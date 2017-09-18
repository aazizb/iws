using IWSProject.Content;
using IWSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web.Mvc;

namespace IWSProject.Controllers
{
    [Authorize]
    [HandleError()]
    public class AccountingController : Controller
    {
        IWSDataContext db;
        public AccountingController()
        {
            db = new IWSDataContext();
        }
        // GET: Accounting
        [HttpGet]
        public ActionResult Index()
        {
            List<DocumentsViewModel> model = IWSLookUp.GetAccountingDocument(false);
            return View(model);
        }

        [ValidateInput(false)]
        public ActionResult ValidateBLPartialView()
        {
            List<DocumentsViewModel> model = IWSLookUp.GetAccountingDocument(false);
            return PartialView(model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CallbackPanelPartialView(string selectedIDs)
        {
            string selectedItems = selectedIDs;
            try
            {
                //check if items were selected previously
                if (!String.IsNullOrEmpty(selectedItems) && selectedItems!=null)
                {
                    string companyId = (string)Session["CompanyID"];
                    ProcessData(selectedItems, companyId, true);
                }
            }
            catch (Exception ex)
            {
                ViewData["GenericError"] = ex.Message;
                IWSLookUp.LogException(ex);
            }
            List<DocumentsViewModel> model = IWSLookUp.GetAccountingDocument(false);
            return PartialView("CallbackPanelPartialView", model);
        }

        #region Helper

        /// <summary>
        /// validates documents
        /// </summary>
        /// <param name="document ID ItemID"></param>
        /// <param name="document type ItemType"></param>
        /// <returns>bool</returns>
        private bool Account(int ItemID, string ItemType, string companyId)
        {
            //bool results;
            if (ItemType.Equals(IWSLookUp.DocsType.GoodReceiving.ToString()))
            {
                return ValidateGoodReceiving(ItemID,companyId);
            }
            if (ItemType.Equals(IWSLookUp.DocsType.BillOfDelivery.ToString()))
            {
                return ValidateBillOfDelivery(ItemID, companyId);
            }
            //if (ItemType.Equals(IWSLookUp.DocsType.InventoryInvoice.ToString()))
            //{
            //    return MakeVendorInvoice(ItemID);
            //}
            //if (ItemType.Equals(IWSLookUp.DocsType.SalesInvoice.ToString()))
            //{
            //    return MakeCustomerInvoice(ItemID);
            //}
            if (ItemType.Equals(IWSLookUp.DocsType.VendorInvoice.ToString()))
            {
                //results = MakePayment(ItemID);
                //if(results)
                return ValidateVendorInvoice(ItemID, companyId);
            }
            if (ItemType.Equals(IWSLookUp.DocsType.CustomerInvoice.ToString()))
            {
                //results = MakeSettlement(ItemID);
                //if (results)
                return ValidateCustmerInvoice(ItemID, companyId);
            }
            if (ItemType.Equals(IWSLookUp.DocsType.Payment.ToString()))
            {
                return ValidatePayment(ItemID, companyId);
            }
            if (ItemType.Equals(IWSLookUp.DocsType.Settlement.ToString()))
            {
                return ValidateSettlement(ItemID, companyId);
            }
            if (ItemType.Equals(IWSLookUp.DocsType.GeneralLedger.ToString()))
            {
                return ValidateGeneralLedger(ItemID, companyId);
            }
            return true;
        }
        private bool UpdateStock(int DocumentID, string DocumentType, string CompanyId)
        {

            if (DocumentType.Equals(IWSLookUp.DocsType.GoodReceiving.ToString()))
            {
                List<ValidateStockViewModel> validateStock =
                    (from line in db.LineGoodReceivings
                     group new { line, line.GoodReceiving } by new
                     {
                         DocumentID = line.GoodReceiving.id,
                         StoreID = line.GoodReceiving.store,
                         ItemID = line.item,
                         ItemName = line.Article.name,
                         Price = line.price,
                         Currency = line.GoodReceiving.oCurrency,
                         IsService = line.Article.IsService,
                         Text = line.GoodReceiving.HeaderText
                     } into g
                     where g.Key.DocumentID == DocumentID
                     select new ValidateStockViewModel
                     {
                         StoreID = g.Key.StoreID,
                         ItemID = g.Key.ItemID,
                         ItemName = g.Key.ItemName,
                         Quantity = g.Sum(q => q.line.quantity),
                         Price = g.Key.Price,
                         Currency = g.Key.Currency,
                         IsService = g.Key.IsService,
                         Text = g.Key.Text
                     }).ToList();
                if (validateStock.Any(i => i.IsService.Equals(false)))
                {
                    return StockIn(validateStock, CompanyId);
                }
            }
            if (DocumentType.Equals(IWSLookUp.DocsType.BillOfDelivery.ToString()))
            {
                List<ValidateStockViewModel> validateStock =
                    (from line in db.LineBillOfDeliveries
                     group new { line, line.BillOfDelivery } by new
                     {
                         DocumentID = line.BillOfDelivery.id,
                         StoreID = line.BillOfDelivery.store,
                         ItemID = line.item,
                         ItemName = line.Article.name,
                         Price = line.price,
                         Currency = line.BillOfDelivery.oCurrency,
                         IsService = line.Article.IsService,
                         Text = line.BillOfDelivery.HeaderText
                     } into g
                     where g.Key.DocumentID == DocumentID
                     select new ValidateStockViewModel
                     {
                         StoreID = g.Key.StoreID,
                         ItemID = g.Key.ItemID,
                         ItemName = g.Key.ItemName,
                         Quantity = g.Sum(q => q.line.quantity),
                         Price = g.Key.Price,
                         Currency = g.Key.Currency,
                         IsService = g.Key.IsService,
                         Text = g.Key.Text
                     }).ToList();
                if (validateStock.Any(i => i.IsService == false))
                {
                    return StockOut(validateStock, CompanyId);
                }
            }
            return true;
        }
        private bool Validate(int ItemID, string ItemType)
        {
            try
            {
                if (ItemType.Equals(IWSLookUp.DocsType.PurchaseOrder.ToString()))
                {
                    var docs = db.PurchaseOrders.Single(item => item.id == ItemID);
                    if (docs != null)
                    {
                        docs.IsValidated = true;
                        return true;
                    }
                }
                if (ItemType.Equals(IWSLookUp.DocsType.SalesOrder.ToString()))
                {
                    var docs = db.SalesOrders.Single(item => item.id == ItemID);
                    if (docs != null)
                    {
                        docs.IsValidated = true;
                        return true;
                    }
                }
                if (ItemType.Equals(IWSLookUp.DocsType.GoodReceiving.ToString()))
                {
                    var docs = db.GoodReceivings.Single(item => item.id == ItemID);
                    if (docs != null)
                    {
                        docs.IsValidated = true;
                        return true;
                    }
                }
                if (ItemType.Equals(IWSLookUp.DocsType.BillOfDelivery.ToString()))
                {
                    var docs = db.BillOfDeliveries.Single(item => item.id == ItemID);
                    if (docs != null)
                    {
                        docs.IsValidated = true;
                        return true;
                    }
                }
                if (ItemType.Equals(IWSLookUp.DocsType.InventoryInvoice.ToString()))
                {
                    var docs = db.InventoryInvoices.Single(item => item.id == ItemID);
                    if (docs != null)
                    {
                        docs.IsValidated = true;
                        return true;
                    }
                }
                if (ItemType.Equals(IWSLookUp.DocsType.CustomerInvoice.ToString()))
                {
                    var docs = db.CustomerInvoices.Single(item => item.id == ItemID);
                    if (docs != null)
                    {
                        docs.IsValidated = true;
                        return true;
                    }
                }
                if (ItemType.Equals(IWSLookUp.DocsType.VendorInvoice.ToString()))
                {
                    var docs = db.VendorInvoices.Single(item => item.id == ItemID);
                    if (docs != null)
                    {
                        docs.IsValidated = true;
                        return true;
                    }
                }
                if (ItemType.Equals(IWSLookUp.DocsType.SalesInvoice.ToString()))
                {
                    var docs = db.SalesInvoices.Single(item => item.id == ItemID);
                    if (docs != null)
                    {
                        docs.IsValidated = true;
                        return true;
                    }
                }
                if (ItemType.Equals(IWSLookUp.DocsType.Payment.ToString()))
                {
                    var docs = db.Payments.Single(item => item.id == ItemID);
                    if (docs != null)
                    {
                        docs.IsValidated = true;
                        return true;
                    }
                }
                if (ItemType.Equals(IWSLookUp.DocsType.Settlement.ToString()))
                {
                    var docs = db.Settlements.Single(item => item.id == ItemID);
                    if (docs != null)
                    {
                        docs.IsValidated = true;
                        return true;
                    }
                }
                if (ItemType.Equals(IWSLookUp.DocsType.GeneralLedger.ToString()))
                {
                    var docs = db.GeneralLedgers.Single(item => item.id == ItemID);
                    if (docs != null)
                    {
                        docs.IsValidated = true;
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

        private bool UpdateAccountBalance(string accountID, decimal amount, bool isDebit, string companyId)
        {
            try
            {
                if (!isDebit)
                {
                    amount = -amount;
                }
                var docs = db.Accounts.FirstOrDefault(a => a.id == accountID && a.CompanyID==companyId);
                if (docs != null)
                {
                    docs.balance += amount;
                    return true;
                }
            }
            catch (Exception ex)
            {
                ViewData["GenericError"] = ex.Message;
                IWSLookUp.LogException(ex);
            }
            return false;
        }

        private bool UpdateAccountBalance(string Periode, string AccountID, decimal amount,
                                                    string currency, bool IsDebit, string companyID)
        {
           
            var docs = db.PeriodicAccountBalances
                       .FirstOrDefault(p => p.Periode == Periode
                        && p.AccountId == AccountID
                        && p.CompanyID == companyID);
            if (docs == null)
            {
                string name = db.Accounts
                    .Where(a => a.id == AccountID && a.CompanyID == companyID)
                    .Select(n => n.name)
                    .Single();
                docs = new PeriodicAccountBalance
                {
                    Name = name,
                    Periode = Periode,
                    AccountId = AccountID,
                    CompanyID = companyID,
                    Debit = 0,
                    Credit = 0,
                    Currency = currency
                };
                if (IsDebit)
                {
                    docs.Debit = amount;
                }
                else
                {
                    docs.Credit = amount;
                }
                try
                {
                    db.PeriodicAccountBalances.InsertOnSubmit(docs);
                    return true;
                }
                catch (Exception ex)
                {
                    ViewData["GenericError"] = ex.Message;
                    IWSLookUp.LogException(ex);
                    return false;
                }
            }
            else
            {
                try
                {
                    if (IsDebit)
                    {
                        docs.Debit += amount;
                    }
                    else
                    {
                        docs.Credit += amount;
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    ViewData["GenericError"] = ex.Message;
                    IWSLookUp.LogException(ex);
                    return false;
                }
            }
        }

        private string GetItemType(string ItemType)
        {
            return db.Localizations.Where(i => i.LocalName == ItemType)
                                                .Select(i => i.ItemName)
                                                .FirstOrDefault();
        }

        private bool StockIn(List<ValidateStockViewModel> items, string CompanyId)
        {
            try
            {
                foreach (var item in items)
                {
                    var article = db.Articles
                        .FirstOrDefault(i => i.id == item.ItemID
                        && i.CompanyID == CompanyId);
                    if (item.IsService)
                    {
                        //for service items
                        article.price = item.Price;
                        article.avgprice = item.Price;
                    }
                    else
                    {
                        //for stockable items
                        float currentStock = 0;
                        bool isItemInStock = db.Stocks.
                            Any(i => i.itemid == item.ItemID
                            && i.CompanyID == CompanyId);
                        if (isItemInStock)
                        {
                            currentStock = db.Stocks
                                .Where(i => i.itemid == item.ItemID
                                && i.CompanyID == CompanyId)
                                .Sum(q => q.quantity);
                        }
                        var stock = db.Stocks
                            .FirstOrDefault(s => s.storeid == item.StoreID
                            && s.itemid == item.ItemID
                            && s.CompanyID == CompanyId);
                        if (stock == null)
                        {
                            stock = new Stock()
                            {
                                itemid = item.ItemID,
                                name = item.ItemName,
                                storeid = item.StoreID,
                                CompanyID = CompanyId,
                                Currency = item.Currency,
                                quantity = (float)item.Quantity,
                                description = item.Text
                            };
                            db.Stocks.InsertOnSubmit(stock);
                        }
                        else
                        {
                            stock.quantity += (float)item.Quantity;
                        }
                        article.price = item.Price;
                        article.avgprice = (article.avgprice * (decimal)currentStock +
                                            item.Price * item.Quantity) / ((decimal)currentStock + item.Quantity);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                ViewData["GenericError"] = ex.Message;
                IWSLookUp.LogException(ex);
                return false;
            }
        }

        private bool StockOut(List<ValidateStockViewModel> items, string CompanyId)
        {
            try
            {
                foreach (var item in items.Where(i => i.IsService == false))
                {
                    var stock = db.Stocks.FirstOrDefault(s => s.storeid == item.StoreID && s.itemid == item.ItemID && s.CompanyID==CompanyId);
                    if (stock != null)
                    {
                        decimal RequestedQuantity = Convert.ToDecimal(item.Quantity);
                        decimal AvailableQuantity = Convert.ToDecimal(stock.quantity + stock.minstock);
                        if (AvailableQuantity >= RequestedQuantity)
                        {
                            stock.quantity -= (float)item.Quantity;
                        }
                        else
                        {
                            string msg = IWSLocalResource.InsufficientStock + ": " + item.ItemID + "-" + item.ItemName;
                            ViewData["GenericError"] = msg;
                            return false;
                        }
                    }
                    else
                    {
                        string msg = IWSLocalResource.InsufficientStock + ": " + item.ItemID + "-" + item.ItemName;
                        ViewData["GenericError"] = msg;
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                IWSLookUp.LogException(ex);
                return false;
            }
        }

        private bool ValidateGoodReceiving(int ItemID, string companyId)
        {
            List<JournalViewModel> docs = (from o in (
                (from i in db.LineGoodReceivings
                 select new
                 {
                     i.GoodReceiving.id,
                     i.GoodReceiving.oid,
                     i.GoodReceiving.account,
                     i.GoodReceiving.store,
                     i.GoodReceiving.TransDate,
                     i.GoodReceiving.ItemDate,
                     i.GoodReceiving.EntryDate,
                     i.GoodReceiving.oPeriode,
                     i.Article.StockAccount,
                     i.GoodReceiving.Company.purchasingclearingaccountid,
                     sAmount = i.lineNet,
                     i.GoodReceiving.Company.IBAN,
                     IBAN2 = i.GoodReceiving.Supplier.IBAN,
                     i.GoodReceiving.oCurrency,
                     i.GoodReceiving.HeaderText
                 }))
                    group o by new
                    {
                        o.id,
                        o.oid,
                        o.account,
                        o.store,
                        o.TransDate,
                        o.ItemDate,
                        o.EntryDate,
                        o.oPeriode,
                        o.StockAccount,
                        o.purchasingclearingaccountid,
                        o.IBAN,
                        o.IBAN2,
                        o.oCurrency,
                        o.HeaderText
                    } into g
                    where g.Key.id == ItemID
                    select new JournalViewModel()
                    {
                    ItemID = g.Key.id,
                    OID = g.Key.oid,
                    CustSupplierID = g.Key.account,
                    StoreID = g.Key.store,
                    TransDate = g.Key.TransDate,
                    Itemdate = g.Key.ItemDate,
                    EntryDate = g.Key.EntryDate,
                    Periode = g.Key.oPeriode,
                    Account = g.Key.StockAccount,
                    OAccount = g.Key.purchasingclearingaccountid,
                    Amount = Convert.ToDecimal(g.Sum(p => p.sAmount)),
                    CompanyIBAN = g.Key.IBAN,
                    IBAN = g.Key.IBAN2,
                    Currency = g.Key.oCurrency,
                    Info = g.Key.HeaderText
                }).Distinct().ToList();

            bool results = false;

            if (docs.Any())
            {
                try
                {

                    foreach (var doc in docs)
                    {

                        results = UpdateAccountBalance(doc.Periode, doc.Account, doc.Amount, doc.Currency, true, companyId);

                        if (!results)
                            return results;

                        results = UpdateAccountBalance(doc.Account, doc.Amount, true, companyId);

                        if (!results)
                            return results;

                        List<Journal> journal = new List<Journal> {
                            new Journal {
                                ItemID =doc.ItemID,
                                OID =doc.OID,
                                ItemType = IWSLookUp.DocsType.GoodReceiving.ToString(),
                                CustSupplierID =doc.CustSupplierID,
                                StoreID =doc.StoreID,
                                TransDate =doc.TransDate,
                                ItemDate =doc.Itemdate,
                                EntryDate =doc.EntryDate,
                                Periode =doc.Periode,
                                Account =doc.Account,
                                OAccount =doc.OAccount,
                                Amount =doc.Amount,
                                Side = IWSLookUp. Side.Debit.ToString(),
                                CompanyID =companyId,
                                CompanyIBAN =doc.CompanyIBAN,
                                IBAN =doc.IBAN,
                                Currency =doc.Currency,
                                Info =doc.Info
                            },
                            new Journal {
                                ItemID =doc.ItemID,
                                OID =doc.OID,
                                ItemType = IWSLookUp.DocsType.GoodReceiving.ToString(),
                                CustSupplierID=doc.CustSupplierID,
                                StoreID =doc.StoreID,
                                TransDate =doc.TransDate,
                                ItemDate =doc.Itemdate,
                                EntryDate =doc.EntryDate,
                                Periode=doc.Periode,
                                Account =doc.OAccount,
                                OAccount =doc.Account,
                                Amount =doc.Amount,
                                Side = IWSLookUp. Side.Credit.ToString(),
                                CompanyID=companyId,
                                CompanyIBAN =doc.CompanyIBAN,
                                IBAN =doc.IBAN,
                                Currency=doc.Currency,
                                Info=doc.Info
                            }
                        };

                        results = SendToJournal(journal);

                        if (!results)
                            return results;
                    }

                    var item = (from doc in docs
                                group new { doc } by new
                                {
                                    doc.Periode,
                                    doc.OAccount,
                                    doc.Currency
                                } into g
                                select new
                                {
                                    Periode = g.Key.Periode,
                                    accountID = g.Key.OAccount,
                                    amount = g.Sum(p => p.doc.Amount),
                                    currency = g.Key.Currency
                                }).Single();
                    results = UpdateAccountBalance(item.Periode, item.accountID, item.amount, item.currency, false, companyId);

                    if (!results)
                        return results;

                    results = UpdateAccountBalance(item.accountID, item.amount, false, companyId);

                    if (!results)
                        return results;
                }
                catch (Exception ex)
                {
                    ViewData["GenericError"] = ex.Message;
                    IWSLookUp.LogException(ex);
                    return false;
                }
            }
            return results;
        }

        private bool ValidateBillOfDelivery(int ItemID, string companyId)
        {

            bool results = false;
            List<JournalViewModel> docs = (from l in db.LineBillOfDeliveries
                                           where
                                             l.BillOfDelivery.id == ItemID
                                           select new JournalViewModel()
                                           {
                                               ItemID = l.BillOfDelivery.id,
                                               OID = l.BillOfDelivery.oid,
                                               Currency = l.BillOfDelivery.oCurrency,
                                               CustSupplierID = l.BillOfDelivery.account,
                                               StoreID = l.BillOfDelivery.store,
                                               TransDate = l.BillOfDelivery.TransDate,
                                               Itemdate = l.BillOfDelivery.ItemDate,
                                               EntryDate = l.BillOfDelivery.EntryDate,
                                               Periode = l.BillOfDelivery.oPeriode,
                                               Amount = (decimal)l.BillOfDelivery.oTotal,
                                               Account = l.BillOfDelivery.Company.salesclearingaccountid,
                                               OAccount = l.Article.RevenuAccountId,
                                               CompanyIBAN = l.BillOfDelivery.Company.IBAN,
                                               IBAN = l.BillOfDelivery.Customer.IBAN,
                                               Info = l.BillOfDelivery.HeaderText
                                           }).Distinct().ToList();
            if (docs.Any())
            {
                results = ValidateBillOfDelivery(docs, companyId);
            }
            if (!results)
                return results;
            docs = (from l in db.LineBillOfDeliveries
                    where
                        !(l.Article.IsService == true)
                    group new { l.BillOfDelivery, l.Article, l.BillOfDelivery.Company, l.BillOfDelivery.Customer, l } by new
                    {
                        l.BillOfDelivery.id,
                        l.BillOfDelivery.oid,
                        l.BillOfDelivery.account,
                        l.BillOfDelivery.store,
                        l.BillOfDelivery.TransDate,
                        l.BillOfDelivery.ItemDate,
                        l.BillOfDelivery.EntryDate,
                        l.BillOfDelivery.oPeriode,
                        l.Article.avgprice,
                        l.Article.ExpenseAccount,
                        l.Article.StockAccount,
                        CompanyIBAN = l.BillOfDelivery.Company.IBAN,
                        IBAN = l.BillOfDelivery.Customer.IBAN,
                        l.BillOfDelivery.oCurrency,
                        l.BillOfDelivery.HeaderText
                    } into g
                    where g.Key.id == ItemID
                    select new JournalViewModel()
                    {
                        ItemID = g.Key.id,
                        OID = g.Key.oid,
                        CustSupplierID = g.Key.account,
                        StoreID = g.Key.store,
                        TransDate = g.Key.TransDate,
                        Itemdate = g.Key.ItemDate,
                        EntryDate = g.Key.EntryDate,
                        Periode = g.Key.oPeriode,
                        Account = g.Key.ExpenseAccount,
                        OAccount = g.Key.StockAccount,
                        Amount = Enumerable.Sum(g, p => Convert.ToDecimal((p.l.quantity * p.l.Article.avgprice))),
                        CompanyIBAN = g.Key.CompanyIBAN,
                        IBAN = g.Key.IBAN,
                        Currency = g.Key.oCurrency,
                        Info = g.Key.HeaderText
                    }).ToList();
            if (docs.Any())
            {
                results = ValidateBillOfDelivery(docs, companyId);
            }
            return results;
        }

        private bool ValidateBillOfDelivery(List<JournalViewModel> docs, string companyId)
        {
            bool results = false;
            try
            {

                foreach (var doc in docs)
                {

                    results = UpdateAccountBalance(doc.Periode, doc.Account, doc.Amount, doc.Currency, true, companyId);

                    if (!results)
                        return results;

                    results = UpdateAccountBalance(doc.Account, doc.Amount, true, companyId);

                    List<Journal> journal = new List<Journal> {
                            new Journal {
                                ItemID =doc.ItemID,
                                OID =doc.OID,
                                ItemType = IWSLookUp.DocsType.BillOfDelivery.ToString(),
                                CustSupplierID =doc.CustSupplierID,
                                StoreID =doc.StoreID,
                                TransDate =doc.TransDate,
                                ItemDate =doc.Itemdate,
                                EntryDate =doc.EntryDate,
                                Periode =doc.Periode,
                                Account =doc.Account,
                                OAccount =doc.OAccount,
                                Amount =doc.Amount,
                                Side = IWSLookUp. Side.Debit.ToString(),
                                CompanyID =companyId,
                                CompanyIBAN =doc.CompanyIBAN,
                                IBAN =doc.IBAN,
                                Currency =doc.Currency,
                                Info =doc.Info
                            },
                            new Journal {
                                ItemID =doc.ItemID,
                                OID =doc.OID,
                                ItemType = IWSLookUp.DocsType.BillOfDelivery.ToString(),
                                CustSupplierID=doc.CustSupplierID,
                                StoreID =doc.StoreID,
                                TransDate =doc.TransDate,
                                ItemDate =doc.Itemdate,
                                EntryDate =doc.EntryDate,
                                Periode=doc.Periode,
                                Account =doc.OAccount,
                                OAccount =doc.Account,
                                Amount =doc.Amount,
                                Side = IWSLookUp. Side.Credit.ToString(),
                                CompanyID=companyId,
                                CompanyIBAN =doc.CompanyIBAN,
                                IBAN =doc.IBAN,
                                Currency=doc.Currency,
                                Info=doc.Info
                            }
                        };

                    results = SendToJournal(journal);

                    if (!results)
                        return results;
                }

                var item = (from doc in docs
                            group new { doc } by new
                            {
                                doc.Periode,
                                doc.OAccount,
                                doc.Currency
                            } into g
                            select new
                            {
                                Periode = g.Key.Periode,
                                accountID = g.Key.OAccount,
                                amount = g.Sum(p => p.doc.Amount),
                                currency = g.Key.Currency
                            }).Single();

                results = UpdateAccountBalance(item.Periode, item.accountID, item.amount, item.currency, false, companyId);

                if (!results)
                    return results;

                results = UpdateAccountBalance(item.accountID, item.amount, false, companyId);

                if (!results)
                    return results;
            }
            catch (Exception ex)
            {
                ViewData["GenericError"] = ex.Message;
                IWSLookUp.LogException(ex);
                return false;
            }
            return results;
        }

        private bool ValidateVendorInvoice(int ItemID, string companyId)
        {

            List<JournalViewModel> docs = (from l in db.LineVendorInvoices
                                           where
                                             l.VendorInvoice.id == ItemID
                                           select new JournalViewModel()
                                           {
                                               ItemID = l.VendorInvoice.id,
                                               OID = l.VendorInvoice.oid,
                                               Currency = l.VendorInvoice.oCurrency,
                                               CustSupplierID = l.VendorInvoice.account,
                                               StoreID = l.VendorInvoice.CostCenter,
                                               TransDate = l.VendorInvoice.TransDate,
                                               Itemdate = l.VendorInvoice.ItemDate,
                                               EntryDate = l.VendorInvoice.EntryDate,
                                               Periode = l.VendorInvoice.oPeriode,
                                               Amount = l.amount,
                                               Account = l.account,
                                               OAccount = l.oaccount,
                                               CompanyIBAN = l.VendorInvoice.Company.IBAN ?? "NA",
                                               IBAN = l.VendorInvoice.Supplier.IBAN ?? "NA",
                                               Info = l.VendorInvoice.HeaderText
                                           }).Distinct().ToList();

            bool results = false;

            if (docs.Any())
            {
                try
                {

                    foreach (var doc in docs)
                    {
                        results = UpdateAccountBalance(doc.Periode,
                                        doc.Account, doc.Amount, doc.Currency, true, companyId);

                        if (!results)
                            return results;

                        results = UpdateAccountBalance(doc.Account, doc.Amount, true, companyId);

                        if (!results)
                            return results;

                        List<Journal> journal = new List<Journal> {
                            new Journal {
                                ItemID =doc.ItemID,
                                OID =doc.OID,
                                ItemType = IWSLookUp.DocsType.VendorInvoice.ToString(),
                                CustSupplierID =doc.CustSupplierID,
                                StoreID =doc.StoreID,
                                TransDate =doc.TransDate,
                                ItemDate =doc.Itemdate,
                                EntryDate =doc.EntryDate,
                                Periode =doc.Periode,
                                Account =doc.Account,
                                OAccount =doc.OAccount,
                                Amount =doc.Amount,
                                Side = IWSLookUp. Side.Debit.ToString(),
                                CompanyID =companyId,
                                CompanyIBAN =doc.CompanyIBAN,
                                IBAN =doc.IBAN,
                                Currency =doc.Currency,
                                Info =doc.Info
                            },
                            new Journal {
                                ItemID =doc.ItemID,
                                OID =doc.OID,
                                ItemType = IWSLookUp.DocsType.VendorInvoice.ToString(),
                                CustSupplierID=doc.CustSupplierID,
                                StoreID =doc.StoreID,
                                TransDate =doc.TransDate,
                                ItemDate =doc.Itemdate,
                                EntryDate =doc.EntryDate,
                                Periode=doc.Periode,
                                Account =doc.OAccount,
                                OAccount =doc.Account,
                                Amount =doc.Amount,
                                Side = IWSLookUp. Side.Credit.ToString(),
                                CompanyID=companyId,
                                CompanyIBAN =doc.CompanyIBAN,
                                IBAN =doc.IBAN,
                                Currency=doc.Currency,
                                Info=doc.Info
                            }
                        };

                        results = SendToJournal(journal);

                        if (!results)
                            return results;
                    }

                    var item = (from doc in docs
                                group new { doc } by new
                                {
                                    doc.Periode,
                                    doc.OAccount,
                                    doc.Currency
                                } into g
                                select new
                                {
                                    Periode = g.Key.Periode,
                                    accountID = g.Key.OAccount,
                                    amount = g.Sum(p => p.doc.Amount),
                                    currency = g.Key.Currency
                                }).Single();
                    results = UpdateAccountBalance(item.Periode, item.accountID, item.amount, item.currency, false, companyId);

                    if (!results)
                        return results;

                    results = UpdateAccountBalance(item.accountID, item.amount, false, companyId);

                    if (!results)
                        return results;
                }
                catch (Exception ex)
                {
                    ViewData["GenericError"] = ex.Message;
                    IWSLookUp.LogException(ex);
                    return false;
                }
            }
            return results;
        }

        private bool ValidatePayment(int ItemID, string companyId)
        {
            List<JournalViewModel> docs = (from l in db.LinePayments
                                           where
                                             l.Payment.id == ItemID
                                           select new JournalViewModel()
                                           {
                                               ItemID = l.Payment.id,
                                               OID = l.Payment.oid,
                                               Currency = l.Payment.oCurrency,
                                               CustSupplierID = l.Payment.account,
                                               StoreID = l.Payment.CostCenter,
                                               TransDate = l.Payment.TransDate,
                                               Itemdate = l.Payment.ItemDate,
                                               EntryDate = l.Payment.EntryDate,
                                               Periode = l.Payment.oPeriode,
                                               Amount = l.amount,
                                               Account = l.account,
                                               OAccount = l.oaccount,
                                               CompanyIBAN = l.Payment.Company.IBAN ?? "NA",
                                               IBAN = l.Payment.Supplier.IBAN ??"NA",
                                               Info = l.Payment.HeaderText
                                           }).Distinct().ToList();

            bool results = false;

            if (docs.Any())
            {
                try
                {

                    foreach (var doc in docs)
                    {
                        results = UpdateAccountBalance(doc.Periode,
                                        doc.Account, doc.Amount, doc.Currency, true, companyId);
                        
                        if (!results)
                            return results;

                        results = UpdateAccountBalance(doc.Account, doc.Amount, true, companyId);
                        
                        if (!results)
                            return results;

                        List<Journal> journal = new List<Journal> {
                            new Journal {
                                ItemID =doc.ItemID,
                                OID =doc.OID,
                                ItemType = IWSLookUp.DocsType.Payment.ToString(),
                                CustSupplierID =doc.CustSupplierID,
                                StoreID =doc.StoreID,
                                TransDate =doc.TransDate,
                                ItemDate =doc.Itemdate,
                                EntryDate =doc.EntryDate,
                                Periode =doc.Periode,
                                Account =doc.Account,
                                OAccount =doc.OAccount,
                                Amount =doc.Amount,
                                Side = IWSLookUp. Side.Debit.ToString(),
                                CompanyID =companyId,
                                CompanyIBAN =doc.CompanyIBAN,
                                IBAN =doc.IBAN,
                                Currency =doc.Currency,
                                Info =doc.Info
                            },
                            new Journal {
                                ItemID =doc.ItemID,
                                OID =doc.OID,
                                ItemType = IWSLookUp.DocsType.Payment.ToString(),
                                CustSupplierID=doc.CustSupplierID,
                                StoreID =doc.StoreID,
                                TransDate =doc.TransDate,
                                ItemDate =doc.Itemdate,
                                EntryDate =doc.EntryDate,
                                Periode=doc.Periode,
                                Account =doc.OAccount,
                                OAccount =doc.Account,
                                Amount =doc.Amount,
                                Side = IWSLookUp. Side.Credit.ToString(),
                                CompanyID=companyId,
                                CompanyIBAN =doc.CompanyIBAN,
                                IBAN =doc.IBAN,
                                Currency=doc.Currency,
                                Info=doc.Info
                            }
                        };

                        results = SendToJournal(journal);
                        if (!results)
                            return results;
                    }

                    var item = (from doc in docs
                                group new { doc } by new
                                {
                                    doc.Periode,
                                    doc.OAccount,
                                    doc.Currency
                                } into g
                                select new
                                {
                                    Periode = g.Key.Periode,
                                    accountID = g.Key.OAccount,
                                    amount = g.Sum(p => p.doc.Amount),
                                    currency = g.Key.Currency
                                }).Single();
                    results = UpdateAccountBalance(item.Periode, item.accountID, item.amount, item.currency, false, companyId);

                    if (!results)
                        return results;

                    results = UpdateAccountBalance(item.accountID, item.amount, false, companyId);

                    if (!results)
                        return results;

                }
                catch (Exception ex)
                {
                    ViewData["GenericError"] = ex.Message;
                    IWSLookUp.LogException(ex);
                    return false;
                }
            }
            return results;
        }

        private bool ValidateCustmerInvoice(int ItemID, string companyId)
        {
            List<JournalViewModel> docs = (from l in db.LineCustomerInvoices
                                           where
                                             l.CustomerInvoice.id == ItemID
                                           select new JournalViewModel()
                                           {
                                               ItemID = l.CustomerInvoice.id,
                                               OID = l.CustomerInvoice.oid,
                                               Currency = l.CustomerInvoice.oCurrency,
                                               CustSupplierID = l.CustomerInvoice.account,
                                               StoreID = l.CustomerInvoice.CostCenter,
                                               TransDate = l.CustomerInvoice.TransDate,
                                               Itemdate = l.CustomerInvoice.ItemDate,
                                               EntryDate = l.CustomerInvoice.EntryDate,
                                               Periode = l.CustomerInvoice.oPeriode,
                                               Amount = l.amount,
                                               Account = l.account,
                                               OAccount = l.oaccount,
                                               CompanyIBAN = l.CustomerInvoice.Company.IBAN ?? "NA",
                                               IBAN = l.CustomerInvoice.Customer.IBAN ?? "NA",
                                               Info = l.CustomerInvoice.HeaderText
                                           }).Distinct().ToList();
            bool results = false;

            if (docs.Any())
            {
                try
                {

                    foreach (var doc in docs)
                    {

                        results = UpdateAccountBalance(doc.Periode, doc.OAccount, doc.Amount, doc.Currency, false, companyId);

                        if (!results)
                            return results;

                        results = UpdateAccountBalance(doc.OAccount, doc.Amount, false, companyId);

                        if (!results)
                            return results;

                        List<Journal> journal = new List<Journal> {
                            new Journal {
                                ItemID =doc.ItemID,
                                OID =doc.OID,
                                ItemType = IWSLookUp.DocsType.CustomerInvoice.ToString(),
                                CustSupplierID =doc.CustSupplierID,
                                StoreID =doc.StoreID,
                                TransDate =doc.TransDate,
                                ItemDate =doc.Itemdate,
                                EntryDate =doc.EntryDate,
                                Periode =doc.Periode,
                                Account =doc.Account,
                                OAccount =doc.OAccount,
                                Amount =doc.Amount,
                                Side = IWSLookUp. Side.Debit.ToString(),
                                CompanyID =companyId,
                                CompanyIBAN =doc.CompanyIBAN,
                                IBAN =doc.IBAN,
                                Currency =doc.Currency,
                                Info =doc.Info
                            },
                            new Journal {
                                ItemID =doc.ItemID,
                                OID =doc.OID,
                                ItemType = IWSLookUp.DocsType.CustomerInvoice.ToString(),
                                CustSupplierID=doc.CustSupplierID,
                                StoreID =doc.StoreID,
                                TransDate =doc.TransDate,
                                ItemDate =doc.Itemdate,
                                EntryDate =doc.EntryDate,
                                Periode=doc.Periode,
                                Account =doc.OAccount,
                                OAccount =doc.Account,
                                Amount =doc.Amount,
                                Side = IWSLookUp. Side.Credit.ToString(),
                                CompanyID=companyId,
                                CompanyIBAN =doc.CompanyIBAN,
                                IBAN =doc.IBAN,
                                Currency=doc.Currency,
                                Info=doc.Info
                            }
                        };

                        results = SendToJournal(journal);

                        if (!results)
                            return results;
                    }

                    var item = (from doc in docs
                                group new { doc } by new
                                {
                                    doc.Periode,
                                    doc.Account,
                                    doc.Currency
                                } into g
                                select new
                                {
                                    Periode = g.Key.Periode,
                                    accountID = g.Key.Account,
                                    amount = g.Sum(p => p.doc.Amount),
                                    currency = g.Key.Currency
                                }).Single();
                    results = UpdateAccountBalance(item.Periode, item.accountID, item.amount, item.currency, true, companyId);

                    if (!results)
                        return results;

                    results = UpdateAccountBalance(item.accountID, item.amount, true, companyId);

                    if (!results)
                        return results;
                }
                catch (Exception ex)
                {
                    ViewData["GenericError"] = ex.Message;
                    IWSLookUp.LogException(ex);
                    return false;
                }
            }
            return results;
        }

        private bool ValidateSettlement(int ItemID, string companyId)
        {
            List<JournalViewModel> docs = (from l in db.LineSettlements
                                           where
                                             l.Settlement.id == ItemID
                                           select new JournalViewModel()
                                           {
                                               ItemID = l.Settlement.id,
                                               OID = l.Settlement.oid,
                                               Currency = l.Settlement.oCurrency,
                                               CustSupplierID = l.Settlement.account,
                                               StoreID = l.Settlement.CostCenter,
                                               TransDate = l.Settlement.TransDate,
                                               Itemdate = l.Settlement.ItemDate,
                                               EntryDate = l.Settlement.EntryDate,
                                               Periode = l.Settlement.oPeriode,
                                               Amount = l.amount,
                                               Account = l.account,
                                               OAccount = l.oaccount,
                                               CompanyIBAN = l.Settlement.Company.IBAN ?? "NA",
                                               IBAN = l.Settlement.Customer.IBAN ?? "NA",
                                               Info = l.Settlement.HeaderText
                                           }).Distinct().ToList();
            bool results = false;

            if (docs.Any())
            {
                try
                {

                    foreach (var doc in docs)
                    {
                        results = UpdateAccountBalance(doc.Periode,
                                        doc.Account, doc.Amount, doc.Currency, true, companyId);

                        if (!results)
                            return results;

                        results = UpdateAccountBalance(doc.Account, doc.Amount, true, companyId);

                        if (!results)
                            return results;

                        List<Journal> journal = new List<Journal> {
                            new Journal {
                                ItemID =doc.ItemID,
                                OID =doc.OID,
                                ItemType = IWSLookUp.DocsType.Settlement.ToString(),
                                CustSupplierID =doc.CustSupplierID,
                                StoreID =doc.StoreID,
                                TransDate =doc.TransDate,
                                ItemDate =doc.Itemdate,
                                EntryDate =doc.EntryDate,
                                Periode =doc.Periode,
                                Account =doc.Account,
                                OAccount =doc.OAccount,
                                Amount =doc.Amount,
                                Side = IWSLookUp. Side.Debit.ToString(),
                                CompanyID =companyId,
                                CompanyIBAN =doc.CompanyIBAN,
                                IBAN =doc.IBAN,
                                Currency =doc.Currency,
                                Info =doc.Info
                            },
                            new Journal {
                                ItemID =doc.ItemID,
                                OID =doc.OID,
                                ItemType = IWSLookUp.DocsType.Settlement.ToString(),
                                CustSupplierID=doc.CustSupplierID,
                                StoreID =doc.StoreID,
                                TransDate =doc.TransDate,
                                ItemDate =doc.Itemdate,
                                EntryDate =doc.EntryDate,
                                Periode=doc.Periode,
                                Account =doc.OAccount,
                                OAccount =doc.Account,
                                Amount =doc.Amount,
                                Side = IWSLookUp. Side.Credit.ToString(),
                                CompanyID=companyId,
                                CompanyIBAN =doc.CompanyIBAN,
                                IBAN =doc.IBAN,
                                Currency=doc.Currency,
                                Info=doc.Info
                            }
                        };

                        results = SendToJournal(journal);

                        if (!results)
                            return results;
                    }

                    var item = (from doc in docs
                                group new { doc } by new
                                {
                                    doc.Periode,
                                    doc.OAccount,
                                    doc.Currency
                                } into g
                                select new
                                {
                                    Periode = g.Key.Periode,
                                    accountID = g.Key.OAccount,
                                    amount = g.Sum(p => p.doc.Amount),
                                    currency = g.Key.Currency
                                }).Single();
                    results = UpdateAccountBalance(item.Periode, item.accountID, item.amount, item.currency, false, companyId);

                    if (!results)
                        return results;

                    results = UpdateAccountBalance(item.accountID, item.amount, false, companyId);

                    if (!results)
                        return results;
                }
                catch (Exception ex)
                {
                    ViewData["GenericError"] = ex.Message;
                    IWSLookUp.LogException(ex);
                    return false;
                }
            }
            return results;
        }

        private bool ValidateGeneralLedger(int ItemID, string companyId)
        {
            List<JournalViewModel> docs = (from l in db.LineGeneralLedgers
                                           where
                                             l.GeneralLedger.id == ItemID
                                           select new JournalViewModel()
                                           {
                                               ItemID = l.GeneralLedger.id,
                                               OID = l.GeneralLedger.oid,
                                               Currency = l.GeneralLedger.oCurrency,
                                               CustSupplierID = l.GeneralLedger.CompanyId,
                                               StoreID = l.GeneralLedger.CostCenter,
                                               TransDate = l.GeneralLedger.TransDate,
                                               Itemdate = l.GeneralLedger.ItemDate,
                                               EntryDate = l.GeneralLedger.EntryDate,
                                               Periode = l.GeneralLedger.oPeriode,
                                               Amount = l.amount,
                                               Account = l.account,
                                               OAccount = l.oaccount,
                                               CompanyIBAN = l.GeneralLedger.Company.IBAN ?? "NA",
                                               IBAN = l.GeneralLedger.Company.IBAN ?? "NA",
                                               Info = l.GeneralLedger.HeaderText
                                           }).Distinct().ToList();

            bool results = false;

            if (docs.Any())
            {
                try
                {

                    foreach (var doc in docs)
                    {
                        results = UpdateAccountBalance(doc.Periode,
                                        doc.Account, doc.Amount, doc.Currency, true, companyId);

                        if (!results)
                            return results;

                        results = UpdateAccountBalance(doc.Account, doc.Amount, true,companyId);

                        if (!results)
                            return results;

                        List<Journal> journal = new List<Journal> {
                            new Journal {
                                ItemID =doc.ItemID,
                                OID =doc.OID,
                                ItemType = IWSLookUp.DocsType.GeneralLedger.ToString(),
                                CustSupplierID =doc.CustSupplierID,
                                StoreID =doc.StoreID,
                                TransDate =doc.TransDate,
                                ItemDate =doc.Itemdate,
                                EntryDate =doc.EntryDate,
                                Periode =doc.Periode,
                                Account =doc.Account,
                                OAccount =doc.OAccount,
                                Amount =doc.Amount,
                                Side = IWSLookUp. Side.Debit.ToString(),
                                CompanyID =companyId,
                                CompanyIBAN =doc.CompanyIBAN,
                                IBAN =doc.IBAN,
                                Currency =doc.Currency,
                                Info =doc.Info
                            },
                            new Journal {
                                ItemID =doc.ItemID,
                                OID =doc.OID,
                                ItemType = IWSLookUp.DocsType.GeneralLedger.ToString(),
                                CustSupplierID=doc.CustSupplierID,
                                StoreID =doc.StoreID,
                                TransDate =doc.TransDate,
                                ItemDate =doc.Itemdate,
                                EntryDate =doc.EntryDate,
                                Periode=doc.Periode,
                                Account =doc.OAccount,
                                OAccount =doc.Account,
                                Amount =doc.Amount,
                                Side = IWSLookUp. Side.Credit.ToString(),
                                CompanyID=companyId,
                                CompanyIBAN =doc.CompanyIBAN,
                                IBAN =doc.IBAN,
                                Currency=doc.Currency,
                                Info=doc.Info
                            }
                        };

                        results = SendToJournal(journal);

                        if (!results)
                            return results;
                    }

                    var item = (from doc in docs
                                group new { doc } by new
                                {
                                    doc.Periode,
                                    doc.OAccount,
                                    doc.Currency
                                } into g
                                select new
                                {
                                    Periode = g.Key.Periode,
                                    accountID = g.Key.OAccount,
                                    amount = g.Sum(p => p.doc.Amount),
                                    currency = g.Key.Currency
                                }).Single();

                    results = UpdateAccountBalance(item.Periode, item.accountID, item.amount, item.currency, false, companyId);

                    if (!results)
                        return results;

                    results = UpdateAccountBalance(item.accountID, item.amount, false, companyId);

                    if (!results)
                        return results;
                }
                catch (Exception ex)
                {
                    ViewData["GenericError"] = ex.Message;
                    IWSLookUp.LogException(ex);
                    return false;
                }
            }
            return results;
        }

        public bool MakeCustomerInvoice(int salesInvoiceItemID)
        {
            bool results = false;
            List<ValidateInvoiceViewModel> salesInvoice =
                (from line in db.LineSalesInvoices
                 group new { line, line.Article.Vat, line.SalesInvoice } by new
                 {
                     line.Vat,
                     line.SalesInvoice.id,
                     line.SalesInvoice.oid,
                     line.SalesInvoice.store,
                     line.SalesInvoice.account,
                     line.SalesInvoice.HeaderText,
                     Linetext = line.text,
                     line.SalesInvoice.ItemDate,
                     line.SalesInvoice.CompanyId,
                     line.Article.Vat.revenueaccountid,
                     line.Article.Vat.outputvataccountid,
                     //line.SalesInvoice.Customer.accountid,
                     //line.SalesInvoice.Company.salesclearingaccountid,
                     line.SalesInvoice.oPeriode,
                     line.SalesInvoice.oTotal,
                     line.SalesInvoice.oCurrency
                 } into g
                 where g.Key.id == salesInvoiceItemID
                 select new ValidateInvoiceViewModel
                 {
                     ID = g.Key.id,
                     OID = (int)g.Key.oid,
                     StoreID = g.Key.store,
                     SupplierID = g.Key.account,
                     ItemDate = g.Key.ItemDate,
                     Text = g.Key.HeaderText,
                     LineText = g.Key.Linetext,
                     CompanyID = g.Key.CompanyId,
                     Vat = g.Key.Vat,
                     VatAccountID = g.Key.outputvataccountid,
                     CreditAccountID = g.Key.revenueaccountid,
                     Periode = g.Key.oPeriode,
                     //DebitAccountID = Convert.ToString(g.Key.accountid),
                     TotHTVA = Convert.ToDecimal(g.Key.oTotal),
                     TotTVA = g.Sum(p => p.line.quantity * p.line.price * p.line.Article.Vat.PVat),
                     Currency = g.Key.oCurrency
                 }).ToList();
            if (salesInvoice.Any())
            {
                int itemID = 0;
                CustomerInvoice invoiceHeader = (from item in salesInvoice
                                                 select new CustomerInvoice
                                                 {
                                                     oid = item.ID,
                                                     CostCenter = item.StoreID,
                                                     account = item.SupplierID,
                                                     HeaderText = item.Text,
                                                     ItemDate = item.ItemDate,
                                                     CompanyId = item.CompanyID,
                                                     IsValidated = false
                                                 }).FirstOrDefault();
                itemID = CustomerInvoiceHeader(invoiceHeader);
                if (itemID > 0)
                {
                    List<LineCustomerInvoice> lineCustomer = (from item in salesInvoice
                                                              select new LineCustomerInvoice
                                                              {
                                                                  transid = itemID,
                                                                  account = item.DebitAccountID,
                                                                  side = false,
                                                                  oaccount = item.VatAccountID,
                                                                  amount = Math.Round(item.TotTVA, 2),
                                                                  Currency = item.Currency,
                                                                  duedate = item.ItemDate,
                                                                  text = item.LineText
                                                              }).ToList();

                    string accountID = salesInvoice.Select(a => a.CreditAccountID).First();

                    string oAccountID = salesInvoice.Select(a => a.DebitAccountID).First();

                    decimal amount = Math.Round(salesInvoice.Sum(t => t.TotHTVA), 2);

                    string currency = salesInvoice.Select(a => a.Currency).First();

                    DateTime dueDate = salesInvoice.Select(d => d.ItemDate).First();

                    string text = salesInvoice.Select(t => t.LineText).First();

                    LineCustomerInvoice line = new LineCustomerInvoice
                    {
                        transid = itemID,
                        account = oAccountID,
                        side = false,
                        oaccount = accountID,
                        amount = amount,
                        Currency = currency,
                        duedate = dueDate,
                        text = text
                    };
                    lineCustomer.Add(line);
                    int countLineID = MakeCustomerInvoiceLine(lineCustomer);
                    results = (countLineID > 0);
                    if (!results)
                        return results;
                }
            }
            return results;
        }

        public int CustomerInvoiceHeader(CustomerInvoice customerInvoice)
        {
            int id = 0;
            try
            {
                db.CustomerInvoices.InsertOnSubmit(customerInvoice);
                db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                id = db.CustomerInvoices.Max(i => i.id);
                return id;
            }
            catch (Exception ex)
            {
                ViewData["GenericError"] = ex.Message;
                IWSLookUp.LogException(ex);
                return id;
            }
        }

        public int MakeCustomerInvoiceLine(List<LineCustomerInvoice> line)
        {
            int id = 0;
            try
            {
                foreach (var item in line)
                {
                    if (item.amount > 0)
                    {
                        db.LineCustomerInvoices.InsertOnSubmit(item);
                        id++;
                    }
                }
                db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                return id;
            }
            catch (Exception ex)
            {
                ViewData["GenericError"] = ex.Message;
                IWSLookUp.LogException(ex);
                return 0;
            }
        }
        private bool MakeVendorInvoice(int InventoryInvoiceItemID)
        {
            bool results = false;
            List<ValidateInvoiceViewModel> inventoryInvoice =
                (from line in db.LineInventoryInvoices
                 group new { line, line.Article.Vat, line.InventoryInvoice } by new
                 {
                     line.Vat,
                     line.Currency,
                     line.InventoryInvoice.id,
                     line.InventoryInvoice.oid,
                     line.InventoryInvoice.store,
                     line.InventoryInvoice.account,
                     line.InventoryInvoice.HeaderText,
                     Linetext = line.text,
                     line.InventoryInvoice.ItemDate,
                     line.InventoryInvoice.CompanyId,
                     line.Article.Vat.inputvataccountid,
                     line.InventoryInvoice.Supplier.accountid,
                     line.InventoryInvoice.Company.purchasingclearingaccountid,
                     line.InventoryInvoice.oPeriode
                 } into g
                 where g.Key.id == InventoryInvoiceItemID
                 select new ValidateInvoiceViewModel
                 {
                     ID = g.Key.id,
                     OID = (int)g.Key.oid,
                     StoreID = g.Key.store,
                     SupplierID = g.Key.account,
                     ItemDate = g.Key.ItemDate,
                     Text = g.Key.HeaderText,
                     LineText = g.Key.Linetext,
                     CompanyID = g.Key.CompanyId,
                     Vat = g.Key.Vat,
                     VatAccountID = g.Key.inputvataccountid,
                     Periode = g.Key.oPeriode,
                     DebitAccountID = g.Key.purchasingclearingaccountid,
                     CreditAccountID = g.Key.accountid,
                     TotHTVA = g.Sum(p => p.line.quantity * p.line.price),
                     TotTVA = g.Sum(p => p.line.quantity * p.line.price * p.line.Article.Vat.PVat),
                     Currency = g.Key.Currency
                 }).ToList();

            if (inventoryInvoice.Any())
            {
                int itemID = 0;
                VendorInvoice invoiceHeader = (from item in inventoryInvoice
                                               select new VendorInvoice
                                               {
                                                   oid = item.ID,
                                                   CostCenter = item.StoreID,
                                                   account = item.SupplierID,
                                                   HeaderText = item.Text,
                                                   ItemDate = item.ItemDate,
                                                   CompanyId = item.CompanyID,
                                                   oCurrency = item.Currency,
                                                   IsValidated = false
                                               }).FirstOrDefault();
                itemID = MakeVendorInvoiceHeader(invoiceHeader);
                if (itemID > 0)
                {
                    List<LineVendorInvoice> lineVendor = (from item in inventoryInvoice
                                                          select new LineVendorInvoice
                                                          {
                                                              transid = itemID,
                                                              account = item.VatAccountID,
                                                              side = true,
                                                              oaccount = item.CreditAccountID,
                                                              amount = Math.Round(item.TotTVA, 2),
                                                              Currency = item.Currency,
                                                              duedate = item.ItemDate,
                                                              text = item.LineText
                                                          }).ToList();

                    string accountID = inventoryInvoice.Select(a => a.DebitAccountID).First();

                    string oAccountID = inventoryInvoice.Select(a => a.CreditAccountID).First();

                    decimal amount = Math.Round(inventoryInvoice.Sum(t => t.TotHTVA), 2);

                    string currency = inventoryInvoice.Select(a => a.Currency).First();

                    DateTime dueDate = inventoryInvoice.Select(d => d.ItemDate).First();

                    string text = inventoryInvoice.Select(t => t.LineText).First();

                    LineVendorInvoice line = new LineVendorInvoice
                    {
                        transid = itemID,
                        account = accountID,
                        side = true,
                        oaccount = oAccountID,
                        amount = amount,
                        Currency = currency,
                        duedate = dueDate,
                        text = text
                    };
                    lineVendor.Add(line);
                    int countLineID = MakeVendorInvoiceLine(lineVendor);
                    results = (countLineID > 0);
                    if (!results)
                        return results;

                }
            }
            return results;
        }
        public int MakeCustomerInvoiceHeader(CustomerInvoice customeInvoice)
        {
            int id = 0;
            try
            {
                db.CustomerInvoices.InsertOnSubmit(customeInvoice);
                db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                id = db.CustomerInvoices.Max(i => i.id);
                return id;
            }
            catch (Exception ex)
            {
                ViewData["GenericError"] = ex.Message;
                IWSLookUp.LogException(ex);
                return id;
            }
        }
        public int MakeVendorInvoiceHeader(VendorInvoice invoice)
        {
            int id = 0;
            try
            {
                db.VendorInvoices.InsertOnSubmit(invoice);
                db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                id = db.VendorInvoices.Max(i => i.id);
                return id;
            }
            catch (Exception ex)
            {
                ViewData["GenericError"] = ex.Message;
                IWSLookUp.LogException(ex);
                return id;
            }
        }
        public int MakeVendorInvoiceLine(List<LineVendorInvoice> line)
        {
            int id = 0;
            try
            {
                foreach (var item in line)
                {
                    if (item.amount > 0)
                    {
                        db.LineVendorInvoices.InsertOnSubmit(item);
                        id++;
                    }
                }
                db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                return id;
            }
            catch (Exception ex)
            {
                ViewData["GenericError"] = ex.Message;
                IWSLookUp.LogException(ex);
                return 0;
            }
        }
        private bool MakePayment(int vendorInvoiceID)
        {
            bool results = false;
            List<ValidateInvoiceViewModel> vendorInvoice =
                (from line in db.LineVendorInvoices
                 group new { line, line.VendorInvoice } by new
                 {
                     line.VendorInvoice.id,
                     line.VendorInvoice.CostCenter,
                     SupplierID = line.VendorInvoice.account,
                     line.VendorInvoice.HeaderText,
                     LineText = line.text,
                     line.Currency,
                     line.VendorInvoice.ItemDate,
                     line.VendorInvoice.CompanyId,
                     line.VendorInvoice.Supplier.accountid,
                     line.VendorInvoice.Company.bankaccountid,
                     xMonth = (Convert.ToString((int?)line.VendorInvoice.ItemDate.Month)).Length == 1 ?
                                             '0' + Convert.ToString((int?)line.VendorInvoice.ItemDate.Month) :
                                             Convert.ToString((int?)line.VendorInvoice.ItemDate.Month),
                     xYear = Convert.ToString((int?)line.VendorInvoice.ItemDate.Year)
                 } into g
                 where g.Key.id == vendorInvoiceID
                 select new ValidateInvoiceViewModel
                 {
                     ID = g.Key.id,
                     StoreID = g.Key.CostCenter,
                     SupplierID = g.Key.SupplierID,
                     ItemDate = g.Key.ItemDate,
                     Periode = g.Key.xYear + g.Key.xMonth,
                     Text = g.Key.HeaderText,
                     LineText = g.Key.LineText,
                     Currency = g.Key.Currency,
                     CompanyID = g.Key.CompanyId,
                     CreditAccountID = g.Key.bankaccountid,
                     DebitAccountID = g.Key.accountid,
                     TotTVA = g.Sum(a => a.line.amount)
                 }).ToList();

            if (vendorInvoice.Any())
            {
                int itemID = 0;
                Payment payment = (from item in vendorInvoice
                                   select new Payment
                                   {
                                       oid = item.ID,
                                       CostCenter = item.StoreID,
                                       account = item.SupplierID,
                                       HeaderText = item.Text,
                                       ItemDate = item.ItemDate,
                                       CompanyId = item.CompanyID,
                                       IsValidated = false
                                   }).First();
                itemID = MakePaymentHeader(payment);
                if (itemID > 0)
                {
                    List<LinePayment> lineVendor = (from item in vendorInvoice
                                                    select new LinePayment
                                                    {
                                                        transid = itemID,
                                                        account = item.DebitAccountID,
                                                        side = false,
                                                        oaccount = item.CreditAccountID,
                                                        amount = Math.Round(item.TotTVA, 2),
                                                        Currency = item.Currency,
                                                        duedate = item.ItemDate,
                                                        text = item.LineText
                                                    }).ToList();
                    int countLineID = MakePaymentLine(lineVendor);
                    results = (countLineID > 0);
                }
                if (!results)
                    return results;
                var journals =
                (from line in db.LineVendorInvoices
                 group new { line, line.VendorInvoice } by new
                 {
                     line.VendorInvoice.id,
                     line.VendorInvoice.oid,
                     line.VendorInvoice.CostCenter,
                     SupplierID = line.VendorInvoice.account,
                     line.VendorInvoice.HeaderText,
                     line.VendorInvoice.ItemDate,
                     line.VendorInvoice.CompanyId,
                     line.account,
                     line.oaccount,
                     line.amount,
                     line.Currency,
                     line.VendorInvoice.Company.bankaccountid,
                     xMonth = (Convert.ToString((int?)line.VendorInvoice.ItemDate.Month)).Length == 1 ?
                                             '0' + Convert.ToString((int?)line.VendorInvoice.ItemDate.Month) :
                                             Convert.ToString((int?)line.VendorInvoice.ItemDate.Month),
                     xYear = Convert.ToString((int?)line.VendorInvoice.ItemDate.Year)
                 } into g
                 where g.Key.id == vendorInvoiceID
                 select new
                 {
                     ItemID = g.Key.id,
                     OID = (int)g.Key.oid,
                     ItemType = IWSLookUp.DocsType.GoodReceiving.ToString(),
                     CustSupplierID = g.Key.SupplierID,
                     StoreID = g.Key.CostCenter,
                     TransDate = g.Key.ItemDate,
                     Periode = g.Key.xYear + g.Key.xMonth,
                     Account = g.Key.account,
                     OAccount = g.Key.oaccount,
                     Amount = g.Key.amount,
                     Currency = g.Key.Currency
                 }).ToList();

                foreach (var item in journals)
                {
                    List<Journal> journal = new List<Journal> {
                            new Journal { ItemID=item.ItemID,
                            OID =item.OID,
                            CustSupplierID=item.CustSupplierID,
                            StoreID =item.StoreID,
                            TransDate =item.TransDate,
                            Periode=item.Periode,
                            Account =item.Account,
                            OAccount =item.OAccount,
                            Amount =item.Amount,
                            Currency=item.Currency,
                            ItemType = IWSLookUp. DocsType.VendorInvoice.ToString(),
                            Side = IWSLookUp. Side.Debit.ToString(),
                            CompanyID=(string)Session["CompanyID"]},
                        new Journal { ItemID=item.ItemID,
                            OID =item.OID,
                            CustSupplierID=item.CustSupplierID,
                            StoreID =item.StoreID,
                            TransDate =item.TransDate,
                            Periode=item.Periode,
                            Account =item.OAccount,
                            OAccount =item.Account,
                            Amount =item.Amount,
                            Currency=item.Currency,
                            ItemType = IWSLookUp. DocsType.VendorInvoice.ToString(),
                            Side = IWSLookUp. Side.Credit.ToString(),
                            CompanyID=(string)Session["CompanyID"]} };

                    results = SendToJournal(journal);
                    if (!results)
                        return results;
                }
            }
            return results;
        }
        public int MakePaymentHeader(Payment payment)
        {
            int id = 0;
            try
            {
                db.Payments.InsertOnSubmit(payment);
                db.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
                id = db.Payments.Max(i => i.id);
                return id;
            }
            catch (Exception ex)
            {
                ViewData["GenericError"] = ex.Message;
                IWSLookUp.LogException(ex);
                return id;
            }
        }
        public int MakePaymentLine(List<LinePayment> linePayment)
        {
            int id = 0;
            try
            {
                foreach (var item in linePayment)
                {
                    db.LinePayments.InsertOnSubmit(item);
                    id++;
                }
                db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                return id;
            }
            catch (Exception ex)
            {
                ViewData["GenericError"] = ex.Message;
                IWSLookUp.LogException(ex);
                return 0;
            }
        }
        private bool MakeSettlement(int customerInvoiceID)
        {
            bool results = false;
            List<ValidateInvoiceViewModel> customerInvoice =
                (from line in db.LineCustomerInvoices
                 group new { line, line.CustomerInvoice } by new
                 {
                     line.CustomerInvoice.id,
                     line.CustomerInvoice.CostCenter,
                     SupplierID = line.CustomerInvoice.account,
                     line.CustomerInvoice.HeaderText,
                     LineText = line.text,
                     line.CustomerInvoice.ItemDate,
                     line.CustomerInvoice.CompanyId,
                     //line.CustomerInvoice.Customer.accountid,
                     line.CustomerInvoice.Company.bankaccountid,
                     line.Currency,
                     xMonth = (Convert.ToString((int?)line.CustomerInvoice.ItemDate.Month)).Length == 1 ?
                                             '0' + Convert.ToString((int?)line.CustomerInvoice.ItemDate.Month) :
                                             Convert.ToString((int?)line.CustomerInvoice.ItemDate.Month),
                     xYear = Convert.ToString((int?)line.CustomerInvoice.ItemDate.Year)
                 } into g
                 where g.Key.id == customerInvoiceID
                 select new ValidateInvoiceViewModel
                 {
                     ID = g.Key.id,
                     StoreID = g.Key.CostCenter,
                     SupplierID = g.Key.SupplierID,
                     ItemDate = g.Key.ItemDate,
                     Periode = g.Key.xYear + g.Key.xMonth,
                     Text = g.Key.HeaderText,
                     LineText = g.Key.LineText,
                     CompanyID = g.Key.CompanyId,
                     //CreditAccountID = Convert.ToString(g.Key.accountid),
                     DebitAccountID = g.Key.bankaccountid,
                     TotTVA = g.Sum(a => a.line.amount),
                     Currency = g.Key.Currency
                 }).ToList();


            if (customerInvoice.Any())
            {
                int itemID = 0;
                Settlement settlement = (from item in customerInvoice
                                         select new Settlement
                                         {
                                             oid = item.ID,
                                             CostCenter = item.StoreID,
                                             account = item.SupplierID,
                                             HeaderText = item.Text,
                                             ItemDate = item.ItemDate,
                                             CompanyId = item.CompanyID,
                                             IsValidated = false
                                         }).First();
                itemID = MakeSettlementHeader(settlement);
                if (itemID > 0)
                {
                    List<LineSettlement> lineSettlement = (from item in customerInvoice
                                                           select new LineSettlement
                                                           {
                                                               transid = itemID,
                                                               account = item.DebitAccountID,
                                                               side = false,
                                                               oaccount = item.CreditAccountID,
                                                               amount = Math.Round(item.TotTVA, 2),
                                                               Currency = item.Currency,
                                                               duedate = item.ItemDate,
                                                               text = item.LineText
                                                           }).ToList();
                    int countLineID = MakeSettlementLine(lineSettlement);
                    results = (countLineID > 0);
                }
                if (!results)
                    return results;
                var journals =
                     (from line in db.LineCustomerInvoices
                      group new { line, line.CustomerInvoice } by new
                      {
                          line.CustomerInvoice.id,
                          line.CustomerInvoice.oid,
                          line.CustomerInvoice.CostCenter,
                          SupplierID = line.CustomerInvoice.account,
                          line.CustomerInvoice.HeaderText,
                          line.CustomerInvoice.ItemDate,
                          line.CustomerInvoice.CompanyId,
                          line.account,
                          line.oaccount,
                          line.amount,
                          line.Currency,
                          line.CustomerInvoice.Company.bankaccountid,
                          xMonth = (Convert.ToString((int?)line.CustomerInvoice.ItemDate.Month)).Length == 1 ?
                                                  '0' + Convert.ToString((int?)line.CustomerInvoice.ItemDate.Month) :
                                                  Convert.ToString((int?)line.CustomerInvoice.ItemDate.Month),
                          xYear = Convert.ToString((int?)line.CustomerInvoice.ItemDate.Year)
                      } into g
                      where g.Key.id == customerInvoiceID
                      select new
                      {
                          ItemID = g.Key.id,
                          OID = (int)g.Key.oid,
                          ItemType = IWSLookUp.DocsType.CustomerInvoice.ToString(),
                          CustSupplierID = g.Key.SupplierID,
                          StoreID = g.Key.CostCenter,
                          TransDate = g.Key.ItemDate,
                          Periode = g.Key.xYear + g.Key.xMonth,
                          Account = g.Key.account,
                          OAccount = g.Key.oaccount,
                          Amount = g.Key.amount,
                          Currency = g.Key.Currency
                      }).ToList();

                foreach (var item in journals)
                {
                    List<Journal> journal = new List<Journal> {
                        new Journal { ItemID=item.ItemID,
                            OID =item.OID,
                            CustSupplierID=item.CustSupplierID,
                            StoreID =item.StoreID,
                            TransDate =item.TransDate,
                            Periode=item.Periode,
                            Account =item.Account,
                            OAccount =item.OAccount,
                            Amount =item.Amount,
                            Currency=item.Currency,
                            ItemType = IWSLookUp. DocsType.CustomerInvoice.ToString(),
                            Side = IWSLookUp. Side.Debit.ToString(),
                            CompanyID=(string)Session["CompanyID"]},
                        new Journal { ItemID=item.ItemID,
                            OID =item.OID,
                            CustSupplierID=item.CustSupplierID,
                            StoreID =item.StoreID,
                            TransDate =item.TransDate,
                            Periode=item.Periode,
                            Account =item.OAccount,
                            OAccount =item.Account,
                            Amount =item.Amount,
                            Currency=item.Currency,
                            ItemType = IWSLookUp. DocsType.CustomerInvoice.ToString(),
                            Side = IWSLookUp. Side.Credit.ToString(),
                            CompanyID=(string)Session["CompanyID"]} };
                    results = SendToJournal(journal);
                    if (!results)
                        return results;
                }
            }
            return results;
        }
        public int MakeSettlementHeader(Settlement settlement)
        {
            int id = 0;
            try
            {
                db.Settlements.InsertOnSubmit(settlement);
                db.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
                id = db.Settlements.Max(i => i.id);
                return id;
            }
            catch (Exception ex)
            {
                ViewData["GenericError"] = ex.Message;
                IWSLookUp.LogException(ex);
                return id;
            }
        }
        public int MakeSettlementLine(List<LineSettlement> lineSettlement)
        {
            int id = 0;
            try
            {
                foreach (var item in lineSettlement)
                {
                    db.LineSettlements.InsertOnSubmit(item);
                    id++;
                }
                db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                return id;
            }
            catch (Exception ex)
            {
                ViewData["GenericError"] = ex.Message;
                IWSLookUp.LogException(ex);
                return 0;
            }
        }
        public bool SendToJournal(List<Journal> journal)
        {
            bool results = false;
            if (ModelState.IsValid)
            {
                try
                {
                    foreach (Journal item in journal)
                    {
                        db.Journals.InsertOnSubmit(item);
                    }
                    results = true;
                }
                catch (Exception ex)
                {
                    ViewData["GenericError"] = ex.Message;
                    IWSLookUp.LogException(ex);
                    results = false;
                }
            }
            return results;
        }

        private bool UpdateEntryDate(int ItemID, string ItemType)
        {
            bool results = false;
            try
            {
                if (ItemType.Equals(IWSLookUp.DocsType.PurchaseOrder.ToString()))
                {
                    var docs = db.PurchaseOrders.Single(item => item.id == ItemID);
                    if (!docs.Equals(null))
                    {
                        docs.EntryDate = DateTime.Today;
                        results = true;
                    }
                }
                if (ItemType.Equals(IWSLookUp.DocsType.SalesOrder.ToString()))
                {
                    var docs = db.SalesOrders.Single(item => item.id == ItemID);
                    if (!docs.Equals(null))
                    {
                        docs.EntryDate = DateTime.Today;
                        results = true;
                    }
                }
                if (ItemType.Equals(IWSLookUp.DocsType.GoodReceiving.ToString()))
                {
                    var docs = db.GoodReceivings.Single(item => item.id == ItemID);
                    if (!docs.Equals(null))
                    {
                        docs.EntryDate = DateTime.Today;
                        results = true;
                    }
                }
                if (ItemType.Equals(IWSLookUp.DocsType.BillOfDelivery.ToString()))
                {
                    var docs = db.BillOfDeliveries.Single(item => item.id == ItemID);
                    if (!docs.Equals(null))
                    {
                        docs.EntryDate = DateTime.Today;
                        results = true;
                    }
                }
                if (ItemType.Equals(IWSLookUp.DocsType.InventoryInvoice.ToString()))
                {
                    var docs = db.InventoryInvoices.Single(item => item.id == ItemID);
                    if (!docs.Equals(null))
                    {
                        docs.EntryDate = DateTime.Today;
                        results = true;
                    }
                }
                if (ItemType.Equals(IWSLookUp.DocsType.CustomerInvoice.ToString()))
                {
                    var docs = db.CustomerInvoices.Single(item => item.id == ItemID);
                    if (!docs.Equals(null))
                    {
                        docs.EntryDate = DateTime.Today;
                        results = true;
                    }
                }
                if (ItemType.Equals(IWSLookUp.DocsType.VendorInvoice.ToString()))
                {
                    var docs = db.VendorInvoices.Single(item => item.id == ItemID);
                    if (!docs.Equals(null))
                    {
                        docs.EntryDate = DateTime.Today;
                        results = true;
                    }
                }
                if (ItemType.Equals(IWSLookUp.DocsType.SalesInvoice.ToString()))
                {
                    var docs = db.SalesInvoices.Single(item => item.id == ItemID);
                    if (!docs.Equals(null))
                    {
                        docs.EntryDate = DateTime.Today;
                        results = true;
                    }
                }
                if (ItemType.Equals(IWSLookUp.DocsType.Payment.ToString()))
                {
                    var docs = db.Payments.Single(item => item.id == ItemID);
                    if (!docs.Equals(null))
                    {
                        docs.EntryDate = DateTime.Today;
                        results = true;
                    }
                }
                if (ItemType.Equals(IWSLookUp.DocsType.Settlement.ToString()))
                {
                    var docs = db.Settlements.Single(item => item.id == ItemID);
                    if (!docs.Equals(null))
                    {
                        docs.EntryDate = DateTime.Today;
                        results = true;
                    }
                }
                if (ItemType.Equals(IWSLookUp.DocsType.GeneralLedger.ToString()))
                {
                    var docs = db.GeneralLedgers.Single(item => item.id == ItemID);
                    if (!docs.Equals(null))
                    {
                        docs.EntryDate = DateTime.Today;
                        results = true;
                    }
                }
                if (results)
                    db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
            }
            catch (Exception ex)
            {
                ViewData["GenericError"] = ex.Message;
                IWSLookUp.LogException(ex);
                results = false;
            }
            return results;
        }

        public void ProcessData(string selectedItems, string companyId, bool convertType)
        {
            using (TransactionScope tx = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                string msg;
                try
                {
                    IList<string> items = new List<string>(selectedItems.Split(new string[] { ";" }, StringSplitOptions.None));
                    foreach (string item in items)
                    {
                        bool results = false;
                        int ItemID;
                        string ItemType;
                        var list = item.Split(new string[] { "," }, StringSplitOptions.None);

                        ItemID = Convert.ToInt32(list[0]);

                        ItemType = list[1];

                        if(convertType)
                        {
                            ItemType = GetItemType(ItemType);
                        }
                        results = UpdateEntryDate(ItemID, ItemType);
                        if (!results)
                        {
                            msg = IWSLocalResource.GenericError;
                            throw new Exception(msg);
                        }
                        results = UpdateStock(ItemID, ItemType, companyId);
                        if (!results)
                        {
                            msg = IWSLocalResource.GenericError;
                            throw new Exception(msg);
                        }
                        results = Account(ItemID, ItemType, companyId);
                        if (!results)
                        {
                            msg = IWSLocalResource.GenericError;
                            throw new Exception(msg);
                        }
                        results = Validate(ItemID, ItemType);
                        if (!results)
                        {
                            msg = IWSLocalResource.GenericError;
                            throw new Exception(msg);
                        }
                        db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                    }
                    tx.Complete();
                }
                catch (Exception ex)
                {
                    ViewData["GenericError"] = ex.Message;
                    IWSLookUp.LogException(ex);
                    tx.Dispose();
                }
            }

        }

        public string SetDocType(string selectedItems, string docType)
        {
  
            string[] items = selectedItems.Split(new string[] { ";" }, 
                                        StringSplitOptions.RemoveEmptyEntries);

            items = items.Select(x => x + "," + docType).ToArray();

            return String.Join(";", items);
        }

        #endregion
    }
}