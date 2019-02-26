
namespace IWSProject.Models
{
    using IWSProject.Models.Entities;
    using System;
    using System.Data;
    using System.Data.Linq;
    using System.Data.Linq.Mapping;
    using System.Linq;
    using System.Reflection;

    [Database(Name = "IWSConnectionString")]
    public partial class IWSDataContext : DataContext
    {
        private static MappingSource mappingSource = new AttributeMappingSource();

        #region Extensibility Method Definitions
        partial void OnCreated();
        partial void InsertAccount(Account instance);
        partial void UpdateAccount(Account instance);
        partial void DeleteAccount(Account instance);
        partial void InsertBankStatement(BankStatement instance);
        partial void UpdateBankStatement(BankStatement instance);
        partial void DeleteBankStatement(BankStatement instance);
        partial void InsertAffectationJournal(AffectationJournal instance);
        partial void UpdateAffectationJournal(AffectationJournal instance);
        partial void DeleteAffectationJournal(AffectationJournal instance);
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
        partial void InsertBrouillard(Brouillard instance);
        partial void UpdateBrouillard(Brouillard instance);
        partial void DeleteBrouillard(Brouillard instance);
        partial void InsertCash(Cash instance);
        partial void UpdateCash(Cash instance);
        partial void DeleteCash(Cash instance);
        partial void InsertCashLine(CashLine instance);
        partial void UpdateCashLine(CashLine instance);
        partial void DeleteCashLine(CashLine instance);
        partial void InsertClassSetup(ClassSetup instance);
        partial void UpdateClassSetup(ClassSetup instance);
        partial void DeleteClassSetup(ClassSetup instance);
        partial void InsertCompany(Company instance);
        partial void UpdateCompany(Company instance);
        partial void DeleteCompany(Company instance);
        partial void InsertCostCenter(CostCenter instance);
        partial void UpdateCostCenter(CostCenter instance);
        partial void DeleteCostCenter(CostCenter instance);
        partial void InsertCurrency(Currency instance);
        partial void UpdateCurrency(Currency instance);
        partial void DeleteCurrency(Currency instance);
        partial void InsertCustomer(Customer instance);
        partial void UpdateCustomer(Customer instance);
        partial void DeleteCustomer(Customer instance);
        partial void InsertDepreciation(Depreciation instance);
        partial void UpdateDepreciation(Depreciation instance);
        partial void DeleteDepreciation(Depreciation instance);
        partial void InsertDepreciationDetail(DepreciationDetail instance);
        partial void UpdateDepreciationDetail(DepreciationDetail instance);
        partial void DeleteDepreciationDetail(DepreciationDetail instance);
        partial void InsertDetailCompta(DetailCompta instance);
        partial void UpdateDetailCompta(DetailCompta instance);
        partial void DeleteDetailCompta(DetailCompta instance);
        partial void InsertDetailDetailCompta(DetailDetailCompta instance);
        partial void UpdateDetailDetailCompta(DetailDetailCompta instance);
        partial void DeleteDetailDetailCompta(DetailDetailCompta instance);
        partial void InsertDetailLogistic(DetailLogistic instance);
        partial void UpdateDetailLogistic(DetailLogistic instance);
        partial void DeleteDetailLogistic(DetailLogistic instance);
        partial void InsertFiscalYear(FiscalYear instance);
        partial void UpdateFiscalYear(FiscalYear instance);
        partial void DeleteFiscalYear(FiscalYear instance);
        partial void InsertJournal(Journal instance);
        partial void UpdateJournal(Journal instance);
        partial void DeleteJournal(Journal instance);
        partial void InsertJournalStock(JournalStock instance);
        partial void UpdateJournalStock(JournalStock instance);
        partial void DeleteJournalStock(JournalStock instance);
        partial void InsertLocalization(Localization instance);
        partial void UpdateLocalization(Localization instance);
        partial void DeleteLocalization(Localization instance);
        partial void InsertLogException(LogException instance);
        partial void UpdateLogException(LogException instance);
        partial void DeleteLogException(LogException instance);
        partial void InsertLookupAccountAmount(LookupAccountAmount instance);
        partial void UpdateLookupAccountAmount(LookupAccountAmount instance);
        partial void DeleteLookupAccountAmount(LookupAccountAmount instance);
        partial void InsertMasterCompta(MasterCompta instance);
        partial void UpdateMasterCompta(MasterCompta instance);
        partial void DeleteMasterCompta(MasterCompta instance);
        partial void InsertMasterLogistic(MasterLogistic instance);
        partial void UpdateMasterLogistic(MasterLogistic instance);
        partial void DeleteMasterLogistic(MasterLogistic instance);
        partial void InsertMenu(Menu instance);
        partial void UpdateMenu(Menu instance);
        partial void DeleteMenu(Menu instance);
        partial void InsertPeriodicAccountBalance(PeriodicAccountBalance instance);
        partial void UpdatePeriodicAccountBalance(PeriodicAccountBalance instance);
        partial void DeletePeriodicAccountBalance(PeriodicAccountBalance instance);
        partial void InsertQuantityUnit(QuantityUnit instance);
        partial void UpdateQuantityUnit(QuantityUnit instance);
        partial void DeleteQuantityUnit(QuantityUnit instance);
        partial void InsertStock(Stock instance);
        partial void UpdateStock(Stock instance);
        partial void DeleteStock(Stock instance);
        partial void InsertStore(Store instance);
        partial void UpdateStore(Store instance);
        partial void DeleteStore(Store instance);
        partial void InsertSupplier(Supplier instance);
        partial void UpdateSupplier(Supplier instance);
        partial void DeleteSupplier(Supplier instance);
        partial void InserttempAccountAmount(tempAccountAmount instance);
        partial void UpdatetempAccountAmount(tempAccountAmount instance);
        partial void DeletetempAccountAmount(tempAccountAmount instance);
        partial void InsertTimeSheet(TimeSheet instance);
        partial void UpdateTimeSheet(TimeSheet instance);
        partial void DeleteTimeSheet(TimeSheet instance);
        partial void InsertTimeSheetLine(TimeSheetLine instance);
        partial void UpdateTimeSheetLine(TimeSheetLine instance);
        partial void DeleteTimeSheetLine(TimeSheetLine instance);
        partial void InsertTypeBrouillard(TypeBrouillard instance);
        partial void UpdateTypeBrouillard(TypeBrouillard instance);
        partial void DeleteTypeBrouillard(TypeBrouillard instance);
        partial void InsertTypeJournal(TypeJournal instance);
        partial void UpdateTypeJournal(TypeJournal instance);
        partial void DeleteTypeJournal(TypeJournal instance);
        partial void InsertVat(Vat instance);
        partial void UpdateVat(Vat instance);
        partial void DeleteVat(Vat instance);
        #endregion
        #region DBContext

        public IWSDataContext() :
        base(System.Configuration.ConfigurationManager.ConnectionStrings["IWSConnectionString"].ConnectionString, mappingSource)
        {
            OnCreated();
        }
        public IWSDataContext(string connection) :
                base(connection, mappingSource)
        {
            OnCreated();
        }
        public IWSDataContext(IDbConnection connection) :
                base(connection, mappingSource)
        {
            OnCreated();
        }
        public IWSDataContext(string connection, MappingSource mappingSource) :
                base(connection, mappingSource)
        {
            OnCreated();
        }
        public IWSDataContext(IDbConnection connection, MappingSource mappingSource) :
                base(connection, mappingSource)
        {
            OnCreated();
        }

        public Table<Account> GetAccounts()
        {
            return this.GetTable<Account>();
        }

        public Table<BankStatement> BankStatements
        {
            get
            {
                return this.GetTable<BankStatement>();
            }
        }

        public Table<AffectationJournal> AffectationJournals
        {
            get
            {
                return this.GetTable<AffectationJournal>();
            }
        }

        public Table<Article> Articles
        {
            get
            {
                return this.GetTable<Article>();
            }
        }

        public Table<AspNetRole> AspNetRoles
        {
            get
            {
                return this.GetTable<AspNetRole>();
            }
        }

        public Table<AspNetUserClaim> AspNetUserClaims
        {
            get
            {
                return this.GetTable<AspNetUserClaim>();
            }
        }

        public Table<AspNetUserLogin> AspNetUserLogins
        {
            get
            {
                return this.GetTable<AspNetUserLogin>();
            }
        }

        public Table<AspNetUserRole> AspNetUserRoles
        {
            get
            {
                return this.GetTable<AspNetUserRole>();
            }
        }

        public Table<AspNetUser> AspNetUsers
        {
            get
            {
                return this.GetTable<AspNetUser>();
            }
        }

        public Table<Asset> Assets
        {
            get
            {
                return this.GetTable<Asset>();
            }
        }

        public Table<Bank> Banks
        {
            get
            {
                return this.GetTable<Bank>();
            }
        }

        public Table<BankAccount> BankAccounts
        {
            get
            {
                return this.GetTable<BankAccount>();
            }
        }

        public Table<Brouillard> Brouillards
        {
            get
            {
                return this.GetTable<Brouillard>();
            }
        }

        public Table<Cash> Cashes
        {
            get
            {
                return this.GetTable<Cash>();
            }
        }

        public Table<CashLine> CashLines
        {
            get
            {
                return this.GetTable<CashLine>();
            }
        }

        public Table<ClassSetup> ClassSetups
        {
            get
            {
                return this.GetTable<ClassSetup>();
            }
        }

        public Table<Company> Companies
        {
            get
            {
                return this.GetTable<Company>();
            }
        }

        public Table<CostCenter> CostCenters
        {
            get
            {
                return this.GetTable<CostCenter>();
            }
        }

        public Table<Currency> Currencies
        {
            get
            {
                return this.GetTable<Currency>();
            }
        }

        public Table<Customer> Customers
        {
            get
            {
                return this.GetTable<Customer>();
            }
        }

        public Table<Depreciation> Depreciations
        {
            get
            {
                return this.GetTable<Depreciation>();
            }
        }

        public Table<DepreciationDetail> DepreciationDetails
        {
            get
            {
                return this.GetTable<DepreciationDetail>();
            }
        }

        public Table<DetailCompta> DetailComptas
        {
            get
            {
                return this.GetTable<DetailCompta>();
            }
        }

        public Table<DetailDetailCompta> DetailDetailComptas
        {
            get
            {
                return this.GetTable<DetailDetailCompta>();
            }
        }

        public Table<DetailLogistic> DetailLogistics
        {
            get
            {
                return this.GetTable<DetailLogistic>();
            }
        }

        public Table<FiscalYear> FiscalYears
        {
            get
            {
                return this.GetTable<FiscalYear>();
            }
        }

        public Table<Journal> Journals
        {
            get
            {
                return this.GetTable<Journal>();
            }
        }

        public Table<JournalStock> JournalStocks
        {
            get
            {
                return this.GetTable<JournalStock>();
            }
        }

        public Table<Localization> Localizations
        {
            get
            {
                return this.GetTable<Localization>();
            }
        }

        public Table<LogException> LogExceptions
        {
            get
            {
                return this.GetTable<LogException>();
            }
        }

        public Table<LookupAccountAmount> LookupAccountAmounts
        {
            get
            {
                return this.GetTable<LookupAccountAmount>();
            }
        }

        public Table<MasterCompta> MasterComptas
        {
            get
            {
                return this.GetTable<MasterCompta>();
            }
        }

        public Table<MasterLogistic> MasterLogistics
        {
            get
            {
                return this.GetTable<MasterLogistic>();
            }
        }

        public Table<Menu> Menus
        {
            get
            {
                return this.GetTable<Menu>();
            }
        }

        public Table<PeriodicAccountBalance> PeriodicAccountBalances
        {
            get
            {
                return this.GetTable<PeriodicAccountBalance>();
            }
        }

        public Table<QuantityUnit> QuantityUnits
        {
            get
            {
                return this.GetTable<QuantityUnit>();
            }
        }

        public Table<Stock> Stocks
        {
            get
            {
                return this.GetTable<Stock>();
            }
        }

        public Table<Store> Stores
        {
            get
            {
                return this.GetTable<Store>();
            }
        }

        public Table<Supplier> Suppliers
        {
            get
            {
                return this.GetTable<Supplier>();
            }
        }

        public Table<tempAccountAmount> tempAccountAmounts
        {
            get
            {
                return this.GetTable<tempAccountAmount>();
            }
        }

        public System.Data.Linq.Table<TimeSheet> TimeSheets
        {
            get
            {
                return this.GetTable<TimeSheet>();
            }
        }

        public System.Data.Linq.Table<TimeSheetLine> TimeSheetLines
        {
            get
            {
                return this.GetTable<TimeSheetLine>();
            }
        }

        public Table<TypeBrouillard> TypeBrouillards
        {
            get
            {
                return this.GetTable<TypeBrouillard>();
            }
        }

        public Table<TypeJournal> TypeJournals
        {
            get
            {
                return this.GetTable<TypeJournal>();
            }
        }

        public Table<Vat> Vats
        {
            get
            {
                return this.GetTable<Vat>();
            }
        }
        #endregion
        #region Functions and SP
        [FunctionAttribute(Name = "dbo.account1To7")]
        public ISingleResult<account1To7Result> account1To7([ParameterAttribute(DbType = "NVarChar(6)")] string start, [ParameterAttribute(DbType = "NVarChar(6)")] string end, [ParameterAttribute(DbType = "NVarChar(6)")] string companyid)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), start, end, companyid);
            return ((ISingleResult<account1To7Result>)(result.ReturnValue));
        }

        [FunctionAttribute(Name = "dbo.ClassAccountBalance")]
        public ISingleResult<ClassAccountBalanceResult> ClassAccountBalance([ParameterAttribute(Name = "class", DbType = "NVarChar(12)")] string @class, [ParameterAttribute(DbType = "NVarChar(6)")] string start, [ParameterAttribute(DbType = "NVarChar(6)")] string end, [ParameterAttribute(DbType = "NVarChar(6)")] string companyid)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), @class, start, end, companyid);
            return ((ISingleResult<ClassAccountBalanceResult>)(result.ReturnValue));
        }

        [FunctionAttribute(Name = "dbo.ClassAccountBalances")]
        public ISingleResult<ClassAccountBalancesResult> ClassAccountBalances([ParameterAttribute(DbType = "NVarChar(6)")] string start, [ParameterAttribute(DbType = "NVarChar(6)")] string end, [ParameterAttribute(DbType = "NVarChar(6)")] string companyid)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), start, end, companyid);
            return ((ISingleResult<ClassAccountBalancesResult>)(result.ReturnValue));
        }

        [FunctionAttribute(Name = "dbo.GetAccountBalance", IsComposable = true)]
        public IQueryable<GetAccountBalanceResult> GetAccountBalance([ParameterAttribute(DbType = "NVarChar(50)")] string id, [ParameterAttribute(DbType = "NVarChar(6)")] string start, [ParameterAttribute(DbType = "NVarChar(6)")] string end, [ParameterAttribute(DbType = "NVarChar(6)")] string companyid)
        {
            return this.CreateMethodCallQuery<GetAccountBalanceResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), id, start, end, companyid);
        }

        [FunctionAttribute(Name = "dbo.GetAccountBalances", IsComposable = true)]
        public IQueryable<GetAccountBalancesResult> GetAccountBalances([ParameterAttribute(Name = "class", DbType = "NVarChar(12)")] string @class, [ParameterAttribute(DbType = "NVarChar(6)")] string start, [ParameterAttribute(DbType = "NVarChar(6)")] string end, [ParameterAttribute(DbType = "NVarChar(6)")] string companyid)
        {
            return this.CreateMethodCallQuery<GetAccountBalancesResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), @class, start, end, companyid);
        }

        [FunctionAttribute(Name = "dbo.GetBalanceSheetChildren", IsComposable = true)]
        public IQueryable<GetBalanceSheetChildrenResult> GetBalanceSheetChildren([ParameterAttribute(DbType = "NVarChar(50)")] string id, [ParameterAttribute(DbType = "NVarChar(50)")] string companyid, [ParameterAttribute(DbType = "Bit")] Nullable<bool> isBalanceSheetAccount)
        {
            return this.CreateMethodCallQuery<GetBalanceSheetChildrenResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), id, companyid, isBalanceSheetAccount);
        }

        [FunctionAttribute(Name = "dbo.GetChildren", IsComposable = true)]
        public IQueryable<GetChildrenResult> GetChildren([ParameterAttribute(DbType = "NVarChar(50)")] string id, [ParameterAttribute(DbType = "NVarChar(50)")] string companyid)
        {
            return this.CreateMethodCallQuery<GetChildrenResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), id, companyid);
        }

        [FunctionAttribute(Name = "dbo.GetParents", IsComposable = true)]
        public IQueryable<GetParentsResult> GetParents([ParameterAttribute(DbType = "NVarChar(50)")] string id, [ParameterAttribute(DbType = "NVarChar(50)")] string companyid)
        {
            return this.CreateMethodCallQuery<GetParentsResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), id, companyid);
        }

        [FunctionAttribute(Name = "dbo.LogException")]
        public int LogException([ParameterAttribute(Name = "Message", DbType = "NVarChar(256)")] string message, [ParameterAttribute(Name = "Type", DbType = "NVarChar(256)")] string type, [ParameterAttribute(Name = "Source", DbType = "NVarChar(256)")] string source, [ParameterAttribute(Name = "URL", DbType = "NVarChar(256)")] string uRL, [ParameterAttribute(Name = "Target", DbType = "NVarChar(256)")] string target, [ParameterAttribute(Name = "ComapnyId", DbType = "NVarChar(6)")] string comapnyId, [ParameterAttribute(Name = "UserName", DbType = "NVarChar(6)")] string userName)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), message, type, source, uRL, target, comapnyId, userName);
            return ((int)(result.ReturnValue));
        }

        [FunctionAttribute(Name = "dbo.GetFiscalYears")]
        public ISingleResult<GetFiscalYearsResult> GetFiscalYears([ParameterAttribute(DbType = "NVarChar(6)")] string companyid)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), companyid);
            return ((ISingleResult<GetFiscalYearsResult>)(result.ReturnValue));
        }

        [FunctionAttribute(Name = "dbo.CloseFiscalYear")]
        public ISingleResult<CloseFiscalYearResult> CloseFiscalYear([ParameterAttribute(DbType = "NVarChar(6)")] string companyId)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), companyId);
            return ((ISingleResult<CloseFiscalYearResult>)(result.ReturnValue));
        }

        [FunctionAttribute(Name = "dbo.OpenFiscalYear")]
        public int OpenFiscalYear([ParameterAttribute(Name = "NStart", DbType = "VarChar(6)")] string nStart, [ParameterAttribute(Name = "NEnd", DbType = "VarChar(6)")] string nEnd, [ParameterAttribute(Name = "CompanyId", DbType = "VarChar(50)")] string companyId, [ParameterAttribute(Name = "Current", DbType = "Bit")] Nullable<bool> current, [ParameterAttribute(Name = "Open", DbType = "Bit")] Nullable<bool> open)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), nStart, nEnd, companyId, current, open);
            return ((int)(result.ReturnValue));
        }

        [FunctionAttribute(Name = "dbo.GetBrouillard")]
        public ISingleResult<GetBrouillardResult> GetBrouillard([ParameterAttribute(Name = "TypeDoc", DbType = "VarChar(2)")] string typeDoc, [ParameterAttribute(Name = "NumPiece", DbType = "VarChar(15)")] string numPiece, [ParameterAttribute(Name = "CompanyId", DbType = "VarChar(15)")] string companyId, [ParameterAttribute(Name = "ItemId", DbType = "Int")] Nullable<int> itemId)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), typeDoc, numPiece, companyId, itemId);
            return ((ISingleResult<GetBrouillardResult>)(result.ReturnValue));
        }

        [FunctionAttribute(Name = "dbo.PeriodicBalances")]
        public ISingleResult<PeriodicBalancesResult> PeriodicBalances([ParameterAttribute(DbType = "NVarChar(6)")] string start, [ParameterAttribute(DbType = "NVarChar(6)")] string end, [ParameterAttribute(DbType = "NVarChar(550)")] string selectedIDs, [ParameterAttribute(DbType = "NVarChar(4)")] string companyid)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), start, end, selectedIDs, companyid);
            return ((ISingleResult<PeriodicBalancesResult>)(result.ReturnValue));
        }

        [FunctionAttribute(Name = "dbo.SetTypeJournal")]
        public int SetTypeJournal([ParameterAttribute(DbType = "VarChar(100)")] string typedoc, [ParameterAttribute(DbType = "Int")] Nullable<int> transid, [ParameterAttribute(DbType = "NVarChar(50)")] string companyid)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), typedoc, transid, companyid);
            return ((int)(result.ReturnValue));
        }

        [FunctionAttribute(Name = "dbo.GetChild", IsComposable = true)]
        public IQueryable<GetChildResult> GetChild([ParameterAttribute(DbType = "NVarChar(50)")] string classId, [ParameterAttribute(DbType = "NVarChar(50)")] string companyid)
        {
            return this.CreateMethodCallQuery<GetChildResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), classId, companyid);
        }

        [FunctionAttribute(Name = "dbo.ClassChildren")]
        public ISingleResult<ClassChildrenResult> ClassChildren([ParameterAttribute(DbType = "NVarChar(50)")] string classId, [ParameterAttribute(DbType = "NVarChar(50)")] string company)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), classId, company);
            return ((ISingleResult<ClassChildrenResult>)(result.ReturnValue));
        }

        [FunctionAttribute(Name = "dbo.ClassChild")]
        public ISingleResult<ClassChildResult> ClassChild([ParameterAttribute(DbType = "NVarChar(50)")] string classId, [ParameterAttribute(DbType = "NVarChar(50)")] string company)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), classId, company);
            return ((ISingleResult<ClassChildResult>)(result.ReturnValue));
        }

        [FunctionAttribute(Name = "dbo.AccountBalance")]
        public ISingleResult<AccountBalanceResult> AccountBalance([ParameterAttribute(Name = "class", DbType = "NVarChar(50)")] string @class, [ParameterAttribute(DbType = "NVarChar(6)")] string start, [ParameterAttribute(DbType = "NVarChar(6)")] string end, [ParameterAttribute(DbType = "NVarChar(6)")] string companyid, [ParameterAttribute(DbType = "Bit")] Nullable<bool> isBalance)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), @class, start, end, companyid, isBalance);
            return ((ISingleResult<AccountBalanceResult>)(result.ReturnValue));
        }

        [FunctionAttribute(Name = "dbo.SetJournal")]
        public int SetJournal([ParameterAttribute(DbType = "Int")] Nullable<int> transid, [ParameterAttribute(DbType = "NVarChar(50)")] string companyid)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), transid, companyid);
            return ((int)(result.ReturnValue));
        }

        [FunctionAttribute(Name = "dbo.GetJournal")]
        public ISingleResult<GetJournalResult> GetJournal([ParameterAttribute(DbType = "NVarChar(6)")] string start, [ParameterAttribute(DbType = "NVarChar(6)")] string end, [ParameterAttribute(DbType = "NVarChar(5)")] string uiculture, [ParameterAttribute(Name = "Companyid", DbType = "NVarChar(6)")] string companyid)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), start, end, uiculture, companyid);
            return ((ISingleResult<GetJournalResult>)(result.ReturnValue));
        }

        #endregion
    }
    #region Function and SP
    public partial class account1To7Result
    {

        private int _gr;

        private string _ID;

        private string _AccountId;

        private string _Name;

        private decimal? _TDebit;

        private decimal? _TCredit;

        private decimal? _SDebit;

        private decimal? _SCredit;

        private string _Currency;

        public account1To7Result()
        {
        }

        [ColumnAttribute(Storage = "_gr", DbType = "Int NOT NULL")]
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

        [ColumnAttribute(Storage = "_ID", DbType = "NVarChar(1)")]
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

        [ColumnAttribute(Storage = "_AccountId", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_Name", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_TDebit", DbType = "Decimal(38,2)")]
        public decimal? TDebit
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

        [ColumnAttribute(Storage = "_TCredit", DbType = "Decimal(38,2)")]
        public decimal? TCredit
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

        [ColumnAttribute(Storage = "_SDebit", DbType = "Decimal(38,2)")]
        public decimal? SDebit
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

        [ColumnAttribute(Storage = "_SCredit", DbType = "Decimal(38,2)")]
        public decimal? SCredit
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

        [ColumnAttribute(Storage = "_Currency", DbType = "NVarChar(10) NOT NULL", CanBeNull = false)]
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

    public partial class ClassAccountBalanceResult
    {

        private string _ID;

        private string _AccountId;

        private string _Name;

        private decimal? _TDebit;

        private decimal? _TCredit;

        private decimal? _SDebit;

        private decimal? _SCredit;

        private string _Currency;

        public ClassAccountBalanceResult()
        {
        }

        [ColumnAttribute(Storage = "_ID", DbType = "NVarChar(1)")]
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

        [ColumnAttribute(Storage = "_AccountId", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_Name", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_TDebit", DbType = "Decimal(38,2)")]
        public decimal? TDebit
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

        [ColumnAttribute(Storage = "_TCredit", DbType = "Decimal(38,2)")]
        public decimal? TCredit
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

        [ColumnAttribute(Storage = "_SDebit", DbType = "Decimal(38,2)")]
        public decimal? SDebit
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

        [ColumnAttribute(Storage = "_SCredit", DbType = "Decimal(38,2)")]
        public decimal? SCredit
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

        [ColumnAttribute(Storage = "_Currency", DbType = "NVarChar(10) NOT NULL", CanBeNull = false)]
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

        private decimal? _TDebit;

        private decimal? _TCredit;

        private decimal? _SDebit;

        private decimal? _SCredit;

        private string _Currency;

        private decimal? _Balance;

        private string _CompanyId;

        private bool? _IsBalance;

        public ClassAccountBalancesResult()
        {
        }

        [ColumnAttribute(Storage = "_ID", DbType = "Int NOT NULL")]
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

        [ColumnAttribute(Storage = "_ClassId", DbType = "NVarChar(50)")]
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

        [ColumnAttribute(Storage = "_ClassName", DbType = "NVarChar(150)")]
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

        [ColumnAttribute(Storage = "_SubClassId", DbType = "NVarChar(50)")]
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

        [ColumnAttribute(Storage = "_SubClassName", DbType = "NVarChar(150)")]
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

        [ColumnAttribute(Storage = "_AccountId", DbType = "NVarChar(50)")]
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

        [ColumnAttribute(Storage = "_AccountName", DbType = "NVarChar(150)")]
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

        [ColumnAttribute(Storage = "_TDebit", DbType = "Money")]
        public decimal? TDebit
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

        [ColumnAttribute(Storage = "_TCredit", DbType = "Money")]
        public decimal? TCredit
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

        [ColumnAttribute(Storage = "_SDebit", DbType = "Money")]
        public decimal? SDebit
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

        [ColumnAttribute(Storage = "_SCredit", DbType = "Money")]
        public decimal? SCredit
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

        [ColumnAttribute(Storage = "_Currency", DbType = "NVarChar(50)")]
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

        [ColumnAttribute(Storage = "_Balance", DbType = "Money")]
        public decimal? Balance
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

        [ColumnAttribute(Storage = "_CompanyId", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_IsBalance", DbType = "Bit")]
        public Nullable<bool> IsBalance
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

        [ColumnAttribute(Storage = "_AccountId", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_Name", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_Debit", DbType = "Decimal(18,2) NOT NULL")]
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

        [ColumnAttribute(Storage = "_Credit", DbType = "Decimal(18,2) NOT NULL")]
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

        [ColumnAttribute(Storage = "_Currency", DbType = "NVarChar(10) NOT NULL", CanBeNull = false)]
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

    public partial class GetAccountBalancesResult
    {

        private string _AccountId;

        private string _Name;

        private decimal? _TDebit;

        private decimal? _TCredit;

        private decimal? _SDebit;

        private decimal? _SCredit;

        private string _Currency;

        public GetAccountBalancesResult()
        {
        }

        [ColumnAttribute(Storage = "_AccountId", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_Name", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_TDebit", DbType = "Decimal(38,2)")]
        public decimal? TDebit
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

        [ColumnAttribute(Storage = "_TCredit", DbType = "Decimal(38,2)")]
        public decimal? TCredit
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

        [ColumnAttribute(Storage = "_SDebit", DbType = "Decimal(38,2)")]
        public decimal? SDebit
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

        [ColumnAttribute(Storage = "_SCredit", DbType = "Decimal(38,2)")]
        public decimal? SCredit
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

        [ColumnAttribute(Storage = "_Currency", DbType = "NVarChar(10) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_id", DbType = "NVarChar(50)")]
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

        [ColumnAttribute(Storage = "_name", DbType = "NVarChar(255)")]
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

    public partial class GetChildrenResult
    {

        private string _id;

        public GetChildrenResult()
        {
        }

        [ColumnAttribute(Storage = "_id", DbType = "NVarChar(50)")]
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

    public partial class GetParentsResult
    {

        private string _id;

        private string _name;

        public GetParentsResult()
        {
        }

        [ColumnAttribute(Storage = "_id", DbType = "NVarChar(50)")]
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

        [ColumnAttribute(Storage = "_name", DbType = "NVarChar(255)")]
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

    public partial class GetFiscalYearsResult
    {

        private string _CompanyId;

        private string _CStart;

        private string _CEnd;

        private string _OStart;

        private string _OEnd;

        public GetFiscalYearsResult()
        {
        }

        [ColumnAttribute(Storage = "_CompanyId", DbType = "NVarChar(50)")]
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

        [ColumnAttribute(Storage = "_CStart", DbType = "NChar(6)")]
        public string CStart
        {
            get
            {
                return this._CStart;
            }
            set
            {
                if ((this._CStart != value))
                {
                    this._CStart = value;
                }
            }
        }

        [ColumnAttribute(Storage = "_CEnd", DbType = "NChar(6)")]
        public string CEnd
        {
            get
            {
                return this._CEnd;
            }
            set
            {
                if ((this._CEnd != value))
                {
                    this._CEnd = value;
                }
            }
        }

        [ColumnAttribute(Storage = "_OStart", DbType = "NChar(6)")]
        public string OStart
        {
            get
            {
                return this._OStart;
            }
            set
            {
                if ((this._OStart != value))
                {
                    this._OStart = value;
                }
            }
        }

        [ColumnAttribute(Storage = "_OEnd", DbType = "NChar(6)")]
        public string OEnd
        {
            get
            {
                return this._OEnd;
            }
            set
            {
                if ((this._OEnd != value))
                {
                    this._OEnd = value;
                }
            }
        }
    }

    public partial class CloseFiscalYearResult
    {

        private int _Id;

        private string _Name;

        private string _AccountId;

        private string _Periode;

        private decimal _Debit;

        private decimal _Credit;

        private decimal _IDebit;

        private decimal _ICredit;

        private decimal _FDebit;

        private decimal _FCredit;

        private string _CompanyID;

        private string _Currency;

        //private decimal _InitialBalance;

        //private decimal _FinalBalance;

        private string _oYear;

        private string _oMonth;

        public CloseFiscalYearResult()
        {
        }

        [ColumnAttribute(Storage = "_Id", DbType = "Int NOT NULL")]
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

        [ColumnAttribute(Storage = "_Name", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_AccountId", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_Periode", DbType = "NChar(6) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_Debit", DbType = "Decimal(18,2) NOT NULL")]
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

        [ColumnAttribute(Storage = "_Credit", DbType = "Decimal(18,2) NOT NULL")]
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

        [ColumnAttribute(Storage = "_IDebit", DbType = "Decimal(18,2) NOT NULL")]
        public decimal IDebit
        {
            get
            {
                return this._IDebit;
            }
            set
            {
                if ((this._IDebit != value))
                {
                    this._IDebit = value;
                }
            }
        }

        [ColumnAttribute(Storage = "_ICredit", DbType = "Decimal(18,2) NOT NULL")]
        public decimal ICredit
        {
            get
            {
                return this._ICredit;
            }
            set
            {
                if ((this._ICredit != value))
                {
                    this._ICredit = value;
                }
            }
        }

        [ColumnAttribute(Storage = "_FDebit", DbType = "Decimal(18,2) NOT NULL")]
        public decimal FDebit
        {
            get
            {
                return this._FDebit;
            }
            set
            {
                if ((this._FDebit != value))
                {
                    this._FDebit = value;
                }
            }
        }

        [ColumnAttribute(Storage = "_FCredit", DbType = "Decimal(18,2) NOT NULL")]
        public decimal FCredit
        {
            get
            {
                return this._FCredit;
            }
            set
            {
                if ((this._FCredit != value))
                {
                    this._FCredit = value;
                }
            }
        }

        [ColumnAttribute(Storage = "_CompanyID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_Currency", DbType = "NVarChar(10) NOT NULL", CanBeNull = false)]
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

        //[ColumnAttribute(Storage = "_InitialBalance", DbType = "Decimal(18,2) NOT NULL")]
        //public decimal InitialBalance
        //{
        //    get
        //    {
        //        return this._InitialBalance;
        //    }
        //    set
        //    {
        //        if ((this._InitialBalance != value))
        //        {
        //            this._InitialBalance = value;
        //        }
        //    }
        //}

        //[ColumnAttribute(Storage = "_FinalBalance", DbType = "Decimal(18,2) NOT NULL")]
        //public decimal FinalBalance
        //{
        //    get
        //    {
        //        return this._FinalBalance;
        //    }
        //    set
        //    {
        //        if ((this._FinalBalance != value))
        //        {
        //            this._FinalBalance = value;
        //        }
        //    }
        //}

        [ColumnAttribute(Storage = "_oYear", DbType = "Char(4)")]
        public string oYear
        {
            get
            {
                return this._oYear;
            }
            set
            {
                if ((this._oYear != value))
                {
                    this._oYear = value;
                }
            }
        }

        [ColumnAttribute(Storage = "_oMonth", DbType = "Char(2)")]
        public string oMonth
        {
            get
            {
                return this._oMonth;
            }
            set
            {
                if ((this._oMonth != value))
                {
                    this._oMonth = value;
                }
            }
        }
    }

    public partial class GetBrouillardResult
    {

        private int _Id;

        private DateTime _Period;

        private string _NumPiece;

        private string _AccountID;

        private Nullable<bool> _Side;

        private string _OAccountID;

        private string _Owner;

        private string _HeaderText;

        private decimal? _Amount;

        private string _Currency;

        private string _TypeDoc;

        private string _CompanyId;

        private Nullable<bool> _IsValidated;

        public GetBrouillardResult()
        {
        }

        [ColumnAttribute(Storage = "_Id", DbType = "Int NOT NULL")]
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

        [ColumnAttribute(Storage = "_Period", DbType = "DateTime NOT NULL")]
        public DateTime Period
        {
            get
            {
                return this._Period;
            }
            set
            {
                if ((this._Period != value))
                {
                    this._Period = value;
                }
            }
        }

        [ColumnAttribute(Storage = "_NumPiece", DbType = "NVarChar(10)")]
        public string NumPiece
        {
            get
            {
                return this._NumPiece;
            }
            set
            {
                if ((this._NumPiece != value))
                {
                    this._NumPiece = value;
                }
            }
        }

        [ColumnAttribute(Storage = "_AccountID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string AccountID
        {
            get
            {
                return this._AccountID;
            }
            set
            {
                if ((this._AccountID != value))
                {
                    this._AccountID = value;
                }
            }
        }

        [ColumnAttribute(Storage = "_Side", DbType = "Bit")]
        public Nullable<bool> Side
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

        [ColumnAttribute(Storage = "_OAccountID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string OAccountID
        {
            get
            {
                return this._OAccountID;
            }
            set
            {
                if ((this._OAccountID != value))
                {
                    this._OAccountID = value;
                }
            }
        }

        [ColumnAttribute(Storage = "_Owner", DbType = "NVarChar(10) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_HeaderText", DbType = "NVarChar(306) NOT NULL", CanBeNull = false)]
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
                    this._HeaderText = value;
                }
            }
        }

        [ColumnAttribute(Storage = "_Amount", DbType = "Money")]
        public decimal? Amount
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

        [ColumnAttribute(Storage = "_Currency", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_TypeDoc", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string TypeDoc
        {
            get
            {
                return this._TypeDoc;
            }
            set
            {
                if ((this._TypeDoc != value))
                {
                    this._TypeDoc = value;
                }
            }
        }

        [ColumnAttribute(Storage = "_CompanyId", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_IsValidated", DbType = "Bit")]
        public Nullable<bool> IsValidated
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

    public partial class PeriodicBalancesResult
    {

        private int _Id;

        private string _AccountId;

        private string _Name;

        private string _Periode;

        private string _OYear;

        private string _OMonth;

        private decimal? _Debit;

        private decimal? _Credit;

        private decimal? _IDebit;

        private decimal? _ICredit;

        private decimal? _InitialBalance;

        private decimal? _FinalBalance;

        //private decimal? _Balance;

        private decimal? _FDebit;

        private decimal? _FCredit;

        private string _Currency;

        //private Nullable<bool> _IsBalance;

        private string _CompanyId;

        public PeriodicBalancesResult()
        {
        }

        [ColumnAttribute(Storage = "_Id", DbType = "Int NOT NULL")]
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

        [ColumnAttribute(Storage = "_AccountId", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_Name", DbType = "NVarChar(150)")]
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

        [ColumnAttribute(Storage = "_Periode", DbType = "NVarChar(16) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_OYear", DbType = "NVarChar(4)")]
        public string OYear
        {
            get
            {
                return this._OYear;
            }
            set
            {
                if ((this._OYear != value))
                {
                    this._OYear = value;
                }
            }
        }

        [ColumnAttribute(Storage = "_OMonth", DbType = "NVarChar(2)")]
        public string OMonth
        {
            get
            {
                return this._OMonth;
            }
            set
            {
                if ((this._OMonth != value))
                {
                    this._OMonth = value;
                }
            }
        }

        [ColumnAttribute(Storage = "_Debit", DbType = "Money")]
        public decimal? Debit
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

        [ColumnAttribute(Storage = "_Credit", DbType = "Money")]
        public decimal? Credit
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


        [ColumnAttribute(Storage = "_IDebit", DbType = "Money")]
        public decimal? IDebit
        {
            get
            {
                return this._IDebit;
            }
            set
            {
                if ((this._IDebit != value))
                {
                    this._IDebit = value;
                }
            }
        }

        [ColumnAttribute(Storage = "_ICredit", DbType = "Money")]
        public decimal? ICredit
        {
            get
            {
                return this._ICredit;
            }
            set
            {
                if ((this._ICredit != value))
                {
                    this._ICredit = value;
                }
            }
        }


        [ColumnAttribute(Storage = "_InitialBalance", DbType = "Money")]
        public decimal? InitialBalance
        {
            get
            {
                return this._InitialBalance;
            }
            set
            {
                if ((this._InitialBalance != value))
                {
                    this._InitialBalance = value;
                }
            }
        }

        [ColumnAttribute(Storage = "_FinalBalance", DbType = "Money")]
        public decimal? FinalBalance
        {
            get
            {
                return this._FinalBalance;
            }
            set
            {
                if ((this._FinalBalance != value))
                {
                    this._FinalBalance = value;
                }
            }
        }

        //[ColumnAttribute(Storage = "_Balance", DbType = "Money")]
        //public decimal? Balance
        //{
        //    get
        //    {
        //        return this._Balance;
        //    }
        //    set
        //    {
        //        if ((this._Balance != value))
        //        {
        //            this._Balance = value;
        //        }
        //    }
        //}

        [ColumnAttribute(Storage = "_FDebit", DbType = "Money")]
        public decimal? FDebit
        {
            get
            {
                return this._FDebit;
            }
            set
            {
                if ((this._FDebit != value))
                {
                    this._FDebit = value;
                }
            }
        }

        [ColumnAttribute(Storage = "_FCredit", DbType = "Money")]
        public decimal? FCredit
        {
            get
            {
                return this._FCredit;
            }
            set
            {
                if ((this._FCredit != value))
                {
                    this._FCredit = value;
                }
            }
        }

        [ColumnAttribute(Storage = "_Currency", DbType = "NVarChar(50)")]
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

        //[ColumnAttribute(Storage = "_IsBalance", DbType = "Bit")]
        //public Nullable<bool> IsBalance
        //{
        //    get
        //    {
        //        return this._IsBalance;
        //    }
        //    set
        //    {
        //        if ((this._IsBalance != value))
        //        {
        //            this._IsBalance = value;
        //        }
        //    }
        //}

        [ColumnAttribute(Storage = "_CompanyId", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
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

    public partial class GetChildResult
    {

        private string _ChildId;

        private string _ChildName;

        private string _ParentId;

        private string _ParentName;

        public GetChildResult()
        {
        }

        [ColumnAttribute(Storage = "_ChildId", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_ChildName", DbType = "NVarChar(255)")]
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

        [ColumnAttribute(Storage = "_ParentId", DbType = "NVarChar(50)")]
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

        [ColumnAttribute(Storage = "_ParentName", DbType = "NVarChar(255)")]
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

    public partial class ClassChildrenResult
    {

        private string _id;

        private string _name;

        public ClassChildrenResult()
        {
        }

        [ColumnAttribute(Storage = "_id", DbType = "NVarChar(50)")]
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

        [ColumnAttribute(Storage = "_name", DbType = "NVarChar(255)")]
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

    public partial class ClassChildResult
    {

        private string _ChildId;

        private string _ChildName;

        private string _ParentId;

        private string _ParentName;

        public ClassChildResult()
        {
        }

        [ColumnAttribute(Storage = "_ChildId", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_ChildName", DbType = "NVarChar(255)")]
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

        [ColumnAttribute(Storage = "_ParentId", DbType = "NVarChar(50)")]
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

        [ColumnAttribute(Storage = "_ParentName", DbType = "NVarChar(255)")]
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

    public partial class AccountBalanceResult
    {

        private int _ID;

        private string _ClassId;

        private string _ClassName;

        private string _SubClassId;

        private string _SubClassName;

        private string _AccountId;

        private string _AccountName;

        private decimal? _TDebit;

        private decimal? _TCredit;

        private decimal? _SDebit;

        private decimal? _SCredit;

        private string _Currency;

        private decimal? _Balance;

        private string _CompanyId;

        private Nullable<bool> _IsBalance;

        private Nullable<bool> _IsResult;

        private Nullable<bool> _IsDebit;

        public AccountBalanceResult()
        {
        }

        [ColumnAttribute(Storage = "_ID", DbType = "Int NOT NULL")]
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

        [ColumnAttribute(Storage = "_ClassId", DbType = "NVarChar(50)")]
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

        [ColumnAttribute(Storage = "_ClassName", DbType = "NVarChar(150)")]
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

        [ColumnAttribute(Storage = "_SubClassId", DbType = "NVarChar(50)")]
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

        [ColumnAttribute(Storage = "_SubClassName", DbType = "NVarChar(150)")]
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

        [ColumnAttribute(Storage = "_AccountId", DbType = "NVarChar(50)")]
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

        [ColumnAttribute(Storage = "_AccountName", DbType = "NVarChar(150)")]
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

        [ColumnAttribute(Storage = "_TDebit", DbType = "Money")]
        public decimal? TDebit
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

        [ColumnAttribute(Storage = "_TCredit", DbType = "Money")]
        public decimal? TCredit
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

        [ColumnAttribute(Storage = "_SDebit", DbType = "Money")]
        public decimal? SDebit
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

        [ColumnAttribute(Storage = "_SCredit", DbType = "Money")]
        public decimal? SCredit
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

        [ColumnAttribute(Storage = "_Currency", DbType = "NVarChar(50)")]
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

        [ColumnAttribute(Storage = "_Balance", DbType = "Money")]
        public decimal? Balance
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

        [ColumnAttribute(Storage = "_CompanyId", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_IsBalance", DbType = "Bit")]
        public Nullable<bool> IsBalance
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

        [ColumnAttribute(Storage = "_IsResult", DbType = "Bit")]
        public Nullable<bool> IsResult
        {
            get
            {
                return this._IsResult;
            }
            set
            {
                if ((this._IsResult != value))
                {
                    this._IsResult = value;
                }
            }
        }

        [ColumnAttribute(Storage = "_IsDebit", DbType = "Bit")]
        public Nullable<bool> IsDebit
        {
            get
            {
                return this._IsDebit;
            }
            set
            {
                if ((this._IsDebit != value))
                {
                    this._IsDebit = value;
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

        private System.DateTime _ItemDate;

        private System.DateTime _EntryDate;

        private string _Periode;

        private string _OYear;

        private string _oMonth;

        private string _Account;

        private string _AccountName;

        private string _OAccount;

        private string _OAccountName;

        private decimal _Amount;

        private decimal _CreditAvantImputationAmount;

        private decimal _DebitAvantImputationAmount;

        private decimal _CreditApresImputationAmount;

        private decimal _DebitApresImputationAmount;

        private string _Side;

        private string _Currency;

        private string _CompanyID;

        private string _Owner;

        private string _TypeJournal;

        private string _Info;

        public GetJournalResult()
        {
        }

        [ColumnAttribute(Storage = "_ID", DbType = "Int NOT NULL")]
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

        [ColumnAttribute(Storage = "_ItemID", DbType = "Int NOT NULL")]
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

        [ColumnAttribute(Storage = "_OID", DbType = "Int NOT NULL")]
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

        [ColumnAttribute(Storage = "_LocalName", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_CustSupplierID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_TransDate", DbType = "DateTime NOT NULL")]
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
                    this._ItemDate = value;
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
                    this._EntryDate = value;
                }
            }
        }
        [ColumnAttribute(Storage = "_Periode", DbType = "NChar(6) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_OYear", DbType = "Char(4)")]
        public string OYear
        {
            get
            {
                return this._OYear;
            }
            set
            {
                if ((this._OYear != value))
                {
                    this._OYear = value;
                }
            }
        }

        [ColumnAttribute(Storage = "_oMonth", DbType = "Char(2)")]
        public string oMonth
        {
            get
            {
                return this._oMonth;
            }
            set
            {
                if ((this._oMonth != value))
                {
                    this._oMonth = value;
                }
            }
        }

        [ColumnAttribute(Storage = "_Account", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_AccountName", DbType = "NVarChar(150)")]
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

        [ColumnAttribute(Storage = "_OAccount", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_OAccountName", DbType = "NVarChar(150)")]
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

        [ColumnAttribute(Storage = "_Amount", DbType = "Money NOT NULL")]
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

        [ColumnAttribute(Storage = "_CreditAvantImputationAmount", DbType = "Money NOT NULL")]
        public decimal CreditAvantImputationAmount
        {
            get
            {
                return this._CreditAvantImputationAmount;
            }
            set
            {
                if ((this._CreditAvantImputationAmount != value))
                {
                    this._CreditAvantImputationAmount = value;
                }
            }
        }

        [ColumnAttribute(Storage = "_DebitAvantImputationAmount", DbType = "Money NOT NULL")]
        public decimal DebitAvantImputationAmount
        {
            get
            {
                return this._DebitAvantImputationAmount;
            }
            set
            {
                if ((this._DebitAvantImputationAmount != value))
                {
                    this._DebitAvantImputationAmount = value;
                }
            }
        }

        [ColumnAttribute(Storage = "_CreditApresImputationAmount", DbType = "Money NOT NULL")]
        public decimal CreditApresImputationAmount
        {
            get
            {
                return this._CreditApresImputationAmount;
            }
            set
            {
                if ((this._CreditApresImputationAmount != value))
                {
                    this._CreditApresImputationAmount = value;
                }
            }
        }

        [ColumnAttribute(Storage = "_DebitApresImputationAmount", DbType = "Money NOT NULL")]
        public decimal DebitApresImputationAmount
        {
            get
            {
                return this._DebitApresImputationAmount;
            }
            set
            {
                if ((this._DebitApresImputationAmount != value))
                {
                    this._DebitApresImputationAmount = value;
                }
            }
        }

        [ColumnAttribute(Storage = "_Side", DbType = "NVarChar(6) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_Currency", DbType = "NVarChar(10) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_CompanyID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_Owner", DbType = "NVarChar(150)")]
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

        [ColumnAttribute(Storage = "_TypeJournal", DbType = "VarChar(50)")]
        public string TypeJournal
        {
            get
            {
                return this._TypeJournal;
            }
            set
            {
                if ((this._TypeJournal != value))
                {
                    this._TypeJournal = value;
                }
            }
        }

        [ColumnAttribute(Storage = "_Info", DbType = "NVarChar(255)")]
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
    }

    #endregion
}
