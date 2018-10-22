using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace IWSProject.Models.Entities
{
    [TableAttribute(Name = "dbo.BankAccount")]
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

        private int _ModelId;

        private EntityRef<Bank> _Bank;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
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
        partial void OnModelIdChanging(int value);
        partial void OnModelIdChanged();
        #endregion

        public BankAccount()
        {
            this._Bank = default(EntityRef<Bank>);
            OnCreated();
        }

        [ColumnAttribute(Storage = "_IBAN", DbType = "NVarChar(50) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
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

        [ColumnAttribute(Storage = "_Owner", DbType = "NVarChar(255) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
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

        [ColumnAttribute(Storage = "_BIC", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
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
                        throw new ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnBICChanging(value);
                    this.SendPropertyChanging();
                    this._BIC = value;
                    this.SendPropertyChanged("BIC");
                    this.OnBICChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Account", DbType = "NVarChar(50)")]
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

        [ColumnAttribute(Storage = "_Debit", DbType = "Money NOT NULL")]
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

        [ColumnAttribute(Storage = "_Credit", DbType = "Money NOT NULL")]
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

        [ColumnAttribute(Storage = "_Currency", DbType = "NVarChar(10)")]
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

        [AssociationAttribute(Name = "Bank_BankAccount", Storage = "_Bank", ThisKey = "BIC", OtherKey = "id", IsForeignKey = true)]
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
}