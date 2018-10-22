using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace IWSProject.Models.Entities
{
    [TableAttribute(Name = "dbo.MasterCompta")]
    public partial class MasterCompta : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _id;

        private int _oid;

        private string _CostCenter;

        private string _account;

        private string _HeaderText;

        private DateTime _TransDate;

        private DateTime _ItemDate;

        private DateTime _EntryDate;

        private string _CompanyId;

        private string _FileName;

        private string _ContentType;

        private Nullable<bool> _IsValidated;

        private Nullable<decimal> _oTotal;

        private string _oCurrency;

        private string _oPeriode;

        private string _oYear;

        private string _oMonth;

        private string _TypeJournal;

        private int _ModelId;

        private EntitySet<DetailCompta> _DetailComptas;

        private EntityRef<Account> _Account1;

        private EntityRef<Company> _Company;

        private EntityRef<CostCenter> _CostCenter1;

        private EntityRef<TypeJournal> _TypeJournal1;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
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
        partial void OnTransDateChanging(DateTime value);
        partial void OnTransDateChanged();
        partial void OnItemDateChanging(DateTime value);
        partial void OnItemDateChanged();
        partial void OnEntryDateChanging(DateTime value);
        partial void OnEntryDateChanged();
        partial void OnCompanyIdChanging(string value);
        partial void OnCompanyIdChanged();
        partial void OnFileNameChanging(string value);
        partial void OnFileNameChanged();
        partial void OnContentTypeChanging(string value);
        partial void OnContentTypeChanged();
        partial void OnIsValidatedChanging(Nullable<bool> value);
        partial void OnIsValidatedChanged();
        partial void OnoTotalChanging(Nullable<decimal> value);
        partial void OnoTotalChanged();
        partial void OnoCurrencyChanging(string value);
        partial void OnoCurrencyChanged();
        partial void OnoPeriodeChanging(string value);
        partial void OnoPeriodeChanged();
        partial void OnoYearChanging(string value);
        partial void OnoYearChanged();
        partial void OnoMonthChanging(string value);
        partial void OnoMonthChanged();
        partial void OnTypeJournalChanging(string value);
        partial void OnTypeJournalChanged();
        partial void OnModelIdChanging(int value);
        partial void OnModelIdChanged();
        #endregion

        public MasterCompta()
        {
            this._DetailComptas = new EntitySet<DetailCompta>(new Action<DetailCompta>(this.attach_DetailComptas), new Action<DetailCompta>(this.detach_DetailComptas));
            this._Account1 = default(EntityRef<Account>);
            this._Company = default(EntityRef<Company>);
            this._CostCenter1 = default(EntityRef<CostCenter>);
            this._TypeJournal1 = default(EntityRef<TypeJournal>);
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

        [ColumnAttribute(Storage = "_CostCenter", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
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
                        throw new ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnCostCenterChanging(value);
                    this.SendPropertyChanging();
                    this._CostCenter = value;
                    this.SendPropertyChanged("CostCenter");
                    this.OnCostCenterChanged();
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
                    if (this._Account1.HasLoadedOrAssignedValue)
                    {
                        throw new ForeignKeyReferenceAlreadyHasValueException();
                    }
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

        [ColumnAttribute(Storage = "_FileName", DbType = "NVarChar(255)")]
        public string FileName
        {
            get
            {
                return this._FileName;
            }
            set
            {
                if ((this._FileName != value))
                {
                    this.OnFileNameChanging(value);
                    this.SendPropertyChanging();
                    this._FileName = value;
                    this.SendPropertyChanged("FileName");
                    this.OnFileNameChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_ContentType", DbType = "NVarChar(50)")]
        public string ContentType
        {
            get
            {
                return this._ContentType;
            }
            set
            {
                if ((this._ContentType != value))
                {
                    this.OnContentTypeChanging(value);
                    this.SendPropertyChanging();
                    this._ContentType = value;
                    this.SendPropertyChanged("ContentType");
                    this.OnContentTypeChanged();
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

        [AssociationAttribute(Name = "MasterCompta_DetailCompta", Storage = "_DetailComptas", ThisKey = "id", OtherKey = "transid")]
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

        [AssociationAttribute(Name = "Account_MasterCompta", Storage = "_Account1", ThisKey = "account", OtherKey = "id", IsForeignKey = true)]
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
                        previousValue.MasterComptas.Remove(this);
                    }
                    this._Account1.Entity = value;
                    if ((value != null))
                    {
                        value.MasterComptas.Add(this);
                        this._account = value.id;
                    }
                    else
                    {
                        this._account = default(string);
                    }
                    this.SendPropertyChanged("Account1");
                }
            }
        }

        [AssociationAttribute(Name = "Company_MasterCompta", Storage = "_Company", ThisKey = "CompanyId", OtherKey = "id", IsForeignKey = true)]
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
                        previousValue.MasterComptas.Remove(this);
                    }
                    this._Company.Entity = value;
                    if ((value != null))
                    {
                        value.MasterComptas.Add(this);
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

        [AssociationAttribute(Name = "CostCenter_MasterCompta", Storage = "_CostCenter1", ThisKey = "CostCenter", OtherKey = "id", IsForeignKey = true)]
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
                        previousValue.MasterComptas.Remove(this);
                    }
                    this._CostCenter1.Entity = value;
                    if ((value != null))
                    {
                        value.MasterComptas.Add(this);
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

        [AssociationAttribute(Name = "TypeJournal_MasterCompta", Storage = "_TypeJournal1", ThisKey = "TypeJournal", OtherKey = "Id", IsForeignKey = true)]
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
                        previousValue.MasterComptas.Remove(this);
                    }
                    this._TypeJournal1.Entity = value;
                    if ((value != null))
                    {
                        value.MasterComptas.Add(this);
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

        private void attach_DetailComptas(DetailCompta entity)
        {
            this.SendPropertyChanging();
            entity.MasterCompta = this;
        }

        private void detach_DetailComptas(DetailCompta entity)
        {
            this.SendPropertyChanging();
            entity.MasterCompta = null;
        }
    }
}