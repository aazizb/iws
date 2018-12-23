namespace IWSProject.Controllers
{
    using DevExpress.Web.Mvc;
    using IWSProject.Content;
    using IWSProject.Models;
    using IWSProject.Models.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Linq;
    using System.Data.OleDb;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Web.Mvc;

    [Authorize]
    public class TimeSheetsController : Controller
    {
        IWSDataContext db;
        public TimeSheetsController()
        {
            db = new IWSDataContext();
        }
        // GET: TimeSheets
        public ActionResult Index()
        {
            return View(IWSLookUp.GetTimeSheet());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MasterGridViewPartial()
        {
            return PartialView("MasterGridViewPartial", IWSLookUp.GetTimeSheet());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CallbackPanelPartialView(string selectedIDs)
        {
            return PartialView("CallbackPanelPartialView", IWSLookUp.GetTimeSheet());
        }
        [ValidateInput(false)]
        public ActionResult DetailGridViewPartial(int transId, object newKeyValue)
        {
            if (newKeyValue != null)
            {
                ViewData["IsNewDetailRow"] = true;
            }
            return PartialView("DetailGridViewPartial", IWSLookUp.GetTimeSheetLines(transId));
        }
        [ValidateInput(false)]
        public ActionResult TimeSheetView()
        {
            return PartialView(IWSLookUp.GetTimeSheet());
        }
        [ValidateInput(false)]
        public ActionResult ImportTimeSheets()
        {
            return PartialView("ImportTimeSheets", TimeSheetsFileManagerSettings.Model);
        }
        [ValidateInput(false)]
        public ActionResult TimeSheetsFileManagerPartial()
        {
            return PartialView("_TimeSheetsFileManagerPartial", TimeSheetsFileManagerSettings.Model);
        }
        public FileStreamResult TimeSheetsFileManagerPartialDownload()
        {
            return FileManagerExtension.DownloadFiles("TimeSheetsFileManager", TimeSheetsFileManagerSettings.Model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UploadToDB(string[] files)
        {
            //string[] timeSheetHeader = { "TatigkeitsNachweis", "MonatJahr", "Firma", "Mitarbeiter", "Kunde", "EBNummer", "AuftragsNummer", "SummeDerStunden", "SummeTage" };
            //string[] timeSheetLineHeader = { "Datum", "ArbeitsZeitVon", "ArbeitsZeitBis", "GerundetVon", "GerundetBis", "Pause", "Project", "TatigkeitEinsatzort", "StundenNetto" };
            const string providerXLS = "Provider=Microsoft.ACE.OLEDB.12.0.;Data Source=";
            const string extensionXLS = ";Extended Properties=\"Excel 8.0;HDR=NO;IMEX=2\"";
            const string providerXLSX = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=";
            const string extensionXLSX = ";Extended Properties=\"Excel 12.0 Xml;HDR=NO;IMEX=2\"";
            string companyId = (string)Session["CompanyID"];
            int modelId = (int)IWSLookUp.MetaModelId.TimeSheet;
            int daysInMonth = 0;
            string fullPath = files[0].ToString();
            string msg = string.Empty;
            string fileName = fullPath.Substring(fullPath.IndexOf(@"\") + 1);
            if (fileName.Equals(null))
            {
                return View("ImportTimeSheets");
            }
            int count = 0;
            int rowCount = 0;
            string sheetName = "";
            //int errorAtLine = 0;
            int transId = 0;
            int readDetailFrom = 11;
            try
            {
                string path = Path.Combine(Server.MapPath(TimeSheetsFileManagerSettings.RootFolder), fileName);

                string extension = Path.GetExtension(fileName).ToLower();

                if ((extension != ".xls") && (extension != ".xlsx"))
                {
                    msg = $"{IWSLocalResource.UnsupportedFormat} ";
                    var msgFormat = new { Description = msg };
                    return Json(msgFormat);
                }
                string connectionString = string.Empty;

                DataTable dataTable = new DataTable();

                connectionString = providerXLS + path + extensionXLS;
                if (extension == ".xlsx")
                    connectionString = providerXLSX + path + extensionXLSX;

                OleDbConnection oleDBConnection = new OleDbConnection(connectionString);

                oleDBConnection.Open();
                dataTable = oleDBConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                oleDBConnection.Close();

                if (dataTable == null)
                    return null;

                string[] excelSheets = new string[dataTable.Rows.Count];
                foreach (DataRow row in dataTable.Rows)
                {
                    excelSheets[count] = row["TABLE_NAME"].ToString();
                    sheetName = excelSheets[count].Replace("\'", "");
                    #region key process

                    if (sheetName != "Daten$")
                    {
                        string query = $"Select * from [{excelSheets[count]}]";
                        DataSet dataSet = new DataSet();
                        using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, oleDBConnection))
                        {
                            dataAdapter.Fill(dataSet);
                        }
                        if (!(dataSet.Tables[0].Rows.Count > 0))
                        {
                            string x = $"{IWSLocalResource.GenericError}{Environment.NewLine}{IWSLocalResource.DataFormat} ";

                            var s = new { Description = x };

                            return Json(s);
                        }
                        if (DateTime.TryParse(dataSet.Tables[0].Rows[12][1].ToString(), CultureInfo.GetCultureInfo(Thread.CurrentThread.CurrentUICulture.Name),
                                                            DateTimeStyles.None, out DateTime currentDate))
                        {
                            daysInMonth = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);
                        }
                        else
                        {
                            string x = $"{IWSLocalResource.GenericError}{Environment.NewLine}{IWSLocalResource.DataFormat} ";

                            var s = new { Description = x };

                            return Json(s);
                        }

                        #region TimeSheets Header

                        string TatigkeitsNachweis = dataSet.Tables[0].AsEnumerable().FirstOrDefault().Field<string>(0);
                        string MonatJahr = dataSet.Tables[0].AsEnumerable().Skip(1).FirstOrDefault().Field<string>(11);
                        string Firma = dataSet.Tables[0].AsEnumerable().Skip(3).FirstOrDefault().Field<string>(2);
                        string Mitarbeiter = dataSet.Tables[0].AsEnumerable().Skip(4).FirstOrDefault().Field<string>(2);
                        string Kunde = dataSet.Tables[0].AsEnumerable().Skip(5).FirstOrDefault().Field<string>(2);
                        string EBNummer = dataSet.Tables[0].AsEnumerable().Skip(6).FirstOrDefault().Field<string>(2);
                        string AuftragsNummer = dataSet.Tables[0].AsEnumerable().Skip(7).FirstOrDefault().Field<string>(2);
                        decimal SummeDerStunden =Convert.ToDecimal(dataSet.Tables[0].AsEnumerable().Skip(42).FirstOrDefault().Field<string>(11));
                        decimal SummeTage = Convert.ToDecimal(dataSet.Tables[0].AsEnumerable().Skip(43).FirstOrDefault().Field<string>(11));

                        TimeSheet timeSheet = new TimeSheet
                        {
                            TatigkeitsNachweis = TatigkeitsNachweis,
                            MonatJahr = MonatJahr,
                            Firma = Firma,
                            Mitarbeiter = Mitarbeiter,
                            Kunde = Kunde,
                            EBNummer = EBNummer,
                            AuftragsNummer = AuftragsNummer,
                            SummeDerStunden = SummeDerStunden,
                            SummeTage = SummeTage,
                            IsValidated = false,
                            ModelId = modelId,
                            CompanyId = companyId
                        };

                        #endregion

                        #region TimeSheets Lines

                        List<TimeSheetLine> timeSheetLines = dataSet.Tables[0].AsEnumerable().Skip(readDetailFrom).Take(daysInMonth).
                            Where(x => x.Field<string>(0) != null).Select(t => new TimeSheetLine
                                {
                                    Datum=Convert.ToDateTime( t.Field<string>(1), CultureInfo.GetCultureInfo(Thread.CurrentThread.CurrentUICulture.Name)),
                                    ArbeitsZeitVon= t.Field<string>(2),
                                    ArbeitsZeitBis=t.Field<string>(3),
                                    GerundetVon=t.Field<string>(4),
                                    GerundetBis=t.Field<string>(5),
                                    Pause=t.Field<string>(6),
                                    Project=t.Field<string>(7),
                                    TatigkeitEinsatzort=t.Field<string>(8),
                                    Gerundet=t.Field<string>(10),
                                    StundenNetto=t.Field<string>(11)
                                }).ToList();

                        #endregion

                    if (db.TimeSheets.Any(m => m.MonatJahr.Equals(timeSheet.MonatJahr) && m.Firma.Equals(timeSheet.Firma) &&
                                                m.Mitarbeiter.Equals(timeSheet.Mitarbeiter) && m.Kunde.Equals(timeSheet.Kunde) &&
                                                m.CompanyId.Equals(companyId)))
                    {
                        TimeSheet entity = db.TimeSheets.FirstOrDefault(n => n.MonatJahr.Equals(timeSheet.MonatJahr) && n.Firma.Equals(timeSheet.Firma) &&
                                                                    n.Mitarbeiter.Equals(timeSheet.Mitarbeiter) && n.Kunde.Equals(timeSheet.Kunde) &&
                                                                    n.CompanyId.Equals(companyId));
                        if (entity.IsValidated.Equals(false))
                        {
                            db.TimeSheets.DeleteOnSubmit(entity);
                            db.SubmitChanges(ConflictMode.FailOnFirstConflict);
                        }
                    }

                    db.TimeSheets.InsertOnSubmit(timeSheet);
                    db.SubmitChanges();
                    transId = db.TimeSheets.DefaultIfEmpty().Max(m => m == null ? 0 : m.Id);
                    count += 1;

                    foreach (TimeSheetLine timeSheetLine in timeSheetLines)
                    {
                        timeSheetLine.TransId = transId;
                        db.TimeSheetLines.InsertOnSubmit(timeSheetLine);
                    }
                    db.SubmitChanges(ConflictMode.ContinueOnConflict);
                    int linx = timeSheetLines.Count();
                    rowCount += linx;
                    }

                    #endregion
                }
                if (rowCount > 0)
                {
                    msg = $"{rowCount} {IWSLocalResource.Imported} ";
                }
                else
                {
                    msg = $"{IWSLocalResource.ImportedNone}";
                }
                var Message = new { Description = msg };

                return Json(Message);
            }
            catch (Exception ex)
            {
                IWSLookUp.LogException(ex);

                msg = ex.Message;
                //if (errorAtLine > 0)
                //    msg = $"{msg} {Environment.NewLine} {sheetName}: {errorAtLine + 1}";
                var Message = new { Description = msg };

                return Json(Message);
            }
        }
        public class TimeSheetsFileManagerSettings
        {
            public const string RootFolder = @"~\Content\Uploads\TimeSheets";
            public static string Model { get { return RootFolder; } }
        }
    }
}