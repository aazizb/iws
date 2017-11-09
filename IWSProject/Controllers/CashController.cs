﻿using DevExpress.Web.Mvc;
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
    public class CashController : Controller
    {
        IWSDataContext db;
        public CashController()
        {
            db = new IWSDataContext();
        }
        private object RootFolder = "~/Content/Uploads";
        public ActionResult Cash()
        {
            return View("Cash", RootFolder);
        }
        // GET: cash
        public ActionResult Index()
        {
            return View(IWSLookUp.GetCash());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MasterGridViewPartial()
        {
            return PartialView("MasterGridViewPartial", IWSLookUp.GetCash());
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
                    int transId = 0;
                    string itemType = String.Empty;
                    string outputVataccountId = String.Empty;
                    decimal vat;

                    bool withdrawal = true;

                    string companyId= (string)Session["CompanyID"];

                    selectedIDs = SetDocType(selectedIDs, IWSLookUp.DocsType.Cash.ToString());

                    IList<string> items = new List<string>( selectedIDs.Split(new string[] { ";" },
                                                                StringSplitOptions.None));
                    foreach (string item in items)
                    {

                        var list = item.Split(new string[] { "," }, StringSplitOptions.None);

                        itemId = Convert.ToInt32(list[0]);

                        itemType = list[1];

                        List<CashLine> CashLines = IWSLookUp.GetCashLines(itemId);

                        foreach (CashLine cashLine in CashLines)
                        {
                            
                            GeneralLedger generalLedger = new GeneralLedger
                            {
                                oid = itemId,
                                CostCenter = cashLine.CostCenter,
                                Area =itemType,
                                HeaderText=cashLine.Beschreibung,
                                TransDate=cashLine.Datum,
                                ItemDate=cashLine.Datum,
                                EntryDate=DateTime.Now,
                                CompanyId=companyId,
                                IsValidated=false
                            };

                            vat= (String.IsNullOrEmpty(cashLine.SteuerSatz))?0: Convert.ToDecimal(cashLine.SteuerSatz)/100;

                            db.GeneralLedgers.InsertOnSubmit(generalLedger);
                            db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                            transId = db.GeneralLedgers.Where(c => c.CompanyId == companyId).Max(c => c.id);

                            cashLine.TransId = transId;

                            withdrawal = cashLine.Ausgaben > cashLine.Einnahmen;
                      
                            LineGeneralLedger lineGeneralLedger = new LineGeneralLedger
                            {
                                transid=cashLine.TransId,
                                account= cashLine.Gegenkonto,
                                side=cashLine.Side??false,
                                oaccount= cashLine.konto,
                                amount= (withdrawal==true)? (vat == 0) ? cashLine.Ausgaben : cashLine.Ausgaben * (1 - vat):cashLine.Einnahmen,
                                duedate =cashLine.Datum,
                                text=cashLine.Beschreibung,
                                Currency=cashLine.Currency
                            };
                            db.LineGeneralLedgers.InsertOnSubmit(lineGeneralLedger);
                            if (vat != 0)
                            {
                                outputVataccountId = IWSLookUp.GetVatAccountId(vat);
                                lineGeneralLedger = new LineGeneralLedger
                                {
                                    transid = cashLine.TransId,
                                    account = outputVataccountId,
                                    side = cashLine.Side ?? false,
                                    oaccount = cashLine.konto,
                                    amount = cashLine.Ausgaben *  vat,
                                    duedate = cashLine.Datum,
                                    text = cashLine.Beschreibung,
                                    Currency = cashLine.Currency
                                };
                            }

                            db.LineGeneralLedgers.InsertOnSubmit(lineGeneralLedger);
                            
                            db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                        }

                    }
                    db.Cashes.Where(c => intIDs.Contains(c.Id)).ToList().ForEach(d => d.IsValidated = true);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                ViewData["GenericError"] = ex.Message;
                IWSLookUp.LogException(ex);
            }
            return PartialView("CallbackPanelPartialView", IWSLookUp.GetCash());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MasterGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Cash item)
        {
            var model = db.Cashes;
            item.IsValidated = false;
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
            return PartialView("MasterGridViewPartial", IWSLookUp.GetCash());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MasterGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Cash item)
        {
            var model = db.Cashes;
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
            return PartialView("MasterGridViewPartial", IWSLookUp.GetCash());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MasterGridViewPartialDelete(int id)
        {
            var model = db.Cashes;

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
            return PartialView("MasterGridViewPartial", IWSLookUp.GetCash());
        }
        [ValidateInput(false)]
        public ActionResult DetailGridViewPartial(int transId, object newKeyValue)
        {
            if (newKeyValue != null)
            {
                ViewData["IsNewDetailRow"] = true;
            }
            return PartialView("DetailGridViewPartial", IWSLookUp.GetCashLines(transId));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DetailGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] CashLine line, int transId)
        {
            var model = db.CashLines;
            line.TransId = transId;
            ViewData["line"] = line;
            if (ModelState.IsValid)
            {
                try
                {
                    model.InsertOnSubmit(line);

                    db.SubmitChanges();
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
            return PartialView("DetailGridViewPartial", IWSLookUp.GetCashLines(transId));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DetailGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] CashLine line, int transId)
        {
            var model = db.CashLines;
            line.TransId = transId;

            ViewData["line"] = line;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.Id == line.Id);

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
            return PartialView("DetailGridViewPartial", IWSLookUp.GetCashLines(transId));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DetailGridViewPartialDelete(int Id, int transId)
        {

            var model = db.CashLines;
            if (Id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.Id == Id);

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
            return PartialView("DetailGridViewPartial", IWSLookUp.GetCashLines(transId));
        }

        [ValidateInput(false)]
        public ActionResult CashPartial(string currentFileName)
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

        private string MakeGeneralLedger(int ItemId, string ItemType)
        {



            return null;
        }

        #endregion

        [HttpPost, ValidateInput(false)]
        public ActionResult CashToDb(string[] files)
        {
            const string providerXLS = "Provider=Microsoft.ACE.OLEDB.12.0.;Data Source=";
            const string extensionXLS = ";Extended Properties=\"Excel 8.0;HDR=NO;IMEX=2\"";
            const string providerXLSX = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=";
            const string extensionXLSX = ";Extended Properties=\"Excel 12.0 Xml;HDR=NO;IMEX=2\"";
            string companyId = (string)Session["CompanyID"];
            //foreach (var item in files)
            //{
            string fullPath = files[0].ToString();
            string msg = string.Empty;
            string option = string.Empty;
            string fileName = fullPath.Substring(fullPath.IndexOf(@"\") + 1);
            if (fileName.Equals(null))
            {
                return View("Cash");
            }
            int count = 0;
            int rowCount = 0;
            string sheetName="";
            int errorAtLine = 0;
            int transId = 0;
            int notImported = 0;
            int readReportFrom = 6;
            int readPeriodFrom = 3;
            decimal monthInitialReport = 0;
            string sYear = String.Empty;
            string sMonth = String.Empty;
            
            string Headers = String.Empty;
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

                    string cashAccountId = IWSLookUp.GetCashAccountId();

                    string currency = IWSLookUp.DefaultCurrency();

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
                        //if (headers.SequenceEqual(columnNames))
                        //{

                        List<CashLine> CashLine = new List<CashLine>();

                        for (int i = 1; i < dataSet.Tables[0].Rows.Count; i++)
                        {
                            #region Cash Header

                            if (i == readPeriodFrom)
                            {
                                sYear = dataSet.Tables[0].Rows[i][4].ToString();
                                sMonth = dataSet.Tables[0].Rows[i][1].ToString();
                            }
                            if (i == readReportFrom)
                            {
                                monthInitialReport = Convert.ToDecimal(dataSet.Tables[0].Rows[i][2]);
                            }

                            #endregion

                            #region Cash Lines

                            errorAtLine += 1;

                            if (i>readReportFrom)
                            {

                                if (DateTime.TryParse(dataSet.Tables[0].Rows[i][5].ToString(), out DateTime datumValue))
                                {
                                    CashLine cashLine = new CashLine
                                    {
                                        Einnahmen = dataSet.Tables[0].Rows[i][0] == DBNull.Value ? 0 : Convert.ToDecimal(dataSet.Tables[0].Rows[i][0]),
                                        Ausgaben = dataSet.Tables[0].Rows[i][1] == DBNull.Value ? 0 : Convert.ToDecimal(dataSet.Tables[0].Rows[i][1]),
                                        Bestand = dataSet.Tables[0].Rows[i][2] == DBNull.Value ? 0 : Convert.ToDecimal(dataSet.Tables[0].Rows[i][2]),
                                        Currency = currency,
                                        konto = cashAccountId,
                                        Gegenkonto = dataSet.Tables[0].Rows[i][3] == DBNull.Value ? null : dataSet.Tables[0].Rows[i][3].ToString(),
                                        BelegNr = dataSet.Tables[0].Rows[i][4] == DBNull.Value ? null : dataSet.Tables[0].Rows[i][4].ToString(),
                                        Datum = datumValue,
                                        SteuerSatz = dataSet.Tables[0].Rows[i][6] == DBNull.Value ? null : dataSet.Tables[0].Rows[i][6].ToString(),
                                        Beschreibung = dataSet.Tables[0].Rows[i][7] == DBNull.Value ? null : dataSet.Tables[0].Rows[i][7].ToString(),
                                        CostCenter=dataSet.Tables[0].Rows[i][8] == DBNull.Value ? null : dataSet.Tables[0].Rows[i][8].ToString()
                                    };

                                    CashLine.Add(cashLine);
                                }
                                else
                                {
                                    notImported += 1;
                                }
                            }

                            #endregion
                        }
                        errorAtLine = 0;
                        if(db.Cashes.Any(m=>m.SYear.Equals(sYear) && m.SMonth.Equals(sMonth) && m.CompanyId.Equals(companyId)))
                        {
                            Cash entity = db.Cashes.FirstOrDefault(n => n.CompanyId.Equals(companyId) && n.SYear.Equals(sYear) && n.SMonth.Equals(sMonth));
                            if (entity.IsValidated.Equals(false))
                            {
                                db.Cashes.DeleteOnSubmit(entity);
                                db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                            }
                        }

                        count += 1;

                        Cash cash = new Cash  
                        {
                            Account = cashAccountId,
                            SYear = sYear,
                            SMonth = sMonth,
                            Report = monthInitialReport,
                            IsValidated = false,
                            CompanyId = companyId
                        };

                        db.Cashes.InsertOnSubmit(cash);
                        db.SubmitChanges();
                        transId = db.Cashes.DefaultIfEmpty().Max(m => m == null ? 0 : m.Id);
                        notImported = 0;

                        foreach (CashLine cashLine in CashLine)  
                        {
                            cashLine.TransId = transId;
                            db.CashLines.InsertOnSubmit(cashLine);
                            rowCount += 1;
                        }
                        //}
                    }
                    db.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
                }

                if (rowCount > 0)
                {
                    msg = $"{rowCount} {IWSLocalResource.Imported} {option} ";
                }
                else
                {
                    msg = $"{IWSLocalResource.ImportedNone}";
                }
            }
            catch (Exception ex)
            {
                IWSLookUp.LogException(ex);

                msg = ex.Message;
                if (errorAtLine > 0)
                    msg = $"{msg} {Environment.NewLine} {sheetName}: {errorAtLine+1}";
            }
            //}
            var Message = new { Description = msg };

            return Json(Message);
        }

    }
}