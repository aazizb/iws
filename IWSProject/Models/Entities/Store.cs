using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace IWSProject.Models.Entities
{
    [TableAttribute(Name = "dbo.Store")]
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

        private DateTime _Posted;

        private DateTime _Updated;

        private int _ModelId;

        private EntitySet<MasterLogistic> _MasterLogistics;

        private EntitySet<Stock> _Stocks;

        private EntityRef<Account> _Account;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
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
        partial void OnPostedChanging(DateTime value);
        partial void OnPostedChanged();
        partial void OnUpdatedChanging(DateTime value);
        partial void OnUpdatedChanged();
        partial void OnModelIdChanging(int value);
        partial void OnModelIdChanged();
        #endregion

        public Store()
        {
            this._MasterLogistics = new EntitySet<MasterLogistic>(new Action<MasterLogistic>(this.attach_MasterLogistics), new Action<MasterLogistic>(this.detach_MasterLogistics));
            this._Stocks = new EntitySet<Stock>(new Action<Stock>(this.attach_Stocks), new Action<Stock>(this.detach_Stocks));
            this._Account = default(EntityRef<Account>);
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

        [ColumnAttribute(Storage = "_name", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_street", DbType = "NVarChar(50)")]
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

        [ColumnAttribute(Storage = "_city", DbType = "NVarChar(50)")]
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

        [ColumnAttribute(Storage = "_state", DbType = "NVarChar(50)")]
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

        [ColumnAttribute(Storage = "_zip", DbType = "NVarChar(50)")]
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

        [ColumnAttribute(Storage = "_accountid", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
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
                        throw new ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnaccountidChanging(value);
                    this.SendPropertyChanging();
                    this._accountid = value;
                    this.SendPropertyChanged("accountid");
                    this.OnaccountidChanged();
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

        [AssociationAttribute(Name = "Store_MasterLogistic", Storage = "_MasterLogistics", ThisKey = "id", OtherKey = "store")]
        public EntitySet<MasterLogistic> MasterLogistics
        {
            get
            {
                return this._MasterLogistics;
            }
            set
            {
                this._MasterLogistics.Assign(value);
            }
        }

        [AssociationAttribute(Name = "Store_Stock", Storage = "_Stocks", ThisKey = "id", OtherKey = "storeid")]
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

        [AssociationAttribute(Name = "Account_Store", Storage = "_Account", ThisKey = "accountid", OtherKey = "id", IsForeignKey = true)]
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

        private void attach_MasterLogistics(MasterLogistic entity)
        {
            this.SendPropertyChanging();
            entity.Store1 = this;
        }

        private void detach_MasterLogistics(MasterLogistic entity)
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
}