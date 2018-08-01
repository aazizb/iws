using IWSProject.Content;
using IWSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace IWSProject.Controllers
{
    public abstract class IWSBaseController : Controller
    {

        #region New Methods
        protected static IWSDataContext db;
        public IWSBaseController()
        {
            db = new IWSDataContext();
        }
        protected static bool UpdateEntryDate(int itemId, int modelId)
        {
            bool results = false;

            if (modelId.Equals((int)IWSLookUp.LogisticMasterModelId.PurchaseOrder) ||
                modelId.Equals((int)IWSLookUp.LogisticMasterModelId.GoodReceiving) ||
                    modelId.Equals((int)IWSLookUp.LogisticMasterModelId.InventoryInvoice) ||
                    modelId.Equals((int)IWSLookUp.LogisticMasterModelId.SalesOrder) ||
                    modelId.Equals((int)IWSLookUp.LogisticMasterModelId.BillOfDelivery) ||
                    modelId.Equals((int)IWSLookUp.LogisticMasterModelId.SalesInvoice))
            {
                var item = db.MasterLogistics.SingleOrDefault(o => o.id.Equals(itemId));
                if(item != null)
                {
                    item.EntryDate = DateTime.Today;
                    results = true;
                }
            }
            if (modelId.Equals((int)IWSLookUp.ComptaMasterModelId.VendorInvoice) ||
                modelId.Equals((int)IWSLookUp.ComptaMasterModelId.CustomerInvoice) ||
                    modelId.Equals((int)IWSLookUp.ComptaMasterModelId.Payment) ||
                    modelId.Equals((int)IWSLookUp.ComptaMasterModelId.Settlement) ||
                    modelId.Equals((int)IWSLookUp.ComptaMasterModelId.GeneralLedger))
            {
                var item = db.MasterComptas.SingleOrDefault(o => o.id.Equals(itemId));
                if (item != null)
                {
                    item.EntryDate = DateTime.Today;
                    results = true;
                }
            }

            return results;
        }
        protected static bool Validate(int itemId, int modelId)
        {
            bool results = false;

            if (modelId.Equals((int)IWSLookUp.LogisticMasterModelId.PurchaseOrder) ||
                modelId.Equals((int)IWSLookUp.LogisticMasterModelId.GoodReceiving) ||
                    modelId.Equals((int)IWSLookUp.LogisticMasterModelId.InventoryInvoice) ||
                    modelId.Equals((int)IWSLookUp.LogisticMasterModelId.SalesOrder) ||
                    modelId.Equals((int)IWSLookUp.LogisticMasterModelId.BillOfDelivery) ||
                    modelId.Equals((int)IWSLookUp.LogisticMasterModelId.SalesInvoice))
            {
                var item = db.MasterLogistics.SingleOrDefault(o => o.id.Equals(itemId));
                if (item != null)
                {
                    item.IsValidated = true;
                    results = true;
                }
            }
            if (modelId.Equals((int)IWSLookUp.ComptaMasterModelId.VendorInvoice) ||
                modelId.Equals((int)IWSLookUp.ComptaMasterModelId.CustomerInvoice) ||
                    modelId.Equals((int)IWSLookUp.ComptaMasterModelId.Payment) ||
                    modelId.Equals((int)IWSLookUp.ComptaMasterModelId.Settlement) ||
                    modelId.Equals((int)IWSLookUp.ComptaMasterModelId.GeneralLedger))
            {
                var item = db.MasterComptas.SingleOrDefault(o => o.id.Equals(itemId));
                if (item != null)
                {
                    item.IsValidated = true;
                    results = true;
                }
            }
            return results;
        }
        protected static bool UpdateStock(int itemId, int modelId, string CompanyId)
        {
            bool results = true;
            try
            {

                if ((modelId.Equals((int)IWSLookUp.LogisticMasterModelId.GoodReceiving)) || 
                    (modelId.Equals((int)IWSLookUp.LogisticMasterModelId.BillOfDelivery)))
                {
                    results = false;

                    List<ValidateStockViewModel> validateStock =
                    (from line in db.DetailLogistics
                        group new { line, line.MasterLogistic } by new
                        {
                            DocumentID = line.MasterLogistic.id,
                            StoreID = line.MasterLogistic.store,
                            ItemID = line.item,
                            ItemName = line.Article.name,
                            Price = line.price,
                            Currency = line.MasterLogistic.oCurrency,
                            line.Article.IsService,
                            Text = line.MasterLogistic.HeaderText
                        } into g
                        where g.Key.DocumentID == itemId
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

                    if (modelId.Equals((int)IWSLookUp.LogisticMasterModelId.GoodReceiving))
                    {
                        if (validateStock.Any(i => i.IsService.Equals(false)))
                        {
                            results = StockIn(validateStock, CompanyId);
                        }
                    }
                    if (modelId.Equals((int)IWSLookUp.LogisticMasterModelId.BillOfDelivery))
                    {
                        if (validateStock.Any(i => i.IsService == false))
                        {
                            results = StockOut(validateStock, CompanyId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IWSLookUp.LogException(ex);
            }
            return results;
        }
        protected static bool StockIn(List<ValidateStockViewModel> items, string CompanyId)
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
                IWSLookUp.LogException(ex);
                return false;
            }
        }
        protected static bool StockOut(List<ValidateStockViewModel> items, string CompanyId)
        {
            bool results = false;
            string msg = String.Empty;
            try
            {
                foreach (var item in items.Where(i => i.IsService == false))
                {
                    var stock = db.Stocks.FirstOrDefault(s => s.storeid == item.StoreID && s.itemid == item.ItemID && s.CompanyID == CompanyId);
                    if (stock != null)
                    {
                        decimal RequestedQuantity = Convert.ToDecimal(item.Quantity);
                        decimal AvailableQuantity = Convert.ToDecimal(stock.quantity + stock.minstock);
                        if (AvailableQuantity >= RequestedQuantity)
                        {
                            stock.quantity -= (float)item.Quantity;
                            results = true;
                        }
                        else
                        {
                            msg = IWSLocalResource.InsufficientStock + ": " + item.ItemID + "-" + item.ItemName;
                            //ViewData["GenericError"] = msg;
                            results = false;
                        }
                    }
                    else
                    {
                        msg = IWSLocalResource.InsufficientStock + ": " + item.ItemID + "-" + item.ItemName;
                        //ViewData["GenericError"] = msg;
                        results = false;
                    }
                    if (!results)
                        throw new Exception(msg);
                }
            }
            catch (Exception ex)
            {
                IWSLookUp.LogException(ex);
                results = false;
            }
            return results;
        }
        protected static bool ValidateMasters(int itemId, int modelId, string companyId)
        {
            string iban = String.Empty;

            bool results = true;

            if (modelId.Equals((int)IWSLookUp.LogisticMasterModelId.BillOfDelivery))
            {
                results = false;

                iban = db.MasterLogistics.Join(db.Customers,
                       v => v.account, s => s.id, (v, s) => new
                       {
                           iban = s.IBAN,
                           itemId = v.id,
                           CompanyId = s.CompanyID
                       }).FirstOrDefault(d =>
                       d.CompanyId.Equals(companyId) && d.itemId.Equals(itemId)).iban;

                List<JournalViewModel> docs = (from l in db.DetailLogistics
                    where
                        l.MasterLogistic.id == itemId
                    select new JournalViewModel()
                    {
                        ItemID = l.MasterLogistic.id,
                        OID = l.MasterLogistic.oid,
                        Currency = l.MasterLogistic.oCurrency,
                        CustSupplierID = l.MasterLogistic.account,
                        StoreID = l.MasterLogistic.store,
                        TransDate = l.MasterLogistic.TransDate,
                        Itemdate = l.MasterLogistic.ItemDate,
                        EntryDate = l.MasterLogistic.EntryDate,
                        Periode = l.MasterLogistic.oPeriode,
                        Amount = (decimal)l.MasterLogistic.oTotal,
                        Account = l.MasterLogistic.Company.salesclearingaccountid,
                        OAccount = l.Article.RevenuAccountId,
                        CompanyIBAN = l.MasterLogistic.Company.IBAN,
                        IBAN = iban,
                        Info = l.MasterLogistic.HeaderText
                    }).Distinct().ToList();
                if (docs.Any())
                {
                    results = ValidateBillOfDelivery(docs, companyId);
                }
                if (!results)
                    return results;
                docs = (from l in db.DetailLogistics
                        where
                            !(l.Article.IsService == true)
                        group new { l.MasterLogistic, l.Article, l.MasterLogistic.Company,  l } by new 
                        {
                            l.MasterLogistic.id,
                            l.MasterLogistic.oid,
                            l.MasterLogistic.account,
                            l.MasterLogistic.store,
                            l.MasterLogistic.TransDate,
                            l.MasterLogistic.ItemDate,
                            l.MasterLogistic.EntryDate,
                            l.MasterLogistic.oPeriode,
                            l.Article.avgprice,
                            l.Article.ExpenseAccount,
                            l.Article.StockAccount,
                            CompanyIBAN = l.MasterLogistic.Company.IBAN,
                            IBAN = iban,
                            l.MasterLogistic.oCurrency,
                            l.MasterLogistic.HeaderText
                        } into g
                        where g.Key.id == itemId
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
                            Info = g.Key.HeaderText,
                            ModelId = modelId
                        }).ToList();
                if (docs.Any())
                {
                    results = ValidateBillOfDelivery(docs, companyId);
                }
                return results;
            }

            if (modelId.Equals((int)IWSLookUp.LogisticMasterModelId.GoodReceiving))
            {
                results = false;

                iban = db.MasterLogistics.Join(db.Suppliers,
                        v => v.account, s => s.id, (v, s) => new
                        {
                            iban = s.IBAN,
                            itemId = v.id,
                            CompanyId = s.CompanyID
                        }).FirstOrDefault(d =>
                        d.CompanyId.Equals(companyId) && d.itemId.Equals(itemId)).iban;

                List<JournalViewModel> docs = (from o in (
                (from i in db.DetailLogistics
                 select new
                 {
                     i.MasterLogistic.id,
                     i.MasterLogistic.oid,
                     i.MasterLogistic.account,
                     i.MasterLogistic.store,
                     i.MasterLogistic.TransDate,
                     i.MasterLogistic.ItemDate,
                     i.MasterLogistic.EntryDate,
                     i.MasterLogistic.oPeriode,
                     i.Article.StockAccount,
                     i.MasterLogistic.Company.purchasingclearingaccountid,
                     sAmount = i.lineNet,
                     i.MasterLogistic.Company.IBAN,
                     IBAN2 = iban,
                     i.MasterLogistic.oCurrency,
                     i.MasterLogistic.HeaderText
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
                    where g.Key.id == itemId
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
                        IBAN = g.Key.IBAN2.ToString(),
                        Currency = g.Key.oCurrency,
                        Info = g.Key.HeaderText,
                        ModelId = modelId
                    }).Distinct().ToList();                

                if (docs.Any())
                {
                    try
                    {
                        foreach (var doc in docs)
                        {

                            results = UpdatePeriodicBalance(doc.Periode, doc.Account, doc.Amount, doc.Currency, true, companyId);

                            if (!results)
                                return results;

                            results = UpdateAccountBalance(doc.Account, doc.Amount, true, companyId);

                            if (!results)
                                return results;

                            List<Journal> journal = new List<Journal> {
                            new Journal {
                                ItemID =doc.ItemID,
                                OID =doc.OID,
                                ItemType = IWSLookUp.LogisticMasterModelId.GoodReceiving.ToString(),
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
                                Info =doc.Info,
                                ModelId = modelId
                            },
                            new Journal {
                                ItemID =doc.ItemID,
                                OID =doc.OID,
                                ItemType = IWSLookUp.LogisticMasterModelId.GoodReceiving.ToString(),
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
                                Info=doc.Info,
                                ModelId = modelId
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
                                        g.Key.Periode,
                                        accountID = g.Key.OAccount,
                                        amount = g.Sum(p => p.doc.Amount),
                                        currency = g.Key.Currency
                                    }).Single();
                        results = UpdatePeriodicBalance(item.Periode, item.accountID, item.amount, item.currency, false, companyId);

                        if (!results)
                            return results;

                        results = UpdateAccountBalance(item.accountID, item.amount, false, companyId);

                        if (!results)
                            return results;
                    }
                    catch (Exception ex)
                    {
                        IWSLookUp.LogException(ex);
                        return false;
                    }
                }

            }

            if (modelId.Equals((int)IWSLookUp.ComptaMasterModelId.VendorInvoice))
            {
                results = false;

                iban = db.MasterComptas.Join(db.Suppliers,
                        m => m.account, s => s.accountid, (m, s) => new
                        {
                            iban = s.IBAN,
                            itemId = m.id,
                            CompanyId = s.CompanyID
                        }).FirstOrDefault(d =>
                        d.CompanyId.Equals(companyId) && d.itemId.Equals(itemId)).iban;

                List<JournalViewModel> docs = (from l in db.DetailComptas
                                               where
                                                 l.MasterCompta.id == itemId
                                               select new JournalViewModel()
                                               {
                                                   ItemID = l.MasterCompta.id,
                                                   OID = l.MasterCompta.oid,
                                                   Currency = l.MasterCompta.oCurrency,
                                                   CustSupplierID = l.MasterCompta.account,
                                                   StoreID = l.MasterCompta.CostCenter,
                                                   TransDate = l.MasterCompta.TransDate,
                                                   Itemdate = l.MasterCompta.ItemDate,
                                                   EntryDate = l.MasterCompta.EntryDate,
                                                   Periode = l.MasterCompta.oPeriode,
                                                   Amount = l.amount,
                                                   Account = l.account,
                                                   OAccount = l.oaccount,
                                                   CompanyIBAN = l.MasterCompta.Company.IBAN ?? "NA",
                                                   IBAN = iban,
                                                   Info = l.MasterCompta.HeaderText,
                                                   TypeJournal = l.MasterCompta.TypeJournal,
                                                   CostCenterId = l.MasterCompta.CostCenter,
                                                   ModelId = modelId
                                               }).Distinct().ToList();

                if (docs.Any())
                {
                    try
                    {

                        foreach (var doc in docs)
                        {
                            results = UpdatePeriodicBalance(doc.Periode,
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
                                ModelId = doc.ModelId,
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
                                Info =doc.Info,
                                TypeJournal=doc.TypeJournal,
                                CostCenterId=doc.CostCenterId
                            },
                            new Journal {
                                ItemID =doc.ItemID,
                                OID =doc.OID,
                                ModelId = doc.ModelId,
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
                                Info=doc.Info,
                                TypeJournal=doc.TypeJournal,
                                CostCenterId=doc.CostCenterId
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
                                        g.Key.Periode,
                                        accountID = g.Key.Account,
                                        amount = g.Sum(p => p.doc.Amount),
                                        currency = g.Key.Currency
                                    }).Single();
                        results = UpdatePeriodicBalance(item.Periode, item.accountID, item.amount, item.currency, false, companyId);

                        if (!results)
                            return results;

                        results = UpdateAccountBalance(item.accountID, item.amount, false, companyId);

                        if (!results)
                            return results;
                    }
                    catch (Exception ex)
                    {
                        IWSLookUp.LogException(ex);
                        return false;
                    }
                }
                return results;

            }
            if (modelId.Equals((int)IWSLookUp.ComptaMasterModelId.CustomerInvoice))
            {
                results = false;
                iban = db.MasterComptas.Join(db.Customers,
                        m => m.account, c => c.accountid, (m, c) => new
                        {
                            iban = c.IBAN,
                            itemId = m.id,
                            CompanyId = c.CompanyID
                        }).FirstOrDefault(d =>
                        d.CompanyId.Equals(companyId) && d.itemId.Equals(itemId)).iban;

                List<JournalViewModel> docs = (from l in db.DetailComptas
                                               where
                                                 l.MasterCompta.id == itemId
                                               select new JournalViewModel()
                                               {
                                                   ItemID = l.MasterCompta.id,
                                                   OID = l.MasterCompta.oid,
                                                   Currency = l.MasterCompta.oCurrency,
                                                   CustSupplierID = l.MasterCompta.account,
                                                   StoreID = l.MasterCompta.CostCenter,
                                                   TransDate = l.MasterCompta.TransDate,
                                                   Itemdate = l.MasterCompta.ItemDate,
                                                   EntryDate = l.MasterCompta.EntryDate,
                                                   Periode = l.MasterCompta.oPeriode,
                                                   Amount = l.amount,
                                                   Account = l.account,
                                                   OAccount = l.oaccount,
                                                   CompanyIBAN = l.MasterCompta.Company.IBAN ?? "NA",
                                                   IBAN = iban,
                                                   Info = l.MasterCompta.HeaderText,
                                                   TypeJournal = l.MasterCompta.TypeJournal,
                                                   CostCenterId = l.MasterCompta.CostCenter,
                                                   ModelId = modelId
                                               }).Distinct().ToList();

                if (docs.Any())
                {
                    try
                    {

                        foreach (var doc in docs)
                        {

                            results = UpdatePeriodicBalance(doc.Periode, doc.OAccount, doc.Amount, doc.Currency, false, companyId);

                            if (!results)
                                return results;

                            results = UpdateAccountBalance(doc.OAccount, doc.Amount, false, companyId);

                            if (!results)
                                return results;

                            List<Journal> journal = new List<Journal> {
                            new Journal {
                                ItemID =doc.ItemID,
                                OID =doc.OID,
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
                                Info =doc.Info,
                                TypeJournal=doc.TypeJournal,
                                CostCenterId=doc.CostCenterId,
                                ModelId = doc.ModelId
                            },
                            new Journal {
                                ItemID =doc.ItemID,
                                OID =doc.OID,
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
                                Info=doc.Info,
                                TypeJournal=doc.TypeJournal,
                                CostCenterId=doc.CostCenterId,
                                ModelId = doc.ModelId
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
                                        g.Key.Periode,
                                        accountID = g.Key.Account,
                                        amount = g.Sum(p => p.doc.Amount),
                                        currency = g.Key.Currency
                                    }).Single();
                        results = UpdatePeriodicBalance(item.Periode, item.accountID, item.amount, item.currency, true, companyId);

                        if (!results)
                            return results;

                        results = UpdateAccountBalance(item.accountID, item.amount, true, companyId);

                        if (!results)
                            return results;
                    }
                    catch (Exception ex)
                    {
                        IWSLookUp.LogException(ex);
                        return false;
                    }
                }
                return results;
            }
            if (modelId.Equals((int)IWSLookUp.ComptaMasterModelId.Payment))
            {
                results = false;
           
                iban = db.MasterComptas.Join(db.Suppliers,
                        m => m.account, s => s.accountid, (m, s) => new
                        {
                            iban = s.IBAN,
                            itemId = m.id,
                            CompanyId = s.CompanyID
                        }).FirstOrDefault(d =>
                        d.CompanyId.Equals(companyId) && d.itemId.Equals(itemId)).iban;

                List<JournalViewModel> docs = (from l in db.DetailComptas
                                               where
                                                 l.MasterCompta.id == itemId
                                               select new JournalViewModel()
                                               {
                                                   ItemID = l.MasterCompta.id,
                                                   OID = l.MasterCompta.oid,
                                                   Currency = l.MasterCompta.oCurrency,
                                                   CustSupplierID = l.MasterCompta.account,
                                                   StoreID = l.MasterCompta.CostCenter,
                                                   TransDate = l.MasterCompta.TransDate,
                                                   Itemdate = l.MasterCompta.ItemDate,
                                                   EntryDate = l.MasterCompta.EntryDate,
                                                   Periode = l.MasterCompta.oPeriode,
                                                   Amount = l.amount,
                                                   Account = l.account,
                                                   OAccount = l.oaccount,
                                                   CompanyIBAN = l.MasterCompta.Company.IBAN ?? "NA",
                                                   IBAN = iban,
                                                   Info = l.MasterCompta.HeaderText,
                                                   TypeJournal = l.MasterCompta.TypeJournal,
                                                   CostCenterId = l.MasterCompta.CostCenter,
                                                   ModelId = modelId
                                               }).Distinct().ToList();

                if (docs.Any())
                {
                    try
                    {

                        foreach (var doc in docs)
                        {
                            results = UpdatePeriodicBalance(doc.Periode,
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
                                Info =doc.Info,
                                TypeJournal=doc.TypeJournal,
                                CostCenterId=doc.CostCenterId,
                                ModelId = modelId
                            },
                            new Journal {
                                ItemID =doc.ItemID,
                                OID =doc.OID,
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
                                Info=doc.Info,
                                TypeJournal=doc.TypeJournal,
                                CostCenterId=doc.CostCenterId,
                                ModelId = modelId
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
                                        g.Key.Periode,
                                        accountID = g.Key.OAccount,
                                        amount = g.Sum(p => p.doc.Amount),
                                        currency = g.Key.Currency
                                    }).Single();
                        results = UpdatePeriodicBalance(item.Periode, item.accountID, item.amount, item.currency, false, companyId);

                        if (!results)
                            return results;
                        results = UpdateAccountBalance(item.accountID, item.amount, false, companyId);

                        if (!results)
                            return results;
                    }
                    catch (Exception ex)
                    {
                        IWSLookUp.LogException(ex);
                        return false;
                    }
                }
                return results;
            }
            if (modelId.Equals((int)IWSLookUp.ComptaMasterModelId.Settlement))
            {
                results = false;
                iban = db.MasterComptas.Join(db.Customers,
                        m => m.account, c => c.accountid, (m, c) => new
                        {
                            iban = c.IBAN,
                            itemId = m.id,
                            CompanyId = c.CompanyID
                        }).FirstOrDefault(d =>
                        d.CompanyId.Equals(companyId) && d.itemId.Equals(itemId)).iban;

                List<JournalViewModel> docs = (from l in db.DetailComptas
                                               where
                                                 l.MasterCompta.id == itemId
                                               select new JournalViewModel()
                                               {
                                                   ItemID = l.MasterCompta.id,
                                                   OID = l.MasterCompta.oid,
                                                   Currency = l.MasterCompta.oCurrency,
                                                   CustSupplierID = l.MasterCompta.account,
                                                   StoreID = l.MasterCompta.CostCenter,
                                                   TransDate = l.MasterCompta.TransDate,
                                                   Itemdate = l.MasterCompta.ItemDate,
                                                   EntryDate = l.MasterCompta.EntryDate,
                                                   Periode = l.MasterCompta.oPeriode,
                                                   Amount = l.amount,
                                                   Account = l.account,
                                                   OAccount = l.oaccount,
                                                   CompanyIBAN = l.MasterCompta.Company.IBAN ?? "NA",
                                                   IBAN = iban,
                                                   Info = l.MasterCompta.HeaderText,
                                                   TypeJournal = l.MasterCompta.TypeJournal,
                                                   CostCenterId = l.MasterCompta.CostCenter,
                                                   ModelId = modelId
                                               }).Distinct().ToList();

                if (docs.Any())
                {
                    try
                    {

                        foreach (var doc in docs)
                        {
                            results = UpdatePeriodicBalance(doc.Periode,
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
                                Info =doc.Info,
                                TypeJournal=doc.TypeJournal,
                                CostCenterId=doc.CostCenterId,
                                ModelId = modelId
                            },
                            new Journal {
                                ItemID =doc.ItemID,
                                OID =doc.OID,
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
                                Info=doc.Info,
                                TypeJournal=doc.TypeJournal,
                                CostCenterId=doc.CostCenterId,
                                ModelId = modelId
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
                                        g.Key.Periode,
                                        accountID = g.Key.OAccount,
                                        amount = g.Sum(p => p.doc.Amount),
                                        currency = g.Key.Currency
                                    }).Single();
                        results = UpdatePeriodicBalance(item.Periode, item.accountID, item.amount, item.currency, false, companyId);

                        if (!results)
                            return results;

                        results = UpdateAccountBalance(item.accountID, item.amount, false, companyId);

                        if (!results)
                            return results;
                    }
                    catch (Exception ex)
                    {
                        IWSLookUp.LogException(ex);
                        return false;
                    }
                }
                return results;
            }
            if (modelId.Equals((int)IWSLookUp.ComptaMasterModelId.GeneralLedger))
            {

                List<JournalViewModel> docs = (from l in db.DetailComptas
                                               where
                                                 l.MasterCompta.id == itemId
                                               select new JournalViewModel()
                                               {
                                                   ItemID = l.MasterCompta.id,
                                                   OID = l.MasterCompta.oid,
                                                   Currency = l.MasterCompta.oCurrency,
                                                   CustSupplierID = l.MasterCompta.CompanyId,
                                                   StoreID = l.MasterCompta.CostCenter,
                                                   TransDate = l.MasterCompta.TransDate,
                                                   Itemdate = l.MasterCompta.ItemDate,
                                                   EntryDate = l.MasterCompta.EntryDate,
                                                   Periode = l.MasterCompta.oPeriode,
                                                   Amount = l.amount,
                                                   Account = l.account,
                                                   OAccount = l.oaccount,
                                                   CompanyIBAN = l.MasterCompta.Company.IBAN ?? "NA",
                                                   IBAN = l.MasterCompta.Company.IBAN ?? "NA",
                                                   Info = l.MasterCompta.HeaderText,
                                                   TypeJournal = l.MasterCompta.TypeJournal,
                                                   CostCenterId = l.MasterCompta.CostCenter,
                                                   ModelId = modelId
                                               }).Distinct().ToList();

                if (docs.Any())
                {
                    try
                    {

                        foreach (var doc in docs)
                        {
                            results = UpdatePeriodicBalance(doc.Periode,
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
                                Info =doc.Info,
                                TypeJournal=doc.TypeJournal,
                                CostCenterId=doc.CostCenterId,
                                ModelId = modelId
                            },
                            new Journal {
                                ItemID =doc.ItemID,
                                OID =doc.OID,
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
                                Info=doc.Info,
                                TypeJournal=doc.TypeJournal,
                                CostCenterId=doc.CostCenterId,
                                ModelId = modelId
                            }
                        };

                            results = SendToJournal(journal);

                            if (!results)
                                return results;
                        }

                        var items = (from doc in docs
                                     group new { doc } by new
                                     {
                                         doc.Periode,
                                         doc.OAccount,
                                         doc.Currency
                                     } into g
                                     select new
                                     {
                                         g.Key.Periode,
                                         accountID = g.Key.OAccount,
                                         amount = g.Sum(p => p.doc.Amount),
                                         currency = g.Key.Currency
                                     });
                        foreach (var item in items)
                        {

                            results = UpdatePeriodicBalance(item.Periode, item.accountID, item.amount, item.currency, false, companyId);

                            if (!results)
                                return results;

                            results = UpdateAccountBalance(item.accountID, item.amount, false, companyId);

                            if (!results)
                                return results;
                        }
                    }
                    catch (Exception ex)
                    {
                        IWSLookUp.LogException(ex);
                        return false;
                    }
                }
                return results;

            }
            return results;
        }
        protected static bool Account(int ItemID, string ItemType, string companyId)
        {
            IWSLookUp.DocsType docsType = GetDocType(ItemType);
            bool results = IWSLookUp.CheckPeriod(ItemID, docsType, companyId, true, true);
            if (!results)
            {
                string msg = IWSLocalResource.CheckPeriod;
                throw new Exception(msg);
            }
            //bool results;
            //if (ItemType.Equals(IWSLookUp.DocsType.GoodReceiving.ToString()))
            //{
            //    return ValidateGoodReceiving(ItemID, companyId);
            //}
            //if (ItemType.Equals(IWSLookUp.DocsType.BillOfDelivery.ToString()))
            //{
            //    return ValidateBillOfDelivery(ItemID, companyId);
            //}
            //if (ItemType.Equals(IWSLookUp.DocsType.VendorInvoice.ToString()))
            //{
            //    return ValidateVendorInvoice(ItemID, companyId);
            //}
            //if (ItemType.Equals(IWSLookUp.DocsType.CustomerInvoice.ToString()))
            //{
            //    return ValidateCustmerInvoice(ItemID, companyId);
            //}
            //if (ItemType.Equals(IWSLookUp.DocsType.Payment.ToString()))
            //{
            //    return ValidatePayment(ItemID, companyId);
            //}
            //if (ItemType.Equals(IWSLookUp.DocsType.Settlement.ToString()))
            //{
            //    return ValidateSettlement(ItemID, companyId);
            //}
            //if (ItemType.Equals(IWSLookUp.DocsType.GeneralLedger.ToString()))
            //{
            //    return ValidateGeneralLedger(ItemID, companyId);
            //}
            return true;
        }
        #endregion

        protected static string GetItemType(string ItemType)
        {
            return db.Localizations.Where(i => i.LocalName == ItemType)
                                                .Select(i => i.ItemName)
                                                .FirstOrDefault();
        }

        protected static IWSLookUp.DocsType GetDocType(string ItemType)
        {
            if (ItemType.Equals(IWSLookUp.DocsType.PurchaseOrder.ToString()))
                return IWSLookUp.DocsType.PurchaseOrder;
            if (ItemType.Equals(IWSLookUp.DocsType.GoodReceiving.ToString()))
                return IWSLookUp.DocsType.GoodReceiving;
            if (ItemType.Equals(IWSLookUp.DocsType.InventoryInvoice.ToString()))
                return IWSLookUp.DocsType.InventoryInvoice;
            if (ItemType.Equals(IWSLookUp.DocsType.SalesOrder.ToString()))
                return IWSLookUp.DocsType.SalesOrder;
            if (ItemType.Equals(IWSLookUp.DocsType.BillOfDelivery.ToString()))
                return IWSLookUp.DocsType.BillOfDelivery;
            if (ItemType.Equals(IWSLookUp.DocsType.SalesInvoice.ToString()))
                return IWSLookUp.DocsType.SalesInvoice;
            if (ItemType.Equals(IWSLookUp.DocsType.PurchaseOrder.ToString()))
                return IWSLookUp.DocsType.PurchaseOrder;
            if (ItemType.Equals(IWSLookUp.DocsType.VendorInvoice.ToString()))
                return IWSLookUp.DocsType.VendorInvoice;
            if (ItemType.Equals(IWSLookUp.DocsType.CustomerInvoice.ToString()))
                return IWSLookUp.DocsType.CustomerInvoice;
            if (ItemType.Equals(IWSLookUp.DocsType.Payment.ToString()))
                return IWSLookUp.DocsType.Payment;
            if (ItemType.Equals(IWSLookUp.DocsType.Settlement.ToString()))
                return IWSLookUp.DocsType.Settlement;
            if (ItemType.Equals(IWSLookUp.DocsType.GeneralLedgerOut.ToString()) ||
                ItemType.Equals(IWSLookUp.DocsType.GeneralLedgerIn.ToString()) ||
                ItemType.Equals(IWSLookUp.DocsType.GeneralLedger.ToString()))
                return IWSLookUp.DocsType.GeneralLedgerOut;
            return IWSLookUp.DocsType.Default;
        }

        protected static bool UpdateEntryDate(int DocumentID, IWSLookUp.DocsType DocumentType, string CompanyId)
        {
            bool results = false;
            try
            {
                results = IWSLookUp.CheckPeriod(DocumentID, DocumentType, CompanyId, true, true);

                if (!results)
                {

                    throw new Exception(IWSLocalResource.CheckPeriod);
                }
                if (DocumentType.Equals(IWSLookUp.DocsType.PurchaseOrder))
                {
                    var docs = db.PurchaseOrders.Single(item => item.id == DocumentID);
                    if (!docs.Equals(null))
                    {
                        docs.EntryDate = DateTime.Today;
                        results = true;
                    }
                }
                if (DocumentType.Equals(IWSLookUp.DocsType.SalesOrder))
                {
                    var docs = db.SalesOrders.Single(item => item.id == DocumentID);
                    if (!docs.Equals(null))
                    {
                        docs.EntryDate = DateTime.Today;
                        results = true;
                    }
                }
                if (DocumentType.Equals(IWSLookUp.DocsType.GoodReceiving))
                {
                    var docs = db.GoodReceivings.Single(item => item.id == DocumentID);
                    if (!docs.Equals(null))
                    {
                        docs.EntryDate = DateTime.Today;
                        results = true;
                    }
                }
                if (DocumentType.Equals(IWSLookUp.DocsType.BillOfDelivery))
                {
                    var docs = db.BillOfDeliveries.Single(item => item.id == DocumentID);
                    if (!docs.Equals(null))
                    {
                        docs.EntryDate = DateTime.Today;
                        results = true;
                    }
                }
                if (DocumentType.Equals(IWSLookUp.DocsType.InventoryInvoice))
                {
                    var docs = db.InventoryInvoices.Single(item => item.id == DocumentID);
                    if (!docs.Equals(null))
                    {
                        docs.EntryDate = DateTime.Today;
                        results = true;
                    }
                }
                if (DocumentType.Equals(IWSLookUp.DocsType.CustomerInvoice))
                {
                    var docs = db.CustomerInvoices.Single(item => item.id == DocumentID);
                    if (!docs.Equals(null))
                    {
                        docs.EntryDate = DateTime.Today;
                        results = true;
                    }
                }
                if (DocumentType.Equals(IWSLookUp.DocsType.VendorInvoice))
                {
                    var docs = db.VendorInvoices.Single(item => item.id == DocumentID);
                    if (!docs.Equals(null))
                    {
                        docs.EntryDate = DateTime.Today;
                        results = true;
                    }
                }
                if (DocumentType.Equals(IWSLookUp.DocsType.SalesInvoice))
                {
                    var docs = db.SalesInvoices.Single(item => item.id == DocumentID);
                    if (!docs.Equals(null))
                    {
                        docs.EntryDate = DateTime.Today;
                        results = true;
                    }
                }
                if (DocumentType.Equals(IWSLookUp.DocsType.Payment))
                {
                    var docs = db.Payments.Single(item => item.id == DocumentID);
                    if (!docs.Equals(null))
                    {
                        docs.EntryDate = DateTime.Today;
                        results = true;
                    }
                }
                if (DocumentType.Equals(IWSLookUp.DocsType.Settlement))
                {
                    var docs = db.Settlements.Single(item => item.id == DocumentID);
                    if (!docs.Equals(null))
                    {
                        docs.EntryDate = DateTime.Today;
                        results = true;
                    }
                }
                if (DocumentType.Equals(IWSLookUp.DocsType.GeneralLedger))
                {
                    var docs = db.GeneralLedgers.Single(item => item.id == DocumentID);
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
                //ViewData["GenericError"] = ex.Message;
                IWSLookUp.LogException(ex);
                results = false;
            }
            return results;
        }
        protected static bool UpdateStock(int itemId, IWSLookUp.DocsType DocumentType, string CompanyId)
        {
            try
            {
                bool results = IWSLookUp.CheckPeriod(itemId, DocumentType, CompanyId, true, true);
                if (!results)
                {
                    string msg = IWSLocalResource.CheckPeriod;
                    throw new Exception(msg);
                }
                if (DocumentType.Equals(IWSLookUp.DocsType.BillOfDelivery))
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
                     where g.Key.DocumentID == itemId
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
                if (DocumentType.Equals(IWSLookUp.DocsType.GoodReceiving))
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
                 where g.Key.DocumentID == itemId
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
            }
            catch (Exception ex)
            {
                //ViewData["GenericError"] = ex.Message;
                IWSLookUp.LogException(ex);
                return false;
            }
            return true;
        }
        protected static bool ValidateBillOfDelivery(List<JournalViewModel> docs, string companyId)
        {
            bool results = false;
            try
            {

                foreach (var doc in docs)
                {

                    results = UpdatePeriodicBalance(doc.Periode, doc.Account, doc.Amount, doc.Currency, true, companyId);

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
                                doc.Account,
                                doc.Currency
                            } into g
                            select new
                            {
                                g.Key.Periode,
                                accountID = g.Key.Account,
                                amount = g.Sum(p => p.doc.Amount),
                                currency = g.Key.Currency
                            }).Single();

                results = UpdatePeriodicBalance(item.Periode, item.accountID, item.amount, item.currency, false, companyId);

                if (!results)
                    return results;

                results = UpdateAccountBalance(item.accountID, item.amount, false, companyId);

                if (!results)
                    return results;
            }
            catch (Exception ex)
            {
                IWSLookUp.LogException(ex);
                return false;
            }
            return results;
        }
        protected static bool ValidateGoodReceiving(int itemId, string companyId)
        {
            string iban = db.MasterLogistics.Join(db.Suppliers,         //goodreceiving
                               v => v.account, s => s.id, (v, s) => new
                               {
                                   iban = s.IBAN,
                                   itemId = v.id,
                                   CompanyId = s.CompanyID
                               }).FirstOrDefault(d =>
                               d.CompanyId.Equals(companyId) && d.itemId.Equals(itemId)).iban;
            //string iban = db.MasterLogistics.Join(db.Customers,         //billofdelivey
            //       v => v.account, s => s.id, (v, s) => new
            //       {
            //           iban = s.IBAN,
            //           itemId = v.id,
            //           CompanyId = s.CompanyID
            //       }).FirstOrDefault(d =>
            //       d.CompanyId.Equals(companyId) && d.itemId.Equals(itemId)).iban;

            List<JournalViewModel> docs = (from o in (
                (from i in db.DetailLogistics
                 select new
                 {
                     i.MasterLogistic.id,
                     i.MasterLogistic.oid,
                     i.MasterLogistic.account,
                     i.MasterLogistic.store,
                     i.MasterLogistic.TransDate,
                     i.MasterLogistic.ItemDate,
                     i.MasterLogistic.EntryDate,
                     i.MasterLogistic.oPeriode,
                     i.Article.StockAccount,
                     i.MasterLogistic.Company.purchasingclearingaccountid,
                     sAmount = i.lineNet,
                     i.MasterLogistic.Company.IBAN,
                     IBAN2 = iban,
                     i.MasterLogistic.oCurrency,
                     i.MasterLogistic.HeaderText
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
                    where g.Key.id == itemId
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
                        IBAN = g.Key.IBAN2.ToString(),
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

                        results = UpdatePeriodicBalance(doc.Periode, doc.Account, doc.Amount, doc.Currency, true, companyId);

                        if (!results)
                            return results;

                        results = UpdateAccountBalance(doc.Account, doc.Amount, true, companyId);

                        if (!results)
                            return results;

                        List<Journal> journal = new List<Journal> {
                            new Journal {
                                ItemID =doc.ItemID,
                                OID =doc.OID,
                                ItemType = IWSLookUp.LogisticMasterModelId.GoodReceiving.ToString(),
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
                                ItemType = IWSLookUp.LogisticMasterModelId.GoodReceiving.ToString(),
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
                                    g.Key.Periode,
                                    accountID = g.Key.OAccount,
                                    amount = g.Sum(p => p.doc.Amount),
                                    currency = g.Key.Currency
                                }).Single();
                    results = UpdatePeriodicBalance(item.Periode, item.accountID, item.amount, item.currency, false, companyId);

                    if (!results)
                        return results;

                    results = UpdateAccountBalance(item.accountID, item.amount, false, companyId);

                    if (!results)
                        return results;
                }
                catch (Exception ex)
                {
                    IWSLookUp.LogException(ex);
                    return false;
                }
            }
            return results;
        }
        protected static bool ValidateBillOfDelivery(int ItemID, string companyId)
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
                        l.BillOfDelivery.Customer.IBAN,
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
        protected static bool ValidateVendorInvoice(int ItemID, string companyId)
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
                                               Info = l.VendorInvoice.HeaderText,
                                               TypeJournal = l.VendorInvoice.TypeJournal,
                                               CostCenterId = l.VendorInvoice.CostCenter
                                           }).Distinct().ToList();

            bool results = false;

            if (docs.Any())
            {
                try
                {

                    foreach (var doc in docs)
                    {
                        results = UpdatePeriodicBalance(doc.Periode,
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
                                Info =doc.Info,
                                TypeJournal=doc.TypeJournal,
                                CostCenterId=doc.CostCenterId
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
                                Info=doc.Info,
                                TypeJournal=doc.TypeJournal,
                                CostCenterId=doc.CostCenterId
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
                    results = UpdatePeriodicBalance(item.Periode, item.accountID, item.amount, item.currency, false, companyId);

                    if (!results)
                        return results;

                    results = UpdateAccountBalance(item.accountID, item.amount, false, companyId);

                    if (!results)
                        return results;
                }
                catch (Exception ex)
                {
                    //ViewData["GenericError"] = ex.Message;
                    IWSLookUp.LogException(ex);
                    return false;
                }
            }
            return results;
        }
        protected static bool ValidateCustmerInvoice(int ItemID, string companyId)
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
                                               Info = l.CustomerInvoice.HeaderText,
                                               TypeJournal = l.CustomerInvoice.TypeJournal,
                                               CostCenterId = l.CustomerInvoice.CostCenter
                                           }).Distinct().ToList();
            bool results = false;

            if (docs.Any())
            {
                try
                {

                    foreach (var doc in docs)
                    {

                        results = UpdatePeriodicBalance(doc.Periode, doc.OAccount, doc.Amount, doc.Currency, false, companyId);

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
                                Info =doc.Info,
                                TypeJournal=doc.TypeJournal,
                                CostCenterId=doc.CostCenterId
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
                                Info=doc.Info,
                                TypeJournal=doc.TypeJournal,
                                CostCenterId=doc.CostCenterId
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
                    results = UpdatePeriodicBalance(item.Periode, item.accountID, item.amount, item.currency, true, companyId);

                    if (!results)
                        return results;

                    results = UpdateAccountBalance(item.accountID, item.amount, true, companyId);

                    if (!results)
                        return results;
                }
                catch (Exception ex)
                {
                    //ViewData["GenericError"] = ex.Message;
                    IWSLookUp.LogException(ex);
                    return false;
                }
            }
            return results;
        }
        protected static bool ValidatePayment(int ItemID, string companyId)
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
                                               IBAN = l.Payment.Supplier.IBAN ?? "NA",
                                               Info = l.Payment.HeaderText,
                                               TypeJournal = l.Payment.TypeJournal,
                                               CostCenterId = l.Payment.CostCenter
                                           }).Distinct().ToList();

            bool results = false;

            if (docs.Any())
            {
                try
                {

                    foreach (var doc in docs)
                    {
                        results = UpdatePeriodicBalance(doc.Periode,
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
                                Info =doc.Info,
                                TypeJournal=doc.TypeJournal,
                                CostCenterId=doc.CostCenterId
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
                                Info=doc.Info,
                                TypeJournal=doc.TypeJournal,
                                CostCenterId=doc.CostCenterId
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
                    results = UpdatePeriodicBalance(item.Periode, item.accountID, item.amount, item.currency, false, companyId);

                    if (!results)
                        return results;

                    results = UpdateAccountBalance(item.accountID, item.amount, false, companyId);

                    if (!results)
                        return results;

                }
                catch (Exception ex)
                {
                    //ViewData["GenericError"] = ex.Message;
                    IWSLookUp.LogException(ex);
                    return false;
                }
            }
            return results;
        }
        protected static bool ValidateSettlement(int ItemID, string companyId)
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
                                               Info = l.Settlement.HeaderText,
                                               TypeJournal = l.Settlement.TypeJournal,
                                               CostCenterId = l.Settlement.CostCenter
                                           }).Distinct().ToList();
            bool results = false;

            if (docs.Any())
            {
                try
                {

                    foreach (var doc in docs)
                    {
                        results = UpdatePeriodicBalance(doc.Periode,
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
                                Info =doc.Info,
                                TypeJournal=doc.TypeJournal,
                                CostCenterId=doc.CostCenterId
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
                                Info=doc.Info,
                                TypeJournal=doc.TypeJournal,
                                CostCenterId=doc.CostCenterId
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
                    results = UpdatePeriodicBalance(item.Periode, item.accountID, item.amount, item.currency, false, companyId);

                    if (!results)
                        return results;

                    results = UpdateAccountBalance(item.accountID, item.amount, false, companyId);

                    if (!results)
                        return results;
                }
                catch (Exception ex)
                {
                    //ViewData["GenericError"] = ex.Message;
                    IWSLookUp.LogException(ex);
                    return false;
                }
            }
            return results;
        }
        protected static bool ValidateGeneralLedger(int ItemID, string companyId)
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
                                               Info = l.GeneralLedger.HeaderText,
                                               TypeJournal = l.GeneralLedger.TypeJournal,
                                               CostCenterId = l.GeneralLedger.CostCenter
                                           }).Distinct().ToList();

            bool results = false;

            if (docs.Any())
            {
                try
                {

                    foreach (var doc in docs)
                    {
                        results = UpdatePeriodicBalance(doc.Periode,
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
                                Info =doc.Info,
                                TypeJournal=doc.TypeJournal,
                                CostCenterId=doc.CostCenterId
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
                                Info=doc.Info,
                                TypeJournal=doc.TypeJournal,
                                CostCenterId=doc.CostCenterId
                            }
                        };

                        results = SendToJournal(journal);

                        if (!results)
                            return results;
                    }

                    var items = (from doc in docs
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
                                 });
                    foreach (var item in items)
                    {

                        results = UpdatePeriodicBalance(item.Periode, item.accountID, item.amount, item.currency, false, companyId);

                        if (!results)
                            return results;

                        results = UpdateAccountBalance(item.accountID, item.amount, false, companyId);

                        if (!results)
                            return results;
                    }
                }
                catch (Exception ex)
                {
                    //ViewData["GenericError"] = ex.Message;
                    IWSLookUp.LogException(ex);
                    return false;
                }
            }
            return results;
        }
        protected static bool SendToJournal(List<Journal> journal)
        {
        bool results = false;
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
            IWSLookUp.LogException(ex);
            results = false;
        }
        return results;
        }
        protected static bool UpdateAccountBalance(string accountID, decimal amount, bool isDebit, string companyId)
        {
            try
            {
                if (!isDebit)
                {
                    amount = -amount;
                }
                var docs = db.Accounts.FirstOrDefault(a => a.id == accountID && a.CompanyID == companyId);
                if (docs != null)
                {
                    docs.balance += amount;
                    return true;
                }
            }
            catch (Exception ex)
            {
                //ViewData["GenericError"] = ex.Message;
                IWSLookUp.LogException(ex);
            }
            return false;
        }
        protected static bool UpdatePeriodicBalance(string Periode, string AccountID, decimal amount,
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
                    //ViewData["GenericError"] = ex.Message;
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
                    //ViewData["GenericError"] = ex.Message;
                    IWSLookUp.LogException(ex);
                    return false;
                }
            }
        }
      
        protected static bool Validate(int ItemID, string ItemType, string companyId)
        {
            try
            {
                IWSLookUp.DocsType docsType = GetDocType(ItemType);
                bool results = IWSLookUp.CheckPeriod(ItemID, docsType, companyId, true, true);
                if (!results)
                {
                    string msg = IWSLocalResource.CheckPeriod;
                    throw new Exception(msg);
                }

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
                //ViewData["GenericError"] = ex.Message;
                IWSLookUp.LogException(ex);
            }
            return false;
        }

        protected static void ProcessData(string selectedItems, string companyId, bool convertType, int modelId)
        {
            string msg;
            int itemId;
            bool results = false;

            IList<string> items = new List<string>(selectedItems.Split(new string[] { ";" }, StringSplitOptions.None));

            foreach (string item in items)
            {
                try
                {
                    var list = item.Split(new string[] { "," }, StringSplitOptions.None);

                    itemId = Convert.ToInt32(list[0]);

                    //results = IWSLookUp.CheckPeriod(itemId, DocumentType, CompanyId, true, true);

                    //if (!results)
                    //{
                    //    string msg = IWSLocalResource.CheckPeriod;
                    //    throw new Exception(msg);
                    //}

                    results = UpdateEntryDate(itemId, modelId);
                    if (!results)
                    {
                        msg = IWSLocalResource.GenericError;
                        throw new Exception(msg);
                    }
                    results = UpdateStock(itemId, modelId, companyId);
                    if (!results)
                    {
                        msg = IWSLocalResource.GenericError;
                        throw new Exception(msg);
                    }
                    results = ValidateMasters(itemId, modelId, companyId);
                    if (!results)
                    {
                        msg = IWSLocalResource.GenericError;
                        throw new Exception(msg);
                    }
                    results = Validate(itemId, modelId);
                    
                    if (!results)
                    {
                        msg = IWSLocalResource.GenericError;
                        throw new Exception(msg);
                    }
                    db.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
                }
                catch (Exception ex)
                {
                    IWSLookUp.LogException(ex);
                }
            }
        }

        protected static string SetDocType(string selectedItems, string docType)
        {

            string[] items = selectedItems.Split(new string[] { ";" },
                                        StringSplitOptions.RemoveEmptyEntries);

            items = items.Select(x => x + "," + docType).ToArray();

            return String.Join(";", items);
        }
    }
}