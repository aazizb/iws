using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace IWSProject.Models.Entities
{

    [TableAttribute(Name = "dbo.Journal")]
    public partial class Journal : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private int _ItemID;

        private int _OID;

        private string _ItemType;

        private string _CustSupplierID;

        private string _StoreID;

        private DateTime _TransDate;

        private DateTime _ItemDate;

        private DateTime _EntryDate;

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

        private string _oYear;

        private string _oMonth;

        private string _StoreName;

        private string _AccountName;

        private string _OAccountName;

        private string _CustSupplierName;

        private string _CompanyName;

        private string _TypeJournal;

        private string _CostCenterId;

        private string _CostCenterName;

        private string _TypeJournalName;

        private Nullable<int> _ModelId;

        private EntityRef<Account> _Account1;

        private EntityRef<Account> _Account2;

        private decimal _DebitAvantImputationAmount;

        private decimal _CreditAvantImputationAmount;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
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
        partial void OnTransDateChanging(DateTime value);
        partial void OnTransDateChanged();
        partial void OnItemDateChanging(DateTime value);
        partial void OnItemDateChanged();
        partial void OnEntryDateChanging(DateTime value);
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
        partial void OnoYearChanging(string value);
        partial void OnoYearChanged();
        partial void OnoMonthChanging(string value);
        partial void OnoMonthChanged();
        partial void OnStoreNameChanging(string value);
        partial void OnStoreNameChanged();
        partial void OnAccountNameChanging(string value);
        partial void OnAccountNameChanged();
        partial void OnOAccountNameChanging(string value);
        partial void OnOAccountNameChanged();
        partial void OnCustSupplierNameChanging(string value);
        partial void OnCustSupplierNameChanged();
        partial void OnCompanyNameChanging(string value);
        partial void OnCompanyNameChanged();
        partial void OnTypeJournalChanging(string value);
        partial void OnTypeJournalChanged();
        partial void OnCostCenterIdChanging(string value);
        partial void OnCostCenterIdChanged();
        partial void OnCostCenterNameChanging(string value);
        partial void OnCostCenterNameChanged();
        partial void OnTypeJournalNameChanging(string value);
        partial void OnTypeJournalNameChanged();
        partial void OnModelIdChanging(Nullable<int> value);
        partial void OnModelIdChanged();
        partial void OnDebitAvantImputationAmountChanging(decimal value);
        partial void OnDebitAvantImputationAmountChanged();
        partial void OnCreditAvantImputationAmountChanging(decimal value);
        partial void OnCreditAvantImputationAmountChanged();
        #endregion

        public Journal()
        {
            this._Account1 = default(EntityRef<Account>);
            this._Account2 = default(EntityRef<Account>);
            OnCreated();
        }

        [ColumnAttribute(Storage = "_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
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
                    this.OnItemIDChanging(value);
                    this.SendPropertyChanging();
                    this._ItemID = value;
                    this.SendPropertyChanged("ItemID");
                    this.OnItemIDChanged();
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
                    this.OnOIDChanging(value);
                    this.SendPropertyChanging();
                    this._OID = value;
                    this.SendPropertyChanged("OID");
                    this.OnOIDChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_ItemType", DbType = "NVarChar(50)")]
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
                    this.OnCustSupplierIDChanging(value);
                    this.SendPropertyChanging();
                    this._CustSupplierID = value;
                    this.SendPropertyChanged("CustSupplierID");
                    this.OnCustSupplierIDChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_StoreID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_TransDate", DbType = "DateTime NOT NULL")]
        public DateTime TransDate
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

        [ColumnAttribute(Storage = "_ItemDate", DbType = "DateTime NOT NULL")]
        public DateTime ItemDate
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

        [ColumnAttribute(Storage = "_EntryDate", DbType = "DateTime NOT NULL")]
        public DateTime EntryDate
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
                    this.OnPeriodeChanging(value);
                    this.SendPropertyChanging();
                    this._Periode = value;
                    this.SendPropertyChanged("Periode");
                    this.OnPeriodeChanged();
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
                    if (this._Account1.HasLoadedOrAssignedValue)
                    {
                        throw new ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnAccountChanging(value);
                    this.SendPropertyChanging();
                    this._Account = value;
                    this.SendPropertyChanged("Account");
                    this.OnAccountChanged();
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
                    if (this._Account2.HasLoadedOrAssignedValue)
                    {
                        throw new ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnOAccountChanging(value);
                    this.SendPropertyChanging();
                    this._OAccount = value;
                    this.SendPropertyChanged("OAccount");
                    this.OnOAccountChanged();
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
                    this.OnAmountChanging(value);
                    this.SendPropertyChanging();
                    this._Amount = value;
                    this.SendPropertyChanged("Amount");
                    this.OnAmountChanged();
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
                    this.OnSideChanging(value);
                    this.SendPropertyChanging();
                    this._Side = value;
                    this.SendPropertyChanged("Side");
                    this.OnSideChanged();
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

        [ColumnAttribute(Storage = "_CompanyIBAN", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_IBAN", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_Info", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_StoreName", DbType = "NVarChar(150)")]
        public string StoreName
        {
            get
            {
                return this._StoreName;
            }
            set
            {
                if ((this._StoreName != value))
                {
                    this.OnStoreNameChanging(value);
                    this.SendPropertyChanging();
                    this._StoreName = value;
                    this.SendPropertyChanged("StoreName");
                    this.OnStoreNameChanged();
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
                    this.OnAccountNameChanging(value);
                    this.SendPropertyChanging();
                    this._AccountName = value;
                    this.SendPropertyChanged("AccountName");
                    this.OnAccountNameChanged();
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
                    this.OnOAccountNameChanging(value);
                    this.SendPropertyChanging();
                    this._OAccountName = value;
                    this.SendPropertyChanged("OAccountName");
                    this.OnOAccountNameChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_CustSupplierName", DbType = "NVarChar(150)")]
        public string CustSupplierName
        {
            get
            {
                return this._CustSupplierName;
            }
            set
            {
                if ((this._CustSupplierName != value))
                {
                    this.OnCustSupplierNameChanging(value);
                    this.SendPropertyChanging();
                    this._CustSupplierName = value;
                    this.SendPropertyChanged("CustSupplierName");
                    this.OnCustSupplierNameChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_CompanyName", DbType = "NVarChar(150)")]
        public string CompanyName
        {
            get
            {
                return this._CompanyName;
            }
            set
            {
                if ((this._CompanyName != value))
                {
                    this.OnCompanyNameChanging(value);
                    this.SendPropertyChanging();
                    this._CompanyName = value;
                    this.SendPropertyChanged("CompanyName");
                    this.OnCompanyNameChanged();
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
                    this.OnTypeJournalChanging(value);
                    this.SendPropertyChanging();
                    this._TypeJournal = value;
                    this.SendPropertyChanged("TypeJournal");
                    this.OnTypeJournalChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_CostCenterId", DbType = "NVarChar(50)")]
        public string CostCenterId
        {
            get
            {
                return this._CostCenterId;
            }
            set
            {
                if ((this._CostCenterId != value))
                {
                    this.OnCostCenterIdChanging(value);
                    this.SendPropertyChanging();
                    this._CostCenterId = value;
                    this.SendPropertyChanged("CostCenterId");
                    this.OnCostCenterIdChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_CostCenterName", DbType = "NVarChar(150)")]
        public string CostCenterName
        {
            get
            {
                return this._CostCenterName;
            }
            set
            {
                if ((this._CostCenterName != value))
                {
                    this.OnCostCenterNameChanging(value);
                    this.SendPropertyChanging();
                    this._CostCenterName = value;
                    this.SendPropertyChanged("CostCenterName");
                    this.OnCostCenterNameChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_TypeJournalName", DbType = "NVarChar(150)")]
        public string TypeJournalName
        {
            get
            {
                return this._TypeJournalName;
            }
            set
            {
                if ((this._TypeJournalName != value))
                {
                    this.OnTypeJournalNameChanging(value);
                    this.SendPropertyChanging();
                    this._TypeJournalName = value;
                    this.SendPropertyChanged("TypeJournalName");
                    this.OnTypeJournalNameChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_ModelId", DbType = "Int")]
        public Nullable<int> ModelId
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

        [AssociationAttribute(Name = "Account_Journal", Storage = "_Account1", ThisKey = "Account", OtherKey = "id", IsForeignKey = true)]
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

        [AssociationAttribute(Name = "Account_Journal1", Storage = "_Account2", ThisKey = "OAccount", OtherKey = "id", IsForeignKey = true)]
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
                    this.OnDebitAvantImputationAmountChanging(value);
                    this.SendPropertyChanging();
                    this._DebitAvantImputationAmount = value;
                    this.SendPropertyChanged("DebitAvantImputationAmount");
                    this.OnDebitAvantImputationAmountChanged();
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
                    this.OnCreditAvantImputationAmountChanging(value);
                    this.SendPropertyChanging();
                    this._CreditAvantImputationAmount = value;
                    this.SendPropertyChanged("CreditAvantImputationAmount");
                    this.OnCreditAvantImputationAmountChanged();
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