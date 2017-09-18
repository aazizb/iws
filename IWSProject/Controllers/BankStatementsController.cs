namespace IWSProject.Controllers
{
    using DevExpress.Web.Mvc;
    using IWSProject.Content;
    using IWSProject.Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Web.Mvc;
    [Authorize]
    //[HandleError]
    public class BankStatementsController : Controller
    {
        IWSDataContext db;
        public BankStatementsController()
        {
            db = new IWSDataContext();
        }
        // GET: BankStatements
        public ActionResult Index()
        {
            List<BankStatementViewModel> model = IWSLookUp.GetBankStatements((string)Session["CompanyID"], false);
            return View(model);
            
        }

        [ValidateInput(false)]
        public ActionResult BankStatementsGridViewPartial()
        {
            List<BankStatementViewModel> model = IWSLookUp.GetBankStatements((string)Session["CompanyID"], false);
            return PartialView(model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult CallbackPanelPartialView(string selectedIDs)
        {
            string msg = string.Empty;

            string selectedItems = selectedIDs;

            try
            {
                if (!string.IsNullOrEmpty(selectedItems))
                {
                    int ItemID = 0;

                    int oid = 0;
                    bool results = false;

                    Decimal amount;

                    IList<string> items = new List<string>(
                        selectedItems.Split(new string[] { ";" },
                            StringSplitOptions.None));

                    foreach (string item in items)
                    {

                        var list = item.Split(new string[] { "," }, StringSplitOptions.None);

                        ItemID = Convert.ToInt32(list[0]);

                        amount = Convert.ToDecimal(list[1]);

                        if (amount == 0)
                        {
                            msg = IWSLocalResource.GenericError;
                            throw new Exception(msg);
                        }
                        if (!IfExist(ItemID))
                        {
                            msg = IWSLocalResource.GenericError;
                            throw new Exception(msg);
                        }

                        if (amount > 0)
                        {
                            oid = MakeSettlement(ItemID, 0);
                            if (oid != 0)
                                results = MakeCustomerInvoice(oid);
                        }
                        if (amount < 0)
                        {
                            oid = MakePayment(ItemID, 0);
                            if (oid != 0)
                                results = MakeVendorInvoice(oid);
                        }

                        if (!results)
                        {
                            msg = IWSLocalResource.GenericError;
                            throw new Exception(msg);
                        }

                        results = ValidateBankStatement(ItemID);

                        if (!results)
                        {
                            msg = IWSLocalResource.GenericError;
                            throw new Exception(msg);
                        }
                        db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                    }
                }
            }
            catch (Exception ex)
            {
                ViewData["GenericError"] = ex.Message;
                IWSLookUp.LogException(ex);
            }
            List<BankStatementViewModel> model=IWSLookUp.GetBankStatements((string)Session["CompanyID"], false);
            return PartialView("CallbackPanelPartialView", model); 
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult BankStatementsGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] BankStatement item)
        {
            var model = db.BankStatements;
            string companyId = (string)Session["CompanyID"];
            item.CompanyID = companyId;

            ViewData["BankStatement"] = item;
            if (ModelState.IsValid)
            {
                try
                {
                    model.InsertOnSubmit(item);
                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    IWSLookUp.LogException(ex);
                }
            }
            else
            {
                ViewData["GenericError"] = IWSLookUp.GetModelSateErrors(ModelState);
            }
            return PartialView("BankStatementsGridViewPartial", 
                    IWSLookUp.GetBankStatements(companyId, false));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult BankStatementsGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] BankStatement item)
        {
            var model = db.BankStatements;
            ViewData["BankStatement"] = item;
            if (ModelState.IsValid)
            {
                try
                {   
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);

                        db.SubmitChanges();
                    }
                }
                catch (Exception ex)
                {
                    ViewData["GenericError"] = ex.Message;
                    IWSLookUp.LogException(ex);
                }
            }
            else
            {
                ViewData["GenericError"] = IWSLookUp.GetModelSateErrors(ModelState);
            }
            return PartialView("BankStatementsGridViewPartial", 
                    IWSLookUp.GetBankStatements((string)Session["CompanyID"], false));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult BankStatementsGridViewPartialDelete(int id)
        {
            var model = db.BankStatements;
            if (id >=0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.id == id);
                    if (item != null)
                        model.DeleteOnSubmit(item);

                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    ViewData["GenericError"] = ex.Message;
                    IWSLookUp.LogException(ex);
                }
            }
            return PartialView("BankStatementsGridViewPartial", 
                    IWSLookUp.GetBankStatements((string)Session["CompanyID"], false)); 
        }

        private object RootFolder = "~/Content/Uploads";

        public ActionResult ImportCSV()
        {
            return View("ImportCSV", RootFolder);
        }
        [ValidateInput(false)]
        public ActionResult ImportCSVPartial(string currentFileName)
        {
            return PartialView("ImportCSVPartial", RootFolder);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UploadToDB(string[] files)
        {
            const string bankStatement = "Auftragskonto;Buchungstag;Valutadatum;" +
                "Buchungstext;Verwendungszweck;Beguenstigter/Zahlungspflichtiger;" +
                "Kontonummer;BLZ;Betrag;Waehrung;Info";

            const string articles = "id;name;description;price";

            const string accounts = "AccountId;AccountName;Balance";

            const string providerXLS = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=";
            const string extensionXLS= ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
            const string providerXLSX = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=";
            const string extensionXLSX= ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
            
            string companyId = (string)Session["CompanyID"];

            //foreach (var item in files)
            //{
            string fullPath = files[0].ToString();
            string msg = string.Empty;
            string option = string.Empty;
            string fileName = fullPath.Substring(fullPath.IndexOf(@"\") + 1);
            if (fileName.Equals(null))
            {
                return View("ImportCSV");
            }
            string[] Fields;
            string Buchungstag;
            string Valutadatum;
            string Betrag;
            int count = 0;
            string Pattern = "^\\d{2}.\\d{2}.\\d{2}$";
            string Headers = String.Empty;
            DataSet dataSet = new DataSet();
            try
            {
                string path = Path.Combine(Server.MapPath(Helper.RootFolder), fileName);

                string extension = Path.GetExtension(fileName).ToLower();

                switch (extension)
                {
                    case ".txt":
                    case ".csv":

                        string[] Lines = System.IO.File.ReadAllLines(path);

                        Headers = Lines.FirstOrDefault().ToString();

                        Headers = Headers.Replace("\"", "");

                        Lines = Lines.Skip(1).ToArray();

                        if(!(Headers.Equals(bankStatement)) && !(Headers.Equals(accounts)) && !(Headers.Equals(articles)))
                        {
                            string x = $"{IWSLocalResource.GenericError}{Environment.NewLine}{IWSLocalResource.DataFormat}";

                            var s = new { Description = x };

                            return Json(s);
                        }

                        if (Headers.Equals(bankStatement))
                        {
                            option = IWSLocalResource.BankStatement;

                            List<BankStatement> BankStatement = new List<BankStatement>();

                            foreach (var line in Lines)
                            {
                                Fields = line.Split(new char[] { ';' });
                                Buchungstag = Fields[1].Replace("\"", "");
                                if (Regex.IsMatch(Buchungstag, Pattern))
                                {
                                    Buchungstag = (Buchungstag.Substring(0, 6) + "20" + Buchungstag.Substring(6, 2)).Replace(".", "/");
                                }
                                Valutadatum = Fields[2].Replace("\"", "");
                                if (Regex.IsMatch(Valutadatum, Pattern))
                                {
                                    Valutadatum = (Valutadatum.Substring(0, 6) + "20" + Valutadatum.Substring(6, 2)).Replace(".", "/");
                                }
                                Betrag = Fields[8].Replace("\"", "");
                                BankStatement.Add(new BankStatement
                                {
                                    Auftragskonto = Fields[0].Replace("\"", ""),
                                    Buchungstag = Convert.ToDateTime(DateTime.ParseExact(Buchungstag, "dd/MM/yyyy", CultureInfo.InvariantCulture)),
                                    Valutadatum = Convert.ToDateTime(DateTime.ParseExact(Valutadatum, "dd/MM/yyyy", CultureInfo.InvariantCulture)),
                                    Buchungstext = Fields[3].Replace("\"", ""),
                                    Verwendungszweck = Fields[4].Replace("\"", ""),
                                    BeguenstigterZahlungspflichtiger = Fields[5].Replace("\"", ""),
                                    Kontonummer = Fields[6].Replace("\"", ""),
                                    BLZ = Fields[7].Replace("\"", ""),
                                    Betrag = Convert.ToDecimal(Betrag),
                                    Waehrung = Fields[9].Replace("\"", ""),
                                    Info = Fields[10].Replace("\"", ""),
                                    CompanyID = companyId
                                });
                            }

                            foreach (var n in BankStatement)
                            {
                                var u = db.BankStatements.Where(o => o.Auftragskonto.Equals(n.Auftragskonto)
                                            && o.BeguenstigterZahlungspflichtiger.Equals(n.BeguenstigterZahlungspflichtiger)
                                            && o.Betrag.Equals(n.Betrag)
                                            && o.BLZ.Equals(n.BLZ)
                                            && o.Buchungstag.Equals(n.Buchungstag)
                                            && o.Buchungstext.Equals(n.Buchungstext)
                                            && o.Info.Equals(n.Info)
                                            //&& o.Kontonummer.Equals(n.Kontonummer)
                                            && o.Valutadatum.Equals(n.Valutadatum)
                                            && o.Verwendungszweck.Equals(n.Verwendungszweck)
                                            && o.Waehrung.Equals(n.Waehrung)
                                            && o.CompanyID.Equals(n.CompanyID)).FirstOrDefault();
                                if (u == null)
                                {
                                    n.IsValidated = false;
                                    db.BankStatements.InsertOnSubmit(n);
                                    count += 1;
                                }
                            }

                        }

                        if (Headers.Equals(accounts))
                        {
                            option = IWSLocalResource.account;

                            List<Account> Account = new List<Account>();
                            foreach (var line in Lines)
                            {
                                Fields = line.Split(new char[] { ';' });

                                Account.Add(new Account
                                {
                                    id = Fields[0],
                                    name = Fields[1],
                                    description = string.Empty,
                                    dateofopen = DateTime.Now,
                                    dateofclose = DateTime.Now,
                                    balance = Convert.ToDecimal(Fields[2]),
                                    CompanyID = companyId,
                                    ParentId = string.Empty,
                                    IsUsed = true
                                });

                            }

                            foreach (var n in Account)
                            {
                                var u = db.Accounts.Where(o => o.id.Equals(n.id)
                                           && o.CompanyID.Equals(n.CompanyID)).FirstOrDefault();
                                if (u == null)
                                {
                                    db.Accounts.InsertOnSubmit(n);
                                    count += 1;
                                }
                            }

                        }


                        if (Headers.Equals(articles))
                        {
                            option = IWSLocalResource.articles;

                            List<Article> Article = new List<Article>();
                            foreach (var line in Lines)
                            {
                                Fields = line.Split(new char[] { ';' });

                                Article.Add(new Article
                                {
                                    id = Fields[0],
                                    name = Fields[1],
                                    description = string.Empty,
                                    CompanyID = companyId,
                                });

                            }

                            foreach (var n in Article)
                            {
                                var u = db.Articles.Where(o => o.id.Equals(n.id)
                                           && o.CompanyID.Equals(n.CompanyID)).FirstOrDefault();
                                if (u == null)
                                {
                                    db.Articles.InsertOnSubmit(n);
                                    count += 1;
                                }
                            }
                        }

                        break;
                    case ".xls":
                    case ".xlsx":

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
                        {
                            return null;
                        }

                        String[] excelSheets = new String[dataTable.Rows.Count];

                        foreach (DataRow row in dataTable.Rows)
                        {
                            excelSheets[count] = row["TABLE_NAME"].ToString();
                            count++;
                        }

                        string query = string.Format("Select * from [{0}]", excelSheets[0]);

                        using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, oleDBConnection))
                        {
                            dataAdapter.Fill(dataSet);
                        }
                        
                        string[] columnNames = dataSet.Tables[0].Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();

                        string[] account = { "id", "name", "balance", "description" };

                        string[] owner = { "id", "name", "street", "city", "state", "zip", "phone", "email", "accountid", "IBAN", "CIF" };

                        if (!account.SequenceEqual(columnNames) && !owner.SequenceEqual(columnNames))
                        {
                            string x = $"{IWSLocalResource.GenericError}{Environment.NewLine}{IWSLocalResource.DataFormat}";

                            var s = new { Description = x };

                            return Json(s);
                        }
                        if(!(dataSet.Tables[0].Rows.Count > 0))
                        {
                            string x = $"{IWSLocalResource.GenericError}{Environment.NewLine}{IWSLocalResource.DataFormat} ";

                            var s = new { Description = x };

                            return Json(s);
                        }
                        if (account.SequenceEqual(columnNames))
                        {

                            List<Account> Accounts = new List<Account>();
                            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                            {
                                Account Account = new Account
                                {
                                    id = dataSet.Tables[0].Rows[i][0].ToString(),
                                    name = dataSet.Tables[0].Rows[i][1].ToString(),
                                    description = dataSet.Tables[0].Rows[i][3].ToString(),
                                    dateofopen = DateTime.Now,
                                    dateofclose = DateTime.Now,
                                    balance = Convert.ToDecimal(dataSet.Tables[0].Rows[i][2].ToString()),
                                    CompanyID = companyId.ToString(),
                                    ParentId = string.Empty,
                                    IsUsed = true
                                };
                                Accounts.Add(Account);
                            }

                            count = 0;

                            foreach (var n in Accounts)
                            {
                                var u = db.Accounts.Where(o => o.id.Equals(n.id)
                                           && o.CompanyID.Equals(n.CompanyID)).FirstOrDefault();
                                if (u == null)
                                {
                                    db.Accounts.InsertOnSubmit(n);
                                    count += 1;
                                }
                            }

                        }

                        if (owner.SequenceEqual(columnNames))
                        {

                            List<Customer> Customers = new List<Customer>();
                            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                            {
                                Customer Customer = new Customer
                                {
                                    id = dataSet.Tables[0].Rows[i][0].ToString(),
                                    name = dataSet.Tables[0].Rows[i][1].ToString(),

                                    CompanyID = companyId.ToString(),

                                };
                                Customers.Add(Customer);
                            }

                            count = 0;

                            foreach (var n in Customers)
                            {
                                var u = db.Customers.Where(o => o.id.Equals(n.id)
                                           && o.CompanyID.Equals(n.CompanyID)).FirstOrDefault();
                                if (u == null)
                                {
                                    db.Customers.InsertOnSubmit(n);
                                    count += 1;
                                }
                            }

                            //==============================
                            List<Supplier> Suppliers = new List<Supplier>();
                            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                            {
                                Supplier Supplier = new Supplier
                                {
                                    id = dataSet.Tables[0].Rows[i][0].ToString(),
                                    name = dataSet.Tables[0].Rows[i][1].ToString(),

                                    CompanyID = companyId.ToString(),

                                };
                                Suppliers.Add(Supplier);
                            }

                            count = 0;

                            foreach (var n in Suppliers)
                            {
                                var u = db.Suppliers.Where(o => o.id.Equals(n.id)
                                           && o.CompanyID.Equals(n.CompanyID)).FirstOrDefault();
                                if (u == null)
                                {
                                    db.Suppliers.InsertOnSubmit(n);
                                    count += 1;
                                }
                            }

                        }
                        break;
                }

                db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);

                if (Headers.Equals(bankStatement))
                {
                    var items =
                        from s in db.BankStatements
                        where
                          s.Buchungstext.ToUpper() == "ABSCHLUSS" &&
                          s.Kontonummer.Length == 0
                        select s;
                        foreach (var item in items)
                        {
                        item.Kontonummer = "DE4748050161XXXXXXXXXX";//("DE47" + item.BLZ + "00" + item.Auftragskonto);
                        }
                        
                    var  ibans =
                        from b in db.BankStatements
                        where
                          b.Auftragskonto == "43006329"
                        select b;
                        foreach (var iban in ibans)
                        {
                        iban.CompanyIBAN = "DE47480501610043006329";
                        }
                    db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);

                    //AddNewAccount();
                }

                if (count > 0)
                {
                    msg= $"{count} {IWSLocalResource.Imported} {option} ";
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
            }
            //}
            var Message = new { Description = msg };

            return Json(Message);
        }

        #region Helper

        private bool MakeCustomerInvoice(int settlementId)
        {
            string companyId = (string)Session["CompanyID"];

            InvoiceViewModel invoice = IWSLookUp.GetInvoiceDetail(settlementId, 
                                            IWSLookUp.DocsType.CustomerInvoice.ToString(), companyId);

            int itemID = 0;

            if (invoice.Equals(null))
                return false;

            CustomerInvoice customerInvoice = new CustomerInvoice
            {
                oid = 0,
                CostCenter = invoice.CostCenter,
                account = invoice.AccountId,
                HeaderText = invoice.HeaderText,
                TransDate = invoice.TransDate,
                ItemDate = invoice.ItemDate,
                EntryDate = invoice.EntryDate,
                CompanyId = invoice.CompanyId,
                IsValidated = false
            };
            itemID = new AccountingController().MakeCustomerInvoiceHeader(customerInvoice);

            if (itemID == 0)
                return false;

            List<LineCustomerInvoice> lineCustomerInvoice = new List<LineCustomerInvoice>
            {
                new LineCustomerInvoice
                {
                    transid = itemID,
                    account = invoice.Account,
                    side = true,
                    oaccount = invoice.OAccount,
                    amount = (decimal)invoice.Amount,
                    Currency = invoice.OCurrency,
                    duedate = invoice.DueDate,
                    text = invoice.Text
                },
                new LineCustomerInvoice
                {
                    transid = itemID,
                    account = invoice.Account,
                    side = true,
                    oaccount = invoice.VatAccountId,
                    amount = (decimal)invoice.VatAmount,
                    Currency = invoice.OCurrency,
                    duedate = invoice.DueDate,
                    text = invoice.Text
                }
            };
            int countLineID = new AccountingController().MakeCustomerInvoiceLine(lineCustomerInvoice);
            if (countLineID != 0)
                return UpdateOid(IWSLookUp.DocsType.Settlement.ToString(), settlementId, itemID);
            return false;
        }

        private bool MakeVendorInvoice(int paymentId)
        {
            string companyId = (string)Session["CompanyID"];

            InvoiceViewModel invoice = IWSLookUp.GetInvoiceDetail(paymentId,
                                            IWSLookUp.DocsType.VendorInvoice.ToString(), companyId);

            int itemID = 0;

            if (invoice.Equals(null))
                return false;

            VendorInvoice vendorInvoice = new VendorInvoice
            {
                oid = 0,
                CostCenter = invoice.CostCenter,
                account = invoice.AccountId,
                HeaderText = invoice.HeaderText,
                TransDate = invoice.TransDate,
                ItemDate = invoice.ItemDate,
                EntryDate = invoice.EntryDate,
                CompanyId = invoice.CompanyId,
                IsValidated = false
            };
            itemID = new AccountingController().MakeVendorInvoiceHeader(vendorInvoice);            

            if (itemID == 0)
                return false;

            List<LineVendorInvoice> lineVendorInvoice = new List<LineVendorInvoice>
            {
                new LineVendorInvoice
                {
                    transid = itemID,
                    account = invoice.Account,
                    side = true,
                    oaccount = invoice.OAccount,
                    amount = (decimal)invoice.Amount,
                    Currency = invoice.OCurrency,
                    duedate = invoice.DueDate,
                    text = invoice.Text
                },
                new LineVendorInvoice
                {
                    transid = itemID,
                    account = invoice.VatAccountId,
                    side = true,
                    oaccount = invoice.OAccount,
                    amount = (decimal)invoice.VatAmount,
                    Currency = invoice.OCurrency,
                    duedate = invoice.DueDate,
                    text = invoice.Text
                }
            };
            int countLineID = new AccountingController().MakeVendorInvoiceLine(lineVendorInvoice);
            if (countLineID != 0)
                return UpdateOid(IWSLookUp.DocsType.Payment.ToString(), paymentId, itemID);
            return false;
        }

        private int MakePayment(int bankStatementID, int oid)
        {
            string companyId = (string)Session["CompanyID"];
            StatementDetailViewModel SD = IWSLookUp.GetStatementDetail(bankStatementID,
                                            IWSLookUp.DocsType.Payment.ToString(), companyId);

            int itemID = 0;

            if (SD==null)
                return itemID;

            Payment payment = new Payment
            {
                oid = oid,
                CostCenter = "200", // to be confirmed
                account = SD.Id,
                HeaderText = SD.Verwendungszweck,
                TransDate = SD.Valutadatum,
                ItemDate = SD.Buchungstag,
                EntryDate = DateTime.Today,
                CompanyId = companyId,
                IsValidated = false
            };
            itemID = new AccountingController().MakePaymentHeader(payment);

            if (!(itemID > 0))
                return itemID;

            List<LinePayment> linePayment = new List<LinePayment>
            {
                new LinePayment
                {
                    transid = itemID,
                    account = SD.AccountID,
                    side = true,
                    oaccount = SD.OAccountID,
                    amount = SD.Betrag,
                    Currency = SD.Waehrung,
                    duedate = SD.Valutadatum,
                    text = SD.Buchungstext
                }
            };
            int countLineID = new AccountingController().MakePaymentLine(linePayment);
            if (countLineID > 0)
            {
                return itemID;

            }
            return countLineID;
        }

        private int MakeSettlement(int bankStatementID, int oid)
        {
            string companyId = (string)Session["CompanyID"];

            StatementDetailViewModel SD = IWSLookUp.GetStatementDetail(bankStatementID,
                                                IWSLookUp.DocsType.Settlement.ToString(), companyId);
            int itemID = 0;

            if (SD.Equals(null))
                return itemID;

            Settlement settlement = new Settlement
                {
                    oid = oid,
                    CostCenter = "100", // to be confirmed
                    account = SD.Id,
                    HeaderText = SD.Verwendungszweck,
                    TransDate = SD.Valutadatum,
                    ItemDate = SD.Buchungstag,
                    EntryDate = DateTime.Today,
                    CompanyId = companyId,
                    IsValidated = false
                };
            itemID = new AccountingController().MakeSettlementHeader(settlement);

            if (!(itemID > 0))
                return itemID;

            List<LineSettlement> lineSettlement = new List<LineSettlement>
                {
                    new LineSettlement
                    {
                        transid = itemID,
                        account = SD.AccountID,
                        side = true,
                        oaccount = SD.OAccountID,
                        amount = SD.Betrag,
                        Currency = SD.Waehrung,
                        duedate = SD.Valutadatum,
                        text = SD.Buchungstext
                    }
                };
            int countLineID = new AccountingController().MakeSettlementLine(lineSettlement);
            if (countLineID > 0)
            {
                return itemID;

            }
            return countLineID;
        }

        private bool ValidateBankStatement(int ItemID)
        {
            try
            { 
                var docs = db.BankStatements.Single(item => item.id == ItemID);

                if (docs.Equals(null))
                    return false;

                docs.IsValidated = true;

                return true;
            }
            catch (Exception ex)
            {
                ViewData["GenericError"] = ex.Message;
                IWSLookUp.LogException(ex);
                return false;
            }
        }

        private bool IfExist(int ItemID)
        {

            try
            {
                var docs = db.BankStatements.Single(item => item.id == ItemID);

                if (docs==null)
                    return false;
                return db.BankAccounts.Any(i => i.IBAN == docs.CompanyIBAN);
            }
            catch (Exception ex)
            {
                ViewData["GenericError"] = ex.Message;
                IWSLookUp.LogException(ex);
                return false;
                
            }
        }

        private bool UpdateOid(string itemType, int itemId, int itemOid)
        {
            try
            {
                if (itemType.Equals(IWSLookUp.DocsType.Payment.ToString()))
                {
                    var docs = db.Payments.Single(item => item.id == itemId);
                    if (docs != null)
                    {
                        docs.oid = itemOid;
                        return true;
                    }
                }
                if (itemType.Equals(IWSLookUp.DocsType.Settlement.ToString()))
                {
                    var docs = db.Settlements.Single(item => item.id == itemId);
                    if (docs != null)
                    {
                        docs.oid = itemOid;
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                ViewData["GenericError"] = ex.Message;
                IWSLookUp.LogException(ex);
            }
            return false;
        }

        //public List<Account> GetAccounts(DataTable dataTable)
        //{
        //    List<Account> accounts = new List<Account>();

        //    int count = 0;

        //    String[] sheets = new String[dataTable.Rows.Count];

        //    foreach (DataRow row in dataTable.Rows)
        //    {
        //        sheets[count] = row["TABLE_NAME"].ToString();
        //        count++;
        //    }

        //    string query = string.Format("Select * from [{0}]", sheets[0]);

        //    return accounts;
        //}
        //public Account GetAccount(DataRow row)
        //{
        //    string companyId = (string)Session["CompanyID"];
        //    Account account = new Account
        //    {
        //        id = row[2].ToString(),
        //        name = "NAAN",// row[1].ToString(),
        //        description = string.Empty,
        //        dateofopen = DateTime.Now,
        //        dateofclose = DateTime.Now,
        //        balance = 0,//Convert.ToDecimal(row[3] ),
        //        CompanyID = companyId.ToString(),
        //        ParentId = string.Empty,
        //        IsUsed = true
        //    };
  
        //    return account;
        //}

        //public DataTable ReadExcel(string path)
        //{

        //    string connectionString = String.Empty; ;

        //    DataTable dataTable = new DataTable();

        //    try
        //    {
        //        string extension = Path.GetExtension(path).ToLower();
                
        //        if (extension == ".xls")
        //        {
        //            connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
        //            path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
        //        }
        //        else if (extension == ".xlsx")
        //        {
        //            connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
        //            path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
        //        }

        //        OleDbConnection oleDBConnection = new OleDbConnection(connectionString);

        //        oleDBConnection.Open();
        //        dataTable = oleDBConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        //        oleDBConnection.Close();

        //        return dataTable;
        //    }
        //    catch(Exception ex)
        //    {
        //        IWSLookUp.LogException(ex);
        //        throw;
        //    }
        //}

        public class Helper
        {
            public const string RootFolder = "~/Content/Uploads";
            public static string Model { get { return RootFolder; } }

            public static string[] AllowedFileExtensions = new string[] { ".csv", ".txt", ".xls", ".xlsx" };
        }

        #endregion

    }

}