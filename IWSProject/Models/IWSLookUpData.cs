namespace IWSProject.Models
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
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
            var account = IWSEntities.BankAccounts.AsEnumerable().Select(i => new
            {
                Id = i.IBAN,
                Name = i.Owner,
                CompanyID = i.CompanyID,
            })
            .Where(c => c.CompanyID == (string)HttpContext.Current.Session["CompanyID"])
            .OrderBy(o => o.Id);
            return account;
        }

        public static IEnumerable GetBIC()
        {
            var account = IWSEntities.Banks.AsEnumerable().Select(i => new
            {
                Id = i.id,
                Name = i.name,
                CompanyID = i.CompanyID,
            })
            .Where(c => c.CompanyID == (string)HttpContext.Current.Session["CompanyID"])
            .OrderBy(o => o.Id);
            return account;
        }
        public static bool IsBalance(string accountId)
        {
            return IWSEntities.Companies.Any(c=>
            c.BalanceSheet==accountId && c.id==(string)HttpContext.Current.Session["CompanyID"]);
        }
        public static IEnumerable GetAccounts()
        {
            var account = IWSEntities.Accounts.AsEnumerable().Select(i => new
            {
                Id = i.id,
                Name = i.name,
                CompanyID=i.CompanyID,
                IsUsed=i.IsUsed
            })
            .Where(c => c.CompanyID == (string)HttpContext.Current.Session["CompanyID"] 
                            && c.IsUsed.Equals(true))
            .OrderBy(o => o.Id);
            return account;
        }
        public static IEnumerable GetPackUnits()
        {
            var account = IWSEntities.QuantityUnits.AsEnumerable().Select(i => new
            {
                Id = i.id,
                Name = i.name,
                CompanyID = i.CompanyID
            })
            .Where(c => c.CompanyID == (string)HttpContext.Current.Session["CompanyID"])
            .OrderBy(o => o.Id);
            return account;
        }
        public static IEnumerable GetArticle()
        {
            var article = IWSEntities.Articles.AsEnumerable().Select(item => new
            {
                Id = item.id,
                Name = item.name,
                Price = item.price,
                Unit = item.qttyunit,
                Pack = item.packunit,
                Vat = item.VatCode,
                CompanyID = item.CompanyID
            }).
            Where(c=>c.CompanyID == (string)HttpContext.Current.Session["CompanyID"]).
            OrderBy(o => o.Name);
            return article;
        }
        public static IEnumerable GetBillOfDelivery()
        {
            var b = from o in IWSEntities.BillOfDeliveries
                                 where o.CompanyId == (string)HttpContext.Current.Session["CompanyID"]
                                 select o;
            return b;
        }
        public static IEnumerable GetCustomerInvoice()
        {
            var b = from o in IWSEntities.CustomerInvoices
                    where o.CompanyId == (string)HttpContext.Current.Session["CompanyID"]
                    select o;
            return b;
        }
        public static IEnumerable GetGeneralLedger(string area)
        {
            var b = from o in IWSEntities.GeneralLedgers
                    where o.CompanyId == (string)HttpContext.Current.Session["CompanyID"] && o.Area == area
                    select o;
            return b;
        }
        public static IEnumerable GetGoodReceiving()
        {
            var b = from o in IWSEntities.GoodReceivings
                    where o.CompanyId == (string)HttpContext.Current.Session["CompanyID"]
                    select o;
            return b;
        }
        public static IEnumerable GetInventoryInvoice()
        {
            var b = from o in IWSEntities.InventoryInvoices
                    where o.CompanyId == (string)HttpContext.Current.Session["CompanyID"]
                    select o;
            return b;
        }
        public static IEnumerable GetPayment()
        {
            var b = from o in IWSEntities.Payments
                    where o.CompanyId == (string)HttpContext.Current.Session["CompanyID"]
                    select o;
            return b;
        }
        public static IEnumerable GetPurchaseOrder()
        {
            var b = from o in IWSEntities.PurchaseOrders
                    where o.CompanyId == (string)HttpContext.Current.Session["CompanyID"]
                    orderby o.id descending
                    select o;
            return b;
        }
        public static IEnumerable GetSalesInvoice()
        {
            var b = from o in IWSEntities.SalesInvoices
                    where o.CompanyId == (string)HttpContext.Current.Session["CompanyID"]
                    select o;
            return b;
        }
        public static IEnumerable GetSalesOrder()
        {
            var b = from o in IWSEntities.SalesOrders
                    where o.CompanyId == (string)HttpContext.Current.Session["CompanyID"]
                    select o;
            return b;
        }
        public static IEnumerable GetSettlement()
        {
            var b = from o in IWSEntities.Settlements
                    where o.CompanyId == (string)HttpContext.Current.Session["CompanyID"]
                    select o;
            return b;
        }
        public static IEnumerable GetVendorInvoice()
        {
            var b = from o in IWSEntities.VendorInvoices
                    where o.CompanyId == (string)HttpContext.Current.Session["CompanyID"]
                    select o;
            return b;
        }
        public static IEnumerable GetCustSuppliers()
        {
            var owner =     (from co in IWSEntities.Companies
            where
              (co.id == (string)HttpContext.Current.Session["CompanyID"])
            select new
            {
                Id = co.id,
                Name = co.name
            }
            ).Union
            (
            from cu in IWSEntities.Customers
            where
              (cu.CompanyID == (string)HttpContext.Current.Session["CompanyID"])
            select new
            {
                Id = cu.id,
                Name = cu.name
            }
            ).Union
            (
            from su in IWSEntities.Suppliers
            where
              (su.CompanyID == (string)HttpContext.Current.Session["CompanyID"])
            select new
            {
                Id = su.id,
                Name = su.name
            }
            )
            .OrderBy(p => p.Name);
            return owner;
        }
        public static IEnumerable GetCustomers()
        {
            var customer = IWSEntities.Customers.AsEnumerable().Select(item => new
            {
                Id = item.id,
                Name = item.name,
                CompanyID=item.CompanyID
            })
            .Where(c => c.CompanyID == (string)HttpContext.Current.Session["CompanyID"])
            .OrderBy(o => o.Id);
            return customer;
        }
        public static IEnumerable GetCustomer()
        {
            var b = from o in IWSEntities.Customers
                    where o.CompanyID == (string)HttpContext.Current.Session["CompanyID"]
                    select o;
            return b;
        }
        public static IEnumerable GetSupplier()
        {
            var b = from o in IWSEntities.Suppliers
                    where o.CompanyID == (string)HttpContext.Current.Session["CompanyID"]
                    select o;
            return b;
        }
        public static IEnumerable GetCompany()
        {
            var b = from o in IWSEntities.Companies
                    where o.id == (string)HttpContext.Current.Session["CompanyID"]
                    select o;
            return b;
        }
        public static IEnumerable GetCostCenter()
        {
            return IWSEntities.CostCenters.Where(c => c.CompanyID == (string)HttpContext.Current.Session["CompanyID"]);
        }
        public static IEnumerable GetCurrencies()
        {
            return IWSEntities.Currencies.Where(c => c.CompanyID == (string)HttpContext.Current.Session["CompanyID"]);
        }
        public static IEnumerable GetBanks()
        {
            return IWSEntities.Banks.Where(c => c.CompanyID == (string)HttpContext.Current.Session["CompanyID"]);
        }
        public static IEnumerable GetAccount()
        {
            return IWSEntities.Accounts.Where(c => c.CompanyID == (string)HttpContext.Current.Session["CompanyID"]);
        }
        public static IEnumerable GetMenus()
        {
            return IWSEntities.Menus.Where(c => c.CompanyID == (string)HttpContext.Current.Session["CompanyID"]);
        }
        public static IEnumerable GetQuantityUnits()
        {
            return IWSEntities.QuantityUnits.Where(c => c.CompanyID == (string)HttpContext.Current.Session["CompanyID"]);
        }
        public static IEnumerable GetStores()
        {
            return IWSEntities.Stores.Where(c => c.CompanyID == (string)HttpContext.Current.Session["CompanyID"]);
        }
        public static IEnumerable GetArticles()
        {
            return IWSEntities.Articles.Where(c => c.CompanyID == (string)HttpContext.Current.Session["CompanyID"]);
        }
        public static IEnumerable GetVats()
        {
            return IWSEntities.Vats.Where(c => c.CompanyID == (string)HttpContext.Current.Session["CompanyID"]);
        }
        public static IEnumerable GetBankAccount(string Owner)
        {
            var b = from o in IWSEntities.BankAccounts
                    where o.Owner == Owner
                    select o;
            return b;
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
            var center = IWSEntities.CostCenters.AsEnumerable().Select(item => new
            {
                Id = item.id,
                Name = item.name,
                CompanyID=item.CompanyID
            })
            .Where(c => c.CompanyID == (string)HttpContext.Current.Session["CompanyID"])
            .OrderBy(o => o.Name);
            return center;
        }
        public static IEnumerable GetMenuId()
        {
            var account = IWSEntities.Menus.AsEnumerable().Select(item => new
            {
                Id = item.ID,
                Name = item.Name,
                CompanyID = item.CompanyID
            })
            .Where(c => c.CompanyID == (string)HttpContext.Current.Session["CompanyID"])
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
                                    UserId = item.UserId, 
                                    RoleId = item.RoleId
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
            var store = IWSEntities.Stores.AsEnumerable().Select(item => new
            {
                Id = item.id,
                Name = item.name,
                CompanyID=item.CompanyID
            }).
            Where(c => c.CompanyID == (string)HttpContext.Current.Session["CompanyID"]).
            OrderBy(o => o.Name);
            return store;
        }
        public static List<Menu> GetMenu(string CompanyID)
        {
            if (HttpContext.Current.Session["Menus"] == null)
            {
                List<Menu> menus = new List<Menu>();
                menus = IWSEntities.Menus
                        .Where(c=>c.CompanyID == CompanyID && c.Disable==false)
                        .ToList();
                HttpContext.Current.Session["Menus"] = menus;
            }
            return (List<Menu>)HttpContext.Current.Session["Menus"];
        }
        public static IEnumerable GetSuppliers()
        {
            var supplier = IWSEntities.Suppliers.AsEnumerable().Select(item => new
            {
                Id = item.id,
                Name = item.name,
                CompanyID =item.CompanyID
            })
            .Where(c => c.CompanyID == (string)HttpContext.Current.Session["CompanyID"])
            .OrderBy(o => o.Id);
            return supplier;
        }
        public static IEnumerable GetVAT()
        {
            var vat = IWSEntities.Vats.AsEnumerable().Select(item => new
            {
                Id = item.id,
                Name = item.PVat,
                CompanyID=item.CompanyID
            })
            .Where(c => c.CompanyID == (string)HttpContext.Current.Session["CompanyID"])
            .OrderBy(o => o.Name);
            return vat;
        }
        public static IEnumerable GetCurrency()
        {
            var currency = IWSEntities.Currencies.AsEnumerable().Select(item => new
            {
                Id = item.Id,
                Name = item.Name,
                CompanyID = item.CompanyID
            })
            .Where(c => c.CompanyID == (string)HttpContext.Current.Session["CompanyID"])
            .OrderBy(o => o.Name);
            return currency;
        }
        public static InvoiceViewModel GetInvoiceDetail(int itemId, string itemType, string companyId)
        {
            try
            {
                if (itemType.Equals(IWSLookUp.DocsType.CustomerInvoice.ToString()))
                {
                    InvoiceViewModel invoice = (from l in IWSEntities.LineSettlements
                                           join Vats in IWSEntities.Vats on new { VatCode = l.Settlement.Customer.VatCode }
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
                                            join Vats in IWSEntities.Vats on new { VatCode = l.Payment.Supplier.VatCode } 
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
                   join bao in IWSEntities.BankAccounts on new { Kontonummer = bs.Kontonummer } equals new { Kontonummer = bao.IBAN }
                   join cu in IWSEntities.Customers on new { Owner = bao.Owner } equals new { Owner = cu.id }
                   join baa in IWSEntities.BankAccounts on new { CompanyIBAN = bs.CompanyIBAN } equals new { CompanyIBAN = baa.IBAN }
                   join co in IWSEntities.Companies on new { Owner = baa.Owner } equals new { Owner = co.id }
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

                if (itemType.Equals(IWSLookUp.DocsType.CustomerInvoice.ToString()))
                {
                    StatementDetailViewModel sd =
                        (from c in IWSEntities.Companies
                         join b in IWSEntities.BankStatements on new { id = c.id } equals new { id = b.CompanyID }
                         join s in IWSEntities.Customers
                             on new { c.id, b.Kontonummer }
                         equals new { id = s.CompanyID, Kontonummer = s.IBAN }
                         where
                         b.IsValidated.Equals(false) &&
                         b.id.Equals(bankStatementId)
                         select new StatementDetailViewModel()
                         {
                             Id = s.id,
                             AccountID = s.accountid,
                             BankAccountID = c.settlementclearingaccountid,
                             Info = b.Info,
                             Waehrung = b.Waehrung,
                             Betrag = (decimal)b.Betrag,
                             Buchungstag = (DateTime)b.Buchungstag,
                             Valutadatum = (DateTime)b.Valutadatum,
                             Periode = Convert.ToString((int?)b.Buchungstag.Value.Year) +
                                         Convert.ToString((int?)b.Buchungstag.Value.Month),
                             Buchungstext = b.Buchungstext,
                             Verwendungszweck = b.Verwendungszweck,
                             BeguenstigterZahlungspflichtiger = b.BeguenstigterZahlungspflichtiger,
                             IBAN = s.IBAN
                         }).Single();
                    return sd;
                }

                if (itemType.Equals(IWSLookUp.DocsType.Payment.ToString()))
                {
                    StatementDetailViewModel sd =
                            (from bs in IWSEntities.BankStatements
                            join bao in IWSEntities.BankAccounts on new { Kontonummer = bs.Kontonummer } equals new { Kontonummer = bao.IBAN }
                            join su in IWSEntities.Suppliers on new { Owner = bao.Owner } equals new { Owner = su.id }
                            join baa in IWSEntities.BankAccounts on new { CompanyIBAN = bs.CompanyIBAN } equals new { CompanyIBAN = baa.IBAN }
                            join co in IWSEntities.Companies on new { Owner = baa.Owner } equals new { Owner = co.id }
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

                if (itemType.Equals(IWSLookUp.DocsType.VendorInvoice.ToString()))
                {

                    StatementDetailViewModel BS =
                        (from su in IWSEntities.Suppliers
                         join ba in IWSEntities.BankAccounts on new { id = su.id } equals new { id = ba.Owner }
                         join co in IWSEntities.Companies on new { CompanyID = ba.CompanyID } equals new { CompanyID = co.id }
                         join bs in IWSEntities.BankStatements on new { IBAN = ba.IBAN } equals new { IBAN = bs.Kontonummer }
                         where
                           bs.IsValidated == false &&
                           ba.CompanyID == companyId &&
                           bs.id == bankStatementId
                         select new StatementDetailViewModel()
                         {
                             Id = su.id,
                             IBAN = ba.IBAN,
                             BankAccountID = ba.Account,
                             AccountID = co.purchasingclearingaccountid,
                             Info = bs.Info,
                             Waehrung = bs.Waehrung,
                             Betrag = Math.Abs((decimal)bs.Betrag),
                             Buchungstag = (DateTime)bs.Buchungstag,
                             Valutadatum = (DateTime)bs.Valutadatum,
                             Periode = Convert.ToString((int?)bs.Buchungstag.Value.Year) +
                                       Convert.ToString((int?)bs.Buchungstag.Value.Month),
                             Buchungstext = bs.Buchungstext,
                             Verwendungszweck = bs.Verwendungszweck,
                             BeguenstigterZahlungspflichtiger = bs.BeguenstigterZahlungspflichtiger
                         }).Single();

                    return BS;
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
                    IsValidated = b.IsValidated

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
                 Area = false,
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
                    Area = true,
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
                 Area = false,
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
                 Area = false,
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
                     Area = true,
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
                 Area = true,
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
                 Area = false,
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
                     Area = false,
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
                 Area = false,
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
                 Area = false,
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
             where line.GeneralLedger.IsValidated == IsValidated && line.GeneralLedger.Area == Area.Sales.ToString()
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
                 Area = false,
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
             where line.GeneralLedger.IsValidated == IsValidated && line.GeneralLedger.Area == Area.Purchasing.ToString()
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
                 Area = false,
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
                                            Where(c=>c.CompanyID==(string)HttpContext.Current.Session["CompanyID"]).
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

            List<OwnerViewModel> companies = Queryable.OrderBy(
            (from line in IWSEntities.Companies
             where line.id== (string)HttpContext.Current.Session["CompanyID"]
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
             where line.id == (string)HttpContext.Current.Session["CompanyID"]
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
             where line.id == (string)HttpContext.Current.Session["CompanyID"]
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

            List<CreditViewModel> c = new List<CreditViewModel>
                ((from l in IWSEntities.LineSalesInvoices
                    where 
                    l.transid == oid &&
                    l.Article.CompanyID == (string)HttpContext.Current.Session["CompanyID"] &&
                    l.Article.Vat.CompanyID == (string)HttpContext.Current.Session["CompanyID"]
                    select new CreditViewModel()
                    {
                        OCreditVAT = l.Article.Vat.outputvataccountid,
                        OCreditTotal = l.Article.Vat.revenueaccountid
                    }).Distinct());

            List<DebitViewModel> d = new List<DebitViewModel>
                (from l in IWSEntities.SalesInvoices
                   where
                     l.CompanyId == (string)HttpContext.Current.Session["CompanyID"] &&
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
            var lines=
            (
                from LineInventoryInvoices in IWSEntities.LineInventoryInvoices
                where
                  LineInventoryInvoices.transid == oid
                group new { LineInventoryInvoices.Article, LineInventoryInvoices } by new
                {
                    LineInventoryInvoices.InventoryInvoice.Company.purchasingclearingaccountid
                } into g
                select new
                {
                    account = g.Key.purchasingclearingaccountid,
                    amount = (decimal?)g.Sum(p => p.LineInventoryInvoices.lineNet)
                }
            ).Union
            (
                from LineInventoryInvoices in IWSEntities.LineInventoryInvoices
                where
                  LineInventoryInvoices.transid == oid
                group new { LineInventoryInvoices.Article.Vat, LineInventoryInvoices } by new
                {
                    LineInventoryInvoices.Article.Vat.inputvataccountid
                } into g
                select new
                {
                    account = g.Key.inputvataccountid,
                    amount = (decimal?)g.Sum(p => p.LineInventoryInvoices.lineVAT)
                }
            );

            var header = from h in IWSEntities.InventoryInvoices
                         where
                           h.id == oid
                         select new
                         {
                             h.HeaderText,
                             h.TransDate,
                             h.oTotal,
                             h.oCurrency,
                             h.Supplier.accountid
                         };

            List<LineInvoiceViewModel> newLine = (from o in lines
                                               select new LineInvoiceViewModel()
                                                {
                                                    TransID=itemID,
                                                    Account=o.account,
                                                    Side = true,
                                                    OAccount =header.Single().accountid,
                                                    Amount= (decimal)o.amount,
                                                    DueDate=header.Single().TransDate,
                                                    Text=header.Single().HeaderText,
                                                    Currency=header.Single().oCurrency
                                                }).ToList();
            List<LineVendorInvoice> docs =
             (from item in newLine
              select new LineVendorInvoice()
              {
                  transid = itemID,
                  account=item.Account,
                  side=item.Side,
                  oaccount=item.OAccount,
                  amount=item.Amount,
                  duedate = item.DueDate,
                  text = item.Text,
                  Currency = item.Currency
              }
             ).ToList();
            return docs;
        }

        public static IEnumerable GetAccountBalance(string start, string end, bool detail, string CompanyID)
        {
            List<AccountBalanceViewModel> items = (from p in IWSEntities.PeriodicBalances(start, end, detail, CompanyID)
                                                   select new AccountBalanceViewModel()
                                                   {
                                                       AccountID=p.AccountId + "-" + p.AccountName,
                                                       AccountName=p.AccountName,
                                                       Periode=p.Periode,
                                                       Debit=(decimal)p.Debit,
                                                       Credit=(decimal)p.Credit,
                                                       Balance=(decimal)p.Balance,
                                                       Currency=p.Currency,
                                                       IsBalance=(bool)p.IsBalance,
                                                       CompanyID=p.CompanyId
                                                   }).ToList();
            return items;
        }

        public static IEnumerable GetJournal(string start, string end, string accountId, string CompanyID)
        {
            string uiCulture = Thread.CurrentThread.CurrentUICulture.Name;
            List<JournalViewModel> journals = new List<JournalViewModel>();
            if (String.IsNullOrEmpty(accountId) || String.IsNullOrWhiteSpace(accountId))
            {
             journals = (from j in IWSEntities.GetJournals(start, end, uiCulture, CompanyID)
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
                     Account = j.Account,
                     AccountName=j.AccountName,
                     OAccount = j.OAccount,
                     OAccountName = j.OAccountName,
                     Amount = j.Amount,
                     Side = j.Side,
                     Currency = j.Currency,
                     CompanyID = j.CompanyID
                 }).ToList();
            }
            else
            {
            journals = (from j in IWSEntities.GetJournals(start, end, uiCulture, CompanyID)
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
                     Account = j.Account,
                     AccountName = j.AccountName,
                     OAccount = j.OAccount,
                     OAccountName = j.OAccountName,
                     Amount = j.Amount,
                     Side = j.Side,
                     Currency = j.Currency,
                     CompanyID = j.CompanyID
                 }).Where(c => accountId.IndexOf(c.Account)>=0  || accountId.IndexOf(c.Account) >= 0).ToList();
            }
            return journals; 
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
            List<ChildViewModel> r =
                ((
                from c in IWSEntities.Companies
                join Accounts in IWSEntities.Accounts on new { BalanceSheet = c.BalanceSheet } equals new { BalanceSheet = Accounts.id }
                where
                  c.id == (string)HttpContext.Current.Session["CompanyID"]
                select new ChildViewModel()
                {
                    ParentId = Accounts.id,
                    ParentName = Accounts.name
                }
                ).Union
                (
                    from c in IWSEntities.Companies
                    join Accounts in IWSEntities.Accounts on new { IncomesStatement = c.IncomesStatement } equals new { IncomesStatement = Accounts.id }
                    where
                      c.id == (string)HttpContext.Current.Session["CompanyID"]
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
            return IWSEntities.Articles.FirstOrDefault(c => 
                c.id == id && c.CompanyID == (string)HttpContext.Current.Session["CompanyID"]).packunit;
        }
        public static string GetCompany(string UserName)
        {
            return IWSEntities.AspNetUsers.FirstOrDefault(c => 
                                c.UserName == UserName).Company;
        }
        public static string GetQttyUnit(string id)
        {
            return IWSEntities.Articles.FirstOrDefault(c => 
                c.id == id && c.CompanyID == (string)HttpContext.Current.Session["CompanyID"]).qttyunit;
        }
        public static decimal GetVatCode(string id)
        {
            return IWSEntities.Articles.FirstOrDefault(c =>
                   c.id == id && c.CompanyID == (string)HttpContext.Current.Session["CompanyID"]).Vat.PVat;
        }
        public static string GetCurrency(string id)
        {
            return IWSEntities.Articles.FirstOrDefault(c =>
                   c.id == id && c.CompanyID == (string)HttpContext.Current.Session["CompanyID"]).Currency;
        }
        public static decimal GetPrice(string id)
        {
            return IWSEntities.Articles.FirstOrDefault(c => 
                c.id == id && c.CompanyID == (string)HttpContext.Current.Session["CompanyID"]).price;
        }
        public static decimal GetSalesPrice(string id)
        {
            return IWSEntities.Articles.FirstOrDefault(c => 
                c.id == id && c.CompanyID == (string)HttpContext.Current.Session["CompanyID"]).salesprice;
        }
        public static string GetLineText(string id)
        {
            return IWSEntities.Articles.FirstOrDefault(c => 
                c.id == id && c.CompanyID == (string)HttpContext.Current.Session["CompanyID"]).description ?? "N/A";
        }
        public static string GetHeaderText(int id, string ItemType)
        {
            if (ItemType.Equals(DocsType.GoodReceiving.ToString()))
            {
                return IWSEntities.PurchaseOrders.FirstOrDefault(c =>
                c.id == id && c.CompanyId == (string)HttpContext.Current.Session["CompanyID"]).HeaderText ?? "N/A";
            }
            if (ItemType.Equals(DocsType.BillOfDelivery.ToString()))
            {
                return IWSEntities.SalesOrders.FirstOrDefault(c =>
                c.id == id && c.CompanyId == (string)HttpContext.Current.Session["CompanyID"]).HeaderText ?? "N/A";
            }
            if (ItemType.Equals(DocsType.InventoryInvoice.ToString()))
            {
                return IWSEntities.GoodReceivings.FirstOrDefault(c =>
                c.id == id && c.CompanyId == (string)HttpContext.Current.Session["CompanyID"]).HeaderText ?? "N/A";
            }
            if (ItemType.Equals(DocsType.SalesInvoice.ToString()))
            {
                return IWSEntities.BillOfDeliveries.FirstOrDefault(c =>
                c.id == id && c.CompanyId == (string)HttpContext.Current.Session["CompanyID"]).HeaderText ?? "N/A";
            }
            if (ItemType.Equals(DocsType.VendorInvoice.ToString()))
            {
                return IWSEntities.InventoryInvoices.FirstOrDefault(c =>
                c.id == id && c.CompanyId == (string)HttpContext.Current.Session["CompanyID"]).HeaderText ?? "N/A";
            }
            if (ItemType.Equals(DocsType.CustomerInvoice.ToString()))
            {
                return IWSEntities.SalesInvoices.FirstOrDefault(c =>
                c.id == id && c.CompanyId == (string)HttpContext.Current.Session["CompanyID"]).HeaderText ?? "N/A";
            }
            if (ItemType.Equals(DocsType.Settlement.ToString()))
            {
                return IWSEntities.CustomerInvoices.FirstOrDefault(c =>
                c.id == id && c.CompanyId == (string)HttpContext.Current.Session["CompanyID"]).HeaderText ?? "N/A";
            }
            if (ItemType.Equals(DocsType.Payment.ToString()))
            {
                return IWSEntities.VendorInvoices.FirstOrDefault(c =>
                c.id == id && c.CompanyId == (string)HttpContext.Current.Session["CompanyID"]).HeaderText ?? "N/A";
            }
            if (ItemType.Equals(DocsType.GeneralLedgerIn.ToString()))
            {
                return IWSEntities.Settlements.FirstOrDefault(c =>
                c.id == id && c.CompanyId == (string)HttpContext.Current.Session["CompanyID"]).HeaderText ?? "N/A";
            }
            if (ItemType.Equals(DocsType.GeneralLedgerOut.ToString()))
            {
                return IWSEntities.Payments.FirstOrDefault(c =>
                c.id == id && c.CompanyId == (string)HttpContext.Current.Session["CompanyID"]).HeaderText ?? "N/A";
            }
            return null;
        }
        public static string GetStore(int id, string ItemType)
        {
            if (ItemType.Equals(DocsType.GoodReceiving.ToString()))
            {
                return IWSEntities.PurchaseOrders.FirstOrDefault(c =>
                c.id == id && c.CompanyId == (string)HttpContext.Current.Session["CompanyID"]).store;
            }
            if (ItemType.Equals(DocsType.BillOfDelivery.ToString()))
            {
                return IWSEntities.SalesOrders.FirstOrDefault(c =>
                c.id == id && c.CompanyId == (string)HttpContext.Current.Session["CompanyID"]).store;
            }
            if (ItemType.Equals(DocsType.InventoryInvoice.ToString()))
            {
                return IWSEntities.GoodReceivings.FirstOrDefault(c =>
                c.id == id && c.CompanyId == (string)HttpContext.Current.Session["CompanyID"]).store;
            }
            if (ItemType.Equals(DocsType.SalesInvoice.ToString()))
            {
                return IWSEntities.BillOfDeliveries.FirstOrDefault(c =>
                c.id == id && c.CompanyId == (string)HttpContext.Current.Session["CompanyID"]).store;
            }
            if (ItemType.Equals(DocsType.VendorInvoice.ToString()))
            {
                return IWSEntities.InventoryInvoices.FirstOrDefault(c =>
                c.id == id && c.CompanyId == (string)HttpContext.Current.Session["CompanyID"]).store;
            }
            if (ItemType.Equals(DocsType.CustomerInvoice.ToString()))
            {
                return IWSEntities.SalesInvoices.FirstOrDefault(c =>
                c.id == id && c.CompanyId == (string)HttpContext.Current.Session["CompanyID"]).store;
            }
            return null;
           
        }
        public static string GetSupplier(int id, string ItemType)
        {
            if (ItemType.Equals(IWSLookUp.DocsType.GoodReceiving.ToString()))
            {
                return IWSEntities.PurchaseOrders.FirstOrDefault(c =>
                c.id == id && c.CompanyId == (string)HttpContext.Current.Session["CompanyID"]).account;
            }
            if (ItemType.Equals(IWSLookUp.DocsType.BillOfDelivery.ToString()))
            {
                return IWSEntities.SalesOrders.FirstOrDefault(c =>
                c.id == id && c.CompanyId == (string)HttpContext.Current.Session["CompanyID"]).account;
            }
            if (ItemType.Equals(IWSLookUp.DocsType.InventoryInvoice.ToString()))
            {
                return IWSEntities.GoodReceivings.FirstOrDefault(c =>
                c.id == id && c.CompanyId == (string)HttpContext.Current.Session["CompanyID"]).account;
            }
            if (ItemType.Equals(IWSLookUp.DocsType.SalesInvoice.ToString()))
            {
                return IWSEntities.BillOfDeliveries.FirstOrDefault(c =>
                c.id == id && c.CompanyId == (string)HttpContext.Current.Session["CompanyID"]).account;
            }
            if (ItemType.Equals(IWSLookUp.DocsType.VendorInvoice.ToString()))
            {
                return IWSEntities.InventoryInvoices.FirstOrDefault(c =>
                c.id == id && c.CompanyId == (string)HttpContext.Current.Session["CompanyID"]).account;
            }
            if (ItemType.Equals(IWSLookUp.DocsType.CustomerInvoice.ToString()))
            {
                return IWSEntities.SalesInvoices.FirstOrDefault(c =>
                c.id == id && c.CompanyId == (string)HttpContext.Current.Session["CompanyID"]).account;
            }
            if (ItemType.Equals(IWSLookUp.DocsType.Settlement.ToString()))
            {
                return IWSEntities.CustomerInvoices.FirstOrDefault(c =>
                c.id == id && c.CompanyId == (string)HttpContext.Current.Session["CompanyID"]).account;
            }
            if (ItemType.Equals(IWSLookUp.DocsType.Payment.ToString()))
            {
                return IWSEntities.VendorInvoices.FirstOrDefault(c =>
                c.id == id && c.CompanyId == (string)HttpContext.Current.Session["CompanyID"]).account;
            }
            if (ItemType.Equals(IWSLookUp.DocsType.GeneralLedgerIn.ToString()))
            {
                return IWSEntities.Settlements.FirstOrDefault(c =>
                c.id == id && c.CompanyId == (string)HttpContext.Current.Session["CompanyID"]).account;
            }
            return null;
        }
        public static string GetCostCenter(int id, string ItemType)
        {
            
            if (ItemType.Equals(IWSLookUp.DocsType.Settlement.ToString()))
            {
                return IWSEntities.CustomerInvoices.FirstOrDefault(c =>
                c.id == id && c.CompanyId == (string)HttpContext.Current.Session["CompanyID"]).CostCenter;
            }
            if (ItemType.Equals(IWSLookUp.DocsType.Payment.ToString()))
            {
                return IWSEntities.VendorInvoices.FirstOrDefault(c =>
                c.id == id && c.CompanyId == (string)HttpContext.Current.Session["CompanyID"]).CostCenter;
            }
            if (ItemType.Equals(IWSLookUp.DocsType.GeneralLedgerIn.ToString()))
            {
                return IWSEntities.Settlements.FirstOrDefault(c =>
                c.id == id && c.CompanyId == (string)HttpContext.Current.Session["CompanyID"]).CostCenter;
            }
            if (ItemType.Equals(IWSLookUp.DocsType.GeneralLedgerOut.ToString()))
            {
                return IWSEntities.Payments.FirstOrDefault(c =>
                c.id == id && c.CompanyId == (string)HttpContext.Current.Session["CompanyID"]).CostCenter;
            }
            return null;
        }
        public static IEnumerable GetGoodReceivingOID()
        {
            var query =
            from s in IWSEntities.Stores
            join p in IWSEntities.PurchaseOrders on new { id = s.id } equals new { id = p.store }
            join r in IWSEntities.Suppliers on new { account = p.account } equals new { account = r.id }
            where
              p.CompanyId == (string)HttpContext.Current.Session["CompanyID"]
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
            var query =
            from s in IWSEntities.Stores
            join g in IWSEntities.GoodReceivings on new { id = s.id } equals new { id = g.store }
            join r in IWSEntities.Suppliers on new { account = g.account } equals new { account = r.id }
            where
              g.CompanyId == (string)HttpContext.Current.Session["CompanyID"]
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
            var query =
            from s in IWSEntities.Stores
            join p in IWSEntities.InventoryInvoices on new { id = s.id } equals new { id = p.store }
            join r in IWSEntities.Suppliers on new { account = p.account } equals new { account = r.id }
            where
              p.CompanyId == (string)HttpContext.Current.Session["CompanyID"]
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
            var query =
            from s in IWSEntities.CostCenters
            join p in IWSEntities.VendorInvoices on new { id = s.id } equals new { id = p.CostCenter }
            join r in IWSEntities.Suppliers on new { account = p.account } equals new { account = r.id }
            where
              p.CompanyId == (string)HttpContext.Current.Session["CompanyID"]
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
            var query =
            from s in IWSEntities.Stores
            join p in IWSEntities.SalesOrders on new { id = s.id } equals new { id = p.store }
            join r in IWSEntities.Customers on new { account = p.account } equals new { account = r.id }
            where
              p.CompanyId == (string)HttpContext.Current.Session["CompanyID"]
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
            var query =
            from s in IWSEntities.Stores
            join p in IWSEntities.BillOfDeliveries on new { id = s.id } equals new { id = p.store }
            join r in IWSEntities.Customers on new { account = p.account } equals new { account = r.id }
            where
              p.CompanyId == (string)HttpContext.Current.Session["CompanyID"]
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
            var query =
            from s in IWSEntities.Stores
            join p in IWSEntities.SalesInvoices on new { id = s.id } equals new { id = p.store }
            join r in IWSEntities.Customers on new { account = p.account } equals new { account = r.id }
            where
              p.CompanyId == (string)HttpContext.Current.Session["CompanyID"]
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
            var query =
            from s in IWSEntities.CostCenters
            join p in IWSEntities.CustomerInvoices on new { id = s.id } equals new { id = p.CostCenter }
            join r in IWSEntities.Customers on new { account = p.account } equals new { account = r.id }
            where
              p.CompanyId == (string)HttpContext.Current.Session["CompanyID"]
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
            var q =
            from s in IWSEntities.CostCenters
            join p in IWSEntities.Settlements on new { id = s.id } equals new { id = p.CostCenter }
            join r in IWSEntities.Customers on new { account = p.account } equals new { account = r.id }
            where
              p.CompanyId == (string)HttpContext.Current.Session["CompanyID"]
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
            var query =
            from s in IWSEntities.CostCenters
            join p in IWSEntities.Payments on new { id = s.id } equals new { id = p.CostCenter }
            join r in IWSEntities.Suppliers on new { account = p.account } equals new { account = r.id }
            where
              p.CompanyId == (string)HttpContext.Current.Session["CompanyID"]
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
            HttpContext context = HttpContext.Current;
            string msg = ex.Message.ToString();
            string type = ex.GetType().Name.ToString();
            string source = ex.Source;
            string url = context.Request.Url.ToString();
            string target = ex.TargetSite.Name.ToString();
            string company = (string)HttpContext.Current.Session["CompanyID"];
            string userName = (string)HttpContext.Current.Session["UserName"];
            IWSEntities.LogException(msg, type, source, url, target, company, userName);
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
            BankStatement
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
    }
}