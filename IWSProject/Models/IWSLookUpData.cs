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
    using IWSProject.Models.Entities;


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
        public static IEnumerable GetUnPaidBill(ComptaMasterModelId modelId, bool balanced)
        {
            int cashing = 0;
            if (modelId.Equals(ComptaMasterModelId.VendorInvoice))
            {
                cashing = (int)ComptaMasterModelId.Payment;
            }
            if (modelId.Equals(ComptaMasterModelId.CustomerInvoice))
            {
                cashing = (int)ComptaMasterModelId.Settlement;
            }
            #region VI/CI
            var bill = (from d in IWSEntities.DetailComptas
                        where
                          d.Balanced == balanced &&
                          d.ModelId == (int)modelId &&
                          d.MasterCompta.IsValidated == true
                        select new
                        {
                            d.id, d.transid, d.account, d.side, d.oaccount, d.amount, paid=0, topay=0,
                            d.duedate, d.text, d.Currency, d.ModelId, d.Terms
                        }).ToList();
            #endregion
            #region PT/ST
            var paid = (from c in IWSEntities.DetailComptas
                      join d in IWSEntities.DetailDetailComptas on new { c.id } equals new { id = d.TransId }
                      where
                        c.MasterCompta.IsValidated == true &&
                        d.ModelId == cashing
                      group new { c, d } by new
                      {
                          c.transid,
                          d.OID
                      } into g
                      select new
                      {
                          TransId = g.Key.transid,
                          g.Key.OID,
                          paid = (decimal?)g.Sum(p => p.d.Amount) ?? 0
                      }).ToList();
            #endregion
            if (paid.Any()) { 
            var unpaid = (from m in bill
                         join d in paid
                         on new { m.id } equals new { id = d.OID } into djoin
                          from ds in djoin.DefaultIfEmpty()
                         select new
                         {
                             id= ds != null ? ds.TransId : 0, m.transid, m.account, m.side, m.oaccount, m.duedate, m.text, m.amount,
                             paid = ds != null ? Convert.ToDecimal(ds?.paid ?? 0, CultureInfo.GetCultureInfo(Thread.CurrentThread.CurrentUICulture.Name).NumberFormat) : 0,
                             topay= ds != null ? m.amount - Convert.ToDecimal(ds?.paid ?? 0, CultureInfo.GetCultureInfo(Thread.CurrentThread.CurrentUICulture.Name).NumberFormat) : m.amount,
                             m.Currency, m.ModelId
                         }).ToList();
            return unpaid;
            }
            return from d in bill
                   select new
                   {
                       d.id,  d.transid, d.account, d.side, d.oaccount, d.amount, paid = 0, topay = d.amount,
                       d.duedate, d.text, d.Currency, d.ModelId, d.Terms
                   };
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
        public static decimal GetLeftToPay(int invoiceId)
        {
            var initialInvoice = IWSEntities.DetailComptas.FirstOrDefault(o => o.id == invoiceId).amount;

            var cumulatedPaid = IWSEntities.DetailDetailComptas.Where(o => o.OID == invoiceId);
            if (cumulatedPaid.Any())
            {
                return initialInvoice-cumulatedPaid.Sum(o => o.Amount);
            }
            return initialInvoice;
        }
        public static bool CheckIfBalanced(int invoiceId)
        {
            var initialInvoice = IWSEntities.DetailComptas.FirstOrDefault(o => o.id == invoiceId).amount;

            var cumulatedPaid = IWSEntities.DetailDetailComptas.Where(o => o.OID == invoiceId);

            return true;// initialInvoice == cumulatedPaid.Sum(o => o.Amount);
        }


        public static IEnumerable GetAccount()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            return IWSEntities.GetAccounts().Where(c => c.CompanyID == companyID);
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
            return "9999";
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
        public static string GetComptaDetailCaption(int ModeliD)
        {
            ComptaMasterModelId caption = (ComptaMasterModelId)ModeliD;

            return caption.ToString();
        }
        public static IEnumerable GetAccounts()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            var account = IWSEntities.GetAccounts().AsEnumerable().Select(i => new
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
        public static IEnumerable GetAsset()
        {
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            var account = IWSEntities.Assets.AsEnumerable().Select(i => new
            {
                i.Id,
                i.Name,
                i.CompanyId
            })
            .Where(c => c.CompanyId == companyID)
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
                   from a in IWSEntities.GetAccounts()
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

            return IWSEntities.Suppliers.Join(IWSEntities.GetAccounts(),
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

            return IWSEntities.Customers.Join(IWSEntities.GetAccounts(),
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
        public static IEnumerable GetDepreciationPeriods()
        {
            var u = (from p in IWSEntities.Depreciations
                join d in IWSEntities.DepreciationDetails on new { p.Id } equals new { Id = d.TransId }
                where
                  p.CompanyId == (string)HttpContext.Current.Session["CompanyID"]
                select new
                {
                    d.Period
                }).Distinct();
            return u;
        }
        public static IEnumerable GetDepreciation(string period, string assetIds)
        {
            string[] IDs = assetIds.Split(';');
            return from p in IWSEntities.Assets
                   join d in IWSEntities.DepreciationDetails on new { p.Id } equals new { Id = d.TransId }
                   where
                     Convert.ToInt32(d.Period) <= Convert.ToInt32(period) &&
                     IDs.Contains(p.Id) &&
                     p.CompanyId == (string)HttpContext.Current.Session["CompanyID"]
                   select new
                   {
                       d.Id,
                       TransId = p.Id,
                       Asset = p.Name,
                       d.Period,
                       d.BookValue,
                       d.Depreciation,
                       d.Currency,
                       d.IsValidated
                   };
        }
        public static IEnumerable GetDepreciation(string period, DepreciationType depreciationType)
        {
            if (depreciationType.Equals(DepreciationType.Degressive))
            {
                return from p in IWSEntities.Depreciations
                       join d in IWSEntities.DepreciationDetails on new { p.Id } equals new { Id = d.TransId }
                       where
                         d.Period == period &&
                         p.CompanyId == (string)HttpContext.Current.Session["CompanyID"]
                       select new
                       {
                           p.Id,
                           p.Asset,
                           p.CostOfAsset,
                           d.Period,
                           d.BookValue,
                           d.Depreciation,
                           d.Currency,
                           d.IsValidated
                       };
            }
            if (depreciationType.Equals(DepreciationType.StraightLine))
            {
                return from p in IWSEntities.Depreciations
                       join d in IWSEntities.DepreciationDetails on new { p.Id } equals new { Id = d.TransId }
                       where
                         d.Period == period &&
                         p.CompanyId == (string)HttpContext.Current.Session["CompanyID"]
                       select new
                       {
                           p.Id,
                           p.Asset,
                           p.CostOfAsset,
                           d.Period,
                           d.BookValue,
                           d.Depreciation,
                           d.Currency,
                           d.IsValidated
                       };
            }
            return null;
        }
        public static ImmoDetailViewModel GetImmoDetail(string IDs, string period)
        {
            string companyId = (string)HttpContext.Current.Session["CompanyID"]; 
            ImmoDetailViewModel detail = 
                (from d in IWSEntities.Assets
                 join p in IWSEntities.DepreciationDetails on new { d.Id } equals new { Id = p.TransId }
                 where
                     IDs.Equals(p.TransId) &&
                     p.Period == period &&
                     d.CompanyId == companyId
                 select new ImmoDetailViewModel()
                 {
                     CostCenter = "100",
                     TransDate = DateTime.Now,
                     ItemDate = DateTime.Now,
                     EntryDate = DateTime.Now,
                     Account = d.Account,
                     Side = true,
                     OAccount = d.OAccount,
                     DueDate = DateTime.Now,
                     CompanyId = d.CompanyId,
                     Currency = d.Currency
                 }).SingleOrDefault<ImmoDetailViewModel>();
            return detail;
        }
        public static List<ImmoDetailViewModel> GetImmoDetail(string[] IDs, string period)
        {

            string companyId = (string)HttpContext.Current.Session["CompanyID"];
            List<ImmoDetailViewModel> detail = new List<ImmoDetailViewModel>
                (from d in IWSEntities.Assets
                 join p in IWSEntities.DepreciationDetails on new { d.Id } equals new { Id = p.TransId }
                 where
                     IDs.Contains(p.TransId) &&
                     p.Period == period &&
                     d.CompanyId == companyId
                 select new ImmoDetailViewModel()
                 {
                     CostCenter = "100",
                     TransDate = DateTime.Now,
                     ItemDate = DateTime.Now,
                     EntryDate = DateTime.Now,
                     Account = d.Account,
                     Side = true,
                     OAccount = d.OAccount,
                     DueDate = DateTime.Now,
                     CompanyId = d.CompanyId,
                     Currency = d.Currency
                 });
            return detail;
        }
        //public static List<ImmoDetailViewModel> GetImmoDetail(string[] IDs, string period)
        //{       
        //    string companyId = (string)HttpContext.Current.Session["CompanyID"];
        //    List<ImmoDetailViewModel> detail = new List<ImmoDetailViewModel>
        //        (from d in IWSEntities.Depreciations
        //            join p in IWSEntities.DepreciationDetails on new { d.Id } equals new { Id = p.TransId }
        //            where
        //                IDs.Contains(p.TransId) &&
        //                p.Period == period &&
        //                d.CompanyId == companyId
        //            select new ImmoDetailViewModel()
        //            {
        //                CostCenter ="100",
        //                TransDate = DateTime.Now,
        //                ItemDate = DateTime.Now,
        //                EntryDate = DateTime.Now,
        //                Account = d.Account,
        //                Side = true,
        //                OAccount = d.OAccount,
        //                DueDate = DateTime.Now,
        //                CompanyId = d.CompanyId,
        //                Currency = d.Currency
        //            });
        //    return detail;
        //}
        public static IEnumerable GetDepreciation() =>
            IWSEntities.Depreciations.Where(c => 
            c.CompanyId == (string)HttpContext.Current.Session["CompanyID"]).AsEnumerable();
        public static IEnumerable GetDepreciationDetail(string transId) => IWSEntities.DepreciationDetails.Where(c =>
                        c.TransId == transId).
                        OrderBy(o => o.Id).AsEnumerable();


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

        public static IEnumerable GetMasterLogistic(LogisticMasterModelId modelId) => 
                        IWSEntities.MasterLogistics.Where(c =>
                        c.CompanyId == (string)HttpContext.Current.Session["CompanyID"] &&
                        c.ModelId == (int)modelId).OrderByDescending(o => o.id).AsEnumerable();

        public static IEnumerable GetMasterCompta(ComptaMasterModelId modelId) => 
                        IWSEntities.MasterComptas.Where(c =>
                        c.CompanyId == (string)HttpContext.Current.Session["CompanyID"] &&
                        c.ModelId == (int)modelId).OrderByDescending(o => o.id).AsEnumerable();

        public static IEnumerable GetDetailLogistic(int transId) => IWSEntities.DetailLogistics.Where(c =>
                                c.transid == transId).
                                OrderByDescending(o => o.id).AsEnumerable();
        public static IEnumerable GetDetailCompta(int transId) => IWSEntities.DetailComptas.Where(c =>
                          c.transid == transId).
                          OrderByDescending(o => o.id).AsEnumerable();

        public static IEnumerable GetDetailDetailCompta(int transId, int modeliId) => IWSEntities.DetailDetailComptas.Where(c =>
                  c.TransId== transId && c.ModelId == modeliId).OrderByDescending(o => o.Id).AsEnumerable();

        public static IEnumerable GetMasterLogisticOID()
        {
            int modelId = (int)HttpContext.Current.Session["ModelId"];

            string companyId = (string)HttpContext.Current.Session["CompanyID"];

            if (modelId.Equals((int)LogisticMasterModelId.GoodReceiving))
            {
                return
                from store in IWSEntities.Stores
                join master in IWSEntities.MasterLogistics on new { store.id } equals new { id = master.store }
                join Owner in IWSEntities.Suppliers on new { master.account } equals new { account = Owner.id }
                where
                  master.CompanyId == companyId &&
                  master.ModelId == (int)LogisticMasterModelId.PurchaseOrder
                orderby
                  master.id
                select new
                {
                    ID = master.id,
                    Name = Owner.name,
                    Store = store.name,
                    DueDate = master.ItemDate.ToShortDateString()
                };
            }
            if (modelId.Equals((int)LogisticMasterModelId.InventoryInvoice))
            {
                return
                from store in IWSEntities.Stores
                join master in IWSEntities.MasterLogistics on new { store.id } equals new { id = master.store }
                join Owner     in IWSEntities.Suppliers on new { master.account } equals new { account = Owner.id }
                where
                  master.CompanyId == companyId &&
                  master.ModelId == (int)LogisticMasterModelId.GoodReceiving
                orderby
                  master.id
                select new
                {
                    ID = master.id,
                    Name = Owner.name,
                    Store = store.name,
                    DueDate = master.ItemDate.ToShortDateString()
                };
            }
            if (modelId.Equals((int)LogisticMasterModelId.BillOfDelivery))
            {
                return from store in IWSEntities.Stores
                       join master in IWSEntities.MasterLogistics on new { store.id } equals new { id = master.store }
                        join Ownser in IWSEntities.Customers on new { master.account } equals new { account = Ownser.id }
                        where
                            master.CompanyId == companyId &&
                            master.ModelId == (int)LogisticMasterModelId.SalesOrder
                        orderby
                            master.id
                        select new
                        {
                            ID = master.id,
                            Name = Ownser.name,
                            Store = store.name,
                            DueDate = master.ItemDate.ToShortDateString()
                        };
            }
            if (modelId.Equals((int)LogisticMasterModelId.SalesInvoice))
            {
                return from store in IWSEntities.Stores
                       join master in IWSEntities.MasterLogistics on new { store.id } equals new { id = master.store }
                        join Ownser in IWSEntities.Customers on new { master.account } equals new { account = Ownser.id }
                        where
                          master.CompanyId == companyId &&
                          master.ModelId == (int)LogisticMasterModelId.BillOfDelivery
                        orderby
                          master.id
                        select new
                        {
                            ID = master.id,
                            Name = Ownser.name,
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
                join account in IWSEntities.Suppliers on new { master.account } equals new { account = account.id }
                where
                  master.CompanyId == companyId &&
                  master.ModelId == (int)LogisticMasterModelId.InventoryInvoice
                orderby
                  master.id
                select new
                {
                    ID = master.id,
                    Name = account.name,
                    Store = store.name,
                    DueDate = master.ItemDate.ToShortDateString()
                };
            }
            if (modelId.Equals((int)ComptaMasterModelId.Payment))
            {
                return from center in IWSEntities.CostCenters
                join master in IWSEntities.MasterComptas on new { center.id } equals new { id = master.CostCenter }
                join account in IWSEntities.GetAccounts() on new { master.account } equals new { account = account.id }
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
                join account in IWSEntities.Customers on new { master.account } equals new { account = account.id }
                where
                  master.CompanyId == companyId &&
                  master.ModelId == (int)LogisticMasterModelId.SalesInvoice
                orderby
                  master.id
                select new
                {
                    ID = master.id,
                    Name = account.name,
                    Store = store.name,
                    DueDate = master.ItemDate.ToShortDateString()
                };
            }
            if (modelId.Equals((int)ComptaMasterModelId.Settlement))
            {
                return from center in IWSEntities.CostCenters
                join master in IWSEntities.MasterComptas on new { center.id } equals new { id = master.CostCenter }
                join account in IWSEntities.GetAccounts() on new { master.account } equals new { account = account.id }
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

        public static int GetMasterComptaOID(int detailComptaTransId) => 
            IWSEntities.MasterComptas.FirstOrDefault(o => o.id.Equals(detailComptaTransId)).oid;

        public static decimal CkeckIfAmountsBalanced(int masterId)
        {
            int model = (int)HttpContext.Current.Session["ModelId"];
            if(model.Equals((int)ComptaMasterModelId.Payment) || model.Equals((int)ComptaMasterModelId.Settlement))
            {
                return (from d in IWSEntities.DetailComptas
                        join dc in IWSEntities.DetailDetailComptas on new { d.id } equals new { id = dc.TransId } into groupJoin
                        from j in groupJoin.DefaultIfEmpty()
                        where
                          d.MasterCompta.id == masterId && d.ModelId == model
                        group new { d.MasterCompta, j } by new
                        {
                            oTotal = (decimal?)d.MasterCompta.oTotal
                        } into g
                        select new
                        {
                            Cummule = g.Sum(p => p.j.Amount)==null? 0 : g.Key.oTotal - g.Sum(p => p.j.Amount)
                        }).FirstOrDefault().Cummule.Value;
            }
            return 0;
        }
        public static IEnumerable GetDetailDetailComptaOID(int modelId, bool balanced)
        {
            int model = 0;
            int oid = (int)HttpContext.Current.Session["MasterComptaOID"];
            if (modelId.Equals((int)ComptaMasterModelId.Payment))
            {
                model = (int)ComptaMasterModelId.VendorInvoice;
            }
            if (modelId.Equals((int)ComptaMasterModelId.Settlement))
            {
                model = (int)ComptaMasterModelId.CustomerInvoice;
            }
            var result = IWSEntities.DetailComptas.Where(o => o.ModelId == model && o.amount != 0).Select(i => new
                            {
                                OID = i.id,
                                TransId = i.transid,
                                Account = i.account,
                                Side = i.side,
                                OAccount = i.oaccount,
                                LineAmount = i.amount.ToString("N2", CultureInfo.GetCultureInfo(Thread.CurrentThread
                                                        .CurrentUICulture.Name).NumberFormat),
                                i.Currency,
                                Text = i.text,
                                i.Balanced
                            }).OrderBy(o => o.OID);
            if (oid > 0)
            {
                if (!balanced)
                    return result.Where(b => b.Balanced == balanced && b.TransId==oid);
                return result.Where(b=>b.TransId==oid);
            }
            if (!balanced)
                return result.Where(b => b.Balanced == balanced);
            return result;
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
                            Currency=debit.Single().Currency, ModelId = modelId}
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
                         OTotal = l.oTotal, Currency = l.oCurrency,
                         ModelId = modelId
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
                    OVat = l.oVat, OTotal = l.oTotal, Currency = l.oCurrency,
                    ModelId = modelId
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
                             ModelId = modelId
                         });
            }
            if (modelId.Equals((int)ComptaMasterModelId.CustomerInvoice) ||

                modelId.Equals((int)ComptaMasterModelId.VendorInvoice))
            {
                lines = new List<DetailCompta>() {
                    new DetailCompta(){                                                                         /*  Single(x)*/
                        transid =itemId, account=debit.Single().ODebit, side=debit.Single().Side, oaccount=credit.First().OCreditVAT,
                        amount=(decimal)debit.Single().OVat, duedate=debit.Single().ItemDate, text=debit.Single().HeaderText,
                        Currency=debit.Single().Currency, ModelId = modelId},
                    new DetailCompta(){
                        transid =itemId, account=debit.Single().ODebit, side=debit.Single().Side, oaccount=debit.Single().OCredit,
                        amount=(decimal)debit.Single().OTotal, duedate=debit.Single().ItemDate, text=debit.Single().HeaderText,
                        Currency=debit.Single().Currency, ModelId = modelId}
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
                            Currency=debit.Single().Currency, ModelId = modelId
                        }
                };
            }

            return lines;
        }
        public static BeforeAmountViewModel GetBeforeAmount(string accountId, string period)
        {

            BeforeAmountViewModel amount = (from p in
                             (from item in IWSEntities.PeriodicAccountBalances
                              where
                                item.AccountId == accountId &&
                                item.Periode == period
                              select new
                              {
                                  item.Debit ,
                                  item.Credit,
                                  Dummy = "x"
                              })
                                             group p by new { p.Dummy } into g
                                             select new BeforeAmountViewModel()
                                             {
                                                 Debit = Convert.ToDecimal(g.Sum(p => p.Debit)),
                                                 Credit = Convert.ToDecimal(g.Sum(p => p.Credit))
                                             }).SingleOrDefault();
            if (amount == null)
            {
                amount = new BeforeAmountViewModel() { Debit = 0, Credit = 0 };

            }
            return amount;
        }
        public static List<DetailDetailViewModel> GetNewLineDetailDetail(int detailId, int OID, int modelId)
        {
            List<DetailDetailViewModel> detail = new List<DetailDetailViewModel>( from d in IWSEntities.DetailComptas
                                                     where
                                                       d.transid == OID
                                                     select new DetailDetailViewModel()
                                                     {
                                                         TransId = detailId,
                                                         OID = d.id,
                                                         Amount = d.amount,
                                                         ModelId = modelId
                                                     });

            return detail;
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

            var result = (from item in IWSEntities.PeriodicAccountBalances
                    where
                      item.CompanyID == companyId &&
                        (from f in IWSEntities.FiscalYears
                         where
                            f.CompanyId == companyId &&
                            f.Current == true &&
                            f.Open == true
                         select new
                         {
                             f.Period
                         }).Contains(new { Period = item.Periode })
                    select new
                    {
                        item.Id,                        item.AccountId,                     item.Name,                        item.Periode,
                        item.oYear,                     item.oMonth,                        item.Debit,                       item.Credit,
                        item.IDebit,                        item.ICredit,                   FDebit = item.Debit + item.IDebit,
                        FCredit = item.Credit + item.ICredit,  item.Currency,               item.CompanyID
                    }).ToList();
            return result;
        }

        public static IEnumerable GetFiscalYears(string companyId) => IWSEntities.GetFiscalYears(companyId).
                    Where(c => c.CompanyId == companyId).
                    Select(f => new
                    {
                        f.CompanyId,f.CStart,f.CEnd, f.OStart, f.OEnd
                    }).ToList();
        public static FiscalYearViewModel GetFiscalYear(string companyId) => IWSEntities.GetFiscalYears(companyId).
            Where(c => c.CompanyId == companyId).
            Select(f => new FiscalYearViewModel()
            {
                //CompanyId = f.CompanyId,
                CStart = f.CStart,
                CEnd = f.CEnd,
                OStart = f.OStart,
                OEnd = f.OEnd
            }).FirstOrDefault();

        public static IEnumerable GetCash() => IWSEntities.Cashes.Where(c =>
                        c.CompanyId == (string)HttpContext.Current.Session["CompanyID"]).
                        OrderByDescending(o => o.Id).AsEnumerable();

        public static IEnumerable GetTimeSheet() => IWSEntities.TimeSheets.Where(c =>
                c.CompanyId == (string)HttpContext.Current.Session["CompanyID"]).
                OrderByDescending(o => o.Id).AsEnumerable();

        public static List<TimeSheetLine> GetTimeSheetLines(int transId) => IWSEntities.TimeSheetLines.Where(c =>
                c.TransId == transId).ToList();

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
            ).Union
            (
            from ac in IWSEntities.GetAccounts()
            where
              (ac.CompanyID == companyID) && (ac.IsUsed.Equals(true))
            select new
            {
                Id = ac.id,
                Name = ac.name
            }
            ).OrderBy(p => p.Name);
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
                                string amount = usage.Substring(indexAmount, indexComma - indexAmount + 3).Trim().Replace(".","").Replace(",",".");

                                accountAmount.Add(new AccountAmountViewModel
                                {
                                    AccountCode = item.AccountCode,
                                    AccountAmount = Convert.ToDecimal(amount, CultureInfo.InvariantCulture)
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
        public static IEnumerable GetSuppliers(bool isCompta)
        {
            string companyId = (string)HttpContext.Current.Session["CompanyID"];
            if (isCompta)
            {
                return from a in IWSEntities.GetAccounts()
                       where
                                 ((from s in IWSEntities.Suppliers
                                   where
                                      s.CompanyID == companyId
                                   select new
                                   {
                                       s.accountid
                                   }).Distinct()).Contains(new { accountid = a.id })
                           select new
                           {
                               Id = a.id,
                               Name = a.name
                           };
            }
            else { 
                return IWSEntities.Suppliers.AsEnumerable().Select(item => new
                    {
                                Id = item.id,
                                Name = item.name,
                                Account = item.accountid,
                                item.CompanyID
                    })
                    .Where(c => c.CompanyID == companyId)
                    .OrderBy(o => o.Id);
            }
        }
        public static IEnumerable GetCustomers(bool isCompta)
        {
            string companyId = (string)HttpContext.Current.Session["CompanyID"];
            if (isCompta)
            {
                return from a in IWSEntities.GetAccounts()
                       where
                                 ((from c in IWSEntities.Customers
                                   where
                                      c.CompanyID == companyId
                                   select new
                                   {
                                       c.accountid
                                   }).Distinct()).Contains(new { accountid = a.id })
                           select new
                           {
                               Id = a.id,
                               Name = a.name
                           };
            }
            else
            {
                return IWSEntities.Customers.AsEnumerable().Select(item => new
                    {
                        Id = item.id,
                        Name = item.name,
                        Account = item.accountid,
                        item.CompanyID
                    })
                    .Where(c => c.CompanyID == companyId)
                    .OrderBy(o => o.Id);
            }
        }

        public static IEnumerable GetOwners(string isVending)
        {

            if (isVending == "SU")
            {
                return GetSuppliers(false);
            }
            if (isVending == "CU")
            {
                return GetCustomers(false);
            }
            return null;
        }

        public static IEnumerable GetAccounts(string isVending)
        {

            if (isVending == "SU")
            {
                return GetSuppliers(true);
            }
            if (isVending == "CU")
            {
                return GetCustomers(true);
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

        public static List<Asset> GetAssets() => IWSEntities.Assets.Where(c =>
                c.CompanyId == (string)HttpContext.Current.Session["CompanyID"]).ToList<Asset>();

        public static string YMToDate(string ymDate)
        {
            if (ymDate == null)
                return null;
            string y = ymDate.Substring(0, 4);
            string m = ymDate.Substring(4, 2);
            return y + "-" + m + "-01";
        }
        public static List<AssetViewModel> GetAssets(DateTime dateTimePeriod, string assetIds)
        {
            string[] IDs = assetIds.Split(';');
            string companyId = (string)HttpContext.Current.Session["CompanyID"];
            List<AssetViewModel> results = new List<AssetViewModel>();
            List<AssetViewModel> assets = new List<AssetViewModel>();
            AssetViewModel assetDate = new AssetViewModel();

            List<AssetViewModel> assetAccounts =  (from a in IWSEntities.Assets
                                where
                                IDs.Contains(a.Id)
                                select new AssetViewModel()
                                 {
                                     Account=a.Account,
                                     Frequency=(int)a.Frequency,
                                     Rate=(decimal)a.Rate
                                 }).ToList();

            foreach (var account in assetAccounts)
            {
                AssetViewModel asset = new AssetViewModel();

                assetDate = (from p in IWSEntities.PeriodicAccountBalances
                             where
                               p.AccountId == account.Account
                             orderby
                               p.Periode
                             select new AssetViewModel()
                             {
                                 Account = p.AccountId,
                                 Period = Convert.ToDateTime(YMToDate(p.Periode)),
                                 Frequency = account.Frequency
                             }).FirstOrDefault();

                if (assetDate != null)
                {
                    int lifeSpanYear = (dateTimePeriod.Year - assetDate.Period.Year) * 12;
                    int lifeSpanMonth = dateTimePeriod.Month - assetDate.Period.Month;

                    #region frequency=1
                    if (account.Frequency == 1)
                    {

                        asset =
                        (from a in IWSEntities.Assets
                         where
                         1 == 0  //update when frequency = 1 //
                         //((((dateTimePeriod.Year - assetDate.StartDate.Year) * 12) + dateTimePeriod.Month - assetDate.StartDate.Month) >= 12) && a.Account == assetDate.Account
                        select new AssetViewModel()
                         {
                             Id = a.Id,
                             Name = a.Name,
                             Account = a.Account,
                             OAccount = a.OAccount,
                             ScrapValue = (decimal)a.ScrapValue,
                             Period = dateTimePeriod,
                             LifeSpan = ((int)a.Frequency) * ((int)a.LifeSpan - (lifeSpanYear + lifeSpanMonth) + 1),
                             Frequency = (int)a.Frequency,
                             DepreciationType = (int)a.Depreciation,
                             Rate = account.Rate
                         }).SingleOrDefault();
                    }
                    #endregion

                    #region frequncy>1
                    if (account.Frequency > 1)
                    {
                        if (lifeSpanYear == 0)
                        {
                            lifeSpanMonth = 1;
                        }
                        else
                        {
                            lifeSpanMonth = 1 + (lifeSpanYear / account.Frequency);
                            lifeSpanYear = 0;
                        }
                        asset = 
                        (from a in IWSEntities.Assets
                         where
                         ((((dateTimePeriod.Year - assetDate.Period.Year) * 12) + dateTimePeriod.Month - assetDate.Period.Month) <= a.LifeSpan * assetDate.Frequency &&
                         (((dateTimePeriod.Year - assetDate.Period.Year) * 12) + dateTimePeriod.Month - assetDate.Period.Month) > 0 &&   a.Account == assetDate.Account)
                         select new AssetViewModel()
                         {
                             Id = a.Id,
                             Name = a.Name,
                             Account = a.Account,
                             OAccount = a.OAccount,
                             ScrapValue = (decimal)a.ScrapValue,
                             Period = dateTimePeriod,
                             AssetStartDate = assetDate.Period,
                             LifeSpan = ((int)a.Frequency) * ((int)a.LifeSpan - (lifeSpanYear + lifeSpanMonth) + 1),
                             Currency =  a.Currency,
                             Frequency = (int)a.Frequency,
                             DepreciationType = (int)a.Depreciation,
                             Rate = account.Rate,
                             CompanyId = companyId
                         }).SingleOrDefault();
                    }

                    #endregion

                    if(asset!=null)
                        assets.Add(asset);
                }
            }
            foreach (var asset in assets)
            {
                var item = (from b in IWSEntities.PeriodicAccountBalances
                               group b by new
                               {
                                   b.AccountId,
                                   b.Currency
                               } into g
                               where g.Key.AccountId == asset.Account
                               select new
                               {
                                   g.Key.AccountId,
                                   balance = (decimal?)g.Sum(p => p.Debit - p.Credit ),
                                   g.Key.Currency
                               }).FirstOrDefault();
                if(item != null)
                {
                    asset.BookValue = Math.Round((decimal)item.balance,2);
                    asset.Currency = item.Currency;
                    asset.ScrapValue = Math.Round(asset.ScrapValue,2);
                    if(asset != null)
                        results.Add(asset);
                }
            }
            return results;
        }

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

        public static StatementDetailViewModel GetStatementDetail(int bankStatementId, string itemType, string companyId)
        {
            try
            {
                if (itemType.Equals(IWSLookUp.ComptaMasterModelId.Settlement.ToString()))
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

                if (itemType.Equals(IWSLookUp.ComptaMasterModelId.Payment.ToString()))
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

                if (itemType.Equals(IWSLookUp.ComptaMasterModelId.GeneralLedger.ToString()))
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
                    b.CompanyID.Equals(companyID)
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
                    CompanyIBAN = b.CompanyIBAN, IsValidated = (bool)b.IsValidated
                }).ToList();
            return doc;
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
        public static IEnumerable GetAccountBalance(string start, string end, string accountId, string CompanyID)
        {
            List<AccountBalanceViewModel> items = new List<AccountBalanceViewModel>();
            items = (from p in IWSEntities.PeriodicBalances(start, end, accountId, CompanyID)
                     select new AccountBalanceViewModel()
                     {
                         AccountID = p.AccountId,
                         Name = p.Name,
                         Periode = p.Periode,
                         OYear = p.OYear,
                         OMonth = p.OMonth,
                         Debit = (decimal)p.Debit,
                         Credit = (decimal)p.Credit,
                         SDebit = (decimal)p.FDebit,
                         SCredit = (decimal)p.FCredit,
                         IDebit = (decimal)p.IDebit,
                         ICredit = (decimal)p.ICredit,
                         Currency = p.Currency,
                         CompanyID = p.CompanyId
                     }).Where(c => ExactMatch(accountId, c.AccountID)==true).OrderBy(o => o.AccountID).ThenBy(o => o.Periode).ToList();
            return items;
        }

        public static IEnumerable GetJournal(string start, string end, string accountId, string CompanyID)
        {

            string uiCulture = Thread.CurrentThread.CurrentUICulture.Name;
            List<JournalViewModel> journals = new List<JournalViewModel>();
            #region MyRegion

            if (accountId != "")
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
                                Info = j.Info,
                                TransDate = j.TransDate,
                                Periode = j.Periode,
                                oYear = j.OYear,
                                oMonth = j.oMonth,
                                Account = j.Account,
                                AccountName = j.AccountName,
                                OAccount = j.OAccount,
                                OAccountName = j.OAccountName,
                                Amount = j.Amount,
                                DebitBefore = j.DebitAvantImputationAmount,
                                CreditBefore = j.CreditAvantImputationAmount,
                                DebitAfter = j.DebitApresImputationAmount,
                                CreditAfter = j.CreditApresImputationAmount,
                                Side = j.Side,
                                Currency = j.Currency,
                                CompanyID = j.CompanyID,
                                TypeJournal = j.TypeJournal,
                            }).Where(c => (ExactMatch(accountId, c.Account) == true)).OrderBy(o => o.pk).ToList();

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
                                Info = j.Info,
                                TransDate = j.TransDate,
                                Periode = j.Periode,
                                oYear = j.OYear,
                                oMonth = j.oMonth,
                                Account = j.Account,
                                AccountName = j.AccountName,
                                OAccount = j.OAccount,
                                OAccountName = j.OAccountName,
                                Amount = j.Amount,
                                DebitBefore = j.DebitAvantImputationAmount,
                                CreditBefore = j.CreditAvantImputationAmount,
                                DebitAfter = j.DebitApresImputationAmount,
                                CreditAfter = j.CreditApresImputationAmount,
                                Side = j.Side,
                                Currency = j.Currency,
                                CompanyID = j.CompanyID,
                                TypeJournal = j.TypeJournal,
                            }).OrderBy(o => o.pk).ToList();
            }
            return journals;
            #endregion

        }


        public static IEnumerable GetJournal(string start, string end, string accountId, string CompanyID, bool side)
        {

            string uiCulture = Thread.CurrentThread.CurrentUICulture.Name;
            List<JournalViewModel> journals = new List<JournalViewModel>();
            #region MyRegion
            if (side == true)
            {
                if (accountId != "")
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
                                    Info = j.Info,
                                    TransDate = j.TransDate,
                                    ItemDate = j.ItemDate,
                                    EntryDate = j.EntryDate,
                                    Periode = j.Periode,
                                    oYear = j.OYear,
                                    oMonth = j.oMonth,
                                    Account = j.Account,
                                    AccountName = j.AccountName,
                                    OAccount = j.OAccount,
                                    OAccountName = j.OAccountName,
                                    Amount = j.Amount,
                                    DebitBefore = j.DebitAvantImputationAmount,
                                    CreditBefore = j.CreditAvantImputationAmount,
                                    DebitAfter = j.DebitApresImputationAmount,
                                    CreditAfter = j.CreditApresImputationAmount,
                                    Side = j.Side,
                                    Currency = j.Currency,
                                    CompanyID = j.CompanyID,
                                    TypeJournal = j.TypeJournal,
                                }).Where(c => (ExactMatch(accountId, c.Account) == true) && (c.Side == "Debit")).OrderBy(o => o.pk).ToList();

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
                                    Info = j.Info,
                                    TransDate = j.TransDate,
                                    ItemDate = j.ItemDate,
                                    EntryDate = j.EntryDate,
                                    Periode = j.Periode,
                                    oYear = j.OYear,
                                    oMonth = j.oMonth,
                                    Account = j.Account,
                                    AccountName = j.AccountName,
                                    OAccount = j.OAccount,
                                    OAccountName = j.OAccountName,
                                    Amount = j.Amount,
                                    DebitBefore = j.DebitAvantImputationAmount,
                                    CreditBefore = j.CreditAvantImputationAmount,
                                    DebitAfter = j.DebitApresImputationAmount,
                                    CreditAfter = j.CreditApresImputationAmount,
                                    Side = j.Side,
                                    Currency = j.Currency,
                                    CompanyID = j.CompanyID,
                                    TypeJournal = j.TypeJournal,
                                }).Where(c => c.Side == "Debit").OrderBy(o => o.pk).ToList();

                }
            }
            if (side == false)
            {
                if (accountId != "")
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
                                    Info = j.Info,
                                    TransDate = j.TransDate,
                                    ItemDate = j.ItemDate,
                                    EntryDate = j.EntryDate,
                                    Periode = j.Periode,
                                    oYear = j.OYear,
                                    oMonth = j.oMonth,
                                    Account = j.Account,
                                    AccountName = j.AccountName,
                                    OAccount = j.OAccount,
                                    OAccountName = j.OAccountName,
                                    Amount = j.Amount,
                                    DebitBefore = j.DebitAvantImputationAmount,
                                    CreditBefore = j.CreditAvantImputationAmount,
                                    DebitAfter = j.DebitApresImputationAmount,
                                    CreditAfter = j.CreditApresImputationAmount,
                                    Side = j.Side,
                                    Currency = j.Currency,
                                    CompanyID = j.CompanyID,
                                    TypeJournal = j.TypeJournal
                                }).Where(c => (ExactMatch(accountId, c.Account) == true) && (c.Side == "Credit")).OrderBy(o => o.pk).ToList();

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
                                    Info = j.Info,
                                    TransDate = j.TransDate,
                                    ItemDate = j.ItemDate,
                                    EntryDate = j.EntryDate,
                                    Periode = j.Periode,
                                    oYear = j.OYear,
                                    oMonth = j.oMonth,
                                    Account = j.Account,
                                    AccountName = j.AccountName,
                                    OAccount = j.OAccount,
                                    OAccountName = j.OAccountName,
                                    Amount = j.Amount,
                                    DebitBefore = j.DebitAvantImputationAmount,
                                    CreditBefore = j.CreditAvantImputationAmount,
                                    DebitAfter = j.DebitApresImputationAmount,
                                    CreditAfter = j.CreditApresImputationAmount,
                                    Side = j.Side,
                                    Currency = j.Currency,
                                    CompanyID = j.CompanyID,
                                    TypeJournal = j.TypeJournal
                                }).Where(c => c.Side == "Credit").OrderBy(o => o.pk).ToList();
                }
            }


            return journals;
            #endregion

        }



        static bool ExactMatch(string input, string match)
        {
            return Regex.IsMatch(input, string.Format(@"\b{0}\b", Regex.Escape(match)));
        }
        public static List<LineJournauxViewModel> GetLineJournaux(int transId)
        {
            return null;
            ////var account = IWSEntities.LinePayments.AsEnumerable<LineJournauxViewModel>().Select(i => new
            ////{
            ////    Id = i.id,
            ////    TranstId=i.transid,
            ////    Account = i.account,
            ////    Side=i.side,
            ////    OAccount=i.oaccount,
            ////    Amount=i.amount,
            ////})
            ////.Where(c => c.TranstId == transId)
            ////.OrderBy(o => o.Id);


            //List<LineJournauxViewModel> linePayment = new List<LineJournauxViewModel>();
            //linePayment = IWSEntities.LinePayments.AsEnumerable().Select(p =>
            //                                          new LineJournauxViewModel
            //                                          {
            //                                              Id = p.id,
            //                                              TransId = transId,
            //                                              Account = p.account,
            //                                              Side = p.side,
            //                                              OAccount = p.oaccount,
            //                                              Amount = p.amount,
            //                                              Text = p.text,
            //                                              DueDate = p.duedate,
            //                                              Currency = p.Currency,
            //                                              ModelId = Convert.ToInt32(p.ModelId ?? 0)
            //                                          }).Where(t => t.TransId == transId).ToList();


            ////linePayment = IWSEntities.LinePayments.Select(p=>
            ////                                            new LineJournauxViewModel()
            ////                                            {
            ////                                                Id = p.id,
            ////                                                TransId=transId,
            ////                                                Account = p.account,
            ////                                                Side=p.side,
            ////                                                OAccount=p.oaccount,
            ////                                                Amount=p.amount,
            ////                                                Text=p.text,
            ////                                                DueDate=p.duedate,
            ////                                                Currency=p.Currency,
            ////                                                ModelId = Convert.ToInt32(p.ModelId ?? 0)
            ////                                            }).Where(t => t.TransId==transId).ToList();
            //return linePayment;
        }
        public static List<JournauxViewModel> GetJournaux(string TypeJournal, string CompanyId)
        {
            return null;
            //List<JournauxViewModel> payment = new List<JournauxViewModel>();
            //payment = IWSEntities.Payments.Join(IWSEntities.Suppliers,
            //                                        p => p.account, s => s.id, (p, s) =>
            //                                            new JournauxViewModel()
            //                                            {
            //                                                Id = p.id,
            //                                                OId = p.oid,
            //                                                CostCenter = p.CostCenter,
            //                                                Account = p.account + '-' + s.name,
            //                                                HeaderText = p.HeaderText,
            //                                                TransDate = p.TransDate,
            //                                                ItemDate = p.ItemDate,
            //                                                EntryDate = p.EntryDate,
            //                                                CompanyId = p.CompanyId,
            //                                                IsValidated = (bool)p.IsValidated,
            //                                                OTotal = (decimal)p.oTotal,
            //                                                OCurrency = p.oCurrency,
            //                                                OPeriode = p.oPeriode,
            //                                                OYear = p.oYear,
            //                                                OMonth = p.oMonth,
            //                                                TypeJournal = p.TypeJournal,
            //                                                ModelId = Convert.ToInt32(p.ModelId ?? 0),
            //                                                AccountingAccount = p.AccountingAccount,
            //                                            //LigneJournauxViewModels=p.LinePayments.Select(l=>new LigneJournauxViewModel()
            //                                            //{
            //                                            //    Id=l.id,
            //                                            //    TransId=l.transid,
            //                                            //    Account=l.account,
            //                                            //    Side=l.side,
            //                                            //    OAccount=l.oaccount,
            //                                            //    Amount=l.amount,
            //                                            //    DueDate=l.duedate,
            //                                            //    Text=l.text,
            //                                            //    ModelId=l.ModelId
            //                                            //}).ToList()
            //                                        }).Where(p => p.CompanyId.Equals(CompanyId) && TypeJournal.IndexOf(p.TypeJournal) >= 0).ToList();
            ////List<JournauxViewModel> settlement = new List<JournauxViewModel>();
            ////settlement= IWSEntities.Settlements.Join(IWSEntities.Customers,
            ////                                        p => p.account, c => c.id, (p, c) =>
            ////                                        new JournauxViewModel()
            ////                                        {
            ////                                            Id = p.id,
            ////                                            OId = p.oid,
            ////                                            CostCenter = p.CostCenter,
            ////                                            Account = p.account + '-' + c.name,
            ////                                            HeaderText = p.HeaderText,
            ////                                            TransDate = p.TransDate,
            ////                                            ItemDate = p.ItemDate,
            ////                                            EntryDate = p.EntryDate,
            ////                                            CompanyId = p.CompanyId,
            ////                                            IsValidated = (bool)p.IsValidated,
            ////                                            OTotal = (decimal)p.oTotal,
            ////                                            OCurrency = p.oCurrency,
            ////                                            OPeriode = p.oPeriode,
            ////                                            OYear = p.oYear,
            ////                                            OMonth = p.oMonth,
            ////                                            TypeJournal = p.TypeJournal,
            ////                                            ModelId = Convert.ToInt32(p.ModelId ?? 0),
            ////                                            AccountingAccount = p.AccountingAccount
            ////                                        }).Where(p => p.CompanyId.Equals(CompanyId) && TypeJournal.IndexOf(p.TypeJournal) >= 0).ToList();
            ////List<JournauxViewModel> vendorInvoice = new List<JournauxViewModel>();
            ////vendorInvoice = IWSEntities.VendorInvoices.Join(IWSEntities.Suppliers,
            ////                                        p => p.account, s => s.id, (p, s) =>
            ////                                        new JournauxViewModel()
            ////                                        {
            ////                                            Id = p.id,
            ////                                            OId = p.oid,
            ////                                            CostCenter = p.CostCenter,
            ////                                            Account = p.account + '-' + s.name,
            ////                                            HeaderText = p.HeaderText,
            ////                                            TransDate = p.TransDate,
            ////                                            ItemDate = p.ItemDate,
            ////                                            EntryDate = p.EntryDate,
            ////                                            CompanyId = p.CompanyId,
            ////                                            IsValidated = (bool)p.IsValidated,
            ////                                            OTotal = (decimal)p.oTotal,
            ////                                            OCurrency = p.oCurrency,
            ////                                            OPeriode = p.oPeriode,
            ////                                            OYear = p.oYear,
            ////                                            OMonth = p.oMonth,
            ////                                            TypeJournal = p.TypeJournal,
            ////                                            ModelId = Convert.ToInt32(p.ModelId ?? 0),
            ////                                            AccountingAccount = p.AccountingAccount
            ////                                        }).Where(p => p.CompanyId.Equals(CompanyId) && TypeJournal.IndexOf(p.TypeJournal) >= 0).ToList();
            ////List<JournauxViewModel> customerInvoice = new List<JournauxViewModel>();
            ////customerInvoice = IWSEntities.CustomerInvoices.Join(IWSEntities.Customers,
            ////                                        p => p.account, s => s.id, (p, s) =>
            ////                                        new JournauxViewModel()
            ////                                        {
            ////                                            Id = p.id,
            ////                                            OId = p.oid,
            ////                                            CostCenter = p.CostCenter,
            ////                                            Account = p.account + '-' + s.name,
            ////                                            HeaderText = p.HeaderText,
            ////                                            TransDate = p.TransDate,
            ////                                            ItemDate = p.ItemDate,
            ////                                            EntryDate = p.EntryDate,
            ////                                            CompanyId = p.CompanyId,
            ////                                            IsValidated = (bool)p.IsValidated,
            ////                                            OTotal = (decimal)p.oTotal,
            ////                                            OCurrency = p.oCurrency,
            ////                                            OPeriode = p.oPeriode,
            ////                                            OYear = p.oYear,
            ////                                            OMonth = p.oMonth,
            ////                                            TypeJournal = p.TypeJournal,
            ////                                            ModelId = Convert.ToInt32(p.ModelId ?? 0),
            ////                                            AccountingAccount = p.AccountingAccount
            ////                                        }).Where(p => p.CompanyId.Equals(CompanyId) && TypeJournal.IndexOf(p.TypeJournal) >= 0).ToList();
            ////List<JournauxViewModel> generalLedger = new List<JournauxViewModel>();
            ////generalLedger = IWSEntities.GeneralLedgers.Select(p=>
            ////                                        new JournauxViewModel()
            ////                                        {
            ////                                            Id = p.id,
            ////                                            OId = p.oid,
            ////                                            CostCenter = p.CostCenter,
            ////                                            Account = "...",
            ////                                            HeaderText = p.HeaderText,
            ////                                            TransDate = p.TransDate,
            ////                                            ItemDate = p.ItemDate,
            ////                                            EntryDate = p.EntryDate,
            ////                                            CompanyId = p.CompanyId,
            ////                                            IsValidated = (bool)p.IsValidated,
            ////                                            OTotal = (decimal)p.oTotal,
            ////                                            OCurrency = p.oCurrency,
            ////                                            OPeriode = p.oPeriode,
            ////                                            OYear = p.oYear,
            ////                                            OMonth = p.oMonth,
            ////                                            TypeJournal = p.TypeJournal,
            ////                                            ModelId = Convert.ToInt32(p.ModelId ?? 0),
            ////                                            AccountingAccount = "..."
            ////                                        }).Where(p => p.CompanyId.Equals(CompanyId) && TypeJournal.IndexOf(p.TypeJournal) >= 0).ToList();
            ////return payment.Union(settlement).ToList().Union(vendorInvoice).Union(customerInvoice).Union(generalLedger).ToList();
            //return payment.ToList();
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
                          ItemType = "N/A",// j.LocalName,
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
                join a in IWSEntities.GetAccounts() on new {  c.BalanceSheet } equals new { BalanceSheet = a.id }
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
                    join Accounts in IWSEntities.GetAccounts() on new {  c.IncomesStatement } equals new { IncomesStatement = Accounts.id }
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
        public static DateTime GetLastDepreciatedPeriod(string assetId)
        {
            string period =string.Empty;
            string companyID = (string)HttpContext.Current.Session["CompanyID"];
            bool anyDepreciatedPeriod = IWSEntities.DepreciationDetails.Any(c => c.TransId == assetId && c.CompanyId == companyID && c.IsValidated.Equals(true));
            if(!anyDepreciatedPeriod)
            {
                string accountId = IWSEntities.Assets.FirstOrDefault(o => o.Id == assetId).Account;
                period = IWSEntities.PeriodicAccountBalances.OrderBy(o => o.Id).FirstOrDefault(a => a.AccountId == accountId && a.CompanyID == companyID).Periode;
            }
            else
            {
                period = IWSEntities.DepreciationDetails.OrderByDescending(o => o.Period).FirstOrDefault(c => c.TransId == assetId &&
                                                                                    c.CompanyId == companyID && c.IsValidated.Equals(true)).Period;
            }
            int year = Convert.ToInt32( period.Substring(0, 4));
            int month = Convert.ToInt32(period.Substring(4, 2));
            int days = DateTime.DaysInMonth(year, month);
            string day = days < 10 ? "0" + days.ToString() : days.ToString();
            period = period + day;
            return DateTime.ParseExact(period, "yyyyMMdd", CultureInfo.InvariantCulture);
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
        public static decimal GetAmount(int itemId, int modelId)
        {

            if (modelId.Equals((int)ComptaMasterModelId.Payment) ||
                modelId.Equals((int)ComptaMasterModelId.Settlement)) 
            {
                var amount = IWSEntities.DetailComptas.FirstOrDefault(item =>
                                                item.id.Equals(itemId)).amount;
                return amount;
            }
            return 0;
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
            //string companyID = (string)HttpContext.Current.Session["CompanyID"];
            //if (ItemType.Equals(DocsType.GoodReceiving.ToString()))
            //{
                
            //    return IWSEntities.PurchaseOrders.FirstOrDefault(c =>
            //    c.id == id && c.CompanyId == companyID).store;
            //}
            //if (ItemType.Equals(DocsType.InventoryInvoice.ToString()))
            //{
            //    return IWSEntities.GoodReceivings.FirstOrDefault(c =>
            //    c.id == id && c.CompanyId == companyID).store;
            //}
            //if (ItemType.Equals(DocsType.BillOfDelivery.ToString()))
            //{
            //    return IWSEntities.SalesOrders.FirstOrDefault(c =>
            //    c.id == id && c.CompanyId == companyID).store;
            //}
            //if (ItemType.Equals(DocsType.SalesInvoice.ToString()))
            //{
            //    return IWSEntities.BillOfDeliveries.FirstOrDefault(c =>
            //    c.id == id && c.CompanyId == companyID).store;
            //}
            return null;
           
        }

        public static string GetSupplier(int id, string ItemType)
        {
            //string companyID = (string)HttpContext.Current.Session["CompanyID"];
            //if (ItemType.Equals(IWSLookUp.DocsType.GoodReceiving.ToString()))
            //{
            //    return IWSEntities.PurchaseOrders.FirstOrDefault(c =>
            //    c.id == id && c.CompanyId == companyID).account;
            //}
            //if (ItemType.Equals(IWSLookUp.DocsType.InventoryInvoice.ToString()))
            //{
            //    return IWSEntities.GoodReceivings.FirstOrDefault(c =>
            //    c.id == id && c.CompanyId == companyID).account;
            //}
            //if (ItemType.Equals(IWSLookUp.DocsType.BillOfDelivery.ToString()))
            //{
            //    return IWSEntities.SalesOrders.FirstOrDefault(c =>
            //    c.id == id && c.CompanyId == companyID).account;
            //}
            //if (ItemType.Equals(IWSLookUp.DocsType.SalesInvoice.ToString()))
            //{
            //    return IWSEntities.BillOfDeliveries.FirstOrDefault(c =>
            //    c.id == id && c.CompanyId == companyID).account;
            //}
            //if (ItemType.Equals(IWSLookUp.DocsType.VendorInvoice.ToString()))
            //{
            //    return IWSEntities.InventoryInvoices.FirstOrDefault(c =>
            //    c.id == id && c.CompanyId == companyID).account;
            //}
            //if (ItemType.Equals(IWSLookUp.DocsType.CustomerInvoice.ToString()))
            //{
            //    return IWSEntities.SalesInvoices.FirstOrDefault(c =>
            //    c.id == id && c.CompanyId == companyID).account;
            //}
            //if (ItemType.Equals(IWSLookUp.DocsType.Settlement.ToString()))
            //{
            //    return IWSEntities.CustomerInvoices.FirstOrDefault(c =>
            //    c.id == id && c.CompanyId == companyID).account;
            //}
            //if (ItemType.Equals(IWSLookUp.DocsType.Payment.ToString()))
            //{
            //    return IWSEntities.VendorInvoices.FirstOrDefault(c =>
            //    c.id == id && c.CompanyId == companyID).account;
            //}
            //if (ItemType.Equals(IWSLookUp.DocsType.GeneralLedgerIn.ToString()))
            //{
            //    return IWSEntities.Settlements.FirstOrDefault(c =>
            //    c.id == id && c.CompanyId == companyID).account;
            //}
            //if (ItemType.Equals(IWSLookUp.DocsType.GeneralLedgerOut.ToString()))
            //{
            //    return IWSEntities.Payments.FirstOrDefault(c =>
            //    c.id == id && c.CompanyId == companyID).account;
            //}
            return null;
        }
        public static string GetCostCenter(int id, string ItemType)
        {
            //string companyID = (string)HttpContext.Current.Session["CompanyID"];

            //if (ItemType.Equals(IWSLookUp.DocsType.Settlement.ToString()))
            //{
            //    return IWSEntities.CustomerInvoices.FirstOrDefault(c =>
            //    c.id == id && c.CompanyId == companyID).CostCenter;
            //}
            //if (ItemType.Equals(IWSLookUp.DocsType.Payment.ToString()))
            //{
            //    return IWSEntities.VendorInvoices.FirstOrDefault(c =>
            //    c.id == id && c.CompanyId == companyID).CostCenter;
            //}
            //if (ItemType.Equals(IWSLookUp.DocsType.GeneralLedgerIn.ToString()))
            //{
            //    return IWSEntities.Settlements.FirstOrDefault(c =>
            //    c.id == id && c.CompanyId == companyID).CostCenter;
            //}
            //if (ItemType.Equals(IWSLookUp.DocsType.GeneralLedgerOut.ToString()))
            //{
            //    return IWSEntities.Payments.FirstOrDefault(c =>
            //    c.id == id && c.CompanyId == companyID).CostCenter;
            //}
            return null;
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
            Article = 7,
            Banks = 11,
            Customer = 3,
            Account = 9,
            Company = 10,
            CostCenter = 6,
            QuantityUnit = 4,
            Store = 2,
            Supplier = 1,
            VAT = 14, 
            Currency = 5,
            TypeJournal = 8,
            Stock = 107,
            BankAccount =12,
            BankStatement =18,
            TimeSheet=20,
            PeriodicAccountBalance =13,
            Asset = 19,
            Default = 0000
        }
        public enum LogisticMasterModelId
        {
            PurchaseOrder = 101,
            GoodReceiving = 104,
            InventoryInvoice = 110,
            SalesOrder = 116,
            BillOfDelivery = 118,
            SalesInvoice = 120,
            Default=0000
        }
        public enum LogisticDetailModelId
        {
            LinePurchaseOrder = 102,
            LineGoodReceiving = 105,
            LineInventoryInvoice = 111,
            LineSalesOrder = 117,
            LineBillOfDelivery = 119,
            LineSalesInvoice = 121,
            Default = 0000
        }
        public enum ComptaMasterModelId
        {
            VendorInvoice = 112,
            Payment = 114,
            CustomerInvoice = 122,
            Settlement = 124,
            GeneralLedger = 134,
            Default = 0000
        }
        public enum ComptaDetailModelId
        {
            LineVendorInvoice = 113,
            LineCustomerInvoice = 123,
            LinePayment = 115,
            LineSettlement = 125,
            LineGeneralLedger = 135,
            Default = 0000
        }
        public enum DepreciationType
        {
            StraightLine=2,
            Degressive = 4,
            Default = 2
        }
        public enum DepreciationFrequency
        {
            Yearly=1,
            Monthly=12
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

    public static IEnumerable<Account> GetChild(string accountId)
    {
        return IWSEntities.GetAccounts().Where(x => x.ParentId == accountId || x.id == accountId)
                            .Union(IWSEntities.GetAccounts().Where(x => x.ParentId == accountId)
                            .SelectMany(x => GetChild(x.id)));
    }


    }
}