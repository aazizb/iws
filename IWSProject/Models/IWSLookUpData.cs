namespace IWSProject.Models
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Web;

    public static class IWSLookUp
    {

        const string IWSDataContext = "IWSDataContext";
       
        public static IWSDataContext IWSEntities
        {

            get
            {
                if (HttpContext.Current.Items[IWSDataContext] == null)
                    HttpContext.Current.Items[IWSDataContext] = new IWSDataContext();

                return (IWSDataContext)HttpContext.Current.Items[IWSDataContext];
            }
        }
        public static IEnumerable GetIBAN()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            var account = IWSEntities.BankAccounts.AsEnumerable().Select(i => new
            {
                Id = i.IBAN,
                Name = i.Owner,
                 i.CompanyID,
            })
            .Where(c => c.CompanyID == companyID)
            .OrderBy(o => o.Id);
            return account;
        }

        public static IEnumerable GetBIC()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            var account = IWSEntities.Banks.AsEnumerable().Select(i => new
            {
                Id = i.id,
                Name = i.name,
                 i.CompanyID,
            })
            .Where(c => c.CompanyID == companyID)
            .OrderBy(o => o.Id);
            return account;
        }
        public static bool IsBalance(string accountId)
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            return IWSEntities.Companies.Any(c =>
                                    c.BalanceSheet == accountId && c.id == companyID);
        }

        public static bool CheckPeriod(int DocumentID, DocsType DocumentType, string CompanyId, bool Current, bool Open)
        {
            var vf = IWSEntities.FiscalYears.Where(e => IWSEntities.MasterLogistics.
                                Any(x => e.Period == x.oPeriode && x.id == DocumentID)).Any();
            return true;
            #region testing period

            //    if (DocsType.PurchaseOrder.Equals(DocumentType))
            //        return IWSEntities.FiscalYears.Where(e => IWSEntities.PurchaseOrders.
            //    Any(x => e.Period == x.oPeriode && x.id == DocumentID)).Any();
            //    if (DocsType.GoodReceiving.Equals(DocumentType))
            //        return IWSEntities.FiscalYears.Where(e => IWSEntities.GoodReceivings.
            //    Any(x => e.Period == x.oPeriode && x.id == DocumentID)).Any();
            //    if (DocsType.InventoryInvoice.Equals(DocumentType))
            //        return IWSEntities.FiscalYears.Where(e => IWSEntities.InventoryInvoices.
            //    Any(x => e.Period == x.oPeriode && x.id == DocumentID)).Any();
            //    if (DocsType.SalesOrder.Equals(DocumentType))
            //        return IWSEntities.FiscalYears.Where(e => IWSEntities.SalesOrders.
            //    Any(x => e.Period == x.oPeriode && x.id == DocumentID)).Any();
            //    if (DocsType.BillOfDelivery.Equals(DocumentType))
            //        return IWSEntities.FiscalYears.Where(e => IWSEntities.BillOfDeliveries.
            //    Any(x => e.Period == x.oPeriode && x.id == DocumentID)).Any();
            //    if (DocsType.SalesInvoice.Equals(DocumentType))
            //        return IWSEntities.FiscalYears.Where(e => IWSEntities.SalesInvoices.
            //    Any(x => e.Period == x.oPeriode && x.id == DocumentID)).Any();
            //    if (DocsType.VendorInvoice.Equals(DocumentType))
            //        return IWSEntities.FiscalYears.Where(e => IWSEntities.VendorInvoices.
            //    Any(x => e.Period == x.oPeriode && x.id == DocumentID)).Any();
            //    if (DocsType.CustomerInvoice.Equals(DocumentType))
            //        return IWSEntities.FiscalYears.Where(e => IWSEntities.CustomerInvoices.
            //Any(x => e.Period == x.oPeriode && x.id == DocumentID)).Any();
            //    if (DocsType.Payment.Equals(DocumentType))
            //        return IWSEntities.FiscalYears.Where(e => IWSEntities.Payments.
            //Any(x => e.Period == x.oPeriode && x.id == DocumentID)).Any();
            //    if (DocsType.Settlement.Equals(DocumentType))
            //        return IWSEntities.FiscalYears.Where(e => IWSEntities.Settlements.
            //Any(x => e.Period == x.oPeriode && x.id == DocumentID)).Any();
            //    if (DocsType.GeneralLedger.Equals(DocumentType))
            //        return IWSEntities.FiscalYears.Where(e => IWSEntities.GeneralLedgers.
            //Any(x => e.Period == x.oPeriode && x.id == DocumentID)).Any();
            //    return false;
            #endregion
        }
        public static bool CheckPeriod(DateTime TransDate, string CompanyId, bool Current, bool Open)
        {
            return true;
            #region testing period

            //string periode = TransDate.Month < 10 ? '0' + Convert.ToString(TransDate.Month) : Convert.ToString(TransDate.Month);
            //periode = Convert.ToString(TransDate.Year) + periode;

            //return IWSEntities.FiscalYears.Where(x => x.Period
            //                .Contains(periode) && x.Current == Current && x.Open == Open &&
            //                x.CompanyId == CompanyId).Any();
            #endregion
        }

        public static IEnumerable GetAccount()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            return IWSEntities.Accounts.Where(c => c.CompanyID == companyID);
        }
        /// <summary>
        /// Retourne le compte tier connaissant tier
        /// </summary>
        /// <param name="account">Tier</param>
        /// <param name="transType">Doc type</param>
        /// <returns>Compte tier</returns>
        public static string GetCompteTier(string account, string transType)
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];

            transType = transType.ToLower();

            if (transType.Equals("payment") || transType.Equals("vendorinvoice"))
            {
                return IWSEntities.Suppliers.SingleOrDefault(i => i.id == account &&
                                                                i.CompanyID.Equals(companyID)).accountid;
            }
            if (transType.Equals("settlement") || transType.Equals("customerinvoice"))
            {
                return IWSEntities.Customers.SingleOrDefault(i => i.id == account &&
                                                                    i.CompanyID.Equals(companyID)).accountid;
            }
            return null;
        }

        public static IEnumerable GetAccount(string TransType)
        {
            string accountid = String.Empty;
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            if (TransType.Equals("SettlementBank") || TransType.Equals("PaymentBank"))
            {
                accountid = IWSEntities.Companies.SingleOrDefault(i => i.id == companyID).ClassBank;
            }
            if (TransType.Equals("SettlementCash") || TransType.Equals("PaymentCash"))
            {
                accountid = IWSEntities.Companies.SingleOrDefault(i => i.id == companyID).ClassCash;
            }
            return IWSEntities.ClassChild(accountid, companyID).Select(i => 
                                                new { id = i.ChildId, name = i.ChildName });
        }

        public static IEnumerable GetAccounts()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            var account = IWSEntities.Accounts.AsEnumerable().Select(i => new
            {
                Id = i.id,
                Name = i.name,
                 i.CompanyID,
                 i.IsUsed
            })
            .Where(c => c.CompanyID == companyID
                            && c.IsUsed.Equals(true))
            .OrderBy(o => o.Name);
            return account;
        }
        public static IEnumerable GetBankChildren()
        {
            string companyId = (string)HttpContext.Current.Session["CompanyID"];

            string companyBank = IWSEntities.Companies
                .SingleOrDefault(company => company.id == companyId).ClassBank;

            var bankChildren = IWSEntities.GetChildren(companyBank, companyId).AsEnumerable().Select(i => new
            {
                Id = i.id
            });

            return from b in bankChildren
                   from a in IWSEntities.Accounts
                   orderby a.name
                   where
                     b.Id == a.id
                   select new
                   {
                       b.Id,
                       a.name
                   } ;
        }
        public static IEnumerable GetAccount(string account, string transType)
        {
            string accountid = String.Empty;
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            transType = transType.ToLower();
            if (transType.Equals("paymentcash") || transType.Equals("paymentbank") || 
                            transType.Equals("vendorinvoice") || transType.Equals("payment"))
            {
                accountid = IWSEntities.Suppliers.SingleOrDefault(i => i.id == account).accountid;
            }
            if (transType.Equals("settlementcash") || transType.Equals("settlementbank") || 
                            transType.Equals("customerinvoice") || transType.Equals("settlement"))
            {
                accountid = IWSEntities.Customers.SingleOrDefault(i => i.id == account).accountid;
            }
            return IWSEntities.ClassChildren(accountid, companyID).Select(i => new { Id = i.id, Name = i.name });
        }
        public static IEnumerable GetTypeJournal() => IWSEntities.TypeJournals.Where(c =>
                c.CompanyId == (string)HttpContext.Current.Session["CompanyID"]).
                Select(s => new {  s.Id, s.Name }).
                OrderBy(o => o.Id).AsEnumerable();
        public static IEnumerable GetSuppliersAccount()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];

            return IWSEntities.Suppliers.Join(IWSEntities.Accounts,
                                                       c => c.accountid, a => a.id, (c, a) => new
                                                       {
                                                           Id = c.accountid,
                                                           Name = a.name,
                                                           CompanyId = a.CompanyID
                                                       }).Where(x => x.CompanyId.Equals(companyID));
        }
        public static IEnumerable GetCustomersAccount()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];

            return IWSEntities.Customers.Join(IWSEntities.Accounts,
                                                       c => c.accountid, a => a.id, (c, a) => new
                                                       {
                                                           Id = c.accountid,
                                                           Name = a.name,
                                                           CompanyId = a.CompanyID
                                                       }).Where(x => x.CompanyId.Equals(companyID));
        }
        public static bool SetTypeJournal(string Itemtype, int TransId)
        {
            int result = -1;
            string companyId = (string)HttpContext.Current.Session["CompanyID"];
            result = IWSEntities.SetTypeJournal(Itemtype, TransId, companyId);
            if (result >= 0)
                return true;
            return false;
        }
        public static bool SetJournal(int transId)
        {
            string companyId = (string)HttpContext.Current.Session["CompanyID"];
            return (IWSEntities.SetJournal( transId, companyId) >= 0);
        }
        public static IEnumerable GetTypeJournals() => IWSEntities.TypeJournals.Where(c =>
                c.CompanyId == (string)HttpContext.Current.Session["CompanyID"]).
               AsEnumerable();

        public static string GetTypeJournal(int id, string ItemType)
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            if (ItemType.Equals(DocsType.VendorInvoice.ToString()))
            {
                return IWSEntities.GoodReceivings.Join(IWSEntities.Suppliers, v => v.account, s => s.id,
                                        (v, s) => new
                                        {
                                            v,
                                            s
                                        }).Join(IWSEntities.Accounts, vs => vs.s.accountid, a => a.id,
                                        (vs, a) => new
                                        {
                                            Id = vs.v.id,
                                             vs.s.CompanyID,
                                             a.TypeJournal
                                        }).Where(x => x.CompanyID.Equals(companyID) && x.Id.Equals(id)).SingleOrDefault().TypeJournal;
            }
            if (ItemType.Equals(DocsType.CustomerInvoice.ToString()))
            {
                return IWSEntities.SalesInvoices.Join(IWSEntities.Customers, s => s.account, c => c.id,
                                        (s, c) => new
                                        {
                                            s,
                                            c
                                        }).Join(IWSEntities.Accounts, sc => sc.c.accountid, a => a.id,
                                        (sc, a) => new
                                        {
                                            Id = sc.s.id,
                                             sc.c.CompanyID,
                                             a.TypeJournal
                                        }).Where(x => x.CompanyID.Equals(companyID) && x.Id.Equals(id)).SingleOrDefault().TypeJournal;
            }
            if (ItemType.Equals(DocsType.Payment.ToString()))
            {
                return IWSEntities.VendorInvoices.FirstOrDefault(c =>
                                         c.id == id && c.CompanyId == companyID).TypeJournal;
            }
            if (ItemType.Equals(DocsType.Settlement.ToString()))
            {
                return IWSEntities.CustomerInvoices.FirstOrDefault(c =>
                                         c.id == id && c.CompanyId == companyID).TypeJournal;
            }
            return null;
        }
        public static string GetTypeJournal(string ItemType , int TransId) //does nothing yet
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];

            return null;

        }

        public static IEnumerable GetPackUnits()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            var account = IWSEntities.QuantityUnits.AsEnumerable().Select(i => new
            {
                Id = i.id,
                Name = i.name,
                 i.CompanyID
            })
            .Where(c => c.CompanyID == companyID)
            .OrderBy(o => o.Id);
            return account;
        }

        public static string GetAccount(int id, string ItemType)
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            if (ItemType.Equals(DocsType.CustomerInvoice.ToString()))
            {
                return IWSEntities.SalesInvoices.Join(IWSEntities.Customers,
                               v => v.account, s => s.id, (v, s) => new
                               {
                                   AccountId = s.accountid,
                                   InvoiceId = v.id,
                                   CompanyId = s.CompanyID
                               }).FirstOrDefault(d =>
                               d.CompanyId.Equals(companyID) && d.InvoiceId.Equals(id)).AccountId;
            }
            if (ItemType.Equals(DocsType.VendorInvoice.ToString()))
            {
                return IWSEntities.InventoryInvoices.Join(IWSEntities.Suppliers,
                               v => v.account, s => s.id, (v, s) => new
                               {
                                   AccountId = s.accountid,
                                   InvoiceId = v.id,
                                   CompanyId = s.CompanyID
                               }).FirstOrDefault(d =>
                               d.CompanyId.Equals(companyID) && d.InvoiceId.Equals(id)).AccountId;
            }
            if (ItemType.Equals(DocsType.Payment.ToString()))
            {
                return IWSEntities.VendorInvoices.FirstOrDefault(v =>
                                           v.CompanyId.Equals(companyID) && v.id.Equals(id)).AccountingAccount;
            }
            if (ItemType.Equals(DocsType.Settlement.ToString()))
            {
                return IWSEntities.CustomerInvoices.FirstOrDefault(v =>
                                           v.CompanyId.Equals(companyID) && v.id.Equals(id)).AccountingAccount;
            }
            return null;
        }

        /// <summary>
        /// Compte à débiter cas paiement
        /// </summary>
        /// <param name="bankStatementId">Bank Statement ID</param>
        /// <returns>N° de compte</returns>
        public static string GetPaymentDebitAcount(int bankStatementId)    
        {
            BankStatement bankStatement = IWSEntities.BankStatements
                                .FirstOrDefault(bs => bs.id == bankStatementId);

            var account = from s in IWSEntities.Suppliers
                          from b in IWSEntities.BankAccounts
                          where
                            s.id == b.Owner &&
                            b.IBAN == bankStatement.Kontonummer
                          select new
                          {
                              s.accountid
                          };

            return account.Single().accountid;

        }
        /// <summary>
        /// Compte à créditer cas paiement
        /// </summary>
        /// <param name="bankStatementId">Bank Statement ID</param>
        /// <returns>N° de compte</returns>
        public static string GetPaymentCreditAcount(int bankStatementId)
        {
            BankStatement bankStatement = IWSEntities.BankStatements
                                .FirstOrDefault(bs => bs.id == bankStatementId);
            #region Modification du 05/06/2018
            //var account = from s in IWSEntities.Companies
            //              from b in IWSEntities.BankAccounts
            //              where
            //                s.id == b.Owner &&
            //                b.IBAN == bankStatement.CompanyIBAN
            //              select new
            //              {
            //                  s.bankaccountid
            //              };
            #endregion
            var account = from b in IWSEntities.BankAccounts
                          where
                            b.IBAN == bankStatement.CompanyIBAN
                          select new
                          {
                              b.Account
                          };

            return account.Single().Account;

        }
        /// <summary>
        /// Compte à débiter cas encaissement
        /// </summary>
        /// <param name="bankStatementId">Bank Statement ID</param>
        /// <returns>N° de compte</returns>
        public static string GetSettlementDebitAcount(int bankStatementId)
        {
            BankStatement bankStatement = IWSEntities.BankStatements
                                .FirstOrDefault(bs => bs.id == bankStatementId);
            #region Modification du 05/06/2018

            //var account = from c in IWSEntities.Companies
            //              from b in IWSEntities.BankAccounts
            //              where
            //                c.id == b.Owner &&
            //                b.IBAN == bankStatement.CompanyIBAN
            //              select new
            //              {
            //                  c.bankaccountid
            //              };
            #endregion
            var account = from b in IWSEntities.BankAccounts
                          where
                            b.IBAN == bankStatement.CompanyIBAN
                          select new
                          {
                              b.Account
                          };
            return account.Single().Account;

        }
        /// <summary>
        /// Compte à créditer cas encaissement
        /// </summary>
        /// <param name="bankStatementId">Bank Statement ID</param>
        /// <returns>N° de compte</returns>
        public static string GetSettlementCreditAcount(int bankStatementId)
        {
            BankStatement bankStatement = IWSEntities.BankStatements
                                .FirstOrDefault(bs => bs.id == bankStatementId);

            var account = from c in IWSEntities.Customers
                          from b in IWSEntities.BankAccounts
                          where
                            c.id == b.Owner &&
                            b.IBAN == bankStatement.Kontonummer
                          select new
                          {
                              c.accountid
                          };

            return account.Single().accountid;

        }

        public static IEnumerable GetArticle()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            var article = IWSEntities.Articles.AsEnumerable().Select(item => new
            {
                Id = item.id,
                Name = item.name,
                Price = item.price,
                Unit = item.qttyunit,
                Pack = item.packunit,
                Vat = item.VatCode,
                item.CompanyID
            }).
            Where(c => c.CompanyID == companyID).
            OrderBy(o => o.Name);
            return article;
        }

        public static IEnumerable GetMasterLogistic(LogisticMasterModelId modelId) => IWSEntities.MasterLogistics.Where(c =>
                                c.CompanyId == (string)HttpContext.Current.Session["CompanyID"] &&
                                c.ModelId == (int)modelId).
                                OrderByDescending(o => o.id).AsEnumerable();
        public static IEnumerable GetMasterCompta(ComptaMasterModelId modelId) => IWSEntities.MasterComptas.Where(c =>
                        c.CompanyId == (string)HttpContext.Current.Session["CompanyID"] &&
                        c.ModelId == (int)modelId).
                        OrderByDescending(o => o.id).AsEnumerable();

        public static IEnumerable GetDetailLogistic(int transId) => IWSEntities.DetailLogistics.Where(c =>
                                c.transid == transId).
                                OrderByDescending(o => o.id).AsEnumerable();
        public static IEnumerable GetDetailCompta(int transId) => IWSEntities.DetailComptas.Where(c =>
                          c.transid == transId).
                          OrderByDescending(o => o.id).AsEnumerable();

        public static IEnumerable GetMasterLogisticOID()
        {
            int modelId = (int)HttpContext.Current.Session["ModelId"];

            string companyId = (string)HttpContext.Current.Session["CompanyID"];

            if (modelId.Equals((int)LogisticMasterModelId.GoodReceiving))
            {
                return
                from store in IWSEntities.Stores
                join master in IWSEntities.MasterLogistics on new { store.id } equals new { id = master.store }
                join supplier in IWSEntities.Suppliers on new { master.account } equals new { account = supplier.id }
                where
                  master.CompanyId == companyId &&
                  master.ModelId == (int)LogisticMasterModelId.PurchaseOrder
                orderby
                  master.id
                select new
                {
                    ID = master.id,
                    Name = supplier.name,
                    Store = store.name,
                    DueDate = master.ItemDate.ToShortDateString()
                };
            }
            if (modelId.Equals((int)LogisticMasterModelId.InventoryInvoice))
            {
                return
                from store in IWSEntities.Stores
                join master in IWSEntities.MasterLogistics on new { store.id } equals new { id = master.store }
                join supplier in IWSEntities.Suppliers on new { master.account } equals new { account = supplier.id }
                where
                  master.CompanyId == companyId &&
                  master.ModelId == (int)LogisticMasterModelId.GoodReceiving
                orderby
                  master.id
                select new
                {
                    ID = master.id,
                    Name = supplier.name,
                    Store = store.name,
                    DueDate = master.ItemDate.ToShortDateString()
                };
            }
            if (modelId.Equals((int)LogisticMasterModelId.BillOfDelivery))
            {
                return
                from store in IWSEntities.Stores
                join master in IWSEntities.MasterLogistics on new { store.id } equals new { id = master.store }
                join customer in IWSEntities.Customers on new { master.account } equals new { account = customer.id }
                where
                  master.CompanyId == companyId &&
                  master.ModelId == (int)LogisticMasterModelId.SalesOrder
                orderby
                  master.id
                select new
                {
                    ID = master.id,
                    Name = customer.name,
                    Store = store.name,
                    DueDate = master.ItemDate.ToShortDateString()
                };
            }
            if (modelId.Equals((int)LogisticMasterModelId.SalesInvoice))
            {
                return
                from store in IWSEntities.Stores
                join master in IWSEntities.MasterLogistics on new { store.id } equals new { id = master.store }
                join customer in IWSEntities.Customers on new { master.account } equals new { account = customer.id }
                where
                  master.CompanyId == companyId &&
                  master.ModelId == (int)LogisticMasterModelId.BillOfDelivery
                orderby
                  master.id
                select new
                {
                    ID = master.id,
                    Name = customer.name,
                    Store = store.name,
                    DueDate = master.ItemDate.ToShortDateString()
                };
            }
            return null;
        }
        public static IEnumerable GetMasterComptaOID()
        {
            int modelId = (int)HttpContext.Current.Session["ModelId"];

            string companyId = (string)HttpContext.Current.Session["CompanyID"];

            if (modelId.Equals((int)ComptaMasterModelId.VendorInvoice))
            {
               return from store in IWSEntities.Stores
                join master in IWSEntities.MasterLogistics on new { store.id } equals new { id = master.store }
                join supplier in IWSEntities.Suppliers on new { master.account } equals new { account = supplier.id }
                where
                  master.CompanyId == companyId &&
                  master.ModelId == (int)LogisticMasterModelId.InventoryInvoice
                orderby
                  master.id
                select new
                {
                    ID = master.id,
                    Name = supplier.name,
                    Store = store.name,
                    DueDate = master.ItemDate.ToShortDateString()
                };
            }
            if (modelId.Equals((int)ComptaMasterModelId.Payment))
            {
                return from center in IWSEntities.CostCenters
                join master in IWSEntities.MasterComptas on new { center.id } equals new { id = master.CostCenter }
                join account in IWSEntities.Accounts on new { master.account } equals new { account = account.id }
                where
                  master.CompanyId == companyId &&
                  master.ModelId == (int)ComptaMasterModelId.VendorInvoice
                orderby
                  master.id
                select new
                {
                    ID = master.id,
                    Name = account.name,
                    Store = center.name,
                    DueDate = master.ItemDate.ToShortDateString()
                };
            }
            if (modelId.Equals((int)ComptaMasterModelId.CustomerInvoice))
            {
                return
                from store in IWSEntities.Stores
                join master in IWSEntities.MasterLogistics on new { store.id } equals new { id = master.store }
                join customer in IWSEntities.Customers on new { master.account } equals new { account = customer.id }
                where
                  master.CompanyId == companyId &&
                  master.ModelId == (int)LogisticMasterModelId.SalesInvoice
                orderby
                  master.id
                select new
                {
                    ID = master.id,
                    Name = customer.name,
                    Store = store.name,
                    DueDate = master.ItemDate.ToShortDateString()
                };
            }
            if (modelId.Equals((int)ComptaMasterModelId.Settlement))
            {
                return from center in IWSEntities.CostCenters
                join master in IWSEntities.MasterComptas on new { center.id } equals new { id = master.CostCenter }
                join account in IWSEntities.Accounts on new { master.account } equals new { account = account.id }
                where
                  master.CompanyId == companyId &&
                  master.ModelId == (int)ComptaMasterModelId.CustomerInvoice
                orderby
                  master.id
                select new
                {
                    ID = master.id,
                    Name = account.name,
                    Store = center.name,
                    DueDate = master.ItemDate.ToShortDateString()
                };
            }
            return null;
        }

        public static IEnumerable GetNewLineDetailLogistic(int itemId, int OID, int modelId)
        {
            List<DetailLogistic> docs = new List<DetailLogistic>();
            docs = IWSEntities.DetailLogistics.Where(c => c.transid.Equals(OID)).ToList();

            List<DetailLogistic> items =
                (from o in docs
                 where o.transid == OID
                 select new DetailLogistic()
                 {
                     transid = itemId,
                     item = o.item,
                     unit = o.unit,
                     price = o.price,
                     quantity = o.quantity,
                     Vat = o.Vat,
                     duedate = o.duedate,
                     text = o.text,
                     Currency = o.Currency,
                     ModelId = modelId
                 }).ToList();
            return items;
        }
        public static IEnumerable GetNewLineDetailCompta(int itemId, int OID, int modelId)
        {
            string companyId = (string)HttpContext.Current.Session["CompanyID"];

            List<DebitViewModel> debit = new List<DebitViewModel>();

            List<CreditViewModel> credit = new List<CreditViewModel>();

            IList<DetailCompta> lines = new List<DetailCompta>();

            string account = GetAccount(OID, modelId);

            if (modelId.Equals((int)ComptaMasterModelId.CustomerInvoice) ||
                modelId.Equals((int)ComptaMasterModelId.VendorInvoice))
            {
                credit = new List<CreditViewModel>
                        ((from l in IWSEntities.DetailLogistics
                          where
                                l.transid == OID &&
                                l.Article.CompanyID == companyId &&
                                l.Article.Vat.CompanyID == companyId
                          select new CreditViewModel()
                          {
                                OCreditVAT = l.Article.Vat.outputvataccountid,
                                OCreditTotal = l.Article.Vat.revenueaccountid
                          }).Distinct());
            }
            if (modelId.Equals((int)ComptaMasterModelId.Payment) ||
                modelId.Equals((int)ComptaMasterModelId.Settlement))
            {
                credit = new List<CreditViewModel>
                    ((from l in IWSEntities.MasterComptas
                      where
                        l.id == OID
                      select new CreditViewModel()
                      {
                          OCreditTotal = l.Company.bankaccountid
                      }).Distinct());
            }
            if (modelId.Equals((int)ComptaMasterModelId.Settlement))
            {
                debit = new List<DebitViewModel>
                        (from l in IWSEntities.DetailComptas
                         group l by new
                         {
                             l.transid, l.account, l.side, l.duedate, l.Currency, l.text
                         } into g
                         where g.Key.transid == OID
                         select new DebitViewModel()
                         {
                             TransID = g.Key.transid, ODebit = g.Key.account, Side = !g.Key.side,
                             OVat = (decimal?)g.Sum(p => p.amount), ItemDate = g.Key.duedate,
                             Currency = g.Key.Currency, HeaderText = g.Key.text
                         });
                lines = new List<DetailCompta>() {
                        new DetailCompta(){
                            transid =itemId, account=credit.Single().OCreditTotal, side=debit.Single().Side, oaccount=debit.Single().ODebit,
                            amount=(decimal)debit.Single().OVat, duedate=debit.Single().ItemDate, text=debit.Single().HeaderText,
                            Currency=debit.Single().Currency}
                     };
            }
            if (modelId.Equals((int)ComptaMasterModelId.VendorInvoice))
            {
                debit = new List<DebitViewModel>
                    (from l in IWSEntities.MasterLogistics
                     where
                       l.CompanyId == companyId &&
                       l.id == OID
                     select new DebitViewModel()
                     {
                         TransID = itemId, ODebit = account, OCredit = l.Company.purchasingclearingaccountid,
                         Side = false, HeaderText = l.HeaderText,
                         ItemDate = l.ItemDate, OVat = l.oVat,
                         OTotal = l.oTotal, Currency = l.oCurrency
                     });
            }
            if (modelId.Equals((int)ComptaMasterModelId.CustomerInvoice))
            {
                debit = new List<DebitViewModel>
               (from l in IWSEntities.MasterLogistics
                where
                   l.CompanyId == companyId &&
                   l.id == OID
                select new DebitViewModel()
                {
                    TransID = itemId, ODebit = account, OCredit = l.Company.salesclearingaccountid,
                    Side = false, HeaderText = l.HeaderText, ItemDate = l.ItemDate,
                    OVat = l.oVat, OTotal = l.oTotal, Currency = l.oCurrency
                });
            }
            if (modelId.Equals((int)ComptaMasterModelId.Payment))
            {
                debit = new List<DebitViewModel>
                        (from l in IWSEntities.MasterComptas
                         where
                           l.id == OID
                         select new DebitViewModel()
                         {
                             TransID = itemId, ODebit = account, Side = true,
                             OTotal = l.oTotal, ItemDate = l.ItemDate,
                             HeaderText = l.HeaderText, Currency = l.oCurrency,
                         });
            }
            if (modelId.Equals((int)ComptaMasterModelId.CustomerInvoice) ||
                modelId.Equals((int)ComptaMasterModelId.VendorInvoice))
            {
                lines = new List<DetailCompta>() {
                    new DetailCompta(){
                        transid =itemId, account=debit.Single().ODebit, side=debit.Single().Side, oaccount=credit.Single().OCreditVAT,
                        amount=(decimal)debit.Single().OVat, duedate=debit.Single().ItemDate, text=debit.Single().HeaderText,
                        Currency=debit.Single().Currency},
                    new DetailCompta(){
                        transid =itemId, account=debit.Single().ODebit, side=debit.Single().Side, oaccount=debit.Single().OCredit,
                        amount=(decimal)debit.Single().OTotal, duedate=debit.Single().ItemDate, text=debit.Single().HeaderText,
                        Currency=debit.Single().Currency}
                    };
            }
            if (modelId.Equals((int)ComptaMasterModelId.Payment))
            {
                lines = new List<DetailCompta>()
                {
                        new DetailCompta()
                        {
                            transid =itemId, account=debit.Single().ODebit, side=debit.Single().Side, oaccount=credit.Single().OCreditTotal,
                            amount=(decimal)debit.Single().OTotal, duedate=debit.Single().ItemDate, text=debit.Single().HeaderText,
                            Currency=debit.Single().Currency
                        }
                };
            }
            return lines;
        }

        public static IEnumerable GetGoodReceiving()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            var b = from o in IWSEntities.GoodReceivings
                    where o.CompanyId == companyID
                    orderby o.id descending
                    select o;
            return b;
        }
        public static IEnumerable GetInventoryInvoice()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            var b = from o in IWSEntities.InventoryInvoices
                    where o.CompanyId == companyID
                    orderby o.id descending
                    select o;
            return b;
        }
        public static IEnumerable GetPurchaseOrder()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            var b = from o in IWSEntities.PurchaseOrders
                    where o.CompanyId == companyID
                    orderby o.id descending
                    select o;
            return b;
        }
        public static IEnumerable GetBillOfDelivery()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            var b = from o in IWSEntities.BillOfDeliveries
                    where o.CompanyId == companyID
                    orderby o.id descending
                    select o;
            return b;
        }
        public static IEnumerable GetSalesInvoice()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            var b = from o in IWSEntities.SalesInvoices
                    where o.CompanyId == companyID
                    orderby o.id descending
                    select o;
            return b;
        }
        public static IEnumerable GetSalesOrder()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            var b = from o in IWSEntities.SalesOrders
                    where o.CompanyId == companyID
                    orderby o.id descending
                    select o;
            return b;
        }
        public static IEnumerable CloseCurrentFiscalYear(string companyId)=> 
                            IWSEntities.CloseFiscalYear(companyId).Where(c=>
                                c.CompanyID == companyId).AsEnumerable();

        public static void OpenNewFiscalYear(string startMonth, string endMonth,
                            string companyId, bool isCurrent, bool isOpen) =>
            IWSEntities.OpenFiscalYear(startMonth, endMonth, companyId, isCurrent, isOpen);

        public static IEnumerable GetBrouillardType() => IWSEntities.TypeBrouillards.
                Where(c => c.UICulture == Thread.CurrentThread.CurrentUICulture.Name).
                 Select(s => new { s.ItemID, s.Name });

        public static IEnumerable GetCurrentFiscalYear(string companyId)
        {

            var b = from f in IWSEntities.PeriodicAccountBalances
                    where
                      f.CompanyID == companyId &&
                        (from FiscalYears in IWSEntities.FiscalYears
                         where
                            FiscalYears.CompanyId == companyId &&
                            FiscalYears.Current == true &&
                            FiscalYears.Open == true
                         select new
                         {
                             FiscalYears.Period
                         }).Contains(new { Period = f.Periode })
                    select new
                    {
                        f.Id,
                        f.AccountId,
                        f.Name,
                        f.Periode,
                        f.oYear,
                        f.oMonth,
                        f.Debit,
                        f.Credit,
                        f.InitialBalance,
                        f.FinalBalance,
                        f.Currency,
                        f.CompanyID
                    };
                   return b;
        }

        public static IEnumerable GetFiscalYears(string companyId) => IWSEntities.GetFiscalYears(companyId).
                    Where(c => c.CompanyId == companyId).
                    Select(f => new
                    {
                        f.CompanyId,f.CStart,f.CEnd, f.OStart, f.OEnd
                    }).ToList();

        public static IEnumerable GetCash() => IWSEntities.Cashes.Where(c =>
                        c.CompanyId == (string)HttpContext.Current.Session["CompanyID"]).
                        OrderByDescending(o => o.Id).AsEnumerable();

        public static IEnumerable GetAffectationJournal() => IWSEntities.AffectationJournals.Where(c =>
                c.CompanyID == (string)HttpContext.Current.Session["CompanyID"]).
                OrderByDescending(o => o.TypeJournalID).AsEnumerable();

        public static Cash GetCash(int cashId) => IWSEntities.Cashes.Where(c => c.Id == cashId).SingleOrDefault();

        public static List<CashLine> GetCashLines(int transId) => IWSEntities.CashLines.Where(c =>
                        c.TransId == transId).ToList();

        public static IEnumerable GetBrouillard() => IWSEntities.Brouillards.Where(b =>
                        b.CompanyId == (string)HttpContext.Current.Session["CompanyID"]).
                        OrderByDescending(o => o.Id).AsEnumerable();

        public static Brouillard GetBrouillard(int brouillardId) => IWSEntities.Brouillards.Where(b =>
                                        b.Id == brouillardId).SingleOrDefault();

        public static List<BrouillardViewModel> GetBrouillard(string TypeDoc, string NumPiece, string CompanyId, int ItemId)
        {
            List<BrouillardViewModel> d = (from b in IWSEntities.GetBrouillard(TypeDoc, NumPiece, CompanyId, ItemId)
                                             select new BrouillardViewModel()
                                             {
                                                 OID=Convert.ToInt16(b.NumPiece),
                                                 Account = b.Owner,
                                                 TransDate = Convert.ToDateTime(b.Period),
                                                 ItemDate= Convert.ToDateTime(b.Period),
                                                 DueDate=Convert.ToDateTime(b.Period),
                                                 EntryDate=DateTime.Now,
                                                 AccountID = b.AccountID,
                                                 Side= Convert.ToBoolean(b.Side),
                                                 OAccountID = b.OAccountID,
                                                 HeaderText = b.HeaderText,
                                                 Amount= Convert.ToDecimal(b.Amount),
                                                 Currency = b.Currency,
                                                 CompanyId = b.CompanyId,
                                             }).ToList();
            return d;
        }
            
        public static IEnumerable GetCustomerInvoice()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            var b = from o in IWSEntities.CustomerInvoices
                    where o.CompanyId == companyID
                    orderby o.id descending
                    select o;
            return b;
        }
        public static IEnumerable GetVendorInvoice()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            var b = from o in IWSEntities.VendorInvoices
                    where o.CompanyId == companyID
                    orderby o.id descending
                    select o;
            return b;
        }

        public static IEnumerable GetPayment()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            var b = from o in IWSEntities.Payments
                    where o.CompanyId == companyID
                    orderby o.id descending
                    select o;
            return b;
        }
        public static IEnumerable GetSettlement()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            var b = from o in IWSEntities.Settlements
                    where o.CompanyId == companyID
                    orderby o.id descending
                    select o;
            return b;
        }
        public static IEnumerable GetGeneralLedger() => IWSEntities.GeneralLedgers.Where(c =>
         c.CompanyId == (string)HttpContext.Current.Session["CompanyID"]).
        OrderByDescending(o => o.id).AsEnumerable();

        public static OwnerViewModel GetOwnerType(string IBAN)
        {
            try
            {
                OwnerViewModel customer = (from c in IWSEntities.Customers
                               where
                                 c.id ==
                                   ((from b in IWSEntities.BankAccounts
                                     where
                                         b.IBAN == IBAN
                                     select new
                                     {
                                         b.Owner
                                     }).First().Owner)
                               select new OwnerViewModel()
                               {
                                   ID = c.id,
                                   OwnerType = "Customer"
                               }).SingleOrDefault();
                if (customer != null)
                    return customer;
                OwnerViewModel supplier = (from c in IWSEntities.Suppliers
                                where
                                    c.id ==
                                    ((from b in IWSEntities.BankAccounts
                                        where
                                            b.IBAN == IBAN
                                        select new
                                        {
                                            b.Owner
                                        }).First().Owner)
                                select new OwnerViewModel()
                                {
                                    ID = c.id,
                                    OwnerType = "Supplier"
                                }).SingleOrDefault();
                if (supplier != null)
                    return supplier;
                OwnerViewModel company = (from c in IWSEntities.Companies
                                where
                                c.id ==
                                    ((from b in IWSEntities.BankAccounts
                                    where
                                        b.IBAN == IBAN
                                    select new
                                    {
                                        b.Owner
                                    }).First().Owner)
                                select new OwnerViewModel()
                                {
                                    ID = c.id,
                                    OwnerType = "Company"
                                }).SingleOrDefault();
                if (company != null)
                    return company;
            }
            catch (Exception ex)
            {
                IWSLookUp.LogException(ex);
            }
            return null;
        }   


        public static List<LinePayment> GetLinePayment(int TransId)
        {
            return IWSEntities.LinePayments.Where(i => i.transid == TransId).ToList();
        }

        public static IEnumerable GetCustSuppliers()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            var owner =     (from co in IWSEntities.Companies
            where
              (co.id == companyID)
            select new
            {
                Id = co.id,
                Name = co.name
            }
            ).Union
            (
            from cu in IWSEntities.Customers
            where
              (cu.CompanyID == companyID)
            select new
            {
                Id = cu.id,
                Name = cu.name
            }
            ).Union
            (
            from su in IWSEntities.Suppliers
            where
              (su.CompanyID == companyID)
            select new
            {
                Id = su.id,
                Name = su.name
            }
            )
            .OrderBy(p => p.Name);
            return owner;
        }

        public static IEnumerable GetCustomer()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            var b = from o in IWSEntities.Customers
                    where o.CompanyID == companyID
                    select o;
            return b;
        }
        public static IEnumerable GetSupplier()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            var b = from o in IWSEntities.Suppliers
                    where o.CompanyID == companyID
                    select o;
            return b;
        }
        public static IEnumerable GetCompany()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            var b = from o in IWSEntities.Companies
                    where o.id == companyID
                    select o;
            return b;
        }
        public static IEnumerable GetCostCenter()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            return IWSEntities.CostCenters.Where(c => c.CompanyID == companyID);
        }
        public static IEnumerable GetBanks()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            return IWSEntities.Banks.Where(c => c.CompanyID == companyID);
        }
        public static IEnumerable GetAccountAmounts(int bankStatementId)
        {
            const char comma = ',';
            const char space = ' ';
            string results = string.Empty;
            string search = string.Empty;
            int nextPosition = 0;
            int indexAccount = 0;
            int indexAmount = 0;
            int indexComma = 0;
            int countOccurences = 0;

            string usage = IWSEntities.BankStatements.SingleOrDefault(bs =>
                                        bs.id.Equals(bankStatementId)).Verwendungszweck;

            List<LookupAccountAmount> lookupAccountAmount = GetAccountAmount();

            List<AccountAmountViewModel> accountAmount = new List<AccountAmountViewModel>();

            foreach (var item in lookupAccountAmount)
            {
                search = item.AccountName;

                nextPosition = 0;

                countOccurences = CountOccurence(usage, search);

                for (int i = 0; i < countOccurences; i++)
                {
                    indexAccount = usage.IndexOf(search, nextPosition, StringComparison.InvariantCultureIgnoreCase);

                    if (indexAccount > 0)
                    {
                        indexComma = usage.IndexOf(comma, indexAccount);
                        if (indexComma > 0)
                        {
                            indexAmount = usage.LastIndexOf(space, indexComma);

                            if (indexAmount > 0)
                            {
                                var amount = usage.Substring(indexAmount, indexComma - indexAmount + 3);
                                accountAmount.Add(new AccountAmountViewModel
                                {
                                    AccountCode = item.AccountCode,
                                    AccountAmount = StringToDecimal(amount)
                                });
                            }
                        }
                    }
                    nextPosition = indexAccount + 1;
                }
            }
            return accountAmount;
        }

        private static int CountOccurence(string source, string search)
        {
            int count = 0;
            foreach (Match match in Regex.Matches(source, search, RegexOptions.IgnoreCase)) { count++; }
            return count;
        }

        private static List<LookupAccountAmount> GetAccountAmount() => IWSEntities.LookupAccountAmounts.ToList();
            
        public static IEnumerable GetMenus()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            return IWSEntities.Menus.Where(c => c.CompanyID == companyID);
        }
        public static IEnumerable GetQuantityUnits()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            return IWSEntities.QuantityUnits.Where(c => c.CompanyID == companyID);
        }
        public static IEnumerable GetStores()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            return IWSEntities.Stores.Where(c => c.CompanyID == companyID);
        }
        public static IEnumerable GetArticles()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            return IWSEntities.Articles.Where(c => c.CompanyID == companyID);
        }
        public static IEnumerable GetExceptions()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            return IWSEntities.LogExceptions.Where(c => 
            c.CompanyId == companyID).OrderByDescending(o=>o.LogId);
        }
        public static IEnumerable GetVats()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            return IWSEntities.Vats.Where(c => c.CompanyID == companyID);
        }
        public static IEnumerable GetBankAccount(string Owner)
        {
            return IWSEntities.BankAccounts.Where(o => o.Owner == Owner).AsEnumerable();
        }
        public static IEnumerable GetCompanies()
        {
            var company = IWSEntities.Companies.AsEnumerable().Select(item => new
            {
                Id=item.id,
                Name = item.name
            })
            .OrderBy(o => o.Name)
            .ToList();
            return company;
        }
        public static IEnumerable GetCostCenters()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            var center = IWSEntities.CostCenters.AsEnumerable().Select(item => new
            {
                Id = item.id,
                Name = item.name,
                item.CompanyID
            })
            .Where(c => c.CompanyID == companyID)
            .OrderBy(o => o.Name);
            return center;
        }
        public static IEnumerable GetMenuId()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            var account = IWSEntities.Menus.AsEnumerable().Select(item => new
            {
                Id = item.ID,
                 item.Name,
                 item.CompanyID
            })
            .Where(c => c.CompanyID == companyID)
            .OrderBy(o => o.Name);
            return account;
        }
        public static IEnumerable GetRoles()
        {
            var roleManager = new RoleManager<IdentityRole>(
                                    new RoleStore<IdentityRole>(new ApplicationDbContext()));

            List<IWSRoles> Role = (from role in roleManager.Roles
                                   select new IWSRoles
                                   {
                                       Id = role.Id,
                                       RoleName = role.Name
                                   }).ToList();
            return Role;
        }
        public static IEnumerable GetUsers()
        {
            var userManager = new UserManager<IdentityUser>(
                                    new UserStore<IdentityUser>(new ApplicationDbContext()));
            List<IWSUserModel> User = (from user in userManager.Users
                                       select new IWSUserModel
                                       {
                                            Id = user.Id,
                                            UserName = user.UserName,
                                       }).ToList();
            return User;
        }
        public static IEnumerable GetUserRoles(string userId)
        {
            var UserRoles = IWSEntities.AspNetUserRoles.Where(item => 
                                item.UserId == userId).Select(item => new
                                {
                                     item.UserId, 
                                     item.RoleId
                                    }).ToList();
            return UserRoles;
        }
        public static IEnumerable GetUserRolesModel(string userId)
        {
            List<IWSUseRolesModel> userRoles = IWSEntities.AspNetUserRoles.
                                            Where(u => u.UserId == userId).
                                            Select(x => new IWSUseRolesModel()
                                            {
                                                UserId = x.UserId,
                                                RoleId = x.RoleId
                                            }).ToList();
            return userRoles;
        }
        public static IEnumerable GetStore()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            var store = IWSEntities.Stores.AsEnumerable().Select(item => new
            {
                Id = item.id,
                Name = item.name,
                item.CompanyID
            }).
            Where(c => c.CompanyID == companyID).
            OrderBy(o => o.Name);
            return store;
        }
        public static List<Menu> GetMenu(string CompanyID)
        {
            if (HttpContext.Current.Session["Menus"] == null)
            {
                HttpContext.Current.Session["Menus"] = IWSEntities.Menus
                        .Where(c => c.CompanyID == CompanyID && c.Disable == false)
                        .ToList<Menu>();
            }
            return (List<Menu>)HttpContext.Current.Session["Menus"];
        }
        public static IEnumerable GetSuppliers()        ///string companyId
        {
            string companyId = (string)HttpContext.Current.Session["CompanyID"];

            var supplier = IWSEntities.Suppliers.AsEnumerable().Select(item => new
            {
                Id = item.id,
                Name = item.name,
                Account = item.accountid,
                item.CompanyID
            })
            .Where(c => c.CompanyID == companyId)
            .OrderBy(o => o.Id);
            return supplier;
        }
        public static IEnumerable GetCustomers()        //string companyId
        {
            string companyId = (string)HttpContext.Current.Session["CompanyID"];
            var customer = IWSEntities.Customers.AsEnumerable().Select(item => new
            {
                Id = item.id,
                Name = item.name,
                Account = item.accountid,
                item.CompanyID
            })
            .Where(c => c.CompanyID == companyId)
            .OrderBy(o => o.Id);
            return customer;
        }
        //public static IEnumerable GetSupplierOrCustomer(string isVending)
        //{
        //    string companyId = (string)HttpContext.Current.Session["CompanyID"];
        //    if (isVending == "SU")
        //    {
        //        return GetSuppliers(companyId);
        //    }
        //    if(isVending == "CU")
        //    {
        //        return GetCustomers(companyId);
        //    }
        //    return null;
        //}
        public static IEnumerable GetAccounts(string isVending)
        {

            if (isVending == "SU")
            {
                return GetSuppliers();
            }
            if (isVending == "CU")
            {
                return GetCustomers();
            }
            return null;
        }
        public static IEnumerable GetVAT()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            var vat = IWSEntities.Vats.AsEnumerable().Select(item => new
            {
                Id = item.id,
                Name = item.PVat,
                item.CompanyID
            })
            .Where(c => c.CompanyID == companyID)
            .OrderBy(o => o.Name);
            return vat;
        }
        public static IEnumerable GetCurrency()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            var currency = IWSEntities.Currencies.AsEnumerable().Select(item => new
            {
                 item.Id,
                 item.Name,
                 item.CompanyID
            })
            .Where(c => c.CompanyID == companyID)
            .OrderBy(o => o.Name);
            return currency;
        }
        public static List<Currency> GetCurrencies() => IWSEntities.Currencies.Where(c =>
            c.CompanyID == (string)HttpContext.Current.Session["CompanyID"]).ToList<Currency>();
        public static string GetCurrency(string id)
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            return IWSEntities.Articles.FirstOrDefault(c =>
                   c.id == id && c.CompanyID == companyID).Currency;
        }
        public static string GetCurrencyDefault()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            return IWSEntities.Companies.SingleOrDefault(i => i.id == companyID).Currency;
        }
        public static IEnumerable GetUnit()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            var unit = IWSEntities.QuantityUnits.AsEnumerable().Select(item => new
            {
                Id = item.id,
                Name = item.name,
                 item.CompanyID
            })
            .Where(c => c.CompanyID == companyID)
            .OrderBy(o => o.Name);
            return unit;
        }
        public static InvoiceViewModel GetInvoiceDetail(int itemId, string itemType, string companyId)
        {
            try
            {
                if (itemType.Equals(IWSLookUp.DocsType.CustomerInvoice.ToString()))
                {
                    InvoiceViewModel invoice = (from l in IWSEntities.LineSettlements
                                           join Vats in IWSEntities.Vats on new {  l.Settlement.Customer.VatCode }
                                           equals new { VatCode = Vats.id }
                                           where
                                             l.Settlement.id == itemId &&
                                             l.Settlement.CompanyId == companyId
                                           select new InvoiceViewModel()
                                           {
                                               Account = l.oaccount,
                                               OAccount = l.Settlement.Customer.Produit,
                                               PVat = Vats.PVat,
                                               CostCenter = l.Settlement.CostCenter,
                                               HeaderText = l.Settlement.HeaderText,
                                               TransDate = l.Settlement.TransDate,
                                               ItemDate = l.Settlement.ItemDate,
                                               EntryDate = l.Settlement.EntryDate,
                                               OTotal = l.Settlement.oTotal,
                                               Amount = Math.Round((decimal)l.Settlement.oTotal / (1 + Vats.PVat), 2, MidpointRounding.AwayFromZero),
                                               VatAmount = Math.Round((decimal)l.Settlement.oTotal * Vats.PVat / (1 + Vats.PVat), 2, MidpointRounding.AwayFromZero),
                                               OPeriode = l.Settlement.oPeriode,
                                               OCurrency = l.Settlement.oCurrency,
                                               DueDate = l.duedate,
                                               Text = l.text,
                                               CompanyId = l.Settlement.CompanyId,
                                               AccountId =l.Settlement.account,
                                               VatAccountId = Vats.outputvataccountid
                                           }).Single();
                    return invoice;
                }
                if (itemType.Equals(IWSLookUp.DocsType.VendorInvoice.ToString()))
                {
                    InvoiceViewModel invoice = (from l in IWSEntities.LinePayments
                                            join Vats in IWSEntities.Vats on new {  l.Payment.Supplier.VatCode } 
                                            equals new { VatCode = Vats.id }
                                            where
                                                l.Payment.id == itemId &&
                                                l.Payment.CompanyId == companyId
                                            select new InvoiceViewModel()
                                            {
                                                Account = l.Payment.Supplier.Charge,
                                                OAccount = l.account,
                                                PVat = Vats.PVat,
                                                CostCenter = l.Payment.CostCenter,
                                                HeaderText = l.Payment.HeaderText,
                                                TransDate = l.Payment.TransDate,
                                                ItemDate = l.Payment.ItemDate,
                                                EntryDate = l.Payment.EntryDate,
                                                OTotal = l.Payment.oTotal,
                                                Amount = Math.Round((decimal)l.Payment.oTotal / (1 + Vats.PVat), 2, MidpointRounding.AwayFromZero),
                                                VatAmount = Math.Round((decimal)l.Payment.oTotal * Vats.PVat / (1 + Vats.PVat), 2, MidpointRounding.AwayFromZero),
                                                OPeriode = l.Payment.oPeriode,
                                                OCurrency = l.Payment.oCurrency,
                                                DueDate = l.duedate,
                                                Text = l.text,
                                                CompanyId = l.Payment.CompanyId,
                                                AccountId =l.Payment.account,
                                                VatAccountId = Vats.inputvataccountid
                                            }).Single();
                    return invoice;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }
        public static StatementDetailViewModel GetStatementDetail(int bankStatementId, string itemType, string companyId)
        {
            try
            {
                if (itemType.Equals(IWSLookUp.DocsType.Settlement.ToString()))
                {
                    StatementDetailViewModel sd =
                  (from bs in IWSEntities.BankStatements
                   join bao in IWSEntities.BankAccounts on new {  bs.Kontonummer } equals new { Kontonummer = bao.IBAN }
                   join cu in IWSEntities.Customers on new {  bao.Owner } equals new { Owner = cu.id }
                   join baa in IWSEntities.BankAccounts on new {  bs.CompanyIBAN } equals new { CompanyIBAN = baa.IBAN }
                   join co in IWSEntities.Companies on new {  baa.Owner } equals new { Owner = co.id }
                   where
                     bs.id == bankStatementId &&
                     bs.IsValidated == false &&
                     bs.CompanyID == companyId
                   select new StatementDetailViewModel()
                   {
                       Id = cu.id,
                       AccountID = co.settlementclearingaccountid,
                       OAccountID = cu.accountid,
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

                if (itemType.Equals(IWSLookUp.DocsType.Payment.ToString()))
                {
                    StatementDetailViewModel sd =
                            (from bs in IWSEntities.BankStatements
                             join bao in IWSEntities.BankAccounts on new {  bs.Kontonummer } equals new { Kontonummer = bao.IBAN }
                             join su in IWSEntities.Suppliers on new {  bao.Owner } equals new { Owner = su.id }
                             join baa in IWSEntities.BankAccounts on new {  bs.CompanyIBAN } equals new { CompanyIBAN = baa.IBAN }
                             join co in IWSEntities.Companies on new {  baa.Owner } equals new { Owner = co.id }
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

                if (itemType.Equals(IWSLookUp.DocsType.GeneralLedger.ToString()))
                {
                    StatementDetailViewModel sd =
                            (from bs in IWSEntities.BankStatements
                             join bao in IWSEntities.BankAccounts on new {  bs.Kontonummer } equals new { Kontonummer = bao.IBAN }
                             join su in IWSEntities.Suppliers on new {  bao.Owner } equals new { Owner = su.id }
                             join baa in IWSEntities.BankAccounts on new {  bs.CompanyIBAN } equals new { CompanyIBAN = baa.IBAN }
                             join co in IWSEntities.Companies on new {  baa.Owner } equals new { Owner = co.id }
                             where
                                 bs.id == bankStatementId &&
                                 bs.IsValidated == false &&
                                 bs.CompanyID == companyId
                             select new StatementDetailViewModel()
                             {
                                 Id = su.id,
                                 AccountID = co.paymentclearingaccountid,
                                 OAccountID = su.accountid,
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

                #region keepit

                //if (itemType.Equals(IWSLookUp.DocsType.CustomerInvoice.ToString()))
                //{
                //    StatementDetailViewModel sd =
                //        (from co in IWSEntities.Companies
                //         join bs in IWSEntities.BankStatements on new { id = co.id } equals new { id = bs.CompanyID }
                //         join cu in IWSEntities.Customers
                //             on new { co.id, bs.Kontonummer }
                //         equals new { id = cu.CompanyID, Kontonummer = cu.IBAN }
                //         where
                //         bs.IsValidated.Equals(false) &&
                //         bs.id.Equals(bankStatementId) &&
                //         co.id.Equals(companyId)
                //         select new StatementDetailViewModel()
                //         {
                //             Id = cu.id,
                //             AccountID = cu.accountid,
                //             OAccountID = co.settlementclearingaccountid,//BankAccountID = 
                //             Info = bs.Info,
                //             Waehrung = bs.Waehrung,
                //             Betrag = (decimal)bs.Betrag,
                //             Buchungstag = (DateTime)bs.Buchungstag,
                //             Valutadatum = (DateTime)bs.Valutadatum,
                //             Periode = Convert.ToString((int?)bs.Buchungstag.Value.Year) +
                //                         Convert.ToString((int?)bs.Buchungstag.Value.Month),
                //             Buchungstext = bs.Buchungstext,
                //             Verwendungszweck = bs.Verwendungszweck,
                //             BeguenstigterZahlungspflichtiger = bs.BeguenstigterZahlungspflichtiger,
                //             IBAN = cu.IBAN
                //         }).Single();
                //    return sd;
                //}

                //if (itemType.Equals(IWSLookUp.DocsType.VendorInvoice.ToString()))
                //{

                //    StatementDetailViewModel sd =
                //        (from su in IWSEntities.Suppliers
                //         join ba in IWSEntities.BankAccounts on new { id = su.id } equals new { id = ba.Owner }
                //         join co in IWSEntities.Companies on new { CompanyID = ba.CompanyID } equals new { CompanyID = co.id }
                //         join bs in IWSEntities.BankStatements on new { IBAN = ba.IBAN } equals new { IBAN = bs.Kontonummer }
                //         where
                //           bs.IsValidated == false &&
                //           ba.CompanyID == companyId &&
                //           bs.id == bankStatementId
                //         select new StatementDetailViewModel()
                //         {
                //             Id = su.id,
                //             BankAccountID = ba.Account,
                //             AccountID = co.purchasingclearingaccountid,
                //             Info = bs.Info,
                //             Waehrung = bs.Waehrung,
                //             Betrag = Math.Abs((decimal)bs.Betrag),
                //             Buchungstag = (DateTime)bs.Buchungstag,
                //             Valutadatum = (DateTime)bs.Valutadatum,
                //             Periode = Convert.ToString((int?)bs.Buchungstag.Value.Year) +
                //                       Convert.ToString((int?)bs.Buchungstag.Value.Month),
                //             Buchungstext = bs.Buchungstext,
                //             Verwendungszweck = bs.Verwendungszweck,
                //             BeguenstigterZahlungspflichtiger = bs.BeguenstigterZahlungspflichtiger,
                //             IBAN = ba.IBAN
                //         }).Single();

                //    return sd;
                //}

                #endregion

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }
        public static List<BankStatementViewModel> GetBankStatements(string companyID,bool isValidated)
        {
            List<BankStatementViewModel> doc = 
                (from b in IWSEntities.BankStatements
                where
                    b.IsValidated.Equals(isValidated) && b.CompanyID.Equals(companyID)
                orderby
                    b.id
                select new BankStatementViewModel()
                {
                    id = b.id, Auftragskonto = b.Auftragskonto,
                    Buchungstag = b.Buchungstag, Valutadatum = b.Valutadatum,
                    Buchungstext = b.Buchungstext, Verwendungszweck = b.Verwendungszweck,
                    BeguenstigterZahlungspflichtiger = b.BeguenstigterZahlungspflichtiger,
                    Kontonummer = b.Kontonummer, BLZ = b.BLZ, Betrag = b.Betrag,
                    Waehrung = b.Waehrung, Info = b.Info, CompanyID = b.CompanyID,
                    CompanyIBAN = b.CompanyIBAN, IsValidated = b.IsValidated
                }).ToList();
            return doc;
        }
        public static List<ValidateDocsViewModel> GetBillOfDelivery(string uiCulture, bool IsValidated)
        {
            List<ValidateDocsViewModel> BL = Queryable.OrderBy(
            (from line in IWSEntities.LineBillOfDeliveries
             where line.BillOfDelivery.IsValidated == IsValidated
             from Item in IWSEntities.Localizations
             where Item.ItemName == DocsType.BillOfDelivery.ToString() && Item.UICulture == uiCulture
             group new
             {
                 line.BillOfDelivery,
                 line,
                 line.Article.Vat
             } by new
             {
                 line.BillOfDelivery.id,
                 ItemType = Item.LocalName,
                 ItemDate = (DateTime?)line.BillOfDelivery.ItemDate,
                 Periode = line.BillOfDelivery.oPeriode,
                 line.BillOfDelivery.account,
                 line.BillOfDelivery.CompanyId,
                 line.Vat,
                 line.Currency
             } into g
             orderby
                g.Key.id
             select new ValidateDocsViewModel()
             {
                 ItemID = g.Key.id,
                 ItemType = g.Key.ItemType,
                 DueDate = Convert.ToDateTime(g.Key.ItemDate),
                 Periode = g.Key.Periode,// g.Key.xYear + g.Key.xMonth,
                 //Area = false,
                 SupplierID = g.Key.account,
                 CompanyID = g.Key.CompanyId,
                 VAT = g.Key.Vat,
                 Currency = g.Key.Currency,
                 TotalVAT = Convert.ToDecimal(Enumerable.Sum(g, p => p.line.price * p.line.quantity * p.line.Article.Vat.PVat)),
                 TotalHVAT = Convert.ToDecimal(Enumerable.Sum(g, p => p.line.price * p.line.quantity))
             }), o => o.ItemID).ToList();
            return BL;
        }
        public static List<ValidateDocsViewModel> GetVendorInvoice(string uiCulture, bool IsValidated)
        {
            List<ValidateDocsViewModel> BL = Queryable.OrderBy(
            (from line in IWSEntities.LineVendorInvoices
                where line.VendorInvoice.IsValidated == IsValidated
                from Item in IWSEntities.Localizations
                where Item.ItemName == DocsType.VendorInvoice.ToString()  && Item.UICulture == uiCulture
                group new
                {
                    line.VendorInvoice,
                    line
                } by new
                {
                    line.VendorInvoice.id,
                    ItemType = Item.LocalName,
                    ItemDate = (DateTime?)line.VendorInvoice.ItemDate,
                    Periode = line.VendorInvoice.oPeriode,
                    line.VendorInvoice.account,
                    line.Currency,
                    line.VendorInvoice.CompanyId
                } into g
                orderby
                        g.Key.id
                select new ValidateDocsViewModel()
                {
                    ItemID = g.Key.id,
                    ItemType = g.Key.ItemType,
                    DueDate = Convert.ToDateTime(g.Key.ItemDate),
                    Periode = g.Key.Periode,
                    //Area = true,
                    SupplierID = g.Key.account,
                    CompanyID = g.Key.CompanyId,
                    VAT = 0,
                    TotalVAT = 0,
                    TotalHVAT = Convert.ToDecimal(Enumerable.Sum(g, p => (double)p.line.amount)),
                    Currency=g.Key.Currency
                }), o => o.ItemID).ToList();
            return BL;
        }
        public static List<ValidateDocsViewModel> GetPurchaseOrder(string uiCulture, bool IsValidated)
        {
            List<ValidateDocsViewModel> BL = Queryable.OrderBy(
            (from line in IWSEntities.LinePurchaseOrders
             where line.PurchaseOrder.IsValidated == IsValidated
             from Item in IWSEntities.Localizations
             where Item.ItemName == DocsType.PurchaseOrder.ToString() && Item.UICulture == uiCulture
             group new
             {
                 line.PurchaseOrder,
                 line,
                 line.Article.Vat
             } by new
             {
                 line.PurchaseOrder.id,
                 ItemType = Item.LocalName,
                 ItemDate = (DateTime?)line.PurchaseOrder.ItemDate,
                 Periode=line.PurchaseOrder.oPeriode,
                 line.PurchaseOrder.account,
                 line.PurchaseOrder.CompanyId,
                 line.Vat,
                 line.Currency
             } into g
             orderby
                 g.Key.id
             select new ValidateDocsViewModel()
             {
                 ItemID = g.Key.id,
                 ItemType = g.Key.ItemType,
                 DueDate = Convert.ToDateTime(g.Key.ItemDate),
                 Periode = g.Key.Periode,
                 //Area = false,
                 SupplierID = g.Key.account,
                 CompanyID = g.Key.CompanyId,
                 VAT=g.Key.Vat,
                 Currency=g.Key.Currency,
                 TotalVAT = Convert.ToDecimal(Enumerable.Sum(g, p => p.line.price * p.line.quantity * p.line.Article.Vat.PVat)),
                 TotalHVAT = Convert.ToDecimal(Enumerable.Sum(g, p => p.line.price * p.line.quantity))
             }), o => o.ItemID).ToList();
            return BL;

        }
        public static List<ValidateDocsViewModel> GetPayment(string uiCulture, bool IsValidated)
        {
             List<ValidateDocsViewModel> BL = Queryable.OrderBy(
             (from line in IWSEntities.LinePayments
             where line.Payment.IsValidated == IsValidated
             from Item in IWSEntities.Localizations
             where Item.ItemName == DocsType.Payment.ToString() && Item.UICulture == uiCulture
             group new
             {
                 line.Payment,
                 line
             } by new
             {
                 line.Payment.id,
                 ItemType = Item.LocalName,
                 ItemDate = (DateTime?)line.Payment.ItemDate,
                 Periode = line.Payment.oPeriode,
                 line.Payment.account,
                 line.Payment.CompanyId,
                 line.Currency
             } into g
             orderby
                 g.Key.id
             select new ValidateDocsViewModel()
             {
                 ItemID = g.Key.id,
                 ItemType = g.Key.ItemType,
                 DueDate = Convert.ToDateTime(g.Key.ItemDate),
                 Periode = g.Key.Periode,
                 //Area = false,
                 SupplierID = g.Key.account,
                 CompanyID = g.Key.CompanyId,
                 VAT=0,
                 TotalVAT = 0,
                 TotalHVAT = Convert.ToDecimal(Enumerable.Sum(g, p => (double)p.line.amount)),
                 Currency=g.Key.Currency
             }), o => o.ItemID).ToList();
            return BL;
        }
        public static List<ValidateDocsViewModel> GetInventoryInvoice(string uiCulture, bool IsValidated)
        {
            List<ValidateDocsViewModel> BL = Queryable.OrderBy(
                (from line in IWSEntities.LineInventoryInvoices
                 where line.InventoryInvoice.IsValidated == IsValidated
                 from Item in IWSEntities.Localizations
                 where Item.ItemName == DocsType.InventoryInvoice.ToString() && Item.UICulture == uiCulture
                 group new
                 {
                     line.InventoryInvoice,
                     line,
                     line.Article.Vat
                 } by new
                 {
                     line.InventoryInvoice.id,
                     ItemType = Item.LocalName,
                     ItemDate = (DateTime?)line.InventoryInvoice.ItemDate,
                     Periode = line.InventoryInvoice.oPeriode,
                     line.InventoryInvoice.account,
                     line.InventoryInvoice.CompanyId,
                     line.Vat,
                     line.Currency
                 } into g
                 orderby
                    g.Key.id
                 select new ValidateDocsViewModel()
                 {
                     ItemID = g.Key.id,
                     ItemType = g.Key.ItemType,
                     DueDate = Convert.ToDateTime(g.Key.ItemDate),
                     Periode = g.Key.Periode,
                     //Area = true,
                     SupplierID = g.Key.account,
                     CompanyID = g.Key.CompanyId,
                     VAT = g.Key.Vat,
                     Currency=g.Key.Currency,
                     TotalVAT = Convert.ToDecimal(Enumerable.Sum(g, p => p.line.price * p.line.quantity * p.line.Article.Vat.PVat)),
                     TotalHVAT = Convert.ToDecimal(Enumerable.Sum(g, p => p.line.price * p.line.quantity))
                 }), o => o.ItemID).ToList();
            return BL;
        }
        public static List<ValidateDocsViewModel> GetGoodReceiving(string uiCulture, bool IsValidated)
        {
            List<ValidateDocsViewModel> BL = Queryable.OrderBy(
            (from line in IWSEntities.LineGoodReceivings
             where line.GoodReceiving.IsValidated == IsValidated
             from Item in IWSEntities.Localizations
             where Item.ItemName == DocsType.GoodReceiving.ToString() && Item.UICulture == uiCulture
             group new
             {
                 line.GoodReceiving,
                 line,
                 line.Article.Vat
             } by new
             {
                 line.GoodReceiving.id,
                 ItemType = Item.LocalName,
                 ItemDate = (DateTime?)line.GoodReceiving.ItemDate,
                 Periode=line.GoodReceiving.oPeriode,
                 line.GoodReceiving.account,
                 line.GoodReceiving.CompanyId,
                 line.Vat,
                 line.Currency
             } into g
             orderby
                g.Key.id
             select new ValidateDocsViewModel()
             {
                 ItemID = g.Key.id,
                 ItemType = g.Key.ItemType,
                 DueDate = Convert.ToDateTime(g.Key.ItemDate),
                 Periode= g.Key.Periode,
                 //Area = true,
                 SupplierID = g.Key.account,
                 CompanyID = g.Key.CompanyId,
                 VAT=g.Key.Vat,
                 Currency=g.Key.Currency,
                 TotalVAT = Convert.ToDecimal(Enumerable.Sum(g, p => p.line.price * p.line.quantity * p.line.Article.Vat.PVat)),
                 TotalHVAT = Convert.ToDecimal(Enumerable.Sum(g, p => p.line.price * p.line.quantity))
             }), o => o.ItemID).ToList();
            return BL;
        }
        public static List<ValidateDocsViewModel> GetSalesOrder(string uiCulture, bool IsValidated)
        {
            List<ValidateDocsViewModel> BL = Queryable.OrderBy(
            (from line in IWSEntities.LineSalesOrders
             where line.SalesOrder.IsValidated == IsValidated
             from Item in IWSEntities.Localizations
             where Item.ItemName == DocsType.SalesOrder.ToString() && Item.UICulture == uiCulture
             group new
             {
                 line.SalesOrder,
                 line,
                 line.Article.Vat
             } by new
             {
                 line.SalesOrder.id,
                 ItemType = Item.LocalName,
                 ItemDate = (DateTime?)line.SalesOrder.ItemDate,
                 Periode=line.SalesOrder.oPeriode,
                 line.SalesOrder.account,
                 line.SalesOrder.CompanyId,
                 line.Vat,
                 line.Currency
             } into g
             orderby
                 g.Key.id
             select new ValidateDocsViewModel()
             {
                 ItemID = g.Key.id,
                 ItemType = g.Key.ItemType,
                 DueDate = Convert.ToDateTime(g.Key.ItemDate),
                 Periode = g.Key.Periode,
                 //Area = false,
                 SupplierID = g.Key.account,
                 CompanyID = g.Key.CompanyId,
                 VAT = g.Key.Vat,
                 Currency=g.Key.Currency,
                 TotalVAT = Convert.ToDecimal(Enumerable.Sum(g, p => p.line.price * p.line.quantity * p.line.Article.Vat.PVat)),
                 TotalHVAT = Convert.ToDecimal(Enumerable.Sum(g, p => p.line.price * p.line.quantity))
             }), o => o.ItemID).ToList();
            return BL;
        }
        public static List<ValidateDocsViewModel> GetSalesInvoice(string uiCulture, bool IsValidated)
        {
            List<ValidateDocsViewModel> BL = Queryable.OrderBy(
                (from line in IWSEntities.LineSalesInvoices
                 where line.SalesInvoice.IsValidated == IsValidated
                 from Item in IWSEntities.Localizations
                 where Item.ItemName == DocsType.SalesInvoice.ToString() && Item.UICulture == uiCulture
                 group new
                 {
                     line.SalesInvoice,
                     line,
                     line.Article.Vat
                 } by new
                 {
                     line.SalesInvoice.id,
                     ItemType = Item.LocalName,
                     ItemDate = (DateTime?)line.SalesInvoice.ItemDate,
                     Periode=line.SalesInvoice.oPeriode,
                     line.SalesInvoice.account,
                     line.SalesInvoice.CompanyId,
                     line.Vat,
                     line.Currency
                 } into g
                 orderby
                    g.Key.id
                 select new ValidateDocsViewModel()
                 {
                     ItemID = g.Key.id,
                     ItemType = g.Key.ItemType,
                     DueDate = Convert.ToDateTime(g.Key.ItemDate),
                     Periode = g.Key.Periode,
                     //Area = false,
                     SupplierID = g.Key.account,
                     CompanyID = g.Key.CompanyId,
                     VAT = g.Key.Vat,
                     Currency=g.Key.Currency,
                     TotalVAT = Convert.ToDecimal(Enumerable.Sum(g, p => p.line.price * p.line.quantity * p.line.Article.Vat.PVat)),
                     TotalHVAT = Convert.ToDecimal(Enumerable.Sum(g, p => p.line.price * p.line.quantity))
                 }), o => o.ItemID).ToList();
            return BL;
        }
        public static List<ValidateDocsViewModel> GetCustomerInvoice(string uiCulture, bool IsValidated)
        {
            List<ValidateDocsViewModel> BL = Queryable.OrderBy(
            (from line in IWSEntities.LineCustomerInvoices
             where line.CustomerInvoice.IsValidated == IsValidated
             from Item in IWSEntities.Localizations
             where Item.ItemName == DocsType.CustomerInvoice.ToString() && Item.UICulture == uiCulture
             group new
             {
                 line.CustomerInvoice,
                 line
             } by new
             {
                 line.CustomerInvoice.id,
                 ItemType = Item.LocalName,
                 ItemDate = (DateTime?)line.CustomerInvoice.ItemDate,
                 Periode=line.CustomerInvoice.oPeriode,
                 line.CustomerInvoice.account,
                 line.Currency,
                 line.CustomerInvoice.CompanyId
             } into g
             orderby
                     g.Key.id
             select new ValidateDocsViewModel()
             {
                 ItemID = g.Key.id,
                 ItemType = g.Key.ItemType,
                 DueDate = Convert.ToDateTime(g.Key.ItemDate),
                 Periode = g.Key.Periode,
                 //Area = false,
                 SupplierID = g.Key.account,
                 CompanyID = g.Key.CompanyId,
                 VAT = 0,
                 TotalVAT = 0,
                 Currency=g.Key.Currency,
                 TotalHVAT = Convert.ToDecimal(Enumerable.Sum(g, p => (double)p.line.amount))
             }), o => o.ItemID).ToList();
            return BL;
        }
        public static List<ValidateDocsViewModel> GetSettlement(string uiCulture, bool IsValidated)
        {
            List<ValidateDocsViewModel> BL = Queryable.OrderBy(
            (from line in IWSEntities.LineSettlements
             where line.Settlement.IsValidated == IsValidated
             from Item in IWSEntities.Localizations
             where Item.ItemName == DocsType.Settlement.ToString() && Item.UICulture == uiCulture
             group new
             {
                 line.Settlement,
                 line
             } by new
             {
                 line.Settlement.id,
                 ItemType = Item.LocalName,
                 ItemDate = (DateTime?)line.Settlement.ItemDate,
                 Periode=line.Settlement.oPeriode,
                 line.Settlement.account,
                 line.Settlement.CompanyId,
                 line.Currency
             } into g
             orderby
                  g.Key.id
             select new ValidateDocsViewModel()
             {
                 ItemID = g.Key.id,
                 ItemType = g.Key.ItemType,
                 DueDate = Convert.ToDateTime(g.Key.ItemDate),
                 Periode = g.Key.Periode,
                 //Area = false,
                 SupplierID = g.Key.account,
                 CompanyID = g.Key.CompanyId,
                 VAT = 0,
                 TotalVAT = 0,
                 Currency=g.Key.Currency,
                 TotalHVAT = Convert.ToDecimal(Enumerable.Sum(g, p => (double)p.line.amount))
             }), o => o.ItemID).ToList();
            return BL;
        }
        public static List<ValidateDocsViewModel> GetGeneralLedgerIn(string uiCulture, bool IsValidated)
        {
            List<ValidateDocsViewModel> BL = Queryable.OrderBy(
            (from line in IWSEntities.LineGeneralLedgers
             where line.GeneralLedger.IsValidated == IsValidated// && line.GeneralLedger.Area == Area.Sales.ToString()
             from Item in IWSEntities.Localizations
             where Item.ItemName == DocsType.GeneralLedger.ToString() && Item.UICulture == uiCulture
             group new
             {
                 line.GeneralLedger,
                 line
             } by new
             {
                 line.GeneralLedger.id,
                 ItemType = Item.LocalName,
                 ItemDate = (DateTime?)line.GeneralLedger.ItemDate,
                 Periode = line.GeneralLedger.oPeriode,
                 line.GeneralLedger.CompanyId,
                 line.Currency
             } into g
             orderby
                  g.Key.id
             select new ValidateDocsViewModel()
             {
                 ItemID = g.Key.id,
                 ItemType = g.Key.ItemType,
                 DueDate = Convert.ToDateTime(g.Key.ItemDate),
                 Periode = g.Key.Periode,
                 //Area = false,
                 SupplierID = Area.Sales.ToString(),
                 CompanyID = g.Key.CompanyId,
                 VAT = 0,
                 TotalVAT = 0,
                 Currency=g.Key.Currency,
                 TotalHVAT = Convert.ToDecimal(Enumerable.Sum(g, p => (double)p.line.amount))
             }), o => o.ItemID).ToList();
            return BL;
        }
        public static List<ValidateDocsViewModel> GetGeneralLedgerOut(string uiCulture, bool IsValidated)
        {
            List<ValidateDocsViewModel> BL = Queryable.OrderBy(
            (from line in IWSEntities.LineGeneralLedgers
             where line.GeneralLedger.IsValidated == IsValidated// && line.GeneralLedger.Area == Area.Purchasing.ToString()
             from Item in IWSEntities.Localizations
             where Item.ItemName == DocsType.GeneralLedger.ToString() && Item.UICulture == uiCulture
             group new
             {
                 line.GeneralLedger,
                 line
             } by new
             {
                 line.GeneralLedger.id,
                 ItemType = Item.LocalName,
                 ItemDate = (DateTime?)line.GeneralLedger.ItemDate,
                 Periode=line.GeneralLedger.oPeriode,
                 line.GeneralLedger.CompanyId,
                 line.Currency
             } into g
             orderby
                  g.Key.id
             select new ValidateDocsViewModel()
             {
                 ItemID = g.Key.id,
                 ItemType = g.Key.ItemType,
                 DueDate = Convert.ToDateTime(g.Key.ItemDate),
                 Periode = g.Key.Periode,
                 //Area = false,
                 SupplierID = Area.Purchasing.ToString(),
                 CompanyID = g.Key.CompanyId,
                 VAT = 0,
                 TotalVAT = 0,
                 Currency=g.Key.Currency,
                 TotalHVAT = Convert.ToDecimal(Enumerable.Sum(g, p => (double)p.line.amount))
             }), o => o.ItemID).ToList();
            return BL;
        }
        public static List<DocumentsViewModel> GetAccountingDocument(bool IsValidated) 
        {
            // get current thread UICulture
            string uiCulture = Thread.CurrentThread.CurrentUICulture.Name;
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            List<ValidateDocsViewModel> document = 
                                            GetPurchaseOrder(uiCulture, IsValidated).
                                            Union(GetGoodReceiving(uiCulture, IsValidated)).
                                            Union(GetInventoryInvoice(uiCulture, IsValidated)).
                                            Union(GetVendorInvoice(uiCulture, IsValidated)).
                                            Union(GetPayment(uiCulture, IsValidated)).
                                            Union(GetSalesOrder(uiCulture, IsValidated)).
                                            Union(GetBillOfDelivery(uiCulture, IsValidated)).
                                            Union(GetSalesInvoice(uiCulture, IsValidated)).
                                            Union(GetCustomerInvoice(uiCulture, IsValidated)).
                                            Union(GetSettlement(uiCulture, IsValidated)).
                                            Union(GetGeneralLedgerIn(uiCulture, IsValidated)).
                                            Union(GetGeneralLedgerOut(uiCulture, IsValidated)).
                                            Where(c=>c.CompanyID==companyID).
                                            ToList();
            List<DocumentsViewModel> documents = (
                                            from doc in document
                                            group doc by new
                                            {
                                                doc.ItemID, doc.ItemType, doc.DueDate,
                                                doc.SupplierID, doc.CompanyID, doc.Currency
                                            } into g
                                            orderby
                                            g.Key.ItemType, g.Key.ItemID
                                            select new DocumentsViewModel()
                                            {
                                                ItemID=g.Key.ItemID, ItemType=g.Key.ItemType, DueDate=g.Key.DueDate,
                                                SupplierID =g.Key.SupplierID, CompanyID=g.Key.CompanyID,
                                                TotalVAT =g.Sum(s=>s.TotalVAT), TotalHVAT=g.Sum(s=>s.TotalHVAT),
                                                Currency=g.Key.Currency
                                            }).ToList();
            return documents;
        }

        public static List<OwnerViewModel> GetOwner()
        {
            string uiCulture = Thread.CurrentThread.CurrentUICulture.Name;
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            List<OwnerViewModel> companies = Queryable.OrderBy(
            (from line in IWSEntities.Companies
             where line.id== companyID
             from Item in IWSEntities.Localizations
             where Item.ItemName == Owner.Company.ToString() && Item.UICulture == uiCulture
             select new OwnerViewModel()
             {
                 ID = line.id,
                 Name = line.name,
                 OwnerType = Item.LocalName
             }), o => o.OwnerType).ToList();

            List<OwnerViewModel> customers = Queryable.OrderBy(
            (from line in IWSEntities.Customers
             where line.id == companyID
             from Item in IWSEntities.Localizations
             where Item.ItemName == Owner.Company.ToString() && Item.UICulture == uiCulture
             select new OwnerViewModel()
             {
                 ID = line.id,
                 Name = line.name,
                 OwnerType = Item.LocalName
             }), o => o.OwnerType).ToList();

            List<OwnerViewModel> suppliers = Queryable.OrderBy(
            (from line in IWSEntities.Suppliers
             where line.id == companyID
             from Item in IWSEntities.Localizations
             where Item.ItemName == Owner.Company.ToString() && Item.UICulture == uiCulture
             select new OwnerViewModel()
             {
                 ID = line.id,
                 Name = line.name,
                 OwnerType = Item.LocalName
             }), o => o.OwnerType).ToList();
            return companies.Union(customers).Union(suppliers).ToList();

        }

        public static IEnumerable GetNewLineGoodReceiving(int  itemID, int oid)
        {
            List<LinePurchaseOrder> items = new List<LinePurchaseOrder>();
            items = IWSEntities.LinePurchaseOrders
                    .Where(c => c.transid == oid)
                    .ToList();
            List<LineGoodReceiving> docs = 
                (from item in items
                select new LineGoodReceiving()
                {
                    transid = itemID, 
                    item=item.item, unit=item.unit,
                    price=item.price, quantity=item.quantity,
                    Vat=item.Vat, duedate=item.duedate,
                    text=item.text, Currency=item.Currency
                }
                ).ToList();
            return docs;
        }
        public static IEnumerable GetNewLineBillOfDelivery(int itemID, int oid)
        {
            List<LineSalesOrder> items = new List<LineSalesOrder>();
            items = IWSEntities.LineSalesOrders
                    .Where(c => c.transid == oid)
                    .ToList();
            List<LineBillOfDelivery> docs =
                (from item in items
                 select new LineBillOfDelivery()
                 {
                     transid = itemID, 
                     item = item.item, unit = item.unit,
                     price = item.price, quantity = item.quantity,
                     Vat = item.Vat, duedate = item.duedate,
                     text = item.text, Currency = item.Currency
                 }
                ).ToList();
            return docs;
        }
        public static IEnumerable GetNewLineSalesInvoice(int itemID, int oid)
        {
            List<LineBillOfDelivery> items = new List<LineBillOfDelivery>();
            items = IWSEntities.LineBillOfDeliveries
                    .Where(c => c.transid == oid)
                    .ToList();
            List<LineSalesInvoice> docs =
                (from item in items
                 select new LineSalesInvoice()
                 {
                     transid = itemID,
                     item = item.item,
                     unit = item.unit,
                     price = item.price,
                     quantity = item.quantity,
                     Vat = item.Vat,
                     duedate = item.duedate,
                     text = item.text,
                     Currency = item.Currency
                 }
                ).ToList();
            return docs;
        }
        public static IEnumerable GetNewLineCustomerInvoice(int itemID, int oid)
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            List<CreditViewModel> c = new List<CreditViewModel>
                ((from l in IWSEntities.LineSalesInvoices
                    where 
                    l.transid == oid &&
                    l.Article.CompanyID == companyID &&
                    l.Article.Vat.CompanyID == companyID
                    select new CreditViewModel()
                    {
                        OCreditVAT = l.Article.Vat.outputvataccountid,
                        OCreditTotal = l.Article.Vat.revenueaccountid
                    }).Distinct());

            List<DebitViewModel> d = new List<DebitViewModel>
                (from l in IWSEntities.SalesInvoices
                   where
                     l.CompanyId == companyID &&
                     l.id == oid
                   select new DebitViewModel()
                   {
                       TransID = itemID,
                       ODebit = l.Customer.accountid,
                       OCredit= l.Company.salesclearingaccountid,
                       Side = false,
                       HeaderText = l.HeaderText,
                       ItemDate= l.ItemDate,
                       OVat = l.oVat,
                       OTotal = l.oTotal,
                       Currency = l.oCurrency
                   });
            IList<LineCustomerInvoice> lines = new List<LineCustomerInvoice>() {
                        new LineCustomerInvoice(){
                            transid =itemID, account=d.Single().ODebit, side=d.Single().Side, oaccount=c.Single().OCreditVAT,
                            amount=(decimal)d.Single().OVat, duedate=d.Single().ItemDate, text=d.Single().HeaderText,
                            Currency=d.Single().Currency},
                        new LineCustomerInvoice(){
                            transid =itemID, account=d.Single().ODebit, side=d.Single().Side, oaccount=d.Single().OCredit,
                            amount=(decimal)d.Single().OTotal, duedate=d.Single().ItemDate, text=d.Single().HeaderText,
                            Currency=d.Single().Currency}
                    };
            return lines;
        }
        public static IEnumerable GetNewLineSettlement(int itemID, int oid)
        {
            List<CreditViewModel> c = new List<CreditViewModel>
                ((from l in IWSEntities.CustomerInvoices
                  where
                    l.id == oid
                  select new CreditViewModel()
                  {
                      OCreditTotal= l.Company.bankaccountid
                  }).Distinct());

            List<DebitViewModel> d = new List<DebitViewModel>
                (from l in IWSEntities.LineCustomerInvoices
                 group l by new
                 {
                     l.transid, l.account, l.side, l.duedate, l.Currency, l.text
                 } into g
                 where g.Key.transid == oid
                 select new DebitViewModel()
                 {
                     TransID= g.Key.transid, ODebit= g.Key.account, Side= !g.Key.side,
                     OVat = (decimal?)g.Sum(p => p.amount), ItemDate= g.Key.duedate,
                     Currency= g.Key.Currency, HeaderText= g.Key.text
                 });
            IList<LineSettlement> lines = new List<LineSettlement>() {
                        new LineSettlement(){
                            transid =itemID, account=c.Single().OCreditTotal, side=d.Single().Side, oaccount=d.Single().ODebit,
                            amount=(decimal)d.Single().OVat, duedate=d.Single().ItemDate, text=d.Single().HeaderText,
                            Currency=d.Single().Currency}
                     };
            return lines;            
        }
        public static IEnumerable GetNewLinePayment(int itemID, int oid)
        {
            List<CreditViewModel> c = new List<CreditViewModel>
                ((from l in IWSEntities.VendorInvoices
                  where
                    l.id == oid
                  select new CreditViewModel()
                  {
                      OCreditTotal = l.Company.bankaccountid
                  }).Distinct());

            List<DebitViewModel> d = new List<DebitViewModel>
                (from l in IWSEntities.VendorInvoices
                 where
                   l.id == oid
                 select new DebitViewModel()
                 {
                     TransID = itemID,
                     ODebit = l.Supplier.accountid,
                     Side = true,
                     OTotal= l.oTotal,
                     ItemDate=l.ItemDate,
                     HeaderText=l.HeaderText,
                     Currency=l.oCurrency,
                 });
                 
            IList<LinePayment> lines = new List<LinePayment>() {
                        new LinePayment(){
                            transid =itemID, account=d.Single().ODebit, side=d.Single().Side, oaccount=c.Single().OCreditTotal,
                            amount=(decimal)d.Single().OTotal, duedate=d.Single().ItemDate, text=d.Single().HeaderText,
                            Currency=d.Single().Currency}
                     };
            return lines;
        }
        public static IEnumerable GetNewGeneralLedgerIn(int itemID, int oid)
        {
            List<LineSettlement> items = new List<LineSettlement>();
            items = IWSEntities.LineSettlements
                    .Where(c => c.transid == oid)
                    .ToList();
            List<LineGeneralLedger> docs =
                (from item in items
                 select new LineGeneralLedger()
                 {
                     transid = itemID, account = item.oaccount, side = !item.side,
                     oaccount = item.account, amount = item.amount,
                     duedate = item.duedate, text = item.text,
                     Currency = item.Currency
                 }
                ).ToList();
            return docs;
        }
        public static IEnumerable GetNewGeneralLedgerOut(int itemID, int oid)
        {
            List<LinePayment> items = new List<LinePayment>();
            items = IWSEntities.LinePayments
                    .Where(c => c.transid == oid)
                    .ToList();
            List<LineGeneralLedger> docs =
                (from item in items
                 select new LineGeneralLedger()
                 {
                     transid = itemID, account = item.oaccount, side = !item.side,
                     oaccount = item.account, amount = item.amount,
                     duedate = item.duedate, text = item.text,
                     Currency = item.Currency
                 }
                ).ToList();
            return docs;
        }
        public static IEnumerable GetNewLineInventoryInvoice(int itemID, int oid)
        {
            List<LineGoodReceiving> items = new List<LineGoodReceiving>();
            items = IWSEntities.LineGoodReceivings
                    .Where(c => c.transid == oid)
                    .ToList();
            List<LineInventoryInvoice> docs =
                (from item in items
                 select new LineInventoryInvoice()
                 {
                     transid = itemID, item = item.item, unit = item.unit, price = item.price,
                     quantity = item.quantity, Vat = item.Vat, duedate = item.duedate,
                     text = item.text, Currency = item.Currency
                 }
                ).ToList();
            return docs;
        }
        public static IEnumerable GetNewLineVendorInvoice(int itemID, int oid)
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            List<CreditViewModel> c = new List<CreditViewModel>
            ((from l in IWSEntities.LineInventoryInvoices
              where
                          l.transid == oid &&
                          l.Article.CompanyID == companyID &&
                          l.Article.Vat.CompanyID == companyID
              select new CreditViewModel()
              {
                  OCreditVAT = l.Article.Vat.outputvataccountid,
                  OCreditTotal = l.Article.Vat.revenueaccountid
              }).Distinct());


            List<DebitViewModel> d = new List<DebitViewModel>
                (from l in IWSEntities.InventoryInvoices
                 where
                   l.CompanyId == companyID &&
                   l.id == oid
                 select new DebitViewModel()
                 {
                     TransID = itemID,
                     ODebit = l.Supplier.accountid,
                     OCredit = l.Company.purchasingclearingaccountid,
                     Side = false,
                     HeaderText = l.HeaderText,
                     ItemDate = l.ItemDate,
                     OVat = l.oVat,
                     OTotal = l.oTotal,
                     Currency = l.oCurrency
                 });
            IList<LineVendorInvoice> lines = new List<LineVendorInvoice>() {
                        new LineVendorInvoice(){
                            transid =itemID, account=d.Single().ODebit, side=d.Single().Side, oaccount=c.Single().OCreditVAT,
                            amount=(decimal)d.Single().OVat, duedate=d.Single().ItemDate, text=d.Single().HeaderText,
                            Currency=d.Single().Currency},
                        new LineVendorInvoice(){
                            transid =itemID, account=d.Single().ODebit, side=d.Single().Side, oaccount=d.Single().OCredit,
                            amount=(decimal)d.Single().OTotal, duedate=d.Single().ItemDate, text=d.Single().HeaderText,
                            Currency=d.Single().Currency}
                    };
            return lines;
        }

        //public static List<CashLine> GetCashLines(int transId) => IWSEntities.CashLines.Where(c =>
        //        c.TransId == transId).ToList();

        //var account = IWSEntities.BankAccounts.AsEnumerable().Select(i => new
        //{
        //    Id = i.IBAN,
        //    Name = i.Owner,
        //    i.CompanyID,
        //})
        //.Where(c => c.CompanyID == companyID)
        //.OrderBy(o => o.Id);

        public static IEnumerable GetAccountBalance(string accountId, string CompanyID)
        {
            List<AccountBalanceViewModel> items = new List<AccountBalanceViewModel>();
            if (String.IsNullOrEmpty(accountId) || String.IsNullOrWhiteSpace(accountId))
            {
                items = (from p in IWSEntities.PeriodicBalances(accountId, CompanyID)
                        select new AccountBalanceViewModel()
                        {
                            AccountID=p.AccountId ,
                            AccountName=p.AccountName,
                            Periode=p.Periode,
                            OYear = p.OYear,
                            OMonth=p.OMonth,
                            Debit =(decimal)p.Debit,
                            Credit=(decimal)p.Credit,
                            InitialBalance=(decimal)p.InitialBalance,
                            FinalBalance=(decimal)p.FinalBalance,
                            SDebit = (decimal)p.SDebit,
                            SCredit = (decimal)p.SCredit,
                            Balance = (decimal)p.Balance,
                            Currency=p.Currency,
                            IsBalance=(bool)p.IsBalance,
                            CompanyID=p.CompanyId
                        }).OrderBy(o => o.AccountID).ThenBy(o => o.Periode).ToList();
            }
            else
            {
                items = (from p in IWSEntities.PeriodicBalances(accountId, CompanyID)
                         select new AccountBalanceViewModel()
                         {
                             AccountID = p.AccountId,
                             AccountName = p.AccountName,
                             Periode = p.Periode,
                             OYear = p.OYear,
                             OMonth = p.OMonth,
                             Debit = (decimal)p.Debit,
                             Credit = (decimal)p.Credit,
                             InitialBalance = (decimal)p.InitialBalance,
                             FinalBalance = (decimal)p.FinalBalance,
                             SDebit = (decimal)p.SDebit,
                             SCredit = (decimal)p.SCredit,
                             Balance = (decimal)p.Balance,
                             Currency = p.Currency,
                             IsBalance = (bool)p.IsBalance,
                             CompanyID = p.CompanyId
                         }).Where(c => accountId.IndexOf(c.AccountID) >= 0 ).OrderBy(o => o.AccountID).ThenBy(o=>o.Periode).ToList();
            }
            return items;
        }
        public static IEnumerable GetJournal(string start, string end, string accountId, string CompanyID)
        {
            string uiCulture = Thread.CurrentThread.CurrentUICulture.Name;
            List<JournalViewModel> journals = new List<JournalViewModel>();
            if (String.IsNullOrEmpty(accountId) || String.IsNullOrWhiteSpace(accountId))
            {
             journals = (from j in IWSEntities.GetJournal(start, end, uiCulture, CompanyID)
                 select new JournalViewModel()
                 {
                     pk = j.ID,
                     ItemID = j.ItemID,
                     OID = j.OID,
                     ItemType = j.LocalName,
                     CustSupplierID = j.CustSupplierID,
                     Owner = j.Owner,
                     TransDate = j.TransDate,
                     Periode = j.Periode,
                     oYear = j.OYear,
                     oMonth = j.oMonth,
                     Account = j.Account,
                     AccountName=j.AccountName,
                     OAccount = j.OAccount,
                     OAccountName = j.OAccountName,
                     Amount = j.Amount,
                     Side = j.Side,
                     Currency = j.Currency,
                     CompanyID = j.CompanyID,
                     TypeJournal = j.TypeJournal
                 }).OrderBy(o=>o.pk).ToList();
            }
            else
            {
            journals = (from j in IWSEntities.GetJournal(start, end, uiCulture, CompanyID)
                 select new JournalViewModel()
                 {
                     pk = j.ID,
                     ItemID = j.ItemID,
                     OID = j.OID,
                     ItemType = j.LocalName,
                     CustSupplierID = j.CustSupplierID,
                     Owner = j.Owner,
                     TransDate = j.TransDate,
                     Periode = j.Periode,
                     oYear = j.OYear,
                     oMonth = j.oMonth,
                     Account = j.Account,
                     AccountName = j.AccountName,
                     OAccount = j.OAccount,
                     OAccountName = j.OAccountName,
                     Amount = j.Amount,
                     Side = j.Side,
                     Currency = j.Currency,
                     CompanyID = j.CompanyID,
                     TypeJournal = j.TypeJournal
                 }).Where(c => accountId.IndexOf(c.Account)>=0  || accountId.IndexOf(c.OAccount) >= 0).OrderBy(o => o.pk).ToList();
            }
            return journals; 
        }

        public static List<JournauxViewModel> GetJournaux(string TypeJournal, string CompanyId)
        {

            List<JournauxViewModel> payment = new List<JournauxViewModel>();
            payment = IWSEntities.Payments.Join(IWSEntities.Suppliers,
                                                    p => p.account, s => s.id, (p, s) =>
                                                        new JournauxViewModel()
                                                        {
                                                            Id = p.id,
                                                            OId = p.oid,
                                                            CostCenter = p.CostCenter,
                                                            Account = p.account + '-' + s.name,
                                                            HeaderText = p.HeaderText,
                                                            TransDate = p.TransDate,
                                                            ItemDate = p.ItemDate,
                                                            EntryDate = p.EntryDate,
                                                            CompanyId = p.CompanyId,
                                                            IsValidated = (bool)p.IsValidated,
                                                            OTotal = (decimal)p.oTotal,
                                                            OCurrency = p.oCurrency,
                                                            OPeriode = p.oPeriode,
                                                            OYear = p.oYear,
                                                            OMonth = p.oMonth,
                                                            TypeJournal = p.TypeJournal,
                                                            ModelId = Convert.ToInt32(p.ModelId ?? 0),
                                                            AccountingAccount = p.AccountingAccount,
                                                        //LigneJournauxViewModels=p.LinePayments.Select(l=>new LigneJournauxViewModel()
                                                        //{
                                                        //    Id=l.id,
                                                        //    TransId=l.transid,
                                                        //    Account=l.account,
                                                        //    Side=l.side,
                                                        //    OAccount=l.oaccount,
                                                        //    Amount=l.amount,
                                                        //    DueDate=l.duedate,
                                                        //    Text=l.text,
                                                        //    ModelId=l.ModelId
                                                        //}).ToList()
                                                    }).Where(p => p.CompanyId.Equals(CompanyId) && TypeJournal.IndexOf(p.TypeJournal) >= 0).ToList();
            //List<JournauxViewModel> settlement = new List<JournauxViewModel>();
            //settlement= IWSEntities.Settlements.Join(IWSEntities.Customers,
            //                                        p => p.account, c => c.id, (p, c) =>
            //                                        new JournauxViewModel()
            //                                        {
            //                                            Id = p.id,
            //                                            OId = p.oid,
            //                                            CostCenter = p.CostCenter,
            //                                            Account = p.account + '-' + c.name,
            //                                            HeaderText = p.HeaderText,
            //                                            TransDate = p.TransDate,
            //                                            ItemDate = p.ItemDate,
            //                                            EntryDate = p.EntryDate,
            //                                            CompanyId = p.CompanyId,
            //                                            IsValidated = (bool)p.IsValidated,
            //                                            OTotal = (decimal)p.oTotal,
            //                                            OCurrency = p.oCurrency,
            //                                            OPeriode = p.oPeriode,
            //                                            OYear = p.oYear,
            //                                            OMonth = p.oMonth,
            //                                            TypeJournal = p.TypeJournal,
            //                                            ModelId = Convert.ToInt32(p.ModelId ?? 0),
            //                                            AccountingAccount = p.AccountingAccount
            //                                        }).Where(p => p.CompanyId.Equals(CompanyId) && TypeJournal.IndexOf(p.TypeJournal) >= 0).ToList();
            //List<JournauxViewModel> vendorInvoice = new List<JournauxViewModel>();
            //vendorInvoice = IWSEntities.VendorInvoices.Join(IWSEntities.Suppliers,
            //                                        p => p.account, s => s.id, (p, s) =>
            //                                        new JournauxViewModel()
            //                                        {
            //                                            Id = p.id,
            //                                            OId = p.oid,
            //                                            CostCenter = p.CostCenter,
            //                                            Account = p.account + '-' + s.name,
            //                                            HeaderText = p.HeaderText,
            //                                            TransDate = p.TransDate,
            //                                            ItemDate = p.ItemDate,
            //                                            EntryDate = p.EntryDate,
            //                                            CompanyId = p.CompanyId,
            //                                            IsValidated = (bool)p.IsValidated,
            //                                            OTotal = (decimal)p.oTotal,
            //                                            OCurrency = p.oCurrency,
            //                                            OPeriode = p.oPeriode,
            //                                            OYear = p.oYear,
            //                                            OMonth = p.oMonth,
            //                                            TypeJournal = p.TypeJournal,
            //                                            ModelId = Convert.ToInt32(p.ModelId ?? 0),
            //                                            AccountingAccount = p.AccountingAccount
            //                                        }).Where(p => p.CompanyId.Equals(CompanyId) && TypeJournal.IndexOf(p.TypeJournal) >= 0).ToList();
            //List<JournauxViewModel> customerInvoice = new List<JournauxViewModel>();
            //customerInvoice = IWSEntities.CustomerInvoices.Join(IWSEntities.Customers,
            //                                        p => p.account, s => s.id, (p, s) =>
            //                                        new JournauxViewModel()
            //                                        {
            //                                            Id = p.id,
            //                                            OId = p.oid,
            //                                            CostCenter = p.CostCenter,
            //                                            Account = p.account + '-' + s.name,
            //                                            HeaderText = p.HeaderText,
            //                                            TransDate = p.TransDate,
            //                                            ItemDate = p.ItemDate,
            //                                            EntryDate = p.EntryDate,
            //                                            CompanyId = p.CompanyId,
            //                                            IsValidated = (bool)p.IsValidated,
            //                                            OTotal = (decimal)p.oTotal,
            //                                            OCurrency = p.oCurrency,
            //                                            OPeriode = p.oPeriode,
            //                                            OYear = p.oYear,
            //                                            OMonth = p.oMonth,
            //                                            TypeJournal = p.TypeJournal,
            //                                            ModelId = Convert.ToInt32(p.ModelId ?? 0),
            //                                            AccountingAccount = p.AccountingAccount
            //                                        }).Where(p => p.CompanyId.Equals(CompanyId) && TypeJournal.IndexOf(p.TypeJournal) >= 0).ToList();
            //List<JournauxViewModel> generalLedger = new List<JournauxViewModel>();
            //generalLedger = IWSEntities.GeneralLedgers.Select(p=>
            //                                        new JournauxViewModel()
            //                                        {
            //                                            Id = p.id,
            //                                            OId = p.oid,
            //                                            CostCenter = p.CostCenter,
            //                                            Account = "...",
            //                                            HeaderText = p.HeaderText,
            //                                            TransDate = p.TransDate,
            //                                            ItemDate = p.ItemDate,
            //                                            EntryDate = p.EntryDate,
            //                                            CompanyId = p.CompanyId,
            //                                            IsValidated = (bool)p.IsValidated,
            //                                            OTotal = (decimal)p.oTotal,
            //                                            OCurrency = p.oCurrency,
            //                                            OPeriode = p.oPeriode,
            //                                            OYear = p.oYear,
            //                                            OMonth = p.oMonth,
            //                                            TypeJournal = p.TypeJournal,
            //                                            ModelId = Convert.ToInt32(p.ModelId ?? 0),
            //                                            AccountingAccount = "..."
            //                                        }).Where(p => p.CompanyId.Equals(CompanyId) && TypeJournal.IndexOf(p.TypeJournal) >= 0).ToList();
            //return payment.Union(settlement).ToList().Union(vendorInvoice).Union(customerInvoice).Union(generalLedger).ToList();
            return payment.ToList();
        }
        public static List<LineJournauxViewModel> GetLineJournaux(int transId)
        {

            //var account = IWSEntities.LinePayments.AsEnumerable<LineJournauxViewModel>().Select(i => new
            //{
            //    Id = i.id,
            //    TranstId=i.transid,
            //    Account = i.account,
            //    Side=i.side,
            //    OAccount=i.oaccount,
            //    Amount=i.amount,
            //})
            //.Where(c => c.TranstId == transId)
            //.OrderBy(o => o.Id);


            List<LineJournauxViewModel> linePayment = new List<LineJournauxViewModel>();
            linePayment = IWSEntities.LinePayments.AsEnumerable().Select(p =>
                                                      new LineJournauxViewModel
                                                      {
                                                          Id = p.id,
                                                          TransId = transId,
                                                          Account = p.account,
                                                          Side = p.side,
                                                          OAccount = p.oaccount,
                                                          Amount = p.amount,
                                                          Text = p.text,
                                                          DueDate = p.duedate,
                                                          Currency = p.Currency,
                                                          ModelId = Convert.ToInt32(p.ModelId ?? 0)
                                                      }).Where(t => t.TransId == transId).ToList();


            //linePayment = IWSEntities.LinePayments.Select(p=>
            //                                            new LineJournauxViewModel()
            //                                            {
            //                                                Id = p.id,
            //                                                TransId=transId,
            //                                                Account = p.account,
            //                                                Side=p.side,
            //                                                OAccount=p.oaccount,
            //                                                Amount=p.amount,
            //                                                Text=p.text,
            //                                                DueDate=p.duedate,
            //                                                Currency=p.Currency,
            //                                                ModelId = Convert.ToInt32(p.ModelId ?? 0)
            //                                            }).Where(t => t.TransId==transId).ToList();
            return linePayment;
        }
        public static IEnumerable GetReport(string start, string end, string CompanyID)
        {
            string uiCulture = Thread.CurrentThread.CurrentUICulture.Name;
            List<ReportViewModel> report = new List<ReportViewModel>();

            report = (from j in IWSEntities.GetJournal(start, end, uiCulture, CompanyID)
                      select new ReportViewModel()
                      {
                          Account = j.Account,
                          Owner = j.CustSupplierID,
                          ItemType = j.LocalName,
                          TransDate = j.TransDate,
                          Amount = j.Amount,
                          Currency = j.Currency,
                      }).ToList();
            return report;
        }
 
        public static IEnumerable GetResultat(string classId, string start, string end, string company, bool isBalance)
        {
            List<ResultsViewModel> r = (from s in IWSEntities.AccountBalance(classId, start, end, company, isBalance)
                                        where s.SDebit != s.SCredit
                                        select new ResultsViewModel()
                                        {
                                            ClassId =s.ClassId,
                                            ClassName =s.ClassName,
                                            SubClassId =s.SubClassId,
                                            SubClassName =s.SubClassName,
                                            AccountId = s.AccountId,
                                            AccountName = s.AccountName,
                                            TDebit = (Decimal)s.TDebit,
                                            TCredit = (Decimal)s.TCredit,
                                            SDebit = (Decimal)s.SDebit,
                                            SCredit = (Decimal)s.SCredit,
                                            Currency=s.Currency,
                                            Balance=(decimal)s.Balance
                                        }).ToList();
            return r;
        }
        public static IEnumerable GetClass()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            List<ChildViewModel> r =
                ((
                from c in IWSEntities.Companies
                join a in IWSEntities.Accounts on new {  c.BalanceSheet } equals new { BalanceSheet = a.id }
                where
                  c.id == companyID
                select new ChildViewModel()
                {
                    ParentId = a.id,
                    ParentName = a.name
                }
                ).Union
                (
                    from c in IWSEntities.Companies
                    join Accounts in IWSEntities.Accounts on new {  c.IncomesStatement } equals new { IncomesStatement = Accounts.id }
                    where
                      c.id == companyID
                    select new ChildViewModel()
                    {
                        ParentId = Accounts.id,
                        ParentName = Accounts.name
                    }
                )).ToList();
            return r;
        }
        public static IEnumerable GetStock(string CompanyID)
        {
            List<StockViewModel> SV = (from s in IWSEntities.Stocks
                                       select new StockViewModel()
                                       {
                                           ItemName = (s.Article.id + "-" + s.Article.name),
                                           StoreName = (s.Store.id + "-" + s.Store.name),
                                           Quantity = Convert.ToInt32(s.quantity),
                                           ItemUnit = s.Article.packunit,
                                           AveragePrice = Convert.ToDecimal(s.Article.avgprice),
                                           Currency=s.Currency,
                                           CompanyID =s.CompanyID
                                       })
                                       .Where(c=>c.CompanyID==CompanyID)
                                       .ToList();
            return SV;
        }
        public static string GetPackUnit(string id)
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            return IWSEntities.Articles.FirstOrDefault(c => 
                c.id == id && c.CompanyID == companyID).packunit;
        }
        public static string GetCompany(string UserName)
        {
            return IWSEntities.AspNetUsers.FirstOrDefault(c => 
                                c.UserName == UserName).Company;
        }
        public static string GetQttyUnit(string id)
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            return IWSEntities.Articles.FirstOrDefault(c => 
                c.id == id && c.CompanyID == companyID).qttyunit;
        }
        public static decimal GetVatCode(string id)
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            return IWSEntities.Articles.FirstOrDefault(c =>
                   c.id == id && c.CompanyID == companyID).Vat.PVat;
        }
        public static string DefaultCurrency()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            return IWSEntities.Companies.FirstOrDefault(c => 
                   c.id == companyID).Currency;
        }
        public static decimal GetPrice(string id)
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            return IWSEntities.Articles.FirstOrDefault(c => 
                c.id == id && c.CompanyID == companyID).price;
        }
        public static decimal GetSalesPrice(string id)
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            return IWSEntities.Articles.FirstOrDefault(c => 
                c.id == id && c.CompanyID == companyID).salesprice;
        }
        public static string GetLineText(string id)
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            return IWSEntities.Articles.FirstOrDefault(c => 
                c.id == id && c.CompanyID == companyID).description ?? "N/A";
        }
        public static string GetCashAccountId()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            return IWSEntities.Companies.FirstOrDefault(c => 
                    c.id == companyID).CashAccountId;
        }
        public static string GetVatAccountId(decimal pvat)
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            return IWSEntities.Vats.FirstOrDefault(c =>
                    c.CompanyID == companyID && c.PVat == pvat)
                    .outputvataccountid;
        }
        public static string GetHeaderText(int id, string ItemType)
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            if (ItemType.Equals(DocsType.GoodReceiving.ToString()))
            {
                return IWSEntities.PurchaseOrders.FirstOrDefault(c =>
                c.id == id && c.CompanyId == companyID).HeaderText ?? "N/A";
            }
            if (ItemType.Equals(DocsType.InventoryInvoice.ToString()))
            {
                return IWSEntities.GoodReceivings.FirstOrDefault(c =>
                c.id == id && c.CompanyId == companyID).HeaderText ?? "N/A";
            }
            if (ItemType.Equals(DocsType.BillOfDelivery.ToString()))
            {
                return IWSEntities.SalesOrders.FirstOrDefault(c =>
                c.id == id && c.CompanyId == companyID).HeaderText ?? "N/A";
            }
            if (ItemType.Equals(DocsType.SalesInvoice.ToString()))
            {
                return IWSEntities.BillOfDeliveries.FirstOrDefault(c =>
                c.id == id && c.CompanyId == companyID).HeaderText ?? "N/A";
            }
            if (ItemType.Equals(DocsType.VendorInvoice.ToString()))
            {
                return IWSEntities.InventoryInvoices.FirstOrDefault(c =>
                c.id == id && c.CompanyId == companyID).HeaderText ?? "N/A";
            }
            if (ItemType.Equals(DocsType.CustomerInvoice.ToString()))
            {
                return IWSEntities.SalesInvoices.FirstOrDefault(c =>
                c.id == id && c.CompanyId == companyID).HeaderText ?? "N/A";
            }
            if (ItemType.Equals(DocsType.Settlement.ToString()))
            {
                return IWSEntities.CustomerInvoices.FirstOrDefault(c =>
                c.id == id && c.CompanyId == companyID).HeaderText ?? "N/A";
            }
            if (ItemType.Equals(DocsType.Payment.ToString()))
            {
                return IWSEntities.VendorInvoices.FirstOrDefault(c =>
                c.id == id && c.CompanyId == companyID).HeaderText ?? "N/A";
            }
            if (ItemType.Equals(DocsType.GeneralLedgerIn.ToString()))
            {
                return IWSEntities.Settlements.FirstOrDefault(c =>
                c.id == id && c.CompanyId == companyID).HeaderText ?? "N/A";
            }
            if (ItemType.Equals(DocsType.GeneralLedgerOut.ToString()))
            {
                return IWSEntities.Payments.FirstOrDefault(c =>
                c.id == id && c.CompanyId == companyID).HeaderText ?? "N/A";
            }
            return null;
        }

        public static string GetHeaderText(int itemId, int modelId)
        {
            string companyId = (string)HttpContext.Current.Session["CompanyID"];

            string headerText = String.Empty;
            if (modelId.Equals((int)LogisticMasterModelId.GoodReceiving) ||
               (modelId.Equals((int)LogisticMasterModelId.InventoryInvoice)) ||
               (modelId.Equals((int)LogisticMasterModelId.BillOfDelivery)) ||
               (modelId.Equals((int)LogisticMasterModelId.SalesInvoice)) ||
               (modelId.Equals((int)ComptaMasterModelId.VendorInvoice)) ||
               (modelId.Equals((int)ComptaMasterModelId.CustomerInvoice)))
            {
                headerText = IWSEntities.MasterLogistics.FirstOrDefault(item => 
                                                item.id.Equals(itemId) && 
                                                item.CompanyId.Equals(companyId)).HeaderText ?? "N/A";
            }
            if (modelId.Equals((int)ComptaMasterModelId.Payment) ||
                modelId.Equals((int)ComptaMasterModelId.Settlement))
            {
                headerText = IWSEntities.MasterComptas.FirstOrDefault(item =>
                                item.id.Equals(itemId) &&
                                item.CompanyId.Equals(companyId)).HeaderText ?? "N/A";
            }
            return headerText;
        }
        public static string GetCostCenter(int itemId, int modelId)
        {
            string companyId = (string)HttpContext.Current.Session["CompanyID"];

            string costCenter = String.Empty;

            if (modelId.Equals((int)ComptaMasterModelId.Payment) ||
                modelId.Equals((int)ComptaMasterModelId.Settlement))
            {

            costCenter = IWSEntities.MasterComptas.FirstOrDefault(item =>
                                            item.id.Equals(itemId) &&
                                            item.CompanyId.Equals(companyId)).CostCenter ?? "N/A";
            }
            return costCenter;
        }
        public static string GetStore(int itemId)
        {
            string companyId = (string)HttpContext.Current.Session["CompanyID"];

            return IWSEntities.MasterLogistics.FirstOrDefault(item =>
                                         item.id.Equals(itemId) &&
                                         item.CompanyId.Equals(companyId)).store ?? "N/A";
        }
        public static string GetAccount(int itemId, int modelId)
        {
            string account = String.Empty;
            string companyId = (string)HttpContext.Current.Session["CompanyID"];

            if (modelId.Equals((int)LogisticMasterModelId.GoodReceiving) ||
               (modelId.Equals((int)LogisticMasterModelId.InventoryInvoice)) ||
               (modelId.Equals((int)LogisticMasterModelId.BillOfDelivery)) ||
               (modelId.Equals((int)LogisticMasterModelId.SalesInvoice)))
            {
                account = IWSEntities.MasterLogistics.FirstOrDefault(item =>
                            item.id.Equals(itemId) &&
                            item.CompanyId.Equals(companyId)).account ?? "N/A";
            }

            if (modelId.Equals((int)ComptaMasterModelId.VendorInvoice))
            {
                account = IWSEntities.MasterLogistics.Join(IWSEntities.Suppliers,
                            v => v.account, s => s.id, (v, s) => new
                            {
                                AccountId = s.accountid,
                                ItemId = v.id,
                                CompanyId = s.CompanyID
                            }).FirstOrDefault(d =>
                            d.CompanyId.Equals(companyId) && d.ItemId.Equals(itemId)).AccountId;
            }

            if (modelId.Equals((int)ComptaMasterModelId.CustomerInvoice))
            {
                account = IWSEntities.MasterLogistics.Join(IWSEntities.Customers,
                        v => v.account, s => s.id, (v, s) => new
                        {
                            AccountId = s.accountid,
                            ItemId = v.id,
                            CompanyId = s.CompanyID
                        }).FirstOrDefault(d =>
                        d.CompanyId.Equals(companyId) && d.ItemId.Equals(itemId)).AccountId;
            }

            if (modelId.Equals((int)ComptaMasterModelId.Payment) ||
                (modelId.Equals((int)ComptaMasterModelId.Settlement)))
            {
                account = IWSEntities.MasterComptas.FirstOrDefault(item =>
                        item.id.Equals(itemId) &&
                        item.CompanyId.Equals(companyId)).account ?? "N/A";
            }
            return account;
        }
        public static string GetStore(int id, string ItemType)
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            if (ItemType.Equals(DocsType.GoodReceiving.ToString()))
            {
                
                return IWSEntities.PurchaseOrders.FirstOrDefault(c =>
                c.id == id && c.CompanyId == companyID).store;
            }
            if (ItemType.Equals(DocsType.InventoryInvoice.ToString()))
            {
                return IWSEntities.GoodReceivings.FirstOrDefault(c =>
                c.id == id && c.CompanyId == companyID).store;
            }
            if (ItemType.Equals(DocsType.BillOfDelivery.ToString()))
            {
                return IWSEntities.SalesOrders.FirstOrDefault(c =>
                c.id == id && c.CompanyId == companyID).store;
            }
            if (ItemType.Equals(DocsType.SalesInvoice.ToString()))
            {
                return IWSEntities.BillOfDeliveries.FirstOrDefault(c =>
                c.id == id && c.CompanyId == companyID).store;
            }
            return null;
           
        }

        public static string GetSupplier(int id, string ItemType)
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            if (ItemType.Equals(IWSLookUp.DocsType.GoodReceiving.ToString()))
            {
                return IWSEntities.PurchaseOrders.FirstOrDefault(c =>
                c.id == id && c.CompanyId == companyID).account;
            }
            if (ItemType.Equals(IWSLookUp.DocsType.InventoryInvoice.ToString()))
            {
                return IWSEntities.GoodReceivings.FirstOrDefault(c =>
                c.id == id && c.CompanyId == companyID).account;
            }
            if (ItemType.Equals(IWSLookUp.DocsType.BillOfDelivery.ToString()))
            {
                return IWSEntities.SalesOrders.FirstOrDefault(c =>
                c.id == id && c.CompanyId == companyID).account;
            }
            if (ItemType.Equals(IWSLookUp.DocsType.SalesInvoice.ToString()))
            {
                return IWSEntities.BillOfDeliveries.FirstOrDefault(c =>
                c.id == id && c.CompanyId == companyID).account;
            }
            if (ItemType.Equals(IWSLookUp.DocsType.VendorInvoice.ToString()))
            {
                return IWSEntities.InventoryInvoices.FirstOrDefault(c =>
                c.id == id && c.CompanyId == companyID).account;
            }
            if (ItemType.Equals(IWSLookUp.DocsType.CustomerInvoice.ToString()))
            {
                return IWSEntities.SalesInvoices.FirstOrDefault(c =>
                c.id == id && c.CompanyId == companyID).account;
            }
            if (ItemType.Equals(IWSLookUp.DocsType.Settlement.ToString()))
            {
                return IWSEntities.CustomerInvoices.FirstOrDefault(c =>
                c.id == id && c.CompanyId == companyID).account;
            }
            if (ItemType.Equals(IWSLookUp.DocsType.Payment.ToString()))
            {
                return IWSEntities.VendorInvoices.FirstOrDefault(c =>
                c.id == id && c.CompanyId == companyID).account;
            }
            if (ItemType.Equals(IWSLookUp.DocsType.GeneralLedgerIn.ToString()))
            {
                return IWSEntities.Settlements.FirstOrDefault(c =>
                c.id == id && c.CompanyId == companyID).account;
            }
            if (ItemType.Equals(IWSLookUp.DocsType.GeneralLedgerOut.ToString()))
            {
                return IWSEntities.Payments.FirstOrDefault(c =>
                c.id == id && c.CompanyId == companyID).account;
            }
            return null;
        }
        public static string GetCostCenter(int id, string ItemType)
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];

            if (ItemType.Equals(IWSLookUp.DocsType.Settlement.ToString()))
            {
                return IWSEntities.CustomerInvoices.FirstOrDefault(c =>
                c.id == id && c.CompanyId == companyID).CostCenter;
            }
            if (ItemType.Equals(IWSLookUp.DocsType.Payment.ToString()))
            {
                return IWSEntities.VendorInvoices.FirstOrDefault(c =>
                c.id == id && c.CompanyId == companyID).CostCenter;
            }
            if (ItemType.Equals(IWSLookUp.DocsType.GeneralLedgerIn.ToString()))
            {
                return IWSEntities.Settlements.FirstOrDefault(c =>
                c.id == id && c.CompanyId == companyID).CostCenter;
            }
            if (ItemType.Equals(IWSLookUp.DocsType.GeneralLedgerOut.ToString()))
            {
                return IWSEntities.Payments.FirstOrDefault(c =>
                c.id == id && c.CompanyId == companyID).CostCenter;
            }
            return null;
        }

        public static IEnumerable GetGoodReceivingOID()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            var query =
            from s in IWSEntities.Stores
            join p in IWSEntities.PurchaseOrders on new {  s.id } equals new { id = p.store }
            join r in IWSEntities.Suppliers on new {  p.account } equals new { account = r.id }
            where
              p.CompanyId == companyID
            orderby
              p.id
            select new
            {
                ID = p.id,
                Supplier = r.name,
                Store = s.name,
                DueDate = p.ItemDate.ToShortDateString()
            };
            return query;
        }
        public static IEnumerable GetInventoryInvoiceOID()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            var query =
            from s in IWSEntities.Stores
            join g in IWSEntities.GoodReceivings on new {  s.id } equals new { id = g.store }
            join r in IWSEntities.Suppliers on new {  g.account } equals new { account = r.id }
            where
              g.CompanyId == companyID
            orderby
              g.id
            select new
            {
                ID = g.id,
                Supplier = r.name,
                Store = s.name,
                DueDate = g.ItemDate.ToShortDateString()
            };
            return query;
        }
        public static IEnumerable GetVendorInvoiceOID()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            var query =
            from s in IWSEntities.Stores
            join p in IWSEntities.InventoryInvoices on new {  s.id } equals new { id = p.store }
            join r in IWSEntities.Suppliers on new {  p.account } equals new { account = r.id }
            where
              p.CompanyId == companyID
            orderby
              p.id
            select new
            {
                ID = p.id,
                Supplier = r.name,
                Store = s.name,
                DueDate = p.ItemDate.ToShortDateString()
            };
            return query;
        }
        public static IEnumerable GetPaymentOID()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            var query =
            from s in IWSEntities.CostCenters
            join p in IWSEntities.VendorInvoices on new {  s.id } equals new { id = p.CostCenter }
            join r in IWSEntities.Suppliers on new {  p.account } equals new { account = r.id }
            where
              p.CompanyId == companyID
            orderby
              p.id
            select new
            {
                ID = p.id,
                Supplier = r.name,
                Store = s.name,
                DueDate = p.ItemDate.ToShortDateString()
            };
            return query;
        }
        public static IEnumerable GetBillOfDeliveryOID()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            var query =
            from s in IWSEntities.Stores
            join p in IWSEntities.SalesOrders on new {  s.id } equals new { id = p.store }
            join r in IWSEntities.Customers on new {  p.account } equals new { account = r.id }
            where
              p.CompanyId == companyID
            orderby
              p.id
            select new
            {
                ID = p.id,
                Customer = r.name,
                Store = s.name,
                DueDate = p.ItemDate.ToShortDateString()
            };
            return query;
        }
        public static IEnumerable GetSalesInvoiceOID()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            var query =
            from s in IWSEntities.Stores
            join p in IWSEntities.BillOfDeliveries on new {  s.id } equals new { id = p.store }
            join r in IWSEntities.Customers on new {  p.account } equals new { account = r.id }
            where
              p.CompanyId == companyID
            orderby
              p.id
            select new
            {
                ID = p.id,
                Customer = r.name,
                Store = s.name,
                DueDate = p.ItemDate.ToShortDateString()
            };
            return query;
        }
        public static IEnumerable GetCustomerInvoiceOID()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            var query =
            from s in IWSEntities.Stores
            join p in IWSEntities.SalesInvoices on new {  s.id } equals new { id = p.store }
            join r in IWSEntities.Customers on new {  p.account } equals new { account = r.id }
            where
              p.CompanyId == companyID
            orderby
              p.id
            select new
            {
                ID = p.id,
                Customer = r.name,
                Store = s.name,
                DueDate = p.ItemDate.ToShortDateString()
            };
            return query;
        }
        public static IEnumerable GetSettlementOID()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            var query =
            from s in IWSEntities.CostCenters
            join p in IWSEntities.CustomerInvoices on new {  s.id } equals new { id = p.CostCenter }
            join r in IWSEntities.Customers on new {  p.account } equals new { account = r.id }
            where
              p.CompanyId == companyID
            orderby
              p.id
            select new
            {
                ID = p.id,
                Customer = r.name,
                CostCenter = s.name,
                DueDate = p.ItemDate.ToShortDateString()
            };
            return query;
        }
        public static IEnumerable GetGeneralLedgerInOID()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            var q =
            from s in IWSEntities.CostCenters
            join p in IWSEntities.Settlements on new {  s.id } equals new { id = p.CostCenter }
            join r in IWSEntities.Customers on new {  p.account } equals new { account = r.id }
            where
              p.CompanyId == companyID
            orderby
              p.id
            select new
            {
                ID = p.id,
                Customer = r.name,
                CostCenter = s.name,
                DueDate = p.ItemDate.ToShortDateString()
            };
            return q;
        }
        public static IEnumerable GetGeneralLedgerOutOID()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            var query =
            from s in IWSEntities.CostCenters
            join p in IWSEntities.Payments on new {  s.id } equals new { id = p.CostCenter }
            join r in IWSEntities.Suppliers on new {  p.account } equals new { account = r.id }
            where
              p.CompanyId == companyID
            orderby
              p.id
            select new
            {
                ID = p.id,
                Customer = r.name,
                CostCenter = s.name,
                DueDate = p.ItemDate.ToShortDateString()
            };
            return query;
        }
        public static void LogException(Exception ex)
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            HttpContext context = HttpContext.Current;
            string msg = ex.Message.ToString();
            string type = ex.GetType().Name.ToString();
            string source = ex.Source.ToString();
            string url = context.Request.Url.ToString();
            string target = ex.TargetSite.Name.ToString();
            string userName = (string)HttpContext.Current.Session["UserName"];
            int result = IWSEntities.LogException(msg, type, source, url, target, companyID, userName);
        }
        public static string GetModelSateErrors(System.Web.Mvc.ModelStateDictionary modelState)
        {
            return string.Join("; ", modelState.Values
                                       .SelectMany(x => x.Errors)
                                       .Select(x => x.ErrorMessage));
        }
        public static List<string> GetModelSateErrorsList(System.Web.Mvc.ModelStateDictionary modelState)
        {
            var errors = from state in modelState.Values
                        from error in state.Errors
                        select error.ErrorMessage;
            return errors.ToList();
        }

        public static List<LinePurchaseOrder> GetLinePurchaseOrders(int transId) => IWSEntities.LinePurchaseOrders.Where(c =>
            c.transid == transId).ToList<LinePurchaseOrder>();
        
        public enum DocsType
        {
            SalesInvoice,
            SalesOrder,
            BillOfDelivery,
            GoodReceiving,
            InventoryInvoice,
            Payment,
            PurchaseOrder,
            CustomerInvoice,
            Settlement,
            VendorInvoice,
            GeneralLedger,
            GeneralLedgerIn,
            GeneralLedgerOut,
            BankStatement,
            Cash,
            Brouillard,
            Default
        }

        public enum MetaModelId
        {
            Article = 2000,
            Banks = 2005,
            Customer = 2010,
            Account = 2015,
            Company = 2020,
            CostCenter = 2025,
            QuantityUnit = 2030,
            Store = 2035,
            Supplier = 2040,
            VAT = 2045,
            Currency = 2050,
            Default = 0000
        }
        public enum LogisticMasterModelId
        {
            PurchaseOrder = 3000,
            GoodReceiving = 3005,
            InventoryInvoice = 3010,
            SalesOrder = 3500,
            BillOfDelivery = 3505,
            SalesInvoice = 3510,
            Default=0000
        }
        public enum LogisticDetailModelId
        {
            LinePurchaseOrder = 4000,
            LineGoodReceiving = 4005,
            LineInventoryInvoice = 4010,
            LineSalesOrder = 4500,
            LineBillOfDelivery = 4505,
            LineSalesInvoice = 4010,
            Default = 0000
        }
        public enum ComptaMasterModelId
        {
            VendorInvoice = 5000,
            Payment = 5005,
            CustomerInvoice = 5500,
            Settlement = 5505,
            GeneralLedger = 5800,
            Default = 0000
        }
        public enum ComptaDetailModelId
        {
            LineVendorInvoice = 6000,
            LineCustomerInvoice = 6005,
            LinePayment = 6010,
            LineSettlement = 6015,
            LineGeneralLedger = 6020,
            Default = 0000
        }
        public enum Side
        {
            Credit,
            Debit
        }
        public enum Area
        {
            GeneralLedger,
            Purchasing,
            Sales
        }
        public enum Owner
        {
            Company,
            Customer,
            Supplier
        }

        private static DateTime StringToDate(string stringDate)
        {
            string y = "20" + stringDate.Substring(4, 2);
            string m = stringDate.Substring(2, 2);
            string d = stringDate.Substring(0, 2);
            string x = y + '-' + m + '-' + d;
            return Convert.ToDateTime(x);
         }

        private static Decimal StringToDecimal(string amount)
        {
            if (string.IsNullOrEmpty(amount))
                amount = "0";
            return Convert.ToDecimal(amount, CultureInfo.GetCultureInfo(Thread.CurrentThread.CurrentUICulture.Name).NumberFormat );
        }

    }
}