using DevExpress.Web.Mvc;
using IWSProject.Content;
using IWSProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Transactions;
using System.Web.Mvc;
namespace IWSProject.Controllers
{
    [Authorize]
    public class BrouillardController : Controller
    {
        IWSDataContext db;
        public BrouillardController()
        {
            db = new IWSDataContext();
        }
        private object RootFolder = "~/Content/Uploads";
        public ActionResult Brouillard()
        {
            return View("Brouillard", RootFolder);
        }
        // GET: Brouillard
        public ActionResult Index()
        {
            return View(IWSLookUp.GetBrouillard());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MasterGridViewPartial()
        {
            return PartialView("MasterGridViewPartial", IWSLookUp.GetBrouillard());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CallbackPanelPartialView(string selectedIDs)
        {

            try
            {
                if (!string.IsNullOrEmpty(selectedIDs))
                {

                    string[] stringIDs = selectedIDs.Split(new string[] { ";" },
                                                StringSplitOptions.RemoveEmptyEntries);

                    int[] intIDs = stringIDs.Select(int.Parse).ToArray();

                    int itemId = 0;
                    //int transId = 0;
                    string itemType = String.Empty;
                    string outputVataccountId = String.Empty;
                    //decimal vat;

                    //bool withdrawal = true;

                    string companyId = (string)Session["CompanyID"];

                    selectedIDs = SetDocType(selectedIDs, IWSLookUp.DocsType.Brouillard.ToString());

                    IList<string> items = new List<string>(selectedIDs.Split(new string[] { ";" },
                                                                StringSplitOptions.None));
                    foreach (string item in items)
                    {

                        var list = item.Split(new string[] { "," }, StringSplitOptions.None);

                        itemId = Convert.ToInt32(list[0]);

                        itemType = list[1];

                        //List<Brouillard> Brouillard = IWSLookUp.GetBrouillardLines(itemId);

                        //foreach (BrouillardLine BrouillardLine in Brouillard)
                        //{

                        //    GeneralLedger generalLedger = new GeneralLedger
                        //    {
                        //        oid = itemId,
                        //        CostCenter = BrouillardLine.CostCenter,
                        //        Area = itemType,
                        //        HeaderText = BrouillardLine.Beschreibung,
                        //        TransDate = BrouillardLine.Datum,
                        //        ItemDate = BrouillardLine.Datum,
                        //        EntryDate = DateTime.Now,
                        //        CompanyId = companyId,
                        //        IsValidated = false
                        //    };

                        //    vat = (String.IsNullOrEmpty(BrouillardLine.SteuerSatz)) ? 0 : Convert.ToDecimal(BrouillardLine.SteuerSatz) / 100;

                        //    db.GeneralLedgers.InsertOnSubmit(generalLedger);
                        //    db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                        //    transId = db.GeneralLedgers.Where(c => c.CompanyId == companyId).Max(c => c.id);

                        //    BrouillardLine.TransId = transId;

                        //    withdrawal = BrouillardLine.Ausgaben > BrouillardLine.Einnahmen;

                        //    LineGeneralLedger lineGeneralLedger = new LineGeneralLedger
                        //    {
                        //        transid = BrouillardLine.TransId,
                        //        account = BrouillardLine.Gegenkonto,
                        //        side = BrouillardLine.Side ?? false,
                        //        oaccount = BrouillardLine.konto,
                        //        amount = (withdrawal == true) ? (vat == 0) ? BrouillardLine.Ausgaben : BrouillardLine.Ausgaben * (1 - vat) : BrouillardLine.Einnahmen,
                        //        duedate = BrouillardLine.Datum,
                        //        text = BrouillardLine.Beschreibung,
                        //        Currency = BrouillardLine.Currency
                        //    };
                        //    db.LineGeneralLedgers.InsertOnSubmit(lineGeneralLedger);
                        //    if (vat != 0)
                        //    {
                        //        outputVataccountId = IWSLookUp.GetVatAccountId(vat);
                        //        lineGeneralLedger = new LineGeneralLedger
                        //        {
                        //            transid = BrouillardLine.TransId,
                        //            account = outputVataccountId,
                        //            side = BrouillardLine.Side ?? false,
                        //            oaccount = BrouillardLine.konto,
                        //            amount = BrouillardLine.Ausgaben * vat,
                        //            duedate = BrouillardLine.Datum,
                        //            text = BrouillardLine.Beschreibung,
                        //            Currency = BrouillardLine.Currency
                        //        };
                        //    }

                        //    db.LineGeneralLedgers.InsertOnSubmit(lineGeneralLedger);

                        //    db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                        //}

                    }
                    //db.Brouillardes.Where(c => intIDs.Contains(c.Id)).ToList().ForEach(d => d.IsValidated = true);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                ViewData["GenericError"] = ex.Message;
                IWSLookUp.LogException(ex);
            }
            return PartialView("CallbackPanelPartialView", IWSLookUp.GetBrouillard());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MasterGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Brouillard item)
        {
            var model = db.Brouillards;

            item.CompanyId = (string)Session["CompanyID"];
            ViewData["item"] = item;
            ViewBag.IsNewRow = true;
            if (ModelState.IsValid)
            {
                try
                {
                    model.InsertOnSubmit(item);
                    db.SubmitChanges();
                    ViewData["NewKeyValue"] = item.Id;
                }
                catch (Exception e)
                {
                    ViewData["GenericError"] = e.Message;
                    IWSLookUp.LogException(e);
                }
            }
            else
            {
                ViewData["GenericError"] = IWSLookUp.GetModelSateErrors(ModelState);
            }
            return PartialView("MasterGridViewPartial", IWSLookUp.GetBrouillard());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MasterGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Brouillard item)
        {
            var model = db.Brouillards;
            ViewData["item"] = item;
            ViewBag.IsNewRow = false;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.Id == item.Id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);

                        db.SubmitChanges();

                    }
                }
                catch (Exception e)
                {
                    ViewData["GenericError"] = e.Message;
                    IWSLookUp.LogException(e);
                }
            }
            else
            {
                ViewData["GenericError"] = IWSLookUp.GetModelSateErrors(ModelState);
            }
            return PartialView("MasterGridViewPartial", IWSLookUp.GetBrouillard());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MasterGridViewPartialDelete(int id)
        {
            var model = db.Brouillards;

            if (id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.Id == id);
                    if (item != null)
                        model.DeleteOnSubmit(item);

                    db.SubmitChanges();
                }
                catch (Exception e)
                {
                    ViewData["GenericError"] = e.Message;
                    IWSLookUp.LogException(e);
                }
            }
            return PartialView("MasterGridViewPartial", IWSLookUp.GetBrouillard());
        }

        [ValidateInput(false)]
        public ActionResult BrouillardPartial(string currentFileName)
        {
            return PartialView(RootFolder);
        }

        #region Helper
        private class Helper
        {
            public const string RootFolder = "~/Content/Uploads";
            public static string Model { get { return RootFolder; } }

            public static string[] AllowedFileExtensions = new string[] { ".xls", ".xlsx" };
        }
        private string SetDocType(string selectedItems, string docType)
        {

            string[] items = selectedItems.Split(new string[] { ";" },
                                        StringSplitOptions.RemoveEmptyEntries);

            items = items.Select(x => x + "," + docType).ToArray();

            return String.Join(";", items);
        }

        #endregion

        [HttpPost, ValidateInput(false)]
        public ActionResult UploadBrouillardToDb(string[] files)
        {
            const string providerXLS = "Provider=Microsoft.ACE.OLEDB.12.0.;Data Source=";
            const string extensionXLS = ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"";
            const string providerXLSX = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=";
            const string extensionXLSX = ";Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\"";
            string companyId = (string)Session["CompanyID"];
            string typeDoc = String.Empty;
            //foreach (var item in files)
            //{
            string fullPath = files[0].ToString();
            string msg = string.Empty;
            string option = string.Empty;
            string fileName = fullPath.Substring(fullPath.IndexOf(@"\") + 1);
            if (fileName.Equals(null))
            {
                return View("Brouillard");
            }

            string sheetName = String.Empty;

            string periode = String.Empty;

            string accountId = String.Empty;

            int count = 0;
            try
            {
                string path = Path.Combine(Server.MapPath(Helper.RootFolder), fileName);

                string extension = Path.GetExtension(fileName).ToLower();

                if (extension == ".xls" || extension == ".xlsx")
                {
                    string connectionString = String.Empty;

                    DataTable dataTable = new DataTable();

                    if (extension == ".xls")
                    {
                        connectionString = providerXLS + path + extensionXLS;
                    }
                    else if (extension == ".xlsx")
                    {
                        connectionString = providerXLSX + path + extensionXLSX;
                    }

                    OleDbConnection oleDBConnection = new OleDbConnection(connectionString);

                    oleDBConnection.Open();
                    dataTable = oleDBConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    oleDBConnection.Close();

                    if (dataTable == null)
                        return null;

                    String[] excelSheets = new String[dataTable.Rows.Count];

                    List<Brouillard> Brouillards = new List<Models.Brouillard>();

                    foreach (DataRow row in dataTable.Rows)
                    {
                        excelSheets[count] = row["TABLE_NAME"].ToString();

                        sheetName = excelSheets[count].Replace("\'", "");

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

                        Brouillards = dataSet.Tables[0].AsEnumerable().
                            Select(b => new Brouillard
                            {
                                Date = b.Field<Double>("Date").ToString(),
                                NumPiece = b.Field<Double>("NumPiece").ToString(),
                                AccountID = b.Field<Double>("AccountID").ToString(),
                                Owner = b.Field<String>("Owner"),
                                Text = b.Field<String>("Text"),
                                Debit = b.Field<Double?>("Debit").ToString(),
                                Credit = b.Field<Double?>("Credit").ToString(),
                                TypeDoc = typeDoc,
                                CompanyId = companyId,
                                IsValidated = false
                            }).ToList<Brouillard>();

                        count += 1;
                    }
                    db.Brouillards.InsertAllOnSubmit(Brouillards);
                    db.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
                }
            }
            catch (Exception ex)
            {
                IWSLookUp.LogException(ex);
            }
            //}
            return View("Brouillard");
        }

    }
}