
namespace IWSProject.Models
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq;
    using System.Data.Linq.Mapping;
    using System.Linq;
    using System.Reflection;


    [global::System.Data.Linq.Mapping.DatabaseAttribute(Name = "iws")]
    public partial class IWSDataContext : System.Data.Linq.DataContext
    {

        private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();

        #region Extensibility Method Definitions
        partial void OnCreated();
        partial void InsertAccount(Account instance);
        partial void UpdateAccount(Account instance);
        partial void DeleteAccount(Account instance);
        partial void InsertVendorInvoice(VendorInvoice instance);
        partial void UpdateVendorInvoice(VendorInvoice instance);
        partial void DeleteVendorInvoice(VendorInvoice instance);
        partial void InsertArticle(Article instance);
        partial void UpdateArticle(Article instance);
        partial void DeleteArticle(Article instance);
        partial void InsertAspNetRole(AspNetRole instance);
        partial void UpdateAspNetRole(AspNetRole instance);
        partial void DeleteAspNetRole(AspNetRole instance);
        partial void InsertAspNetUserClaim(AspNetUserClaim instance);
        partial void UpdateAspNetUserClaim(AspNetUserClaim instance);
        partial void DeleteAspNetUserClaim(AspNetUserClaim instance);
        partial void InsertAspNetUserLogin(AspNetUserLogin instance);
        partial void UpdateAspNetUserLogin(AspNetUserLogin instance);
        partial void DeleteAspNetUserLogin(AspNetUserLogin instance);
        partial void InsertAspNetUserRole(AspNetUserRole instance);
        partial void UpdateAspNetUserRole(AspNetUserRole instance);
        partial void DeleteAspNetUserRole(AspNetUserRole instance);
        partial void InsertAspNetUser(AspNetUser instance);
        partial void UpdateAspNetUser(AspNetUser instance);
        partial void DeleteAspNetUser(AspNetUser instance);
        partial void InsertBank(Bank instance);
        partial void UpdateBank(Bank instance);
        partial void DeleteBank(Bank instance);
        partial void InsertBankAccount(BankAccount instance);
        partial void UpdateBankAccount(BankAccount instance);
        partial void DeleteBankAccount(BankAccount instance);
        partial void InsertBankStatement(BankStatement instance);
        partial void UpdateBankStatement(BankStatement instance);
        partial void DeleteBankStatement(BankStatement instance);
        partial void InsertBillOfDelivery(BillOfDelivery instance);
        partial void UpdateBillOfDelivery(BillOfDelivery instance);
        partial void DeleteBillOfDelivery(BillOfDelivery instance);
        partial void InsertCategory(Category instance);
        partial void UpdateCategory(Category instance);
        partial void DeleteCategory(Category instance);
        partial void InsertClassSetup(ClassSetup instance);
        partial void UpdateClassSetup(ClassSetup instance);
        partial void DeleteClassSetup(ClassSetup instance);
        partial void InsertCompany(Company instance);
        partial void UpdateCompany(Company instance);
        partial void DeleteCompany(Company instance);
        partial void InsertCostCenter(CostCenter instance);
        partial void UpdateCostCenter(CostCenter instance);
        partial void DeleteCostCenter(CostCenter instance);
        partial void InsertCountry(Country instance);
        partial void UpdateCountry(Country instance);
        partial void DeleteCountry(Country instance);
        partial void InsertCurrency(Currency instance);
        partial void UpdateCurrency(Currency instance);
        partial void DeleteCurrency(Currency instance);
        partial void InsertCustomer(Customer instance);
        partial void UpdateCustomer(Customer instance);
        partial void DeleteCustomer(Customer instance);
        partial void InsertCustomerInvoice(CustomerInvoice instance);
        partial void UpdateCustomerInvoice(CustomerInvoice instance);
        partial void DeleteCustomerInvoice(CustomerInvoice instance);
        partial void InsertGeneralLedger(GeneralLedger instance);
        partial void UpdateGeneralLedger(GeneralLedger instance);
        partial void DeleteGeneralLedger(GeneralLedger instance);
        partial void InsertGoodReceiving(GoodReceiving instance);
        partial void UpdateGoodReceiving(GoodReceiving instance);
        partial void DeleteGoodReceiving(GoodReceiving instance);
        partial void InsertInventoryInvoice(InventoryInvoice instance);
        partial void UpdateInventoryInvoice(InventoryInvoice instance);
        partial void DeleteInventoryInvoice(InventoryInvoice instance);
        partial void InsertJournal(Journal instance);
        partial void UpdateJournal(Journal instance);
        partial void DeleteJournal(Journal instance);
        partial void InsertJournalStock(JournalStock instance);
        partial void UpdateJournalStock(JournalStock instance);
        partial void DeleteJournalStock(JournalStock instance);
        partial void InsertLineBillOfDelivery(LineBillOfDelivery instance);
        partial void UpdateLineBillOfDelivery(LineBillOfDelivery instance);
        partial void DeleteLineBillOfDelivery(LineBillOfDelivery instance);
        partial void InsertLineCustomerInvoice(LineCustomerInvoice instance);
        partial void UpdateLineCustomerInvoice(LineCustomerInvoice instance);
        partial void DeleteLineCustomerInvoice(LineCustomerInvoice instance);
        partial void InsertLineGeneralLedger(LineGeneralLedger instance);
        partial void UpdateLineGeneralLedger(LineGeneralLedger instance);
        partial void DeleteLineGeneralLedger(LineGeneralLedger instance);
        partial void InsertLineGoodReceiving(LineGoodReceiving instance);
        partial void UpdateLineGoodReceiving(LineGoodReceiving instance);
        partial void DeleteLineGoodReceiving(LineGoodReceiving instance);
        partial void InsertLineInventoryInvoice(LineInventoryInvoice instance);
        partial void UpdateLineInventoryInvoice(LineInventoryInvoice instance);
        partial void DeleteLineInventoryInvoice(LineInventoryInvoice instance);
        partial void InsertLinePayment(LinePayment instance);
        partial void UpdateLinePayment(LinePayment instance);
        partial void DeleteLinePayment(LinePayment instance);
        partial void InsertLinePurchaseOrder(LinePurchaseOrder instance);
        partial void UpdateLinePurchaseOrder(LinePurchaseOrder instance);
        partial void DeleteLinePurchaseOrder(LinePurchaseOrder instance);
        partial void InsertLineSalesInvoice(LineSalesInvoice instance);
        partial void UpdateLineSalesInvoice(LineSalesInvoice instance);
        partial void DeleteLineSalesInvoice(LineSalesInvoice instance);
        partial void InsertLineSalesOrder(LineSalesOrder instance);
        partial void UpdateLineSalesOrder(LineSalesOrder instance);
        partial void DeleteLineSalesOrder(LineSalesOrder instance);
        partial void InsertLineSettlement(LineSettlement instance);
        partial void UpdateLineSettlement(LineSettlement instance);
        partial void DeleteLineSettlement(LineSettlement instance);
        partial void InsertLineVendorInvoice(LineVendorInvoice instance);
        partial void UpdateLineVendorInvoice(LineVendorInvoice instance);
        partial void DeleteLineVendorInvoice(LineVendorInvoice instance);
        partial void InsertLocalization(Localization instance);
        partial void UpdateLocalization(Localization instance);
        partial void DeleteLocalization(Localization instance);
        partial void InsertLogException(LogException instance);
        partial void UpdateLogException(LogException instance);
        partial void DeleteLogException(LogException instance);
        partial void InsertMenu(Menu instance);
        partial void UpdateMenu(Menu instance);
        partial void DeleteMenu(Menu instance);
        partial void InsertPayment(Payment instance);
        partial void UpdatePayment(Payment instance);
        partial void DeletePayment(Payment instance);
        partial void InsertPeriodicAccountBalance(PeriodicAccountBalance instance);
        partial void UpdatePeriodicAccountBalance(PeriodicAccountBalance instance);
        partial void DeletePeriodicAccountBalance(PeriodicAccountBalance instance);
        partial void InsertPurchaseOrder(PurchaseOrder instance);
        partial void UpdatePurchaseOrder(PurchaseOrder instance);
        partial void DeletePurchaseOrder(PurchaseOrder instance);
        partial void InsertQuantityUnit(QuantityUnit instance);
        partial void UpdateQuantityUnit(QuantityUnit instance);
        partial void DeleteQuantityUnit(QuantityUnit instance);
        partial void InsertSalesInvoice(SalesInvoice instance);
        partial void UpdateSalesInvoice(SalesInvoice instance);
        partial void DeleteSalesInvoice(SalesInvoice instance);
        partial void InsertSalesOrder(SalesOrder instance);
        partial void UpdateSalesOrder(SalesOrder instance);
        partial void DeleteSalesOrder(SalesOrder instance);
        partial void InsertSettlement(Settlement instance);
        partial void UpdateSettlement(Settlement instance);
        partial void DeleteSettlement(Settlement instance);
        partial void InsertStock(Stock instance);
        partial void UpdateStock(Stock instance);
        partial void DeleteStock(Stock instance);
        partial void InsertStore(Store instance);
        partial void UpdateStore(Store instance);
        partial void DeleteStore(Store instance);
        partial void InsertSupplier(Supplier instance);
        partial void UpdateSupplier(Supplier instance);
        partial void DeleteSupplier(Supplier instance);
        partial void InsertVat(Vat instance);
        partial void UpdateVat(Vat instance);
        partial void DeleteVat(Vat instance);
        #endregion

        public IWSDataContext() :
                base(global::System.Configuration.ConfigurationManager.ConnectionStrings["IWSConnectionString"].ConnectionString, mappingSource)
        {
            OnCreated();
        }

        public IWSDataContext(string connection) :
                base(connection, mappingSource)
        {
            OnCreated();
        }

        public IWSDataContext(System.Data.IDbConnection connection) :
                base(connection, mappingSource)
        {
            OnCreated();
        }

        public IWSDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) :
                base(connection, mappingSource)
        {
            OnCreated();
        }

        public IWSDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) :
                base(connection, mappingSource)
        {
            OnCreated();
        }

        public System.Data.Linq.Table<Account> Accounts
        {
            get
            {
                return this.GetTable<Account>();
            }
        }

        public System.Data.Linq.Table<VendorInvoice> VendorInvoices
        {
            get
            {
                return this.GetTable<VendorInvoice>();
            }
        }

        public System.Data.Linq.Table<Article> Articles
        {
            get
            {
                return this.GetTable<Article>();
            }
        }

        public System.Data.Linq.Table<AspNetRole> AspNetRoles
        {
            get
            {
                return this.GetTable<AspNetRole>();
            }
        }

        public System.Data.Linq.Table<AspNetUserClaim> AspNetUserClaims
        {
            get
            {
                return this.GetTable<AspNetUserClaim>();
            }
        }

        public System.Data.Linq.Table<AspNetUserLogin> AspNetUserLogins
        {
            get
            {
                return this.GetTable<AspNetUserLogin>();
            }
        }

        public System.Data.Linq.Table<AspNetUserRole> AspNetUserRoles
        {
            get
            {
                return this.GetTable<AspNetUserRole>();
            }
        }

        public System.Data.Linq.Table<AspNetUser> AspNetUsers
        {
            get
            {
                return this.GetTable<AspNetUser>();
            }
        }

        public System.Data.Linq.Table<Bank> Banks
        {
            get
            {
                return this.GetTable<Bank>();
            }
        }

        public System.Data.Linq.Table<BankAccount> BankAccounts
        {
            get
            {
                return this.GetTable<BankAccount>();
            }
        }

        public System.Data.Linq.Table<BankStatement> BankStatements
        {
            get
            {
                return this.GetTable<BankStatement>();
            }
        }

        public System.Data.Linq.Table<bckBankStatement> bckBankStatements
        {
            get
            {
                return this.GetTable<bckBankStatement>();
            }
        }

        public System.Data.Linq.Table<bckBankStatement0812> bckBankStatement0812s
        {
            get
            {
                return this.GetTable<bckBankStatement0812>();
            }
        }

        public System.Data.Linq.Table<bckStatement> bckStatements
        {
            get
            {
                return this.GetTable<bckStatement>();
            }
        }

        public System.Data.Linq.Table<BillOfDelivery> BillOfDeliveries
        {
            get
            {
                return this.GetTable<BillOfDelivery>();
            }
        }

        public System.Data.Linq.Table<Category> Categories
        {
            get
            {
                return this.GetTable<Category>();
            }
        }

        public System.Data.Linq.Table<ClassSetup> ClassSetups
        {
            get
            {
                return this.GetTable<ClassSetup>();
            }
        }

        public System.Data.Linq.Table<Company> Companies
        {
            get
            {
                return this.GetTable<Company>();
            }
        }

        public System.Data.Linq.Table<CostCenter> CostCenters
        {
            get
            {
                return this.GetTable<CostCenter>();
            }
        }

        public System.Data.Linq.Table<Country> Countries
        {
            get
            {
                return this.GetTable<Country>();
            }
        }

        public System.Data.Linq.Table<Currency> Currencies
        {
            get
            {
                return this.GetTable<Currency>();
            }
        }

        public System.Data.Linq.Table<Customer> Customers
        {
            get
            {
                return this.GetTable<Customer>();
            }
        }

        public System.Data.Linq.Table<CustomerInvoice> CustomerInvoices
        {
            get
            {
                return this.GetTable<CustomerInvoice>();
            }
        }

        public System.Data.Linq.Table<GeneralLedger> GeneralLedgers
        {
            get
            {
                return this.GetTable<GeneralLedger>();
            }
        }

        public System.Data.Linq.Table<GoodReceiving> GoodReceivings
        {
            get
            {
                return this.GetTable<GoodReceiving>();
            }
        }

        public System.Data.Linq.Table<InventoryInvoice> InventoryInvoices
        {
            get
            {
                return this.GetTable<InventoryInvoice>();
            }
        }

        public System.Data.Linq.Table<Journal> Journals
        {
            get
            {
                return this.GetTable<Journal>();
            }
        }

        public System.Data.Linq.Table<JournalStock> JournalStocks
        {
            get
            {
                return this.GetTable<JournalStock>();
            }
        }

        public System.Data.Linq.Table<LineBillOfDelivery> LineBillOfDeliveries
        {
            get
            {
                return this.GetTable<LineBillOfDelivery>();
            }
        }

        public System.Data.Linq.Table<LineCustomerInvoice> LineCustomerInvoices
        {
            get
            {
                return this.GetTable<LineCustomerInvoice>();
            }
        }

        public System.Data.Linq.Table<LineGeneralLedger> LineGeneralLedgers
        {
            get
            {
                return this.GetTable<LineGeneralLedger>();
            }
        }

        public System.Data.Linq.Table<LineGoodReceiving> LineGoodReceivings
        {
            get
            {
                return this.GetTable<LineGoodReceiving>();
            }
        }

        public System.Data.Linq.Table<LineInventoryInvoice> LineInventoryInvoices
        {
            get
            {
                return this.GetTable<LineInventoryInvoice>();
            }
        }

        public System.Data.Linq.Table<LinePayment> LinePayments
        {
            get
            {
                return this.GetTable<LinePayment>();
            }
        }

        public System.Data.Linq.Table<LinePurchaseOrder> LinePurchaseOrders
        {
            get
            {
                return this.GetTable<LinePurchaseOrder>();
            }
        }

        public System.Data.Linq.Table<LineSalesInvoice> LineSalesInvoices
        {
            get
            {
                return this.GetTable<LineSalesInvoice>();
            }
        }

        public System.Data.Linq.Table<LineSalesOrder> LineSalesOrders
        {
            get
            {
                return this.GetTable<LineSalesOrder>();
            }
        }

        public System.Data.Linq.Table<LineSettlement> LineSettlements
        {
            get
            {
                return this.GetTable<LineSettlement>();
            }
        }

        public System.Data.Linq.Table<LineVendorInvoice> LineVendorInvoices
        {
            get
            {
                return this.GetTable<LineVendorInvoice>();
            }
        }

        public System.Data.Linq.Table<Localization> Localizations
        {
            get
            {
                return this.GetTable<Localization>();
            }
        }

        public System.Data.Linq.Table<LogException> LogExceptions
        {
            get
            {
                return this.GetTable<LogException>();
            }
        }

        public System.Data.Linq.Table<Menu> Menus
        {
            get
            {
                return this.GetTable<Menu>();
            }
        }

        public System.Data.Linq.Table<Payment> Payments
        {
            get
            {
                return this.GetTable<Payment>();
            }
        }

        public System.Data.Linq.Table<PeriodicAccountBalance> PeriodicAccountBalances
        {
            get
            {
                return this.GetTable<PeriodicAccountBalance>();
            }
        }

        public System.Data.Linq.Table<PurchaseOrder> PurchaseOrders
        {
            get
            {
                return this.GetTable<PurchaseOrder>();
            }
        }

        public System.Data.Linq.Table<QuantityUnit> QuantityUnits
        {
            get
            {
                return this.GetTable<QuantityUnit>();
            }
        }

        public System.Data.Linq.Table<SalesInvoice> SalesInvoices
        {
            get
            {
                return this.GetTable<SalesInvoice>();
            }
        }

        public System.Data.Linq.Table<SalesOrder> SalesOrders
        {
            get
            {
                return this.GetTable<SalesOrder>();
            }
        }

        public System.Data.Linq.Table<Settlement> Settlements
        {
            get
            {
                return this.GetTable<Settlement>();
            }
        }

        public System.Data.Linq.Table<Stock> Stocks
        {
            get
            {
                return this.GetTable<Stock>();
            }
        }

        public System.Data.Linq.Table<Store> Stores
        {
            get
            {
                return this.GetTable<Store>();
            }
        }

        public System.Data.Linq.Table<Supplier> Suppliers
        {
            get
            {
                return this.GetTable<Supplier>();
            }
        }

        public System.Data.Linq.Table<tmpBalance> tmpBalances
        {
            get
            {
                return this.GetTable<tmpBalance>();
            }
        }

        public System.Data.Linq.Table<tmpPeriodic> tmpPeriodics
        {
            get
            {
                return this.GetTable<tmpPeriodic>();
            }
        }

        public System.Data.Linq.Table<Vat> Vats
        {
            get
            {
                return this.GetTable<Vat>();
            }
        }

        [global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.account1To7")]
        public ISingleResult<account1To7Result> account1To7([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(6)")] string start, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(6)")] string end, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(6)")] string companyid)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), start, end, companyid);
            return ((ISingleResult<account1To7Result>)(result.ReturnValue));
        }

        [global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.PeriodicBalances")]
        public ISingleResult<PeriodicBalancesResult> PeriodicBalances([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(6)")] string start, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(6)")] string end, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Bit")] System.Nullable<bool> detail, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(6)")] string companyid)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), start, end, detail, companyid);
            return ((ISingleResult<PeriodicBalancesResult>)(result.ReturnValue));
        }

        [global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.AccountBalance")]
        public ISingleResult<AccountBalanceResult> AccountBalance([global::System.Data.Linq.Mapping.ParameterAttribute(Name = "class", DbType = "NVarChar(50)")] string @class, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(6)")] string start, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(6)")] string end, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(6)")] string companyid, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Bit")] System.Nullable<bool> isBalance)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), @class, start, end, companyid, isBalance);
            return ((ISingleResult<AccountBalanceResult>)(result.ReturnValue));
        }

        [global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.ClassAccountBalance")]
        public ISingleResult<ClassAccountBalanceResult> ClassAccountBalance([global::System.Data.Linq.Mapping.ParameterAttribute(Name = "class", DbType = "NVarChar(12)")] string @class, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(6)")] string start, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(6)")] string end, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(6)")] string companyid)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), @class, start, end, companyid);
            return ((ISingleResult<ClassAccountBalanceResult>)(result.ReturnValue));
        }

        [global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.ClassAccountBalances")]
        public ISingleResult<ClassAccountBalancesResult> ClassAccountBalances([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(6)")] string start, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(6)")] string end, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(6)")] string companyid)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), start, end, companyid);
            return ((ISingleResult<ClassAccountBalancesResult>)(result.ReturnValue));
        }

        [global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.ClassChild")]
        public ISingleResult<ClassChildResult> ClassChild([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(50)")] string classId, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(50)")] string company)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), classId, company);
            return ((ISingleResult<ClassChildResult>)(result.ReturnValue));
        }

        [global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.LogException")]
        public int LogException([global::System.Data.Linq.Mapping.ParameterAttribute(Name = "Message", DbType = "NVarChar(256)")] string message, [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "Type", DbType = "NVarChar(256)")] string type, [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "Source", DbType = "NVarChar(256)")] string source, [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "URL", DbType = "NVarChar(256)")] string uRL, [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "Target", DbType = "NVarChar(256)")] string target, [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ComapnyId", DbType = "NVarChar(6)")] string comapnyId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "UserName", DbType = "NVarChar(6)")] string userName)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), message, type, source, uRL, target, comapnyId, userName);
            return ((int)(result.ReturnValue));
        }

        [global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.GetAccountBalance", IsComposable = true)]
        public IQueryable<GetAccountBalanceResult> GetAccountBalance([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(50)")] string id, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(6)")] string start, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(6)")] string end, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(6)")] string companyid)
        {
            return this.CreateMethodCallQuery<GetAccountBalanceResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), id, start, end, companyid);
        }

        [global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.GetBalanceSheetChildren", IsComposable = true)]
        public IQueryable<GetBalanceSheetChildrenResult> GetBalanceSheetChildren([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(50)")] string id, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(50)")] string companyid, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Bit")] System.Nullable<bool> isBalanceSheetAccount)
        {
            return this.CreateMethodCallQuery<GetBalanceSheetChildrenResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), id, companyid, isBalanceSheetAccount);
        }

        [global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.GetAccountBalances", IsComposable = true)]
        public IQueryable<GetAccountBalancesResult> GetAccountBalances([global::System.Data.Linq.Mapping.ParameterAttribute(Name = "class", DbType = "NVarChar(12)")] string @class, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(6)")] string start, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(6)")] string end, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(6)")] string companyid)
        {
            return this.CreateMethodCallQuery<GetAccountBalancesResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), @class, start, end, companyid);
        }

        [global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.GetChild", IsComposable = true)]
        public IQueryable<GetChildResult> GetChild([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(50)")] string classId, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(50)")] string companyid)
        {
            return this.CreateMethodCallQuery<GetChildResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), classId, companyid);
        }

        [global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.GetChildren", IsComposable = true)]
        public IQueryable<GetChildrenResult> GetChildren([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(50)")] string id, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(50)")] string companyid)
        {
            return this.CreateMethodCallQuery<GetChildrenResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), id, companyid);
        }

        [global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.GetJournal", IsComposable = true)]
        public IQueryable<GetJournalResult> GetJournal([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(6)")] string start, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(6)")] string end, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(5)")] string uiculture, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(6)")] string companyid)
        {
            return this.CreateMethodCallQuery<GetJournalResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), start, end, uiculture, companyid);
        }

        [global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.GetJournals", IsComposable = true)]
        public IQueryable<GetJournalsResult> GetJournals([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(6)")] string start, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(6)")] string end, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(5)")] string uiculture, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(6)")] string companyid)
        {
            return this.CreateMethodCallQuery<GetJournalsResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), start, end, uiculture, companyid);
        }

        [global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.GetParents", IsComposable = true)]
        public IQueryable<GetParentsResult> GetParents([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(50)")] string id, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(50)")] string companyid)
        {
            return this.CreateMethodCallQuery<GetParentsResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), id, companyid);
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.Account")]
    public partial class Account : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _id;

        private string _name;

        private string _description;

        private System.Nullable<System.DateTime> _dateofopen;

        private System.Nullable<System.DateTime> _dateofclose;

        private decimal _balance;

        private string _CompanyID;

        private string _ParentId;

        private bool _IsUsed;

        private System.Nullable<bool> _IsBalanceSheetAccount;

        private EntitySet<ClassSetup> _ClassSetups;

        private EntitySet<CostCenter> _CostCenters;

        private EntitySet<Journal> _Journals;

        private EntitySet<Journal> _Journals1;

        private EntitySet<PeriodicAccountBalance> _PeriodicAccountBalances;

        private EntitySet<Store> _Stores;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnidChanging(string value);
        partial void OnidChanged();
        partial void OnnameChanging(string value);
        partial void OnnameChanged();
        partial void OndescriptionChanging(string value);
        partial void OndescriptionChanged();
        partial void OndateofopenChanging(System.Nullable<System.DateTime> value);
        partial void OndateofopenChanged();
        partial void OndateofcloseChanging(System.Nullable<System.DateTime> value);
        partial void OndateofcloseChanged();
        partial void OnbalanceChanging(decimal value);
        partial void OnbalanceChanged();
        partial void OnCompanyIDChanging(string value);
        partial void OnCompanyIDChanged();
        partial void OnParentIdChanging(string value);
        partial void OnParentIdChanged();
        partial void OnIsUsedChanging(bool value);
        partial void OnIsUsedChanged();
        partial void OnIsBalanceSheetAccountChanging(System.Nullable<bool> value);
        partial void OnIsBalanceSheetAccountChanged();
        #endregion

        public Account()
        {
            this._ClassSetups = new EntitySet<ClassSetup>(new Action<ClassSetup>(this.attach_ClassSetups), new Action<ClassSetup>(this.detach_ClassSetups));
            this._CostCenters = new EntitySet<CostCenter>(new Action<CostCenter>(this.attach_CostCenters), new Action<CostCenter>(this.detach_CostCenters));
            this._Journals = new EntitySet<Journal>(new Action<Journal>(this.attach_Journals), new Action<Journal>(this.detach_Journals));
            this._Journals1 = new EntitySet<Journal>(new Action<Journal>(this.attach_Journals1), new Action<Journal>(this.detach_Journals1));
            this._PeriodicAccountBalances = new EntitySet<PeriodicAccountBalance>(new Action<PeriodicAccountBalance>(this.attach_PeriodicAccountBalances), new Action<PeriodicAccountBalance>(this.detach_PeriodicAccountBalances));
            this._Stores = new EntitySet<Store>(new Action<Store>(this.attach_Stores), new Action<Store>(this.detach_Stores));
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id", DbType = "NVarChar(50) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    this.OnidChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("id");
                    this.OnidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_name", DbType = "NVarChar(255)")]
        public string name
        {
            get
            {
                return this._name;
            }
            set
            {
                if ((this._name != value))
                {
                    this.OnnameChanging(value);
                    this.SendPropertyChanging();
                    this._name = value;
                    this.SendPropertyChanged("name");
                    this.OnnameChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_description", DbType = "NVarChar(255)")]
        public string description
        {
            get
            {
                return this._description;
            }
            set
            {
                if ((this._description != value))
                {
                    this.OndescriptionChanging(value);
                    this.SendPropertyChanging();
                    this._description = value;
                    this.SendPropertyChanged("description");
                    this.OndescriptionChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_dateofopen", DbType = "DateTime2")]
        public System.Nullable<System.DateTime> dateofopen
        {
            get
            {
                return this._dateofopen;
            }
            set
            {
                if ((this._dateofopen != value))
                {
                    this.OndateofopenChanging(value);
                    this.SendPropertyChanging();
                    this._dateofopen = value;
                    this.SendPropertyChanged("dateofopen");
                    this.OndateofopenChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_dateofclose", DbType = "DateTime2")]
        public System.Nullable<System.DateTime> dateofclose
        {
            get
            {
                return this._dateofclose;
            }
            set
            {
                if ((this._dateofclose != value))
                {
                    this.OndateofcloseChanging(value);
                    this.SendPropertyChanging();
                    this._dateofclose = value;
                    this.SendPropertyChanged("dateofclose");
                    this.OndateofcloseChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_balance", DbType = "Money NOT NULL")]
        public decimal balance
        {
            get
            {
                return this._balance;
            }
            set
            {
                if ((this._balance != value))
                {
                    this.OnbalanceChanging(value);
                    this.SendPropertyChanging();
                    this._balance = value;
                    this.SendPropertyChanged("balance");
                    this.OnbalanceChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CompanyID
        {
            get
            {
                return this._CompanyID;
            }
            set
            {
                if ((this._CompanyID != value))
                {
                    this.OnCompanyIDChanging(value);
                    this.SendPropertyChanging();
                    this._CompanyID = value;
                    this.SendPropertyChanged("CompanyID");
                    this.OnCompanyIDChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ParentId", DbType = "NVarChar(50)")]
        public string ParentId
        {
            get
            {
                return this._ParentId;
            }
            set
            {
                if ((this._ParentId != value))
                {
                    this.OnParentIdChanging(value);
                    this.SendPropertyChanging();
                    this._ParentId = value;
                    this.SendPropertyChanged("ParentId");
                    this.OnParentIdChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IsUsed", DbType = "Bit NOT NULL")]
        public bool IsUsed
        {
            get
            {
                return this._IsUsed;
            }
            set
            {
                if ((this._IsUsed != value))
                {
                    this.OnIsUsedChanging(value);
                    this.SendPropertyChanging();
                    this._IsUsed = value;
                    this.SendPropertyChanged("IsUsed");
                    this.OnIsUsedChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IsBalanceSheetAccount", DbType = "Bit")]
        public System.Nullable<bool> IsBalanceSheetAccount
        {
            get
            {
                return this._IsBalanceSheetAccount;
            }
            set
            {
                if ((this._IsBalanceSheetAccount != value))
                {
                    this.OnIsBalanceSheetAccountChanging(value);
                    this.SendPropertyChanging();
                    this._IsBalanceSheetAccount = value;
                    this.SendPropertyChanged("IsBalanceSheetAccount");
                    this.OnIsBalanceSheetAccountChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Account_ClassSetup", Storage = "_ClassSetups", ThisKey = "id", OtherKey = "ClassID")]
        public EntitySet<ClassSetup> ClassSetups
        {
            get
            {
                return this._ClassSetups;
            }
            set
            {
                this._ClassSetups.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Account_CostCenter", Storage = "_CostCenters", ThisKey = "id", OtherKey = "accountid")]
        public EntitySet<CostCenter> CostCenters
        {
            get
            {
                return this._CostCenters;
            }
            set
            {
                this._CostCenters.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Account_Journal", Storage = "_Journals", ThisKey = "id", OtherKey = "Account")]
        public EntitySet<Journal> Journals
        {
            get
            {
                return this._Journals;
            }
            set
            {
                this._Journals.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Account_Journal1", Storage = "_Journals1", ThisKey = "id", OtherKey = "OAccount")]
        public EntitySet<Journal> Journals1
        {
            get
            {
                return this._Journals1;
            }
            set
            {
                this._Journals1.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Account_PeriodicAccountBalance", Storage = "_PeriodicAccountBalances", ThisKey = "id", OtherKey = "AccountId")]
        public EntitySet<PeriodicAccountBalance> PeriodicAccountBalances
        {
            get
            {
                return this._PeriodicAccountBalances;
            }
            set
            {
                this._PeriodicAccountBalances.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Account_Store", Storage = "_Stores", ThisKey = "id", OtherKey = "accountid")]
        public EntitySet<Store> Stores
        {
            get
            {
                return this._Stores;
            }
            set
            {
                this._Stores.Assign(value);
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void attach_ClassSetups(ClassSetup entity)
        {
            this.SendPropertyChanging();
            entity.Account = this;
        }

        private void detach_ClassSetups(ClassSetup entity)
        {
            this.SendPropertyChanging();
            entity.Account = null;
        }

        private void attach_CostCenters(CostCenter entity)
        {
            this.SendPropertyChanging();
            entity.Account = this;
        }

        private void detach_CostCenters(CostCenter entity)
        {
            this.SendPropertyChanging();
            entity.Account = null;
        }

        private void attach_Journals(Journal entity)
        {
            this.SendPropertyChanging();
            entity.Account1 = this;
        }

        private void detach_Journals(Journal entity)
        {
            this.SendPropertyChanging();
            entity.Account1 = null;
        }

        private void attach_Journals1(Journal entity)
        {
            this.SendPropertyChanging();
            entity.Account2 = this;
        }

        private void detach_Journals1(Journal entity)
        {
            this.SendPropertyChanging();
            entity.Account2 = null;
        }

        private void attach_PeriodicAccountBalances(PeriodicAccountBalance entity)
        {
            this.SendPropertyChanging();
            entity.Account = this;
        }

        private void detach_PeriodicAccountBalances(PeriodicAccountBalance entity)
        {
            this.SendPropertyChanging();
            entity.Account = null;
        }

        private void attach_Stores(Store entity)
        {
            this.SendPropertyChanging();
            entity.Account = this;
        }

        private void detach_Stores(Store entity)
        {
            this.SendPropertyChanging();
            entity.Account = null;
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.VendorInvoice")]
    public partial class VendorInvoice : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _id;

        private int _oid;

        private string _CostCenter;

        private string _account;

        private string _HeaderText;

        private System.DateTime _TransDate;

        private System.DateTime _ItemDate;

        private System.DateTime _EntryDate;

        private string _CompanyId;

        private bool _IsValidated;

        private System.Nullable<decimal> _oTotal;

        private string _oCurrency;

        private string _oPeriode;

        private EntitySet<LineVendorInvoice> _LineVendorInvoices;

        private EntityRef<Company> _Company;

        private EntityRef<CostCenter> _CostCenter1;

        private EntityRef<Supplier> _Supplier;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnidChanging(int value);
        partial void OnidChanged();
        partial void OnoidChanging(int value);
        partial void OnoidChanged();
        partial void OnCostCenterChanging(string value);
        partial void OnCostCenterChanged();
        partial void OnaccountChanging(string value);
        partial void OnaccountChanged();
        partial void OnHeaderTextChanging(string value);
        partial void OnHeaderTextChanged();
        partial void OnTransDateChanging(System.DateTime value);
        partial void OnTransDateChanged();
        partial void OnItemDateChanging(System.DateTime value);
        partial void OnItemDateChanged();
        partial void OnEntryDateChanging(System.DateTime value);
        partial void OnEntryDateChanged();
        partial void OnCompanyIdChanging(string value);
        partial void OnCompanyIdChanged();
        partial void OnIsValidatedChanging(bool value);
        partial void OnIsValidatedChanged();
        partial void OnoTotalChanging(System.Nullable<decimal> value);
        partial void OnoTotalChanged();
        partial void OnoCurrencyChanging(string value);
        partial void OnoCurrencyChanged();
        partial void OnoPeriodeChanging(string value);
        partial void OnoPeriodeChanged();
        #endregion

        public VendorInvoice()
        {
            this._LineVendorInvoices = new EntitySet<LineVendorInvoice>(new Action<LineVendorInvoice>(this.attach_LineVendorInvoices), new Action<LineVendorInvoice>(this.detach_LineVendorInvoices));
            this._Company = default(EntityRef<Company>);
            this._CostCenter1 = default(EntityRef<CostCenter>);
            this._Supplier = default(EntityRef<Supplier>);
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    this.OnidChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("id");
                    this.OnidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oid", DbType = "Int NOT NULL")]
        public int oid
        {
            get
            {
                return this._oid;
            }
            set
            {
                if ((this._oid != value))
                {
                    this.OnoidChanging(value);
                    this.SendPropertyChanging();
                    this._oid = value;
                    this.SendPropertyChanged("oid");
                    this.OnoidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CostCenter", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CostCenter
        {
            get
            {
                return this._CostCenter;
            }
            set
            {
                if ((this._CostCenter != value))
                {
                    if (this._CostCenter1.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnCostCenterChanging(value);
                    this.SendPropertyChanging();
                    this._CostCenter = value;
                    this.SendPropertyChanged("CostCenter");
                    this.OnCostCenterChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_account", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string account
        {
            get
            {
                return this._account;
            }
            set
            {
                if ((this._account != value))
                {
                    if (this._Supplier.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnaccountChanging(value);
                    this.SendPropertyChanging();
                    this._account = value;
                    this.SendPropertyChanged("account");
                    this.OnaccountChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_HeaderText", DbType = "NVarChar(250) NOT NULL", CanBeNull = false)]
        public string HeaderText
        {
            get
            {
                return this._HeaderText;
            }
            set
            {
                if ((this._HeaderText != value))
                {
                    this.OnHeaderTextChanging(value);
                    this.SendPropertyChanging();
                    this._HeaderText = value;
                    this.SendPropertyChanged("HeaderText");
                    this.OnHeaderTextChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TransDate", DbType = "Date NOT NULL")]
        public System.DateTime TransDate
        {
            get
            {
                return this._TransDate;
            }
            set
            {
                if ((this._TransDate != value))
                {
                    this.OnTransDateChanging(value);
                    this.SendPropertyChanging();
                    this._TransDate = value;
                    this.SendPropertyChanged("TransDate");
                    this.OnTransDateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ItemDate", DbType = "Date NOT NULL")]
        public System.DateTime ItemDate
        {
            get
            {
                return this._ItemDate;
            }
            set
            {
                if ((this._ItemDate != value))
                {
                    this.OnItemDateChanging(value);
                    this.SendPropertyChanging();
                    this._ItemDate = value;
                    this.SendPropertyChanged("ItemDate");
                    this.OnItemDateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_EntryDate", DbType = "Date NOT NULL")]
        public System.DateTime EntryDate
        {
            get
            {
                return this._EntryDate;
            }
            set
            {
                if ((this._EntryDate != value))
                {
                    this.OnEntryDateChanging(value);
                    this.SendPropertyChanging();
                    this._EntryDate = value;
                    this.SendPropertyChanged("EntryDate");
                    this.OnEntryDateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyId", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CompanyId
        {
            get
            {
                return this._CompanyId;
            }
            set
            {
                if ((this._CompanyId != value))
                {
                    if (this._Company.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnCompanyIdChanging(value);
                    this.SendPropertyChanging();
                    this._CompanyId = value;
                    this.SendPropertyChanged("CompanyId");
                    this.OnCompanyIdChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IsValidated", DbType = "Bit NOT NULL")]
        public bool IsValidated
        {
            get
            {
                return this._IsValidated;
            }
            set
            {
                if ((this._IsValidated != value))
                {
                    this.OnIsValidatedChanging(value);
                    this.SendPropertyChanging();
                    this._IsValidated = value;
                    this.SendPropertyChanged("IsValidated");
                    this.OnIsValidatedChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oTotal", AutoSync = AutoSync.Always, DbType = "Money", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<decimal> oTotal
        {
            get
            {
                return this._oTotal;
            }
            set
            {
                if ((this._oTotal != value))
                {
                    this.OnoTotalChanging(value);
                    this.SendPropertyChanging();
                    this._oTotal = value;
                    this.SendPropertyChanged("oTotal");
                    this.OnoTotalChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oCurrency", AutoSync = AutoSync.Always, DbType = "NVarChar(10)", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public string oCurrency
        {
            get
            {
                return this._oCurrency;
            }
            set
            {
                if ((this._oCurrency != value))
                {
                    this.OnoCurrencyChanging(value);
                    this.SendPropertyChanging();
                    this._oCurrency = value;
                    this.SendPropertyChanged("oCurrency");
                    this.OnoCurrencyChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oPeriode", AutoSync = AutoSync.Always, DbType = "NVarChar(6)", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public string oPeriode
        {
            get
            {
                return this._oPeriode;
            }
            set
            {
                if ((this._oPeriode != value))
                {
                    this.OnoPeriodeChanging(value);
                    this.SendPropertyChanging();
                    this._oPeriode = value;
                    this.SendPropertyChanged("oPeriode");
                    this.OnoPeriodeChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "VendorInvoice_LineVendorInvoice", Storage = "_LineVendorInvoices", ThisKey = "id", OtherKey = "transid")]
        public EntitySet<LineVendorInvoice> LineVendorInvoices
        {
            get
            {
                return this._LineVendorInvoices;
            }
            set
            {
                this._LineVendorInvoices.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Company_VendorInvoice", Storage = "_Company", ThisKey = "CompanyId", OtherKey = "id", IsForeignKey = true)]
        public Company Company
        {
            get
            {
                return this._Company.Entity;
            }
            set
            {
                Company previousValue = this._Company.Entity;
                if (((previousValue != value)
                            || (this._Company.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Company.Entity = null;
                        previousValue.VendorInvoices.Remove(this);
                    }
                    this._Company.Entity = value;
                    if ((value != null))
                    {
                        value.VendorInvoices.Add(this);
                        this._CompanyId = value.id;
                    }
                    else
                    {
                        this._CompanyId = default(string);
                    }
                    this.SendPropertyChanged("Company");
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "CostCenter_VendorInvoice", Storage = "_CostCenter1", ThisKey = "CostCenter", OtherKey = "id", IsForeignKey = true)]
        public CostCenter CostCenter1
        {
            get
            {
                return this._CostCenter1.Entity;
            }
            set
            {
                CostCenter previousValue = this._CostCenter1.Entity;
                if (((previousValue != value)
                            || (this._CostCenter1.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._CostCenter1.Entity = null;
                        previousValue.VendorInvoices.Remove(this);
                    }
                    this._CostCenter1.Entity = value;
                    if ((value != null))
                    {
                        value.VendorInvoices.Add(this);
                        this._CostCenter = value.id;
                    }
                    else
                    {
                        this._CostCenter = default(string);
                    }
                    this.SendPropertyChanged("CostCenter1");
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Supplier_VendorInvoice", Storage = "_Supplier", ThisKey = "account", OtherKey = "id", IsForeignKey = true)]
        public Supplier Supplier
        {
            get
            {
                return this._Supplier.Entity;
            }
            set
            {
                Supplier previousValue = this._Supplier.Entity;
                if (((previousValue != value)
                            || (this._Supplier.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Supplier.Entity = null;
                        previousValue.VendorInvoices.Remove(this);
                    }
                    this._Supplier.Entity = value;
                    if ((value != null))
                    {
                        value.VendorInvoices.Add(this);
                        this._account = value.id;
                    }
                    else
                    {
                        this._account = default(string);
                    }
                    this.SendPropertyChanged("Supplier");
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void attach_LineVendorInvoices(LineVendorInvoice entity)
        {
            this.SendPropertyChanging();
            entity.VendorInvoice = this;
        }

        private void detach_LineVendorInvoices(LineVendorInvoice entity)
        {
            this.SendPropertyChanging();
            entity.VendorInvoice = null;
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.Article")]
    public partial class Article : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _id;

        private string _name;

        private string _description;

        private decimal _price;

        private decimal _avgprice;

        private decimal _salesprice;

        private string _qttyunit;

        private string _packunit;

        private string _VatCode;

        private bool _IsService;

        private string _CompanyID;

        private string _StockAccount;

        private string _ExpenseAccount;

        private string _Currency;

        private string _GroupId;

        private string _RevenuAccountId;

        private EntitySet<LineBillOfDelivery> _LineBillOfDeliveries;

        private EntitySet<LineGoodReceiving> _LineGoodReceivings;

        private EntitySet<LineInventoryInvoice> _LineInventoryInvoices;

        private EntitySet<LinePurchaseOrder> _LinePurchaseOrders;

        private EntitySet<LineSalesInvoice> _LineSalesInvoices;

        private EntitySet<LineSalesOrder> _LineSalesOrders;

        private EntitySet<Stock> _Stocks;

        private EntityRef<Vat> _Vat;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnidChanging(string value);
        partial void OnidChanged();
        partial void OnnameChanging(string value);
        partial void OnnameChanged();
        partial void OndescriptionChanging(string value);
        partial void OndescriptionChanged();
        partial void OnpriceChanging(decimal value);
        partial void OnpriceChanged();
        partial void OnavgpriceChanging(decimal value);
        partial void OnavgpriceChanged();
        partial void OnsalespriceChanging(decimal value);
        partial void OnsalespriceChanged();
        partial void OnqttyunitChanging(string value);
        partial void OnqttyunitChanged();
        partial void OnpackunitChanging(string value);
        partial void OnpackunitChanged();
        partial void OnVatCodeChanging(string value);
        partial void OnVatCodeChanged();
        partial void OnIsServiceChanging(bool value);
        partial void OnIsServiceChanged();
        partial void OnCompanyIDChanging(string value);
        partial void OnCompanyIDChanged();
        partial void OnStockAccountChanging(string value);
        partial void OnStockAccountChanged();
        partial void OnExpenseAccountChanging(string value);
        partial void OnExpenseAccountChanged();
        partial void OnCurrencyChanging(string value);
        partial void OnCurrencyChanged();
        partial void OnGroupIdChanging(string value);
        partial void OnGroupIdChanged();
        partial void OnRevenuAccountIdChanging(string value);
        partial void OnRevenuAccountIdChanged();
        #endregion

        public Article()
        {
            this._LineBillOfDeliveries = new EntitySet<LineBillOfDelivery>(new Action<LineBillOfDelivery>(this.attach_LineBillOfDeliveries), new Action<LineBillOfDelivery>(this.detach_LineBillOfDeliveries));
            this._LineGoodReceivings = new EntitySet<LineGoodReceiving>(new Action<LineGoodReceiving>(this.attach_LineGoodReceivings), new Action<LineGoodReceiving>(this.detach_LineGoodReceivings));
            this._LineInventoryInvoices = new EntitySet<LineInventoryInvoice>(new Action<LineInventoryInvoice>(this.attach_LineInventoryInvoices), new Action<LineInventoryInvoice>(this.detach_LineInventoryInvoices));
            this._LinePurchaseOrders = new EntitySet<LinePurchaseOrder>(new Action<LinePurchaseOrder>(this.attach_LinePurchaseOrders), new Action<LinePurchaseOrder>(this.detach_LinePurchaseOrders));
            this._LineSalesInvoices = new EntitySet<LineSalesInvoice>(new Action<LineSalesInvoice>(this.attach_LineSalesInvoices), new Action<LineSalesInvoice>(this.detach_LineSalesInvoices));
            this._LineSalesOrders = new EntitySet<LineSalesOrder>(new Action<LineSalesOrder>(this.attach_LineSalesOrders), new Action<LineSalesOrder>(this.detach_LineSalesOrders));
            this._Stocks = new EntitySet<Stock>(new Action<Stock>(this.attach_Stocks), new Action<Stock>(this.detach_Stocks));
            this._Vat = default(EntityRef<Vat>);
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id", DbType = "NVarChar(50) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    this.OnidChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("id");
                    this.OnidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_name", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
        public string name
        {
            get
            {
                return this._name;
            }
            set
            {
                if ((this._name != value))
                {
                    this.OnnameChanging(value);
                    this.SendPropertyChanging();
                    this._name = value;
                    this.SendPropertyChanged("name");
                    this.OnnameChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_description", DbType = "NVarChar(255)")]
        public string description
        {
            get
            {
                return this._description;
            }
            set
            {
                if ((this._description != value))
                {
                    this.OndescriptionChanging(value);
                    this.SendPropertyChanging();
                    this._description = value;
                    this.SendPropertyChanged("description");
                    this.OndescriptionChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_price", DbType = "Money NOT NULL")]
        public decimal price
        {
            get
            {
                return this._price;
            }
            set
            {
                if ((this._price != value))
                {
                    this.OnpriceChanging(value);
                    this.SendPropertyChanging();
                    this._price = value;
                    this.SendPropertyChanged("price");
                    this.OnpriceChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_avgprice", DbType = "Money NOT NULL")]
        public decimal avgprice
        {
            get
            {
                return this._avgprice;
            }
            set
            {
                if ((this._avgprice != value))
                {
                    this.OnavgpriceChanging(value);
                    this.SendPropertyChanging();
                    this._avgprice = value;
                    this.SendPropertyChanged("avgprice");
                    this.OnavgpriceChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_salesprice", DbType = "Money NOT NULL")]
        public decimal salesprice
        {
            get
            {
                return this._salesprice;
            }
            set
            {
                if ((this._salesprice != value))
                {
                    this.OnsalespriceChanging(value);
                    this.SendPropertyChanging();
                    this._salesprice = value;
                    this.SendPropertyChanged("salesprice");
                    this.OnsalespriceChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_qttyunit", DbType = "NVarChar(255)")]
        public string qttyunit
        {
            get
            {
                return this._qttyunit;
            }
            set
            {
                if ((this._qttyunit != value))
                {
                    this.OnqttyunitChanging(value);
                    this.SendPropertyChanging();
                    this._qttyunit = value;
                    this.SendPropertyChanged("qttyunit");
                    this.OnqttyunitChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_packunit", DbType = "NVarChar(255)")]
        public string packunit
        {
            get
            {
                return this._packunit;
            }
            set
            {
                if ((this._packunit != value))
                {
                    this.OnpackunitChanging(value);
                    this.SendPropertyChanging();
                    this._packunit = value;
                    this.SendPropertyChanged("packunit");
                    this.OnpackunitChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_VatCode", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string VatCode
        {
            get
            {
                return this._VatCode;
            }
            set
            {
                if ((this._VatCode != value))
                {
                    if (this._Vat.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnVatCodeChanging(value);
                    this.SendPropertyChanging();
                    this._VatCode = value;
                    this.SendPropertyChanged("VatCode");
                    this.OnVatCodeChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IsService", DbType = "Bit NOT NULL")]
        public bool IsService
        {
            get
            {
                return this._IsService;
            }
            set
            {
                if ((this._IsService != value))
                {
                    this.OnIsServiceChanging(value);
                    this.SendPropertyChanging();
                    this._IsService = value;
                    this.SendPropertyChanged("IsService");
                    this.OnIsServiceChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CompanyID
        {
            get
            {
                return this._CompanyID;
            }
            set
            {
                if ((this._CompanyID != value))
                {
                    this.OnCompanyIDChanging(value);
                    this.SendPropertyChanging();
                    this._CompanyID = value;
                    this.SendPropertyChanged("CompanyID");
                    this.OnCompanyIDChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_StockAccount", DbType = "NVarChar(50)")]
        public string StockAccount
        {
            get
            {
                return this._StockAccount;
            }
            set
            {
                if ((this._StockAccount != value))
                {
                    this.OnStockAccountChanging(value);
                    this.SendPropertyChanging();
                    this._StockAccount = value;
                    this.SendPropertyChanged("StockAccount");
                    this.OnStockAccountChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ExpenseAccount", DbType = "NVarChar(50)")]
        public string ExpenseAccount
        {
            get
            {
                return this._ExpenseAccount;
            }
            set
            {
                if ((this._ExpenseAccount != value))
                {
                    this.OnExpenseAccountChanging(value);
                    this.SendPropertyChanging();
                    this._ExpenseAccount = value;
                    this.SendPropertyChanged("ExpenseAccount");
                    this.OnExpenseAccountChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Currency", DbType = "NVarChar(10)")]
        public string Currency
        {
            get
            {
                return this._Currency;
            }
            set
            {
                if ((this._Currency != value))
                {
                    this.OnCurrencyChanging(value);
                    this.SendPropertyChanging();
                    this._Currency = value;
                    this.SendPropertyChanged("Currency");
                    this.OnCurrencyChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_GroupId", DbType = "NVarChar(50)")]
        public string GroupId
        {
            get
            {
                return this._GroupId;
            }
            set
            {
                if ((this._GroupId != value))
                {
                    this.OnGroupIdChanging(value);
                    this.SendPropertyChanging();
                    this._GroupId = value;
                    this.SendPropertyChanged("GroupId");
                    this.OnGroupIdChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_RevenuAccountId", DbType = "NVarChar(50)")]
        public string RevenuAccountId
        {
            get
            {
                return this._RevenuAccountId;
            }
            set
            {
                if ((this._RevenuAccountId != value))
                {
                    this.OnRevenuAccountIdChanging(value);
                    this.SendPropertyChanging();
                    this._RevenuAccountId = value;
                    this.SendPropertyChanged("RevenuAccountId");
                    this.OnRevenuAccountIdChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Article_LineBillOfDelivery", Storage = "_LineBillOfDeliveries", ThisKey = "id", OtherKey = "item")]
        public EntitySet<LineBillOfDelivery> LineBillOfDeliveries
        {
            get
            {
                return this._LineBillOfDeliveries;
            }
            set
            {
                this._LineBillOfDeliveries.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Article_LineGoodReceiving", Storage = "_LineGoodReceivings", ThisKey = "id", OtherKey = "item")]
        public EntitySet<LineGoodReceiving> LineGoodReceivings
        {
            get
            {
                return this._LineGoodReceivings;
            }
            set
            {
                this._LineGoodReceivings.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Article_LineInventoryInvoice", Storage = "_LineInventoryInvoices", ThisKey = "id", OtherKey = "item")]
        public EntitySet<LineInventoryInvoice> LineInventoryInvoices
        {
            get
            {
                return this._LineInventoryInvoices;
            }
            set
            {
                this._LineInventoryInvoices.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Article_LinePurchaseOrder", Storage = "_LinePurchaseOrders", ThisKey = "id", OtherKey = "item")]
        public EntitySet<LinePurchaseOrder> LinePurchaseOrders
        {
            get
            {
                return this._LinePurchaseOrders;
            }
            set
            {
                this._LinePurchaseOrders.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Article_LineSalesInvoice", Storage = "_LineSalesInvoices", ThisKey = "id", OtherKey = "item")]
        public EntitySet<LineSalesInvoice> LineSalesInvoices
        {
            get
            {
                return this._LineSalesInvoices;
            }
            set
            {
                this._LineSalesInvoices.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Article_LineSalesOrder", Storage = "_LineSalesOrders", ThisKey = "id", OtherKey = "item")]
        public EntitySet<LineSalesOrder> LineSalesOrders
        {
            get
            {
                return this._LineSalesOrders;
            }
            set
            {
                this._LineSalesOrders.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Article_Stock", Storage = "_Stocks", ThisKey = "id", OtherKey = "itemid")]
        public EntitySet<Stock> Stocks
        {
            get
            {
                return this._Stocks;
            }
            set
            {
                this._Stocks.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Vat_Article", Storage = "_Vat", ThisKey = "VatCode", OtherKey = "id", IsForeignKey = true)]
        public Vat Vat
        {
            get
            {
                return this._Vat.Entity;
            }
            set
            {
                Vat previousValue = this._Vat.Entity;
                if (((previousValue != value)
                            || (this._Vat.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Vat.Entity = null;
                        previousValue.Articles.Remove(this);
                    }
                    this._Vat.Entity = value;
                    if ((value != null))
                    {
                        value.Articles.Add(this);
                        this._VatCode = value.id;
                    }
                    else
                    {
                        this._VatCode = default(string);
                    }
                    this.SendPropertyChanged("Vat");
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void attach_LineBillOfDeliveries(LineBillOfDelivery entity)
        {
            this.SendPropertyChanging();
            entity.Article = this;
        }

        private void detach_LineBillOfDeliveries(LineBillOfDelivery entity)
        {
            this.SendPropertyChanging();
            entity.Article = null;
        }

        private void attach_LineGoodReceivings(LineGoodReceiving entity)
        {
            this.SendPropertyChanging();
            entity.Article = this;
        }

        private void detach_LineGoodReceivings(LineGoodReceiving entity)
        {
            this.SendPropertyChanging();
            entity.Article = null;
        }

        private void attach_LineInventoryInvoices(LineInventoryInvoice entity)
        {
            this.SendPropertyChanging();
            entity.Article = this;
        }

        private void detach_LineInventoryInvoices(LineInventoryInvoice entity)
        {
            this.SendPropertyChanging();
            entity.Article = null;
        }

        private void attach_LinePurchaseOrders(LinePurchaseOrder entity)
        {
            this.SendPropertyChanging();
            entity.Article = this;
        }

        private void detach_LinePurchaseOrders(LinePurchaseOrder entity)
        {
            this.SendPropertyChanging();
            entity.Article = null;
        }

        private void attach_LineSalesInvoices(LineSalesInvoice entity)
        {
            this.SendPropertyChanging();
            entity.Article = this;
        }

        private void detach_LineSalesInvoices(LineSalesInvoice entity)
        {
            this.SendPropertyChanging();
            entity.Article = null;
        }

        private void attach_LineSalesOrders(LineSalesOrder entity)
        {
            this.SendPropertyChanging();
            entity.Article = this;
        }

        private void detach_LineSalesOrders(LineSalesOrder entity)
        {
            this.SendPropertyChanging();
            entity.Article = null;
        }

        private void attach_Stocks(Stock entity)
        {
            this.SendPropertyChanging();
            entity.Article = this;
        }

        private void detach_Stocks(Stock entity)
        {
            this.SendPropertyChanging();
            entity.Article = null;
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.AspNetRoles")]
    public partial class AspNetRole : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _Id;

        private string _Name;

        private EntitySet<AspNetUserRole> _AspNetUserRoles;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIdChanging(string value);
        partial void OnIdChanged();
        partial void OnNameChanging(string value);
        partial void OnNameChanged();
        #endregion

        public AspNetRole()
        {
            this._AspNetUserRoles = new EntitySet<AspNetUserRole>(new Action<AspNetUserRole>(this.attach_AspNetUserRoles), new Action<AspNetUserRole>(this.detach_AspNetUserRoles));
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Id", DbType = "NVarChar(128) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                if ((this._Id != value))
                {
                    this.OnIdChanging(value);
                    this.SendPropertyChanging();
                    this._Id = value;
                    this.SendPropertyChanged("Id");
                    this.OnIdChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Name", DbType = "NVarChar(256) NOT NULL", CanBeNull = false)]
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                if ((this._Name != value))
                {
                    this.OnNameChanging(value);
                    this.SendPropertyChanging();
                    this._Name = value;
                    this.SendPropertyChanged("Name");
                    this.OnNameChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "AspNetRole_AspNetUserRole", Storage = "_AspNetUserRoles", ThisKey = "Id", OtherKey = "RoleId")]
        public EntitySet<AspNetUserRole> AspNetUserRoles
        {
            get
            {
                return this._AspNetUserRoles;
            }
            set
            {
                this._AspNetUserRoles.Assign(value);
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void attach_AspNetUserRoles(AspNetUserRole entity)
        {
            this.SendPropertyChanging();
            entity.AspNetRole = this;
        }

        private void detach_AspNetUserRoles(AspNetUserRole entity)
        {
            this.SendPropertyChanging();
            entity.AspNetRole = null;
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.AspNetUserClaims")]
    public partial class AspNetUserClaim : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _Id;

        private string _UserId;

        private string _ClaimType;

        private string _ClaimValue;

        private EntityRef<AspNetUser> _AspNetUser;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIdChanging(int value);
        partial void OnIdChanged();
        partial void OnUserIdChanging(string value);
        partial void OnUserIdChanged();
        partial void OnClaimTypeChanging(string value);
        partial void OnClaimTypeChanged();
        partial void OnClaimValueChanging(string value);
        partial void OnClaimValueChanged();
        #endregion

        public AspNetUserClaim()
        {
            this._AspNetUser = default(EntityRef<AspNetUser>);
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Id", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                if ((this._Id != value))
                {
                    this.OnIdChanging(value);
                    this.SendPropertyChanging();
                    this._Id = value;
                    this.SendPropertyChanged("Id");
                    this.OnIdChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_UserId", DbType = "NVarChar(128) NOT NULL", CanBeNull = false)]
        public string UserId
        {
            get
            {
                return this._UserId;
            }
            set
            {
                if ((this._UserId != value))
                {
                    if (this._AspNetUser.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnUserIdChanging(value);
                    this.SendPropertyChanging();
                    this._UserId = value;
                    this.SendPropertyChanged("UserId");
                    this.OnUserIdChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ClaimType", DbType = "NVarChar(MAX)")]
        public string ClaimType
        {
            get
            {
                return this._ClaimType;
            }
            set
            {
                if ((this._ClaimType != value))
                {
                    this.OnClaimTypeChanging(value);
                    this.SendPropertyChanging();
                    this._ClaimType = value;
                    this.SendPropertyChanged("ClaimType");
                    this.OnClaimTypeChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ClaimValue", DbType = "NVarChar(MAX)")]
        public string ClaimValue
        {
            get
            {
                return this._ClaimValue;
            }
            set
            {
                if ((this._ClaimValue != value))
                {
                    this.OnClaimValueChanging(value);
                    this.SendPropertyChanging();
                    this._ClaimValue = value;
                    this.SendPropertyChanged("ClaimValue");
                    this.OnClaimValueChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "AspNetUser_AspNetUserClaim", Storage = "_AspNetUser", ThisKey = "UserId", OtherKey = "Id", IsForeignKey = true, DeleteOnNull = true, DeleteRule = "CASCADE")]
        public AspNetUser AspNetUser
        {
            get
            {
                return this._AspNetUser.Entity;
            }
            set
            {
                AspNetUser previousValue = this._AspNetUser.Entity;
                if (((previousValue != value)
                            || (this._AspNetUser.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._AspNetUser.Entity = null;
                        previousValue.AspNetUserClaims.Remove(this);
                    }
                    this._AspNetUser.Entity = value;
                    if ((value != null))
                    {
                        value.AspNetUserClaims.Add(this);
                        this._UserId = value.Id;
                    }
                    else
                    {
                        this._UserId = default(string);
                    }
                    this.SendPropertyChanged("AspNetUser");
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.AspNetUserLogins")]
    public partial class AspNetUserLogin : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _LoginProvider;

        private string _ProviderKey;

        private string _UserId;

        private EntityRef<AspNetUser> _AspNetUser;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnLoginProviderChanging(string value);
        partial void OnLoginProviderChanged();
        partial void OnProviderKeyChanging(string value);
        partial void OnProviderKeyChanged();
        partial void OnUserIdChanging(string value);
        partial void OnUserIdChanged();
        #endregion

        public AspNetUserLogin()
        {
            this._AspNetUser = default(EntityRef<AspNetUser>);
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_LoginProvider", DbType = "NVarChar(128) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string LoginProvider
        {
            get
            {
                return this._LoginProvider;
            }
            set
            {
                if ((this._LoginProvider != value))
                {
                    this.OnLoginProviderChanging(value);
                    this.SendPropertyChanging();
                    this._LoginProvider = value;
                    this.SendPropertyChanged("LoginProvider");
                    this.OnLoginProviderChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ProviderKey", DbType = "NVarChar(128) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string ProviderKey
        {
            get
            {
                return this._ProviderKey;
            }
            set
            {
                if ((this._ProviderKey != value))
                {
                    this.OnProviderKeyChanging(value);
                    this.SendPropertyChanging();
                    this._ProviderKey = value;
                    this.SendPropertyChanged("ProviderKey");
                    this.OnProviderKeyChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_UserId", DbType = "NVarChar(128) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string UserId
        {
            get
            {
                return this._UserId;
            }
            set
            {
                if ((this._UserId != value))
                {
                    if (this._AspNetUser.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnUserIdChanging(value);
                    this.SendPropertyChanging();
                    this._UserId = value;
                    this.SendPropertyChanged("UserId");
                    this.OnUserIdChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "AspNetUser_AspNetUserLogin", Storage = "_AspNetUser", ThisKey = "UserId", OtherKey = "Id", IsForeignKey = true, DeleteOnNull = true, DeleteRule = "CASCADE")]
        public AspNetUser AspNetUser
        {
            get
            {
                return this._AspNetUser.Entity;
            }
            set
            {
                AspNetUser previousValue = this._AspNetUser.Entity;
                if (((previousValue != value)
                            || (this._AspNetUser.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._AspNetUser.Entity = null;
                        previousValue.AspNetUserLogins.Remove(this);
                    }
                    this._AspNetUser.Entity = value;
                    if ((value != null))
                    {
                        value.AspNetUserLogins.Add(this);
                        this._UserId = value.Id;
                    }
                    else
                    {
                        this._UserId = default(string);
                    }
                    this.SendPropertyChanged("AspNetUser");
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.AspNetUserRoles")]
    public partial class AspNetUserRole : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _UserId;

        private string _RoleId;

        private EntityRef<AspNetRole> _AspNetRole;

        private EntityRef<AspNetUser> _AspNetUser;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnUserIdChanging(string value);
        partial void OnUserIdChanged();
        partial void OnRoleIdChanging(string value);
        partial void OnRoleIdChanged();
        #endregion

        public AspNetUserRole()
        {
            this._AspNetRole = default(EntityRef<AspNetRole>);
            this._AspNetUser = default(EntityRef<AspNetUser>);
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_UserId", DbType = "NVarChar(128) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string UserId
        {
            get
            {
                return this._UserId;
            }
            set
            {
                if ((this._UserId != value))
                {
                    if (this._AspNetUser.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnUserIdChanging(value);
                    this.SendPropertyChanging();
                    this._UserId = value;
                    this.SendPropertyChanged("UserId");
                    this.OnUserIdChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_RoleId", DbType = "NVarChar(128) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string RoleId
        {
            get
            {
                return this._RoleId;
            }
            set
            {
                if ((this._RoleId != value))
                {
                    if (this._AspNetRole.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnRoleIdChanging(value);
                    this.SendPropertyChanging();
                    this._RoleId = value;
                    this.SendPropertyChanged("RoleId");
                    this.OnRoleIdChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "AspNetRole_AspNetUserRole", Storage = "_AspNetRole", ThisKey = "RoleId", OtherKey = "Id", IsForeignKey = true, DeleteOnNull = true, DeleteRule = "CASCADE")]
        public AspNetRole AspNetRole
        {
            get
            {
                return this._AspNetRole.Entity;
            }
            set
            {
                AspNetRole previousValue = this._AspNetRole.Entity;
                if (((previousValue != value)
                            || (this._AspNetRole.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._AspNetRole.Entity = null;
                        previousValue.AspNetUserRoles.Remove(this);
                    }
                    this._AspNetRole.Entity = value;
                    if ((value != null))
                    {
                        value.AspNetUserRoles.Add(this);
                        this._RoleId = value.Id;
                    }
                    else
                    {
                        this._RoleId = default(string);
                    }
                    this.SendPropertyChanged("AspNetRole");
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "AspNetUser_AspNetUserRole", Storage = "_AspNetUser", ThisKey = "UserId", OtherKey = "Id", IsForeignKey = true, DeleteOnNull = true, DeleteRule = "CASCADE")]
        public AspNetUser AspNetUser
        {
            get
            {
                return this._AspNetUser.Entity;
            }
            set
            {
                AspNetUser previousValue = this._AspNetUser.Entity;
                if (((previousValue != value)
                            || (this._AspNetUser.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._AspNetUser.Entity = null;
                        previousValue.AspNetUserRoles.Remove(this);
                    }
                    this._AspNetUser.Entity = value;
                    if ((value != null))
                    {
                        value.AspNetUserRoles.Add(this);
                        this._UserId = value.Id;
                    }
                    else
                    {
                        this._UserId = default(string);
                    }
                    this.SendPropertyChanged("AspNetUser");
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.AspNetUsers")]
    public partial class AspNetUser : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _Id;

        private System.Nullable<System.DateTime> _BirthDate;

        private string _FirstName;

        private string _LastName;

        private string _Company;

        private int _Gender;

        private string _Email;

        private bool _EmailConfirmed;

        private string _PasswordHash;

        private string _SecurityStamp;

        private string _PhoneNumber;

        private bool _PhoneNumberConfirmed;

        private bool _TwoFactorEnabled;

        private System.Nullable<System.DateTime> _LockoutEndDateUtc;

        private bool _LockoutEnabled;

        private int _AccessFailedCount;

        private string _UserName;

        private EntitySet<AspNetUserClaim> _AspNetUserClaims;

        private EntitySet<AspNetUserLogin> _AspNetUserLogins;

        private EntitySet<AspNetUserRole> _AspNetUserRoles;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIdChanging(string value);
        partial void OnIdChanged();
        partial void OnBirthDateChanging(System.Nullable<System.DateTime> value);
        partial void OnBirthDateChanged();
        partial void OnFirstNameChanging(string value);
        partial void OnFirstNameChanged();
        partial void OnLastNameChanging(string value);
        partial void OnLastNameChanged();
        partial void OnCompanyChanging(string value);
        partial void OnCompanyChanged();
        partial void OnGenderChanging(int value);
        partial void OnGenderChanged();
        partial void OnEmailChanging(string value);
        partial void OnEmailChanged();
        partial void OnEmailConfirmedChanging(bool value);
        partial void OnEmailConfirmedChanged();
        partial void OnPasswordHashChanging(string value);
        partial void OnPasswordHashChanged();
        partial void OnSecurityStampChanging(string value);
        partial void OnSecurityStampChanged();
        partial void OnPhoneNumberChanging(string value);
        partial void OnPhoneNumberChanged();
        partial void OnPhoneNumberConfirmedChanging(bool value);
        partial void OnPhoneNumberConfirmedChanged();
        partial void OnTwoFactorEnabledChanging(bool value);
        partial void OnTwoFactorEnabledChanged();
        partial void OnLockoutEndDateUtcChanging(System.Nullable<System.DateTime> value);
        partial void OnLockoutEndDateUtcChanged();
        partial void OnLockoutEnabledChanging(bool value);
        partial void OnLockoutEnabledChanged();
        partial void OnAccessFailedCountChanging(int value);
        partial void OnAccessFailedCountChanged();
        partial void OnUserNameChanging(string value);
        partial void OnUserNameChanged();
        #endregion

        public AspNetUser()
        {
            this._AspNetUserClaims = new EntitySet<AspNetUserClaim>(new Action<AspNetUserClaim>(this.attach_AspNetUserClaims), new Action<AspNetUserClaim>(this.detach_AspNetUserClaims));
            this._AspNetUserLogins = new EntitySet<AspNetUserLogin>(new Action<AspNetUserLogin>(this.attach_AspNetUserLogins), new Action<AspNetUserLogin>(this.detach_AspNetUserLogins));
            this._AspNetUserRoles = new EntitySet<AspNetUserRole>(new Action<AspNetUserRole>(this.attach_AspNetUserRoles), new Action<AspNetUserRole>(this.detach_AspNetUserRoles));
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Id", DbType = "NVarChar(128) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                if ((this._Id != value))
                {
                    this.OnIdChanging(value);
                    this.SendPropertyChanging();
                    this._Id = value;
                    this.SendPropertyChanged("Id");
                    this.OnIdChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_BirthDate", DbType = "DateTime")]
        public System.Nullable<System.DateTime> BirthDate
        {
            get
            {
                return this._BirthDate;
            }
            set
            {
                if ((this._BirthDate != value))
                {
                    this.OnBirthDateChanging(value);
                    this.SendPropertyChanging();
                    this._BirthDate = value;
                    this.SendPropertyChanged("BirthDate");
                    this.OnBirthDateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_FirstName", DbType = "NVarChar(MAX)")]
        public string FirstName
        {
            get
            {
                return this._FirstName;
            }
            set
            {
                if ((this._FirstName != value))
                {
                    this.OnFirstNameChanging(value);
                    this.SendPropertyChanging();
                    this._FirstName = value;
                    this.SendPropertyChanged("FirstName");
                    this.OnFirstNameChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_LastName", DbType = "NVarChar(MAX)")]
        public string LastName
        {
            get
            {
                return this._LastName;
            }
            set
            {
                if ((this._LastName != value))
                {
                    this.OnLastNameChanging(value);
                    this.SendPropertyChanging();
                    this._LastName = value;
                    this.SendPropertyChanged("LastName");
                    this.OnLastNameChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Company", DbType = "NVarChar(MAX)")]
        public string Company
        {
            get
            {
                return this._Company;
            }
            set
            {
                if ((this._Company != value))
                {
                    this.OnCompanyChanging(value);
                    this.SendPropertyChanging();
                    this._Company = value;
                    this.SendPropertyChanged("Company");
                    this.OnCompanyChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Gender", DbType = "Int NOT NULL")]
        public int Gender
        {
            get
            {
                return this._Gender;
            }
            set
            {
                if ((this._Gender != value))
                {
                    this.OnGenderChanging(value);
                    this.SendPropertyChanging();
                    this._Gender = value;
                    this.SendPropertyChanged("Gender");
                    this.OnGenderChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Email", DbType = "NVarChar(256)")]
        public string Email
        {
            get
            {
                return this._Email;
            }
            set
            {
                if ((this._Email != value))
                {
                    this.OnEmailChanging(value);
                    this.SendPropertyChanging();
                    this._Email = value;
                    this.SendPropertyChanged("Email");
                    this.OnEmailChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_EmailConfirmed", DbType = "Bit NOT NULL")]
        public bool EmailConfirmed
        {
            get
            {
                return this._EmailConfirmed;
            }
            set
            {
                if ((this._EmailConfirmed != value))
                {
                    this.OnEmailConfirmedChanging(value);
                    this.SendPropertyChanging();
                    this._EmailConfirmed = value;
                    this.SendPropertyChanged("EmailConfirmed");
                    this.OnEmailConfirmedChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_PasswordHash", DbType = "NVarChar(MAX)")]
        public string PasswordHash
        {
            get
            {
                return this._PasswordHash;
            }
            set
            {
                if ((this._PasswordHash != value))
                {
                    this.OnPasswordHashChanging(value);
                    this.SendPropertyChanging();
                    this._PasswordHash = value;
                    this.SendPropertyChanged("PasswordHash");
                    this.OnPasswordHashChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_SecurityStamp", DbType = "NVarChar(MAX)")]
        public string SecurityStamp
        {
            get
            {
                return this._SecurityStamp;
            }
            set
            {
                if ((this._SecurityStamp != value))
                {
                    this.OnSecurityStampChanging(value);
                    this.SendPropertyChanging();
                    this._SecurityStamp = value;
                    this.SendPropertyChanged("SecurityStamp");
                    this.OnSecurityStampChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_PhoneNumber", DbType = "NVarChar(MAX)")]
        public string PhoneNumber
        {
            get
            {
                return this._PhoneNumber;
            }
            set
            {
                if ((this._PhoneNumber != value))
                {
                    this.OnPhoneNumberChanging(value);
                    this.SendPropertyChanging();
                    this._PhoneNumber = value;
                    this.SendPropertyChanged("PhoneNumber");
                    this.OnPhoneNumberChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_PhoneNumberConfirmed", DbType = "Bit NOT NULL")]
        public bool PhoneNumberConfirmed
        {
            get
            {
                return this._PhoneNumberConfirmed;
            }
            set
            {
                if ((this._PhoneNumberConfirmed != value))
                {
                    this.OnPhoneNumberConfirmedChanging(value);
                    this.SendPropertyChanging();
                    this._PhoneNumberConfirmed = value;
                    this.SendPropertyChanged("PhoneNumberConfirmed");
                    this.OnPhoneNumberConfirmedChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TwoFactorEnabled", DbType = "Bit NOT NULL")]
        public bool TwoFactorEnabled
        {
            get
            {
                return this._TwoFactorEnabled;
            }
            set
            {
                if ((this._TwoFactorEnabled != value))
                {
                    this.OnTwoFactorEnabledChanging(value);
                    this.SendPropertyChanging();
                    this._TwoFactorEnabled = value;
                    this.SendPropertyChanged("TwoFactorEnabled");
                    this.OnTwoFactorEnabledChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_LockoutEndDateUtc", DbType = "DateTime")]
        public System.Nullable<System.DateTime> LockoutEndDateUtc
        {
            get
            {
                return this._LockoutEndDateUtc;
            }
            set
            {
                if ((this._LockoutEndDateUtc != value))
                {
                    this.OnLockoutEndDateUtcChanging(value);
                    this.SendPropertyChanging();
                    this._LockoutEndDateUtc = value;
                    this.SendPropertyChanged("LockoutEndDateUtc");
                    this.OnLockoutEndDateUtcChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_LockoutEnabled", DbType = "Bit NOT NULL")]
        public bool LockoutEnabled
        {
            get
            {
                return this._LockoutEnabled;
            }
            set
            {
                if ((this._LockoutEnabled != value))
                {
                    this.OnLockoutEnabledChanging(value);
                    this.SendPropertyChanging();
                    this._LockoutEnabled = value;
                    this.SendPropertyChanged("LockoutEnabled");
                    this.OnLockoutEnabledChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_AccessFailedCount", DbType = "Int NOT NULL")]
        public int AccessFailedCount
        {
            get
            {
                return this._AccessFailedCount;
            }
            set
            {
                if ((this._AccessFailedCount != value))
                {
                    this.OnAccessFailedCountChanging(value);
                    this.SendPropertyChanging();
                    this._AccessFailedCount = value;
                    this.SendPropertyChanged("AccessFailedCount");
                    this.OnAccessFailedCountChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_UserName", DbType = "NVarChar(256) NOT NULL", CanBeNull = false)]
        public string UserName
        {
            get
            {
                return this._UserName;
            }
            set
            {
                if ((this._UserName != value))
                {
                    this.OnUserNameChanging(value);
                    this.SendPropertyChanging();
                    this._UserName = value;
                    this.SendPropertyChanged("UserName");
                    this.OnUserNameChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "AspNetUser_AspNetUserClaim", Storage = "_AspNetUserClaims", ThisKey = "Id", OtherKey = "UserId")]
        public EntitySet<AspNetUserClaim> AspNetUserClaims
        {
            get
            {
                return this._AspNetUserClaims;
            }
            set
            {
                this._AspNetUserClaims.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "AspNetUser_AspNetUserLogin", Storage = "_AspNetUserLogins", ThisKey = "Id", OtherKey = "UserId")]
        public EntitySet<AspNetUserLogin> AspNetUserLogins
        {
            get
            {
                return this._AspNetUserLogins;
            }
            set
            {
                this._AspNetUserLogins.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "AspNetUser_AspNetUserRole", Storage = "_AspNetUserRoles", ThisKey = "Id", OtherKey = "UserId")]
        public EntitySet<AspNetUserRole> AspNetUserRoles
        {
            get
            {
                return this._AspNetUserRoles;
            }
            set
            {
                this._AspNetUserRoles.Assign(value);
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void attach_AspNetUserClaims(AspNetUserClaim entity)
        {
            this.SendPropertyChanging();
            entity.AspNetUser = this;
        }

        private void detach_AspNetUserClaims(AspNetUserClaim entity)
        {
            this.SendPropertyChanging();
            entity.AspNetUser = null;
        }

        private void attach_AspNetUserLogins(AspNetUserLogin entity)
        {
            this.SendPropertyChanging();
            entity.AspNetUser = this;
        }

        private void detach_AspNetUserLogins(AspNetUserLogin entity)
        {
            this.SendPropertyChanging();
            entity.AspNetUser = null;
        }

        private void attach_AspNetUserRoles(AspNetUserRole entity)
        {
            this.SendPropertyChanging();
            entity.AspNetUser = this;
        }

        private void detach_AspNetUserRoles(AspNetUserRole entity)
        {
            this.SendPropertyChanging();
            entity.AspNetUser = null;
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.Bank")]
    public partial class Bank : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _id;

        private string _name;

        private string _description;

        private string _CompanyID;

        private EntitySet<BankAccount> _BankAccounts;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnidChanging(string value);
        partial void OnidChanged();
        partial void OnnameChanging(string value);
        partial void OnnameChanged();
        partial void OndescriptionChanging(string value);
        partial void OndescriptionChanged();
        partial void OnCompanyIDChanging(string value);
        partial void OnCompanyIDChanged();
        #endregion

        public Bank()
        {
            this._BankAccounts = new EntitySet<BankAccount>(new Action<BankAccount>(this.attach_BankAccounts), new Action<BankAccount>(this.detach_BankAccounts));
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id", DbType = "NVarChar(50) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    this.OnidChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("id");
                    this.OnidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_name", DbType = "NVarChar(250)")]
        public string name
        {
            get
            {
                return this._name;
            }
            set
            {
                if ((this._name != value))
                {
                    this.OnnameChanging(value);
                    this.SendPropertyChanging();
                    this._name = value;
                    this.SendPropertyChanged("name");
                    this.OnnameChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_description", DbType = "NVarChar(255)")]
        public string description
        {
            get
            {
                return this._description;
            }
            set
            {
                if ((this._description != value))
                {
                    this.OndescriptionChanging(value);
                    this.SendPropertyChanging();
                    this._description = value;
                    this.SendPropertyChanged("description");
                    this.OndescriptionChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CompanyID
        {
            get
            {
                return this._CompanyID;
            }
            set
            {
                if ((this._CompanyID != value))
                {
                    this.OnCompanyIDChanging(value);
                    this.SendPropertyChanging();
                    this._CompanyID = value;
                    this.SendPropertyChanged("CompanyID");
                    this.OnCompanyIDChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Bank_BankAccount", Storage = "_BankAccounts", ThisKey = "id", OtherKey = "BIC")]
        public EntitySet<BankAccount> BankAccounts
        {
            get
            {
                return this._BankAccounts;
            }
            set
            {
                this._BankAccounts.Assign(value);
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void attach_BankAccounts(BankAccount entity)
        {
            this.SendPropertyChanging();
            entity.Bank = this;
        }

        private void detach_BankAccounts(BankAccount entity)
        {
            this.SendPropertyChanging();
            entity.Bank = null;
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.BankAccount")]
    public partial class BankAccount : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _IBAN;

        private string _Owner;

        private string _BIC;

        private string _Account;

        private decimal _Debit;

        private decimal _Credit;

        private string _Currency;

        private string _CompanyID;

        private EntityRef<Bank> _Bank;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIBANChanging(string value);
        partial void OnIBANChanged();
        partial void OnOwnerChanging(string value);
        partial void OnOwnerChanged();
        partial void OnBICChanging(string value);
        partial void OnBICChanged();
        partial void OnAccountChanging(string value);
        partial void OnAccountChanged();
        partial void OnDebitChanging(decimal value);
        partial void OnDebitChanged();
        partial void OnCreditChanging(decimal value);
        partial void OnCreditChanged();
        partial void OnCurrencyChanging(string value);
        partial void OnCurrencyChanged();
        partial void OnCompanyIDChanging(string value);
        partial void OnCompanyIDChanged();
        #endregion

        public BankAccount()
        {
            this._Bank = default(EntityRef<Bank>);
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IBAN", DbType = "NVarChar(50) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string IBAN
        {
            get
            {
                return this._IBAN;
            }
            set
            {
                if ((this._IBAN != value))
                {
                    this.OnIBANChanging(value);
                    this.SendPropertyChanging();
                    this._IBAN = value;
                    this.SendPropertyChanged("IBAN");
                    this.OnIBANChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Owner", DbType = "NVarChar(255) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string Owner
        {
            get
            {
                return this._Owner;
            }
            set
            {
                if ((this._Owner != value))
                {
                    this.OnOwnerChanging(value);
                    this.SendPropertyChanging();
                    this._Owner = value;
                    this.SendPropertyChanged("Owner");
                    this.OnOwnerChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_BIC", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string BIC
        {
            get
            {
                return this._BIC;
            }
            set
            {
                if ((this._BIC != value))
                {
                    if (this._Bank.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnBICChanging(value);
                    this.SendPropertyChanging();
                    this._BIC = value;
                    this.SendPropertyChanged("BIC");
                    this.OnBICChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Account", DbType = "NVarChar(50)")]
        public string Account
        {
            get
            {
                return this._Account;
            }
            set
            {
                if ((this._Account != value))
                {
                    this.OnAccountChanging(value);
                    this.SendPropertyChanging();
                    this._Account = value;
                    this.SendPropertyChanged("Account");
                    this.OnAccountChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Debit", DbType = "Money NOT NULL")]
        public decimal Debit
        {
            get
            {
                return this._Debit;
            }
            set
            {
                if ((this._Debit != value))
                {
                    this.OnDebitChanging(value);
                    this.SendPropertyChanging();
                    this._Debit = value;
                    this.SendPropertyChanged("Debit");
                    this.OnDebitChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Credit", DbType = "Money NOT NULL")]
        public decimal Credit
        {
            get
            {
                return this._Credit;
            }
            set
            {
                if ((this._Credit != value))
                {
                    this.OnCreditChanging(value);
                    this.SendPropertyChanging();
                    this._Credit = value;
                    this.SendPropertyChanged("Credit");
                    this.OnCreditChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Currency", DbType = "NVarChar(10)")]
        public string Currency
        {
            get
            {
                return this._Currency;
            }
            set
            {
                if ((this._Currency != value))
                {
                    this.OnCurrencyChanging(value);
                    this.SendPropertyChanging();
                    this._Currency = value;
                    this.SendPropertyChanged("Currency");
                    this.OnCurrencyChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CompanyID
        {
            get
            {
                return this._CompanyID;
            }
            set
            {
                if ((this._CompanyID != value))
                {
                    this.OnCompanyIDChanging(value);
                    this.SendPropertyChanging();
                    this._CompanyID = value;
                    this.SendPropertyChanged("CompanyID");
                    this.OnCompanyIDChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Bank_BankAccount", Storage = "_Bank", ThisKey = "BIC", OtherKey = "id", IsForeignKey = true)]
        public Bank Bank
        {
            get
            {
                return this._Bank.Entity;
            }
            set
            {
                Bank previousValue = this._Bank.Entity;
                if (((previousValue != value)
                            || (this._Bank.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Bank.Entity = null;
                        previousValue.BankAccounts.Remove(this);
                    }
                    this._Bank.Entity = value;
                    if ((value != null))
                    {
                        value.BankAccounts.Add(this);
                        this._BIC = value.id;
                    }
                    else
                    {
                        this._BIC = default(string);
                    }
                    this.SendPropertyChanged("Bank");
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.BankStatement")]
    public partial class BankStatement : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _id;

        private string _Auftragskonto;

        private System.Nullable<System.DateTime> _Buchungstag;

        private System.Nullable<System.DateTime> _Valutadatum;

        private string _Buchungstext;

        private string _Verwendungszweck;

        private string _BeguenstigterZahlungspflichtiger;

        private string _Kontonummer;

        private string _BLZ;

        private System.Nullable<decimal> _Betrag;

        private string _Waehrung;

        private string _Info;

        private string _CompanyID;

        private string _CompanyIBAN;

        private System.Nullable<bool> _IsValidated;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnidChanging(int value);
        partial void OnidChanged();
        partial void OnAuftragskontoChanging(string value);
        partial void OnAuftragskontoChanged();
        partial void OnBuchungstagChanging(System.Nullable<System.DateTime> value);
        partial void OnBuchungstagChanged();
        partial void OnValutadatumChanging(System.Nullable<System.DateTime> value);
        partial void OnValutadatumChanged();
        partial void OnBuchungstextChanging(string value);
        partial void OnBuchungstextChanged();
        partial void OnVerwendungszweckChanging(string value);
        partial void OnVerwendungszweckChanged();
        partial void OnBeguenstigterZahlungspflichtigerChanging(string value);
        partial void OnBeguenstigterZahlungspflichtigerChanged();
        partial void OnKontonummerChanging(string value);
        partial void OnKontonummerChanged();
        partial void OnBLZChanging(string value);
        partial void OnBLZChanged();
        partial void OnBetragChanging(System.Nullable<decimal> value);
        partial void OnBetragChanged();
        partial void OnWaehrungChanging(string value);
        partial void OnWaehrungChanged();
        partial void OnInfoChanging(string value);
        partial void OnInfoChanged();
        partial void OnCompanyIDChanging(string value);
        partial void OnCompanyIDChanged();
        partial void OnCompanyIBANChanging(string value);
        partial void OnCompanyIBANChanged();
        partial void OnIsValidatedChanging(System.Nullable<bool> value);
        partial void OnIsValidatedChanged();
        #endregion

        public BankStatement()
        {
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    this.OnidChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("id");
                    this.OnidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Auftragskonto", DbType = "NVarChar(50)")]
        public string Auftragskonto
        {
            get
            {
                return this._Auftragskonto;
            }
            set
            {
                if ((this._Auftragskonto != value))
                {
                    this.OnAuftragskontoChanging(value);
                    this.SendPropertyChanging();
                    this._Auftragskonto = value;
                    this.SendPropertyChanged("Auftragskonto");
                    this.OnAuftragskontoChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Buchungstag", DbType = "Date")]
        public System.Nullable<System.DateTime> Buchungstag
        {
            get
            {
                return this._Buchungstag;
            }
            set
            {
                if ((this._Buchungstag != value))
                {
                    this.OnBuchungstagChanging(value);
                    this.SendPropertyChanging();
                    this._Buchungstag = value;
                    this.SendPropertyChanged("Buchungstag");
                    this.OnBuchungstagChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Valutadatum", DbType = "Date")]
        public System.Nullable<System.DateTime> Valutadatum
        {
            get
            {
                return this._Valutadatum;
            }
            set
            {
                if ((this._Valutadatum != value))
                {
                    this.OnValutadatumChanging(value);
                    this.SendPropertyChanging();
                    this._Valutadatum = value;
                    this.SendPropertyChanged("Valutadatum");
                    this.OnValutadatumChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Buchungstext", DbType = "NVarChar(200)")]
        public string Buchungstext
        {
            get
            {
                return this._Buchungstext;
            }
            set
            {
                if ((this._Buchungstext != value))
                {
                    this.OnBuchungstextChanging(value);
                    this.SendPropertyChanging();
                    this._Buchungstext = value;
                    this.SendPropertyChanged("Buchungstext");
                    this.OnBuchungstextChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Verwendungszweck", DbType = "NVarChar(250)")]
        public string Verwendungszweck
        {
            get
            {
                return this._Verwendungszweck;
            }
            set
            {
                if ((this._Verwendungszweck != value))
                {
                    this.OnVerwendungszweckChanging(value);
                    this.SendPropertyChanging();
                    this._Verwendungszweck = value;
                    this.SendPropertyChanged("Verwendungszweck");
                    this.OnVerwendungszweckChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_BeguenstigterZahlungspflichtiger", DbType = "NVarChar(250)")]
        public string BeguenstigterZahlungspflichtiger
        {
            get
            {
                return this._BeguenstigterZahlungspflichtiger;
            }
            set
            {
                if ((this._BeguenstigterZahlungspflichtiger != value))
                {
                    this.OnBeguenstigterZahlungspflichtigerChanging(value);
                    this.SendPropertyChanging();
                    this._BeguenstigterZahlungspflichtiger = value;
                    this.SendPropertyChanged("BeguenstigterZahlungspflichtiger");
                    this.OnBeguenstigterZahlungspflichtigerChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Kontonummer", DbType = "NVarChar(50)")]
        public string Kontonummer
        {
            get
            {
                return this._Kontonummer;
            }
            set
            {
                if ((this._Kontonummer != value))
                {
                    this.OnKontonummerChanging(value);
                    this.SendPropertyChanging();
                    this._Kontonummer = value;
                    this.SendPropertyChanged("Kontonummer");
                    this.OnKontonummerChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_BLZ", DbType = "NVarChar(50)")]
        public string BLZ
        {
            get
            {
                return this._BLZ;
            }
            set
            {
                if ((this._BLZ != value))
                {
                    this.OnBLZChanging(value);
                    this.SendPropertyChanging();
                    this._BLZ = value;
                    this.SendPropertyChanged("BLZ");
                    this.OnBLZChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Betrag", DbType = "Money")]
        public System.Nullable<decimal> Betrag
        {
            get
            {
                return this._Betrag;
            }
            set
            {
                if ((this._Betrag != value))
                {
                    this.OnBetragChanging(value);
                    this.SendPropertyChanging();
                    this._Betrag = value;
                    this.SendPropertyChanged("Betrag");
                    this.OnBetragChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Waehrung", DbType = "NVarChar(200)")]
        public string Waehrung
        {
            get
            {
                return this._Waehrung;
            }
            set
            {
                if ((this._Waehrung != value))
                {
                    this.OnWaehrungChanging(value);
                    this.SendPropertyChanging();
                    this._Waehrung = value;
                    this.SendPropertyChanged("Waehrung");
                    this.OnWaehrungChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Info", DbType = "NVarChar(250)")]
        public string Info
        {
            get
            {
                return this._Info;
            }
            set
            {
                if ((this._Info != value))
                {
                    this.OnInfoChanging(value);
                    this.SendPropertyChanging();
                    this._Info = value;
                    this.SendPropertyChanged("Info");
                    this.OnInfoChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyID", DbType = "NVarChar(50)")]
        public string CompanyID
        {
            get
            {
                return this._CompanyID;
            }
            set
            {
                if ((this._CompanyID != value))
                {
                    this.OnCompanyIDChanging(value);
                    this.SendPropertyChanging();
                    this._CompanyID = value;
                    this.SendPropertyChanged("CompanyID");
                    this.OnCompanyIDChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyIBAN", DbType = "NVarChar(50)")]
        public string CompanyIBAN
        {
            get
            {
                return this._CompanyIBAN;
            }
            set
            {
                if ((this._CompanyIBAN != value))
                {
                    this.OnCompanyIBANChanging(value);
                    this.SendPropertyChanging();
                    this._CompanyIBAN = value;
                    this.SendPropertyChanged("CompanyIBAN");
                    this.OnCompanyIBANChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IsValidated", DbType = "Bit")]
        public System.Nullable<bool> IsValidated
        {
            get
            {
                return this._IsValidated;
            }
            set
            {
                if ((this._IsValidated != value))
                {
                    this.OnIsValidatedChanging(value);
                    this.SendPropertyChanging();
                    this._IsValidated = value;
                    this.SendPropertyChanged("IsValidated");
                    this.OnIsValidatedChanged();
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.bckBankStatement")]
    public partial class bckBankStatement
    {

        private string _Auftragskonto;

        private System.Nullable<System.DateTime> _Buchungstag;

        private System.Nullable<System.DateTime> _Valutadatum;

        private string _Buchungstext;

        private string _Verwendungszweck;

        private string _BeguenstigterZahlungspflichtiger;

        private string _Kontonummer;

        private string _BLZ;

        private System.Nullable<decimal> _Betrag;

        private string _Waehrung;

        private string _Info;

        private string _CompanyID;

        private System.Nullable<bool> _IsValidated;

        public bckBankStatement()
        {
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Auftragskonto", DbType = "NVarChar(50)")]
        public string Auftragskonto
        {
            get
            {
                return this._Auftragskonto;
            }
            set
            {
                if ((this._Auftragskonto != value))
                {
                    this._Auftragskonto = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Buchungstag", DbType = "Date")]
        public System.Nullable<System.DateTime> Buchungstag
        {
            get
            {
                return this._Buchungstag;
            }
            set
            {
                if ((this._Buchungstag != value))
                {
                    this._Buchungstag = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Valutadatum", DbType = "Date")]
        public System.Nullable<System.DateTime> Valutadatum
        {
            get
            {
                return this._Valutadatum;
            }
            set
            {
                if ((this._Valutadatum != value))
                {
                    this._Valutadatum = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Buchungstext", DbType = "NVarChar(200)")]
        public string Buchungstext
        {
            get
            {
                return this._Buchungstext;
            }
            set
            {
                if ((this._Buchungstext != value))
                {
                    this._Buchungstext = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Verwendungszweck", DbType = "NVarChar(250)")]
        public string Verwendungszweck
        {
            get
            {
                return this._Verwendungszweck;
            }
            set
            {
                if ((this._Verwendungszweck != value))
                {
                    this._Verwendungszweck = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_BeguenstigterZahlungspflichtiger", DbType = "NVarChar(250)")]
        public string BeguenstigterZahlungspflichtiger
        {
            get
            {
                return this._BeguenstigterZahlungspflichtiger;
            }
            set
            {
                if ((this._BeguenstigterZahlungspflichtiger != value))
                {
                    this._BeguenstigterZahlungspflichtiger = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Kontonummer", DbType = "NVarChar(50)")]
        public string Kontonummer
        {
            get
            {
                return this._Kontonummer;
            }
            set
            {
                if ((this._Kontonummer != value))
                {
                    this._Kontonummer = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_BLZ", DbType = "NVarChar(50)")]
        public string BLZ
        {
            get
            {
                return this._BLZ;
            }
            set
            {
                if ((this._BLZ != value))
                {
                    this._BLZ = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Betrag", DbType = "Money")]
        public System.Nullable<decimal> Betrag
        {
            get
            {
                return this._Betrag;
            }
            set
            {
                if ((this._Betrag != value))
                {
                    this._Betrag = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Waehrung", DbType = "NVarChar(200)")]
        public string Waehrung
        {
            get
            {
                return this._Waehrung;
            }
            set
            {
                if ((this._Waehrung != value))
                {
                    this._Waehrung = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Info", DbType = "NVarChar(250)")]
        public string Info
        {
            get
            {
                return this._Info;
            }
            set
            {
                if ((this._Info != value))
                {
                    this._Info = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyID", DbType = "NVarChar(50)")]
        public string CompanyID
        {
            get
            {
                return this._CompanyID;
            }
            set
            {
                if ((this._CompanyID != value))
                {
                    this._CompanyID = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IsValidated", DbType = "Bit")]
        public System.Nullable<bool> IsValidated
        {
            get
            {
                return this._IsValidated;
            }
            set
            {
                if ((this._IsValidated != value))
                {
                    this._IsValidated = value;
                }
            }
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.bckBankStatement0812")]
    public partial class bckBankStatement0812
    {

        private int _id;

        private string _Auftragskonto;

        private System.Nullable<System.DateTime> _Buchungstag;

        private System.Nullable<System.DateTime> _Valutadatum;

        private string _Buchungstext;

        private string _Verwendungszweck;

        private string _BeguenstigterZahlungspflichtiger;

        private string _Kontonummer;

        private string _BLZ;

        private System.Nullable<decimal> _Betrag;

        private string _Waehrung;

        private string _Info;

        private string _CompanyID;

        private string _CompanyIBAN;

        private System.Nullable<bool> _IsValidated;

        public bckBankStatement0812()
        {
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id", AutoSync = AutoSync.Always, DbType = "Int NOT NULL IDENTITY", IsDbGenerated = true)]
        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    this._id = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Auftragskonto", DbType = "NVarChar(50)")]
        public string Auftragskonto
        {
            get
            {
                return this._Auftragskonto;
            }
            set
            {
                if ((this._Auftragskonto != value))
                {
                    this._Auftragskonto = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Buchungstag", DbType = "Date")]
        public System.Nullable<System.DateTime> Buchungstag
        {
            get
            {
                return this._Buchungstag;
            }
            set
            {
                if ((this._Buchungstag != value))
                {
                    this._Buchungstag = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Valutadatum", DbType = "Date")]
        public System.Nullable<System.DateTime> Valutadatum
        {
            get
            {
                return this._Valutadatum;
            }
            set
            {
                if ((this._Valutadatum != value))
                {
                    this._Valutadatum = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Buchungstext", DbType = "NVarChar(200)")]
        public string Buchungstext
        {
            get
            {
                return this._Buchungstext;
            }
            set
            {
                if ((this._Buchungstext != value))
                {
                    this._Buchungstext = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Verwendungszweck", DbType = "NVarChar(250)")]
        public string Verwendungszweck
        {
            get
            {
                return this._Verwendungszweck;
            }
            set
            {
                if ((this._Verwendungszweck != value))
                {
                    this._Verwendungszweck = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_BeguenstigterZahlungspflichtiger", DbType = "NVarChar(250)")]
        public string BeguenstigterZahlungspflichtiger
        {
            get
            {
                return this._BeguenstigterZahlungspflichtiger;
            }
            set
            {
                if ((this._BeguenstigterZahlungspflichtiger != value))
                {
                    this._BeguenstigterZahlungspflichtiger = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Kontonummer", DbType = "NVarChar(50)")]
        public string Kontonummer
        {
            get
            {
                return this._Kontonummer;
            }
            set
            {
                if ((this._Kontonummer != value))
                {
                    this._Kontonummer = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_BLZ", DbType = "NVarChar(50)")]
        public string BLZ
        {
            get
            {
                return this._BLZ;
            }
            set
            {
                if ((this._BLZ != value))
                {
                    this._BLZ = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Betrag", DbType = "Money")]
        public System.Nullable<decimal> Betrag
        {
            get
            {
                return this._Betrag;
            }
            set
            {
                if ((this._Betrag != value))
                {
                    this._Betrag = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Waehrung", DbType = "NVarChar(200)")]
        public string Waehrung
        {
            get
            {
                return this._Waehrung;
            }
            set
            {
                if ((this._Waehrung != value))
                {
                    this._Waehrung = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Info", DbType = "NVarChar(250)")]
        public string Info
        {
            get
            {
                return this._Info;
            }
            set
            {
                if ((this._Info != value))
                {
                    this._Info = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyID", DbType = "NVarChar(50)")]
        public string CompanyID
        {
            get
            {
                return this._CompanyID;
            }
            set
            {
                if ((this._CompanyID != value))
                {
                    this._CompanyID = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyIBAN", DbType = "NVarChar(50)")]
        public string CompanyIBAN
        {
            get
            {
                return this._CompanyIBAN;
            }
            set
            {
                if ((this._CompanyIBAN != value))
                {
                    this._CompanyIBAN = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IsValidated", DbType = "Bit")]
        public System.Nullable<bool> IsValidated
        {
            get
            {
                return this._IsValidated;
            }
            set
            {
                if ((this._IsValidated != value))
                {
                    this._IsValidated = value;
                }
            }
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.bckStatement")]
    public partial class bckStatement
    {

        private string _Auftragskonto;

        private System.Nullable<System.DateTime> _Buchungstag;

        private System.Nullable<System.DateTime> _Valutadatum;

        private string _Buchungstext;

        private string _Verwendungszweck;

        private string _BeguenstigterZahlungspflichtiger;

        private string _Kontonummer;

        private string _BLZ;

        private System.Nullable<decimal> _Betrag;

        private string _Waehrung;

        private string _Info;

        private string _CompanyID;

        private string _CompanyIBAN;

        private System.Nullable<bool> _IsValidated;

        public bckStatement()
        {
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Auftragskonto", DbType = "NVarChar(50)")]
        public string Auftragskonto
        {
            get
            {
                return this._Auftragskonto;
            }
            set
            {
                if ((this._Auftragskonto != value))
                {
                    this._Auftragskonto = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Buchungstag", DbType = "Date")]
        public System.Nullable<System.DateTime> Buchungstag
        {
            get
            {
                return this._Buchungstag;
            }
            set
            {
                if ((this._Buchungstag != value))
                {
                    this._Buchungstag = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Valutadatum", DbType = "Date")]
        public System.Nullable<System.DateTime> Valutadatum
        {
            get
            {
                return this._Valutadatum;
            }
            set
            {
                if ((this._Valutadatum != value))
                {
                    this._Valutadatum = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Buchungstext", DbType = "NVarChar(200)")]
        public string Buchungstext
        {
            get
            {
                return this._Buchungstext;
            }
            set
            {
                if ((this._Buchungstext != value))
                {
                    this._Buchungstext = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Verwendungszweck", DbType = "NVarChar(250)")]
        public string Verwendungszweck
        {
            get
            {
                return this._Verwendungszweck;
            }
            set
            {
                if ((this._Verwendungszweck != value))
                {
                    this._Verwendungszweck = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_BeguenstigterZahlungspflichtiger", DbType = "NVarChar(250)")]
        public string BeguenstigterZahlungspflichtiger
        {
            get
            {
                return this._BeguenstigterZahlungspflichtiger;
            }
            set
            {
                if ((this._BeguenstigterZahlungspflichtiger != value))
                {
                    this._BeguenstigterZahlungspflichtiger = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Kontonummer", DbType = "NVarChar(50)")]
        public string Kontonummer
        {
            get
            {
                return this._Kontonummer;
            }
            set
            {
                if ((this._Kontonummer != value))
                {
                    this._Kontonummer = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_BLZ", DbType = "NVarChar(50)")]
        public string BLZ
        {
            get
            {
                return this._BLZ;
            }
            set
            {
                if ((this._BLZ != value))
                {
                    this._BLZ = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Betrag", DbType = "Money")]
        public System.Nullable<decimal> Betrag
        {
            get
            {
                return this._Betrag;
            }
            set
            {
                if ((this._Betrag != value))
                {
                    this._Betrag = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Waehrung", DbType = "NVarChar(200)")]
        public string Waehrung
        {
            get
            {
                return this._Waehrung;
            }
            set
            {
                if ((this._Waehrung != value))
                {
                    this._Waehrung = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Info", DbType = "NVarChar(250)")]
        public string Info
        {
            get
            {
                return this._Info;
            }
            set
            {
                if ((this._Info != value))
                {
                    this._Info = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyID", DbType = "NVarChar(50)")]
        public string CompanyID
        {
            get
            {
                return this._CompanyID;
            }
            set
            {
                if ((this._CompanyID != value))
                {
                    this._CompanyID = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyIBAN", DbType = "NVarChar(50)")]
        public string CompanyIBAN
        {
            get
            {
                return this._CompanyIBAN;
            }
            set
            {
                if ((this._CompanyIBAN != value))
                {
                    this._CompanyIBAN = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IsValidated", DbType = "Bit")]
        public System.Nullable<bool> IsValidated
        {
            get
            {
                return this._IsValidated;
            }
            set
            {
                if ((this._IsValidated != value))
                {
                    this._IsValidated = value;
                }
            }
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.BillOfDelivery")]
    public partial class BillOfDelivery : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _id;

        private int _oid;

        private string _store;

        private string _account;

        private string _HeaderText;

        private System.DateTime _TransDate;

        private System.DateTime _ItemDate;

        private System.DateTime _EntryDate;

        private string _CompanyId;

        private bool _IsValidated;

        private System.Nullable<decimal> _oTotal;

        private System.Nullable<decimal> _oVat;

        private string _oCurrency;

        private string _oPeriode;

        private System.Nullable<decimal> _oNet;

        private EntitySet<LineBillOfDelivery> _LineBillOfDeliveries;

        private EntityRef<Company> _Company;

        private EntityRef<Customer> _Customer;

        private EntityRef<Store> _Store1;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnidChanging(int value);
        partial void OnidChanged();
        partial void OnoidChanging(int value);
        partial void OnoidChanged();
        partial void OnstoreChanging(string value);
        partial void OnstoreChanged();
        partial void OnaccountChanging(string value);
        partial void OnaccountChanged();
        partial void OnHeaderTextChanging(string value);
        partial void OnHeaderTextChanged();
        partial void OnTransDateChanging(System.DateTime value);
        partial void OnTransDateChanged();
        partial void OnItemDateChanging(System.DateTime value);
        partial void OnItemDateChanged();
        partial void OnEntryDateChanging(System.DateTime value);
        partial void OnEntryDateChanged();
        partial void OnCompanyIdChanging(string value);
        partial void OnCompanyIdChanged();
        partial void OnIsValidatedChanging(bool value);
        partial void OnIsValidatedChanged();
        partial void OnoTotalChanging(System.Nullable<decimal> value);
        partial void OnoTotalChanged();
        partial void OnoVatChanging(System.Nullable<decimal> value);
        partial void OnoVatChanged();
        partial void OnoCurrencyChanging(string value);
        partial void OnoCurrencyChanged();
        partial void OnoPeriodeChanging(string value);
        partial void OnoPeriodeChanged();
        partial void OnoNetChanging(System.Nullable<decimal> value);
        partial void OnoNetChanged();
        #endregion

        public BillOfDelivery()
        {
            this._LineBillOfDeliveries = new EntitySet<LineBillOfDelivery>(new Action<LineBillOfDelivery>(this.attach_LineBillOfDeliveries), new Action<LineBillOfDelivery>(this.detach_LineBillOfDeliveries));
            this._Company = default(EntityRef<Company>);
            this._Customer = default(EntityRef<Customer>);
            this._Store1 = default(EntityRef<Store>);
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    this.OnidChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("id");
                    this.OnidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oid", DbType = "Int NOT NULL")]
        public int oid
        {
            get
            {
                return this._oid;
            }
            set
            {
                if ((this._oid != value))
                {
                    this.OnoidChanging(value);
                    this.SendPropertyChanging();
                    this._oid = value;
                    this.SendPropertyChanged("oid");
                    this.OnoidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_store", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string store
        {
            get
            {
                return this._store;
            }
            set
            {
                if ((this._store != value))
                {
                    if (this._Store1.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnstoreChanging(value);
                    this.SendPropertyChanging();
                    this._store = value;
                    this.SendPropertyChanged("store");
                    this.OnstoreChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_account", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string account
        {
            get
            {
                return this._account;
            }
            set
            {
                if ((this._account != value))
                {
                    if (this._Customer.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnaccountChanging(value);
                    this.SendPropertyChanging();
                    this._account = value;
                    this.SendPropertyChanged("account");
                    this.OnaccountChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_HeaderText", DbType = "NVarChar(250)")]
        public string HeaderText
        {
            get
            {
                return this._HeaderText;
            }
            set
            {
                if ((this._HeaderText != value))
                {
                    this.OnHeaderTextChanging(value);
                    this.SendPropertyChanging();
                    this._HeaderText = value;
                    this.SendPropertyChanged("HeaderText");
                    this.OnHeaderTextChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TransDate", DbType = "Date NOT NULL")]
        public System.DateTime TransDate
        {
            get
            {
                return this._TransDate;
            }
            set
            {
                if ((this._TransDate != value))
                {
                    this.OnTransDateChanging(value);
                    this.SendPropertyChanging();
                    this._TransDate = value;
                    this.SendPropertyChanged("TransDate");
                    this.OnTransDateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ItemDate", DbType = "Date NOT NULL")]
        public System.DateTime ItemDate
        {
            get
            {
                return this._ItemDate;
            }
            set
            {
                if ((this._ItemDate != value))
                {
                    this.OnItemDateChanging(value);
                    this.SendPropertyChanging();
                    this._ItemDate = value;
                    this.SendPropertyChanged("ItemDate");
                    this.OnItemDateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_EntryDate", DbType = "Date NOT NULL")]
        public System.DateTime EntryDate
        {
            get
            {
                return this._EntryDate;
            }
            set
            {
                if ((this._EntryDate != value))
                {
                    this.OnEntryDateChanging(value);
                    this.SendPropertyChanging();
                    this._EntryDate = value;
                    this.SendPropertyChanged("EntryDate");
                    this.OnEntryDateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyId", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CompanyId
        {
            get
            {
                return this._CompanyId;
            }
            set
            {
                if ((this._CompanyId != value))
                {
                    if (this._Company.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnCompanyIdChanging(value);
                    this.SendPropertyChanging();
                    this._CompanyId = value;
                    this.SendPropertyChanged("CompanyId");
                    this.OnCompanyIdChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IsValidated", DbType = "Bit NOT NULL")]
        public bool IsValidated
        {
            get
            {
                return this._IsValidated;
            }
            set
            {
                if ((this._IsValidated != value))
                {
                    this.OnIsValidatedChanging(value);
                    this.SendPropertyChanging();
                    this._IsValidated = value;
                    this.SendPropertyChanged("IsValidated");
                    this.OnIsValidatedChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oTotal", AutoSync = AutoSync.Always, DbType = "Money", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<decimal> oTotal
        {
            get
            {
                return this._oTotal;
            }
            set
            {
                if ((this._oTotal != value))
                {
                    this.OnoTotalChanging(value);
                    this.SendPropertyChanging();
                    this._oTotal = value;
                    this.SendPropertyChanged("oTotal");
                    this.OnoTotalChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oVat", AutoSync = AutoSync.Always, DbType = "Money", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<decimal> oVat
        {
            get
            {
                return this._oVat;
            }
            set
            {
                if ((this._oVat != value))
                {
                    this.OnoVatChanging(value);
                    this.SendPropertyChanging();
                    this._oVat = value;
                    this.SendPropertyChanged("oVat");
                    this.OnoVatChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oCurrency", AutoSync = AutoSync.Always, DbType = "Char(10)", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public string oCurrency
        {
            get
            {
                return this._oCurrency;
            }
            set
            {
                if ((this._oCurrency != value))
                {
                    this.OnoCurrencyChanging(value);
                    this.SendPropertyChanging();
                    this._oCurrency = value;
                    this.SendPropertyChanged("oCurrency");
                    this.OnoCurrencyChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oPeriode", AutoSync = AutoSync.Always, DbType = "NVarChar(6)", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public string oPeriode
        {
            get
            {
                return this._oPeriode;
            }
            set
            {
                if ((this._oPeriode != value))
                {
                    this.OnoPeriodeChanging(value);
                    this.SendPropertyChanging();
                    this._oPeriode = value;
                    this.SendPropertyChanged("oPeriode");
                    this.OnoPeriodeChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oNet", AutoSync = AutoSync.Always, DbType = "Money", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<decimal> oNet
        {
            get
            {
                return this._oNet;
            }
            set
            {
                if ((this._oNet != value))
                {
                    this.OnoNetChanging(value);
                    this.SendPropertyChanging();
                    this._oNet = value;
                    this.SendPropertyChanged("oNet");
                    this.OnoNetChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "BillOfDelivery_LineBillOfDelivery", Storage = "_LineBillOfDeliveries", ThisKey = "id", OtherKey = "transid")]
        public EntitySet<LineBillOfDelivery> LineBillOfDeliveries
        {
            get
            {
                return this._LineBillOfDeliveries;
            }
            set
            {
                this._LineBillOfDeliveries.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Company_BillOfDelivery", Storage = "_Company", ThisKey = "CompanyId", OtherKey = "id", IsForeignKey = true)]
        public Company Company
        {
            get
            {
                return this._Company.Entity;
            }
            set
            {
                Company previousValue = this._Company.Entity;
                if (((previousValue != value)
                            || (this._Company.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Company.Entity = null;
                        previousValue.BillOfDeliveries.Remove(this);
                    }
                    this._Company.Entity = value;
                    if ((value != null))
                    {
                        value.BillOfDeliveries.Add(this);
                        this._CompanyId = value.id;
                    }
                    else
                    {
                        this._CompanyId = default(string);
                    }
                    this.SendPropertyChanged("Company");
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Customer_BillOfDelivery", Storage = "_Customer", ThisKey = "account", OtherKey = "id", IsForeignKey = true)]
        public Customer Customer
        {
            get
            {
                return this._Customer.Entity;
            }
            set
            {
                Customer previousValue = this._Customer.Entity;
                if (((previousValue != value)
                            || (this._Customer.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Customer.Entity = null;
                        previousValue.BillOfDeliveries.Remove(this);
                    }
                    this._Customer.Entity = value;
                    if ((value != null))
                    {
                        value.BillOfDeliveries.Add(this);
                        this._account = value.id;
                    }
                    else
                    {
                        this._account = default(string);
                    }
                    this.SendPropertyChanged("Customer");
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Store_BillOfDelivery", Storage = "_Store1", ThisKey = "store", OtherKey = "id", IsForeignKey = true)]
        public Store Store1
        {
            get
            {
                return this._Store1.Entity;
            }
            set
            {
                Store previousValue = this._Store1.Entity;
                if (((previousValue != value)
                            || (this._Store1.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Store1.Entity = null;
                        previousValue.BillOfDeliveries.Remove(this);
                    }
                    this._Store1.Entity = value;
                    if ((value != null))
                    {
                        value.BillOfDeliveries.Add(this);
                        this._store = value.id;
                    }
                    else
                    {
                        this._store = default(string);
                    }
                    this.SendPropertyChanged("Store1");
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void attach_LineBillOfDeliveries(LineBillOfDelivery entity)
        {
            this.SendPropertyChanging();
            entity.BillOfDelivery = this;
        }

        private void detach_LineBillOfDeliveries(LineBillOfDelivery entity)
        {
            this.SendPropertyChanging();
            entity.BillOfDelivery = null;
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.Category")]
    public partial class Category : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _id;

        private string _name;

        private string _description;

        private string _CompanyID;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnidChanging(string value);
        partial void OnidChanged();
        partial void OnnameChanging(string value);
        partial void OnnameChanged();
        partial void OndescriptionChanging(string value);
        partial void OndescriptionChanged();
        partial void OnCompanyIDChanging(string value);
        partial void OnCompanyIDChanged();
        #endregion

        public Category()
        {
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id", DbType = "NVarChar(50) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    this.OnidChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("id");
                    this.OnidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_name", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
        public string name
        {
            get
            {
                return this._name;
            }
            set
            {
                if ((this._name != value))
                {
                    this.OnnameChanging(value);
                    this.SendPropertyChanging();
                    this._name = value;
                    this.SendPropertyChanged("name");
                    this.OnnameChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_description", DbType = "NVarChar(255)")]
        public string description
        {
            get
            {
                return this._description;
            }
            set
            {
                if ((this._description != value))
                {
                    this.OndescriptionChanging(value);
                    this.SendPropertyChanging();
                    this._description = value;
                    this.SendPropertyChanged("description");
                    this.OndescriptionChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CompanyID
        {
            get
            {
                return this._CompanyID;
            }
            set
            {
                if ((this._CompanyID != value))
                {
                    this.OnCompanyIDChanging(value);
                    this.SendPropertyChanging();
                    this._CompanyID = value;
                    this.SendPropertyChanged("CompanyID");
                    this.OnCompanyIDChanged();
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.ClassSetup")]
    public partial class ClassSetup : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _Id;

        private string _ClassID;

        private string _RoleID;

        private string _CompanyID;

        private EntityRef<Account> _Account;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIdChanging(int value);
        partial void OnIdChanged();
        partial void OnClassIDChanging(string value);
        partial void OnClassIDChanged();
        partial void OnRoleIDChanging(string value);
        partial void OnRoleIDChanged();
        partial void OnCompanyIDChanging(string value);
        partial void OnCompanyIDChanged();
        #endregion

        public ClassSetup()
        {
            this._Account = default(EntityRef<Account>);
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Id", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                if ((this._Id != value))
                {
                    this.OnIdChanging(value);
                    this.SendPropertyChanging();
                    this._Id = value;
                    this.SendPropertyChanged("Id");
                    this.OnIdChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ClassID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string ClassID
        {
            get
            {
                return this._ClassID;
            }
            set
            {
                if ((this._ClassID != value))
                {
                    if (this._Account.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnClassIDChanging(value);
                    this.SendPropertyChanging();
                    this._ClassID = value;
                    this.SendPropertyChanged("ClassID");
                    this.OnClassIDChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_RoleID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string RoleID
        {
            get
            {
                return this._RoleID;
            }
            set
            {
                if ((this._RoleID != value))
                {
                    this.OnRoleIDChanging(value);
                    this.SendPropertyChanging();
                    this._RoleID = value;
                    this.SendPropertyChanged("RoleID");
                    this.OnRoleIDChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CompanyID
        {
            get
            {
                return this._CompanyID;
            }
            set
            {
                if ((this._CompanyID != value))
                {
                    this.OnCompanyIDChanging(value);
                    this.SendPropertyChanging();
                    this._CompanyID = value;
                    this.SendPropertyChanged("CompanyID");
                    this.OnCompanyIDChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Account_ClassSetup", Storage = "_Account", ThisKey = "ClassID", OtherKey = "id", IsForeignKey = true)]
        public Account Account
        {
            get
            {
                return this._Account.Entity;
            }
            set
            {
                Account previousValue = this._Account.Entity;
                if (((previousValue != value)
                            || (this._Account.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Account.Entity = null;
                        previousValue.ClassSetups.Remove(this);
                    }
                    this._Account.Entity = value;
                    if ((value != null))
                    {
                        value.ClassSetups.Add(this);
                        this._ClassID = value.id;
                    }
                    else
                    {
                        this._ClassID = default(string);
                    }
                    this.SendPropertyChanged("Account");
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.Company")]
    public partial class Company : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _id;

        private string _name;

        private string _street;

        private string _city;

        private string _state;

        private string _zip;

        private string _bankaccountid;

        private string _purchasingclearingaccountid;

        private string _salesclearingaccountid;

        private string _paymentclearingaccountid;

        private string _settlementclearingaccountid;

        private string _taxcode;

        private string _vatcode;

        private string _Currency;

        private string _IBAN;

        private string _CIF;

        private string _BalanceSheet;

        private string _IncomesStatement;

        private EntitySet<VendorInvoice> _VendorInvoices;

        private EntitySet<BillOfDelivery> _BillOfDeliveries;

        private EntitySet<CustomerInvoice> _CustomerInvoices;

        private EntitySet<GeneralLedger> _GeneralLedgers;

        private EntitySet<GoodReceiving> _GoodReceivings;

        private EntitySet<InventoryInvoice> _InventoryInvoices;

        private EntitySet<Payment> _Payments;

        private EntitySet<PurchaseOrder> _PurchaseOrders;

        private EntitySet<SalesInvoice> _SalesInvoices;

        private EntitySet<SalesOrder> _SalesOrders;

        private EntitySet<Settlement> _Settlements;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnidChanging(string value);
        partial void OnidChanged();
        partial void OnnameChanging(string value);
        partial void OnnameChanged();
        partial void OnstreetChanging(string value);
        partial void OnstreetChanged();
        partial void OncityChanging(string value);
        partial void OncityChanged();
        partial void OnstateChanging(string value);
        partial void OnstateChanged();
        partial void OnzipChanging(string value);
        partial void OnzipChanged();
        partial void OnbankaccountidChanging(string value);
        partial void OnbankaccountidChanged();
        partial void OnpurchasingclearingaccountidChanging(string value);
        partial void OnpurchasingclearingaccountidChanged();
        partial void OnsalesclearingaccountidChanging(string value);
        partial void OnsalesclearingaccountidChanged();
        partial void OnpaymentclearingaccountidChanging(string value);
        partial void OnpaymentclearingaccountidChanged();
        partial void OnsettlementclearingaccountidChanging(string value);
        partial void OnsettlementclearingaccountidChanged();
        partial void OntaxcodeChanging(string value);
        partial void OntaxcodeChanged();
        partial void OnvatcodeChanging(string value);
        partial void OnvatcodeChanged();
        partial void OnCurrencyChanging(string value);
        partial void OnCurrencyChanged();
        partial void OnIBANChanging(string value);
        partial void OnIBANChanged();
        partial void OnCIFChanging(string value);
        partial void OnCIFChanged();
        partial void OnBalanceSheetChanging(string value);
        partial void OnBalanceSheetChanged();
        partial void OnIncomesStatementChanging(string value);
        partial void OnIncomesStatementChanged();
        #endregion

        public Company()
        {
            this._VendorInvoices = new EntitySet<VendorInvoice>(new Action<VendorInvoice>(this.attach_VendorInvoices), new Action<VendorInvoice>(this.detach_VendorInvoices));
            this._BillOfDeliveries = new EntitySet<BillOfDelivery>(new Action<BillOfDelivery>(this.attach_BillOfDeliveries), new Action<BillOfDelivery>(this.detach_BillOfDeliveries));
            this._CustomerInvoices = new EntitySet<CustomerInvoice>(new Action<CustomerInvoice>(this.attach_CustomerInvoices), new Action<CustomerInvoice>(this.detach_CustomerInvoices));
            this._GeneralLedgers = new EntitySet<GeneralLedger>(new Action<GeneralLedger>(this.attach_GeneralLedgers), new Action<GeneralLedger>(this.detach_GeneralLedgers));
            this._GoodReceivings = new EntitySet<GoodReceiving>(new Action<GoodReceiving>(this.attach_GoodReceivings), new Action<GoodReceiving>(this.detach_GoodReceivings));
            this._InventoryInvoices = new EntitySet<InventoryInvoice>(new Action<InventoryInvoice>(this.attach_InventoryInvoices), new Action<InventoryInvoice>(this.detach_InventoryInvoices));
            this._Payments = new EntitySet<Payment>(new Action<Payment>(this.attach_Payments), new Action<Payment>(this.detach_Payments));
            this._PurchaseOrders = new EntitySet<PurchaseOrder>(new Action<PurchaseOrder>(this.attach_PurchaseOrders), new Action<PurchaseOrder>(this.detach_PurchaseOrders));
            this._SalesInvoices = new EntitySet<SalesInvoice>(new Action<SalesInvoice>(this.attach_SalesInvoices), new Action<SalesInvoice>(this.detach_SalesInvoices));
            this._SalesOrders = new EntitySet<SalesOrder>(new Action<SalesOrder>(this.attach_SalesOrders), new Action<SalesOrder>(this.detach_SalesOrders));
            this._Settlements = new EntitySet<Settlement>(new Action<Settlement>(this.attach_Settlements), new Action<Settlement>(this.detach_Settlements));
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id", DbType = "NVarChar(50) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    this.OnidChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("id");
                    this.OnidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_name", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
        public string name
        {
            get
            {
                return this._name;
            }
            set
            {
                if ((this._name != value))
                {
                    this.OnnameChanging(value);
                    this.SendPropertyChanging();
                    this._name = value;
                    this.SendPropertyChanged("name");
                    this.OnnameChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_street", DbType = "NVarChar(255)")]
        public string street
        {
            get
            {
                return this._street;
            }
            set
            {
                if ((this._street != value))
                {
                    this.OnstreetChanging(value);
                    this.SendPropertyChanging();
                    this._street = value;
                    this.SendPropertyChanged("street");
                    this.OnstreetChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_city", DbType = "NVarChar(255)")]
        public string city
        {
            get
            {
                return this._city;
            }
            set
            {
                if ((this._city != value))
                {
                    this.OncityChanging(value);
                    this.SendPropertyChanging();
                    this._city = value;
                    this.SendPropertyChanged("city");
                    this.OncityChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_state", DbType = "NVarChar(255)")]
        public string state
        {
            get
            {
                return this._state;
            }
            set
            {
                if ((this._state != value))
                {
                    this.OnstateChanging(value);
                    this.SendPropertyChanging();
                    this._state = value;
                    this.SendPropertyChanged("state");
                    this.OnstateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_zip", DbType = "NVarChar(255)")]
        public string zip
        {
            get
            {
                return this._zip;
            }
            set
            {
                if ((this._zip != value))
                {
                    this.OnzipChanging(value);
                    this.SendPropertyChanging();
                    this._zip = value;
                    this.SendPropertyChanged("zip");
                    this.OnzipChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_bankaccountid", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
        public string bankaccountid
        {
            get
            {
                return this._bankaccountid;
            }
            set
            {
                if ((this._bankaccountid != value))
                {
                    this.OnbankaccountidChanging(value);
                    this.SendPropertyChanging();
                    this._bankaccountid = value;
                    this.SendPropertyChanged("bankaccountid");
                    this.OnbankaccountidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_purchasingclearingaccountid", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
        public string purchasingclearingaccountid
        {
            get
            {
                return this._purchasingclearingaccountid;
            }
            set
            {
                if ((this._purchasingclearingaccountid != value))
                {
                    this.OnpurchasingclearingaccountidChanging(value);
                    this.SendPropertyChanging();
                    this._purchasingclearingaccountid = value;
                    this.SendPropertyChanged("purchasingclearingaccountid");
                    this.OnpurchasingclearingaccountidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_salesclearingaccountid", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
        public string salesclearingaccountid
        {
            get
            {
                return this._salesclearingaccountid;
            }
            set
            {
                if ((this._salesclearingaccountid != value))
                {
                    this.OnsalesclearingaccountidChanging(value);
                    this.SendPropertyChanging();
                    this._salesclearingaccountid = value;
                    this.SendPropertyChanged("salesclearingaccountid");
                    this.OnsalesclearingaccountidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_paymentclearingaccountid", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
        public string paymentclearingaccountid
        {
            get
            {
                return this._paymentclearingaccountid;
            }
            set
            {
                if ((this._paymentclearingaccountid != value))
                {
                    this.OnpaymentclearingaccountidChanging(value);
                    this.SendPropertyChanging();
                    this._paymentclearingaccountid = value;
                    this.SendPropertyChanged("paymentclearingaccountid");
                    this.OnpaymentclearingaccountidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_settlementclearingaccountid", DbType = "NVarChar(255)")]
        public string settlementclearingaccountid
        {
            get
            {
                return this._settlementclearingaccountid;
            }
            set
            {
                if ((this._settlementclearingaccountid != value))
                {
                    this.OnsettlementclearingaccountidChanging(value);
                    this.SendPropertyChanging();
                    this._settlementclearingaccountid = value;
                    this.SendPropertyChanged("settlementclearingaccountid");
                    this.OnsettlementclearingaccountidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_taxcode", DbType = "NVarChar(255)")]
        public string taxcode
        {
            get
            {
                return this._taxcode;
            }
            set
            {
                if ((this._taxcode != value))
                {
                    this.OntaxcodeChanging(value);
                    this.SendPropertyChanging();
                    this._taxcode = value;
                    this.SendPropertyChanged("taxcode");
                    this.OntaxcodeChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_vatcode", DbType = "NVarChar(255)")]
        public string vatcode
        {
            get
            {
                return this._vatcode;
            }
            set
            {
                if ((this._vatcode != value))
                {
                    this.OnvatcodeChanging(value);
                    this.SendPropertyChanging();
                    this._vatcode = value;
                    this.SendPropertyChanged("vatcode");
                    this.OnvatcodeChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Currency", DbType = "NVarChar(50)")]
        public string Currency
        {
            get
            {
                return this._Currency;
            }
            set
            {
                if ((this._Currency != value))
                {
                    this.OnCurrencyChanging(value);
                    this.SendPropertyChanging();
                    this._Currency = value;
                    this.SendPropertyChanged("Currency");
                    this.OnCurrencyChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IBAN", DbType = "NVarChar(50)")]
        public string IBAN
        {
            get
            {
                return this._IBAN;
            }
            set
            {
                if ((this._IBAN != value))
                {
                    this.OnIBANChanging(value);
                    this.SendPropertyChanging();
                    this._IBAN = value;
                    this.SendPropertyChanged("IBAN");
                    this.OnIBANChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CIF", DbType = "NVarChar(50)")]
        public string CIF
        {
            get
            {
                return this._CIF;
            }
            set
            {
                if ((this._CIF != value))
                {
                    this.OnCIFChanging(value);
                    this.SendPropertyChanging();
                    this._CIF = value;
                    this.SendPropertyChanged("CIF");
                    this.OnCIFChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_BalanceSheet", DbType = "NVarChar(50)")]
        public string BalanceSheet
        {
            get
            {
                return this._BalanceSheet;
            }
            set
            {
                if ((this._BalanceSheet != value))
                {
                    this.OnBalanceSheetChanging(value);
                    this.SendPropertyChanging();
                    this._BalanceSheet = value;
                    this.SendPropertyChanged("BalanceSheet");
                    this.OnBalanceSheetChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IncomesStatement", DbType = "NVarChar(50)")]
        public string IncomesStatement
        {
            get
            {
                return this._IncomesStatement;
            }
            set
            {
                if ((this._IncomesStatement != value))
                {
                    this.OnIncomesStatementChanging(value);
                    this.SendPropertyChanging();
                    this._IncomesStatement = value;
                    this.SendPropertyChanged("IncomesStatement");
                    this.OnIncomesStatementChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Company_VendorInvoice", Storage = "_VendorInvoices", ThisKey = "id", OtherKey = "CompanyId")]
        public EntitySet<VendorInvoice> VendorInvoices
        {
            get
            {
                return this._VendorInvoices;
            }
            set
            {
                this._VendorInvoices.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Company_BillOfDelivery", Storage = "_BillOfDeliveries", ThisKey = "id", OtherKey = "CompanyId")]
        public EntitySet<BillOfDelivery> BillOfDeliveries
        {
            get
            {
                return this._BillOfDeliveries;
            }
            set
            {
                this._BillOfDeliveries.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Company_CustomerInvoice", Storage = "_CustomerInvoices", ThisKey = "id", OtherKey = "CompanyId")]
        public EntitySet<CustomerInvoice> CustomerInvoices
        {
            get
            {
                return this._CustomerInvoices;
            }
            set
            {
                this._CustomerInvoices.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Company_GeneralLedger", Storage = "_GeneralLedgers", ThisKey = "id", OtherKey = "CompanyId")]
        public EntitySet<GeneralLedger> GeneralLedgers
        {
            get
            {
                return this._GeneralLedgers;
            }
            set
            {
                this._GeneralLedgers.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Company_GoodReceiving", Storage = "_GoodReceivings", ThisKey = "id", OtherKey = "CompanyId")]
        public EntitySet<GoodReceiving> GoodReceivings
        {
            get
            {
                return this._GoodReceivings;
            }
            set
            {
                this._GoodReceivings.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Company_InventoryInvoice", Storage = "_InventoryInvoices", ThisKey = "id", OtherKey = "CompanyId")]
        public EntitySet<InventoryInvoice> InventoryInvoices
        {
            get
            {
                return this._InventoryInvoices;
            }
            set
            {
                this._InventoryInvoices.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Company_Payment", Storage = "_Payments", ThisKey = "id", OtherKey = "CompanyId")]
        public EntitySet<Payment> Payments
        {
            get
            {
                return this._Payments;
            }
            set
            {
                this._Payments.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Company_PurchaseOrder", Storage = "_PurchaseOrders", ThisKey = "id", OtherKey = "CompanyId")]
        public EntitySet<PurchaseOrder> PurchaseOrders
        {
            get
            {
                return this._PurchaseOrders;
            }
            set
            {
                this._PurchaseOrders.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Company_SalesInvoice", Storage = "_SalesInvoices", ThisKey = "id", OtherKey = "CompanyId")]
        public EntitySet<SalesInvoice> SalesInvoices
        {
            get
            {
                return this._SalesInvoices;
            }
            set
            {
                this._SalesInvoices.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Company_SalesOrder", Storage = "_SalesOrders", ThisKey = "id", OtherKey = "CompanyId")]
        public EntitySet<SalesOrder> SalesOrders
        {
            get
            {
                return this._SalesOrders;
            }
            set
            {
                this._SalesOrders.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Company_Settlement", Storage = "_Settlements", ThisKey = "id", OtherKey = "CompanyId")]
        public EntitySet<Settlement> Settlements
        {
            get
            {
                return this._Settlements;
            }
            set
            {
                this._Settlements.Assign(value);
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void attach_VendorInvoices(VendorInvoice entity)
        {
            this.SendPropertyChanging();
            entity.Company = this;
        }

        private void detach_VendorInvoices(VendorInvoice entity)
        {
            this.SendPropertyChanging();
            entity.Company = null;
        }

        private void attach_BillOfDeliveries(BillOfDelivery entity)
        {
            this.SendPropertyChanging();
            entity.Company = this;
        }

        private void detach_BillOfDeliveries(BillOfDelivery entity)
        {
            this.SendPropertyChanging();
            entity.Company = null;
        }

        private void attach_CustomerInvoices(CustomerInvoice entity)
        {
            this.SendPropertyChanging();
            entity.Company = this;
        }

        private void detach_CustomerInvoices(CustomerInvoice entity)
        {
            this.SendPropertyChanging();
            entity.Company = null;
        }

        private void attach_GeneralLedgers(GeneralLedger entity)
        {
            this.SendPropertyChanging();
            entity.Company = this;
        }

        private void detach_GeneralLedgers(GeneralLedger entity)
        {
            this.SendPropertyChanging();
            entity.Company = null;
        }

        private void attach_GoodReceivings(GoodReceiving entity)
        {
            this.SendPropertyChanging();
            entity.Company = this;
        }

        private void detach_GoodReceivings(GoodReceiving entity)
        {
            this.SendPropertyChanging();
            entity.Company = null;
        }

        private void attach_InventoryInvoices(InventoryInvoice entity)
        {
            this.SendPropertyChanging();
            entity.Company = this;
        }

        private void detach_InventoryInvoices(InventoryInvoice entity)
        {
            this.SendPropertyChanging();
            entity.Company = null;
        }

        private void attach_Payments(Payment entity)
        {
            this.SendPropertyChanging();
            entity.Company = this;
        }

        private void detach_Payments(Payment entity)
        {
            this.SendPropertyChanging();
            entity.Company = null;
        }

        private void attach_PurchaseOrders(PurchaseOrder entity)
        {
            this.SendPropertyChanging();
            entity.Company = this;
        }

        private void detach_PurchaseOrders(PurchaseOrder entity)
        {
            this.SendPropertyChanging();
            entity.Company = null;
        }

        private void attach_SalesInvoices(SalesInvoice entity)
        {
            this.SendPropertyChanging();
            entity.Company = this;
        }

        private void detach_SalesInvoices(SalesInvoice entity)
        {
            this.SendPropertyChanging();
            entity.Company = null;
        }

        private void attach_SalesOrders(SalesOrder entity)
        {
            this.SendPropertyChanging();
            entity.Company = this;
        }

        private void detach_SalesOrders(SalesOrder entity)
        {
            this.SendPropertyChanging();
            entity.Company = null;
        }

        private void attach_Settlements(Settlement entity)
        {
            this.SendPropertyChanging();
            entity.Company = this;
        }

        private void detach_Settlements(Settlement entity)
        {
            this.SendPropertyChanging();
            entity.Company = null;
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.CostCenter")]
    public partial class CostCenter : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _id;

        private string _name;

        private string _description;

        private string _accountid;

        private string _CompanyID;

        private EntitySet<VendorInvoice> _VendorInvoices;

        private EntitySet<CustomerInvoice> _CustomerInvoices;

        private EntityRef<Account> _Account;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnidChanging(string value);
        partial void OnidChanged();
        partial void OnnameChanging(string value);
        partial void OnnameChanged();
        partial void OndescriptionChanging(string value);
        partial void OndescriptionChanged();
        partial void OnaccountidChanging(string value);
        partial void OnaccountidChanged();
        partial void OnCompanyIDChanging(string value);
        partial void OnCompanyIDChanged();
        #endregion

        public CostCenter()
        {
            this._VendorInvoices = new EntitySet<VendorInvoice>(new Action<VendorInvoice>(this.attach_VendorInvoices), new Action<VendorInvoice>(this.detach_VendorInvoices));
            this._CustomerInvoices = new EntitySet<CustomerInvoice>(new Action<CustomerInvoice>(this.attach_CustomerInvoices), new Action<CustomerInvoice>(this.detach_CustomerInvoices));
            this._Account = default(EntityRef<Account>);
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id", DbType = "NVarChar(50) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    this.OnidChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("id");
                    this.OnidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_name", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
        public string name
        {
            get
            {
                return this._name;
            }
            set
            {
                if ((this._name != value))
                {
                    this.OnnameChanging(value);
                    this.SendPropertyChanging();
                    this._name = value;
                    this.SendPropertyChanged("name");
                    this.OnnameChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_description", DbType = "NVarChar(255)")]
        public string description
        {
            get
            {
                return this._description;
            }
            set
            {
                if ((this._description != value))
                {
                    this.OndescriptionChanging(value);
                    this.SendPropertyChanging();
                    this._description = value;
                    this.SendPropertyChanged("description");
                    this.OndescriptionChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_accountid", DbType = "NVarChar(50)")]
        public string accountid
        {
            get
            {
                return this._accountid;
            }
            set
            {
                if ((this._accountid != value))
                {
                    if (this._Account.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnaccountidChanging(value);
                    this.SendPropertyChanging();
                    this._accountid = value;
                    this.SendPropertyChanged("accountid");
                    this.OnaccountidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CompanyID
        {
            get
            {
                return this._CompanyID;
            }
            set
            {
                if ((this._CompanyID != value))
                {
                    this.OnCompanyIDChanging(value);
                    this.SendPropertyChanging();
                    this._CompanyID = value;
                    this.SendPropertyChanged("CompanyID");
                    this.OnCompanyIDChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "CostCenter_VendorInvoice", Storage = "_VendorInvoices", ThisKey = "id", OtherKey = "CostCenter")]
        public EntitySet<VendorInvoice> VendorInvoices
        {
            get
            {
                return this._VendorInvoices;
            }
            set
            {
                this._VendorInvoices.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "CostCenter_CustomerInvoice", Storage = "_CustomerInvoices", ThisKey = "id", OtherKey = "CostCenter")]
        public EntitySet<CustomerInvoice> CustomerInvoices
        {
            get
            {
                return this._CustomerInvoices;
            }
            set
            {
                this._CustomerInvoices.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Account_CostCenter", Storage = "_Account", ThisKey = "accountid", OtherKey = "id", IsForeignKey = true)]
        public Account Account
        {
            get
            {
                return this._Account.Entity;
            }
            set
            {
                Account previousValue = this._Account.Entity;
                if (((previousValue != value)
                            || (this._Account.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Account.Entity = null;
                        previousValue.CostCenters.Remove(this);
                    }
                    this._Account.Entity = value;
                    if ((value != null))
                    {
                        value.CostCenters.Add(this);
                        this._accountid = value.id;
                    }
                    else
                    {
                        this._accountid = default(string);
                    }
                    this.SendPropertyChanged("Account");
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void attach_VendorInvoices(VendorInvoice entity)
        {
            this.SendPropertyChanging();
            entity.CostCenter1 = this;
        }

        private void detach_VendorInvoices(VendorInvoice entity)
        {
            this.SendPropertyChanging();
            entity.CostCenter1 = null;
        }

        private void attach_CustomerInvoices(CustomerInvoice entity)
        {
            this.SendPropertyChanging();
            entity.CostCenter1 = this;
        }

        private void detach_CustomerInvoices(CustomerInvoice entity)
        {
            this.SendPropertyChanging();
            entity.CostCenter1 = null;
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.Country")]
    public partial class Country : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _code;

        private string _name;

        private int _population;

        private decimal _gnp;

        private string _CompanyID;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OncodeChanging(string value);
        partial void OncodeChanged();
        partial void OnnameChanging(string value);
        partial void OnnameChanged();
        partial void OnpopulationChanging(int value);
        partial void OnpopulationChanged();
        partial void OngnpChanging(decimal value);
        partial void OngnpChanged();
        partial void OnCompanyIDChanging(string value);
        partial void OnCompanyIDChanged();
        #endregion

        public Country()
        {
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_code", DbType = "NVarChar(50) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string code
        {
            get
            {
                return this._code;
            }
            set
            {
                if ((this._code != value))
                {
                    this.OncodeChanging(value);
                    this.SendPropertyChanging();
                    this._code = value;
                    this.SendPropertyChanged("code");
                    this.OncodeChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_name", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string name
        {
            get
            {
                return this._name;
            }
            set
            {
                if ((this._name != value))
                {
                    this.OnnameChanging(value);
                    this.SendPropertyChanging();
                    this._name = value;
                    this.SendPropertyChanged("name");
                    this.OnnameChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_population", DbType = "Int NOT NULL")]
        public int population
        {
            get
            {
                return this._population;
            }
            set
            {
                if ((this._population != value))
                {
                    this.OnpopulationChanging(value);
                    this.SendPropertyChanging();
                    this._population = value;
                    this.SendPropertyChanged("population");
                    this.OnpopulationChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_gnp", DbType = "Money NOT NULL")]
        public decimal gnp
        {
            get
            {
                return this._gnp;
            }
            set
            {
                if ((this._gnp != value))
                {
                    this.OngnpChanging(value);
                    this.SendPropertyChanging();
                    this._gnp = value;
                    this.SendPropertyChanged("gnp");
                    this.OngnpChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CompanyID
        {
            get
            {
                return this._CompanyID;
            }
            set
            {
                if ((this._CompanyID != value))
                {
                    this.OnCompanyIDChanging(value);
                    this.SendPropertyChanging();
                    this._CompanyID = value;
                    this.SendPropertyChanged("CompanyID");
                    this.OnCompanyIDChanged();
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.Currency")]
    public partial class Currency : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _Id;

        private string _Name;

        private string _CompanyID;

        private string _Description;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIdChanging(string value);
        partial void OnIdChanged();
        partial void OnNameChanging(string value);
        partial void OnNameChanged();
        partial void OnCompanyIDChanging(string value);
        partial void OnCompanyIDChanged();
        partial void OnDescriptionChanging(string value);
        partial void OnDescriptionChanged();
        #endregion

        public Currency()
        {
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Id", DbType = "NVarChar(10) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                if ((this._Id != value))
                {
                    this.OnIdChanging(value);
                    this.SendPropertyChanging();
                    this._Id = value;
                    this.SendPropertyChanged("Id");
                    this.OnIdChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Name", DbType = "NVarChar(10) NOT NULL", CanBeNull = false)]
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                if ((this._Name != value))
                {
                    this.OnNameChanging(value);
                    this.SendPropertyChanging();
                    this._Name = value;
                    this.SendPropertyChanged("Name");
                    this.OnNameChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string CompanyID
        {
            get
            {
                return this._CompanyID;
            }
            set
            {
                if ((this._CompanyID != value))
                {
                    this.OnCompanyIDChanging(value);
                    this.SendPropertyChanging();
                    this._CompanyID = value;
                    this.SendPropertyChanged("CompanyID");
                    this.OnCompanyIDChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Description", DbType = "NVarChar(255)")]
        public string Description
        {
            get
            {
                return this._Description;
            }
            set
            {
                if ((this._Description != value))
                {
                    this.OnDescriptionChanging(value);
                    this.SendPropertyChanging();
                    this._Description = value;
                    this.SendPropertyChanged("Description");
                    this.OnDescriptionChanged();
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.Customer")]
    public partial class Customer : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _id;

        private string _name;

        private string _street;

        private string _city;

        private string _state;

        private string _zip;

        private string _Phone;

        private string _Email;

        private string _accountid;

        private string _CompanyID;

        private string _IBAN;

        private string _Bank;

        private string _BIC;

        private string _VatCode;

        private string _Produit;

        private EntitySet<BillOfDelivery> _BillOfDeliveries;

        private EntitySet<CustomerInvoice> _CustomerInvoices;

        private EntitySet<SalesInvoice> _SalesInvoices;

        private EntitySet<Settlement> _Settlements;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnidChanging(string value);
        partial void OnidChanged();
        partial void OnnameChanging(string value);
        partial void OnnameChanged();
        partial void OnstreetChanging(string value);
        partial void OnstreetChanged();
        partial void OncityChanging(string value);
        partial void OncityChanged();
        partial void OnstateChanging(string value);
        partial void OnstateChanged();
        partial void OnzipChanging(string value);
        partial void OnzipChanged();
        partial void OnPhoneChanging(string value);
        partial void OnPhoneChanged();
        partial void OnEmailChanging(string value);
        partial void OnEmailChanged();
        partial void OnaccountidChanging(string value);
        partial void OnaccountidChanged();
        partial void OnCompanyIDChanging(string value);
        partial void OnCompanyIDChanged();
        partial void OnIBANChanging(string value);
        partial void OnIBANChanged();
        partial void OnBankChanging(string value);
        partial void OnBankChanged();
        partial void OnBICChanging(string value);
        partial void OnBICChanged();
        partial void OnVatCodeChanging(string value);
        partial void OnVatCodeChanged();
        partial void OnProduitChanging(string value);
        partial void OnProduitChanged();
        #endregion

        public Customer()
        {
            this._BillOfDeliveries = new EntitySet<BillOfDelivery>(new Action<BillOfDelivery>(this.attach_BillOfDeliveries), new Action<BillOfDelivery>(this.detach_BillOfDeliveries));
            this._CustomerInvoices = new EntitySet<CustomerInvoice>(new Action<CustomerInvoice>(this.attach_CustomerInvoices), new Action<CustomerInvoice>(this.detach_CustomerInvoices));
            this._SalesInvoices = new EntitySet<SalesInvoice>(new Action<SalesInvoice>(this.attach_SalesInvoices), new Action<SalesInvoice>(this.detach_SalesInvoices));
            this._Settlements = new EntitySet<Settlement>(new Action<Settlement>(this.attach_Settlements), new Action<Settlement>(this.detach_Settlements));
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id", DbType = "NVarChar(50) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    this.OnidChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("id");
                    this.OnidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_name", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
        public string name
        {
            get
            {
                return this._name;
            }
            set
            {
                if ((this._name != value))
                {
                    this.OnnameChanging(value);
                    this.SendPropertyChanging();
                    this._name = value;
                    this.SendPropertyChanged("name");
                    this.OnnameChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_street", DbType = "NVarChar(255)")]
        public string street
        {
            get
            {
                return this._street;
            }
            set
            {
                if ((this._street != value))
                {
                    this.OnstreetChanging(value);
                    this.SendPropertyChanging();
                    this._street = value;
                    this.SendPropertyChanged("street");
                    this.OnstreetChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_city", DbType = "NVarChar(255)")]
        public string city
        {
            get
            {
                return this._city;
            }
            set
            {
                if ((this._city != value))
                {
                    this.OncityChanging(value);
                    this.SendPropertyChanging();
                    this._city = value;
                    this.SendPropertyChanged("city");
                    this.OncityChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_state", DbType = "NVarChar(255)")]
        public string state
        {
            get
            {
                return this._state;
            }
            set
            {
                if ((this._state != value))
                {
                    this.OnstateChanging(value);
                    this.SendPropertyChanging();
                    this._state = value;
                    this.SendPropertyChanged("state");
                    this.OnstateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_zip", DbType = "NVarChar(255)")]
        public string zip
        {
            get
            {
                return this._zip;
            }
            set
            {
                if ((this._zip != value))
                {
                    this.OnzipChanging(value);
                    this.SendPropertyChanging();
                    this._zip = value;
                    this.SendPropertyChanged("zip");
                    this.OnzipChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Phone", DbType = "NVarChar(50)")]
        public string Phone
        {
            get
            {
                return this._Phone;
            }
            set
            {
                if ((this._Phone != value))
                {
                    this.OnPhoneChanging(value);
                    this.SendPropertyChanging();
                    this._Phone = value;
                    this.SendPropertyChanged("Phone");
                    this.OnPhoneChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Email", DbType = "NVarChar(50)")]
        public string Email
        {
            get
            {
                return this._Email;
            }
            set
            {
                if ((this._Email != value))
                {
                    this.OnEmailChanging(value);
                    this.SendPropertyChanging();
                    this._Email = value;
                    this.SendPropertyChanged("Email");
                    this.OnEmailChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_accountid", DbType = "NVarChar(50)")]
        public string accountid
        {
            get
            {
                return this._accountid;
            }
            set
            {
                if ((this._accountid != value))
                {
                    this.OnaccountidChanging(value);
                    this.SendPropertyChanging();
                    this._accountid = value;
                    this.SendPropertyChanged("accountid");
                    this.OnaccountidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CompanyID
        {
            get
            {
                return this._CompanyID;
            }
            set
            {
                if ((this._CompanyID != value))
                {
                    this.OnCompanyIDChanging(value);
                    this.SendPropertyChanging();
                    this._CompanyID = value;
                    this.SendPropertyChanged("CompanyID");
                    this.OnCompanyIDChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IBAN", DbType = "NVarChar(50)")]
        public string IBAN
        {
            get
            {
                return this._IBAN;
            }
            set
            {
                if ((this._IBAN != value))
                {
                    this.OnIBANChanging(value);
                    this.SendPropertyChanging();
                    this._IBAN = value;
                    this.SendPropertyChanged("IBAN");
                    this.OnIBANChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Bank", DbType = "NVarChar(50)")]
        public string Bank
        {
            get
            {
                return this._Bank;
            }
            set
            {
                if ((this._Bank != value))
                {
                    this.OnBankChanging(value);
                    this.SendPropertyChanging();
                    this._Bank = value;
                    this.SendPropertyChanged("Bank");
                    this.OnBankChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_BIC", DbType = "NVarChar(50)")]
        public string BIC
        {
            get
            {
                return this._BIC;
            }
            set
            {
                if ((this._BIC != value))
                {
                    this.OnBICChanging(value);
                    this.SendPropertyChanging();
                    this._BIC = value;
                    this.SendPropertyChanged("BIC");
                    this.OnBICChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_VatCode", DbType = "NVarChar(50)")]
        public string VatCode
        {
            get
            {
                return this._VatCode;
            }
            set
            {
                if ((this._VatCode != value))
                {
                    this.OnVatCodeChanging(value);
                    this.SendPropertyChanging();
                    this._VatCode = value;
                    this.SendPropertyChanged("VatCode");
                    this.OnVatCodeChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Produit", DbType = "NVarChar(50)")]
        public string Produit
        {
            get
            {
                return this._Produit;
            }
            set
            {
                if ((this._Produit != value))
                {
                    this.OnProduitChanging(value);
                    this.SendPropertyChanging();
                    this._Produit = value;
                    this.SendPropertyChanged("Produit");
                    this.OnProduitChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Customer_BillOfDelivery", Storage = "_BillOfDeliveries", ThisKey = "id", OtherKey = "account")]
        public EntitySet<BillOfDelivery> BillOfDeliveries
        {
            get
            {
                return this._BillOfDeliveries;
            }
            set
            {
                this._BillOfDeliveries.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Customer_CustomerInvoice", Storage = "_CustomerInvoices", ThisKey = "id", OtherKey = "account")]
        public EntitySet<CustomerInvoice> CustomerInvoices
        {
            get
            {
                return this._CustomerInvoices;
            }
            set
            {
                this._CustomerInvoices.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Customer_SalesInvoice", Storage = "_SalesInvoices", ThisKey = "id", OtherKey = "account")]
        public EntitySet<SalesInvoice> SalesInvoices
        {
            get
            {
                return this._SalesInvoices;
            }
            set
            {
                this._SalesInvoices.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Customer_Settlement", Storage = "_Settlements", ThisKey = "id", OtherKey = "account")]
        public EntitySet<Settlement> Settlements
        {
            get
            {
                return this._Settlements;
            }
            set
            {
                this._Settlements.Assign(value);
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void attach_BillOfDeliveries(BillOfDelivery entity)
        {
            this.SendPropertyChanging();
            entity.Customer = this;
        }

        private void detach_BillOfDeliveries(BillOfDelivery entity)
        {
            this.SendPropertyChanging();
            entity.Customer = null;
        }

        private void attach_CustomerInvoices(CustomerInvoice entity)
        {
            this.SendPropertyChanging();
            entity.Customer = this;
        }

        private void detach_CustomerInvoices(CustomerInvoice entity)
        {
            this.SendPropertyChanging();
            entity.Customer = null;
        }

        private void attach_SalesInvoices(SalesInvoice entity)
        {
            this.SendPropertyChanging();
            entity.Customer = this;
        }

        private void detach_SalesInvoices(SalesInvoice entity)
        {
            this.SendPropertyChanging();
            entity.Customer = null;
        }

        private void attach_Settlements(Settlement entity)
        {
            this.SendPropertyChanging();
            entity.Customer = this;
        }

        private void detach_Settlements(Settlement entity)
        {
            this.SendPropertyChanging();
            entity.Customer = null;
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.CustomerInvoice")]
    public partial class CustomerInvoice : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _id;

        private int _oid;

        private string _CostCenter;

        private string _account;

        private string _HeaderText;

        private System.DateTime _TransDate;

        private System.DateTime _ItemDate;

        private System.DateTime _EntryDate;

        private string _CompanyId;

        private System.Nullable<bool> _IsValidated;

        private System.Nullable<decimal> _oTotal;

        private string _oCurrency;

        private string _oPeriode;

        private EntitySet<LineCustomerInvoice> _LineCustomerInvoices;

        private EntityRef<Company> _Company;

        private EntityRef<CostCenter> _CostCenter1;

        private EntityRef<Customer> _Customer;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnidChanging(int value);
        partial void OnidChanged();
        partial void OnoidChanging(int value);
        partial void OnoidChanged();
        partial void OnCostCenterChanging(string value);
        partial void OnCostCenterChanged();
        partial void OnaccountChanging(string value);
        partial void OnaccountChanged();
        partial void OnHeaderTextChanging(string value);
        partial void OnHeaderTextChanged();
        partial void OnTransDateChanging(System.DateTime value);
        partial void OnTransDateChanged();
        partial void OnItemDateChanging(System.DateTime value);
        partial void OnItemDateChanged();
        partial void OnEntryDateChanging(System.DateTime value);
        partial void OnEntryDateChanged();
        partial void OnCompanyIdChanging(string value);
        partial void OnCompanyIdChanged();
        partial void OnIsValidatedChanging(System.Nullable<bool> value);
        partial void OnIsValidatedChanged();
        partial void OnoTotalChanging(System.Nullable<decimal> value);
        partial void OnoTotalChanged();
        partial void OnoCurrencyChanging(string value);
        partial void OnoCurrencyChanged();
        partial void OnoPeriodeChanging(string value);
        partial void OnoPeriodeChanged();
        #endregion

        public CustomerInvoice()
        {
            this._LineCustomerInvoices = new EntitySet<LineCustomerInvoice>(new Action<LineCustomerInvoice>(this.attach_LineCustomerInvoices), new Action<LineCustomerInvoice>(this.detach_LineCustomerInvoices));
            this._Company = default(EntityRef<Company>);
            this._CostCenter1 = default(EntityRef<CostCenter>);
            this._Customer = default(EntityRef<Customer>);
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    this.OnidChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("id");
                    this.OnidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oid", DbType = "Int NOT NULL")]
        public int oid
        {
            get
            {
                return this._oid;
            }
            set
            {
                if ((this._oid != value))
                {
                    this.OnoidChanging(value);
                    this.SendPropertyChanging();
                    this._oid = value;
                    this.SendPropertyChanged("oid");
                    this.OnoidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CostCenter", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CostCenter
        {
            get
            {
                return this._CostCenter;
            }
            set
            {
                if ((this._CostCenter != value))
                {
                    if (this._CostCenter1.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnCostCenterChanging(value);
                    this.SendPropertyChanging();
                    this._CostCenter = value;
                    this.SendPropertyChanged("CostCenter");
                    this.OnCostCenterChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_account", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string account
        {
            get
            {
                return this._account;
            }
            set
            {
                if ((this._account != value))
                {
                    if (this._Customer.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnaccountChanging(value);
                    this.SendPropertyChanging();
                    this._account = value;
                    this.SendPropertyChanged("account");
                    this.OnaccountChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_HeaderText", DbType = "NVarChar(250)")]
        public string HeaderText
        {
            get
            {
                return this._HeaderText;
            }
            set
            {
                if ((this._HeaderText != value))
                {
                    this.OnHeaderTextChanging(value);
                    this.SendPropertyChanging();
                    this._HeaderText = value;
                    this.SendPropertyChanged("HeaderText");
                    this.OnHeaderTextChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TransDate", DbType = "Date NOT NULL")]
        public System.DateTime TransDate
        {
            get
            {
                return this._TransDate;
            }
            set
            {
                if ((this._TransDate != value))
                {
                    this.OnTransDateChanging(value);
                    this.SendPropertyChanging();
                    this._TransDate = value;
                    this.SendPropertyChanged("TransDate");
                    this.OnTransDateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ItemDate", DbType = "Date NOT NULL")]
        public System.DateTime ItemDate
        {
            get
            {
                return this._ItemDate;
            }
            set
            {
                if ((this._ItemDate != value))
                {
                    this.OnItemDateChanging(value);
                    this.SendPropertyChanging();
                    this._ItemDate = value;
                    this.SendPropertyChanged("ItemDate");
                    this.OnItemDateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_EntryDate", DbType = "Date NOT NULL")]
        public System.DateTime EntryDate
        {
            get
            {
                return this._EntryDate;
            }
            set
            {
                if ((this._EntryDate != value))
                {
                    this.OnEntryDateChanging(value);
                    this.SendPropertyChanging();
                    this._EntryDate = value;
                    this.SendPropertyChanged("EntryDate");
                    this.OnEntryDateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyId", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CompanyId
        {
            get
            {
                return this._CompanyId;
            }
            set
            {
                if ((this._CompanyId != value))
                {
                    if (this._Company.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnCompanyIdChanging(value);
                    this.SendPropertyChanging();
                    this._CompanyId = value;
                    this.SendPropertyChanged("CompanyId");
                    this.OnCompanyIdChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IsValidated", DbType = "Bit")]
        public System.Nullable<bool> IsValidated
        {
            get
            {
                return this._IsValidated;
            }
            set
            {
                if ((this._IsValidated != value))
                {
                    this.OnIsValidatedChanging(value);
                    this.SendPropertyChanging();
                    this._IsValidated = value;
                    this.SendPropertyChanged("IsValidated");
                    this.OnIsValidatedChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oTotal", AutoSync = AutoSync.Always, DbType = "Money", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<decimal> oTotal
        {
            get
            {
                return this._oTotal;
            }
            set
            {
                if ((this._oTotal != value))
                {
                    this.OnoTotalChanging(value);
                    this.SendPropertyChanging();
                    this._oTotal = value;
                    this.SendPropertyChanged("oTotal");
                    this.OnoTotalChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oCurrency", AutoSync = AutoSync.Always, DbType = "NVarChar(10)", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public string oCurrency
        {
            get
            {
                return this._oCurrency;
            }
            set
            {
                if ((this._oCurrency != value))
                {
                    this.OnoCurrencyChanging(value);
                    this.SendPropertyChanging();
                    this._oCurrency = value;
                    this.SendPropertyChanged("oCurrency");
                    this.OnoCurrencyChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oPeriode", AutoSync = AutoSync.Always, DbType = "NVarChar(6)", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public string oPeriode
        {
            get
            {
                return this._oPeriode;
            }
            set
            {
                if ((this._oPeriode != value))
                {
                    this.OnoPeriodeChanging(value);
                    this.SendPropertyChanging();
                    this._oPeriode = value;
                    this.SendPropertyChanged("oPeriode");
                    this.OnoPeriodeChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "CustomerInvoice_LineCustomerInvoice", Storage = "_LineCustomerInvoices", ThisKey = "id", OtherKey = "transid")]
        public EntitySet<LineCustomerInvoice> LineCustomerInvoices
        {
            get
            {
                return this._LineCustomerInvoices;
            }
            set
            {
                this._LineCustomerInvoices.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Company_CustomerInvoice", Storage = "_Company", ThisKey = "CompanyId", OtherKey = "id", IsForeignKey = true)]
        public Company Company
        {
            get
            {
                return this._Company.Entity;
            }
            set
            {
                Company previousValue = this._Company.Entity;
                if (((previousValue != value)
                            || (this._Company.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Company.Entity = null;
                        previousValue.CustomerInvoices.Remove(this);
                    }
                    this._Company.Entity = value;
                    if ((value != null))
                    {
                        value.CustomerInvoices.Add(this);
                        this._CompanyId = value.id;
                    }
                    else
                    {
                        this._CompanyId = default(string);
                    }
                    this.SendPropertyChanged("Company");
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "CostCenter_CustomerInvoice", Storage = "_CostCenter1", ThisKey = "CostCenter", OtherKey = "id", IsForeignKey = true)]
        public CostCenter CostCenter1
        {
            get
            {
                return this._CostCenter1.Entity;
            }
            set
            {
                CostCenter previousValue = this._CostCenter1.Entity;
                if (((previousValue != value)
                            || (this._CostCenter1.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._CostCenter1.Entity = null;
                        previousValue.CustomerInvoices.Remove(this);
                    }
                    this._CostCenter1.Entity = value;
                    if ((value != null))
                    {
                        value.CustomerInvoices.Add(this);
                        this._CostCenter = value.id;
                    }
                    else
                    {
                        this._CostCenter = default(string);
                    }
                    this.SendPropertyChanged("CostCenter1");
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Customer_CustomerInvoice", Storage = "_Customer", ThisKey = "account", OtherKey = "id", IsForeignKey = true)]
        public Customer Customer
        {
            get
            {
                return this._Customer.Entity;
            }
            set
            {
                Customer previousValue = this._Customer.Entity;
                if (((previousValue != value)
                            || (this._Customer.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Customer.Entity = null;
                        previousValue.CustomerInvoices.Remove(this);
                    }
                    this._Customer.Entity = value;
                    if ((value != null))
                    {
                        value.CustomerInvoices.Add(this);
                        this._account = value.id;
                    }
                    else
                    {
                        this._account = default(string);
                    }
                    this.SendPropertyChanged("Customer");
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void attach_LineCustomerInvoices(LineCustomerInvoice entity)
        {
            this.SendPropertyChanging();
            entity.CustomerInvoice = this;
        }

        private void detach_LineCustomerInvoices(LineCustomerInvoice entity)
        {
            this.SendPropertyChanging();
            entity.CustomerInvoice = null;
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.GeneralLedger")]
    public partial class GeneralLedger : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _id;

        private int _oid;

        private string _CostCenter;

        private string _Area;

        private string _HeaderText;

        private System.DateTime _TransDate;

        private System.DateTime _ItemDate;

        private System.DateTime _EntryDate;

        private string _CompanyId;

        private bool _IsValidated;

        private System.Nullable<decimal> _oTotal;

        private string _oCurrency;

        private string _oPeriode;

        private EntitySet<LineGeneralLedger> _LineGeneralLedgers;

        private EntityRef<Company> _Company;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnidChanging(int value);
        partial void OnidChanged();
        partial void OnoidChanging(int value);
        partial void OnoidChanged();
        partial void OnCostCenterChanging(string value);
        partial void OnCostCenterChanged();
        partial void OnAreaChanging(string value);
        partial void OnAreaChanged();
        partial void OnHeaderTextChanging(string value);
        partial void OnHeaderTextChanged();
        partial void OnTransDateChanging(System.DateTime value);
        partial void OnTransDateChanged();
        partial void OnItemDateChanging(System.DateTime value);
        partial void OnItemDateChanged();
        partial void OnEntryDateChanging(System.DateTime value);
        partial void OnEntryDateChanged();
        partial void OnCompanyIdChanging(string value);
        partial void OnCompanyIdChanged();
        partial void OnIsValidatedChanging(bool value);
        partial void OnIsValidatedChanged();
        partial void OnoTotalChanging(System.Nullable<decimal> value);
        partial void OnoTotalChanged();
        partial void OnoCurrencyChanging(string value);
        partial void OnoCurrencyChanged();
        partial void OnoPeriodeChanging(string value);
        partial void OnoPeriodeChanged();
        #endregion

        public GeneralLedger()
        {
            this._LineGeneralLedgers = new EntitySet<LineGeneralLedger>(new Action<LineGeneralLedger>(this.attach_LineGeneralLedgers), new Action<LineGeneralLedger>(this.detach_LineGeneralLedgers));
            this._Company = default(EntityRef<Company>);
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    this.OnidChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("id");
                    this.OnidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oid", DbType = "Int NOT NULL")]
        public int oid
        {
            get
            {
                return this._oid;
            }
            set
            {
                if ((this._oid != value))
                {
                    this.OnoidChanging(value);
                    this.SendPropertyChanging();
                    this._oid = value;
                    this.SendPropertyChanged("oid");
                    this.OnoidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CostCenter", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CostCenter
        {
            get
            {
                return this._CostCenter;
            }
            set
            {
                if ((this._CostCenter != value))
                {
                    this.OnCostCenterChanging(value);
                    this.SendPropertyChanging();
                    this._CostCenter = value;
                    this.SendPropertyChanged("CostCenter");
                    this.OnCostCenterChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Area", DbType = "NVarChar(15) NOT NULL", CanBeNull = false)]
        public string Area
        {
            get
            {
                return this._Area;
            }
            set
            {
                if ((this._Area != value))
                {
                    this.OnAreaChanging(value);
                    this.SendPropertyChanging();
                    this._Area = value;
                    this.SendPropertyChanged("Area");
                    this.OnAreaChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_HeaderText", DbType = "NVarChar(250) NOT NULL", CanBeNull = false)]
        public string HeaderText
        {
            get
            {
                return this._HeaderText;
            }
            set
            {
                if ((this._HeaderText != value))
                {
                    this.OnHeaderTextChanging(value);
                    this.SendPropertyChanging();
                    this._HeaderText = value;
                    this.SendPropertyChanged("HeaderText");
                    this.OnHeaderTextChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TransDate", DbType = "Date NOT NULL")]
        public System.DateTime TransDate
        {
            get
            {
                return this._TransDate;
            }
            set
            {
                if ((this._TransDate != value))
                {
                    this.OnTransDateChanging(value);
                    this.SendPropertyChanging();
                    this._TransDate = value;
                    this.SendPropertyChanged("TransDate");
                    this.OnTransDateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ItemDate", DbType = "Date NOT NULL")]
        public System.DateTime ItemDate
        {
            get
            {
                return this._ItemDate;
            }
            set
            {
                if ((this._ItemDate != value))
                {
                    this.OnItemDateChanging(value);
                    this.SendPropertyChanging();
                    this._ItemDate = value;
                    this.SendPropertyChanged("ItemDate");
                    this.OnItemDateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_EntryDate", DbType = "Date NOT NULL")]
        public System.DateTime EntryDate
        {
            get
            {
                return this._EntryDate;
            }
            set
            {
                if ((this._EntryDate != value))
                {
                    this.OnEntryDateChanging(value);
                    this.SendPropertyChanging();
                    this._EntryDate = value;
                    this.SendPropertyChanged("EntryDate");
                    this.OnEntryDateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyId", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CompanyId
        {
            get
            {
                return this._CompanyId;
            }
            set
            {
                if ((this._CompanyId != value))
                {
                    if (this._Company.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnCompanyIdChanging(value);
                    this.SendPropertyChanging();
                    this._CompanyId = value;
                    this.SendPropertyChanged("CompanyId");
                    this.OnCompanyIdChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IsValidated", DbType = "Bit NOT NULL")]
        public bool IsValidated
        {
            get
            {
                return this._IsValidated;
            }
            set
            {
                if ((this._IsValidated != value))
                {
                    this.OnIsValidatedChanging(value);
                    this.SendPropertyChanging();
                    this._IsValidated = value;
                    this.SendPropertyChanged("IsValidated");
                    this.OnIsValidatedChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oTotal", AutoSync = AutoSync.Always, DbType = "Money", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<decimal> oTotal
        {
            get
            {
                return this._oTotal;
            }
            set
            {
                if ((this._oTotal != value))
                {
                    this.OnoTotalChanging(value);
                    this.SendPropertyChanging();
                    this._oTotal = value;
                    this.SendPropertyChanged("oTotal");
                    this.OnoTotalChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oCurrency", AutoSync = AutoSync.Always, DbType = "NVarChar(10)", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public string oCurrency
        {
            get
            {
                return this._oCurrency;
            }
            set
            {
                if ((this._oCurrency != value))
                {
                    this.OnoCurrencyChanging(value);
                    this.SendPropertyChanging();
                    this._oCurrency = value;
                    this.SendPropertyChanged("oCurrency");
                    this.OnoCurrencyChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oPeriode", AutoSync = AutoSync.Always, DbType = "NVarChar(6)", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public string oPeriode
        {
            get
            {
                return this._oPeriode;
            }
            set
            {
                if ((this._oPeriode != value))
                {
                    this.OnoPeriodeChanging(value);
                    this.SendPropertyChanging();
                    this._oPeriode = value;
                    this.SendPropertyChanged("oPeriode");
                    this.OnoPeriodeChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "GeneralLedger_LineGeneralLedger", Storage = "_LineGeneralLedgers", ThisKey = "id", OtherKey = "transid")]
        public EntitySet<LineGeneralLedger> LineGeneralLedgers
        {
            get
            {
                return this._LineGeneralLedgers;
            }
            set
            {
                this._LineGeneralLedgers.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Company_GeneralLedger", Storage = "_Company", ThisKey = "CompanyId", OtherKey = "id", IsForeignKey = true)]
        public Company Company
        {
            get
            {
                return this._Company.Entity;
            }
            set
            {
                Company previousValue = this._Company.Entity;
                if (((previousValue != value)
                            || (this._Company.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Company.Entity = null;
                        previousValue.GeneralLedgers.Remove(this);
                    }
                    this._Company.Entity = value;
                    if ((value != null))
                    {
                        value.GeneralLedgers.Add(this);
                        this._CompanyId = value.id;
                    }
                    else
                    {
                        this._CompanyId = default(string);
                    }
                    this.SendPropertyChanged("Company");
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void attach_LineGeneralLedgers(LineGeneralLedger entity)
        {
            this.SendPropertyChanging();
            entity.GeneralLedger = this;
        }

        private void detach_LineGeneralLedgers(LineGeneralLedger entity)
        {
            this.SendPropertyChanging();
            entity.GeneralLedger = null;
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.GoodReceiving")]
    public partial class GoodReceiving : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _id;

        private int _oid;

        private string _store;

        private string _account;

        private string _HeaderText;

        private System.DateTime _TransDate;

        private System.DateTime _ItemDate;

        private System.DateTime _EntryDate;

        private string _CompanyId;

        private bool _IsValidated;

        private System.Nullable<decimal> _oTotal;

        private System.Nullable<decimal> _oVat;

        private string _oCurrency;

        private string _oPeriode;

        private System.Nullable<decimal> _oNet;

        private EntitySet<LineGoodReceiving> _LineGoodReceivings;

        private EntityRef<Company> _Company;

        private EntityRef<Store> _Store1;

        private EntityRef<Supplier> _Supplier;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnidChanging(int value);
        partial void OnidChanged();
        partial void OnoidChanging(int value);
        partial void OnoidChanged();
        partial void OnstoreChanging(string value);
        partial void OnstoreChanged();
        partial void OnaccountChanging(string value);
        partial void OnaccountChanged();
        partial void OnHeaderTextChanging(string value);
        partial void OnHeaderTextChanged();
        partial void OnTransDateChanging(System.DateTime value);
        partial void OnTransDateChanged();
        partial void OnItemDateChanging(System.DateTime value);
        partial void OnItemDateChanged();
        partial void OnEntryDateChanging(System.DateTime value);
        partial void OnEntryDateChanged();
        partial void OnCompanyIdChanging(string value);
        partial void OnCompanyIdChanged();
        partial void OnIsValidatedChanging(bool value);
        partial void OnIsValidatedChanged();
        partial void OnoTotalChanging(System.Nullable<decimal> value);
        partial void OnoTotalChanged();
        partial void OnoVatChanging(System.Nullable<decimal> value);
        partial void OnoVatChanged();
        partial void OnoCurrencyChanging(string value);
        partial void OnoCurrencyChanged();
        partial void OnoPeriodeChanging(string value);
        partial void OnoPeriodeChanged();
        partial void OnoNetChanging(System.Nullable<decimal> value);
        partial void OnoNetChanged();
        #endregion

        public GoodReceiving()
        {
            this._LineGoodReceivings = new EntitySet<LineGoodReceiving>(new Action<LineGoodReceiving>(this.attach_LineGoodReceivings), new Action<LineGoodReceiving>(this.detach_LineGoodReceivings));
            this._Company = default(EntityRef<Company>);
            this._Store1 = default(EntityRef<Store>);
            this._Supplier = default(EntityRef<Supplier>);
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    this.OnidChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("id");
                    this.OnidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oid", DbType = "Int NOT NULL")]
        public int oid
        {
            get
            {
                return this._oid;
            }
            set
            {
                if ((this._oid != value))
                {
                    this.OnoidChanging(value);
                    this.SendPropertyChanging();
                    this._oid = value;
                    this.SendPropertyChanged("oid");
                    this.OnoidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_store", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string store
        {
            get
            {
                return this._store;
            }
            set
            {
                if ((this._store != value))
                {
                    if (this._Store1.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnstoreChanging(value);
                    this.SendPropertyChanging();
                    this._store = value;
                    this.SendPropertyChanged("store");
                    this.OnstoreChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_account", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string account
        {
            get
            {
                return this._account;
            }
            set
            {
                if ((this._account != value))
                {
                    if (this._Supplier.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnaccountChanging(value);
                    this.SendPropertyChanging();
                    this._account = value;
                    this.SendPropertyChanged("account");
                    this.OnaccountChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_HeaderText", DbType = "NVarChar(250)")]
        public string HeaderText
        {
            get
            {
                return this._HeaderText;
            }
            set
            {
                if ((this._HeaderText != value))
                {
                    this.OnHeaderTextChanging(value);
                    this.SendPropertyChanging();
                    this._HeaderText = value;
                    this.SendPropertyChanged("HeaderText");
                    this.OnHeaderTextChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TransDate", DbType = "Date NOT NULL")]
        public System.DateTime TransDate
        {
            get
            {
                return this._TransDate;
            }
            set
            {
                if ((this._TransDate != value))
                {
                    this.OnTransDateChanging(value);
                    this.SendPropertyChanging();
                    this._TransDate = value;
                    this.SendPropertyChanged("TransDate");
                    this.OnTransDateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ItemDate", DbType = "Date NOT NULL")]
        public System.DateTime ItemDate
        {
            get
            {
                return this._ItemDate;
            }
            set
            {
                if ((this._ItemDate != value))
                {
                    this.OnItemDateChanging(value);
                    this.SendPropertyChanging();
                    this._ItemDate = value;
                    this.SendPropertyChanged("ItemDate");
                    this.OnItemDateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_EntryDate", DbType = "Date NOT NULL")]
        public System.DateTime EntryDate
        {
            get
            {
                return this._EntryDate;
            }
            set
            {
                if ((this._EntryDate != value))
                {
                    this.OnEntryDateChanging(value);
                    this.SendPropertyChanging();
                    this._EntryDate = value;
                    this.SendPropertyChanged("EntryDate");
                    this.OnEntryDateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyId", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CompanyId
        {
            get
            {
                return this._CompanyId;
            }
            set
            {
                if ((this._CompanyId != value))
                {
                    if (this._Company.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnCompanyIdChanging(value);
                    this.SendPropertyChanging();
                    this._CompanyId = value;
                    this.SendPropertyChanged("CompanyId");
                    this.OnCompanyIdChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IsValidated", DbType = "Bit NOT NULL")]
        public bool IsValidated
        {
            get
            {
                return this._IsValidated;
            }
            set
            {
                if ((this._IsValidated != value))
                {
                    this.OnIsValidatedChanging(value);
                    this.SendPropertyChanging();
                    this._IsValidated = value;
                    this.SendPropertyChanged("IsValidated");
                    this.OnIsValidatedChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oTotal", AutoSync = AutoSync.Always, DbType = "Money", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<decimal> oTotal
        {
            get
            {
                return this._oTotal;
            }
            set
            {
                if ((this._oTotal != value))
                {
                    this.OnoTotalChanging(value);
                    this.SendPropertyChanging();
                    this._oTotal = value;
                    this.SendPropertyChanged("oTotal");
                    this.OnoTotalChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oVat", AutoSync = AutoSync.Always, DbType = "Money", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<decimal> oVat
        {
            get
            {
                return this._oVat;
            }
            set
            {
                if ((this._oVat != value))
                {
                    this.OnoVatChanging(value);
                    this.SendPropertyChanging();
                    this._oVat = value;
                    this.SendPropertyChanged("oVat");
                    this.OnoVatChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oCurrency", AutoSync = AutoSync.Always, DbType = "Char(10)", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public string oCurrency
        {
            get
            {
                return this._oCurrency;
            }
            set
            {
                if ((this._oCurrency != value))
                {
                    this.OnoCurrencyChanging(value);
                    this.SendPropertyChanging();
                    this._oCurrency = value;
                    this.SendPropertyChanged("oCurrency");
                    this.OnoCurrencyChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oPeriode", AutoSync = AutoSync.Always, DbType = "NVarChar(6)", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public string oPeriode
        {
            get
            {
                return this._oPeriode;
            }
            set
            {
                if ((this._oPeriode != value))
                {
                    this.OnoPeriodeChanging(value);
                    this.SendPropertyChanging();
                    this._oPeriode = value;
                    this.SendPropertyChanged("oPeriode");
                    this.OnoPeriodeChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oNet", AutoSync = AutoSync.Always, DbType = "Money", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<decimal> oNet
        {
            get
            {
                return this._oNet;
            }
            set
            {
                if ((this._oNet != value))
                {
                    this.OnoNetChanging(value);
                    this.SendPropertyChanging();
                    this._oNet = value;
                    this.SendPropertyChanged("oNet");
                    this.OnoNetChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "GoodReceiving_LineGoodReceiving", Storage = "_LineGoodReceivings", ThisKey = "id", OtherKey = "transid")]
        public EntitySet<LineGoodReceiving> LineGoodReceivings
        {
            get
            {
                return this._LineGoodReceivings;
            }
            set
            {
                this._LineGoodReceivings.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Company_GoodReceiving", Storage = "_Company", ThisKey = "CompanyId", OtherKey = "id", IsForeignKey = true)]
        public Company Company
        {
            get
            {
                return this._Company.Entity;
            }
            set
            {
                Company previousValue = this._Company.Entity;
                if (((previousValue != value)
                            || (this._Company.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Company.Entity = null;
                        previousValue.GoodReceivings.Remove(this);
                    }
                    this._Company.Entity = value;
                    if ((value != null))
                    {
                        value.GoodReceivings.Add(this);
                        this._CompanyId = value.id;
                    }
                    else
                    {
                        this._CompanyId = default(string);
                    }
                    this.SendPropertyChanged("Company");
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Store_GoodReceiving", Storage = "_Store1", ThisKey = "store", OtherKey = "id", IsForeignKey = true)]
        public Store Store1
        {
            get
            {
                return this._Store1.Entity;
            }
            set
            {
                Store previousValue = this._Store1.Entity;
                if (((previousValue != value)
                            || (this._Store1.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Store1.Entity = null;
                        previousValue.GoodReceivings.Remove(this);
                    }
                    this._Store1.Entity = value;
                    if ((value != null))
                    {
                        value.GoodReceivings.Add(this);
                        this._store = value.id;
                    }
                    else
                    {
                        this._store = default(string);
                    }
                    this.SendPropertyChanged("Store1");
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Supplier_GoodReceiving", Storage = "_Supplier", ThisKey = "account", OtherKey = "id", IsForeignKey = true)]
        public Supplier Supplier
        {
            get
            {
                return this._Supplier.Entity;
            }
            set
            {
                Supplier previousValue = this._Supplier.Entity;
                if (((previousValue != value)
                            || (this._Supplier.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Supplier.Entity = null;
                        previousValue.GoodReceivings.Remove(this);
                    }
                    this._Supplier.Entity = value;
                    if ((value != null))
                    {
                        value.GoodReceivings.Add(this);
                        this._account = value.id;
                    }
                    else
                    {
                        this._account = default(string);
                    }
                    this.SendPropertyChanged("Supplier");
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void attach_LineGoodReceivings(LineGoodReceiving entity)
        {
            this.SendPropertyChanging();
            entity.GoodReceiving = this;
        }

        private void detach_LineGoodReceivings(LineGoodReceiving entity)
        {
            this.SendPropertyChanging();
            entity.GoodReceiving = null;
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.InventoryInvoice")]
    public partial class InventoryInvoice : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _id;

        private int _oid;

        private string _store;

        private string _account;

        private string _HeaderText;

        private System.DateTime _TransDate;

        private System.DateTime _ItemDate;

        private System.DateTime _EntryDate;

        private string _CompanyId;

        private System.Nullable<bool> _IsValidated;

        private System.Nullable<decimal> _oTotal;

        private System.Nullable<decimal> _oVat;

        private string _oCurrency;

        private string _oPeriode;

        private System.Nullable<decimal> _oNet;

        private EntitySet<LineInventoryInvoice> _LineInventoryInvoices;

        private EntityRef<Company> _Company;

        private EntityRef<Store> _Store1;

        private EntityRef<Supplier> _Supplier;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnidChanging(int value);
        partial void OnidChanged();
        partial void OnoidChanging(int value);
        partial void OnoidChanged();
        partial void OnstoreChanging(string value);
        partial void OnstoreChanged();
        partial void OnaccountChanging(string value);
        partial void OnaccountChanged();
        partial void OnHeaderTextChanging(string value);
        partial void OnHeaderTextChanged();
        partial void OnTransDateChanging(System.DateTime value);
        partial void OnTransDateChanged();
        partial void OnItemDateChanging(System.DateTime value);
        partial void OnItemDateChanged();
        partial void OnEntryDateChanging(System.DateTime value);
        partial void OnEntryDateChanged();
        partial void OnCompanyIdChanging(string value);
        partial void OnCompanyIdChanged();
        partial void OnIsValidatedChanging(System.Nullable<bool> value);
        partial void OnIsValidatedChanged();
        partial void OnoTotalChanging(System.Nullable<decimal> value);
        partial void OnoTotalChanged();
        partial void OnoVatChanging(System.Nullable<decimal> value);
        partial void OnoVatChanged();
        partial void OnoCurrencyChanging(string value);
        partial void OnoCurrencyChanged();
        partial void OnoPeriodeChanging(string value);
        partial void OnoPeriodeChanged();
        partial void OnoNetChanging(System.Nullable<decimal> value);
        partial void OnoNetChanged();
        #endregion

        public InventoryInvoice()
        {
            this._LineInventoryInvoices = new EntitySet<LineInventoryInvoice>(new Action<LineInventoryInvoice>(this.attach_LineInventoryInvoices), new Action<LineInventoryInvoice>(this.detach_LineInventoryInvoices));
            this._Company = default(EntityRef<Company>);
            this._Store1 = default(EntityRef<Store>);
            this._Supplier = default(EntityRef<Supplier>);
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    this.OnidChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("id");
                    this.OnidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oid", DbType = "Int NOT NULL")]
        public int oid
        {
            get
            {
                return this._oid;
            }
            set
            {
                if ((this._oid != value))
                {
                    this.OnoidChanging(value);
                    this.SendPropertyChanging();
                    this._oid = value;
                    this.SendPropertyChanged("oid");
                    this.OnoidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_store", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string store
        {
            get
            {
                return this._store;
            }
            set
            {
                if ((this._store != value))
                {
                    if (this._Store1.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnstoreChanging(value);
                    this.SendPropertyChanging();
                    this._store = value;
                    this.SendPropertyChanged("store");
                    this.OnstoreChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_account", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string account
        {
            get
            {
                return this._account;
            }
            set
            {
                if ((this._account != value))
                {
                    if (this._Supplier.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnaccountChanging(value);
                    this.SendPropertyChanging();
                    this._account = value;
                    this.SendPropertyChanged("account");
                    this.OnaccountChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_HeaderText", DbType = "NVarChar(250)")]
        public string HeaderText
        {
            get
            {
                return this._HeaderText;
            }
            set
            {
                if ((this._HeaderText != value))
                {
                    this.OnHeaderTextChanging(value);
                    this.SendPropertyChanging();
                    this._HeaderText = value;
                    this.SendPropertyChanged("HeaderText");
                    this.OnHeaderTextChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TransDate", DbType = "Date NOT NULL")]
        public System.DateTime TransDate
        {
            get
            {
                return this._TransDate;
            }
            set
            {
                if ((this._TransDate != value))
                {
                    this.OnTransDateChanging(value);
                    this.SendPropertyChanging();
                    this._TransDate = value;
                    this.SendPropertyChanged("TransDate");
                    this.OnTransDateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ItemDate", DbType = "Date NOT NULL")]
        public System.DateTime ItemDate
        {
            get
            {
                return this._ItemDate;
            }
            set
            {
                if ((this._ItemDate != value))
                {
                    this.OnItemDateChanging(value);
                    this.SendPropertyChanging();
                    this._ItemDate = value;
                    this.SendPropertyChanged("ItemDate");
                    this.OnItemDateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_EntryDate", DbType = "Date NOT NULL")]
        public System.DateTime EntryDate
        {
            get
            {
                return this._EntryDate;
            }
            set
            {
                if ((this._EntryDate != value))
                {
                    this.OnEntryDateChanging(value);
                    this.SendPropertyChanging();
                    this._EntryDate = value;
                    this.SendPropertyChanged("EntryDate");
                    this.OnEntryDateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyId", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CompanyId
        {
            get
            {
                return this._CompanyId;
            }
            set
            {
                if ((this._CompanyId != value))
                {
                    if (this._Company.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnCompanyIdChanging(value);
                    this.SendPropertyChanging();
                    this._CompanyId = value;
                    this.SendPropertyChanged("CompanyId");
                    this.OnCompanyIdChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IsValidated", DbType = "Bit")]
        public System.Nullable<bool> IsValidated
        {
            get
            {
                return this._IsValidated;
            }
            set
            {
                if ((this._IsValidated != value))
                {
                    this.OnIsValidatedChanging(value);
                    this.SendPropertyChanging();
                    this._IsValidated = value;
                    this.SendPropertyChanged("IsValidated");
                    this.OnIsValidatedChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oTotal", AutoSync = AutoSync.Always, DbType = "Money", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<decimal> oTotal
        {
            get
            {
                return this._oTotal;
            }
            set
            {
                if ((this._oTotal != value))
                {
                    this.OnoTotalChanging(value);
                    this.SendPropertyChanging();
                    this._oTotal = value;
                    this.SendPropertyChanged("oTotal");
                    this.OnoTotalChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oVat", AutoSync = AutoSync.Always, DbType = "Money", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<decimal> oVat
        {
            get
            {
                return this._oVat;
            }
            set
            {
                if ((this._oVat != value))
                {
                    this.OnoVatChanging(value);
                    this.SendPropertyChanging();
                    this._oVat = value;
                    this.SendPropertyChanged("oVat");
                    this.OnoVatChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oCurrency", AutoSync = AutoSync.Always, DbType = "NVarChar(10)", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public string oCurrency
        {
            get
            {
                return this._oCurrency;
            }
            set
            {
                if ((this._oCurrency != value))
                {
                    this.OnoCurrencyChanging(value);
                    this.SendPropertyChanging();
                    this._oCurrency = value;
                    this.SendPropertyChanged("oCurrency");
                    this.OnoCurrencyChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oPeriode", AutoSync = AutoSync.Always, DbType = "NVarChar(6)", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public string oPeriode
        {
            get
            {
                return this._oPeriode;
            }
            set
            {
                if ((this._oPeriode != value))
                {
                    this.OnoPeriodeChanging(value);
                    this.SendPropertyChanging();
                    this._oPeriode = value;
                    this.SendPropertyChanged("oPeriode");
                    this.OnoPeriodeChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oNet", AutoSync = AutoSync.Always, DbType = "Money", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<decimal> oNet
        {
            get
            {
                return this._oNet;
            }
            set
            {
                if ((this._oNet != value))
                {
                    this.OnoNetChanging(value);
                    this.SendPropertyChanging();
                    this._oNet = value;
                    this.SendPropertyChanged("oNet");
                    this.OnoNetChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "InventoryInvoice_LineInventoryInvoice", Storage = "_LineInventoryInvoices", ThisKey = "id", OtherKey = "transid")]
        public EntitySet<LineInventoryInvoice> LineInventoryInvoices
        {
            get
            {
                return this._LineInventoryInvoices;
            }
            set
            {
                this._LineInventoryInvoices.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Company_InventoryInvoice", Storage = "_Company", ThisKey = "CompanyId", OtherKey = "id", IsForeignKey = true)]
        public Company Company
        {
            get
            {
                return this._Company.Entity;
            }
            set
            {
                Company previousValue = this._Company.Entity;
                if (((previousValue != value)
                            || (this._Company.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Company.Entity = null;
                        previousValue.InventoryInvoices.Remove(this);
                    }
                    this._Company.Entity = value;
                    if ((value != null))
                    {
                        value.InventoryInvoices.Add(this);
                        this._CompanyId = value.id;
                    }
                    else
                    {
                        this._CompanyId = default(string);
                    }
                    this.SendPropertyChanged("Company");
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Store_InventoryInvoice", Storage = "_Store1", ThisKey = "store", OtherKey = "id", IsForeignKey = true)]
        public Store Store1
        {
            get
            {
                return this._Store1.Entity;
            }
            set
            {
                Store previousValue = this._Store1.Entity;
                if (((previousValue != value)
                            || (this._Store1.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Store1.Entity = null;
                        previousValue.InventoryInvoices.Remove(this);
                    }
                    this._Store1.Entity = value;
                    if ((value != null))
                    {
                        value.InventoryInvoices.Add(this);
                        this._store = value.id;
                    }
                    else
                    {
                        this._store = default(string);
                    }
                    this.SendPropertyChanged("Store1");
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Supplier_InventoryInvoice", Storage = "_Supplier", ThisKey = "account", OtherKey = "id", IsForeignKey = true)]
        public Supplier Supplier
        {
            get
            {
                return this._Supplier.Entity;
            }
            set
            {
                Supplier previousValue = this._Supplier.Entity;
                if (((previousValue != value)
                            || (this._Supplier.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Supplier.Entity = null;
                        previousValue.InventoryInvoices.Remove(this);
                    }
                    this._Supplier.Entity = value;
                    if ((value != null))
                    {
                        value.InventoryInvoices.Add(this);
                        this._account = value.id;
                    }
                    else
                    {
                        this._account = default(string);
                    }
                    this.SendPropertyChanged("Supplier");
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void attach_LineInventoryInvoices(LineInventoryInvoice entity)
        {
            this.SendPropertyChanging();
            entity.InventoryInvoice = this;
        }

        private void detach_LineInventoryInvoices(LineInventoryInvoice entity)
        {
            this.SendPropertyChanging();
            entity.InventoryInvoice = null;
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.Journal")]
    public partial class Journal : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private int _ItemID;

        private int _OID;

        private string _ItemType;

        private string _CustSupplierID;

        private string _StoreID;

        private System.DateTime _TransDate;

        private System.DateTime _ItemDate;

        private System.DateTime _EntryDate;

        private string _Periode;

        private string _Account;

        private string _OAccount;

        private decimal _Amount;

        private string _Side;

        private string _CompanyID;

        private string _CompanyIBAN;

        private string _IBAN;

        private string _Currency;

        private string _Info;

        private EntityRef<Account> _Account1;

        private EntityRef<Account> _Account2;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnItemIDChanging(int value);
        partial void OnItemIDChanged();
        partial void OnOIDChanging(int value);
        partial void OnOIDChanged();
        partial void OnItemTypeChanging(string value);
        partial void OnItemTypeChanged();
        partial void OnCustSupplierIDChanging(string value);
        partial void OnCustSupplierIDChanged();
        partial void OnStoreIDChanging(string value);
        partial void OnStoreIDChanged();
        partial void OnTransDateChanging(System.DateTime value);
        partial void OnTransDateChanged();
        partial void OnItemDateChanging(System.DateTime value);
        partial void OnItemDateChanged();
        partial void OnEntryDateChanging(System.DateTime value);
        partial void OnEntryDateChanged();
        partial void OnPeriodeChanging(string value);
        partial void OnPeriodeChanged();
        partial void OnAccountChanging(string value);
        partial void OnAccountChanged();
        partial void OnOAccountChanging(string value);
        partial void OnOAccountChanged();
        partial void OnAmountChanging(decimal value);
        partial void OnAmountChanged();
        partial void OnSideChanging(string value);
        partial void OnSideChanged();
        partial void OnCompanyIDChanging(string value);
        partial void OnCompanyIDChanged();
        partial void OnCompanyIBANChanging(string value);
        partial void OnCompanyIBANChanged();
        partial void OnIBANChanging(string value);
        partial void OnIBANChanged();
        partial void OnCurrencyChanging(string value);
        partial void OnCurrencyChanged();
        partial void OnInfoChanging(string value);
        partial void OnInfoChanged();
        #endregion

        public Journal()
        {
            this._Account1 = default(EntityRef<Account>);
            this._Account2 = default(EntityRef<Account>);
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                if ((this._ID != value))
                {
                    this.OnIDChanging(value);
                    this.SendPropertyChanging();
                    this._ID = value;
                    this.SendPropertyChanged("ID");
                    this.OnIDChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ItemID", DbType = "Int NOT NULL")]
        public int ItemID
        {
            get
            {
                return this._ItemID;
            }
            set
            {
                if ((this._ItemID != value))
                {
                    this.OnItemIDChanging(value);
                    this.SendPropertyChanging();
                    this._ItemID = value;
                    this.SendPropertyChanged("ItemID");
                    this.OnItemIDChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_OID", DbType = "Int NOT NULL")]
        public int OID
        {
            get
            {
                return this._OID;
            }
            set
            {
                if ((this._OID != value))
                {
                    this.OnOIDChanging(value);
                    this.SendPropertyChanging();
                    this._OID = value;
                    this.SendPropertyChanged("OID");
                    this.OnOIDChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ItemType", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string ItemType
        {
            get
            {
                return this._ItemType;
            }
            set
            {
                if ((this._ItemType != value))
                {
                    this.OnItemTypeChanging(value);
                    this.SendPropertyChanging();
                    this._ItemType = value;
                    this.SendPropertyChanged("ItemType");
                    this.OnItemTypeChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CustSupplierID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CustSupplierID
        {
            get
            {
                return this._CustSupplierID;
            }
            set
            {
                if ((this._CustSupplierID != value))
                {
                    this.OnCustSupplierIDChanging(value);
                    this.SendPropertyChanging();
                    this._CustSupplierID = value;
                    this.SendPropertyChanged("CustSupplierID");
                    this.OnCustSupplierIDChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_StoreID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string StoreID
        {
            get
            {
                return this._StoreID;
            }
            set
            {
                if ((this._StoreID != value))
                {
                    this.OnStoreIDChanging(value);
                    this.SendPropertyChanging();
                    this._StoreID = value;
                    this.SendPropertyChanged("StoreID");
                    this.OnStoreIDChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TransDate", DbType = "DateTime NOT NULL")]
        public System.DateTime TransDate
        {
            get
            {
                return this._TransDate;
            }
            set
            {
                if ((this._TransDate != value))
                {
                    this.OnTransDateChanging(value);
                    this.SendPropertyChanging();
                    this._TransDate = value;
                    this.SendPropertyChanged("TransDate");
                    this.OnTransDateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ItemDate", DbType = "DateTime NOT NULL")]
        public System.DateTime ItemDate
        {
            get
            {
                return this._ItemDate;
            }
            set
            {
                if ((this._ItemDate != value))
                {
                    this.OnItemDateChanging(value);
                    this.SendPropertyChanging();
                    this._ItemDate = value;
                    this.SendPropertyChanged("ItemDate");
                    this.OnItemDateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_EntryDate", DbType = "DateTime NOT NULL")]
        public System.DateTime EntryDate
        {
            get
            {
                return this._EntryDate;
            }
            set
            {
                if ((this._EntryDate != value))
                {
                    this.OnEntryDateChanging(value);
                    this.SendPropertyChanging();
                    this._EntryDate = value;
                    this.SendPropertyChanged("EntryDate");
                    this.OnEntryDateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Periode", DbType = "NChar(6) NOT NULL", CanBeNull = false)]
        public string Periode
        {
            get
            {
                return this._Periode;
            }
            set
            {
                if ((this._Periode != value))
                {
                    this.OnPeriodeChanging(value);
                    this.SendPropertyChanging();
                    this._Periode = value;
                    this.SendPropertyChanged("Periode");
                    this.OnPeriodeChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Account", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string Account
        {
            get
            {
                return this._Account;
            }
            set
            {
                if ((this._Account != value))
                {
                    if (this._Account1.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnAccountChanging(value);
                    this.SendPropertyChanging();
                    this._Account = value;
                    this.SendPropertyChanged("Account");
                    this.OnAccountChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_OAccount", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string OAccount
        {
            get
            {
                return this._OAccount;
            }
            set
            {
                if ((this._OAccount != value))
                {
                    if (this._Account2.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnOAccountChanging(value);
                    this.SendPropertyChanging();
                    this._OAccount = value;
                    this.SendPropertyChanged("OAccount");
                    this.OnOAccountChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Amount", DbType = "Money NOT NULL")]
        public decimal Amount
        {
            get
            {
                return this._Amount;
            }
            set
            {
                if ((this._Amount != value))
                {
                    this.OnAmountChanging(value);
                    this.SendPropertyChanging();
                    this._Amount = value;
                    this.SendPropertyChanged("Amount");
                    this.OnAmountChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Side", DbType = "NVarChar(6) NOT NULL", CanBeNull = false)]
        public string Side
        {
            get
            {
                return this._Side;
            }
            set
            {
                if ((this._Side != value))
                {
                    this.OnSideChanging(value);
                    this.SendPropertyChanging();
                    this._Side = value;
                    this.SendPropertyChanged("Side");
                    this.OnSideChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CompanyID
        {
            get
            {
                return this._CompanyID;
            }
            set
            {
                if ((this._CompanyID != value))
                {
                    this.OnCompanyIDChanging(value);
                    this.SendPropertyChanging();
                    this._CompanyID = value;
                    this.SendPropertyChanged("CompanyID");
                    this.OnCompanyIDChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyIBAN", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CompanyIBAN
        {
            get
            {
                return this._CompanyIBAN;
            }
            set
            {
                if ((this._CompanyIBAN != value))
                {
                    this.OnCompanyIBANChanging(value);
                    this.SendPropertyChanging();
                    this._CompanyIBAN = value;
                    this.SendPropertyChanged("CompanyIBAN");
                    this.OnCompanyIBANChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IBAN", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string IBAN
        {
            get
            {
                return this._IBAN;
            }
            set
            {
                if ((this._IBAN != value))
                {
                    this.OnIBANChanging(value);
                    this.SendPropertyChanging();
                    this._IBAN = value;
                    this.SendPropertyChanged("IBAN");
                    this.OnIBANChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Currency", DbType = "NVarChar(10) NOT NULL", CanBeNull = false)]
        public string Currency
        {
            get
            {
                return this._Currency;
            }
            set
            {
                if ((this._Currency != value))
                {
                    this.OnCurrencyChanging(value);
                    this.SendPropertyChanging();
                    this._Currency = value;
                    this.SendPropertyChanged("Currency");
                    this.OnCurrencyChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Info", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
        public string Info
        {
            get
            {
                return this._Info;
            }
            set
            {
                if ((this._Info != value))
                {
                    this.OnInfoChanging(value);
                    this.SendPropertyChanging();
                    this._Info = value;
                    this.SendPropertyChanged("Info");
                    this.OnInfoChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Account_Journal", Storage = "_Account1", ThisKey = "Account", OtherKey = "id", IsForeignKey = true)]
        public Account Account1
        {
            get
            {
                return this._Account1.Entity;
            }
            set
            {
                Account previousValue = this._Account1.Entity;
                if (((previousValue != value)
                            || (this._Account1.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Account1.Entity = null;
                        previousValue.Journals.Remove(this);
                    }
                    this._Account1.Entity = value;
                    if ((value != null))
                    {
                        value.Journals.Add(this);
                        this._Account = value.id;
                    }
                    else
                    {
                        this._Account = default(string);
                    }
                    this.SendPropertyChanged("Account1");
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Account_Journal1", Storage = "_Account2", ThisKey = "OAccount", OtherKey = "id", IsForeignKey = true)]
        public Account Account2
        {
            get
            {
                return this._Account2.Entity;
            }
            set
            {
                Account previousValue = this._Account2.Entity;
                if (((previousValue != value)
                            || (this._Account2.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Account2.Entity = null;
                        previousValue.Journals1.Remove(this);
                    }
                    this._Account2.Entity = value;
                    if ((value != null))
                    {
                        value.Journals1.Add(this);
                        this._OAccount = value.id;
                    }
                    else
                    {
                        this._OAccount = default(string);
                    }
                    this.SendPropertyChanged("Account2");
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.JournalStock")]
    public partial class JournalStock : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private int _ItemID;

        private int _OID;

        private string _ItemType;

        private string _CustSupplierID;

        private string _StoreID;

        private string _ArticleID;

        private string _ArticleName;

        private decimal _Quantity;

        private decimal _Price;

        private decimal _AvgPrice;

        private System.DateTime _TransDate;

        private string _Periode;

        private string _Account;

        private string _OAccount;

        private decimal _Amount;

        private string _Side;

        private string _CompanyID;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnItemIDChanging(int value);
        partial void OnItemIDChanged();
        partial void OnOIDChanging(int value);
        partial void OnOIDChanged();
        partial void OnItemTypeChanging(string value);
        partial void OnItemTypeChanged();
        partial void OnCustSupplierIDChanging(string value);
        partial void OnCustSupplierIDChanged();
        partial void OnStoreIDChanging(string value);
        partial void OnStoreIDChanged();
        partial void OnArticleIDChanging(string value);
        partial void OnArticleIDChanged();
        partial void OnArticleNameChanging(string value);
        partial void OnArticleNameChanged();
        partial void OnQuantityChanging(decimal value);
        partial void OnQuantityChanged();
        partial void OnPriceChanging(decimal value);
        partial void OnPriceChanged();
        partial void OnAvgPriceChanging(decimal value);
        partial void OnAvgPriceChanged();
        partial void OnTransDateChanging(System.DateTime value);
        partial void OnTransDateChanged();
        partial void OnPeriodeChanging(string value);
        partial void OnPeriodeChanged();
        partial void OnAccountChanging(string value);
        partial void OnAccountChanged();
        partial void OnOAccountChanging(string value);
        partial void OnOAccountChanged();
        partial void OnAmountChanging(decimal value);
        partial void OnAmountChanged();
        partial void OnSideChanging(string value);
        partial void OnSideChanged();
        partial void OnCompanyIDChanging(string value);
        partial void OnCompanyIDChanged();
        #endregion

        public JournalStock()
        {
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                if ((this._ID != value))
                {
                    this.OnIDChanging(value);
                    this.SendPropertyChanging();
                    this._ID = value;
                    this.SendPropertyChanged("ID");
                    this.OnIDChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ItemID", DbType = "Int NOT NULL")]
        public int ItemID
        {
            get
            {
                return this._ItemID;
            }
            set
            {
                if ((this._ItemID != value))
                {
                    this.OnItemIDChanging(value);
                    this.SendPropertyChanging();
                    this._ItemID = value;
                    this.SendPropertyChanged("ItemID");
                    this.OnItemIDChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_OID", DbType = "Int NOT NULL")]
        public int OID
        {
            get
            {
                return this._OID;
            }
            set
            {
                if ((this._OID != value))
                {
                    this.OnOIDChanging(value);
                    this.SendPropertyChanging();
                    this._OID = value;
                    this.SendPropertyChanged("OID");
                    this.OnOIDChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ItemType", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string ItemType
        {
            get
            {
                return this._ItemType;
            }
            set
            {
                if ((this._ItemType != value))
                {
                    this.OnItemTypeChanging(value);
                    this.SendPropertyChanging();
                    this._ItemType = value;
                    this.SendPropertyChanged("ItemType");
                    this.OnItemTypeChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CustSupplierID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CustSupplierID
        {
            get
            {
                return this._CustSupplierID;
            }
            set
            {
                if ((this._CustSupplierID != value))
                {
                    this.OnCustSupplierIDChanging(value);
                    this.SendPropertyChanging();
                    this._CustSupplierID = value;
                    this.SendPropertyChanged("CustSupplierID");
                    this.OnCustSupplierIDChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_StoreID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string StoreID
        {
            get
            {
                return this._StoreID;
            }
            set
            {
                if ((this._StoreID != value))
                {
                    this.OnStoreIDChanging(value);
                    this.SendPropertyChanging();
                    this._StoreID = value;
                    this.SendPropertyChanged("StoreID");
                    this.OnStoreIDChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ArticleID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string ArticleID
        {
            get
            {
                return this._ArticleID;
            }
            set
            {
                if ((this._ArticleID != value))
                {
                    this.OnArticleIDChanging(value);
                    this.SendPropertyChanging();
                    this._ArticleID = value;
                    this.SendPropertyChanged("ArticleID");
                    this.OnArticleIDChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ArticleName", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string ArticleName
        {
            get
            {
                return this._ArticleName;
            }
            set
            {
                if ((this._ArticleName != value))
                {
                    this.OnArticleNameChanging(value);
                    this.SendPropertyChanging();
                    this._ArticleName = value;
                    this.SendPropertyChanged("ArticleName");
                    this.OnArticleNameChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Quantity", DbType = "Decimal(16,2) NOT NULL")]
        public decimal Quantity
        {
            get
            {
                return this._Quantity;
            }
            set
            {
                if ((this._Quantity != value))
                {
                    this.OnQuantityChanging(value);
                    this.SendPropertyChanging();
                    this._Quantity = value;
                    this.SendPropertyChanged("Quantity");
                    this.OnQuantityChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Price", DbType = "Decimal(16,2) NOT NULL")]
        public decimal Price
        {
            get
            {
                return this._Price;
            }
            set
            {
                if ((this._Price != value))
                {
                    this.OnPriceChanging(value);
                    this.SendPropertyChanging();
                    this._Price = value;
                    this.SendPropertyChanged("Price");
                    this.OnPriceChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_AvgPrice", DbType = "Decimal(16,2) NOT NULL")]
        public decimal AvgPrice
        {
            get
            {
                return this._AvgPrice;
            }
            set
            {
                if ((this._AvgPrice != value))
                {
                    this.OnAvgPriceChanging(value);
                    this.SendPropertyChanging();
                    this._AvgPrice = value;
                    this.SendPropertyChanged("AvgPrice");
                    this.OnAvgPriceChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TransDate", DbType = "DateTime NOT NULL")]
        public System.DateTime TransDate
        {
            get
            {
                return this._TransDate;
            }
            set
            {
                if ((this._TransDate != value))
                {
                    this.OnTransDateChanging(value);
                    this.SendPropertyChanging();
                    this._TransDate = value;
                    this.SendPropertyChanged("TransDate");
                    this.OnTransDateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Periode", DbType = "NChar(6) NOT NULL", CanBeNull = false)]
        public string Periode
        {
            get
            {
                return this._Periode;
            }
            set
            {
                if ((this._Periode != value))
                {
                    this.OnPeriodeChanging(value);
                    this.SendPropertyChanging();
                    this._Periode = value;
                    this.SendPropertyChanged("Periode");
                    this.OnPeriodeChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Account", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string Account
        {
            get
            {
                return this._Account;
            }
            set
            {
                if ((this._Account != value))
                {
                    this.OnAccountChanging(value);
                    this.SendPropertyChanging();
                    this._Account = value;
                    this.SendPropertyChanged("Account");
                    this.OnAccountChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_OAccount", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string OAccount
        {
            get
            {
                return this._OAccount;
            }
            set
            {
                if ((this._OAccount != value))
                {
                    this.OnOAccountChanging(value);
                    this.SendPropertyChanging();
                    this._OAccount = value;
                    this.SendPropertyChanged("OAccount");
                    this.OnOAccountChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Amount", DbType = "Decimal(16,2) NOT NULL")]
        public decimal Amount
        {
            get
            {
                return this._Amount;
            }
            set
            {
                if ((this._Amount != value))
                {
                    this.OnAmountChanging(value);
                    this.SendPropertyChanging();
                    this._Amount = value;
                    this.SendPropertyChanged("Amount");
                    this.OnAmountChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Side", DbType = "NVarChar(6) NOT NULL", CanBeNull = false)]
        public string Side
        {
            get
            {
                return this._Side;
            }
            set
            {
                if ((this._Side != value))
                {
                    this.OnSideChanging(value);
                    this.SendPropertyChanging();
                    this._Side = value;
                    this.SendPropertyChanged("Side");
                    this.OnSideChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CompanyID
        {
            get
            {
                return this._CompanyID;
            }
            set
            {
                if ((this._CompanyID != value))
                {
                    this.OnCompanyIDChanging(value);
                    this.SendPropertyChanging();
                    this._CompanyID = value;
                    this.SendPropertyChanged("CompanyID");
                    this.OnCompanyIDChanged();
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.LineBillOfDelivery")]
    public partial class LineBillOfDelivery : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _id;

        private int _transid;

        private string _item;

        private string _unit;

        private decimal _price;

        private decimal _quantity;

        private decimal _Vat;

        private System.DateTime _duedate;

        private string _text;

        private System.Nullable<decimal> _lineNet;

        private System.Nullable<decimal> _lineVAT;

        private string _Currency;

        private EntityRef<Article> _Article;

        private EntityRef<BillOfDelivery> _BillOfDelivery;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnidChanging(int value);
        partial void OnidChanged();
        partial void OntransidChanging(int value);
        partial void OntransidChanged();
        partial void OnitemChanging(string value);
        partial void OnitemChanged();
        partial void OnunitChanging(string value);
        partial void OnunitChanged();
        partial void OnpriceChanging(decimal value);
        partial void OnpriceChanged();
        partial void OnquantityChanging(decimal value);
        partial void OnquantityChanged();
        partial void OnVatChanging(decimal value);
        partial void OnVatChanged();
        partial void OnduedateChanging(System.DateTime value);
        partial void OnduedateChanged();
        partial void OntextChanging(string value);
        partial void OntextChanged();
        partial void OnlineNetChanging(System.Nullable<decimal> value);
        partial void OnlineNetChanged();
        partial void OnlineVATChanging(System.Nullable<decimal> value);
        partial void OnlineVATChanged();
        partial void OnCurrencyChanging(string value);
        partial void OnCurrencyChanged();
        #endregion

        public LineBillOfDelivery()
        {
            this._Article = default(EntityRef<Article>);
            this._BillOfDelivery = default(EntityRef<BillOfDelivery>);
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    this.OnidChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("id");
                    this.OnidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_transid", DbType = "Int NOT NULL")]
        public int transid
        {
            get
            {
                return this._transid;
            }
            set
            {
                if ((this._transid != value))
                {
                    if (this._BillOfDelivery.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OntransidChanging(value);
                    this.SendPropertyChanging();
                    this._transid = value;
                    this.SendPropertyChanged("transid");
                    this.OntransidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_item", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string item
        {
            get
            {
                return this._item;
            }
            set
            {
                if ((this._item != value))
                {
                    if (this._Article.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnitemChanging(value);
                    this.SendPropertyChanging();
                    this._item = value;
                    this.SendPropertyChanged("item");
                    this.OnitemChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_unit", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
        public string unit
        {
            get
            {
                return this._unit;
            }
            set
            {
                if ((this._unit != value))
                {
                    this.OnunitChanging(value);
                    this.SendPropertyChanging();
                    this._unit = value;
                    this.SendPropertyChanged("unit");
                    this.OnunitChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_price", DbType = "Money NOT NULL")]
        public decimal price
        {
            get
            {
                return this._price;
            }
            set
            {
                if ((this._price != value))
                {
                    this.OnpriceChanging(value);
                    this.SendPropertyChanging();
                    this._price = value;
                    this.SendPropertyChanged("price");
                    this.OnpriceChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_quantity", DbType = "Decimal(10,2) NOT NULL")]
        public decimal quantity
        {
            get
            {
                return this._quantity;
            }
            set
            {
                if ((this._quantity != value))
                {
                    this.OnquantityChanging(value);
                    this.SendPropertyChanging();
                    this._quantity = value;
                    this.SendPropertyChanged("quantity");
                    this.OnquantityChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Vat", DbType = "Decimal(16,2) NOT NULL")]
        public decimal Vat
        {
            get
            {
                return this._Vat;
            }
            set
            {
                if ((this._Vat != value))
                {
                    this.OnVatChanging(value);
                    this.SendPropertyChanging();
                    this._Vat = value;
                    this.SendPropertyChanged("Vat");
                    this.OnVatChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_duedate", DbType = "DateTime2 NOT NULL")]
        public System.DateTime duedate
        {
            get
            {
                return this._duedate;
            }
            set
            {
                if ((this._duedate != value))
                {
                    this.OnduedateChanging(value);
                    this.SendPropertyChanging();
                    this._duedate = value;
                    this.SendPropertyChanged("duedate");
                    this.OnduedateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_text", DbType = "NVarChar(50)")]
        public string text
        {
            get
            {
                return this._text;
            }
            set
            {
                if ((this._text != value))
                {
                    this.OntextChanging(value);
                    this.SendPropertyChanging();
                    this._text = value;
                    this.SendPropertyChanged("text");
                    this.OntextChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_lineNet", AutoSync = AutoSync.Always, DbType = "Money", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<decimal> lineNet
        {
            get
            {
                return this._lineNet;
            }
            set
            {
                if ((this._lineNet != value))
                {
                    this.OnlineNetChanging(value);
                    this.SendPropertyChanging();
                    this._lineNet = value;
                    this.SendPropertyChanged("lineNet");
                    this.OnlineNetChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_lineVAT", AutoSync = AutoSync.Always, DbType = "Money", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<decimal> lineVAT
        {
            get
            {
                return this._lineVAT;
            }
            set
            {
                if ((this._lineVAT != value))
                {
                    this.OnlineVATChanging(value);
                    this.SendPropertyChanging();
                    this._lineVAT = value;
                    this.SendPropertyChanged("lineVAT");
                    this.OnlineVATChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Currency", DbType = "NVarChar(10) NOT NULL", CanBeNull = false)]
        public string Currency
        {
            get
            {
                return this._Currency;
            }
            set
            {
                if ((this._Currency != value))
                {
                    this.OnCurrencyChanging(value);
                    this.SendPropertyChanging();
                    this._Currency = value;
                    this.SendPropertyChanged("Currency");
                    this.OnCurrencyChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Article_LineBillOfDelivery", Storage = "_Article", ThisKey = "item", OtherKey = "id", IsForeignKey = true)]
        public Article Article
        {
            get
            {
                return this._Article.Entity;
            }
            set
            {
                Article previousValue = this._Article.Entity;
                if (((previousValue != value)
                            || (this._Article.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Article.Entity = null;
                        previousValue.LineBillOfDeliveries.Remove(this);
                    }
                    this._Article.Entity = value;
                    if ((value != null))
                    {
                        value.LineBillOfDeliveries.Add(this);
                        this._item = value.id;
                    }
                    else
                    {
                        this._item = default(string);
                    }
                    this.SendPropertyChanged("Article");
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "BillOfDelivery_LineBillOfDelivery", Storage = "_BillOfDelivery", ThisKey = "transid", OtherKey = "id", IsForeignKey = true)]
        public BillOfDelivery BillOfDelivery
        {
            get
            {
                return this._BillOfDelivery.Entity;
            }
            set
            {
                BillOfDelivery previousValue = this._BillOfDelivery.Entity;
                if (((previousValue != value)
                            || (this._BillOfDelivery.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._BillOfDelivery.Entity = null;
                        previousValue.LineBillOfDeliveries.Remove(this);
                    }
                    this._BillOfDelivery.Entity = value;
                    if ((value != null))
                    {
                        value.LineBillOfDeliveries.Add(this);
                        this._transid = value.id;
                    }
                    else
                    {
                        this._transid = default(int);
                    }
                    this.SendPropertyChanged("BillOfDelivery");
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.LineCustomerInvoice")]
    public partial class LineCustomerInvoice : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _id;

        private int _transid;

        private string _account;

        private bool _side;

        private string _oaccount;

        private decimal _amount;

        private System.DateTime _duedate;

        private string _text;

        private string _Currency;

        private EntityRef<CustomerInvoice> _CustomerInvoice;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnidChanging(int value);
        partial void OnidChanged();
        partial void OntransidChanging(int value);
        partial void OntransidChanged();
        partial void OnaccountChanging(string value);
        partial void OnaccountChanged();
        partial void OnsideChanging(bool value);
        partial void OnsideChanged();
        partial void OnoaccountChanging(string value);
        partial void OnoaccountChanged();
        partial void OnamountChanging(decimal value);
        partial void OnamountChanged();
        partial void OnduedateChanging(System.DateTime value);
        partial void OnduedateChanged();
        partial void OntextChanging(string value);
        partial void OntextChanged();
        partial void OnCurrencyChanging(string value);
        partial void OnCurrencyChanged();
        #endregion

        public LineCustomerInvoice()
        {
            this._CustomerInvoice = default(EntityRef<CustomerInvoice>);
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    this.OnidChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("id");
                    this.OnidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_transid", DbType = "Int NOT NULL")]
        public int transid
        {
            get
            {
                return this._transid;
            }
            set
            {
                if ((this._transid != value))
                {
                    if (this._CustomerInvoice.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OntransidChanging(value);
                    this.SendPropertyChanging();
                    this._transid = value;
                    this.SendPropertyChanged("transid");
                    this.OntransidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_account", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string account
        {
            get
            {
                return this._account;
            }
            set
            {
                if ((this._account != value))
                {
                    this.OnaccountChanging(value);
                    this.SendPropertyChanging();
                    this._account = value;
                    this.SendPropertyChanged("account");
                    this.OnaccountChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_side", DbType = "Bit NOT NULL")]
        public bool side
        {
            get
            {
                return this._side;
            }
            set
            {
                if ((this._side != value))
                {
                    this.OnsideChanging(value);
                    this.SendPropertyChanging();
                    this._side = value;
                    this.SendPropertyChanged("side");
                    this.OnsideChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oaccount", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string oaccount
        {
            get
            {
                return this._oaccount;
            }
            set
            {
                if ((this._oaccount != value))
                {
                    this.OnoaccountChanging(value);
                    this.SendPropertyChanging();
                    this._oaccount = value;
                    this.SendPropertyChanged("oaccount");
                    this.OnoaccountChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_amount", DbType = "Money NOT NULL")]
        public decimal amount
        {
            get
            {
                return this._amount;
            }
            set
            {
                if ((this._amount != value))
                {
                    this.OnamountChanging(value);
                    this.SendPropertyChanging();
                    this._amount = value;
                    this.SendPropertyChanged("amount");
                    this.OnamountChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_duedate", DbType = "DateTime2 NOT NULL")]
        public System.DateTime duedate
        {
            get
            {
                return this._duedate;
            }
            set
            {
                if ((this._duedate != value))
                {
                    this.OnduedateChanging(value);
                    this.SendPropertyChanging();
                    this._duedate = value;
                    this.SendPropertyChanged("duedate");
                    this.OnduedateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_text", DbType = "NVarChar(50)")]
        public string text
        {
            get
            {
                return this._text;
            }
            set
            {
                if ((this._text != value))
                {
                    this.OntextChanging(value);
                    this.SendPropertyChanging();
                    this._text = value;
                    this.SendPropertyChanged("text");
                    this.OntextChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Currency", DbType = "NVarChar(10) NOT NULL", CanBeNull = false)]
        public string Currency
        {
            get
            {
                return this._Currency;
            }
            set
            {
                if ((this._Currency != value))
                {
                    this.OnCurrencyChanging(value);
                    this.SendPropertyChanging();
                    this._Currency = value;
                    this.SendPropertyChanged("Currency");
                    this.OnCurrencyChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "CustomerInvoice_LineCustomerInvoice", Storage = "_CustomerInvoice", ThisKey = "transid", OtherKey = "id", IsForeignKey = true)]
        public CustomerInvoice CustomerInvoice
        {
            get
            {
                return this._CustomerInvoice.Entity;
            }
            set
            {
                CustomerInvoice previousValue = this._CustomerInvoice.Entity;
                if (((previousValue != value)
                            || (this._CustomerInvoice.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._CustomerInvoice.Entity = null;
                        previousValue.LineCustomerInvoices.Remove(this);
                    }
                    this._CustomerInvoice.Entity = value;
                    if ((value != null))
                    {
                        value.LineCustomerInvoices.Add(this);
                        this._transid = value.id;
                    }
                    else
                    {
                        this._transid = default(int);
                    }
                    this.SendPropertyChanged("CustomerInvoice");
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.LineGeneralLedger")]
    public partial class LineGeneralLedger : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _id;

        private int _transid;

        private string _account;

        private bool _side;

        private string _oaccount;

        private decimal _amount;

        private System.DateTime _duedate;

        private string _text;

        private string _Currency;

        private EntityRef<GeneralLedger> _GeneralLedger;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnidChanging(int value);
        partial void OnidChanged();
        partial void OntransidChanging(int value);
        partial void OntransidChanged();
        partial void OnaccountChanging(string value);
        partial void OnaccountChanged();
        partial void OnsideChanging(bool value);
        partial void OnsideChanged();
        partial void OnoaccountChanging(string value);
        partial void OnoaccountChanged();
        partial void OnamountChanging(decimal value);
        partial void OnamountChanged();
        partial void OnduedateChanging(System.DateTime value);
        partial void OnduedateChanged();
        partial void OntextChanging(string value);
        partial void OntextChanged();
        partial void OnCurrencyChanging(string value);
        partial void OnCurrencyChanged();
        #endregion

        public LineGeneralLedger()
        {
            this._GeneralLedger = default(EntityRef<GeneralLedger>);
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    this.OnidChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("id");
                    this.OnidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_transid", DbType = "Int NOT NULL")]
        public int transid
        {
            get
            {
                return this._transid;
            }
            set
            {
                if ((this._transid != value))
                {
                    if (this._GeneralLedger.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OntransidChanging(value);
                    this.SendPropertyChanging();
                    this._transid = value;
                    this.SendPropertyChanged("transid");
                    this.OntransidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_account", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string account
        {
            get
            {
                return this._account;
            }
            set
            {
                if ((this._account != value))
                {
                    this.OnaccountChanging(value);
                    this.SendPropertyChanging();
                    this._account = value;
                    this.SendPropertyChanged("account");
                    this.OnaccountChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_side", DbType = "Bit NOT NULL")]
        public bool side
        {
            get
            {
                return this._side;
            }
            set
            {
                if ((this._side != value))
                {
                    this.OnsideChanging(value);
                    this.SendPropertyChanging();
                    this._side = value;
                    this.SendPropertyChanged("side");
                    this.OnsideChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oaccount", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string oaccount
        {
            get
            {
                return this._oaccount;
            }
            set
            {
                if ((this._oaccount != value))
                {
                    this.OnoaccountChanging(value);
                    this.SendPropertyChanging();
                    this._oaccount = value;
                    this.SendPropertyChanged("oaccount");
                    this.OnoaccountChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_amount", DbType = "Money NOT NULL")]
        public decimal amount
        {
            get
            {
                return this._amount;
            }
            set
            {
                if ((this._amount != value))
                {
                    this.OnamountChanging(value);
                    this.SendPropertyChanging();
                    this._amount = value;
                    this.SendPropertyChanged("amount");
                    this.OnamountChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_duedate", DbType = "DateTime2 NOT NULL")]
        public System.DateTime duedate
        {
            get
            {
                return this._duedate;
            }
            set
            {
                if ((this._duedate != value))
                {
                    this.OnduedateChanging(value);
                    this.SendPropertyChanging();
                    this._duedate = value;
                    this.SendPropertyChanged("duedate");
                    this.OnduedateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_text", DbType = "NVarChar(50)")]
        public string text
        {
            get
            {
                return this._text;
            }
            set
            {
                if ((this._text != value))
                {
                    this.OntextChanging(value);
                    this.SendPropertyChanging();
                    this._text = value;
                    this.SendPropertyChanged("text");
                    this.OntextChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Currency", DbType = "NVarChar(10) NOT NULL", CanBeNull = false)]
        public string Currency
        {
            get
            {
                return this._Currency;
            }
            set
            {
                if ((this._Currency != value))
                {
                    this.OnCurrencyChanging(value);
                    this.SendPropertyChanging();
                    this._Currency = value;
                    this.SendPropertyChanged("Currency");
                    this.OnCurrencyChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "GeneralLedger_LineGeneralLedger", Storage = "_GeneralLedger", ThisKey = "transid", OtherKey = "id", IsForeignKey = true)]
        public GeneralLedger GeneralLedger
        {
            get
            {
                return this._GeneralLedger.Entity;
            }
            set
            {
                GeneralLedger previousValue = this._GeneralLedger.Entity;
                if (((previousValue != value)
                            || (this._GeneralLedger.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._GeneralLedger.Entity = null;
                        previousValue.LineGeneralLedgers.Remove(this);
                    }
                    this._GeneralLedger.Entity = value;
                    if ((value != null))
                    {
                        value.LineGeneralLedgers.Add(this);
                        this._transid = value.id;
                    }
                    else
                    {
                        this._transid = default(int);
                    }
                    this.SendPropertyChanged("GeneralLedger");
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.LineGoodReceiving")]
    public partial class LineGoodReceiving : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _id;

        private int _transid;

        private string _item;

        private string _unit;

        private decimal _price;

        private decimal _quantity;

        private decimal _Vat;

        private System.DateTime _duedate;

        private string _text;

        private System.Nullable<decimal> _lineNet;

        private System.Nullable<decimal> _lineVAT;

        private string _Currency;

        private EntityRef<Article> _Article;

        private EntityRef<GoodReceiving> _GoodReceiving;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnidChanging(int value);
        partial void OnidChanged();
        partial void OntransidChanging(int value);
        partial void OntransidChanged();
        partial void OnitemChanging(string value);
        partial void OnitemChanged();
        partial void OnunitChanging(string value);
        partial void OnunitChanged();
        partial void OnpriceChanging(decimal value);
        partial void OnpriceChanged();
        partial void OnquantityChanging(decimal value);
        partial void OnquantityChanged();
        partial void OnVatChanging(decimal value);
        partial void OnVatChanged();
        partial void OnduedateChanging(System.DateTime value);
        partial void OnduedateChanged();
        partial void OntextChanging(string value);
        partial void OntextChanged();
        partial void OnlineNetChanging(System.Nullable<decimal> value);
        partial void OnlineNetChanged();
        partial void OnlineVATChanging(System.Nullable<decimal> value);
        partial void OnlineVATChanged();
        partial void OnCurrencyChanging(string value);
        partial void OnCurrencyChanged();
        #endregion

        public LineGoodReceiving()
        {
            this._Article = default(EntityRef<Article>);
            this._GoodReceiving = default(EntityRef<GoodReceiving>);
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    this.OnidChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("id");
                    this.OnidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_transid", DbType = "Int NOT NULL")]
        public int transid
        {
            get
            {
                return this._transid;
            }
            set
            {
                if ((this._transid != value))
                {
                    if (this._GoodReceiving.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OntransidChanging(value);
                    this.SendPropertyChanging();
                    this._transid = value;
                    this.SendPropertyChanged("transid");
                    this.OntransidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_item", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string item
        {
            get
            {
                return this._item;
            }
            set
            {
                if ((this._item != value))
                {
                    if (this._Article.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnitemChanging(value);
                    this.SendPropertyChanging();
                    this._item = value;
                    this.SendPropertyChanged("item");
                    this.OnitemChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_unit", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
        public string unit
        {
            get
            {
                return this._unit;
            }
            set
            {
                if ((this._unit != value))
                {
                    this.OnunitChanging(value);
                    this.SendPropertyChanging();
                    this._unit = value;
                    this.SendPropertyChanged("unit");
                    this.OnunitChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_price", DbType = "Money NOT NULL")]
        public decimal price
        {
            get
            {
                return this._price;
            }
            set
            {
                if ((this._price != value))
                {
                    this.OnpriceChanging(value);
                    this.SendPropertyChanging();
                    this._price = value;
                    this.SendPropertyChanged("price");
                    this.OnpriceChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_quantity", DbType = "Decimal(10,2) NOT NULL")]
        public decimal quantity
        {
            get
            {
                return this._quantity;
            }
            set
            {
                if ((this._quantity != value))
                {
                    this.OnquantityChanging(value);
                    this.SendPropertyChanging();
                    this._quantity = value;
                    this.SendPropertyChanged("quantity");
                    this.OnquantityChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Vat", DbType = "Decimal(16,2) NOT NULL")]
        public decimal Vat
        {
            get
            {
                return this._Vat;
            }
            set
            {
                if ((this._Vat != value))
                {
                    this.OnVatChanging(value);
                    this.SendPropertyChanging();
                    this._Vat = value;
                    this.SendPropertyChanged("Vat");
                    this.OnVatChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_duedate", DbType = "DateTime2 NOT NULL")]
        public System.DateTime duedate
        {
            get
            {
                return this._duedate;
            }
            set
            {
                if ((this._duedate != value))
                {
                    this.OnduedateChanging(value);
                    this.SendPropertyChanging();
                    this._duedate = value;
                    this.SendPropertyChanged("duedate");
                    this.OnduedateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_text", DbType = "NVarChar(50)")]
        public string text
        {
            get
            {
                return this._text;
            }
            set
            {
                if ((this._text != value))
                {
                    this.OntextChanging(value);
                    this.SendPropertyChanging();
                    this._text = value;
                    this.SendPropertyChanged("text");
                    this.OntextChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_lineNet", AutoSync = AutoSync.Always, DbType = "Money", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<decimal> lineNet
        {
            get
            {
                return this._lineNet;
            }
            set
            {
                if ((this._lineNet != value))
                {
                    this.OnlineNetChanging(value);
                    this.SendPropertyChanging();
                    this._lineNet = value;
                    this.SendPropertyChanged("lineNet");
                    this.OnlineNetChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_lineVAT", AutoSync = AutoSync.Always, DbType = "Money", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<decimal> lineVAT
        {
            get
            {
                return this._lineVAT;
            }
            set
            {
                if ((this._lineVAT != value))
                {
                    this.OnlineVATChanging(value);
                    this.SendPropertyChanging();
                    this._lineVAT = value;
                    this.SendPropertyChanged("lineVAT");
                    this.OnlineVATChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Currency", DbType = "NVarChar(10) NOT NULL", CanBeNull = false)]
        public string Currency
        {
            get
            {
                return this._Currency;
            }
            set
            {
                if ((this._Currency != value))
                {
                    this.OnCurrencyChanging(value);
                    this.SendPropertyChanging();
                    this._Currency = value;
                    this.SendPropertyChanged("Currency");
                    this.OnCurrencyChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Article_LineGoodReceiving", Storage = "_Article", ThisKey = "item", OtherKey = "id", IsForeignKey = true)]
        public Article Article
        {
            get
            {
                return this._Article.Entity;
            }
            set
            {
                Article previousValue = this._Article.Entity;
                if (((previousValue != value)
                            || (this._Article.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Article.Entity = null;
                        previousValue.LineGoodReceivings.Remove(this);
                    }
                    this._Article.Entity = value;
                    if ((value != null))
                    {
                        value.LineGoodReceivings.Add(this);
                        this._item = value.id;
                    }
                    else
                    {
                        this._item = default(string);
                    }
                    this.SendPropertyChanged("Article");
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "GoodReceiving_LineGoodReceiving", Storage = "_GoodReceiving", ThisKey = "transid", OtherKey = "id", IsForeignKey = true)]
        public GoodReceiving GoodReceiving
        {
            get
            {
                return this._GoodReceiving.Entity;
            }
            set
            {
                GoodReceiving previousValue = this._GoodReceiving.Entity;
                if (((previousValue != value)
                            || (this._GoodReceiving.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._GoodReceiving.Entity = null;
                        previousValue.LineGoodReceivings.Remove(this);
                    }
                    this._GoodReceiving.Entity = value;
                    if ((value != null))
                    {
                        value.LineGoodReceivings.Add(this);
                        this._transid = value.id;
                    }
                    else
                    {
                        this._transid = default(int);
                    }
                    this.SendPropertyChanged("GoodReceiving");
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.LineInventoryInvoice")]
    public partial class LineInventoryInvoice : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _id;

        private int _transid;

        private string _item;

        private string _unit;

        private decimal _price;

        private decimal _quantity;

        private decimal _Vat;

        private System.DateTime _duedate;

        private string _text;

        private System.Nullable<decimal> _lineNet;

        private System.Nullable<decimal> _lineVAT;

        private string _Currency;

        private EntityRef<Article> _Article;

        private EntityRef<InventoryInvoice> _InventoryInvoice;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnidChanging(int value);
        partial void OnidChanged();
        partial void OntransidChanging(int value);
        partial void OntransidChanged();
        partial void OnitemChanging(string value);
        partial void OnitemChanged();
        partial void OnunitChanging(string value);
        partial void OnunitChanged();
        partial void OnpriceChanging(decimal value);
        partial void OnpriceChanged();
        partial void OnquantityChanging(decimal value);
        partial void OnquantityChanged();
        partial void OnVatChanging(decimal value);
        partial void OnVatChanged();
        partial void OnduedateChanging(System.DateTime value);
        partial void OnduedateChanged();
        partial void OntextChanging(string value);
        partial void OntextChanged();
        partial void OnlineNetChanging(System.Nullable<decimal> value);
        partial void OnlineNetChanged();
        partial void OnlineVATChanging(System.Nullable<decimal> value);
        partial void OnlineVATChanged();
        partial void OnCurrencyChanging(string value);
        partial void OnCurrencyChanged();
        #endregion

        public LineInventoryInvoice()
        {
            this._Article = default(EntityRef<Article>);
            this._InventoryInvoice = default(EntityRef<InventoryInvoice>);
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    this.OnidChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("id");
                    this.OnidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_transid", DbType = "Int NOT NULL")]
        public int transid
        {
            get
            {
                return this._transid;
            }
            set
            {
                if ((this._transid != value))
                {
                    if (this._InventoryInvoice.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OntransidChanging(value);
                    this.SendPropertyChanging();
                    this._transid = value;
                    this.SendPropertyChanged("transid");
                    this.OntransidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_item", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string item
        {
            get
            {
                return this._item;
            }
            set
            {
                if ((this._item != value))
                {
                    if (this._Article.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnitemChanging(value);
                    this.SendPropertyChanging();
                    this._item = value;
                    this.SendPropertyChanged("item");
                    this.OnitemChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_unit", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string unit
        {
            get
            {
                return this._unit;
            }
            set
            {
                if ((this._unit != value))
                {
                    this.OnunitChanging(value);
                    this.SendPropertyChanging();
                    this._unit = value;
                    this.SendPropertyChanged("unit");
                    this.OnunitChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_price", DbType = "Money NOT NULL")]
        public decimal price
        {
            get
            {
                return this._price;
            }
            set
            {
                if ((this._price != value))
                {
                    this.OnpriceChanging(value);
                    this.SendPropertyChanging();
                    this._price = value;
                    this.SendPropertyChanged("price");
                    this.OnpriceChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_quantity", DbType = "Decimal(10,2) NOT NULL")]
        public decimal quantity
        {
            get
            {
                return this._quantity;
            }
            set
            {
                if ((this._quantity != value))
                {
                    this.OnquantityChanging(value);
                    this.SendPropertyChanging();
                    this._quantity = value;
                    this.SendPropertyChanged("quantity");
                    this.OnquantityChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Vat", DbType = "Decimal(16,2) NOT NULL")]
        public decimal Vat
        {
            get
            {
                return this._Vat;
            }
            set
            {
                if ((this._Vat != value))
                {
                    this.OnVatChanging(value);
                    this.SendPropertyChanging();
                    this._Vat = value;
                    this.SendPropertyChanged("Vat");
                    this.OnVatChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_duedate", DbType = "DateTime2 NOT NULL")]
        public System.DateTime duedate
        {
            get
            {
                return this._duedate;
            }
            set
            {
                if ((this._duedate != value))
                {
                    this.OnduedateChanging(value);
                    this.SendPropertyChanging();
                    this._duedate = value;
                    this.SendPropertyChanged("duedate");
                    this.OnduedateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_text", DbType = "NVarChar(50)")]
        public string text
        {
            get
            {
                return this._text;
            }
            set
            {
                if ((this._text != value))
                {
                    this.OntextChanging(value);
                    this.SendPropertyChanging();
                    this._text = value;
                    this.SendPropertyChanged("text");
                    this.OntextChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_lineNet", AutoSync = AutoSync.Always, DbType = "Money", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<decimal> lineNet
        {
            get
            {
                return this._lineNet;
            }
            set
            {
                if ((this._lineNet != value))
                {
                    this.OnlineNetChanging(value);
                    this.SendPropertyChanging();
                    this._lineNet = value;
                    this.SendPropertyChanged("lineNet");
                    this.OnlineNetChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_lineVAT", AutoSync = AutoSync.Always, DbType = "Money", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<decimal> lineVAT
        {
            get
            {
                return this._lineVAT;
            }
            set
            {
                if ((this._lineVAT != value))
                {
                    this.OnlineVATChanging(value);
                    this.SendPropertyChanging();
                    this._lineVAT = value;
                    this.SendPropertyChanged("lineVAT");
                    this.OnlineVATChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Currency", DbType = "NVarChar(10) NOT NULL", CanBeNull = false)]
        public string Currency
        {
            get
            {
                return this._Currency;
            }
            set
            {
                if ((this._Currency != value))
                {
                    this.OnCurrencyChanging(value);
                    this.SendPropertyChanging();
                    this._Currency = value;
                    this.SendPropertyChanged("Currency");
                    this.OnCurrencyChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Article_LineInventoryInvoice", Storage = "_Article", ThisKey = "item", OtherKey = "id", IsForeignKey = true)]
        public Article Article
        {
            get
            {
                return this._Article.Entity;
            }
            set
            {
                Article previousValue = this._Article.Entity;
                if (((previousValue != value)
                            || (this._Article.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Article.Entity = null;
                        previousValue.LineInventoryInvoices.Remove(this);
                    }
                    this._Article.Entity = value;
                    if ((value != null))
                    {
                        value.LineInventoryInvoices.Add(this);
                        this._item = value.id;
                    }
                    else
                    {
                        this._item = default(string);
                    }
                    this.SendPropertyChanged("Article");
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "InventoryInvoice_LineInventoryInvoice", Storage = "_InventoryInvoice", ThisKey = "transid", OtherKey = "id", IsForeignKey = true)]
        public InventoryInvoice InventoryInvoice
        {
            get
            {
                return this._InventoryInvoice.Entity;
            }
            set
            {
                InventoryInvoice previousValue = this._InventoryInvoice.Entity;
                if (((previousValue != value)
                            || (this._InventoryInvoice.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._InventoryInvoice.Entity = null;
                        previousValue.LineInventoryInvoices.Remove(this);
                    }
                    this._InventoryInvoice.Entity = value;
                    if ((value != null))
                    {
                        value.LineInventoryInvoices.Add(this);
                        this._transid = value.id;
                    }
                    else
                    {
                        this._transid = default(int);
                    }
                    this.SendPropertyChanged("InventoryInvoice");
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.LinePayment")]
    public partial class LinePayment : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _id;

        private int _transid;

        private string _account;

        private bool _side;

        private string _oaccount;

        private decimal _amount;

        private System.DateTime _duedate;

        private string _text;

        private string _Currency;

        private EntityRef<Payment> _Payment;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnidChanging(int value);
        partial void OnidChanged();
        partial void OntransidChanging(int value);
        partial void OntransidChanged();
        partial void OnaccountChanging(string value);
        partial void OnaccountChanged();
        partial void OnsideChanging(bool value);
        partial void OnsideChanged();
        partial void OnoaccountChanging(string value);
        partial void OnoaccountChanged();
        partial void OnamountChanging(decimal value);
        partial void OnamountChanged();
        partial void OnduedateChanging(System.DateTime value);
        partial void OnduedateChanged();
        partial void OntextChanging(string value);
        partial void OntextChanged();
        partial void OnCurrencyChanging(string value);
        partial void OnCurrencyChanged();
        #endregion

        public LinePayment()
        {
            this._Payment = default(EntityRef<Payment>);
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    this.OnidChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("id");
                    this.OnidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_transid", DbType = "Int NOT NULL")]
        public int transid
        {
            get
            {
                return this._transid;
            }
            set
            {
                if ((this._transid != value))
                {
                    if (this._Payment.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OntransidChanging(value);
                    this.SendPropertyChanging();
                    this._transid = value;
                    this.SendPropertyChanged("transid");
                    this.OntransidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_account", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string account
        {
            get
            {
                return this._account;
            }
            set
            {
                if ((this._account != value))
                {
                    this.OnaccountChanging(value);
                    this.SendPropertyChanging();
                    this._account = value;
                    this.SendPropertyChanged("account");
                    this.OnaccountChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_side", DbType = "Bit NOT NULL")]
        public bool side
        {
            get
            {
                return this._side;
            }
            set
            {
                if ((this._side != value))
                {
                    this.OnsideChanging(value);
                    this.SendPropertyChanging();
                    this._side = value;
                    this.SendPropertyChanged("side");
                    this.OnsideChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oaccount", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string oaccount
        {
            get
            {
                return this._oaccount;
            }
            set
            {
                if ((this._oaccount != value))
                {
                    this.OnoaccountChanging(value);
                    this.SendPropertyChanging();
                    this._oaccount = value;
                    this.SendPropertyChanged("oaccount");
                    this.OnoaccountChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_amount", DbType = "Money NOT NULL")]
        public decimal amount
        {
            get
            {
                return this._amount;
            }
            set
            {
                if ((this._amount != value))
                {
                    this.OnamountChanging(value);
                    this.SendPropertyChanging();
                    this._amount = value;
                    this.SendPropertyChanged("amount");
                    this.OnamountChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_duedate", DbType = "DateTime2 NOT NULL")]
        public System.DateTime duedate
        {
            get
            {
                return this._duedate;
            }
            set
            {
                if ((this._duedate != value))
                {
                    this.OnduedateChanging(value);
                    this.SendPropertyChanging();
                    this._duedate = value;
                    this.SendPropertyChanged("duedate");
                    this.OnduedateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_text", DbType = "NVarChar(250)")]
        public string text
        {
            get
            {
                return this._text;
            }
            set
            {
                if ((this._text != value))
                {
                    this.OntextChanging(value);
                    this.SendPropertyChanging();
                    this._text = value;
                    this.SendPropertyChanged("text");
                    this.OntextChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Currency", DbType = "NVarChar(10) NOT NULL", CanBeNull = false)]
        public string Currency
        {
            get
            {
                return this._Currency;
            }
            set
            {
                if ((this._Currency != value))
                {
                    this.OnCurrencyChanging(value);
                    this.SendPropertyChanging();
                    this._Currency = value;
                    this.SendPropertyChanged("Currency");
                    this.OnCurrencyChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Payment_LinePayment", Storage = "_Payment", ThisKey = "transid", OtherKey = "id", IsForeignKey = true)]
        public Payment Payment
        {
            get
            {
                return this._Payment.Entity;
            }
            set
            {
                Payment previousValue = this._Payment.Entity;
                if (((previousValue != value)
                            || (this._Payment.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Payment.Entity = null;
                        previousValue.LinePayments.Remove(this);
                    }
                    this._Payment.Entity = value;
                    if ((value != null))
                    {
                        value.LinePayments.Add(this);
                        this._transid = value.id;
                    }
                    else
                    {
                        this._transid = default(int);
                    }
                    this.SendPropertyChanged("Payment");
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.LinePurchaseOrder")]
    public partial class LinePurchaseOrder : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _id;

        private int _transid;

        private string _item;

        private string _unit;

        private decimal _price;

        private decimal _quantity;

        private decimal _Vat;

        private System.DateTime _duedate;

        private string _text;

        private System.Nullable<decimal> _lineNet;

        private System.Nullable<decimal> _lineVAT;

        private string _Currency;

        private EntityRef<Article> _Article;

        private EntityRef<PurchaseOrder> _PurchaseOrder;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnidChanging(int value);
        partial void OnidChanged();
        partial void OntransidChanging(int value);
        partial void OntransidChanged();
        partial void OnitemChanging(string value);
        partial void OnitemChanged();
        partial void OnunitChanging(string value);
        partial void OnunitChanged();
        partial void OnpriceChanging(decimal value);
        partial void OnpriceChanged();
        partial void OnquantityChanging(decimal value);
        partial void OnquantityChanged();
        partial void OnVatChanging(decimal value);
        partial void OnVatChanged();
        partial void OnduedateChanging(System.DateTime value);
        partial void OnduedateChanged();
        partial void OntextChanging(string value);
        partial void OntextChanged();
        partial void OnlineNetChanging(System.Nullable<decimal> value);
        partial void OnlineNetChanged();
        partial void OnlineVATChanging(System.Nullable<decimal> value);
        partial void OnlineVATChanged();
        partial void OnCurrencyChanging(string value);
        partial void OnCurrencyChanged();
        #endregion

        public LinePurchaseOrder()
        {
            this._Article = default(EntityRef<Article>);
            this._PurchaseOrder = default(EntityRef<PurchaseOrder>);
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    this.OnidChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("id");
                    this.OnidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_transid", DbType = "Int NOT NULL")]
        public int transid
        {
            get
            {
                return this._transid;
            }
            set
            {
                if ((this._transid != value))
                {
                    if (this._PurchaseOrder.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OntransidChanging(value);
                    this.SendPropertyChanging();
                    this._transid = value;
                    this.SendPropertyChanged("transid");
                    this.OntransidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_item", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string item
        {
            get
            {
                return this._item;
            }
            set
            {
                if ((this._item != value))
                {
                    if (this._Article.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnitemChanging(value);
                    this.SendPropertyChanging();
                    this._item = value;
                    this.SendPropertyChanged("item");
                    this.OnitemChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_unit", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
        public string unit
        {
            get
            {
                return this._unit;
            }
            set
            {
                if ((this._unit != value))
                {
                    this.OnunitChanging(value);
                    this.SendPropertyChanging();
                    this._unit = value;
                    this.SendPropertyChanged("unit");
                    this.OnunitChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_price", DbType = "Money NOT NULL")]
        public decimal price
        {
            get
            {
                return this._price;
            }
            set
            {
                if ((this._price != value))
                {
                    this.OnpriceChanging(value);
                    this.SendPropertyChanging();
                    this._price = value;
                    this.SendPropertyChanged("price");
                    this.OnpriceChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_quantity", DbType = "Decimal(10,2) NOT NULL")]
        public decimal quantity
        {
            get
            {
                return this._quantity;
            }
            set
            {
                if ((this._quantity != value))
                {
                    this.OnquantityChanging(value);
                    this.SendPropertyChanging();
                    this._quantity = value;
                    this.SendPropertyChanged("quantity");
                    this.OnquantityChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Vat", DbType = "Decimal(16,2) NOT NULL")]
        public decimal Vat
        {
            get
            {
                return this._Vat;
            }
            set
            {
                if ((this._Vat != value))
                {
                    this.OnVatChanging(value);
                    this.SendPropertyChanging();
                    this._Vat = value;
                    this.SendPropertyChanged("Vat");
                    this.OnVatChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_duedate", DbType = "DateTime2 NOT NULL")]
        public System.DateTime duedate
        {
            get
            {
                return this._duedate;
            }
            set
            {
                if ((this._duedate != value))
                {
                    this.OnduedateChanging(value);
                    this.SendPropertyChanging();
                    this._duedate = value;
                    this.SendPropertyChanged("duedate");
                    this.OnduedateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_text", DbType = "NVarChar(50)")]
        public string text
        {
            get
            {
                return this._text;
            }
            set
            {
                if ((this._text != value))
                {
                    this.OntextChanging(value);
                    this.SendPropertyChanging();
                    this._text = value;
                    this.SendPropertyChanged("text");
                    this.OntextChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_lineNet", AutoSync = AutoSync.Always, DbType = "Money", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<decimal> lineNet
        {
            get
            {
                return this._lineNet;
            }
            set
            {
                if ((this._lineNet != value))
                {
                    this.OnlineNetChanging(value);
                    this.SendPropertyChanging();
                    this._lineNet = value;
                    this.SendPropertyChanged("lineNet");
                    this.OnlineNetChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_lineVAT", AutoSync = AutoSync.Always, DbType = "Money", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<decimal> lineVAT
        {
            get
            {
                return this._lineVAT;
            }
            set
            {
                if ((this._lineVAT != value))
                {
                    this.OnlineVATChanging(value);
                    this.SendPropertyChanging();
                    this._lineVAT = value;
                    this.SendPropertyChanged("lineVAT");
                    this.OnlineVATChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Currency", DbType = "NVarChar(10) NOT NULL", CanBeNull = false)]
        public string Currency
        {
            get
            {
                return this._Currency;
            }
            set
            {
                if ((this._Currency != value))
                {
                    this.OnCurrencyChanging(value);
                    this.SendPropertyChanging();
                    this._Currency = value;
                    this.SendPropertyChanged("Currency");
                    this.OnCurrencyChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Article_LinePurchaseOrder", Storage = "_Article", ThisKey = "item", OtherKey = "id", IsForeignKey = true)]
        public Article Article
        {
            get
            {
                return this._Article.Entity;
            }
            set
            {
                Article previousValue = this._Article.Entity;
                if (((previousValue != value)
                            || (this._Article.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Article.Entity = null;
                        previousValue.LinePurchaseOrders.Remove(this);
                    }
                    this._Article.Entity = value;
                    if ((value != null))
                    {
                        value.LinePurchaseOrders.Add(this);
                        this._item = value.id;
                    }
                    else
                    {
                        this._item = default(string);
                    }
                    this.SendPropertyChanged("Article");
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "PurchaseOrder_LinePurchaseOrder", Storage = "_PurchaseOrder", ThisKey = "transid", OtherKey = "id", IsForeignKey = true)]
        public PurchaseOrder PurchaseOrder
        {
            get
            {
                return this._PurchaseOrder.Entity;
            }
            set
            {
                PurchaseOrder previousValue = this._PurchaseOrder.Entity;
                if (((previousValue != value)
                            || (this._PurchaseOrder.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._PurchaseOrder.Entity = null;
                        previousValue.LinePurchaseOrders.Remove(this);
                    }
                    this._PurchaseOrder.Entity = value;
                    if ((value != null))
                    {
                        value.LinePurchaseOrders.Add(this);
                        this._transid = value.id;
                    }
                    else
                    {
                        this._transid = default(int);
                    }
                    this.SendPropertyChanged("PurchaseOrder");
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.LineSalesInvoice")]
    public partial class LineSalesInvoice : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _id;

        private int _transid;

        private string _item;

        private string _unit;

        private decimal _price;

        private decimal _quantity;

        private decimal _Vat;

        private System.DateTime _duedate;

        private string _text;

        private string _Currency;

        private System.Nullable<decimal> _lineNet;

        private System.Nullable<decimal> _lineVAT;

        private EntityRef<Article> _Article;

        private EntityRef<SalesInvoice> _SalesInvoice;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnidChanging(int value);
        partial void OnidChanged();
        partial void OntransidChanging(int value);
        partial void OntransidChanged();
        partial void OnitemChanging(string value);
        partial void OnitemChanged();
        partial void OnunitChanging(string value);
        partial void OnunitChanged();
        partial void OnpriceChanging(decimal value);
        partial void OnpriceChanged();
        partial void OnquantityChanging(decimal value);
        partial void OnquantityChanged();
        partial void OnVatChanging(decimal value);
        partial void OnVatChanged();
        partial void OnduedateChanging(System.DateTime value);
        partial void OnduedateChanged();
        partial void OntextChanging(string value);
        partial void OntextChanged();
        partial void OnCurrencyChanging(string value);
        partial void OnCurrencyChanged();
        partial void OnlineNetChanging(System.Nullable<decimal> value);
        partial void OnlineNetChanged();
        partial void OnlineVATChanging(System.Nullable<decimal> value);
        partial void OnlineVATChanged();
        #endregion

        public LineSalesInvoice()
        {
            this._Article = default(EntityRef<Article>);
            this._SalesInvoice = default(EntityRef<SalesInvoice>);
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    this.OnidChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("id");
                    this.OnidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_transid", DbType = "Int NOT NULL")]
        public int transid
        {
            get
            {
                return this._transid;
            }
            set
            {
                if ((this._transid != value))
                {
                    if (this._SalesInvoice.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OntransidChanging(value);
                    this.SendPropertyChanging();
                    this._transid = value;
                    this.SendPropertyChanged("transid");
                    this.OntransidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_item", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string item
        {
            get
            {
                return this._item;
            }
            set
            {
                if ((this._item != value))
                {
                    if (this._Article.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnitemChanging(value);
                    this.SendPropertyChanging();
                    this._item = value;
                    this.SendPropertyChanged("item");
                    this.OnitemChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_unit", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string unit
        {
            get
            {
                return this._unit;
            }
            set
            {
                if ((this._unit != value))
                {
                    this.OnunitChanging(value);
                    this.SendPropertyChanging();
                    this._unit = value;
                    this.SendPropertyChanged("unit");
                    this.OnunitChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_price", DbType = "Money NOT NULL")]
        public decimal price
        {
            get
            {
                return this._price;
            }
            set
            {
                if ((this._price != value))
                {
                    this.OnpriceChanging(value);
                    this.SendPropertyChanging();
                    this._price = value;
                    this.SendPropertyChanged("price");
                    this.OnpriceChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_quantity", DbType = "Decimal(10,2) NOT NULL")]
        public decimal quantity
        {
            get
            {
                return this._quantity;
            }
            set
            {
                if ((this._quantity != value))
                {
                    this.OnquantityChanging(value);
                    this.SendPropertyChanging();
                    this._quantity = value;
                    this.SendPropertyChanged("quantity");
                    this.OnquantityChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Vat", DbType = "Decimal(16,2) NOT NULL")]
        public decimal Vat
        {
            get
            {
                return this._Vat;
            }
            set
            {
                if ((this._Vat != value))
                {
                    this.OnVatChanging(value);
                    this.SendPropertyChanging();
                    this._Vat = value;
                    this.SendPropertyChanged("Vat");
                    this.OnVatChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_duedate", DbType = "DateTime2 NOT NULL")]
        public System.DateTime duedate
        {
            get
            {
                return this._duedate;
            }
            set
            {
                if ((this._duedate != value))
                {
                    this.OnduedateChanging(value);
                    this.SendPropertyChanging();
                    this._duedate = value;
                    this.SendPropertyChanged("duedate");
                    this.OnduedateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_text", DbType = "NVarChar(50)")]
        public string text
        {
            get
            {
                return this._text;
            }
            set
            {
                if ((this._text != value))
                {
                    this.OntextChanging(value);
                    this.SendPropertyChanging();
                    this._text = value;
                    this.SendPropertyChanged("text");
                    this.OntextChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Currency", DbType = "NVarChar(10) NOT NULL", CanBeNull = false)]
        public string Currency
        {
            get
            {
                return this._Currency;
            }
            set
            {
                if ((this._Currency != value))
                {
                    this.OnCurrencyChanging(value);
                    this.SendPropertyChanging();
                    this._Currency = value;
                    this.SendPropertyChanged("Currency");
                    this.OnCurrencyChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_lineNet", AutoSync = AutoSync.Always, DbType = "Money", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<decimal> lineNet
        {
            get
            {
                return this._lineNet;
            }
            set
            {
                if ((this._lineNet != value))
                {
                    this.OnlineNetChanging(value);
                    this.SendPropertyChanging();
                    this._lineNet = value;
                    this.SendPropertyChanged("lineNet");
                    this.OnlineNetChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_lineVAT", AutoSync = AutoSync.Always, DbType = "Money", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<decimal> lineVAT
        {
            get
            {
                return this._lineVAT;
            }
            set
            {
                if ((this._lineVAT != value))
                {
                    this.OnlineVATChanging(value);
                    this.SendPropertyChanging();
                    this._lineVAT = value;
                    this.SendPropertyChanged("lineVAT");
                    this.OnlineVATChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Article_LineSalesInvoice", Storage = "_Article", ThisKey = "item", OtherKey = "id", IsForeignKey = true)]
        public Article Article
        {
            get
            {
                return this._Article.Entity;
            }
            set
            {
                Article previousValue = this._Article.Entity;
                if (((previousValue != value)
                            || (this._Article.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Article.Entity = null;
                        previousValue.LineSalesInvoices.Remove(this);
                    }
                    this._Article.Entity = value;
                    if ((value != null))
                    {
                        value.LineSalesInvoices.Add(this);
                        this._item = value.id;
                    }
                    else
                    {
                        this._item = default(string);
                    }
                    this.SendPropertyChanged("Article");
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "SalesInvoice_LineSalesInvoice", Storage = "_SalesInvoice", ThisKey = "transid", OtherKey = "id", IsForeignKey = true)]
        public SalesInvoice SalesInvoice
        {
            get
            {
                return this._SalesInvoice.Entity;
            }
            set
            {
                SalesInvoice previousValue = this._SalesInvoice.Entity;
                if (((previousValue != value)
                            || (this._SalesInvoice.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._SalesInvoice.Entity = null;
                        previousValue.LineSalesInvoices.Remove(this);
                    }
                    this._SalesInvoice.Entity = value;
                    if ((value != null))
                    {
                        value.LineSalesInvoices.Add(this);
                        this._transid = value.id;
                    }
                    else
                    {
                        this._transid = default(int);
                    }
                    this.SendPropertyChanged("SalesInvoice");
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.LineSalesOrder")]
    public partial class LineSalesOrder : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _id;

        private int _transid;

        private string _item;

        private string _unit;

        private decimal _price;

        private decimal _quantity;

        private decimal _Vat;

        private System.DateTime _duedate;

        private string _text;

        private System.Nullable<decimal> _lineNet;

        private System.Nullable<decimal> _lineVAT;

        private string _Currency;

        private EntityRef<Article> _Article;

        private EntityRef<SalesOrder> _SalesOrder;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnidChanging(int value);
        partial void OnidChanged();
        partial void OntransidChanging(int value);
        partial void OntransidChanged();
        partial void OnitemChanging(string value);
        partial void OnitemChanged();
        partial void OnunitChanging(string value);
        partial void OnunitChanged();
        partial void OnpriceChanging(decimal value);
        partial void OnpriceChanged();
        partial void OnquantityChanging(decimal value);
        partial void OnquantityChanged();
        partial void OnVatChanging(decimal value);
        partial void OnVatChanged();
        partial void OnduedateChanging(System.DateTime value);
        partial void OnduedateChanged();
        partial void OntextChanging(string value);
        partial void OntextChanged();
        partial void OnlineNetChanging(System.Nullable<decimal> value);
        partial void OnlineNetChanged();
        partial void OnlineVATChanging(System.Nullable<decimal> value);
        partial void OnlineVATChanged();
        partial void OnCurrencyChanging(string value);
        partial void OnCurrencyChanged();
        #endregion

        public LineSalesOrder()
        {
            this._Article = default(EntityRef<Article>);
            this._SalesOrder = default(EntityRef<SalesOrder>);
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    this.OnidChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("id");
                    this.OnidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_transid", DbType = "Int NOT NULL")]
        public int transid
        {
            get
            {
                return this._transid;
            }
            set
            {
                if ((this._transid != value))
                {
                    if (this._SalesOrder.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OntransidChanging(value);
                    this.SendPropertyChanging();
                    this._transid = value;
                    this.SendPropertyChanged("transid");
                    this.OntransidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_item", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string item
        {
            get
            {
                return this._item;
            }
            set
            {
                if ((this._item != value))
                {
                    if (this._Article.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnitemChanging(value);
                    this.SendPropertyChanging();
                    this._item = value;
                    this.SendPropertyChanged("item");
                    this.OnitemChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_unit", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
        public string unit
        {
            get
            {
                return this._unit;
            }
            set
            {
                if ((this._unit != value))
                {
                    this.OnunitChanging(value);
                    this.SendPropertyChanging();
                    this._unit = value;
                    this.SendPropertyChanged("unit");
                    this.OnunitChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_price", DbType = "Money NOT NULL")]
        public decimal price
        {
            get
            {
                return this._price;
            }
            set
            {
                if ((this._price != value))
                {
                    this.OnpriceChanging(value);
                    this.SendPropertyChanging();
                    this._price = value;
                    this.SendPropertyChanged("price");
                    this.OnpriceChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_quantity", DbType = "Decimal(10,2) NOT NULL")]
        public decimal quantity
        {
            get
            {
                return this._quantity;
            }
            set
            {
                if ((this._quantity != value))
                {
                    this.OnquantityChanging(value);
                    this.SendPropertyChanging();
                    this._quantity = value;
                    this.SendPropertyChanged("quantity");
                    this.OnquantityChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Vat", DbType = "Decimal(16,2) NOT NULL")]
        public decimal Vat
        {
            get
            {
                return this._Vat;
            }
            set
            {
                if ((this._Vat != value))
                {
                    this.OnVatChanging(value);
                    this.SendPropertyChanging();
                    this._Vat = value;
                    this.SendPropertyChanged("Vat");
                    this.OnVatChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_duedate", DbType = "DateTime2 NOT NULL")]
        public System.DateTime duedate
        {
            get
            {
                return this._duedate;
            }
            set
            {
                if ((this._duedate != value))
                {
                    this.OnduedateChanging(value);
                    this.SendPropertyChanging();
                    this._duedate = value;
                    this.SendPropertyChanged("duedate");
                    this.OnduedateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_text", DbType = "NVarChar(50)")]
        public string text
        {
            get
            {
                return this._text;
            }
            set
            {
                if ((this._text != value))
                {
                    this.OntextChanging(value);
                    this.SendPropertyChanging();
                    this._text = value;
                    this.SendPropertyChanged("text");
                    this.OntextChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_lineNet", AutoSync = AutoSync.Always, DbType = "Money", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<decimal> lineNet
        {
            get
            {
                return this._lineNet;
            }
            set
            {
                if ((this._lineNet != value))
                {
                    this.OnlineNetChanging(value);
                    this.SendPropertyChanging();
                    this._lineNet = value;
                    this.SendPropertyChanged("lineNet");
                    this.OnlineNetChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_lineVAT", AutoSync = AutoSync.Always, DbType = "Money", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<decimal> lineVAT
        {
            get
            {
                return this._lineVAT;
            }
            set
            {
                if ((this._lineVAT != value))
                {
                    this.OnlineVATChanging(value);
                    this.SendPropertyChanging();
                    this._lineVAT = value;
                    this.SendPropertyChanged("lineVAT");
                    this.OnlineVATChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Currency", DbType = "NVarChar(10) NOT NULL", CanBeNull = false)]
        public string Currency
        {
            get
            {
                return this._Currency;
            }
            set
            {
                if ((this._Currency != value))
                {
                    this.OnCurrencyChanging(value);
                    this.SendPropertyChanging();
                    this._Currency = value;
                    this.SendPropertyChanged("Currency");
                    this.OnCurrencyChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Article_LineSalesOrder", Storage = "_Article", ThisKey = "item", OtherKey = "id", IsForeignKey = true)]
        public Article Article
        {
            get
            {
                return this._Article.Entity;
            }
            set
            {
                Article previousValue = this._Article.Entity;
                if (((previousValue != value)
                            || (this._Article.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Article.Entity = null;
                        previousValue.LineSalesOrders.Remove(this);
                    }
                    this._Article.Entity = value;
                    if ((value != null))
                    {
                        value.LineSalesOrders.Add(this);
                        this._item = value.id;
                    }
                    else
                    {
                        this._item = default(string);
                    }
                    this.SendPropertyChanged("Article");
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "SalesOrder_LineSalesOrder", Storage = "_SalesOrder", ThisKey = "transid", OtherKey = "id", IsForeignKey = true)]
        public SalesOrder SalesOrder
        {
            get
            {
                return this._SalesOrder.Entity;
            }
            set
            {
                SalesOrder previousValue = this._SalesOrder.Entity;
                if (((previousValue != value)
                            || (this._SalesOrder.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._SalesOrder.Entity = null;
                        previousValue.LineSalesOrders.Remove(this);
                    }
                    this._SalesOrder.Entity = value;
                    if ((value != null))
                    {
                        value.LineSalesOrders.Add(this);
                        this._transid = value.id;
                    }
                    else
                    {
                        this._transid = default(int);
                    }
                    this.SendPropertyChanged("SalesOrder");
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.LineSettlement")]
    public partial class LineSettlement : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _id;

        private int _transid;

        private string _account;

        private bool _side;

        private string _oaccount;

        private decimal _amount;

        private System.DateTime _duedate;

        private string _text;

        private string _Currency;

        private EntityRef<Settlement> _Settlement;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnidChanging(int value);
        partial void OnidChanged();
        partial void OntransidChanging(int value);
        partial void OntransidChanged();
        partial void OnaccountChanging(string value);
        partial void OnaccountChanged();
        partial void OnsideChanging(bool value);
        partial void OnsideChanged();
        partial void OnoaccountChanging(string value);
        partial void OnoaccountChanged();
        partial void OnamountChanging(decimal value);
        partial void OnamountChanged();
        partial void OnduedateChanging(System.DateTime value);
        partial void OnduedateChanged();
        partial void OntextChanging(string value);
        partial void OntextChanged();
        partial void OnCurrencyChanging(string value);
        partial void OnCurrencyChanged();
        #endregion

        public LineSettlement()
        {
            this._Settlement = default(EntityRef<Settlement>);
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    this.OnidChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("id");
                    this.OnidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_transid", DbType = "Int NOT NULL")]
        public int transid
        {
            get
            {
                return this._transid;
            }
            set
            {
                if ((this._transid != value))
                {
                    if (this._Settlement.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OntransidChanging(value);
                    this.SendPropertyChanging();
                    this._transid = value;
                    this.SendPropertyChanged("transid");
                    this.OntransidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_account", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string account
        {
            get
            {
                return this._account;
            }
            set
            {
                if ((this._account != value))
                {
                    this.OnaccountChanging(value);
                    this.SendPropertyChanging();
                    this._account = value;
                    this.SendPropertyChanged("account");
                    this.OnaccountChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_side", DbType = "Bit NOT NULL")]
        public bool side
        {
            get
            {
                return this._side;
            }
            set
            {
                if ((this._side != value))
                {
                    this.OnsideChanging(value);
                    this.SendPropertyChanging();
                    this._side = value;
                    this.SendPropertyChanged("side");
                    this.OnsideChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oaccount", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string oaccount
        {
            get
            {
                return this._oaccount;
            }
            set
            {
                if ((this._oaccount != value))
                {
                    this.OnoaccountChanging(value);
                    this.SendPropertyChanging();
                    this._oaccount = value;
                    this.SendPropertyChanged("oaccount");
                    this.OnoaccountChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_amount", DbType = "Money NOT NULL")]
        public decimal amount
        {
            get
            {
                return this._amount;
            }
            set
            {
                if ((this._amount != value))
                {
                    this.OnamountChanging(value);
                    this.SendPropertyChanging();
                    this._amount = value;
                    this.SendPropertyChanged("amount");
                    this.OnamountChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_duedate", DbType = "DateTime2 NOT NULL")]
        public System.DateTime duedate
        {
            get
            {
                return this._duedate;
            }
            set
            {
                if ((this._duedate != value))
                {
                    this.OnduedateChanging(value);
                    this.SendPropertyChanging();
                    this._duedate = value;
                    this.SendPropertyChanged("duedate");
                    this.OnduedateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_text", DbType = "NVarChar(250)")]
        public string text
        {
            get
            {
                return this._text;
            }
            set
            {
                if ((this._text != value))
                {
                    this.OntextChanging(value);
                    this.SendPropertyChanging();
                    this._text = value;
                    this.SendPropertyChanged("text");
                    this.OntextChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Currency", DbType = "NVarChar(10) NOT NULL", CanBeNull = false)]
        public string Currency
        {
            get
            {
                return this._Currency;
            }
            set
            {
                if ((this._Currency != value))
                {
                    this.OnCurrencyChanging(value);
                    this.SendPropertyChanging();
                    this._Currency = value;
                    this.SendPropertyChanged("Currency");
                    this.OnCurrencyChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Settlement_LineSettlement", Storage = "_Settlement", ThisKey = "transid", OtherKey = "id", IsForeignKey = true)]
        public Settlement Settlement
        {
            get
            {
                return this._Settlement.Entity;
            }
            set
            {
                Settlement previousValue = this._Settlement.Entity;
                if (((previousValue != value)
                            || (this._Settlement.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Settlement.Entity = null;
                        previousValue.LineSettlements.Remove(this);
                    }
                    this._Settlement.Entity = value;
                    if ((value != null))
                    {
                        value.LineSettlements.Add(this);
                        this._transid = value.id;
                    }
                    else
                    {
                        this._transid = default(int);
                    }
                    this.SendPropertyChanged("Settlement");
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.LineVendorInvoice")]
    public partial class LineVendorInvoice : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _id;

        private int _transid;

        private string _account;

        private bool _side;

        private string _oaccount;

        private decimal _amount;

        private System.DateTime _duedate;

        private string _text;

        private string _Currency;

        private EntityRef<VendorInvoice> _VendorInvoice;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnidChanging(int value);
        partial void OnidChanged();
        partial void OntransidChanging(int value);
        partial void OntransidChanged();
        partial void OnaccountChanging(string value);
        partial void OnaccountChanged();
        partial void OnsideChanging(bool value);
        partial void OnsideChanged();
        partial void OnoaccountChanging(string value);
        partial void OnoaccountChanged();
        partial void OnamountChanging(decimal value);
        partial void OnamountChanged();
        partial void OnduedateChanging(System.DateTime value);
        partial void OnduedateChanged();
        partial void OntextChanging(string value);
        partial void OntextChanged();
        partial void OnCurrencyChanging(string value);
        partial void OnCurrencyChanged();
        #endregion

        public LineVendorInvoice()
        {
            this._VendorInvoice = default(EntityRef<VendorInvoice>);
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    this.OnidChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("id");
                    this.OnidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_transid", DbType = "Int NOT NULL")]
        public int transid
        {
            get
            {
                return this._transid;
            }
            set
            {
                if ((this._transid != value))
                {
                    if (this._VendorInvoice.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OntransidChanging(value);
                    this.SendPropertyChanging();
                    this._transid = value;
                    this.SendPropertyChanged("transid");
                    this.OntransidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_account", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string account
        {
            get
            {
                return this._account;
            }
            set
            {
                if ((this._account != value))
                {
                    this.OnaccountChanging(value);
                    this.SendPropertyChanging();
                    this._account = value;
                    this.SendPropertyChanged("account");
                    this.OnaccountChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_side", DbType = "Bit NOT NULL")]
        public bool side
        {
            get
            {
                return this._side;
            }
            set
            {
                if ((this._side != value))
                {
                    this.OnsideChanging(value);
                    this.SendPropertyChanging();
                    this._side = value;
                    this.SendPropertyChanged("side");
                    this.OnsideChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oaccount", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string oaccount
        {
            get
            {
                return this._oaccount;
            }
            set
            {
                if ((this._oaccount != value))
                {
                    this.OnoaccountChanging(value);
                    this.SendPropertyChanging();
                    this._oaccount = value;
                    this.SendPropertyChanged("oaccount");
                    this.OnoaccountChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_amount", DbType = "Money NOT NULL")]
        public decimal amount
        {
            get
            {
                return this._amount;
            }
            set
            {
                if ((this._amount != value))
                {
                    this.OnamountChanging(value);
                    this.SendPropertyChanging();
                    this._amount = value;
                    this.SendPropertyChanged("amount");
                    this.OnamountChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_duedate", DbType = "DateTime2 NOT NULL")]
        public System.DateTime duedate
        {
            get
            {
                return this._duedate;
            }
            set
            {
                if ((this._duedate != value))
                {
                    this.OnduedateChanging(value);
                    this.SendPropertyChanging();
                    this._duedate = value;
                    this.SendPropertyChanged("duedate");
                    this.OnduedateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_text", DbType = "NVarChar(50)")]
        public string text
        {
            get
            {
                return this._text;
            }
            set
            {
                if ((this._text != value))
                {
                    this.OntextChanging(value);
                    this.SendPropertyChanging();
                    this._text = value;
                    this.SendPropertyChanged("text");
                    this.OntextChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Currency", DbType = "NVarChar(10) NOT NULL", CanBeNull = false)]
        public string Currency
        {
            get
            {
                return this._Currency;
            }
            set
            {
                if ((this._Currency != value))
                {
                    this.OnCurrencyChanging(value);
                    this.SendPropertyChanging();
                    this._Currency = value;
                    this.SendPropertyChanged("Currency");
                    this.OnCurrencyChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "VendorInvoice_LineVendorInvoice", Storage = "_VendorInvoice", ThisKey = "transid", OtherKey = "id", IsForeignKey = true)]
        public VendorInvoice VendorInvoice
        {
            get
            {
                return this._VendorInvoice.Entity;
            }
            set
            {
                VendorInvoice previousValue = this._VendorInvoice.Entity;
                if (((previousValue != value)
                            || (this._VendorInvoice.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._VendorInvoice.Entity = null;
                        previousValue.LineVendorInvoices.Remove(this);
                    }
                    this._VendorInvoice.Entity = value;
                    if ((value != null))
                    {
                        value.LineVendorInvoices.Add(this);
                        this._transid = value.id;
                    }
                    else
                    {
                        this._transid = default(int);
                    }
                    this.SendPropertyChanged("VendorInvoice");
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.Localization")]
    public partial class Localization : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _ItemName;

        private string _UICulture;

        private string _LocalName;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnItemNameChanging(string value);
        partial void OnItemNameChanged();
        partial void OnUICultureChanging(string value);
        partial void OnUICultureChanged();
        partial void OnLocalNameChanging(string value);
        partial void OnLocalNameChanged();
        #endregion

        public Localization()
        {
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ItemName", DbType = "NVarChar(50) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string ItemName
        {
            get
            {
                return this._ItemName;
            }
            set
            {
                if ((this._ItemName != value))
                {
                    this.OnItemNameChanging(value);
                    this.SendPropertyChanging();
                    this._ItemName = value;
                    this.SendPropertyChanged("ItemName");
                    this.OnItemNameChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_UICulture", DbType = "Char(5) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string UICulture
        {
            get
            {
                return this._UICulture;
            }
            set
            {
                if ((this._UICulture != value))
                {
                    this.OnUICultureChanging(value);
                    this.SendPropertyChanging();
                    this._UICulture = value;
                    this.SendPropertyChanged("UICulture");
                    this.OnUICultureChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_LocalName", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string LocalName
        {
            get
            {
                return this._LocalName;
            }
            set
            {
                if ((this._LocalName != value))
                {
                    this.OnLocalNameChanging(value);
                    this.SendPropertyChanging();
                    this._LocalName = value;
                    this.SendPropertyChanged("LocalName");
                    this.OnLocalNameChanged();
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.LogExceptions")]
    public partial class LogException : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private long _LogId;

        private string _EMessage;

        private string _EType;

        private string _ESource;

        private string _ETarget;

        private string _EURL;

        private System.DateTime _LogDate;

        private string _CompanyId;

        private string _UserName;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnLogIdChanging(long value);
        partial void OnLogIdChanged();
        partial void OnEMessageChanging(string value);
        partial void OnEMessageChanged();
        partial void OnETypeChanging(string value);
        partial void OnETypeChanged();
        partial void OnESourceChanging(string value);
        partial void OnESourceChanged();
        partial void OnETargetChanging(string value);
        partial void OnETargetChanged();
        partial void OnEURLChanging(string value);
        partial void OnEURLChanged();
        partial void OnLogDateChanging(System.DateTime value);
        partial void OnLogDateChanged();
        partial void OnCompanyIdChanging(string value);
        partial void OnCompanyIdChanged();
        partial void OnUserNameChanging(string value);
        partial void OnUserNameChanged();
        #endregion

        public LogException()
        {
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_LogId", AutoSync = AutoSync.OnInsert, DbType = "BigInt NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public long LogId
        {
            get
            {
                return this._LogId;
            }
            set
            {
                if ((this._LogId != value))
                {
                    this.OnLogIdChanging(value);
                    this.SendPropertyChanging();
                    this._LogId = value;
                    this.SendPropertyChanged("LogId");
                    this.OnLogIdChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_EMessage", DbType = "VarChar(MAX) NOT NULL", CanBeNull = false)]
        public string EMessage
        {
            get
            {
                return this._EMessage;
            }
            set
            {
                if ((this._EMessage != value))
                {
                    this.OnEMessageChanging(value);
                    this.SendPropertyChanging();
                    this._EMessage = value;
                    this.SendPropertyChanged("EMessage");
                    this.OnEMessageChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_EType", DbType = "VarChar(256)")]
        public string EType
        {
            get
            {
                return this._EType;
            }
            set
            {
                if ((this._EType != value))
                {
                    this.OnETypeChanging(value);
                    this.SendPropertyChanging();
                    this._EType = value;
                    this.SendPropertyChanged("EType");
                    this.OnETypeChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ESource", DbType = "NVarChar(256)")]
        public string ESource
        {
            get
            {
                return this._ESource;
            }
            set
            {
                if ((this._ESource != value))
                {
                    this.OnESourceChanging(value);
                    this.SendPropertyChanging();
                    this._ESource = value;
                    this.SendPropertyChanged("ESource");
                    this.OnESourceChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ETarget", DbType = "NVarChar(256)")]
        public string ETarget
        {
            get
            {
                return this._ETarget;
            }
            set
            {
                if ((this._ETarget != value))
                {
                    this.OnETargetChanging(value);
                    this.SendPropertyChanging();
                    this._ETarget = value;
                    this.SendPropertyChanged("ETarget");
                    this.OnETargetChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_EURL", DbType = "VarChar(256)")]
        public string EURL
        {
            get
            {
                return this._EURL;
            }
            set
            {
                if ((this._EURL != value))
                {
                    this.OnEURLChanging(value);
                    this.SendPropertyChanging();
                    this._EURL = value;
                    this.SendPropertyChanged("EURL");
                    this.OnEURLChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_LogDate", DbType = "DateTime NOT NULL")]
        public System.DateTime LogDate
        {
            get
            {
                return this._LogDate;
            }
            set
            {
                if ((this._LogDate != value))
                {
                    this.OnLogDateChanging(value);
                    this.SendPropertyChanging();
                    this._LogDate = value;
                    this.SendPropertyChanged("LogDate");
                    this.OnLogDateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyId", DbType = "NVarChar(6) NOT NULL", CanBeNull = false)]
        public string CompanyId
        {
            get
            {
                return this._CompanyId;
            }
            set
            {
                if ((this._CompanyId != value))
                {
                    this.OnCompanyIdChanging(value);
                    this.SendPropertyChanging();
                    this._CompanyId = value;
                    this.SendPropertyChanged("CompanyId");
                    this.OnCompanyIdChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_UserName", DbType = "VarChar(100) NOT NULL", CanBeNull = false)]
        public string UserName
        {
            get
            {
                return this._UserName;
            }
            set
            {
                if ((this._UserName != value))
                {
                    this.OnUserNameChanging(value);
                    this.SendPropertyChanging();
                    this._UserName = value;
                    this.SendPropertyChanged("UserName");
                    this.OnUserNameChanged();
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.Menu")]
    public partial class Menu : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private string _CompanyID;

        private string _Name;

        private string _Action;

        private string _Controller;

        private string _Roles;

        private System.Nullable<bool> _Disable;

        private System.Nullable<bool> _HasAccess;

        private System.Nullable<int> _Parent;

        private System.Nullable<int> _MenuOrder;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnCompanyIDChanging(string value);
        partial void OnCompanyIDChanged();
        partial void OnNameChanging(string value);
        partial void OnNameChanged();
        partial void OnActionChanging(string value);
        partial void OnActionChanged();
        partial void OnControllerChanging(string value);
        partial void OnControllerChanged();
        partial void OnRolesChanging(string value);
        partial void OnRolesChanged();
        partial void OnDisableChanging(System.Nullable<bool> value);
        partial void OnDisableChanged();
        partial void OnHasAccessChanging(System.Nullable<bool> value);
        partial void OnHasAccessChanged();
        partial void OnParentChanging(System.Nullable<int> value);
        partial void OnParentChanged();
        partial void OnMenuOrderChanging(System.Nullable<int> value);
        partial void OnMenuOrderChanged();
        #endregion

        public Menu()
        {
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                if ((this._ID != value))
                {
                    this.OnIDChanging(value);
                    this.SendPropertyChanging();
                    this._ID = value;
                    this.SendPropertyChanged("ID");
                    this.OnIDChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string CompanyID
        {
            get
            {
                return this._CompanyID;
            }
            set
            {
                if ((this._CompanyID != value))
                {
                    this.OnCompanyIDChanging(value);
                    this.SendPropertyChanging();
                    this._CompanyID = value;
                    this.SendPropertyChanged("CompanyID");
                    this.OnCompanyIDChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Name", DbType = "NVarChar(50)")]
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                if ((this._Name != value))
                {
                    this.OnNameChanging(value);
                    this.SendPropertyChanging();
                    this._Name = value;
                    this.SendPropertyChanged("Name");
                    this.OnNameChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Action", DbType = "NVarChar(50)")]
        public string Action
        {
            get
            {
                return this._Action;
            }
            set
            {
                if ((this._Action != value))
                {
                    this.OnActionChanging(value);
                    this.SendPropertyChanging();
                    this._Action = value;
                    this.SendPropertyChanged("Action");
                    this.OnActionChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Controller", DbType = "NVarChar(50)")]
        public string Controller
        {
            get
            {
                return this._Controller;
            }
            set
            {
                if ((this._Controller != value))
                {
                    this.OnControllerChanging(value);
                    this.SendPropertyChanging();
                    this._Controller = value;
                    this.SendPropertyChanged("Controller");
                    this.OnControllerChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Roles", DbType = "NVarChar(150)")]
        public string Roles
        {
            get
            {
                return this._Roles;
            }
            set
            {
                if ((this._Roles != value))
                {
                    this.OnRolesChanging(value);
                    this.SendPropertyChanging();
                    this._Roles = value;
                    this.SendPropertyChanged("Roles");
                    this.OnRolesChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Disable", DbType = "Bit")]
        public System.Nullable<bool> Disable
        {
            get
            {
                return this._Disable;
            }
            set
            {
                if ((this._Disable != value))
                {
                    this.OnDisableChanging(value);
                    this.SendPropertyChanging();
                    this._Disable = value;
                    this.SendPropertyChanged("Disable");
                    this.OnDisableChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_HasAccess", DbType = "Bit")]
        public System.Nullable<bool> HasAccess
        {
            get
            {
                return this._HasAccess;
            }
            set
            {
                if ((this._HasAccess != value))
                {
                    this.OnHasAccessChanging(value);
                    this.SendPropertyChanging();
                    this._HasAccess = value;
                    this.SendPropertyChanged("HasAccess");
                    this.OnHasAccessChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Parent", DbType = "Int")]
        public System.Nullable<int> Parent
        {
            get
            {
                return this._Parent;
            }
            set
            {
                if ((this._Parent != value))
                {
                    this.OnParentChanging(value);
                    this.SendPropertyChanging();
                    this._Parent = value;
                    this.SendPropertyChanged("Parent");
                    this.OnParentChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_MenuOrder", DbType = "Int")]
        public System.Nullable<int> MenuOrder
        {
            get
            {
                return this._MenuOrder;
            }
            set
            {
                if ((this._MenuOrder != value))
                {
                    this.OnMenuOrderChanging(value);
                    this.SendPropertyChanging();
                    this._MenuOrder = value;
                    this.SendPropertyChanged("MenuOrder");
                    this.OnMenuOrderChanged();
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.Payment")]
    public partial class Payment : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _id;

        private int _oid;

        private string _CostCenter;

        private string _account;

        private string _HeaderText;

        private System.DateTime _TransDate;

        private System.DateTime _ItemDate;

        private System.DateTime _EntryDate;

        private string _CompanyId;

        private System.Nullable<bool> _IsValidated;

        private System.Nullable<decimal> _oTotal;

        private string _oCurrency;

        private string _oPeriode;

        private EntitySet<LinePayment> _LinePayments;

        private EntityRef<Company> _Company;

        private EntityRef<Supplier> _Supplier;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnidChanging(int value);
        partial void OnidChanged();
        partial void OnoidChanging(int value);
        partial void OnoidChanged();
        partial void OnCostCenterChanging(string value);
        partial void OnCostCenterChanged();
        partial void OnaccountChanging(string value);
        partial void OnaccountChanged();
        partial void OnHeaderTextChanging(string value);
        partial void OnHeaderTextChanged();
        partial void OnTransDateChanging(System.DateTime value);
        partial void OnTransDateChanged();
        partial void OnItemDateChanging(System.DateTime value);
        partial void OnItemDateChanged();
        partial void OnEntryDateChanging(System.DateTime value);
        partial void OnEntryDateChanged();
        partial void OnCompanyIdChanging(string value);
        partial void OnCompanyIdChanged();
        partial void OnIsValidatedChanging(System.Nullable<bool> value);
        partial void OnIsValidatedChanged();
        partial void OnoTotalChanging(System.Nullable<decimal> value);
        partial void OnoTotalChanged();
        partial void OnoCurrencyChanging(string value);
        partial void OnoCurrencyChanged();
        partial void OnoPeriodeChanging(string value);
        partial void OnoPeriodeChanged();
        #endregion

        public Payment()
        {
            this._LinePayments = new EntitySet<LinePayment>(new Action<LinePayment>(this.attach_LinePayments), new Action<LinePayment>(this.detach_LinePayments));
            this._Company = default(EntityRef<Company>);
            this._Supplier = default(EntityRef<Supplier>);
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    this.OnidChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("id");
                    this.OnidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oid", DbType = "Int NOT NULL")]
        public int oid
        {
            get
            {
                return this._oid;
            }
            set
            {
                if ((this._oid != value))
                {
                    this.OnoidChanging(value);
                    this.SendPropertyChanging();
                    this._oid = value;
                    this.SendPropertyChanged("oid");
                    this.OnoidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CostCenter", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CostCenter
        {
            get
            {
                return this._CostCenter;
            }
            set
            {
                if ((this._CostCenter != value))
                {
                    this.OnCostCenterChanging(value);
                    this.SendPropertyChanging();
                    this._CostCenter = value;
                    this.SendPropertyChanged("CostCenter");
                    this.OnCostCenterChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_account", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string account
        {
            get
            {
                return this._account;
            }
            set
            {
                if ((this._account != value))
                {
                    if (this._Supplier.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnaccountChanging(value);
                    this.SendPropertyChanging();
                    this._account = value;
                    this.SendPropertyChanged("account");
                    this.OnaccountChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_HeaderText", DbType = "NVarChar(250)")]
        public string HeaderText
        {
            get
            {
                return this._HeaderText;
            }
            set
            {
                if ((this._HeaderText != value))
                {
                    this.OnHeaderTextChanging(value);
                    this.SendPropertyChanging();
                    this._HeaderText = value;
                    this.SendPropertyChanged("HeaderText");
                    this.OnHeaderTextChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TransDate", DbType = "Date NOT NULL")]
        public System.DateTime TransDate
        {
            get
            {
                return this._TransDate;
            }
            set
            {
                if ((this._TransDate != value))
                {
                    this.OnTransDateChanging(value);
                    this.SendPropertyChanging();
                    this._TransDate = value;
                    this.SendPropertyChanged("TransDate");
                    this.OnTransDateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ItemDate", DbType = "Date NOT NULL")]
        public System.DateTime ItemDate
        {
            get
            {
                return this._ItemDate;
            }
            set
            {
                if ((this._ItemDate != value))
                {
                    this.OnItemDateChanging(value);
                    this.SendPropertyChanging();
                    this._ItemDate = value;
                    this.SendPropertyChanged("ItemDate");
                    this.OnItemDateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_EntryDate", DbType = "Date NOT NULL")]
        public System.DateTime EntryDate
        {
            get
            {
                return this._EntryDate;
            }
            set
            {
                if ((this._EntryDate != value))
                {
                    this.OnEntryDateChanging(value);
                    this.SendPropertyChanging();
                    this._EntryDate = value;
                    this.SendPropertyChanged("EntryDate");
                    this.OnEntryDateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyId", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CompanyId
        {
            get
            {
                return this._CompanyId;
            }
            set
            {
                if ((this._CompanyId != value))
                {
                    if (this._Company.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnCompanyIdChanging(value);
                    this.SendPropertyChanging();
                    this._CompanyId = value;
                    this.SendPropertyChanged("CompanyId");
                    this.OnCompanyIdChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IsValidated", DbType = "Bit")]
        public System.Nullable<bool> IsValidated
        {
            get
            {
                return this._IsValidated;
            }
            set
            {
                if ((this._IsValidated != value))
                {
                    this.OnIsValidatedChanging(value);
                    this.SendPropertyChanging();
                    this._IsValidated = value;
                    this.SendPropertyChanged("IsValidated");
                    this.OnIsValidatedChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oTotal", AutoSync = AutoSync.Always, DbType = "Money", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<decimal> oTotal
        {
            get
            {
                return this._oTotal;
            }
            set
            {
                if ((this._oTotal != value))
                {
                    this.OnoTotalChanging(value);
                    this.SendPropertyChanging();
                    this._oTotal = value;
                    this.SendPropertyChanged("oTotal");
                    this.OnoTotalChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oCurrency", AutoSync = AutoSync.Always, DbType = "NVarChar(10)", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public string oCurrency
        {
            get
            {
                return this._oCurrency;
            }
            set
            {
                if ((this._oCurrency != value))
                {
                    this.OnoCurrencyChanging(value);
                    this.SendPropertyChanging();
                    this._oCurrency = value;
                    this.SendPropertyChanged("oCurrency");
                    this.OnoCurrencyChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oPeriode", AutoSync = AutoSync.Always, DbType = "NVarChar(6)", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public string oPeriode
        {
            get
            {
                return this._oPeriode;
            }
            set
            {
                if ((this._oPeriode != value))
                {
                    this.OnoPeriodeChanging(value);
                    this.SendPropertyChanging();
                    this._oPeriode = value;
                    this.SendPropertyChanged("oPeriode");
                    this.OnoPeriodeChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Payment_LinePayment", Storage = "_LinePayments", ThisKey = "id", OtherKey = "transid")]
        public EntitySet<LinePayment> LinePayments
        {
            get
            {
                return this._LinePayments;
            }
            set
            {
                this._LinePayments.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Company_Payment", Storage = "_Company", ThisKey = "CompanyId", OtherKey = "id", IsForeignKey = true)]
        public Company Company
        {
            get
            {
                return this._Company.Entity;
            }
            set
            {
                Company previousValue = this._Company.Entity;
                if (((previousValue != value)
                            || (this._Company.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Company.Entity = null;
                        previousValue.Payments.Remove(this);
                    }
                    this._Company.Entity = value;
                    if ((value != null))
                    {
                        value.Payments.Add(this);
                        this._CompanyId = value.id;
                    }
                    else
                    {
                        this._CompanyId = default(string);
                    }
                    this.SendPropertyChanged("Company");
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Supplier_Payment", Storage = "_Supplier", ThisKey = "account", OtherKey = "id", IsForeignKey = true)]
        public Supplier Supplier
        {
            get
            {
                return this._Supplier.Entity;
            }
            set
            {
                Supplier previousValue = this._Supplier.Entity;
                if (((previousValue != value)
                            || (this._Supplier.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Supplier.Entity = null;
                        previousValue.Payments.Remove(this);
                    }
                    this._Supplier.Entity = value;
                    if ((value != null))
                    {
                        value.Payments.Add(this);
                        this._account = value.id;
                    }
                    else
                    {
                        this._account = default(string);
                    }
                    this.SendPropertyChanged("Supplier");
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void attach_LinePayments(LinePayment entity)
        {
            this.SendPropertyChanging();
            entity.Payment = this;
        }

        private void detach_LinePayments(LinePayment entity)
        {
            this.SendPropertyChanging();
            entity.Payment = null;
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.PeriodicAccountBalance")]
    public partial class PeriodicAccountBalance : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _Id;

        private string _Name;

        private string _Description;

        private string _AccountId;

        private string _Periode;

        private decimal _Debit;

        private decimal _Credit;

        private string _CompanyID;

        private string _Currency;

        private EntityRef<Account> _Account;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIdChanging(int value);
        partial void OnIdChanged();
        partial void OnNameChanging(string value);
        partial void OnNameChanged();
        partial void OnDescriptionChanging(string value);
        partial void OnDescriptionChanged();
        partial void OnAccountIdChanging(string value);
        partial void OnAccountIdChanged();
        partial void OnPeriodeChanging(string value);
        partial void OnPeriodeChanged();
        partial void OnDebitChanging(decimal value);
        partial void OnDebitChanged();
        partial void OnCreditChanging(decimal value);
        partial void OnCreditChanged();
        partial void OnCompanyIDChanging(string value);
        partial void OnCompanyIDChanged();
        partial void OnCurrencyChanging(string value);
        partial void OnCurrencyChanged();
        #endregion

        public PeriodicAccountBalance()
        {
            this._Account = default(EntityRef<Account>);
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Id", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                if ((this._Id != value))
                {
                    this.OnIdChanging(value);
                    this.SendPropertyChanging();
                    this._Id = value;
                    this.SendPropertyChanged("Id");
                    this.OnIdChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Name", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                if ((this._Name != value))
                {
                    this.OnNameChanging(value);
                    this.SendPropertyChanging();
                    this._Name = value;
                    this.SendPropertyChanged("Name");
                    this.OnNameChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Description", DbType = "NChar(10)")]
        public string Description
        {
            get
            {
                return this._Description;
            }
            set
            {
                if ((this._Description != value))
                {
                    this.OnDescriptionChanging(value);
                    this.SendPropertyChanging();
                    this._Description = value;
                    this.SendPropertyChanged("Description");
                    this.OnDescriptionChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_AccountId", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string AccountId
        {
            get
            {
                return this._AccountId;
            }
            set
            {
                if ((this._AccountId != value))
                {
                    if (this._Account.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnAccountIdChanging(value);
                    this.SendPropertyChanging();
                    this._AccountId = value;
                    this.SendPropertyChanged("AccountId");
                    this.OnAccountIdChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Periode", DbType = "NChar(6) NOT NULL", CanBeNull = false)]
        public string Periode
        {
            get
            {
                return this._Periode;
            }
            set
            {
                if ((this._Periode != value))
                {
                    this.OnPeriodeChanging(value);
                    this.SendPropertyChanging();
                    this._Periode = value;
                    this.SendPropertyChanged("Periode");
                    this.OnPeriodeChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Debit", DbType = "Decimal(18,2) NOT NULL")]
        public decimal Debit
        {
            get
            {
                return this._Debit;
            }
            set
            {
                if ((this._Debit != value))
                {
                    this.OnDebitChanging(value);
                    this.SendPropertyChanging();
                    this._Debit = value;
                    this.SendPropertyChanged("Debit");
                    this.OnDebitChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Credit", DbType = "Decimal(18,2) NOT NULL")]
        public decimal Credit
        {
            get
            {
                return this._Credit;
            }
            set
            {
                if ((this._Credit != value))
                {
                    this.OnCreditChanging(value);
                    this.SendPropertyChanging();
                    this._Credit = value;
                    this.SendPropertyChanged("Credit");
                    this.OnCreditChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string CompanyID
        {
            get
            {
                return this._CompanyID;
            }
            set
            {
                if ((this._CompanyID != value))
                {
                    this.OnCompanyIDChanging(value);
                    this.SendPropertyChanging();
                    this._CompanyID = value;
                    this.SendPropertyChanged("CompanyID");
                    this.OnCompanyIDChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Currency", DbType = "NVarChar(10) NOT NULL", CanBeNull = false)]
        public string Currency
        {
            get
            {
                return this._Currency;
            }
            set
            {
                if ((this._Currency != value))
                {
                    this.OnCurrencyChanging(value);
                    this.SendPropertyChanging();
                    this._Currency = value;
                    this.SendPropertyChanged("Currency");
                    this.OnCurrencyChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Account_PeriodicAccountBalance", Storage = "_Account", ThisKey = "AccountId", OtherKey = "id", IsForeignKey = true)]
        public Account Account
        {
            get
            {
                return this._Account.Entity;
            }
            set
            {
                Account previousValue = this._Account.Entity;
                if (((previousValue != value)
                            || (this._Account.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Account.Entity = null;
                        previousValue.PeriodicAccountBalances.Remove(this);
                    }
                    this._Account.Entity = value;
                    if ((value != null))
                    {
                        value.PeriodicAccountBalances.Add(this);
                        this._AccountId = value.id;
                    }
                    else
                    {
                        this._AccountId = default(string);
                    }
                    this.SendPropertyChanged("Account");
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.PurchaseOrder")]
    public partial class PurchaseOrder : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _id;

        private string _store;

        private string _account;

        private string _HeaderText;

        private System.DateTime _TransDate;

        private System.DateTime _ItemDate;

        private System.DateTime _EntryDate;

        private string _ShippingTerms;

        private string _CompanyId;

        private bool _IsValidated;

        private System.Nullable<decimal> _oTotal;

        private System.Nullable<decimal> _oVat;

        private string _oCurrency;

        private string _oPeriode;

        private System.Nullable<decimal> _oNet;

        private EntitySet<LinePurchaseOrder> _LinePurchaseOrders;

        private EntityRef<Company> _Company;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnidChanging(int value);
        partial void OnidChanged();
        partial void OnstoreChanging(string value);
        partial void OnstoreChanged();
        partial void OnaccountChanging(string value);
        partial void OnaccountChanged();
        partial void OnHeaderTextChanging(string value);
        partial void OnHeaderTextChanged();
        partial void OnTransDateChanging(System.DateTime value);
        partial void OnTransDateChanged();
        partial void OnItemDateChanging(System.DateTime value);
        partial void OnItemDateChanged();
        partial void OnEntryDateChanging(System.DateTime value);
        partial void OnEntryDateChanged();
        partial void OnShippingTermsChanging(string value);
        partial void OnShippingTermsChanged();
        partial void OnCompanyIdChanging(string value);
        partial void OnCompanyIdChanged();
        partial void OnIsValidatedChanging(bool value);
        partial void OnIsValidatedChanged();
        partial void OnoTotalChanging(System.Nullable<decimal> value);
        partial void OnoTotalChanged();
        partial void OnoVatChanging(System.Nullable<decimal> value);
        partial void OnoVatChanged();
        partial void OnoCurrencyChanging(string value);
        partial void OnoCurrencyChanged();
        partial void OnoPeriodeChanging(string value);
        partial void OnoPeriodeChanged();
        partial void OnoNetChanging(System.Nullable<decimal> value);
        partial void OnoNetChanged();
        #endregion

        public PurchaseOrder()
        {
            this._LinePurchaseOrders = new EntitySet<LinePurchaseOrder>(new Action<LinePurchaseOrder>(this.attach_LinePurchaseOrders), new Action<LinePurchaseOrder>(this.detach_LinePurchaseOrders));
            this._Company = default(EntityRef<Company>);
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    this.OnidChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("id");
                    this.OnidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_store", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
        public string store
        {
            get
            {
                return this._store;
            }
            set
            {
                if ((this._store != value))
                {
                    this.OnstoreChanging(value);
                    this.SendPropertyChanging();
                    this._store = value;
                    this.SendPropertyChanged("store");
                    this.OnstoreChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_account", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
        public string account
        {
            get
            {
                return this._account;
            }
            set
            {
                if ((this._account != value))
                {
                    this.OnaccountChanging(value);
                    this.SendPropertyChanging();
                    this._account = value;
                    this.SendPropertyChanged("account");
                    this.OnaccountChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_HeaderText", DbType = "NVarChar(250) NOT NULL", CanBeNull = false)]
        public string HeaderText
        {
            get
            {
                return this._HeaderText;
            }
            set
            {
                if ((this._HeaderText != value))
                {
                    this.OnHeaderTextChanging(value);
                    this.SendPropertyChanging();
                    this._HeaderText = value;
                    this.SendPropertyChanged("HeaderText");
                    this.OnHeaderTextChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TransDate", DbType = "Date NOT NULL")]
        public System.DateTime TransDate
        {
            get
            {
                return this._TransDate;
            }
            set
            {
                if ((this._TransDate != value))
                {
                    this.OnTransDateChanging(value);
                    this.SendPropertyChanging();
                    this._TransDate = value;
                    this.SendPropertyChanged("TransDate");
                    this.OnTransDateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ItemDate", DbType = "Date NOT NULL")]
        public System.DateTime ItemDate
        {
            get
            {
                return this._ItemDate;
            }
            set
            {
                if ((this._ItemDate != value))
                {
                    this.OnItemDateChanging(value);
                    this.SendPropertyChanging();
                    this._ItemDate = value;
                    this.SendPropertyChanged("ItemDate");
                    this.OnItemDateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_EntryDate", DbType = "Date NOT NULL")]
        public System.DateTime EntryDate
        {
            get
            {
                return this._EntryDate;
            }
            set
            {
                if ((this._EntryDate != value))
                {
                    this.OnEntryDateChanging(value);
                    this.SendPropertyChanging();
                    this._EntryDate = value;
                    this.SendPropertyChanged("EntryDate");
                    this.OnEntryDateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ShippingTerms", DbType = "NVarChar(255)")]
        public string ShippingTerms
        {
            get
            {
                return this._ShippingTerms;
            }
            set
            {
                if ((this._ShippingTerms != value))
                {
                    this.OnShippingTermsChanging(value);
                    this.SendPropertyChanging();
                    this._ShippingTerms = value;
                    this.SendPropertyChanged("ShippingTerms");
                    this.OnShippingTermsChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyId", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CompanyId
        {
            get
            {
                return this._CompanyId;
            }
            set
            {
                if ((this._CompanyId != value))
                {
                    if (this._Company.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnCompanyIdChanging(value);
                    this.SendPropertyChanging();
                    this._CompanyId = value;
                    this.SendPropertyChanged("CompanyId");
                    this.OnCompanyIdChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IsValidated", DbType = "Bit NOT NULL")]
        public bool IsValidated
        {
            get
            {
                return this._IsValidated;
            }
            set
            {
                if ((this._IsValidated != value))
                {
                    this.OnIsValidatedChanging(value);
                    this.SendPropertyChanging();
                    this._IsValidated = value;
                    this.SendPropertyChanged("IsValidated");
                    this.OnIsValidatedChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oTotal", AutoSync = AutoSync.Always, DbType = "Money", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<decimal> oTotal
        {
            get
            {
                return this._oTotal;
            }
            set
            {
                if ((this._oTotal != value))
                {
                    this.OnoTotalChanging(value);
                    this.SendPropertyChanging();
                    this._oTotal = value;
                    this.SendPropertyChanged("oTotal");
                    this.OnoTotalChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oVat", AutoSync = AutoSync.Always, DbType = "Money", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<decimal> oVat
        {
            get
            {
                return this._oVat;
            }
            set
            {
                if ((this._oVat != value))
                {
                    this.OnoVatChanging(value);
                    this.SendPropertyChanging();
                    this._oVat = value;
                    this.SendPropertyChanged("oVat");
                    this.OnoVatChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oCurrency", AutoSync = AutoSync.Always, DbType = "Char(10)", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public string oCurrency
        {
            get
            {
                return this._oCurrency;
            }
            set
            {
                if ((this._oCurrency != value))
                {
                    this.OnoCurrencyChanging(value);
                    this.SendPropertyChanging();
                    this._oCurrency = value;
                    this.SendPropertyChanged("oCurrency");
                    this.OnoCurrencyChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oPeriode", AutoSync = AutoSync.Always, DbType = "NVarChar(6)", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public string oPeriode
        {
            get
            {
                return this._oPeriode;
            }
            set
            {
                if ((this._oPeriode != value))
                {
                    this.OnoPeriodeChanging(value);
                    this.SendPropertyChanging();
                    this._oPeriode = value;
                    this.SendPropertyChanged("oPeriode");
                    this.OnoPeriodeChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oNet", AutoSync = AutoSync.Always, DbType = "Money", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<decimal> oNet
        {
            get
            {
                return this._oNet;
            }
            set
            {
                if ((this._oNet != value))
                {
                    this.OnoNetChanging(value);
                    this.SendPropertyChanging();
                    this._oNet = value;
                    this.SendPropertyChanged("oNet");
                    this.OnoNetChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "PurchaseOrder_LinePurchaseOrder", Storage = "_LinePurchaseOrders", ThisKey = "id", OtherKey = "transid")]
        public EntitySet<LinePurchaseOrder> LinePurchaseOrders
        {
            get
            {
                return this._LinePurchaseOrders;
            }
            set
            {
                this._LinePurchaseOrders.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Company_PurchaseOrder", Storage = "_Company", ThisKey = "CompanyId", OtherKey = "id", IsForeignKey = true)]
        public Company Company
        {
            get
            {
                return this._Company.Entity;
            }
            set
            {
                Company previousValue = this._Company.Entity;
                if (((previousValue != value)
                            || (this._Company.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Company.Entity = null;
                        previousValue.PurchaseOrders.Remove(this);
                    }
                    this._Company.Entity = value;
                    if ((value != null))
                    {
                        value.PurchaseOrders.Add(this);
                        this._CompanyId = value.id;
                    }
                    else
                    {
                        this._CompanyId = default(string);
                    }
                    this.SendPropertyChanged("Company");
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void attach_LinePurchaseOrders(LinePurchaseOrder entity)
        {
            this.SendPropertyChanging();
            entity.PurchaseOrder = this;
        }

        private void detach_LinePurchaseOrders(LinePurchaseOrder entity)
        {
            this.SendPropertyChanging();
            entity.PurchaseOrder = null;
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.QuantityUnit")]
    public partial class QuantityUnit : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _id;

        private string _name;

        private string _description;

        private string _CompanyID;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnidChanging(string value);
        partial void OnidChanged();
        partial void OnnameChanging(string value);
        partial void OnnameChanged();
        partial void OndescriptionChanging(string value);
        partial void OndescriptionChanged();
        partial void OnCompanyIDChanging(string value);
        partial void OnCompanyIDChanged();
        #endregion

        public QuantityUnit()
        {
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id", DbType = "NVarChar(50) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    this.OnidChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("id");
                    this.OnidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_name", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string name
        {
            get
            {
                return this._name;
            }
            set
            {
                if ((this._name != value))
                {
                    this.OnnameChanging(value);
                    this.SendPropertyChanging();
                    this._name = value;
                    this.SendPropertyChanged("name");
                    this.OnnameChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_description", DbType = "NVarChar(255)")]
        public string description
        {
            get
            {
                return this._description;
            }
            set
            {
                if ((this._description != value))
                {
                    this.OndescriptionChanging(value);
                    this.SendPropertyChanging();
                    this._description = value;
                    this.SendPropertyChanged("description");
                    this.OndescriptionChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CompanyID
        {
            get
            {
                return this._CompanyID;
            }
            set
            {
                if ((this._CompanyID != value))
                {
                    this.OnCompanyIDChanging(value);
                    this.SendPropertyChanging();
                    this._CompanyID = value;
                    this.SendPropertyChanged("CompanyID");
                    this.OnCompanyIDChanged();
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.SalesInvoice")]
    public partial class SalesInvoice : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _id;

        private int _oid;

        private string _store;

        private string _account;

        private string _HeaderText;

        private System.DateTime _TransDate;

        private System.DateTime _ItemDate;

        private System.DateTime _EntryDate;

        private string _CompanyId;

        private bool _IsValidated;

        private System.Nullable<decimal> _oTotal;

        private System.Nullable<decimal> _oVat;

        private string _oCurrency;

        private string _oPeriode;

        private System.Nullable<decimal> _oNet;

        private EntitySet<LineSalesInvoice> _LineSalesInvoices;

        private EntityRef<Company> _Company;

        private EntityRef<Customer> _Customer;

        private EntityRef<Store> _Store1;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnidChanging(int value);
        partial void OnidChanged();
        partial void OnoidChanging(int value);
        partial void OnoidChanged();
        partial void OnstoreChanging(string value);
        partial void OnstoreChanged();
        partial void OnaccountChanging(string value);
        partial void OnaccountChanged();
        partial void OnHeaderTextChanging(string value);
        partial void OnHeaderTextChanged();
        partial void OnTransDateChanging(System.DateTime value);
        partial void OnTransDateChanged();
        partial void OnItemDateChanging(System.DateTime value);
        partial void OnItemDateChanged();
        partial void OnEntryDateChanging(System.DateTime value);
        partial void OnEntryDateChanged();
        partial void OnCompanyIdChanging(string value);
        partial void OnCompanyIdChanged();
        partial void OnIsValidatedChanging(bool value);
        partial void OnIsValidatedChanged();
        partial void OnoTotalChanging(System.Nullable<decimal> value);
        partial void OnoTotalChanged();
        partial void OnoVatChanging(System.Nullable<decimal> value);
        partial void OnoVatChanged();
        partial void OnoCurrencyChanging(string value);
        partial void OnoCurrencyChanged();
        partial void OnoPeriodeChanging(string value);
        partial void OnoPeriodeChanged();
        partial void OnoNetChanging(System.Nullable<decimal> value);
        partial void OnoNetChanged();
        #endregion

        public SalesInvoice()
        {
            this._LineSalesInvoices = new EntitySet<LineSalesInvoice>(new Action<LineSalesInvoice>(this.attach_LineSalesInvoices), new Action<LineSalesInvoice>(this.detach_LineSalesInvoices));
            this._Company = default(EntityRef<Company>);
            this._Customer = default(EntityRef<Customer>);
            this._Store1 = default(EntityRef<Store>);
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    this.OnidChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("id");
                    this.OnidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oid", DbType = "Int NOT NULL")]
        public int oid
        {
            get
            {
                return this._oid;
            }
            set
            {
                if ((this._oid != value))
                {
                    this.OnoidChanging(value);
                    this.SendPropertyChanging();
                    this._oid = value;
                    this.SendPropertyChanged("oid");
                    this.OnoidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_store", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string store
        {
            get
            {
                return this._store;
            }
            set
            {
                if ((this._store != value))
                {
                    if (this._Store1.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnstoreChanging(value);
                    this.SendPropertyChanging();
                    this._store = value;
                    this.SendPropertyChanged("store");
                    this.OnstoreChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_account", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string account
        {
            get
            {
                return this._account;
            }
            set
            {
                if ((this._account != value))
                {
                    if (this._Customer.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnaccountChanging(value);
                    this.SendPropertyChanging();
                    this._account = value;
                    this.SendPropertyChanged("account");
                    this.OnaccountChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_HeaderText", DbType = "NVarChar(250) NOT NULL", CanBeNull = false)]
        public string HeaderText
        {
            get
            {
                return this._HeaderText;
            }
            set
            {
                if ((this._HeaderText != value))
                {
                    this.OnHeaderTextChanging(value);
                    this.SendPropertyChanging();
                    this._HeaderText = value;
                    this.SendPropertyChanged("HeaderText");
                    this.OnHeaderTextChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TransDate", DbType = "Date NOT NULL")]
        public System.DateTime TransDate
        {
            get
            {
                return this._TransDate;
            }
            set
            {
                if ((this._TransDate != value))
                {
                    this.OnTransDateChanging(value);
                    this.SendPropertyChanging();
                    this._TransDate = value;
                    this.SendPropertyChanged("TransDate");
                    this.OnTransDateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ItemDate", DbType = "Date NOT NULL")]
        public System.DateTime ItemDate
        {
            get
            {
                return this._ItemDate;
            }
            set
            {
                if ((this._ItemDate != value))
                {
                    this.OnItemDateChanging(value);
                    this.SendPropertyChanging();
                    this._ItemDate = value;
                    this.SendPropertyChanged("ItemDate");
                    this.OnItemDateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_EntryDate", DbType = "Date NOT NULL")]
        public System.DateTime EntryDate
        {
            get
            {
                return this._EntryDate;
            }
            set
            {
                if ((this._EntryDate != value))
                {
                    this.OnEntryDateChanging(value);
                    this.SendPropertyChanging();
                    this._EntryDate = value;
                    this.SendPropertyChanged("EntryDate");
                    this.OnEntryDateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyId", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CompanyId
        {
            get
            {
                return this._CompanyId;
            }
            set
            {
                if ((this._CompanyId != value))
                {
                    if (this._Company.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnCompanyIdChanging(value);
                    this.SendPropertyChanging();
                    this._CompanyId = value;
                    this.SendPropertyChanged("CompanyId");
                    this.OnCompanyIdChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IsValidated", DbType = "Bit NOT NULL")]
        public bool IsValidated
        {
            get
            {
                return this._IsValidated;
            }
            set
            {
                if ((this._IsValidated != value))
                {
                    this.OnIsValidatedChanging(value);
                    this.SendPropertyChanging();
                    this._IsValidated = value;
                    this.SendPropertyChanged("IsValidated");
                    this.OnIsValidatedChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oTotal", AutoSync = AutoSync.Always, DbType = "Money", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<decimal> oTotal
        {
            get
            {
                return this._oTotal;
            }
            set
            {
                if ((this._oTotal != value))
                {
                    this.OnoTotalChanging(value);
                    this.SendPropertyChanging();
                    this._oTotal = value;
                    this.SendPropertyChanged("oTotal");
                    this.OnoTotalChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oVat", AutoSync = AutoSync.Always, DbType = "Money", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<decimal> oVat
        {
            get
            {
                return this._oVat;
            }
            set
            {
                if ((this._oVat != value))
                {
                    this.OnoVatChanging(value);
                    this.SendPropertyChanging();
                    this._oVat = value;
                    this.SendPropertyChanged("oVat");
                    this.OnoVatChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oCurrency", AutoSync = AutoSync.Always, DbType = "NVarChar(10)", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public string oCurrency
        {
            get
            {
                return this._oCurrency;
            }
            set
            {
                if ((this._oCurrency != value))
                {
                    this.OnoCurrencyChanging(value);
                    this.SendPropertyChanging();
                    this._oCurrency = value;
                    this.SendPropertyChanged("oCurrency");
                    this.OnoCurrencyChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oPeriode", AutoSync = AutoSync.Always, DbType = "NVarChar(6)", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public string oPeriode
        {
            get
            {
                return this._oPeriode;
            }
            set
            {
                if ((this._oPeriode != value))
                {
                    this.OnoPeriodeChanging(value);
                    this.SendPropertyChanging();
                    this._oPeriode = value;
                    this.SendPropertyChanged("oPeriode");
                    this.OnoPeriodeChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oNet", AutoSync = AutoSync.Always, DbType = "Money", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<decimal> oNet
        {
            get
            {
                return this._oNet;
            }
            set
            {
                if ((this._oNet != value))
                {
                    this.OnoNetChanging(value);
                    this.SendPropertyChanging();
                    this._oNet = value;
                    this.SendPropertyChanged("oNet");
                    this.OnoNetChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "SalesInvoice_LineSalesInvoice", Storage = "_LineSalesInvoices", ThisKey = "id", OtherKey = "transid")]
        public EntitySet<LineSalesInvoice> LineSalesInvoices
        {
            get
            {
                return this._LineSalesInvoices;
            }
            set
            {
                this._LineSalesInvoices.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Company_SalesInvoice", Storage = "_Company", ThisKey = "CompanyId", OtherKey = "id", IsForeignKey = true)]
        public Company Company
        {
            get
            {
                return this._Company.Entity;
            }
            set
            {
                Company previousValue = this._Company.Entity;
                if (((previousValue != value)
                            || (this._Company.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Company.Entity = null;
                        previousValue.SalesInvoices.Remove(this);
                    }
                    this._Company.Entity = value;
                    if ((value != null))
                    {
                        value.SalesInvoices.Add(this);
                        this._CompanyId = value.id;
                    }
                    else
                    {
                        this._CompanyId = default(string);
                    }
                    this.SendPropertyChanged("Company");
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Customer_SalesInvoice", Storage = "_Customer", ThisKey = "account", OtherKey = "id", IsForeignKey = true)]
        public Customer Customer
        {
            get
            {
                return this._Customer.Entity;
            }
            set
            {
                Customer previousValue = this._Customer.Entity;
                if (((previousValue != value)
                            || (this._Customer.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Customer.Entity = null;
                        previousValue.SalesInvoices.Remove(this);
                    }
                    this._Customer.Entity = value;
                    if ((value != null))
                    {
                        value.SalesInvoices.Add(this);
                        this._account = value.id;
                    }
                    else
                    {
                        this._account = default(string);
                    }
                    this.SendPropertyChanged("Customer");
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Store_SalesInvoice", Storage = "_Store1", ThisKey = "store", OtherKey = "id", IsForeignKey = true)]
        public Store Store1
        {
            get
            {
                return this._Store1.Entity;
            }
            set
            {
                Store previousValue = this._Store1.Entity;
                if (((previousValue != value)
                            || (this._Store1.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Store1.Entity = null;
                        previousValue.SalesInvoices.Remove(this);
                    }
                    this._Store1.Entity = value;
                    if ((value != null))
                    {
                        value.SalesInvoices.Add(this);
                        this._store = value.id;
                    }
                    else
                    {
                        this._store = default(string);
                    }
                    this.SendPropertyChanged("Store1");
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void attach_LineSalesInvoices(LineSalesInvoice entity)
        {
            this.SendPropertyChanging();
            entity.SalesInvoice = this;
        }

        private void detach_LineSalesInvoices(LineSalesInvoice entity)
        {
            this.SendPropertyChanging();
            entity.SalesInvoice = null;
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.SalesOrder")]
    public partial class SalesOrder : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _id;

        private string _store;

        private string _account;

        private string _HeaderText;

        private System.DateTime _TransDate;

        private System.DateTime _ItemDate;

        private System.DateTime _EntryDate;

        private string _DeliveryTerms;

        private string _CompanyId;

        private bool _IsValidated;

        private System.Nullable<decimal> _oTotal;

        private System.Nullable<decimal> _oVat;

        private string _oCurrency;

        private string _oPeriode;

        private System.Nullable<decimal> _oNet;

        private EntitySet<LineSalesOrder> _LineSalesOrders;

        private EntityRef<Company> _Company;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnidChanging(int value);
        partial void OnidChanged();
        partial void OnstoreChanging(string value);
        partial void OnstoreChanged();
        partial void OnaccountChanging(string value);
        partial void OnaccountChanged();
        partial void OnHeaderTextChanging(string value);
        partial void OnHeaderTextChanged();
        partial void OnTransDateChanging(System.DateTime value);
        partial void OnTransDateChanged();
        partial void OnItemDateChanging(System.DateTime value);
        partial void OnItemDateChanged();
        partial void OnEntryDateChanging(System.DateTime value);
        partial void OnEntryDateChanged();
        partial void OnDeliveryTermsChanging(string value);
        partial void OnDeliveryTermsChanged();
        partial void OnCompanyIdChanging(string value);
        partial void OnCompanyIdChanged();
        partial void OnIsValidatedChanging(bool value);
        partial void OnIsValidatedChanged();
        partial void OnoTotalChanging(System.Nullable<decimal> value);
        partial void OnoTotalChanged();
        partial void OnoVatChanging(System.Nullable<decimal> value);
        partial void OnoVatChanged();
        partial void OnoCurrencyChanging(string value);
        partial void OnoCurrencyChanged();
        partial void OnoPeriodeChanging(string value);
        partial void OnoPeriodeChanged();
        partial void OnoNetChanging(System.Nullable<decimal> value);
        partial void OnoNetChanged();
        #endregion

        public SalesOrder()
        {
            this._LineSalesOrders = new EntitySet<LineSalesOrder>(new Action<LineSalesOrder>(this.attach_LineSalesOrders), new Action<LineSalesOrder>(this.detach_LineSalesOrders));
            this._Company = default(EntityRef<Company>);
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    this.OnidChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("id");
                    this.OnidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_store", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
        public string store
        {
            get
            {
                return this._store;
            }
            set
            {
                if ((this._store != value))
                {
                    this.OnstoreChanging(value);
                    this.SendPropertyChanging();
                    this._store = value;
                    this.SendPropertyChanged("store");
                    this.OnstoreChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_account", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
        public string account
        {
            get
            {
                return this._account;
            }
            set
            {
                if ((this._account != value))
                {
                    this.OnaccountChanging(value);
                    this.SendPropertyChanging();
                    this._account = value;
                    this.SendPropertyChanged("account");
                    this.OnaccountChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_HeaderText", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
        public string HeaderText
        {
            get
            {
                return this._HeaderText;
            }
            set
            {
                if ((this._HeaderText != value))
                {
                    this.OnHeaderTextChanging(value);
                    this.SendPropertyChanging();
                    this._HeaderText = value;
                    this.SendPropertyChanged("HeaderText");
                    this.OnHeaderTextChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TransDate", DbType = "Date NOT NULL")]
        public System.DateTime TransDate
        {
            get
            {
                return this._TransDate;
            }
            set
            {
                if ((this._TransDate != value))
                {
                    this.OnTransDateChanging(value);
                    this.SendPropertyChanging();
                    this._TransDate = value;
                    this.SendPropertyChanged("TransDate");
                    this.OnTransDateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ItemDate", DbType = "Date NOT NULL")]
        public System.DateTime ItemDate
        {
            get
            {
                return this._ItemDate;
            }
            set
            {
                if ((this._ItemDate != value))
                {
                    this.OnItemDateChanging(value);
                    this.SendPropertyChanging();
                    this._ItemDate = value;
                    this.SendPropertyChanged("ItemDate");
                    this.OnItemDateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_EntryDate", DbType = "Date NOT NULL")]
        public System.DateTime EntryDate
        {
            get
            {
                return this._EntryDate;
            }
            set
            {
                if ((this._EntryDate != value))
                {
                    this.OnEntryDateChanging(value);
                    this.SendPropertyChanging();
                    this._EntryDate = value;
                    this.SendPropertyChanged("EntryDate");
                    this.OnEntryDateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_DeliveryTerms", DbType = "NVarChar(250)")]
        public string DeliveryTerms
        {
            get
            {
                return this._DeliveryTerms;
            }
            set
            {
                if ((this._DeliveryTerms != value))
                {
                    this.OnDeliveryTermsChanging(value);
                    this.SendPropertyChanging();
                    this._DeliveryTerms = value;
                    this.SendPropertyChanged("DeliveryTerms");
                    this.OnDeliveryTermsChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyId", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CompanyId
        {
            get
            {
                return this._CompanyId;
            }
            set
            {
                if ((this._CompanyId != value))
                {
                    if (this._Company.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnCompanyIdChanging(value);
                    this.SendPropertyChanging();
                    this._CompanyId = value;
                    this.SendPropertyChanged("CompanyId");
                    this.OnCompanyIdChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IsValidated", DbType = "Bit NOT NULL")]
        public bool IsValidated
        {
            get
            {
                return this._IsValidated;
            }
            set
            {
                if ((this._IsValidated != value))
                {
                    this.OnIsValidatedChanging(value);
                    this.SendPropertyChanging();
                    this._IsValidated = value;
                    this.SendPropertyChanged("IsValidated");
                    this.OnIsValidatedChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oTotal", AutoSync = AutoSync.Always, DbType = "Money", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<decimal> oTotal
        {
            get
            {
                return this._oTotal;
            }
            set
            {
                if ((this._oTotal != value))
                {
                    this.OnoTotalChanging(value);
                    this.SendPropertyChanging();
                    this._oTotal = value;
                    this.SendPropertyChanged("oTotal");
                    this.OnoTotalChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oVat", AutoSync = AutoSync.Always, DbType = "Money", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<decimal> oVat
        {
            get
            {
                return this._oVat;
            }
            set
            {
                if ((this._oVat != value))
                {
                    this.OnoVatChanging(value);
                    this.SendPropertyChanging();
                    this._oVat = value;
                    this.SendPropertyChanged("oVat");
                    this.OnoVatChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oCurrency", AutoSync = AutoSync.Always, DbType = "Char(10)", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public string oCurrency
        {
            get
            {
                return this._oCurrency;
            }
            set
            {
                if ((this._oCurrency != value))
                {
                    this.OnoCurrencyChanging(value);
                    this.SendPropertyChanging();
                    this._oCurrency = value;
                    this.SendPropertyChanged("oCurrency");
                    this.OnoCurrencyChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oPeriode", AutoSync = AutoSync.Always, DbType = "NVarChar(6)", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public string oPeriode
        {
            get
            {
                return this._oPeriode;
            }
            set
            {
                if ((this._oPeriode != value))
                {
                    this.OnoPeriodeChanging(value);
                    this.SendPropertyChanging();
                    this._oPeriode = value;
                    this.SendPropertyChanged("oPeriode");
                    this.OnoPeriodeChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oNet", AutoSync = AutoSync.Always, DbType = "Money", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<decimal> oNet
        {
            get
            {
                return this._oNet;
            }
            set
            {
                if ((this._oNet != value))
                {
                    this.OnoNetChanging(value);
                    this.SendPropertyChanging();
                    this._oNet = value;
                    this.SendPropertyChanged("oNet");
                    this.OnoNetChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "SalesOrder_LineSalesOrder", Storage = "_LineSalesOrders", ThisKey = "id", OtherKey = "transid")]
        public EntitySet<LineSalesOrder> LineSalesOrders
        {
            get
            {
                return this._LineSalesOrders;
            }
            set
            {
                this._LineSalesOrders.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Company_SalesOrder", Storage = "_Company", ThisKey = "CompanyId", OtherKey = "id", IsForeignKey = true)]
        public Company Company
        {
            get
            {
                return this._Company.Entity;
            }
            set
            {
                Company previousValue = this._Company.Entity;
                if (((previousValue != value)
                            || (this._Company.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Company.Entity = null;
                        previousValue.SalesOrders.Remove(this);
                    }
                    this._Company.Entity = value;
                    if ((value != null))
                    {
                        value.SalesOrders.Add(this);
                        this._CompanyId = value.id;
                    }
                    else
                    {
                        this._CompanyId = default(string);
                    }
                    this.SendPropertyChanged("Company");
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void attach_LineSalesOrders(LineSalesOrder entity)
        {
            this.SendPropertyChanging();
            entity.SalesOrder = this;
        }

        private void detach_LineSalesOrders(LineSalesOrder entity)
        {
            this.SendPropertyChanging();
            entity.SalesOrder = null;
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.Settlement")]
    public partial class Settlement : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _id;

        private int _oid;

        private string _CostCenter;

        private string _account;

        private string _HeaderText;

        private System.DateTime _TransDate;

        private System.DateTime _ItemDate;

        private System.DateTime _EntryDate;

        private string _CompanyId;

        private bool _IsValidated;

        private System.Nullable<decimal> _oTotal;

        private string _oCurrency;

        private string _oPeriode;

        private EntitySet<LineSettlement> _LineSettlements;

        private EntityRef<Company> _Company;

        private EntityRef<Customer> _Customer;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnidChanging(int value);
        partial void OnidChanged();
        partial void OnoidChanging(int value);
        partial void OnoidChanged();
        partial void OnCostCenterChanging(string value);
        partial void OnCostCenterChanged();
        partial void OnaccountChanging(string value);
        partial void OnaccountChanged();
        partial void OnHeaderTextChanging(string value);
        partial void OnHeaderTextChanged();
        partial void OnTransDateChanging(System.DateTime value);
        partial void OnTransDateChanged();
        partial void OnItemDateChanging(System.DateTime value);
        partial void OnItemDateChanged();
        partial void OnEntryDateChanging(System.DateTime value);
        partial void OnEntryDateChanged();
        partial void OnCompanyIdChanging(string value);
        partial void OnCompanyIdChanged();
        partial void OnIsValidatedChanging(bool value);
        partial void OnIsValidatedChanged();
        partial void OnoTotalChanging(System.Nullable<decimal> value);
        partial void OnoTotalChanged();
        partial void OnoCurrencyChanging(string value);
        partial void OnoCurrencyChanged();
        partial void OnoPeriodeChanging(string value);
        partial void OnoPeriodeChanged();
        #endregion

        public Settlement()
        {
            this._LineSettlements = new EntitySet<LineSettlement>(new Action<LineSettlement>(this.attach_LineSettlements), new Action<LineSettlement>(this.detach_LineSettlements));
            this._Company = default(EntityRef<Company>);
            this._Customer = default(EntityRef<Customer>);
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    this.OnidChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("id");
                    this.OnidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oid", DbType = "Int NOT NULL")]
        public int oid
        {
            get
            {
                return this._oid;
            }
            set
            {
                if ((this._oid != value))
                {
                    this.OnoidChanging(value);
                    this.SendPropertyChanging();
                    this._oid = value;
                    this.SendPropertyChanged("oid");
                    this.OnoidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CostCenter", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CostCenter
        {
            get
            {
                return this._CostCenter;
            }
            set
            {
                if ((this._CostCenter != value))
                {
                    this.OnCostCenterChanging(value);
                    this.SendPropertyChanging();
                    this._CostCenter = value;
                    this.SendPropertyChanged("CostCenter");
                    this.OnCostCenterChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_account", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string account
        {
            get
            {
                return this._account;
            }
            set
            {
                if ((this._account != value))
                {
                    if (this._Customer.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnaccountChanging(value);
                    this.SendPropertyChanging();
                    this._account = value;
                    this.SendPropertyChanged("account");
                    this.OnaccountChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_HeaderText", DbType = "NVarChar(250) NOT NULL", CanBeNull = false)]
        public string HeaderText
        {
            get
            {
                return this._HeaderText;
            }
            set
            {
                if ((this._HeaderText != value))
                {
                    this.OnHeaderTextChanging(value);
                    this.SendPropertyChanging();
                    this._HeaderText = value;
                    this.SendPropertyChanged("HeaderText");
                    this.OnHeaderTextChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TransDate", DbType = "Date NOT NULL")]
        public System.DateTime TransDate
        {
            get
            {
                return this._TransDate;
            }
            set
            {
                if ((this._TransDate != value))
                {
                    this.OnTransDateChanging(value);
                    this.SendPropertyChanging();
                    this._TransDate = value;
                    this.SendPropertyChanged("TransDate");
                    this.OnTransDateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ItemDate", DbType = "Date NOT NULL")]
        public System.DateTime ItemDate
        {
            get
            {
                return this._ItemDate;
            }
            set
            {
                if ((this._ItemDate != value))
                {
                    this.OnItemDateChanging(value);
                    this.SendPropertyChanging();
                    this._ItemDate = value;
                    this.SendPropertyChanged("ItemDate");
                    this.OnItemDateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_EntryDate", DbType = "Date NOT NULL")]
        public System.DateTime EntryDate
        {
            get
            {
                return this._EntryDate;
            }
            set
            {
                if ((this._EntryDate != value))
                {
                    this.OnEntryDateChanging(value);
                    this.SendPropertyChanging();
                    this._EntryDate = value;
                    this.SendPropertyChanged("EntryDate");
                    this.OnEntryDateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyId", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CompanyId
        {
            get
            {
                return this._CompanyId;
            }
            set
            {
                if ((this._CompanyId != value))
                {
                    if (this._Company.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnCompanyIdChanging(value);
                    this.SendPropertyChanging();
                    this._CompanyId = value;
                    this.SendPropertyChanged("CompanyId");
                    this.OnCompanyIdChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IsValidated", DbType = "Bit NOT NULL")]
        public bool IsValidated
        {
            get
            {
                return this._IsValidated;
            }
            set
            {
                if ((this._IsValidated != value))
                {
                    this.OnIsValidatedChanging(value);
                    this.SendPropertyChanging();
                    this._IsValidated = value;
                    this.SendPropertyChanged("IsValidated");
                    this.OnIsValidatedChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oTotal", AutoSync = AutoSync.Always, DbType = "Money", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<decimal> oTotal
        {
            get
            {
                return this._oTotal;
            }
            set
            {
                if ((this._oTotal != value))
                {
                    this.OnoTotalChanging(value);
                    this.SendPropertyChanging();
                    this._oTotal = value;
                    this.SendPropertyChanged("oTotal");
                    this.OnoTotalChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oCurrency", AutoSync = AutoSync.Always, DbType = "NVarChar(10)", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public string oCurrency
        {
            get
            {
                return this._oCurrency;
            }
            set
            {
                if ((this._oCurrency != value))
                {
                    this.OnoCurrencyChanging(value);
                    this.SendPropertyChanging();
                    this._oCurrency = value;
                    this.SendPropertyChanged("oCurrency");
                    this.OnoCurrencyChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_oPeriode", AutoSync = AutoSync.Always, DbType = "NVarChar(6)", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public string oPeriode
        {
            get
            {
                return this._oPeriode;
            }
            set
            {
                if ((this._oPeriode != value))
                {
                    this.OnoPeriodeChanging(value);
                    this.SendPropertyChanging();
                    this._oPeriode = value;
                    this.SendPropertyChanged("oPeriode");
                    this.OnoPeriodeChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Settlement_LineSettlement", Storage = "_LineSettlements", ThisKey = "id", OtherKey = "transid")]
        public EntitySet<LineSettlement> LineSettlements
        {
            get
            {
                return this._LineSettlements;
            }
            set
            {
                this._LineSettlements.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Company_Settlement", Storage = "_Company", ThisKey = "CompanyId", OtherKey = "id", IsForeignKey = true)]
        public Company Company
        {
            get
            {
                return this._Company.Entity;
            }
            set
            {
                Company previousValue = this._Company.Entity;
                if (((previousValue != value)
                            || (this._Company.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Company.Entity = null;
                        previousValue.Settlements.Remove(this);
                    }
                    this._Company.Entity = value;
                    if ((value != null))
                    {
                        value.Settlements.Add(this);
                        this._CompanyId = value.id;
                    }
                    else
                    {
                        this._CompanyId = default(string);
                    }
                    this.SendPropertyChanged("Company");
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Customer_Settlement", Storage = "_Customer", ThisKey = "account", OtherKey = "id", IsForeignKey = true)]
        public Customer Customer
        {
            get
            {
                return this._Customer.Entity;
            }
            set
            {
                Customer previousValue = this._Customer.Entity;
                if (((previousValue != value)
                            || (this._Customer.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Customer.Entity = null;
                        previousValue.Settlements.Remove(this);
                    }
                    this._Customer.Entity = value;
                    if ((value != null))
                    {
                        value.Settlements.Add(this);
                        this._account = value.id;
                    }
                    else
                    {
                        this._account = default(string);
                    }
                    this.SendPropertyChanged("Customer");
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void attach_LineSettlements(LineSettlement entity)
        {
            this.SendPropertyChanging();
            entity.Settlement = this;
        }

        private void detach_LineSettlements(LineSettlement entity)
        {
            this.SendPropertyChanging();
            entity.Settlement = null;
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.Stock")]
    public partial class Stock : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _id;

        private string _name;

        private string _description;

        private string _itemid;

        private string _storeid;

        private float _quantity;

        private short _minstock;

        private string _CompanyID;

        private string _Currency;

        private EntityRef<Article> _Article;

        private EntityRef<Store> _Store;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnidChanging(int value);
        partial void OnidChanged();
        partial void OnnameChanging(string value);
        partial void OnnameChanged();
        partial void OndescriptionChanging(string value);
        partial void OndescriptionChanged();
        partial void OnitemidChanging(string value);
        partial void OnitemidChanged();
        partial void OnstoreidChanging(string value);
        partial void OnstoreidChanged();
        partial void OnquantityChanging(float value);
        partial void OnquantityChanged();
        partial void OnminstockChanging(short value);
        partial void OnminstockChanged();
        partial void OnCompanyIDChanging(string value);
        partial void OnCompanyIDChanged();
        partial void OnCurrencyChanging(string value);
        partial void OnCurrencyChanged();
        #endregion

        public Stock()
        {
            this._Article = default(EntityRef<Article>);
            this._Store = default(EntityRef<Store>);
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    this.OnidChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("id");
                    this.OnidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_name", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string name
        {
            get
            {
                return this._name;
            }
            set
            {
                if ((this._name != value))
                {
                    this.OnnameChanging(value);
                    this.SendPropertyChanging();
                    this._name = value;
                    this.SendPropertyChanged("name");
                    this.OnnameChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_description", DbType = "NVarChar(255)")]
        public string description
        {
            get
            {
                return this._description;
            }
            set
            {
                if ((this._description != value))
                {
                    this.OndescriptionChanging(value);
                    this.SendPropertyChanging();
                    this._description = value;
                    this.SendPropertyChanged("description");
                    this.OndescriptionChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_itemid", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string itemid
        {
            get
            {
                return this._itemid;
            }
            set
            {
                if ((this._itemid != value))
                {
                    if (this._Article.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnitemidChanging(value);
                    this.SendPropertyChanging();
                    this._itemid = value;
                    this.SendPropertyChanged("itemid");
                    this.OnitemidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_storeid", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string storeid
        {
            get
            {
                return this._storeid;
            }
            set
            {
                if ((this._storeid != value))
                {
                    if (this._Store.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnstoreidChanging(value);
                    this.SendPropertyChanging();
                    this._storeid = value;
                    this.SendPropertyChanged("storeid");
                    this.OnstoreidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_quantity", DbType = "Real NOT NULL")]
        public float quantity
        {
            get
            {
                return this._quantity;
            }
            set
            {
                if ((this._quantity != value))
                {
                    this.OnquantityChanging(value);
                    this.SendPropertyChanging();
                    this._quantity = value;
                    this.SendPropertyChanged("quantity");
                    this.OnquantityChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_minstock", DbType = "SmallInt NOT NULL")]
        public short minstock
        {
            get
            {
                return this._minstock;
            }
            set
            {
                if ((this._minstock != value))
                {
                    this.OnminstockChanging(value);
                    this.SendPropertyChanging();
                    this._minstock = value;
                    this.SendPropertyChanged("minstock");
                    this.OnminstockChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CompanyID
        {
            get
            {
                return this._CompanyID;
            }
            set
            {
                if ((this._CompanyID != value))
                {
                    this.OnCompanyIDChanging(value);
                    this.SendPropertyChanging();
                    this._CompanyID = value;
                    this.SendPropertyChanged("CompanyID");
                    this.OnCompanyIDChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Currency", DbType = "NVarChar(10) NOT NULL", CanBeNull = false)]
        public string Currency
        {
            get
            {
                return this._Currency;
            }
            set
            {
                if ((this._Currency != value))
                {
                    this.OnCurrencyChanging(value);
                    this.SendPropertyChanging();
                    this._Currency = value;
                    this.SendPropertyChanged("Currency");
                    this.OnCurrencyChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Article_Stock", Storage = "_Article", ThisKey = "itemid", OtherKey = "id", IsForeignKey = true)]
        public Article Article
        {
            get
            {
                return this._Article.Entity;
            }
            set
            {
                Article previousValue = this._Article.Entity;
                if (((previousValue != value)
                            || (this._Article.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Article.Entity = null;
                        previousValue.Stocks.Remove(this);
                    }
                    this._Article.Entity = value;
                    if ((value != null))
                    {
                        value.Stocks.Add(this);
                        this._itemid = value.id;
                    }
                    else
                    {
                        this._itemid = default(string);
                    }
                    this.SendPropertyChanged("Article");
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Store_Stock", Storage = "_Store", ThisKey = "storeid", OtherKey = "id", IsForeignKey = true)]
        public Store Store
        {
            get
            {
                return this._Store.Entity;
            }
            set
            {
                Store previousValue = this._Store.Entity;
                if (((previousValue != value)
                            || (this._Store.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Store.Entity = null;
                        previousValue.Stocks.Remove(this);
                    }
                    this._Store.Entity = value;
                    if ((value != null))
                    {
                        value.Stocks.Add(this);
                        this._storeid = value.id;
                    }
                    else
                    {
                        this._storeid = default(string);
                    }
                    this.SendPropertyChanged("Store");
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.Store")]
    public partial class Store : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _id;

        private string _name;

        private string _street;

        private string _city;

        private string _state;

        private string _zip;

        private string _accountid;

        private string _CompanyID;

        private EntitySet<BillOfDelivery> _BillOfDeliveries;

        private EntitySet<GoodReceiving> _GoodReceivings;

        private EntitySet<InventoryInvoice> _InventoryInvoices;

        private EntitySet<SalesInvoice> _SalesInvoices;

        private EntitySet<Stock> _Stocks;

        private EntityRef<Account> _Account;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnidChanging(string value);
        partial void OnidChanged();
        partial void OnnameChanging(string value);
        partial void OnnameChanged();
        partial void OnstreetChanging(string value);
        partial void OnstreetChanged();
        partial void OncityChanging(string value);
        partial void OncityChanged();
        partial void OnstateChanging(string value);
        partial void OnstateChanged();
        partial void OnzipChanging(string value);
        partial void OnzipChanged();
        partial void OnaccountidChanging(string value);
        partial void OnaccountidChanged();
        partial void OnCompanyIDChanging(string value);
        partial void OnCompanyIDChanged();
        #endregion

        public Store()
        {
            this._BillOfDeliveries = new EntitySet<BillOfDelivery>(new Action<BillOfDelivery>(this.attach_BillOfDeliveries), new Action<BillOfDelivery>(this.detach_BillOfDeliveries));
            this._GoodReceivings = new EntitySet<GoodReceiving>(new Action<GoodReceiving>(this.attach_GoodReceivings), new Action<GoodReceiving>(this.detach_GoodReceivings));
            this._InventoryInvoices = new EntitySet<InventoryInvoice>(new Action<InventoryInvoice>(this.attach_InventoryInvoices), new Action<InventoryInvoice>(this.detach_InventoryInvoices));
            this._SalesInvoices = new EntitySet<SalesInvoice>(new Action<SalesInvoice>(this.attach_SalesInvoices), new Action<SalesInvoice>(this.detach_SalesInvoices));
            this._Stocks = new EntitySet<Stock>(new Action<Stock>(this.attach_Stocks), new Action<Stock>(this.detach_Stocks));
            this._Account = default(EntityRef<Account>);
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id", DbType = "NVarChar(50) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    this.OnidChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("id");
                    this.OnidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_name", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string name
        {
            get
            {
                return this._name;
            }
            set
            {
                if ((this._name != value))
                {
                    this.OnnameChanging(value);
                    this.SendPropertyChanging();
                    this._name = value;
                    this.SendPropertyChanged("name");
                    this.OnnameChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_street", DbType = "NVarChar(50)")]
        public string street
        {
            get
            {
                return this._street;
            }
            set
            {
                if ((this._street != value))
                {
                    this.OnstreetChanging(value);
                    this.SendPropertyChanging();
                    this._street = value;
                    this.SendPropertyChanged("street");
                    this.OnstreetChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_city", DbType = "NVarChar(50)")]
        public string city
        {
            get
            {
                return this._city;
            }
            set
            {
                if ((this._city != value))
                {
                    this.OncityChanging(value);
                    this.SendPropertyChanging();
                    this._city = value;
                    this.SendPropertyChanged("city");
                    this.OncityChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_state", DbType = "NVarChar(50)")]
        public string state
        {
            get
            {
                return this._state;
            }
            set
            {
                if ((this._state != value))
                {
                    this.OnstateChanging(value);
                    this.SendPropertyChanging();
                    this._state = value;
                    this.SendPropertyChanged("state");
                    this.OnstateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_zip", DbType = "NVarChar(50)")]
        public string zip
        {
            get
            {
                return this._zip;
            }
            set
            {
                if ((this._zip != value))
                {
                    this.OnzipChanging(value);
                    this.SendPropertyChanging();
                    this._zip = value;
                    this.SendPropertyChanged("zip");
                    this.OnzipChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_accountid", DbType = "NVarChar(50)")]
        public string accountid
        {
            get
            {
                return this._accountid;
            }
            set
            {
                if ((this._accountid != value))
                {
                    if (this._Account.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnaccountidChanging(value);
                    this.SendPropertyChanging();
                    this._accountid = value;
                    this.SendPropertyChanged("accountid");
                    this.OnaccountidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CompanyID
        {
            get
            {
                return this._CompanyID;
            }
            set
            {
                if ((this._CompanyID != value))
                {
                    this.OnCompanyIDChanging(value);
                    this.SendPropertyChanging();
                    this._CompanyID = value;
                    this.SendPropertyChanged("CompanyID");
                    this.OnCompanyIDChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Store_BillOfDelivery", Storage = "_BillOfDeliveries", ThisKey = "id", OtherKey = "store")]
        public EntitySet<BillOfDelivery> BillOfDeliveries
        {
            get
            {
                return this._BillOfDeliveries;
            }
            set
            {
                this._BillOfDeliveries.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Store_GoodReceiving", Storage = "_GoodReceivings", ThisKey = "id", OtherKey = "store")]
        public EntitySet<GoodReceiving> GoodReceivings
        {
            get
            {
                return this._GoodReceivings;
            }
            set
            {
                this._GoodReceivings.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Store_InventoryInvoice", Storage = "_InventoryInvoices", ThisKey = "id", OtherKey = "store")]
        public EntitySet<InventoryInvoice> InventoryInvoices
        {
            get
            {
                return this._InventoryInvoices;
            }
            set
            {
                this._InventoryInvoices.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Store_SalesInvoice", Storage = "_SalesInvoices", ThisKey = "id", OtherKey = "store")]
        public EntitySet<SalesInvoice> SalesInvoices
        {
            get
            {
                return this._SalesInvoices;
            }
            set
            {
                this._SalesInvoices.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Store_Stock", Storage = "_Stocks", ThisKey = "id", OtherKey = "storeid")]
        public EntitySet<Stock> Stocks
        {
            get
            {
                return this._Stocks;
            }
            set
            {
                this._Stocks.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Account_Store", Storage = "_Account", ThisKey = "accountid", OtherKey = "id", IsForeignKey = true)]
        public Account Account
        {
            get
            {
                return this._Account.Entity;
            }
            set
            {
                Account previousValue = this._Account.Entity;
                if (((previousValue != value)
                            || (this._Account.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Account.Entity = null;
                        previousValue.Stores.Remove(this);
                    }
                    this._Account.Entity = value;
                    if ((value != null))
                    {
                        value.Stores.Add(this);
                        this._accountid = value.id;
                    }
                    else
                    {
                        this._accountid = default(string);
                    }
                    this.SendPropertyChanged("Account");
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void attach_BillOfDeliveries(BillOfDelivery entity)
        {
            this.SendPropertyChanging();
            entity.Store1 = this;
        }

        private void detach_BillOfDeliveries(BillOfDelivery entity)
        {
            this.SendPropertyChanging();
            entity.Store1 = null;
        }

        private void attach_GoodReceivings(GoodReceiving entity)
        {
            this.SendPropertyChanging();
            entity.Store1 = this;
        }

        private void detach_GoodReceivings(GoodReceiving entity)
        {
            this.SendPropertyChanging();
            entity.Store1 = null;
        }

        private void attach_InventoryInvoices(InventoryInvoice entity)
        {
            this.SendPropertyChanging();
            entity.Store1 = this;
        }

        private void detach_InventoryInvoices(InventoryInvoice entity)
        {
            this.SendPropertyChanging();
            entity.Store1 = null;
        }

        private void attach_SalesInvoices(SalesInvoice entity)
        {
            this.SendPropertyChanging();
            entity.Store1 = this;
        }

        private void detach_SalesInvoices(SalesInvoice entity)
        {
            this.SendPropertyChanging();
            entity.Store1 = null;
        }

        private void attach_Stocks(Stock entity)
        {
            this.SendPropertyChanging();
            entity.Store = this;
        }

        private void detach_Stocks(Stock entity)
        {
            this.SendPropertyChanging();
            entity.Store = null;
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.Supplier")]
    public partial class Supplier : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _id;

        private string _name;

        private string _street;

        private string _city;

        private string _state;

        private string _zip;

        private string _Phone;

        private string _Email;

        private string _accountid;

        private string _CompanyID;

        private string _IBAN;

        private string _Bank;

        private string _BIC;

        private string _VatCode;

        private string _Charge;

        private EntitySet<VendorInvoice> _VendorInvoices;

        private EntitySet<GoodReceiving> _GoodReceivings;

        private EntitySet<InventoryInvoice> _InventoryInvoices;

        private EntitySet<Payment> _Payments;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnidChanging(string value);
        partial void OnidChanged();
        partial void OnnameChanging(string value);
        partial void OnnameChanged();
        partial void OnstreetChanging(string value);
        partial void OnstreetChanged();
        partial void OncityChanging(string value);
        partial void OncityChanged();
        partial void OnstateChanging(string value);
        partial void OnstateChanged();
        partial void OnzipChanging(string value);
        partial void OnzipChanged();
        partial void OnPhoneChanging(string value);
        partial void OnPhoneChanged();
        partial void OnEmailChanging(string value);
        partial void OnEmailChanged();
        partial void OnaccountidChanging(string value);
        partial void OnaccountidChanged();
        partial void OnCompanyIDChanging(string value);
        partial void OnCompanyIDChanged();
        partial void OnIBANChanging(string value);
        partial void OnIBANChanged();
        partial void OnBankChanging(string value);
        partial void OnBankChanged();
        partial void OnBICChanging(string value);
        partial void OnBICChanged();
        partial void OnVatCodeChanging(string value);
        partial void OnVatCodeChanged();
        partial void OnChargeChanging(string value);
        partial void OnChargeChanged();
        #endregion

        public Supplier()
        {
            this._VendorInvoices = new EntitySet<VendorInvoice>(new Action<VendorInvoice>(this.attach_VendorInvoices), new Action<VendorInvoice>(this.detach_VendorInvoices));
            this._GoodReceivings = new EntitySet<GoodReceiving>(new Action<GoodReceiving>(this.attach_GoodReceivings), new Action<GoodReceiving>(this.detach_GoodReceivings));
            this._InventoryInvoices = new EntitySet<InventoryInvoice>(new Action<InventoryInvoice>(this.attach_InventoryInvoices), new Action<InventoryInvoice>(this.detach_InventoryInvoices));
            this._Payments = new EntitySet<Payment>(new Action<Payment>(this.attach_Payments), new Action<Payment>(this.detach_Payments));
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id", DbType = "NVarChar(50) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    this.OnidChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("id");
                    this.OnidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_name", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
        public string name
        {
            get
            {
                return this._name;
            }
            set
            {
                if ((this._name != value))
                {
                    this.OnnameChanging(value);
                    this.SendPropertyChanging();
                    this._name = value;
                    this.SendPropertyChanged("name");
                    this.OnnameChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_street", DbType = "NVarChar(255)")]
        public string street
        {
            get
            {
                return this._street;
            }
            set
            {
                if ((this._street != value))
                {
                    this.OnstreetChanging(value);
                    this.SendPropertyChanging();
                    this._street = value;
                    this.SendPropertyChanged("street");
                    this.OnstreetChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_city", DbType = "NVarChar(255)")]
        public string city
        {
            get
            {
                return this._city;
            }
            set
            {
                if ((this._city != value))
                {
                    this.OncityChanging(value);
                    this.SendPropertyChanging();
                    this._city = value;
                    this.SendPropertyChanged("city");
                    this.OncityChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_state", DbType = "NVarChar(255)")]
        public string state
        {
            get
            {
                return this._state;
            }
            set
            {
                if ((this._state != value))
                {
                    this.OnstateChanging(value);
                    this.SendPropertyChanging();
                    this._state = value;
                    this.SendPropertyChanged("state");
                    this.OnstateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_zip", DbType = "NVarChar(255)")]
        public string zip
        {
            get
            {
                return this._zip;
            }
            set
            {
                if ((this._zip != value))
                {
                    this.OnzipChanging(value);
                    this.SendPropertyChanging();
                    this._zip = value;
                    this.SendPropertyChanged("zip");
                    this.OnzipChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Phone", DbType = "NVarChar(50)")]
        public string Phone
        {
            get
            {
                return this._Phone;
            }
            set
            {
                if ((this._Phone != value))
                {
                    this.OnPhoneChanging(value);
                    this.SendPropertyChanging();
                    this._Phone = value;
                    this.SendPropertyChanged("Phone");
                    this.OnPhoneChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Email", DbType = "NVarChar(50)")]
        public string Email
        {
            get
            {
                return this._Email;
            }
            set
            {
                if ((this._Email != value))
                {
                    this.OnEmailChanging(value);
                    this.SendPropertyChanging();
                    this._Email = value;
                    this.SendPropertyChanged("Email");
                    this.OnEmailChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_accountid", DbType = "NVarChar(50)")]
        public string accountid
        {
            get
            {
                return this._accountid;
            }
            set
            {
                if ((this._accountid != value))
                {
                    this.OnaccountidChanging(value);
                    this.SendPropertyChanging();
                    this._accountid = value;
                    this.SendPropertyChanged("accountid");
                    this.OnaccountidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CompanyID
        {
            get
            {
                return this._CompanyID;
            }
            set
            {
                if ((this._CompanyID != value))
                {
                    this.OnCompanyIDChanging(value);
                    this.SendPropertyChanging();
                    this._CompanyID = value;
                    this.SendPropertyChanged("CompanyID");
                    this.OnCompanyIDChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IBAN", DbType = "NVarChar(50)")]
        public string IBAN
        {
            get
            {
                return this._IBAN;
            }
            set
            {
                if ((this._IBAN != value))
                {
                    this.OnIBANChanging(value);
                    this.SendPropertyChanging();
                    this._IBAN = value;
                    this.SendPropertyChanged("IBAN");
                    this.OnIBANChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Bank", DbType = "NVarChar(50)")]
        public string Bank
        {
            get
            {
                return this._Bank;
            }
            set
            {
                if ((this._Bank != value))
                {
                    this.OnBankChanging(value);
                    this.SendPropertyChanging();
                    this._Bank = value;
                    this.SendPropertyChanged("Bank");
                    this.OnBankChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_BIC", DbType = "NVarChar(50)")]
        public string BIC
        {
            get
            {
                return this._BIC;
            }
            set
            {
                if ((this._BIC != value))
                {
                    this.OnBICChanging(value);
                    this.SendPropertyChanging();
                    this._BIC = value;
                    this.SendPropertyChanged("BIC");
                    this.OnBICChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_VatCode", DbType = "NVarChar(50)")]
        public string VatCode
        {
            get
            {
                return this._VatCode;
            }
            set
            {
                if ((this._VatCode != value))
                {
                    this.OnVatCodeChanging(value);
                    this.SendPropertyChanging();
                    this._VatCode = value;
                    this.SendPropertyChanged("VatCode");
                    this.OnVatCodeChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Charge", DbType = "NVarChar(50)")]
        public string Charge
        {
            get
            {
                return this._Charge;
            }
            set
            {
                if ((this._Charge != value))
                {
                    this.OnChargeChanging(value);
                    this.SendPropertyChanging();
                    this._Charge = value;
                    this.SendPropertyChanged("Charge");
                    this.OnChargeChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Supplier_VendorInvoice", Storage = "_VendorInvoices", ThisKey = "id", OtherKey = "account")]
        public EntitySet<VendorInvoice> VendorInvoices
        {
            get
            {
                return this._VendorInvoices;
            }
            set
            {
                this._VendorInvoices.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Supplier_GoodReceiving", Storage = "_GoodReceivings", ThisKey = "id", OtherKey = "account")]
        public EntitySet<GoodReceiving> GoodReceivings
        {
            get
            {
                return this._GoodReceivings;
            }
            set
            {
                this._GoodReceivings.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Supplier_InventoryInvoice", Storage = "_InventoryInvoices", ThisKey = "id", OtherKey = "account")]
        public EntitySet<InventoryInvoice> InventoryInvoices
        {
            get
            {
                return this._InventoryInvoices;
            }
            set
            {
                this._InventoryInvoices.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Supplier_Payment", Storage = "_Payments", ThisKey = "id", OtherKey = "account")]
        public EntitySet<Payment> Payments
        {
            get
            {
                return this._Payments;
            }
            set
            {
                this._Payments.Assign(value);
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void attach_VendorInvoices(VendorInvoice entity)
        {
            this.SendPropertyChanging();
            entity.Supplier = this;
        }

        private void detach_VendorInvoices(VendorInvoice entity)
        {
            this.SendPropertyChanging();
            entity.Supplier = null;
        }

        private void attach_GoodReceivings(GoodReceiving entity)
        {
            this.SendPropertyChanging();
            entity.Supplier = this;
        }

        private void detach_GoodReceivings(GoodReceiving entity)
        {
            this.SendPropertyChanging();
            entity.Supplier = null;
        }

        private void attach_InventoryInvoices(InventoryInvoice entity)
        {
            this.SendPropertyChanging();
            entity.Supplier = this;
        }

        private void detach_InventoryInvoices(InventoryInvoice entity)
        {
            this.SendPropertyChanging();
            entity.Supplier = null;
        }

        private void attach_Payments(Payment entity)
        {
            this.SendPropertyChanging();
            entity.Supplier = this;
        }

        private void detach_Payments(Payment entity)
        {
            this.SendPropertyChanging();
            entity.Supplier = null;
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.tmpBalance")]
    public partial class tmpBalance
    {

        private int _ID;

        private string _ClassId;

        private string _ClassName;

        private string _SubClassId;

        private string _SubClassName;

        private string _AccountId;

        private string _AccountName;

        private System.Nullable<decimal> _TDebit;

        private System.Nullable<decimal> _TCredit;

        private System.Nullable<decimal> _SDebit;

        private System.Nullable<decimal> _SCredit;

        private string _Currency;

        private System.Nullable<decimal> _Balance;

        private string _CompanyId;

        private System.Nullable<bool> _IsBalance;

        public tmpBalance()
        {
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ID", AutoSync = AutoSync.Always, DbType = "Int NOT NULL IDENTITY", IsDbGenerated = true)]
        public int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                if ((this._ID != value))
                {
                    this._ID = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ClassId", DbType = "NVarChar(50)")]
        public string ClassId
        {
            get
            {
                return this._ClassId;
            }
            set
            {
                if ((this._ClassId != value))
                {
                    this._ClassId = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ClassName", DbType = "NVarChar(150)")]
        public string ClassName
        {
            get
            {
                return this._ClassName;
            }
            set
            {
                if ((this._ClassName != value))
                {
                    this._ClassName = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_SubClassId", DbType = "NVarChar(50)")]
        public string SubClassId
        {
            get
            {
                return this._SubClassId;
            }
            set
            {
                if ((this._SubClassId != value))
                {
                    this._SubClassId = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_SubClassName", DbType = "NVarChar(150)")]
        public string SubClassName
        {
            get
            {
                return this._SubClassName;
            }
            set
            {
                if ((this._SubClassName != value))
                {
                    this._SubClassName = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_AccountId", DbType = "NVarChar(50)")]
        public string AccountId
        {
            get
            {
                return this._AccountId;
            }
            set
            {
                if ((this._AccountId != value))
                {
                    this._AccountId = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_AccountName", DbType = "NVarChar(150)")]
        public string AccountName
        {
            get
            {
                return this._AccountName;
            }
            set
            {
                if ((this._AccountName != value))
                {
                    this._AccountName = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TDebit", DbType = "Money")]
        public System.Nullable<decimal> TDebit
        {
            get
            {
                return this._TDebit;
            }
            set
            {
                if ((this._TDebit != value))
                {
                    this._TDebit = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TCredit", DbType = "Money")]
        public System.Nullable<decimal> TCredit
        {
            get
            {
                return this._TCredit;
            }
            set
            {
                if ((this._TCredit != value))
                {
                    this._TCredit = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_SDebit", DbType = "Money")]
        public System.Nullable<decimal> SDebit
        {
            get
            {
                return this._SDebit;
            }
            set
            {
                if ((this._SDebit != value))
                {
                    this._SDebit = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_SCredit", DbType = "Money")]
        public System.Nullable<decimal> SCredit
        {
            get
            {
                return this._SCredit;
            }
            set
            {
                if ((this._SCredit != value))
                {
                    this._SCredit = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Currency", DbType = "NVarChar(50)")]
        public string Currency
        {
            get
            {
                return this._Currency;
            }
            set
            {
                if ((this._Currency != value))
                {
                    this._Currency = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Balance", DbType = "Money")]
        public System.Nullable<decimal> Balance
        {
            get
            {
                return this._Balance;
            }
            set
            {
                if ((this._Balance != value))
                {
                    this._Balance = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyId", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CompanyId
        {
            get
            {
                return this._CompanyId;
            }
            set
            {
                if ((this._CompanyId != value))
                {
                    this._CompanyId = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IsBalance", DbType = "Bit")]
        public System.Nullable<bool> IsBalance
        {
            get
            {
                return this._IsBalance;
            }
            set
            {
                if ((this._IsBalance != value))
                {
                    this._IsBalance = value;
                }
            }
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.tmpPeriodic")]
    public partial class tmpPeriodic
    {

        private int _Id;

        private string _AccountId;

        private string _AccountName;

        private string _Periode;

        private System.Nullable<decimal> _Debit;

        private System.Nullable<decimal> _Credit;

        private System.Nullable<decimal> _Balance;

        private string _Currency;

        private System.Nullable<bool> _IsBalance;

        private string _CompanyId;

        public tmpPeriodic()
        {
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Id", AutoSync = AutoSync.Always, DbType = "Int NOT NULL IDENTITY", IsDbGenerated = true)]
        public int Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                if ((this._Id != value))
                {
                    this._Id = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_AccountId", DbType = "NVarChar(50)")]
        public string AccountId
        {
            get
            {
                return this._AccountId;
            }
            set
            {
                if ((this._AccountId != value))
                {
                    this._AccountId = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_AccountName", DbType = "NVarChar(150)")]
        public string AccountName
        {
            get
            {
                return this._AccountName;
            }
            set
            {
                if ((this._AccountName != value))
                {
                    this._AccountName = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Periode", DbType = "NVarChar(16)")]
        public string Periode
        {
            get
            {
                return this._Periode;
            }
            set
            {
                if ((this._Periode != value))
                {
                    this._Periode = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Debit", DbType = "Money")]
        public System.Nullable<decimal> Debit
        {
            get
            {
                return this._Debit;
            }
            set
            {
                if ((this._Debit != value))
                {
                    this._Debit = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Credit", DbType = "Money")]
        public System.Nullable<decimal> Credit
        {
            get
            {
                return this._Credit;
            }
            set
            {
                if ((this._Credit != value))
                {
                    this._Credit = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Balance", DbType = "Money")]
        public System.Nullable<decimal> Balance
        {
            get
            {
                return this._Balance;
            }
            set
            {
                if ((this._Balance != value))
                {
                    this._Balance = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Currency", DbType = "NVarChar(50)")]
        public string Currency
        {
            get
            {
                return this._Currency;
            }
            set
            {
                if ((this._Currency != value))
                {
                    this._Currency = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IsBalance", DbType = "Bit")]
        public System.Nullable<bool> IsBalance
        {
            get
            {
                return this._IsBalance;
            }
            set
            {
                if ((this._IsBalance != value))
                {
                    this._IsBalance = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyId", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CompanyId
        {
            get
            {
                return this._CompanyId;
            }
            set
            {
                if ((this._CompanyId != value))
                {
                    this._CompanyId = value;
                }
            }
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.Vat")]
    public partial class Vat : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _id;

        private string _name;

        private string _description;

        private decimal _PVat;

        private string _inputvataccountid;

        private string _outputvataccountid;

        private string _revenueaccountid;

        private string _CompanyID;

        private EntitySet<Article> _Articles;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnidChanging(string value);
        partial void OnidChanged();
        partial void OnnameChanging(string value);
        partial void OnnameChanged();
        partial void OndescriptionChanging(string value);
        partial void OndescriptionChanged();
        partial void OnPVatChanging(decimal value);
        partial void OnPVatChanged();
        partial void OninputvataccountidChanging(string value);
        partial void OninputvataccountidChanged();
        partial void OnoutputvataccountidChanging(string value);
        partial void OnoutputvataccountidChanged();
        partial void OnrevenueaccountidChanging(string value);
        partial void OnrevenueaccountidChanged();
        partial void OnCompanyIDChanging(string value);
        partial void OnCompanyIDChanged();
        #endregion

        public Vat()
        {
            this._Articles = new EntitySet<Article>(new Action<Article>(this.attach_Articles), new Action<Article>(this.detach_Articles));
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id", DbType = "NVarChar(50) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    this.OnidChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("id");
                    this.OnidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_name", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
        public string name
        {
            get
            {
                return this._name;
            }
            set
            {
                if ((this._name != value))
                {
                    this.OnnameChanging(value);
                    this.SendPropertyChanging();
                    this._name = value;
                    this.SendPropertyChanged("name");
                    this.OnnameChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_description", DbType = "NVarChar(255)")]
        public string description
        {
            get
            {
                return this._description;
            }
            set
            {
                if ((this._description != value))
                {
                    this.OndescriptionChanging(value);
                    this.SendPropertyChanging();
                    this._description = value;
                    this.SendPropertyChanged("description");
                    this.OndescriptionChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_PVat", DbType = "Decimal(3,2) NOT NULL")]
        public decimal PVat
        {
            get
            {
                return this._PVat;
            }
            set
            {
                if ((this._PVat != value))
                {
                    this.OnPVatChanging(value);
                    this.SendPropertyChanging();
                    this._PVat = value;
                    this.SendPropertyChanged("PVat");
                    this.OnPVatChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_inputvataccountid", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
        public string inputvataccountid
        {
            get
            {
                return this._inputvataccountid;
            }
            set
            {
                if ((this._inputvataccountid != value))
                {
                    this.OninputvataccountidChanging(value);
                    this.SendPropertyChanging();
                    this._inputvataccountid = value;
                    this.SendPropertyChanged("inputvataccountid");
                    this.OninputvataccountidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_outputvataccountid", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
        public string outputvataccountid
        {
            get
            {
                return this._outputvataccountid;
            }
            set
            {
                if ((this._outputvataccountid != value))
                {
                    this.OnoutputvataccountidChanging(value);
                    this.SendPropertyChanging();
                    this._outputvataccountid = value;
                    this.SendPropertyChanged("outputvataccountid");
                    this.OnoutputvataccountidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_revenueaccountid", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
        public string revenueaccountid
        {
            get
            {
                return this._revenueaccountid;
            }
            set
            {
                if ((this._revenueaccountid != value))
                {
                    this.OnrevenueaccountidChanging(value);
                    this.SendPropertyChanging();
                    this._revenueaccountid = value;
                    this.SendPropertyChanged("revenueaccountid");
                    this.OnrevenueaccountidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CompanyID
        {
            get
            {
                return this._CompanyID;
            }
            set
            {
                if ((this._CompanyID != value))
                {
                    this.OnCompanyIDChanging(value);
                    this.SendPropertyChanging();
                    this._CompanyID = value;
                    this.SendPropertyChanged("CompanyID");
                    this.OnCompanyIDChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Vat_Article", Storage = "_Articles", ThisKey = "id", OtherKey = "VatCode")]
        public EntitySet<Article> Articles
        {
            get
            {
                return this._Articles;
            }
            set
            {
                this._Articles.Assign(value);
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void attach_Articles(Article entity)
        {
            this.SendPropertyChanging();
            entity.Vat = this;
        }

        private void detach_Articles(Article entity)
        {
            this.SendPropertyChanging();
            entity.Vat = null;
        }
    }

    public partial class account1To7Result
    {

        private int _gr;

        private string _ID;

        private string _AccountId;

        private string _Name;

        private System.Nullable<decimal> _TDebit;

        private System.Nullable<decimal> _TCredit;

        private System.Nullable<decimal> _SDebit;

        private System.Nullable<decimal> _SCredit;

        private string _Currency;

        public account1To7Result()
        {
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_gr", DbType = "Int NOT NULL")]
        public int gr
        {
            get
            {
                return this._gr;
            }
            set
            {
                if ((this._gr != value))
                {
                    this._gr = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ID", DbType = "NVarChar(1)")]
        public string ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                if ((this._ID != value))
                {
                    this._ID = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_AccountId", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string AccountId
        {
            get
            {
                return this._AccountId;
            }
            set
            {
                if ((this._AccountId != value))
                {
                    this._AccountId = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Name", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                if ((this._Name != value))
                {
                    this._Name = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TDebit", DbType = "Decimal(38,2)")]
        public System.Nullable<decimal> TDebit
        {
            get
            {
                return this._TDebit;
            }
            set
            {
                if ((this._TDebit != value))
                {
                    this._TDebit = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TCredit", DbType = "Decimal(38,2)")]
        public System.Nullable<decimal> TCredit
        {
            get
            {
                return this._TCredit;
            }
            set
            {
                if ((this._TCredit != value))
                {
                    this._TCredit = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_SDebit", DbType = "Decimal(38,2)")]
        public System.Nullable<decimal> SDebit
        {
            get
            {
                return this._SDebit;
            }
            set
            {
                if ((this._SDebit != value))
                {
                    this._SDebit = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_SCredit", DbType = "Decimal(38,2)")]
        public System.Nullable<decimal> SCredit
        {
            get
            {
                return this._SCredit;
            }
            set
            {
                if ((this._SCredit != value))
                {
                    this._SCredit = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Currency", DbType = "NVarChar(10) NOT NULL", CanBeNull = false)]
        public string Currency
        {
            get
            {
                return this._Currency;
            }
            set
            {
                if ((this._Currency != value))
                {
                    this._Currency = value;
                }
            }
        }
    }

    public partial class PeriodicBalancesResult
    {

        private int _Id;

        private string _AccountId;

        private string _AccountName;

        private string _Periode;

        private System.Nullable<decimal> _Debit;

        private System.Nullable<decimal> _Credit;

        private System.Nullable<decimal> _Balance;

        private string _Currency;

        private System.Nullable<bool> _IsBalance;

        private string _CompanyId;

        public PeriodicBalancesResult()
        {
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Id", DbType = "Int NOT NULL")]
        public int Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                if ((this._Id != value))
                {
                    this._Id = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_AccountId", DbType = "NVarChar(50)")]
        public string AccountId
        {
            get
            {
                return this._AccountId;
            }
            set
            {
                if ((this._AccountId != value))
                {
                    this._AccountId = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_AccountName", DbType = "NVarChar(150)")]
        public string AccountName
        {
            get
            {
                return this._AccountName;
            }
            set
            {
                if ((this._AccountName != value))
                {
                    this._AccountName = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Periode", DbType = "NVarChar(16)")]
        public string Periode
        {
            get
            {
                return this._Periode;
            }
            set
            {
                if ((this._Periode != value))
                {
                    this._Periode = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Debit", DbType = "Money")]
        public System.Nullable<decimal> Debit
        {
            get
            {
                return this._Debit;
            }
            set
            {
                if ((this._Debit != value))
                {
                    this._Debit = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Credit", DbType = "Money")]
        public System.Nullable<decimal> Credit
        {
            get
            {
                return this._Credit;
            }
            set
            {
                if ((this._Credit != value))
                {
                    this._Credit = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Balance", DbType = "Money")]
        public System.Nullable<decimal> Balance
        {
            get
            {
                return this._Balance;
            }
            set
            {
                if ((this._Balance != value))
                {
                    this._Balance = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Currency", DbType = "NVarChar(50)")]
        public string Currency
        {
            get
            {
                return this._Currency;
            }
            set
            {
                if ((this._Currency != value))
                {
                    this._Currency = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IsBalance", DbType = "Bit")]
        public System.Nullable<bool> IsBalance
        {
            get
            {
                return this._IsBalance;
            }
            set
            {
                if ((this._IsBalance != value))
                {
                    this._IsBalance = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyId", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CompanyId
        {
            get
            {
                return this._CompanyId;
            }
            set
            {
                if ((this._CompanyId != value))
                {
                    this._CompanyId = value;
                }
            }
        }
    }

    public partial class AccountBalanceResult
    {

        private int _ID;

        private string _ClassId;

        private string _ClassName;

        private string _SubClassId;

        private string _SubClassName;

        private string _AccountId;

        private string _AccountName;

        private System.Nullable<decimal> _TDebit;

        private System.Nullable<decimal> _TCredit;

        private System.Nullable<decimal> _SDebit;

        private System.Nullable<decimal> _SCredit;

        private string _Currency;

        private System.Nullable<decimal> _Balance;

        private string _CompanyId;

        private System.Nullable<bool> _IsBalance;

        public AccountBalanceResult()
        {
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ID", DbType = "Int NOT NULL")]
        public int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                if ((this._ID != value))
                {
                    this._ID = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ClassId", DbType = "NVarChar(50)")]
        public string ClassId
        {
            get
            {
                return this._ClassId;
            }
            set
            {
                if ((this._ClassId != value))
                {
                    this._ClassId = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ClassName", DbType = "NVarChar(150)")]
        public string ClassName
        {
            get
            {
                return this._ClassName;
            }
            set
            {
                if ((this._ClassName != value))
                {
                    this._ClassName = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_SubClassId", DbType = "NVarChar(50)")]
        public string SubClassId
        {
            get
            {
                return this._SubClassId;
            }
            set
            {
                if ((this._SubClassId != value))
                {
                    this._SubClassId = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_SubClassName", DbType = "NVarChar(150)")]
        public string SubClassName
        {
            get
            {
                return this._SubClassName;
            }
            set
            {
                if ((this._SubClassName != value))
                {
                    this._SubClassName = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_AccountId", DbType = "NVarChar(50)")]
        public string AccountId
        {
            get
            {
                return this._AccountId;
            }
            set
            {
                if ((this._AccountId != value))
                {
                    this._AccountId = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_AccountName", DbType = "NVarChar(150)")]
        public string AccountName
        {
            get
            {
                return this._AccountName;
            }
            set
            {
                if ((this._AccountName != value))
                {
                    this._AccountName = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TDebit", DbType = "Money")]
        public System.Nullable<decimal> TDebit
        {
            get
            {
                return this._TDebit;
            }
            set
            {
                if ((this._TDebit != value))
                {
                    this._TDebit = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TCredit", DbType = "Money")]
        public System.Nullable<decimal> TCredit
        {
            get
            {
                return this._TCredit;
            }
            set
            {
                if ((this._TCredit != value))
                {
                    this._TCredit = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_SDebit", DbType = "Money")]
        public System.Nullable<decimal> SDebit
        {
            get
            {
                return this._SDebit;
            }
            set
            {
                if ((this._SDebit != value))
                {
                    this._SDebit = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_SCredit", DbType = "Money")]
        public System.Nullable<decimal> SCredit
        {
            get
            {
                return this._SCredit;
            }
            set
            {
                if ((this._SCredit != value))
                {
                    this._SCredit = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Currency", DbType = "NVarChar(50)")]
        public string Currency
        {
            get
            {
                return this._Currency;
            }
            set
            {
                if ((this._Currency != value))
                {
                    this._Currency = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Balance", DbType = "Money")]
        public System.Nullable<decimal> Balance
        {
            get
            {
                return this._Balance;
            }
            set
            {
                if ((this._Balance != value))
                {
                    this._Balance = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyId", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CompanyId
        {
            get
            {
                return this._CompanyId;
            }
            set
            {
                if ((this._CompanyId != value))
                {
                    this._CompanyId = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IsBalance", DbType = "Bit")]
        public System.Nullable<bool> IsBalance
        {
            get
            {
                return this._IsBalance;
            }
            set
            {
                if ((this._IsBalance != value))
                {
                    this._IsBalance = value;
                }
            }
        }
    }

    public partial class ClassAccountBalanceResult
    {

        private string _ID;

        private string _AccountId;

        private string _Name;

        private System.Nullable<decimal> _TDebit;

        private System.Nullable<decimal> _TCredit;

        private System.Nullable<decimal> _SDebit;

        private System.Nullable<decimal> _SCredit;

        private string _Currency;

        public ClassAccountBalanceResult()
        {
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ID", DbType = "NVarChar(1)")]
        public string ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                if ((this._ID != value))
                {
                    this._ID = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_AccountId", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string AccountId
        {
            get
            {
                return this._AccountId;
            }
            set
            {
                if ((this._AccountId != value))
                {
                    this._AccountId = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Name", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                if ((this._Name != value))
                {
                    this._Name = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TDebit", DbType = "Decimal(38,2)")]
        public System.Nullable<decimal> TDebit
        {
            get
            {
                return this._TDebit;
            }
            set
            {
                if ((this._TDebit != value))
                {
                    this._TDebit = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TCredit", DbType = "Decimal(38,2)")]
        public System.Nullable<decimal> TCredit
        {
            get
            {
                return this._TCredit;
            }
            set
            {
                if ((this._TCredit != value))
                {
                    this._TCredit = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_SDebit", DbType = "Decimal(38,2)")]
        public System.Nullable<decimal> SDebit
        {
            get
            {
                return this._SDebit;
            }
            set
            {
                if ((this._SDebit != value))
                {
                    this._SDebit = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_SCredit", DbType = "Decimal(38,2)")]
        public System.Nullable<decimal> SCredit
        {
            get
            {
                return this._SCredit;
            }
            set
            {
                if ((this._SCredit != value))
                {
                    this._SCredit = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Currency", DbType = "NVarChar(10) NOT NULL", CanBeNull = false)]
        public string Currency
        {
            get
            {
                return this._Currency;
            }
            set
            {
                if ((this._Currency != value))
                {
                    this._Currency = value;
                }
            }
        }
    }

    public partial class ClassAccountBalancesResult
    {

        private int _ID;

        private string _ClassId;

        private string _ClassName;

        private string _SubClassId;

        private string _SubClassName;

        private string _AccountId;

        private string _AccountName;

        private System.Nullable<decimal> _TDebit;

        private System.Nullable<decimal> _TCredit;

        private System.Nullable<decimal> _SDebit;

        private System.Nullable<decimal> _SCredit;

        private string _Currency;

        private System.Nullable<decimal> _Balance;

        private string _CompanyId;

        private System.Nullable<bool> _IsBalance;

        public ClassAccountBalancesResult()
        {
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ID", DbType = "Int NOT NULL")]
        public int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                if ((this._ID != value))
                {
                    this._ID = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ClassId", DbType = "NVarChar(50)")]
        public string ClassId
        {
            get
            {
                return this._ClassId;
            }
            set
            {
                if ((this._ClassId != value))
                {
                    this._ClassId = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ClassName", DbType = "NVarChar(150)")]
        public string ClassName
        {
            get
            {
                return this._ClassName;
            }
            set
            {
                if ((this._ClassName != value))
                {
                    this._ClassName = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_SubClassId", DbType = "NVarChar(50)")]
        public string SubClassId
        {
            get
            {
                return this._SubClassId;
            }
            set
            {
                if ((this._SubClassId != value))
                {
                    this._SubClassId = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_SubClassName", DbType = "NVarChar(150)")]
        public string SubClassName
        {
            get
            {
                return this._SubClassName;
            }
            set
            {
                if ((this._SubClassName != value))
                {
                    this._SubClassName = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_AccountId", DbType = "NVarChar(50)")]
        public string AccountId
        {
            get
            {
                return this._AccountId;
            }
            set
            {
                if ((this._AccountId != value))
                {
                    this._AccountId = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_AccountName", DbType = "NVarChar(150)")]
        public string AccountName
        {
            get
            {
                return this._AccountName;
            }
            set
            {
                if ((this._AccountName != value))
                {
                    this._AccountName = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TDebit", DbType = "Money")]
        public System.Nullable<decimal> TDebit
        {
            get
            {
                return this._TDebit;
            }
            set
            {
                if ((this._TDebit != value))
                {
                    this._TDebit = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TCredit", DbType = "Money")]
        public System.Nullable<decimal> TCredit
        {
            get
            {
                return this._TCredit;
            }
            set
            {
                if ((this._TCredit != value))
                {
                    this._TCredit = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_SDebit", DbType = "Money")]
        public System.Nullable<decimal> SDebit
        {
            get
            {
                return this._SDebit;
            }
            set
            {
                if ((this._SDebit != value))
                {
                    this._SDebit = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_SCredit", DbType = "Money")]
        public System.Nullable<decimal> SCredit
        {
            get
            {
                return this._SCredit;
            }
            set
            {
                if ((this._SCredit != value))
                {
                    this._SCredit = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Currency", DbType = "NVarChar(50)")]
        public string Currency
        {
            get
            {
                return this._Currency;
            }
            set
            {
                if ((this._Currency != value))
                {
                    this._Currency = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Balance", DbType = "Money")]
        public System.Nullable<decimal> Balance
        {
            get
            {
                return this._Balance;
            }
            set
            {
                if ((this._Balance != value))
                {
                    this._Balance = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyId", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CompanyId
        {
            get
            {
                return this._CompanyId;
            }
            set
            {
                if ((this._CompanyId != value))
                {
                    this._CompanyId = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IsBalance", DbType = "Bit")]
        public System.Nullable<bool> IsBalance
        {
            get
            {
                return this._IsBalance;
            }
            set
            {
                if ((this._IsBalance != value))
                {
                    this._IsBalance = value;
                }
            }
        }
    }

    public partial class ClassChildResult
    {

        private string _ChildId;

        private string _ChildName;

        private string _ParentId;

        private string _ParentName;

        public ClassChildResult()
        {
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ChildId", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string ChildId
        {
            get
            {
                return this._ChildId;
            }
            set
            {
                if ((this._ChildId != value))
                {
                    this._ChildId = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ChildName", DbType = "NVarChar(255)")]
        public string ChildName
        {
            get
            {
                return this._ChildName;
            }
            set
            {
                if ((this._ChildName != value))
                {
                    this._ChildName = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ParentId", DbType = "NVarChar(50)")]
        public string ParentId
        {
            get
            {
                return this._ParentId;
            }
            set
            {
                if ((this._ParentId != value))
                {
                    this._ParentId = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ParentName", DbType = "NVarChar(255)")]
        public string ParentName
        {
            get
            {
                return this._ParentName;
            }
            set
            {
                if ((this._ParentName != value))
                {
                    this._ParentName = value;
                }
            }
        }
    }

    public partial class GetAccountBalanceResult
    {

        private string _AccountId;

        private string _Name;

        private decimal _Debit;

        private decimal _Credit;

        private string _Currency;

        public GetAccountBalanceResult()
        {
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_AccountId", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string AccountId
        {
            get
            {
                return this._AccountId;
            }
            set
            {
                if ((this._AccountId != value))
                {
                    this._AccountId = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Name", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                if ((this._Name != value))
                {
                    this._Name = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Debit", DbType = "Decimal(18,2) NOT NULL")]
        public decimal Debit
        {
            get
            {
                return this._Debit;
            }
            set
            {
                if ((this._Debit != value))
                {
                    this._Debit = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Credit", DbType = "Decimal(18,2) NOT NULL")]
        public decimal Credit
        {
            get
            {
                return this._Credit;
            }
            set
            {
                if ((this._Credit != value))
                {
                    this._Credit = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Currency", DbType = "NVarChar(10) NOT NULL", CanBeNull = false)]
        public string Currency
        {
            get
            {
                return this._Currency;
            }
            set
            {
                if ((this._Currency != value))
                {
                    this._Currency = value;
                }
            }
        }
    }

    public partial class GetBalanceSheetChildrenResult
    {

        private string _id;

        private string _name;

        public GetBalanceSheetChildrenResult()
        {
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id", DbType = "NVarChar(50)")]
        public string id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    this._id = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_name", DbType = "NVarChar(255)")]
        public string name
        {
            get
            {
                return this._name;
            }
            set
            {
                if ((this._name != value))
                {
                    this._name = value;
                }
            }
        }
    }

    public partial class GetAccountBalancesResult
    {

        private string _AccountId;

        private string _Name;

        private System.Nullable<decimal> _TDebit;

        private System.Nullable<decimal> _TCredit;

        private System.Nullable<decimal> _SDebit;

        private System.Nullable<decimal> _SCredit;

        private string _Currency;

        public GetAccountBalancesResult()
        {
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_AccountId", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string AccountId
        {
            get
            {
                return this._AccountId;
            }
            set
            {
                if ((this._AccountId != value))
                {
                    this._AccountId = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Name", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                if ((this._Name != value))
                {
                    this._Name = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TDebit", DbType = "Decimal(38,2)")]
        public System.Nullable<decimal> TDebit
        {
            get
            {
                return this._TDebit;
            }
            set
            {
                if ((this._TDebit != value))
                {
                    this._TDebit = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TCredit", DbType = "Decimal(38,2)")]
        public System.Nullable<decimal> TCredit
        {
            get
            {
                return this._TCredit;
            }
            set
            {
                if ((this._TCredit != value))
                {
                    this._TCredit = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_SDebit", DbType = "Decimal(38,2)")]
        public System.Nullable<decimal> SDebit
        {
            get
            {
                return this._SDebit;
            }
            set
            {
                if ((this._SDebit != value))
                {
                    this._SDebit = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_SCredit", DbType = "Decimal(38,2)")]
        public System.Nullable<decimal> SCredit
        {
            get
            {
                return this._SCredit;
            }
            set
            {
                if ((this._SCredit != value))
                {
                    this._SCredit = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Currency", DbType = "NVarChar(10) NOT NULL", CanBeNull = false)]
        public string Currency
        {
            get
            {
                return this._Currency;
            }
            set
            {
                if ((this._Currency != value))
                {
                    this._Currency = value;
                }
            }
        }
    }

    public partial class GetChildResult
    {

        private string _ChildId;

        private string _ChildName;

        private string _ParentId;

        private string _ParentName;

        public GetChildResult()
        {
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ChildId", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string ChildId
        {
            get
            {
                return this._ChildId;
            }
            set
            {
                if ((this._ChildId != value))
                {
                    this._ChildId = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ChildName", DbType = "NVarChar(255)")]
        public string ChildName
        {
            get
            {
                return this._ChildName;
            }
            set
            {
                if ((this._ChildName != value))
                {
                    this._ChildName = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ParentId", DbType = "NVarChar(50)")]
        public string ParentId
        {
            get
            {
                return this._ParentId;
            }
            set
            {
                if ((this._ParentId != value))
                {
                    this._ParentId = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ParentName", DbType = "NVarChar(255)")]
        public string ParentName
        {
            get
            {
                return this._ParentName;
            }
            set
            {
                if ((this._ParentName != value))
                {
                    this._ParentName = value;
                }
            }
        }
    }

    public partial class GetChildrenResult
    {

        private string _id;

        public GetChildrenResult()
        {
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id", DbType = "NVarChar(50)")]
        public string id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    this._id = value;
                }
            }
        }
    }

    public partial class GetJournalResult
    {

        private int _ID;

        private int _ItemID;

        private int _OID;

        private string _LocalName;

        private string _CustSupplierID;

        private System.DateTime _TransDate;

        private string _Periode;

        private string _Account;

        private string _OAccount;

        private decimal _Amount;

        private string _Side;

        private string _Currency;

        private string _CompanyID;

        public GetJournalResult()
        {
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ID", DbType = "Int NOT NULL")]
        public int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                if ((this._ID != value))
                {
                    this._ID = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ItemID", DbType = "Int NOT NULL")]
        public int ItemID
        {
            get
            {
                return this._ItemID;
            }
            set
            {
                if ((this._ItemID != value))
                {
                    this._ItemID = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_OID", DbType = "Int NOT NULL")]
        public int OID
        {
            get
            {
                return this._OID;
            }
            set
            {
                if ((this._OID != value))
                {
                    this._OID = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_LocalName", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string LocalName
        {
            get
            {
                return this._LocalName;
            }
            set
            {
                if ((this._LocalName != value))
                {
                    this._LocalName = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CustSupplierID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CustSupplierID
        {
            get
            {
                return this._CustSupplierID;
            }
            set
            {
                if ((this._CustSupplierID != value))
                {
                    this._CustSupplierID = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TransDate", DbType = "DateTime NOT NULL")]
        public System.DateTime TransDate
        {
            get
            {
                return this._TransDate;
            }
            set
            {
                if ((this._TransDate != value))
                {
                    this._TransDate = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Periode", DbType = "NChar(6) NOT NULL", CanBeNull = false)]
        public string Periode
        {
            get
            {
                return this._Periode;
            }
            set
            {
                if ((this._Periode != value))
                {
                    this._Periode = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Account", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string Account
        {
            get
            {
                return this._Account;
            }
            set
            {
                if ((this._Account != value))
                {
                    this._Account = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_OAccount", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string OAccount
        {
            get
            {
                return this._OAccount;
            }
            set
            {
                if ((this._OAccount != value))
                {
                    this._OAccount = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Amount", DbType = "Money NOT NULL")]
        public decimal Amount
        {
            get
            {
                return this._Amount;
            }
            set
            {
                if ((this._Amount != value))
                {
                    this._Amount = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Side", DbType = "NVarChar(6) NOT NULL", CanBeNull = false)]
        public string Side
        {
            get
            {
                return this._Side;
            }
            set
            {
                if ((this._Side != value))
                {
                    this._Side = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Currency", DbType = "NVarChar(10) NOT NULL", CanBeNull = false)]
        public string Currency
        {
            get
            {
                return this._Currency;
            }
            set
            {
                if ((this._Currency != value))
                {
                    this._Currency = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CompanyID
        {
            get
            {
                return this._CompanyID;
            }
            set
            {
                if ((this._CompanyID != value))
                {
                    this._CompanyID = value;
                }
            }
        }
    }

    public partial class GetJournalsResult
    {

        private string _AccountName;

        private int _ItemID;

        private string _LocalName;

        private string _Owner;

        private System.DateTime _TransDate;

        private string _Account;

        private string _OAccount;

        private string _Side;

        private decimal _Amount;

        private string _Currency;

        private string _CompanyID;

        private string _OAccountName;

        private string _Periode;

        private int _OID;

        private string _CustSupplierID;

        private int _ID;

        public GetJournalsResult()
        {
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_AccountName", DbType = "NVarChar(306)")]
        public string AccountName
        {
            get
            {
                return this._AccountName;
            }
            set
            {
                if ((this._AccountName != value))
                {
                    this._AccountName = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ItemID", DbType = "Int NOT NULL")]
        public int ItemID
        {
            get
            {
                return this._ItemID;
            }
            set
            {
                if ((this._ItemID != value))
                {
                    this._ItemID = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_LocalName", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string LocalName
        {
            get
            {
                return this._LocalName;
            }
            set
            {
                if ((this._LocalName != value))
                {
                    this._LocalName = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Owner", DbType = "NVarChar(306) NOT NULL", CanBeNull = false)]
        public string Owner
        {
            get
            {
                return this._Owner;
            }
            set
            {
                if ((this._Owner != value))
                {
                    this._Owner = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TransDate", DbType = "DateTime NOT NULL")]
        public System.DateTime TransDate
        {
            get
            {
                return this._TransDate;
            }
            set
            {
                if ((this._TransDate != value))
                {
                    this._TransDate = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Account", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string Account
        {
            get
            {
                return this._Account;
            }
            set
            {
                if ((this._Account != value))
                {
                    this._Account = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_OAccount", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string OAccount
        {
            get
            {
                return this._OAccount;
            }
            set
            {
                if ((this._OAccount != value))
                {
                    this._OAccount = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Side", DbType = "NVarChar(6) NOT NULL", CanBeNull = false)]
        public string Side
        {
            get
            {
                return this._Side;
            }
            set
            {
                if ((this._Side != value))
                {
                    this._Side = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Amount", DbType = "Money NOT NULL")]
        public decimal Amount
        {
            get
            {
                return this._Amount;
            }
            set
            {
                if ((this._Amount != value))
                {
                    this._Amount = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Currency", DbType = "NVarChar(10) NOT NULL", CanBeNull = false)]
        public string Currency
        {
            get
            {
                return this._Currency;
            }
            set
            {
                if ((this._Currency != value))
                {
                    this._Currency = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CompanyID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CompanyID
        {
            get
            {
                return this._CompanyID;
            }
            set
            {
                if ((this._CompanyID != value))
                {
                    this._CompanyID = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_OAccountName", DbType = "NVarChar(306)")]
        public string OAccountName
        {
            get
            {
                return this._OAccountName;
            }
            set
            {
                if ((this._OAccountName != value))
                {
                    this._OAccountName = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Periode", DbType = "NChar(6) NOT NULL", CanBeNull = false)]
        public string Periode
        {
            get
            {
                return this._Periode;
            }
            set
            {
                if ((this._Periode != value))
                {
                    this._Periode = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_OID", DbType = "Int NOT NULL")]
        public int OID
        {
            get
            {
                return this._OID;
            }
            set
            {
                if ((this._OID != value))
                {
                    this._OID = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CustSupplierID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CustSupplierID
        {
            get
            {
                return this._CustSupplierID;
            }
            set
            {
                if ((this._CustSupplierID != value))
                {
                    this._CustSupplierID = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ID", DbType = "Int NOT NULL")]
        public int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                if ((this._ID != value))
                {
                    this._ID = value;
                }
            }
        }
    }

    public partial class GetParentsResult
    {

        private string _id;

        private string _name;

        public GetParentsResult()
        {
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id", DbType = "NVarChar(50)")]
        public string id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    this._id = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_name", DbType = "NVarChar(255)")]
        public string name
        {
            get
            {
                return this._name;
            }
            set
            {
                if ((this._name != value))
                {
                    this._name = value;
                }
            }
        }
    }
}
