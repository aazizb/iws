namespace IWSProject.Controllers
{
    using DevExpress.Web.Mvc;
    using IWSProject.Content;
    using IWSProject.Models;
    using IWSProject.Models.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Data.Linq;
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
            #region data processing
            string msg = string.Empty;
            string selectedItems = selectedIDs;
            int modelId = 0;
            try
            {
                if (!string.IsNullOrWhiteSpace(selectedItems))
                {
                    int itemId = 0;

                    int OID = 0;
                    bool results = false;

                    Decimal amount;
                    string IBAN;
                    IList<string> items = new List<string>(
                        selectedItems.Split(new string[] { ";" },
                            StringSplitOptions.None));

                    foreach (string item in items)
                    {

                        var list = item.Split(new string[] { "," }, StringSplitOptions.None);

                        itemId = Convert.ToInt32(list[0]);

                        IEnumerable<AccountAmountViewModel> accountAmount = IWSLookUp.GetAccountAmounts(itemId).Cast<AccountAmountViewModel>();

                        List<tempAccountAmount> ls = db.tempAccountAmounts.ToList();
                        foreach (var l in ls)
                        {
                            db.tempAccountAmounts.DeleteOnSubmit(l);
                        }
                        db.SubmitChanges();

                        tempAccountAmount temp = new tempAccountAmount();

                        foreach (AccountAmountViewModel itemx in accountAmount)
                        {
                            temp = new tempAccountAmount
                            {
                                AccountCode = itemx.AccountCode,
                                AccountAmount = itemx.AccountAmount
                            };

                            db.tempAccountAmounts.InsertOnSubmit(temp);
                        }
                        db.SubmitChanges();


                        amount = Convert.ToDecimal(list[1], CultureInfo.InvariantCulture);

                        IBAN = list[2];

                        if (amount == 0)
                        {
                            msg = IWSLocalResource.GenericError;
                            throw new Exception(msg);
                        }
                        if (!IfExist(itemId))
                        {
                            msg = IWSLocalResource.GenericError;
                            throw new Exception(msg);
                        }
                        var owner = IWSLookUp.GetOwnerType(IBAN);

                        if (amount > 0)
                        {
                            if (owner.OwnerType == "Customer")
                            {
                                modelId = (int)IWSLookUp.ComptaMasterModelId.Settlement;
                                OID = MakeComptaMaster(itemId, OID, modelId,
                                        IWSLookUp.ComptaMasterModelId.Settlement.ToString());
                                if (OID != 0)
                                {
                                    modelId = (int)IWSLookUp.ComptaMasterModelId.CustomerInvoice;
                                    results = MakeComptaMaster(itemId, OID, modelId,
                                            IWSLookUp.ComptaMasterModelId.CustomerInvoice.ToString()) != 0;
                                }
                            }
                            if (owner.OwnerType == "Supplier")
                            {
                                modelId = (int)IWSLookUp.ComptaMasterModelId.GeneralLedger;
                                results = MakeComptaMaster(itemId, 0, modelId,
                                            IWSLookUp.ComptaMasterModelId.GeneralLedger.ToString()) != 0;
                            }
                        }
                        if (amount < 0)
                        {
                            modelId = (int)IWSLookUp.ComptaMasterModelId.Payment;
                            OID = MakeComptaMaster(itemId, OID, modelId,
                                        IWSLookUp.ComptaMasterModelId.Payment.ToString());
                            if (OID != 0)
                            {
                                modelId = (int)IWSLookUp.ComptaMasterModelId.VendorInvoice;
                                results = MakeComptaMaster(itemId, OID, modelId,
                                        IWSLookUp.ComptaMasterModelId.VendorInvoice.ToString()) != 0;
                            }
                        }

                        if (!results)
                        {
                            msg = IWSLocalResource.GenericError;
                            throw new Exception(msg);
                        }

                        results = ValidateBankStatement(itemId);

                        if (!results)
                        {
                            msg = IWSLocalResource.GenericError;
                            throw new Exception(msg);
                        }

                        results = ReferenceInvoice(OID);
                        if (results)
                            db.SubmitChanges(ConflictMode.FailOnFirstConflict);
                    }
                }
            }
            catch (Exception ex)
            {
                ViewData["GenericError"] = ex.Message;
                IWSLookUp.LogException(ex);
            }
            #endregion
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
        [ValidateInput(false)]
        public ActionResult BankStatementView()
        {
            List<BankStatementViewModel> model = IWSLookUp.GetBankStatements((string)Session["CompanyID"], false);
            return PartialView(model);
        }

        public ActionResult CustomGridViewCallback(bool isChecked)
        {
            ViewBag.select = isChecked;
            List<BankStatementViewModel> model = IWSLookUp.GetBankStatements((string)Session["CompanyID"], false);
            return PartialView("BankStatementsGridViewPartial", model);
        }
        private readonly object RootFolder = "~/Content/Uploads";
        [ValidateInput(false)]
        public ActionResult ImportCSV()
        {
            return PartialView("ImportCSV", RootFolder);
        }

        [ValidateInput(false)]
        public ActionResult ImportCSVPartial()
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

            const string accounts = "id;name;balance;description";

            const string providerXLS = "Provider=Microsoft.ACE.OLEDB.12.0.;Data Source=";
            const string extensionXLS = ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=2\"";
            const string providerXLSX = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=";
            const string extensionXLSX = ";Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=2\"";

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
                                    n.ModelId = (int)IWSLookUp.MetaModelId.BankStatement;
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
                                    description = Fields[3],
                                    dateofopen = DateTime.Now,
                                    dateofclose = DateTime.Now,
                                    balance = Convert.ToDecimal(Fields[2]),
                                    CompanyID = companyId,
                                    ParentId = string.Empty,
                                    IsUsed = true
                                });

                            }

                            foreach (var item in Account)
                            {
                                var u = db.GetAccounts().Where(o => o.id.Equals(item.id)
                                           && o.CompanyID.Equals(item.CompanyID)).FirstOrDefault();
                                if (u == null)
                                {
                                    db.GetAccounts().InsertOnSubmit(item);
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
                                    description = Fields[2],
                                    price= Convert.ToDecimal(Fields[3]),
                                    CompanyID = companyId,
                                });

                            }

                            foreach (var item in Article)
                            {
                                var u = db.Articles.Where(o => o.id.Equals(item.id)
                                           && o.CompanyID.Equals(item.CompanyID)).FirstOrDefault();
                                if (u == null)
                                {
                                    db.Articles.InsertOnSubmit(item);
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

                        string[] customer = { "customerid", "name", "street", "city", "state", "zip", "phone", "email", "accountid", "IBAN" };

                        string[] supplier = { "supplierid", "name", "street", "city", "state", "zip", "phone", "email", "accountid", "IBAN" };

                        if (!account.SequenceEqual(columnNames) && !customer.SequenceEqual(columnNames) && !supplier.SequenceEqual(columnNames))
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
                                var u = db.GetAccounts().Where(o => o.id.Equals(n.id)
                                           && o.CompanyID.Equals(n.CompanyID)).FirstOrDefault();
                                if (u == null)
                                {
                                    db.GetAccounts().InsertOnSubmit(n);
                                    count += 1;
                                }
                            }

                        }

                        if (customer.SequenceEqual(columnNames))
                        {

                            List<Customer> Customers = new List<Customer>();
                            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                            {
                                Customer Customer = new Customer
                                {
                                    id = dataSet.Tables[0].Rows[i][0].ToString(),
                                    name = dataSet.Tables[0].Rows[i][1].ToString(),
                                    street = dataSet.Tables[0].Rows[i][2].ToString(),
                                    city = dataSet.Tables[0].Rows[i][3].ToString(),
                                    state = dataSet.Tables[0].Rows[i][4].ToString(),
                                    zip = dataSet.Tables[0].Rows[i][5].ToString(),
                                    Phone = dataSet.Tables[0].Rows[i][6].ToString(),
                                    Email = dataSet.Tables[0].Rows[i][7].ToString(),
                                    accountid = dataSet.Tables[0].Rows[i][8].ToString(),
                                    CompanyID = companyId.ToString(),
                                    IBAN = dataSet.Tables[0].Rows[i][9].ToString()
                                };
                                Customers.Add(Customer);
                            }

                            count = 0;

                            foreach (var item in Customers)
                            {
                                var u = db.Customers.Where(o => o.id.Equals(item.id)
                                           && o.CompanyID.Equals(item.CompanyID)).FirstOrDefault();
                                if (u == null)
                                {
                                    db.Customers.InsertOnSubmit(item);
                                    count += 1;
                                }
                            }

                        }

                        if (supplier.SequenceEqual(columnNames))
                        {

                            List<Supplier> Suppliers = new List<Supplier>();
                            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                            {
                                Supplier Supplier = new Supplier
                                {
                                    id = dataSet.Tables[0].Rows[i][0].ToString(),
                                    name = dataSet.Tables[0].Rows[i][1].ToString(),
                                    street = dataSet.Tables[0].Rows[i][2].ToString(),
                                    city = dataSet.Tables[0].Rows[i][3].ToString(),
                                    state = dataSet.Tables[0].Rows[i][4].ToString(),
                                    zip = dataSet.Tables[0].Rows[i][5].ToString(),
                                    Phone = dataSet.Tables[0].Rows[i][6].ToString(),
                                    Email = dataSet.Tables[0].Rows[i][7].ToString(),
                                    accountid = dataSet.Tables[0].Rows[i][8].ToString(),
                                    CompanyID = companyId.ToString(),
                                    IBAN = dataSet.Tables[0].Rows[i][9].ToString()
                                };
                                Suppliers.Add(Supplier);
                            }

                            count = 0;

                            foreach (var item in Suppliers)
                            {
                                var u = db.Suppliers.Where(o => o.id.Equals(item.id)
                                           && o.CompanyID.Equals(item.CompanyID)).FirstOrDefault();
                                if (u == null)
                                {
                                    db.Suppliers.InsertOnSubmit(item);
                                    count += 1;
                                }
                            }

                        }

                        break;
                }

                db.SubmitChanges(ConflictMode.FailOnFirstConflict);

                if (Headers.Equals(bankStatement))
                {

                    db.BankStatements.Where(o => o.Auftragskonto == "43006329" && o.CompanyIBAN == null).ToList()
                                     .ForEach(i => i.CompanyIBAN = "DE47480501610043006329");
                    db.SubmitChanges(ConflictMode.FailOnFirstConflict);
                    db.BankStatements.Where(o => o.Auftragskonto.Length == 22 && o.CompanyIBAN == null).ToList()
                                     .ForEach(i => i.CompanyIBAN = i.Auftragskonto);
                    db.SubmitChanges(ConflictMode.FailOnFirstConflict);
                    db.BankStatements.Where(o => o.Buchungstext.ToUpper() == "ABSCHLUSS" && o.Kontonummer.Length == 0).ToList()
                                     .ForEach(i => i.Kontonummer = "DE4748050161XXXXXXXXXX");
                    db.SubmitChanges(ConflictMode.FailOnFirstConflict);

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
        private int MakeComptaMaster(int bankStatementId, int OID, int modelId, string itemtype)
        {
            int itemID = 0;
            int newOID = 2;
            string companyId = (string)Session["CompanyID"];
            string account = String.Empty;
            MasterCompta masterCompta = new MasterCompta();
            List<DetailCompta> detailCompta = new List<DetailCompta>();
            StatementDetailViewModel bankStatement = new StatementDetailViewModel();
            InvoiceViewModel invoice = new InvoiceViewModel();

            var maxId = db.MasterComptas.Count(i => i.id > 0);
            if (maxId != 0)
                newOID += db.MasterComptas.Max(i => i.id);


            if (!modelId.Equals((int)IWSLookUp.ComptaMasterModelId.VendorInvoice) &&
                !modelId.Equals((int)IWSLookUp.ComptaMasterModelId.CustomerInvoice))
            {
                bankStatement = IWSLookUp.GetStatementDetail(bankStatementId, itemtype, companyId);
                if (bankStatement == null)
                    return itemID;
            }
            if (modelId.Equals((int)IWSLookUp.ComptaMasterModelId.Payment))
            {
                account = IWSLookUp.GetCompteTier(bankStatement.Id,
                             IWSLookUp.ComptaMasterModelId.Payment.ToString());
            }
            if (modelId.Equals((int)IWSLookUp.ComptaMasterModelId.Settlement))
            {
                account = IWSLookUp.GetCompteTier(bankStatement.Id,
                            IWSLookUp.ComptaMasterModelId.Settlement.ToString());
            }
            if (modelId.Equals((int)IWSLookUp.ComptaMasterModelId.GeneralLedger))
            {
                account = IWSLookUp.GetCompteTier(bankStatement.Id,
                            IWSLookUp.ComptaMasterModelId.GeneralLedger.ToString());
            }
            if (modelId.Equals((int)IWSLookUp.ComptaMasterModelId.Payment) ||
                modelId.Equals((int)IWSLookUp.ComptaMasterModelId.Settlement))
            {
                masterCompta = new MasterCompta
                {
                    oid = newOID,
                    CostCenter = modelId.Equals((int)IWSLookUp.ComptaMasterModelId.Settlement)? "100": "200",
                    account = account,
                    HeaderText = bankStatement.Verwendungszweck,
                    TransDate = bankStatement.Valutadatum,
                    ItemDate = bankStatement.Buchungstag,
                    EntryDate = DateTime.Today,
                    CompanyId = companyId,
                    ModelId = modelId,
                    IsValidated = false
                };
            }
            if (modelId.Equals((int)IWSLookUp.ComptaMasterModelId.GeneralLedger))
            {
                masterCompta = new MasterCompta
                {
                    oid = 0,
                    CostCenter = "100",
                    account = account,
                    HeaderText = bankStatement.Verwendungszweck,
                    TransDate = bankStatement.Valutadatum,
                    ItemDate = bankStatement.Buchungstag,
                    EntryDate = DateTime.Today,
                    CompanyId = companyId,
                    ModelId = modelId,
                    IsValidated = false
                };
            }
            if (modelId.Equals((int)IWSLookUp.ComptaMasterModelId.VendorInvoice))
            {
                invoice = GetInvoiceDetail(OID, bankStatementId,
                            IWSLookUp.ComptaMasterModelId.VendorInvoice.ToString(), companyId);

                if (invoice != null)
                {
                    masterCompta = new MasterCompta
                    {
                        oid = 0,
                        CostCenter = invoice.CostCenter,
                        account = invoice.AccountId,
                        HeaderText = invoice.HeaderText,
                        TransDate = invoice.TransDate,
                        ItemDate = invoice.ItemDate,
                        EntryDate = invoice.EntryDate,
                        CompanyId = invoice.CompanyId,
                        ModelId = modelId,
                        IsValidated = false
                    };
                }
            }
            if (modelId.Equals((int)IWSLookUp.ComptaMasterModelId.CustomerInvoice))
            {
                invoice = GetInvoiceDetail(OID, bankStatementId,
                            IWSLookUp.ComptaMasterModelId.CustomerInvoice.ToString(), companyId);

                if (invoice != null)
                {
                    masterCompta = new MasterCompta
                    {
                        oid = 0,
                        CostCenter = invoice.CostCenter,
                        account = invoice.AccountId,
                        HeaderText = invoice.HeaderText,
                        TransDate = invoice.TransDate,
                        ItemDate = invoice.ItemDate,
                        EntryDate = invoice.EntryDate,
                        CompanyId = invoice.CompanyId,
                        ModelId = modelId, 
                        IsValidated = false
                    };
                }
            }

            itemID = MakeHeader(masterCompta);
            if (!(itemID > 0))
                return itemID;

            if (modelId.Equals((int)IWSLookUp.ComptaMasterModelId.Payment))
            {
                detailCompta = new List<DetailCompta>
                {
                    new DetailCompta
                    {
                        transid = itemID,
                        account =  IWSLookUp.GetPaymentDebitAcount(bankStatementId),
                        side = true,
                        oaccount = IWSLookUp.GetPaymentCreditAcount(bankStatementId),
                        amount = bankStatement.Betrag,
                        Currency = bankStatement.Waehrung,
                        duedate = bankStatement.Valutadatum,
                        ModelId = modelId,
                        text = bankStatement.Buchungstext
                    }
                };
            }
            if (modelId.Equals((int)IWSLookUp.ComptaMasterModelId.Settlement))
            {
                detailCompta = new List<DetailCompta>
                {
                    new DetailCompta
                    {
                        transid = itemID,
                        account = IWSLookUp.GetSettlementDebitAcount(bankStatementId),
                        side = true,
                        oaccount = IWSLookUp.GetSettlementCreditAcount(bankStatementId),
                        amount = bankStatement.Betrag,
                        Currency = bankStatement.Waehrung,
                        duedate = bankStatement.Valutadatum,
                        ModelId = modelId,
                        text = bankStatement.Buchungstext
                    }
                };
            }
            if (modelId.Equals((int)IWSLookUp.ComptaMasterModelId.GeneralLedger))
            {
                detailCompta = new List<DetailCompta>
                     {
                         new DetailCompta
                         {
                             transid = itemID,
                             account = bankStatement.AccountID,
                             side = true,
                             oaccount = bankStatement.OAccountID,
                             amount = bankStatement.Betrag,
                             Currency = bankStatement.Waehrung,
                             duedate = bankStatement.Valutadatum,
                             ModelId = modelId,
                             text = bankStatement.Buchungstext
                         }
                     };
            }
            if (modelId.Equals((int)IWSLookUp.ComptaMasterModelId.VendorInvoice))
            {
                DetailCompta temp = new DetailCompta();

                if (db.tempAccountAmounts.Any())
                {
                    List<tempAccountAmount> ls = db.tempAccountAmounts.ToList();

                    foreach (var l in ls)
                    {
                        temp = new DetailCompta
                        {
                            transid = itemID,
                            account = l.AccountCode,
                            side = true,
                            oaccount = invoice.OAccount,
                            amount = l.AccountAmount,
                            Currency = invoice.OCurrency,
                            duedate = invoice.DueDate,
                            ModelId = modelId,
                            text = invoice.HeaderText
                        };
                        detailCompta.Add(temp);
                    }
                }
                else
                {
                    detailCompta = new List<DetailCompta>
                    {
                        new DetailCompta
                        {
                            transid = itemID,
                            account = invoice.Account,
                            side = true,
                            oaccount = invoice.OAccount,
                            amount = (decimal)invoice.Amount,
                            Currency = invoice.OCurrency,
                            duedate = invoice.DueDate,
                            ModelId = invoice.Modelid,
                            text = invoice.HeaderText
                        },
                        new DetailCompta
                        {
                            transid = itemID,
                            account = invoice.VatAccountId,
                            side = true,
                            oaccount = invoice.OAccount,
                            amount = (decimal)invoice.VatAmount,
                            Currency = invoice.OCurrency,
                            duedate = invoice.DueDate,
                            ModelId = invoice.Modelid,
                            text = invoice.HeaderText
                        }
                    };
                }
            }
            if (modelId.Equals((int)IWSLookUp.ComptaMasterModelId.CustomerInvoice))
            {
                detailCompta = new List<DetailCompta>
                {
                    new DetailCompta
                    {
                        transid = itemID,
                        account = invoice.Account,
                        side = true,
                        oaccount = invoice.OAccount,
                        amount = (decimal)invoice.Amount,
                        Currency = invoice.OCurrency,
                        duedate = invoice.DueDate,
                        ModelId = modelId,
                        text = invoice.Text
                    },
                    new DetailCompta
                    {
                        transid = itemID,
                        account = invoice.Account,
                        side = true,
                        oaccount = invoice.VatAccountId,
                        amount = (decimal)invoice.VatAmount,
                        Currency = invoice.OCurrency,
                        duedate = invoice.DueDate,
                        ModelId = modelId,
                        text = invoice.Text
                    }
                };
            }

            int countLineID = MakeDetail(detailCompta);
            if (countLineID > 0)
            {
                IWSLookUp.SetJournal(detailCompta.First().transid);
                return itemID;
            }
            return countLineID;
        }
        private InvoiceViewModel GetInvoiceDetail(int itemId, int bankStatementId, string itemType, string companyId)
        {
            string id;
            try
            {
                if (itemType.Equals(IWSLookUp.ComptaMasterModelId.CustomerInvoice.ToString()))
                {
                    var OwnerId = (from ba in db.BankAccounts
                                   where
                                     ba.IBAN ==
                                       ((from bs in db.BankStatements
                                         where
                                            bs.id == bankStatementId &&
                                            bs.CompanyID == companyId
                                         select new
                                         {
                                             bs.Kontonummer
                                         }).First().Kontonummer)
                                   select new
                                   {
                                       ba.Owner
                                   }).Take(2).OrderBy(o => o.Owner);
                    if (OwnerId.Count() > 1)
                    {
                        id = OwnerId.First().Owner;
                        var owner = from v in db.Vats
                                    join cu in db.Customers on new { v.id } equals new { id = cu.VatCode }
                                    where
                                      cu.id == id
                                    select new
                                    {
                                        v.PVat,
                                        v.outputvataccountid,
                                        cu.accountid,
                                        cu.IBAN,
                                        cu.Produit
                                    };
                        if (!owner.Any())
                        {
                            OwnerId = OwnerId.OrderByDescending(o => o.Owner);
                            id = OwnerId.First().Owner;
                            owner = from v in db.Vats
                                    join cu in db.Customers on new { v.id } equals new { id = cu.VatCode }
                                    where
                                        cu.id == id
                                    select new
                                    {
                                        v.PVat,
                                        v.outputvataccountid,
                                        cu.accountid,
                                        cu.IBAN,
                                        cu.Produit
                                    };

                        }
                        var vat = owner.SingleOrDefault().PVat;
                        InvoiceViewModel invoice = (from l in db.DetailComptas
                                                    where
                                                        l.MasterCompta.id == itemId &&
                                                        l.MasterCompta.CompanyId == companyId
                                                    select new InvoiceViewModel()
                                                    {
                                                        Account = l.oaccount,
                                                        OAccount = owner.SingleOrDefault().Produit,
                                                        PVat = vat,
                                                        CostCenter = l.MasterCompta.CostCenter,
                                                        HeaderText = l.MasterCompta.HeaderText,
                                                        TransDate = l.MasterCompta.TransDate,
                                                        ItemDate = l.MasterCompta.ItemDate,
                                                        EntryDate = l.MasterCompta.EntryDate,
                                                        OTotal = l.MasterCompta.oTotal,
                                                        Amount = Math.Round((decimal)l.MasterCompta.oTotal / (1 + vat), 2, MidpointRounding.AwayFromZero),
                                                        VatAmount = Math.Round((decimal)l.MasterCompta.oTotal * vat / (1 + vat), 2, MidpointRounding.AwayFromZero),
                                                        OPeriode = l.MasterCompta.oPeriode,
                                                        OCurrency = l.MasterCompta.oCurrency,
                                                        DueDate = l.duedate,
                                                        Text = l.text,
                                                        CompanyId = l.MasterCompta.CompanyId,
                                                        AccountId = l.MasterCompta.account,
                                                        VatAccountId = owner.SingleOrDefault().outputvataccountid,
                                                        Modelid = (int)IWSLookUp.ComptaMasterModelId.CustomerInvoice
                                                    }).Single();
                        return invoice;

                    }
                    if (OwnerId.Count() == 1)
                    {
                        id = OwnerId.First().Owner;
                        var owner = from v in db.Vats
                                    join cu in db.Customers on new { v.id } equals new { id = cu.VatCode }
                                    where
                                      cu.id == id
                                    select new
                                    {
                                        v.PVat,
                                        v.outputvataccountid,
                                        cu.accountid,
                                        cu.IBAN,
                                        cu.Produit
                                    };
                        if (owner.Any())
                        {
                            var vat = owner.SingleOrDefault().PVat;
                            InvoiceViewModel invoice = (from l in db.DetailComptas
                                                        where
                                                            l.MasterCompta.id == itemId &&
                                                            l.MasterCompta.CompanyId == companyId
                                                        select new InvoiceViewModel()
                                                        {
                                                            Account = l.oaccount,
                                                            OAccount = owner.SingleOrDefault().Produit,
                                                            PVat = vat,
                                                            CostCenter = l.MasterCompta.CostCenter,
                                                            HeaderText = l.MasterCompta.HeaderText,
                                                            TransDate = l.MasterCompta.TransDate,
                                                            ItemDate = l.MasterCompta.ItemDate,
                                                            EntryDate = l.MasterCompta.EntryDate,
                                                            OTotal = l.MasterCompta.oTotal,
                                                            Amount = Math.Round((decimal)l.MasterCompta.oTotal / (1 + vat), 2, MidpointRounding.AwayFromZero),
                                                            VatAmount = Math.Round((decimal)l.MasterCompta.oTotal * vat / (1 + vat), 2, MidpointRounding.AwayFromZero),
                                                            OPeriode = l.MasterCompta.oPeriode,
                                                            OCurrency = l.MasterCompta.oCurrency,
                                                            DueDate = l.duedate,
                                                            Text = l.text,
                                                            CompanyId = l.MasterCompta.CompanyId,
                                                            AccountId = l.MasterCompta.account,
                                                            VatAccountId = owner.SingleOrDefault().outputvataccountid,
                                                            Modelid = (int)IWSLookUp.ComptaMasterModelId.CustomerInvoice
                                                        }).Single();
                            return invoice;
                        }
                    }
                }
                if (itemType.Equals(IWSLookUp.ComptaMasterModelId.VendorInvoice.ToString()))
                {
                    var OwnerId = (from ba in db.BankAccounts
                                   where
                                     ba.IBAN ==
                                       ((from bs in db.BankStatements
                                         where
                                            bs.id == bankStatementId &&
                                            bs.CompanyID == companyId
                                         select new
                                         {
                                             bs.Kontonummer
                                         }).First().Kontonummer)
                                   select new
                                   {
                                       ba.Owner
                                   }).Take(2).OrderBy(o=>o.Owner);
                    if (OwnerId.Count()>1)
                    {
                        id = OwnerId.First().Owner;
                        var owner = from v in db.Vats
                                    join su in db.Suppliers on new { v.id } equals new { id = su.VatCode }
                                    where
                                      su.id == id
                                    select new
                                    {
                                        v.PVat,
                                        v.inputvataccountid,
                                        su.accountid,
                                        su.IBAN,
                                        su.Charge
                                    };
                        if (!owner.Any())
                        {
                            OwnerId = OwnerId.OrderByDescending(o => o.Owner);
                            id = OwnerId.First().Owner;
                            owner = from v in db.Vats
                                    join su in db.Suppliers on new { v.id } equals new { id = su.VatCode }
                                    where
                                      su.id == id
                                    select new
                                    {
                                        v.PVat,
                                        v.inputvataccountid,
                                        su.accountid,
                                        su.IBAN,
                                        su.Charge
                                    };
                        }
                        var vat = owner.SingleOrDefault().PVat;
                        InvoiceViewModel invoice = (from l in db.DetailComptas
                                                    where
                                                        l.MasterCompta.id == itemId &&
                                                        l.MasterCompta.CompanyId == companyId
                                                    select new InvoiceViewModel()
                                                    {
                                                        Account = owner.SingleOrDefault().Charge,
                                                        OAccount = l.account,
                                                        PVat = vat,
                                                        CostCenter = l.MasterCompta.CostCenter,
                                                        HeaderText = l.MasterCompta.HeaderText,
                                                        TransDate = l.MasterCompta.TransDate,
                                                        ItemDate = l.MasterCompta.ItemDate,
                                                        EntryDate = l.MasterCompta.EntryDate,
                                                        OTotal = l.MasterCompta.oTotal,
                                                        Amount = Math.Round((decimal)l.MasterCompta.oTotal / (1 + vat), 2, MidpointRounding.AwayFromZero),
                                                        VatAmount = Math.Round((decimal)l.MasterCompta.oTotal * vat / (1 + vat), 2, MidpointRounding.AwayFromZero),
                                                        OPeriode = l.MasterCompta.oPeriode,
                                                        OCurrency = l.MasterCompta.oCurrency,
                                                        DueDate = l.duedate,
                                                        Text = l.text,
                                                        CompanyId = l.MasterCompta.CompanyId,
                                                        AccountId = l.MasterCompta.account,
                                                        VatAccountId = owner.SingleOrDefault().inputvataccountid,
                                                        Modelid = (int)IWSLookUp.ComptaMasterModelId.VendorInvoice
                                                    }).Single();
                        return invoice;
                    }
                    if (OwnerId.Count() == 1)
                    {
                        id = OwnerId.First().Owner;
                        var owner = from v in db.Vats
                                    join su in db.Suppliers on new { v.id } equals new { id = su.VatCode }
                                    where
                                      su.id == id
                                    select new
                                    {
                                        v.PVat,
                                        v.inputvataccountid,
                                        su.accountid,
                                        su.IBAN,
                                        su.Charge
                                    };
                        if (owner.Any())
                        {
                            var vat = owner.SingleOrDefault().PVat;
                            InvoiceViewModel invoice = (from l in db.DetailComptas
                                                        where
                                                            l.MasterCompta.id == itemId &&
                                                            l.MasterCompta.CompanyId == companyId
                                                        select new InvoiceViewModel()
                                                        {
                                                            Account = owner.SingleOrDefault().Charge,
                                                            OAccount = l.account,
                                                            PVat = vat,
                                                            CostCenter = l.MasterCompta.CostCenter,
                                                            HeaderText = l.MasterCompta.HeaderText,
                                                            TransDate = l.MasterCompta.TransDate,
                                                            ItemDate = l.MasterCompta.ItemDate,
                                                            EntryDate = l.MasterCompta.EntryDate,
                                                            OTotal = l.MasterCompta.oTotal,
                                                            Amount = Math.Round((decimal)l.MasterCompta.oTotal / (1 + vat), 2, MidpointRounding.AwayFromZero),
                                                            VatAmount = Math.Round((decimal)l.MasterCompta.oTotal * vat / (1 + vat), 2, MidpointRounding.AwayFromZero),
                                                            OPeriode = l.MasterCompta.oPeriode,
                                                            OCurrency = l.MasterCompta.oCurrency,
                                                            DueDate = l.duedate,
                                                            Text = l.text,
                                                            CompanyId = l.MasterCompta.CompanyId,
                                                            AccountId = l.MasterCompta.account,
                                                            VatAccountId = owner.SingleOrDefault().inputvataccountid,
                                                            Modelid = (int)IWSLookUp.ComptaMasterModelId.VendorInvoice
                                                        }).Single();
                            return invoice;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }
        private int MakeHeader(MasterCompta masterCompta)
        {
            int id = 0;
            try
            {
                db.MasterComptas.InsertOnSubmit(masterCompta);
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                id = db.MasterComptas.Max(i => i.id);
            }
            catch (Exception ex)
            {
                IWSLookUp.LogException(ex);
            }
            return id;
        }
        private int MakeDetail(List<DetailCompta> detailCompta)
        {
            int id = 0;
            try
            {
                foreach (var item in detailCompta)
                {
                    if (item.amount != 0)
                    {
                        db.DetailComptas.InsertOnSubmit(item);
                        id++;
                    }
                }
                db.SubmitChanges(ConflictMode.FailOnFirstConflict);
            }
            catch (Exception ex)
            {
                IWSLookUp.LogException(ex);
            }
            return id;
        }
        private StatementDetailViewModel GetDetailCompta(int bankStatementId, string itemType, string companyId)
        {


            StatementDetailViewModel sd =       //payment
                (from bs in db.BankStatements
                 join bao in db.BankAccounts on new { bs.Kontonummer } equals new { Kontonummer = bao.IBAN }
                 join su in db.Suppliers on new { bao.Owner } equals new { Owner = su.id }
                 join baa in db.BankAccounts on new { bs.CompanyIBAN } equals new { CompanyIBAN = baa.IBAN }
                 join co in db.Companies on new { baa.Owner } equals new { Owner = co.id }
                 where
                     bs.id == bankStatementId &&
                     bs.IsValidated == false &&
                     bs.CompanyID == companyId
                 select new StatementDetailViewModel()
                 {
                     Id = su.id,
                     AccountID = su.accountid,
                     OAccountID = co.paymentclearingaccountid,
                     Betrag = Math.Abs((decimal)bs.Betrag),
                     Waehrung = bs.Waehrung,
                     Info = bs.Info,
                     Buchungstag = (DateTime)bs.Buchungstag,
                     Valutadatum = (DateTime)bs.Valutadatum,
                     Periode = Convert.ToString((int?)bs.Buchungstag.Value.Year) +
                              Convert.ToString((int?)bs.Buchungstag.Value.Month),
                     Buchungstext = bs.Buchungstext,
                     Verwendungszweck = bs.Verwendungszweck,
                     BeguenstigterZahlungspflichtiger = bs.BeguenstigterZahlungspflichtiger
                 }).Single();
                    return sd;

        }
        private bool ValidateBankStatement(int ItemID)
        {
            try
            { 
                var docs = db.BankStatements.SingleOrDefault(item => item.id == ItemID);

                if (docs.Equals(null))
                    return false;

                docs.IsValidated = true;

                return true;
            }
            catch (Exception ex)
            {
                IWSLookUp.LogException(ex);
                return false;
            }
        }
        private bool ReferenceInvoice(int itemId)
        {
          
            var Master = db.MasterComptas.Join(db.DetailComptas,
                            m => m.id, d => d.transid, (m, d) => new
                            {
                                Id = d.id,
                                TransId = d.transid,
                                OID = m.oid,
                                m.ModelId
                            }).Where(x => x.TransId.Equals(itemId));
            int OID = Master.FirstOrDefault().OID;
            var Detail = db.DetailComptas.Where(o => o.transid.Equals(OID)).Select(n => new
                            {
                                Id = n.id,
                                TransId = n.transid,
                                Amount = n.amount
                            });
            try
            {
                foreach (var master in Master)
                {
                    foreach (var detail in Detail)
                    {
                        DetailDetailCompta detailDetailCompta = new DetailDetailCompta
                        {
                            TransId= master.Id,
                            OID = detail.Id,
                            Amount = detail.Amount,
                            ModelId = master.ModelId
                        };
                        db.DetailDetailComptas.InsertOnSubmit(detailDetailCompta);

                        var invoiceLine = db.DetailComptas.Where(i => i.id.Equals(detail.Id));

                        foreach (var line in invoiceLine)
                        {
                            line.Balanced = true;
                        }
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                throw e;
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
        private class Helper
        {
            public const string RootFolder = "~/Content/Uploads";
            public static string Model { get { return RootFolder; } }

            public static string[] AllowedFileExtensions = new string[] { ".csv", ".txt", ".xls", ".xlsx" };
        }
        #endregion

    }

}