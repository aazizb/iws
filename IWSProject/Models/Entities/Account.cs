using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace IWSProject.Models.Entities
{

    [TableAttribute(Name = "dbo.Account")]
    public partial class Account : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _id;

        private string _name;

        private string _description;

        private DateTime _dateofopen;

        private DateTime _dateofclose;

        private decimal _balance;

        private string _CompanyID;

        private string _ParentId;

        private bool _IsDebit;

        private bool _IsBalanceSheetAccount;

        private DateTime _Posted;

        private DateTime _Updated;

        private string _TypeJournal;

        private int _ModelId;

        private bool _IsResultAccount;

        private EntitySet<AffectationJournal> _AffectationJournals;

        private EntitySet<AffectationJournal> _AffectationJournals1;

        private EntitySet<ClassSetup> _ClassSetups;

        private EntitySet<CostCenter> _CostCenters;

        private EntitySet<DetailCompta> _DetailComptas;

        private EntitySet<DetailCompta> _DetailComptas1;

        private EntitySet<Journal> _Journals;

        private EntitySet<Journal> _Journals1;

        private EntitySet<MasterCompta> _MasterComptas;

        private EntitySet<PeriodicAccountBalance> _PeriodicAccountBalances;

        private EntitySet<Store> _Stores;

        private EntityRef<TypeJournal> _TypeJournal1;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnidChanging(string value);
        partial void OnidChanged();
        partial void OnnameChanging(string value);
        partial void OnnameChanged();
        partial void OndescriptionChanging(string value);
        partial void OndescriptionChanged();
        partial void OndateofopenChanging(DateTime value);
        partial void OndateofopenChanged();
        partial void OndateofcloseChanging(DateTime value);
        partial void OndateofcloseChanged();
        partial void OnbalanceChanging(decimal value);
        partial void OnbalanceChanged();
        partial void OnCompanyIDChanging(string value);
        partial void OnCompanyIDChanged();
        partial void OnParentIdChanging(string value);
        partial void OnParentIdChanged();
        partial void OnIsDebitChanging(bool value);
        partial void OnIsDebitChanged();
        partial void OnIsBalanceSheetAccountChanging(bool value);
        partial void OnIsBalanceSheetAccountChanged();
        partial void OnPostedChanging(DateTime value);
        partial void OnPostedChanged();
        partial void OnUpdatedChanging(DateTime value);
        partial void OnUpdatedChanged();
        partial void OnTypeJournalChanging(string value);
        partial void OnTypeJournalChanged();
        partial void OnModelIdChanging(int value);
        partial void OnModelIdChanged();
        partial void OnIsResultAccountChanging(bool value);
        partial void OnIsResultAccountChanged();
        #endregion

        public Account()
        {
            this._AffectationJournals = new EntitySet<AffectationJournal>(new Action<AffectationJournal>(this.attach_AffectationJournals), new Action<AffectationJournal>(this.detach_AffectationJournals));
            this._AffectationJournals1 = new EntitySet<AffectationJournal>(new Action<AffectationJournal>(this.attach_AffectationJournals1), new Action<AffectationJournal>(this.detach_AffectationJournals1));
            this._ClassSetups = new EntitySet<ClassSetup>(new Action<ClassSetup>(this.attach_ClassSetups), new Action<ClassSetup>(this.detach_ClassSetups));
            this._CostCenters = new EntitySet<CostCenter>(new Action<CostCenter>(this.attach_CostCenters), new Action<CostCenter>(this.detach_CostCenters));
            this._DetailComptas = new EntitySet<DetailCompta>(new Action<DetailCompta>(this.attach_DetailComptas), new Action<DetailCompta>(this.detach_DetailComptas));
            this._DetailComptas1 = new EntitySet<DetailCompta>(new Action<DetailCompta>(this.attach_DetailComptas1), new Action<DetailCompta>(this.detach_DetailComptas1));
            this._Journals = new EntitySet<Journal>(new Action<Journal>(this.attach_Journals), new Action<Journal>(this.detach_Journals));
            this._Journals1 = new EntitySet<Journal>(new Action<Journal>(this.attach_Journals1), new Action<Journal>(this.detach_Journals1));
            this._MasterComptas = new EntitySet<MasterCompta>(new Action<MasterCompta>(this.attach_MasterComptas), new Action<MasterCompta>(this.detach_MasterComptas));
            this._PeriodicAccountBalances = new EntitySet<PeriodicAccountBalance>(new Action<PeriodicAccountBalance>(this.attach_PeriodicAccountBalances), new Action<PeriodicAccountBalance>(this.detach_PeriodicAccountBalances));
            this._Stores = new EntitySet<Store>(new Action<Store>(this.attach_Stores), new Action<Store>(this.detach_Stores));
            this._TypeJournal1 = default(EntityRef<TypeJournal>);
            OnCreated();
        }

        [ColumnAttribute(Storage = "_id", DbType = "NVarChar(50) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
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

        [ColumnAttribute(Storage = "_name", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_description", DbType = "NVarChar(255)")]
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

        [ColumnAttribute(Storage = "_dateofopen", DbType = "DateTime2 NOT NULL")]
        public DateTime dateofopen
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

        [ColumnAttribute(Storage = "_dateofclose", DbType = "DateTime2 NOT NULL")]
        public DateTime dateofclose
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

        [ColumnAttribute(Storage = "_balance", DbType = "Money NOT NULL")]
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
                    this.OnCompanyIDChanging(value);
                    this.SendPropertyChanging();
                    this._CompanyID = value;
                    this.SendPropertyChanged("CompanyID");
                    this.OnCompanyIDChanged();
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
                    this.OnParentIdChanging(value);
                    this.SendPropertyChanging();
                    this._ParentId = value;
                    this.SendPropertyChanged("ParentId");
                    this.OnParentIdChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_IsDebit", DbType = "Bit NOT NULL")]
        public bool IsDebit
        {
            get
            {
                return this._IsDebit;
            }
            set
            {
                if ((this._IsDebit != value))
                {
                    this.OnIsDebitChanging(value);
                    this.SendPropertyChanging();
                    this._IsDebit = value;
                    this.SendPropertyChanged("IsDebit");
                    this.OnIsDebitChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_IsBalanceSheetAccount", DbType = "Bit NOT NULL")]
        public bool IsBalanceSheetAccount
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

        [ColumnAttribute(Storage = "_Posted", DbType = "DateTime2 NOT NULL")]
        public DateTime Posted
        {
            get
            {
                return this._Posted;
            }
            set
            {
                if ((this._Posted != value))
                {
                    this.OnPostedChanging(value);
                    this.SendPropertyChanging();
                    this._Posted = value;
                    this.SendPropertyChanged("Posted");
                    this.OnPostedChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Updated", DbType = "DateTime2 NOT NULL")]
        public DateTime Updated
        {
            get
            {
                return this._Updated;
            }
            set
            {
                if ((this._Updated != value))
                {
                    this.OnUpdatedChanging(value);
                    this.SendPropertyChanging();
                    this._Updated = value;
                    this.SendPropertyChanged("Updated");
                    this.OnUpdatedChanged();
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
                    if (this._TypeJournal1.HasLoadedOrAssignedValue)
                    {
                        throw new ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnTypeJournalChanging(value);
                    this.SendPropertyChanging();
                    this._TypeJournal = value;
                    this.SendPropertyChanged("TypeJournal");
                    this.OnTypeJournalChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_ModelId", DbType = "Int NOT NULL")]
        public int ModelId
        {
            get
            {
                return this._ModelId;
            }
            set
            {
                if ((this._ModelId != value))
                {
                    this.OnModelIdChanging(value);
                    this.SendPropertyChanging();
                    this._ModelId = value;
                    this.SendPropertyChanged("ModelId");
                    this.OnModelIdChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_IsResultAccount", DbType = "Bit NOT NULL")]
        public bool IsResultAccount
        {
            get
            {
                return this._IsResultAccount;
            }
            set
            {
                if ((this._IsResultAccount != value))
                {
                    this.OnIsResultAccountChanging(value);
                    this.SendPropertyChanging();
                    this._IsResultAccount = value;
                    this.SendPropertyChanged("IsResultAccount");
                    this.OnIsResultAccountChanged();
                }
            }
        }

        [AssociationAttribute(Name = "Account_AffectationJournal", Storage = "_AffectationJournals", ThisKey = "id", OtherKey = "AccountID")]
        public EntitySet<AffectationJournal> AffectationJournals
        {
            get
            {
                return this._AffectationJournals;
            }
            set
            {
                this._AffectationJournals.Assign(value);
            }
        }

        [AssociationAttribute(Name = "Account_AffectationJournal1", Storage = "_AffectationJournals1", ThisKey = "id", OtherKey = "OAccountID")]
        public EntitySet<AffectationJournal> AffectationJournals1
        {
            get
            {
                return this._AffectationJournals1;
            }
            set
            {
                this._AffectationJournals1.Assign(value);
            }
        }

        [AssociationAttribute(Name = "Account_ClassSetup", Storage = "_ClassSetups", ThisKey = "id", OtherKey = "ClassID")]
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

        [AssociationAttribute(Name = "Account_CostCenter", Storage = "_CostCenters", ThisKey = "id", OtherKey = "accountid")]
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

        [AssociationAttribute(Name = "Account_DetailCompta", Storage = "_DetailComptas", ThisKey = "id", OtherKey = "account")]
        public EntitySet<DetailCompta> DetailComptas
        {
            get
            {
                return this._DetailComptas;
            }
            set
            {
                this._DetailComptas.Assign(value);
            }
        }

        [AssociationAttribute(Name = "Account_DetailCompta1", Storage = "_DetailComptas1", ThisKey = "id", OtherKey = "oaccount")]
        public EntitySet<DetailCompta> DetailComptas1
        {
            get
            {
                return this._DetailComptas1;
            }
            set
            {
                this._DetailComptas1.Assign(value);
            }
        }

        [AssociationAttribute(Name = "Account_Journal", Storage = "_Journals", ThisKey = "id", OtherKey = "Account")]
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

        [AssociationAttribute(Name = "Account_Journal1", Storage = "_Journals1", ThisKey = "id", OtherKey = "OAccount")]
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

        [AssociationAttribute(Name = "Account_MasterCompta", Storage = "_MasterComptas", ThisKey = "id", OtherKey = "account")]
        public EntitySet<MasterCompta> MasterComptas
        {
            get
            {
                return this._MasterComptas;
            }
            set
            {
                this._MasterComptas.Assign(value);
            }
        }

        [AssociationAttribute(Name = "Account_PeriodicAccountBalance", Storage = "_PeriodicAccountBalances", ThisKey = "id", OtherKey = "AccountId")]
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

        [AssociationAttribute(Name = "Account_Store", Storage = "_Stores", ThisKey = "id", OtherKey = "accountid")]
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

        [AssociationAttribute(Name = "TypeJournal_Account", Storage = "_TypeJournal1", ThisKey = "TypeJournal", OtherKey = "Id", IsForeignKey = true)]
        public TypeJournal TypeJournal1
        {
            get
            {
                return this._TypeJournal1.Entity;
            }
            set
            {
                TypeJournal previousValue = this._TypeJournal1.Entity;
                if (((previousValue != value)
                            || (this._TypeJournal1.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._TypeJournal1.Entity = null;
                        previousValue.Accounts.Remove(this);
                    }
                    this._TypeJournal1.Entity = value;
                    if ((value != null))
                    {
                        value.Accounts.Add(this);
                        this._TypeJournal = value.Id;
                    }
                    else
                    {
                        this._TypeJournal = default(string);
                    }
                    this.SendPropertyChanged("TypeJournal1");
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

        private void attach_AffectationJournals(AffectationJournal entity)
        {
            this.SendPropertyChanging();
            entity.Account = this;
        }

        private void detach_AffectationJournals(AffectationJournal entity)
        {
            this.SendPropertyChanging();
            entity.Account = null;
        }

        private void attach_AffectationJournals1(AffectationJournal entity)
        {
            this.SendPropertyChanging();
            entity.Account1 = this;
        }

        private void detach_AffectationJournals1(AffectationJournal entity)
        {
            this.SendPropertyChanging();
            entity.Account1 = null;
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

        private void attach_DetailComptas(DetailCompta entity)
        {
            this.SendPropertyChanging();
            entity.Account1 = this;
        }

        private void detach_DetailComptas(DetailCompta entity)
        {
            this.SendPropertyChanging();
            entity.Account1 = null;
        }

        private void attach_DetailComptas1(DetailCompta entity)
        {
            this.SendPropertyChanging();
            entity.Account2 = this;
        }

        private void detach_DetailComptas1(DetailCompta entity)
        {
            this.SendPropertyChanging();
            entity.Account2 = null;
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

        private void attach_MasterComptas(MasterCompta entity)
        {
            this.SendPropertyChanging();
            entity.Account1 = this;
        }

        private void detach_MasterComptas(MasterCompta entity)
        {
            this.SendPropertyChanging();
            entity.Account1 = null;
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

}