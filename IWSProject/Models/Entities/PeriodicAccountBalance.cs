using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace IWSProject.Models.Entities
{

    [TableAttribute(Name = "dbo.PeriodicAccountBalance")]
    public partial class PeriodicAccountBalance : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

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

        //private decimal _FinalBalance;

        //private decimal _InitialBalance;

        private string _oYear;

        private string _oMonth;

        private int _ModelId;

        private EntityRef<Account> _Account;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnIdChanging(int value);
        partial void OnIdChanged();
        partial void OnNameChanging(string value);
        partial void OnNameChanged();
        partial void OnAccountIdChanging(string value);
        partial void OnAccountIdChanged();
        partial void OnPeriodeChanging(string value);
        partial void OnPeriodeChanged();
        partial void OnDebitChanging(decimal value);
        partial void OnDebitChanged();
        partial void OnCreditChanging(decimal value);
        partial void OnCreditChanged();
        partial void OnIDebitChanging(decimal value);
        partial void OnIDebitChanged();
        partial void OnICreditChanging(decimal value);
        partial void OnICreditChanged();
        partial void OnFDebitChanging(decimal value);
        partial void OnFDebitChanged();
        partial void OnFCreditChanging(decimal value);
        partial void OnFCreditChanged();
        partial void OnCompanyIDChanging(string value);
        partial void OnCompanyIDChanged();
        partial void OnCurrencyChanging(string value);
        partial void OnCurrencyChanged();
        partial void OnFinalBalanceChanging(decimal value);
        partial void OnFinalBalanceChanged();
        partial void OnInitialBalanceChanging(decimal value);
        partial void OnInitialBalanceChanged();
        partial void OnoYearChanging(string value);
        partial void OnoYearChanged();
        partial void OnoMonthChanging(string value);
        partial void OnoMonthChanged();
        partial void OnModelIdChanging(int value);
        partial void OnModelIdChanged();
        #endregion

        public PeriodicAccountBalance()
        {
            this._Account = default(EntityRef<Account>);
            OnCreated();
        }

        [ColumnAttribute(Storage = "_Id", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
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
                    this.OnNameChanging(value);
                    this.SendPropertyChanging();
                    this._Name = value;
                    this.SendPropertyChanged("Name");
                    this.OnNameChanged();
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
                    if (this._Account.HasLoadedOrAssignedValue)
                    {
                        throw new ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnAccountIdChanging(value);
                    this.SendPropertyChanging();
                    this._AccountId = value;
                    this.SendPropertyChanged("AccountId");
                    this.OnAccountIdChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Periode", DbType = "NVarChar(6) NOT NULL", CanBeNull = false)]
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
                    this.OnDebitChanging(value);
                    this.SendPropertyChanging();
                    this._Debit = value;
                    this.SendPropertyChanged("Debit");
                    this.OnDebitChanged();
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
                    this.OnCreditChanging(value);
                    this.SendPropertyChanging();
                    this._Credit = value;
                    this.SendPropertyChanged("Credit");
                    this.OnCreditChanged();
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
                    this.OnIDebitChanging(value);
                    this.SendPropertyChanging();
                    this._IDebit = value;
                    this.SendPropertyChanged("IDebit");
                    this.OnIDebitChanged();
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
                    this.OnICreditChanging(value);
                    this.SendPropertyChanging();
                    this._ICredit = value;
                    this.SendPropertyChanged("ICredit");
                    this.OnICreditChanged();
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
                    this.OnFDebitChanging(value);
                    this.SendPropertyChanging();
                    this._FDebit = value;
                    this.SendPropertyChanged("FDebit");
                    this.OnFDebitChanged();
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
                    this.OnFCreditChanging(value);
                    this.SendPropertyChanging();
                    this._FCredit = value;
                    this.SendPropertyChanged("FCredit");
                    this.OnFCreditChanged();
                }
            }
        }


        [ColumnAttribute(Storage = "_CompanyID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
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
                    this.OnCurrencyChanging(value);
                    this.SendPropertyChanging();
                    this._Currency = value;
                    this.SendPropertyChanged("Currency");
                    this.OnCurrencyChanged();
                }
            }
        }

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
        //            this.OnFinalBalanceChanging(value);
        //            this.SendPropertyChanging();
        //            this._FinalBalance = value;
        //            this.SendPropertyChanged("FinalBalance");
        //            this.OnFinalBalanceChanged();
        //        }
        //    }
        //}

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
        //            this.OnInitialBalanceChanging(value);
        //            this.SendPropertyChanging();
        //            this._InitialBalance = value;
        //            this.SendPropertyChanged("InitialBalance");
        //            this.OnInitialBalanceChanged();
        //        }
        //    }
        //}

        [ColumnAttribute(Storage = "_oYear", AutoSync = AutoSync.Always, DbType = "Char(4)", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
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
                    this.OnoYearChanging(value);
                    this.SendPropertyChanging();
                    this._oYear = value;
                    this.SendPropertyChanged("oYear");
                    this.OnoYearChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_oMonth", AutoSync = AutoSync.Always, DbType = "Char(2)", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
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
                    this.OnoMonthChanging(value);
                    this.SendPropertyChanging();
                    this._oMonth = value;
                    this.SendPropertyChanged("oMonth");
                    this.OnoMonthChanged();
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

        [AssociationAttribute(Name = "Account_PeriodicAccountBalance", Storage = "_Account", ThisKey = "AccountId", OtherKey = "id", IsForeignKey = true)]
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


}