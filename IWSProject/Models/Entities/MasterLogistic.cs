using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace IWSProject.Models.Entities
{
    [TableAttribute(Name = "dbo.MasterLogistic")]
    public partial class MasterLogistic : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _id;

        private int _oid;

        private string _store;

        private string _account;

        private string _HeaderText;

        private DateTime _TransDate;

        private DateTime _ItemDate;

        private DateTime _EntryDate;

        private string _CompanyId;

        private Nullable<bool> _IsValidated;

        private Nullable<decimal> _oTotal;

        private Nullable<decimal> _oVat;

        private string _oCurrency;

        private string _oPeriode;

        private Nullable<decimal> _oNet;

        private string _oYear;

        private string _oMonth;

        private int _ModelId;

        private string _Terms;

        private EntitySet<DetailLogistic> _DetailLogistics;

        private EntityRef<Company> _Company;

        private EntityRef<Store> _Store1;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
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
        partial void OnTransDateChanging(DateTime value);
        partial void OnTransDateChanged();
        partial void OnItemDateChanging(DateTime value);
        partial void OnItemDateChanged();
        partial void OnEntryDateChanging(DateTime value);
        partial void OnEntryDateChanged();
        partial void OnCompanyIdChanging(string value);
        partial void OnCompanyIdChanged();
        partial void OnIsValidatedChanging(Nullable<bool> value);
        partial void OnIsValidatedChanged();
        partial void OnoTotalChanging(Nullable<decimal> value);
        partial void OnoTotalChanged();
        partial void OnoVatChanging(Nullable<decimal> value);
        partial void OnoVatChanged();
        partial void OnoCurrencyChanging(string value);
        partial void OnoCurrencyChanged();
        partial void OnoPeriodeChanging(string value);
        partial void OnoPeriodeChanged();
        partial void OnoNetChanging(Nullable<decimal> value);
        partial void OnoNetChanged();
        partial void OnoYearChanging(string value);
        partial void OnoYearChanged();
        partial void OnoMonthChanging(string value);
        partial void OnoMonthChanged();
        partial void OnModelIdChanging(int value);
        partial void OnModelIdChanged();
        partial void OnTermsChanging(string value);
        partial void OnTermsChanged();
        #endregion

        public MasterLogistic()
        {
            this._DetailLogistics = new EntitySet<DetailLogistic>(new Action<DetailLogistic>(this.attach_DetailLogistics), new Action<DetailLogistic>(this.detach_DetailLogistics));
            this._Company = default(EntityRef<Company>);
            this._Store1 = default(EntityRef<Store>);
            OnCreated();
        }

        [ColumnAttribute(Storage = "_id", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
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

        [ColumnAttribute(Storage = "_oid", DbType = "Int NOT NULL")]
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

        [ColumnAttribute(Storage = "_store", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
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
                        throw new ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnstoreChanging(value);
                    this.SendPropertyChanging();
                    this._store = value;
                    this.SendPropertyChanged("store");
                    this.OnstoreChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_account", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_HeaderText", DbType = "NVarChar(250)")]
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

        [ColumnAttribute(Storage = "_TransDate", DbType = "Date NOT NULL")]
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

        [ColumnAttribute(Storage = "_ItemDate", DbType = "Date NOT NULL")]
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

        [ColumnAttribute(Storage = "_EntryDate", DbType = "Date NOT NULL")]
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
                    if (this._Company.HasLoadedOrAssignedValue)
                    {
                        throw new ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnCompanyIdChanging(value);
                    this.SendPropertyChanging();
                    this._CompanyId = value;
                    this.SendPropertyChanged("CompanyId");
                    this.OnCompanyIdChanged();
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
                    this.OnIsValidatedChanging(value);
                    this.SendPropertyChanging();
                    this._IsValidated = value;
                    this.SendPropertyChanged("IsValidated");
                    this.OnIsValidatedChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_oTotal", AutoSync = AutoSync.Always, DbType = "Money", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public Nullable<decimal> oTotal
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

        [ColumnAttribute(Storage = "_oVat", AutoSync = AutoSync.Always, DbType = "Money", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public Nullable<decimal> oVat
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

        [ColumnAttribute(Storage = "_oCurrency", AutoSync = AutoSync.Always, DbType = "NVarChar(10)", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
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

        [ColumnAttribute(Storage = "_oPeriode", AutoSync = AutoSync.Always, DbType = "NVarChar(6)", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
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

        [ColumnAttribute(Storage = "_oNet", AutoSync = AutoSync.Always, DbType = "Money", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public Nullable<decimal> oNet
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

        [ColumnAttribute(Storage = "_Terms", DbType = "NVarChar(250)")]
        public string Terms
        {
            get
            {
                return this._Terms;
            }
            set
            {
                if ((this._Terms != value))
                {
                    this.OnTermsChanging(value);
                    this.SendPropertyChanging();
                    this._Terms = value;
                    this.SendPropertyChanged("Terms");
                    this.OnTermsChanged();
                }
            }
        }

        [AssociationAttribute(Name = "MasterLogistic_DetailLogistic", Storage = "_DetailLogistics", ThisKey = "id", OtherKey = "transid")]
        public EntitySet<DetailLogistic> DetailLogistics
        {
            get
            {
                return this._DetailLogistics;
            }
            set
            {
                this._DetailLogistics.Assign(value);
            }
        }

        [AssociationAttribute(Name = "Company_MasterLogistic", Storage = "_Company", ThisKey = "CompanyId", OtherKey = "id", IsForeignKey = true)]
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
                        previousValue.MasterLogistics.Remove(this);
                    }
                    this._Company.Entity = value;
                    if ((value != null))
                    {
                        value.MasterLogistics.Add(this);
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

        [AssociationAttribute(Name = "Store_MasterLogistic", Storage = "_Store1", ThisKey = "store", OtherKey = "id", IsForeignKey = true)]
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
                        previousValue.MasterLogistics.Remove(this);
                    }
                    this._Store1.Entity = value;
                    if ((value != null))
                    {
                        value.MasterLogistics.Add(this);
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

        private void attach_DetailLogistics(DetailLogistic entity)
        {
            this.SendPropertyChanging();
            entity.MasterLogistic = this;
        }

        private void detach_DetailLogistics(DetailLogistic entity)
        {
            this.SendPropertyChanging();
            entity.MasterLogistic = null;
        }
    }
}