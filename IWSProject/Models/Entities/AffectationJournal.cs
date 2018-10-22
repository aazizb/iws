using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace IWSProject.Models.Entities
{

    [TableAttribute(Name = "dbo.AffectationJournal")]
    public partial class AffectationJournal : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _AccountID;

        private bool _Side;

        private string _OAccountID;

        private string _TypeJournalID;

        private string _Description;

        private string _CompanyID;

        private Nullable<int> _ModelId;

        private int _Id;

        private EntityRef<Account> _Account;

        private EntityRef<Account> _Account1;

        private EntityRef<Company> _Company;

        private EntityRef<TypeJournal> _TypeJournal;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnAccountIDChanging(string value);
        partial void OnAccountIDChanged();
        partial void OnSideChanging(bool value);
        partial void OnSideChanged();
        partial void OnOAccountIDChanging(string value);
        partial void OnOAccountIDChanged();
        partial void OnTypeJournalIDChanging(string value);
        partial void OnTypeJournalIDChanged();
        partial void OnDescriptionChanging(string value);
        partial void OnDescriptionChanged();
        partial void OnCompanyIDChanging(string value);
        partial void OnCompanyIDChanged();
        partial void OnModelIdChanging(Nullable<int> value);
        partial void OnModelIdChanged();
        partial void OnIdChanging(int value);
        partial void OnIdChanged();
        #endregion

        public AffectationJournal()
        {
            this._Account = default(EntityRef<Account>);
            this._Account1 = default(EntityRef<Account>);
            this._Company = default(EntityRef<Company>);
            this._TypeJournal = default(EntityRef<TypeJournal>);
            OnCreated();
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
                    if (this._Account.HasLoadedOrAssignedValue)
                    {
                        throw new ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnAccountIDChanging(value);
                    this.SendPropertyChanging();
                    this._AccountID = value;
                    this.SendPropertyChanged("AccountID");
                    this.OnAccountIDChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Side", DbType = "Bit NOT NULL")]
        public bool Side
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
                    if (this._Account1.HasLoadedOrAssignedValue)
                    {
                        throw new ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnOAccountIDChanging(value);
                    this.SendPropertyChanging();
                    this._OAccountID = value;
                    this.SendPropertyChanged("OAccountID");
                    this.OnOAccountIDChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_TypeJournalID", DbType = "VarChar(50) NOT NULL", CanBeNull = false)]
        public string TypeJournalID
        {
            get
            {
                return this._TypeJournalID;
            }
            set
            {
                if ((this._TypeJournalID != value))
                {
                    if (this._TypeJournal.HasLoadedOrAssignedValue)
                    {
                        throw new ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnTypeJournalIDChanging(value);
                    this.SendPropertyChanging();
                    this._TypeJournalID = value;
                    this.SendPropertyChanged("TypeJournalID");
                    this.OnTypeJournalIDChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Description", DbType = "NVarChar(255)")]
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
                    if (this._Company.HasLoadedOrAssignedValue)
                    {
                        throw new ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnCompanyIDChanging(value);
                    this.SendPropertyChanging();
                    this._CompanyID = value;
                    this.SendPropertyChanged("CompanyID");
                    this.OnCompanyIDChanged();
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

        [AssociationAttribute(Name = "Account_AffectationJournal", Storage = "_Account", ThisKey = "AccountID", OtherKey = "id", IsForeignKey = true)]
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
                        previousValue.AffectationJournals.Remove(this);
                    }
                    this._Account.Entity = value;
                    if ((value != null))
                    {
                        value.AffectationJournals.Add(this);
                        this._AccountID = value.id;
                    }
                    else
                    {
                        this._AccountID = default(string);
                    }
                    this.SendPropertyChanged("Account");
                }
            }
        }

        [AssociationAttribute(Name = "Account_AffectationJournal1", Storage = "_Account1", ThisKey = "OAccountID", OtherKey = "id", IsForeignKey = true)]
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
                        previousValue.AffectationJournals1.Remove(this);
                    }
                    this._Account1.Entity = value;
                    if ((value != null))
                    {
                        value.AffectationJournals1.Add(this);
                        this._OAccountID = value.id;
                    }
                    else
                    {
                        this._OAccountID = default(string);
                    }
                    this.SendPropertyChanged("Account1");
                }
            }
        }

        [AssociationAttribute(Name = "Company_AffectationJournal", Storage = "_Company", ThisKey = "CompanyID", OtherKey = "id", IsForeignKey = true)]
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
                        previousValue.AffectationJournals.Remove(this);
                    }
                    this._Company.Entity = value;
                    if ((value != null))
                    {
                        value.AffectationJournals.Add(this);
                        this._CompanyID = value.id;
                    }
                    else
                    {
                        this._CompanyID = default(string);
                    }
                    this.SendPropertyChanged("Company");
                }
            }
        }

        [AssociationAttribute(Name = "TypeJournal_AffectationJournal", Storage = "_TypeJournal", ThisKey = "TypeJournalID", OtherKey = "Id", IsForeignKey = true)]
        public TypeJournal TypeJournal
        {
            get
            {
                return this._TypeJournal.Entity;
            }
            set
            {
                TypeJournal previousValue = this._TypeJournal.Entity;
                if (((previousValue != value)
                            || (this._TypeJournal.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._TypeJournal.Entity = null;
                        previousValue.AffectationJournals.Remove(this);
                    }
                    this._TypeJournal.Entity = value;
                    if ((value != null))
                    {
                        value.AffectationJournals.Add(this);
                        this._TypeJournalID = value.Id;
                    }
                    else
                    {
                        this._TypeJournalID = default(string);
                    }
                    this.SendPropertyChanged("TypeJournal");
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