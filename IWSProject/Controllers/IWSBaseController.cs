using IWSProject.Content;
using IWSProject.Models;
using IWSProject.Models.Entities;
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
                        if (validateStock.Any(i => i.IsService.Equals(false)))
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
            string iban = string.Empty;

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
                        Info = l.MasterLogistic.HeaderText ?? "NA"
                    }).Distinct().ToList();
                if (docs.Any())
                {
                    results = ValidateBillOfDelivery(docs, companyId);
                }
                if (!results)
                    return results;
                docs = (from l in db.DetailLogistics
                        where
                            (l.Article.IsService == false)
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
                        Info = g.Key.HeaderText ?? "NA",
                        ModelId = modelId
                    }).Distinct().ToList();                

                if (docs.Any())
                {
                    try
                    {
                        #region debit
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
                        #endregion
                        #region credit
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
                                     }).Distinct().ToList();
                        foreach (var item in items)
                        {
                        results = UpdatePeriodicBalance(item.Periode, item.accountID, item.amount, item.currency, false, companyId);

                        if (!results)
                            return results;

                        results = UpdateAccountBalance(item.accountID, item.amount, false, companyId);

                        if (!results)
                            return results;

                        }
                        #endregion
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
                                                   Info = l.MasterCompta.HeaderText ?? "NA",
                                                   TypeJournal = l.MasterCompta.TypeJournal,
                                                   CostCenterId = l.MasterCompta.CostCenter,
                                                   ModelId = modelId
                                               }).Distinct().ToList();

                if (docs.Any())
                {
                    try
                    {
                        #region debit

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
                                ItemType = IWSLookUp.ComptaMasterModelId.VendorInvoice.ToString(),
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
                                ItemType = IWSLookUp.ComptaMasterModelId.VendorInvoice.ToString(),
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
                        #endregion
                        #region credit

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
                                    }).Distinct().ToList();

                        foreach (var item in items)
                        {
                            results = UpdatePeriodicBalance(item.Periode, item.accountID, item.amount, item.currency, false, companyId);

                            if (!results)
                                return results;

                            results = UpdateAccountBalance(item.accountID, item.amount, false, companyId);

                            if (!results)
                                return results;
                        }
                        #endregion
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
                                                   ItemType = IWSLookUp.ComptaMasterModelId.CustomerInvoice.ToString(),
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
                                                   Info = l.MasterCompta.HeaderText ?? "NA",
                                                   TypeJournal = l.MasterCompta.TypeJournal,
                                                   CostCenterId = l.MasterCompta.CostCenter,
                                                   ModelId = modelId
                                               }).Distinct().ToList();

                if (docs.Any())
                {
                    try
                    {
                        #region debit
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
                                ItemType = IWSLookUp.ComptaMasterModelId.CustomerInvoice.ToString(),
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
                                ItemType = IWSLookUp.ComptaMasterModelId.CustomerInvoice.ToString(),
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

                        #endregion
                        #region credit

                        var items = (from doc in docs
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
                                     }).Distinct().ToList();
                        foreach (var item in items)
                        {

                        results = UpdatePeriodicBalance(item.Periode, item.accountID, item.amount, item.currency, true, companyId);

                        if (!results)
                            return results;

                        results = UpdateAccountBalance(item.accountID, item.amount, true, companyId);

                        if (!results)
                            return results;
                        }
                        #endregion
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
                                                   ItemType = IWSLookUp.ComptaMasterModelId.Payment.ToString(),
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
                                                   Info = l.MasterCompta.HeaderText ?? "NA",
                                                   TypeJournal = l.MasterCompta.TypeJournal,
                                                   CostCenterId = l.MasterCompta.CostCenter,
                                                   ModelId = modelId
                                               }).Distinct().ToList();

                if (docs.Any())
                {
                    try
                    {
                        #region debit

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
                                ItemType = IWSLookUp.ComptaMasterModelId.Payment.ToString(),
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
                                ItemType = IWSLookUp.ComptaMasterModelId.Payment.ToString(),
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
                        #endregion
                        #region credit

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
                                     }).Distinct().ToList();
                        foreach (var item in items)
                        {

                        results = UpdatePeriodicBalance(item.Periode, item.accountID, item.amount, item.currency, false, companyId);

                        if (!results)
                            return results;
                        results = UpdateAccountBalance(item.accountID, item.amount, false, companyId);

                        if (!results)
                            return results;
                        }
                        #endregion
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
                                                   ItemType = IWSLookUp.ComptaMasterModelId.Settlement.ToString(),
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
                                                   Info = l.MasterCompta.HeaderText ?? "NA",
                                                   TypeJournal = l.MasterCompta.TypeJournal,
                                                   CostCenterId = l.MasterCompta.CostCenter,
                                                   ModelId = modelId
                                               }).Distinct().ToList();

                if (docs.Any())
                {
                    try
                    {
                        #region debit   
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
                                ItemType = IWSLookUp.ComptaMasterModelId.Settlement.ToString(),
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
                                ItemType = IWSLookUp.ComptaMasterModelId.Settlement.ToString(),
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

                        #endregion
                        #region credit
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
                                     }).Distinct().ToList();        //.Single();
                        foreach (var item in items)
                        {
                        results = UpdatePeriodicBalance(item.Periode, item.accountID, item.amount, item.currency, false, companyId);

                        if (!results)
                            return results;

                        results = UpdateAccountBalance(item.accountID, item.amount, false, companyId);

                        if (!results)
                            return results;

                        }

                        #endregion
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
                                                   ItemType = IWSLookUp.ComptaMasterModelId.GeneralLedger.ToString(),
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
                                                   Info = l.MasterCompta.HeaderText ?? "NA",
                                                   TypeJournal = l.MasterCompta.TypeJournal,
                                                   CostCenterId = l.MasterCompta.CostCenter,
                                                   ModelId = modelId
                                               }).Distinct().ToList();

                if (docs.Any())
                {
                    try
                    {
                        #region debit
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
                                ItemType = IWSLookUp.ComptaMasterModelId.GeneralLedger.ToString(),
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
                                ItemType = IWSLookUp.ComptaMasterModelId.GeneralLedger.ToString(),
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

                        #endregion
                        #region credit
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

                        #endregion
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

 
        #endregion


        protected static string GetItemType(string ItemType)
        {
            return db.Localizations.Where(i => i.LocalName == ItemType)
                                                .Select(i => i.ItemName)
                                                .FirstOrDefault();
        }

        protected static bool ValidateBillOfDelivery(List<JournalViewModel> docs, string companyId)
        {
            bool results = false;
            try
            {
                #region debit
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
                                ItemType = IWSLookUp.LogisticMasterModelId.BillOfDelivery.ToString(),
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
                                ItemType = IWSLookUp.LogisticMasterModelId.BillOfDelivery.ToString(),
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

                #endregion
                #region credit


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
                             }).Distinct().ToList();
                foreach (var item in items)
                {
                results = UpdatePeriodicBalance(item.Periode, item.accountID, item.amount, item.currency, false, companyId);

                if (!results)
                    return results;

                results = UpdateAccountBalance(item.accountID, item.amount, false, companyId);

                if (!results)
                    return results;

                }
                #endregion
            }
            catch (Exception ex)
            {
                IWSLookUp.LogException(ex);
                return false;
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
                BeforeAmountViewModel amount = IWSLookUp.GetBeforeAmount(item.Account, item.Periode);
                item.DebitAvantImputationAmount = amount.Debit;
                item.CreditAvantImputationAmount = amount.Credit;
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
                var docs = db.GetAccounts().FirstOrDefault(a => a.id == accountID && a.CompanyID == companyId);
                if (docs != null)
                {
                    docs.balance += amount;
                    return true;
                }
            }
            catch (Exception ex)
            {
                IWSLookUp.LogException(ex);
            }
            return false;
        }
        protected static bool UpdatePeriodicBalance(string Periode, string AccountID, decimal amount,
                                                    string currency, bool IsDebit, string companyID)
        {
            bool result = false;
            var docs = db.PeriodicAccountBalances
                       .FirstOrDefault(p => p.Periode == Periode
                        && p.AccountId == AccountID
                        && p.CompanyID == companyID);
            if (docs == null)
            {
                string name = db.GetAccounts()
                    .Where(a => a.id == AccountID && a.CompanyID == companyID)
                    .Select(n => n.name)
                    .Single();
                decimal iDebit = 0;
                decimal iCredit = 0;

                var initialDebitCredit = (from f in db.FiscalYears
                                          join p in db.PeriodicAccountBalances on new { f.Period } equals new { Period = p.Periode }
                                          where
                                            f.Current == true &&
                                            f.Open == true &&
                                            Convert.ToInt32(p.Periode) < Convert.ToInt32(Periode) &&
                                            p.AccountId == AccountID
                                          orderby
                                            f.Period descending
                                          select new
                                          {
                                              Debit = (p.IDebit + p.Debit),
                                              Credit = (p.ICredit + p.Credit)
                                          }).Take(1);
                if (initialDebitCredit.Count() != 0)
                {
                    iDebit = initialDebitCredit.Select(o => o.Debit).SingleOrDefault();
                    iCredit = initialDebitCredit.Select(o => o.Credit).SingleOrDefault();
                }

                docs = new PeriodicAccountBalance
                {
                    Name = name,
                    Periode = Periode,
                    AccountId = AccountID,
                    CompanyID = companyID,
                    IDebit = iDebit,
                    ICredit = iCredit,
                    Debit = (IsDebit==true) ? amount : 0,
                    Credit = (IsDebit == true) ? 0 : amount,
                    Currency = currency
                };
                try
                {
                    db.PeriodicAccountBalances.InsertOnSubmit(docs);
                    result = true;
                }
                catch (Exception ex)
                {
                    result = false;
                    IWSLookUp.LogException(ex);
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
                    result = true;
                }
                catch (Exception ex)
                {
                    result = false;
                    IWSLookUp.LogException(ex);
                }
            }
            if (result)
                result = UpsertPeriodicBalance(Periode, AccountID, amount, currency, IsDebit, companyID);
            return result;
        }
        public static bool UpsertPeriodicBalance(string period, string AccountID, decimal amount, string currency, bool IsDebit, string companyID)
        {
            bool result = false;

            string nPeriod = GetNextPeriod(period);

            var docs = db.PeriodicAccountBalances
                         .FirstOrDefault(p => p.Periode == nPeriod && p.AccountId == AccountID  && p.CompanyID == companyID);
            if (docs == null)
            {
                string name = db.GetAccounts()
                            .Where(a => a.id == AccountID && a.CompanyID == companyID).Select(n => n.name).Single();

                decimal iDebit = (IsDebit == true) ? amount : 0;
                decimal iCredit = (IsDebit == true) ? 0 : amount;

                var initialDebitCredit = (from f in db.FiscalYears
                                          join p in db.PeriodicAccountBalances on new { f.Period } equals new { Period = p.Periode }
                                          where
                                            f.Current == true &&
                                            f.Open == true &&
                                            Convert.ToInt32(p.Periode) < Convert.ToInt32(period) &&
                                            p.AccountId == AccountID
                                          orderby
                                            f.Period descending
                                          select new
                                          {
                                              Debit = (p.IDebit + p.Debit),
                                              Credit = (p.ICredit + p.Credit)
                                          }).Take(1);
                if (initialDebitCredit.Count() !=0)
                { 
                    iDebit +=  initialDebitCredit.Select(o => o.Debit).SingleOrDefault();  
                    iCredit += initialDebitCredit.Select(o => o.Credit).SingleOrDefault(); 
                }
                docs = new PeriodicAccountBalance
                {
                    Name = name,
                    Periode = nPeriod,
                    AccountId = AccountID,
                    CompanyID = companyID,
                    IDebit = iDebit,    
                    ICredit = iCredit,  
                    Currency = currency
                };
                try
                {
                    db.PeriodicAccountBalances.InsertOnSubmit(docs);
                    result = true;
                }
                catch (Exception ex)
                {
                    result = false;
                    IWSLookUp.LogException(ex);
                }
            }
            else
            {
                try
                {
                    result = UpdateNextPeriod(AccountID, period, amount, IsDebit, companyID);
                    result = true;
                }
                catch (Exception ex)
                {
                    result = false;
                    IWSLookUp.LogException(ex);
                }
            }
            return result;
        }
        protected static bool UpdateNextPeriod(string accountId, string period, decimal amount, bool IsDebit, string companyID)
        {
            bool result = false;

            var balance =
                from p in db.PeriodicAccountBalances
                where
                  p.AccountId == accountId && p.CompanyID == companyID &&
                  Convert.ToInt32(p.Periode) > Convert.ToInt32(period)
                select p;
            try
            {
                foreach (var b in balance)
                {
                    if (IsDebit)
                    b.IDebit = (b.IDebit + amount);
                    if (!IsDebit)
                    b.ICredit = (b.ICredit + amount);
                }
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                IWSLookUp.LogException(ex);
            }
            return result;
        }
        private static string GetNextPeriod(string period)
        {
            DateTime nextPeriod;
            string p=String.Empty;
            string nextMonth = String.Empty;
            int iYear = Convert.ToInt32(period.Substring(0,4));
            int iMonth = Convert.ToInt32(period.Substring(4,2));
            if (iMonth == 12)
            {
                nextPeriod = new DateTime(iYear + 1, 1, 1);
            }
            else
            {
                nextPeriod = new DateTime(iYear, iMonth + 1, 1);
            }
            nextMonth = (nextPeriod.Month < 10) ? "0" + nextPeriod.Month : nextPeriod.Month.ToString();
            p = nextPeriod.Year.ToString() + nextMonth;
            return p;
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
                    #region check period
                    //results = IWSLookUp.CheckPeriod(itemId, DocumentType, CompanyId, true, true);

                    //if (!results)
                    //{
                    //    string msg = IWSLocalResource.CheckPeriod;
                    //    throw new Exception(msg);
                    //}

                    #endregion
                    if (IWSLookUp.CkeckIfAmountsBalanced(itemId) !=0)
                    {
                        msg = IWSLocalResource.BalancedAmount;
                        throw new Exception(msg);
                    }
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
    }
}