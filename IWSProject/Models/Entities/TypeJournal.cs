using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace IWSProject.Models.Entities
{
    [TableAttribute(Name = "dbo.TypeJournal")]
    public partial class TypeJournal : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _Id;

        private string _Name;

        private string _Description;

        private DateTime _Posted;

        private DateTime _Updated;

        private string _CompanyId;

        private int _ModelId;

        private EntitySet<Account> _Accounts;

        private EntitySet<AffectationJournal> _AffectationJournals;

        private EntitySet<MasterCompta> _MasterComptas;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnIdChanging(string value);
        partial void OnIdChanged();
        partial void OnNameChanging(string value);
        partial void OnNameChanged();
        partial void OnDescriptionChanging(string value);
        partial void OnDescriptionChanged();
        partial void OnPostedChanging(DateTime value);
        partial void OnPostedChanged();
        partial void OnUpdatedChanging(DateTime value);
        partial void OnUpdatedChanged();
        partial void OnCompanyIdChanging(string value);
        partial void OnCompanyIdChanged();
        partial void OnModelIdChanging(int value);
        partial void OnModelIdChanged();
        #endregion

        public TypeJournal()
        {
            this._Accounts = new EntitySet<Account>(new Action<Account>(this.attach_Accounts), new Action<Account>(this.detach_Accounts));
            this._AffectationJournals = new EntitySet<AffectationJournal>(new Action<AffectationJournal>(this.attach_AffectationJournals), new Action<AffectationJournal>(this.detach_AffectationJournals));
            this._MasterComptas = new EntitySet<MasterCompta>(new Action<MasterCompta>(this.attach_MasterComptas), new Action<MasterCompta>(this.detach_MasterComptas));
            OnCreated();
        }

        [ColumnAttribute(Storage = "_Id", DbType = "VarChar(50) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
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

        [ColumnAttribute(Storage = "_Name", DbType = "NVarChar(150) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_Description", DbType = "NVarChar(250)")]
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
                    this.OnCompanyIdChanging(value);
                    this.SendPropertyChanging();
                    this._CompanyId = value;
                    this.SendPropertyChanged("CompanyId");
                    this.OnCompanyIdChanged();
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

        [AssociationAttribute(Name = "TypeJournal_Account", Storage = "_Accounts", ThisKey = "Id", OtherKey = "TypeJournal")]
        public EntitySet<Account> Accounts
        {
            get
            {
                return this._Accounts;
            }
            set
            {
                this._Accounts.Assign(value);
            }
        }

        [AssociationAttribute(Name = "TypeJournal_AffectationJournal", Storage = "_AffectationJournals", ThisKey = "Id", OtherKey = "TypeJournalID")]
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

        [AssociationAttribute(Name = "TypeJournal_MasterCompta", Storage = "_MasterComptas", ThisKey = "Id", OtherKey = "TypeJournal")]
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

        private void attach_Accounts(Account entity)
        {
            this.SendPropertyChanging();
            entity.TypeJournal1 = this;
        }

        private void detach_Accounts(Account entity)
        {
            this.SendPropertyChanging();
            entity.TypeJournal1 = null;
        }

        private void attach_AffectationJournals(AffectationJournal entity)
        {
            this.SendPropertyChanging();
            entity.TypeJournal = this;
        }

        private void detach_AffectationJournals(AffectationJournal entity)
        {
            this.SendPropertyChanging();
            entity.TypeJournal = null;
        }

        private void attach_MasterComptas(MasterCompta entity)
        {
            this.SendPropertyChanging();
            entity.TypeJournal1 = this;
        }

        private void detach_MasterComptas(MasterCompta entity)
        {
            this.SendPropertyChanging();
            entity.TypeJournal1 = null;
        }
    }

}