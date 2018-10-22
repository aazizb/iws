using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace IWSProject.Models.Entities
{
    [TableAttribute(Name = "dbo.Stock")]
    public partial class Stock : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _id;

        private string _name;

        private string _description;

        private string _itemid;

        private string _storeid;

        private float _quantity;

        private short _minstock;

        private string _CompanyID;

        private string _Currency;

        private int _ModelId;

        private EntityRef<Article> _Article;

        private EntityRef<Store> _Store;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnidChanging(int value);
        partial void OnidChanged();
        partial void OnnameChanging(string value);
        partial void OnnameChanged();
        partial void OndescriptionChanging(string value);
        partial void OndescriptionChanged();
        partial void OnitemidChanging(string value);
        partial void OnitemidChanged();
        partial void OnstoreidChanging(string value);
        partial void OnstoreidChanged();
        partial void OnquantityChanging(float value);
        partial void OnquantityChanged();
        partial void OnminstockChanging(short value);
        partial void OnminstockChanged();
        partial void OnCompanyIDChanging(string value);
        partial void OnCompanyIDChanged();
        partial void OnCurrencyChanging(string value);
        partial void OnCurrencyChanged();
        partial void OnModelIdChanging(int value);
        partial void OnModelIdChanged();
        #endregion

        public Stock()
        {
            this._Article = default(EntityRef<Article>);
            this._Store = default(EntityRef<Store>);
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

        [ColumnAttribute(Storage = "_itemid", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string itemid
        {
            get
            {
                return this._itemid;
            }
            set
            {
                if ((this._itemid != value))
                {
                    if (this._Article.HasLoadedOrAssignedValue)
                    {
                        throw new ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnitemidChanging(value);
                    this.SendPropertyChanging();
                    this._itemid = value;
                    this.SendPropertyChanged("itemid");
                    this.OnitemidChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_storeid", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string storeid
        {
            get
            {
                return this._storeid;
            }
            set
            {
                if ((this._storeid != value))
                {
                    if (this._Store.HasLoadedOrAssignedValue)
                    {
                        throw new ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnstoreidChanging(value);
                    this.SendPropertyChanging();
                    this._storeid = value;
                    this.SendPropertyChanged("storeid");
                    this.OnstoreidChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_quantity", DbType = "Real NOT NULL")]
        public float quantity
        {
            get
            {
                return this._quantity;
            }
            set
            {
                if ((this._quantity != value))
                {
                    this.OnquantityChanging(value);
                    this.SendPropertyChanging();
                    this._quantity = value;
                    this.SendPropertyChanged("quantity");
                    this.OnquantityChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_minstock", DbType = "SmallInt NOT NULL")]
        public short minstock
        {
            get
            {
                return this._minstock;
            }
            set
            {
                if ((this._minstock != value))
                {
                    this.OnminstockChanging(value);
                    this.SendPropertyChanging();
                    this._minstock = value;
                    this.SendPropertyChanged("minstock");
                    this.OnminstockChanged();
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

        [AssociationAttribute(Name = "Article_Stock", Storage = "_Article", ThisKey = "itemid", OtherKey = "id", IsForeignKey = true)]
        public Article Article
        {
            get
            {
                return this._Article.Entity;
            }
            set
            {
                Article previousValue = this._Article.Entity;
                if (((previousValue != value)
                            || (this._Article.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Article.Entity = null;
                        previousValue.Stocks.Remove(this);
                    }
                    this._Article.Entity = value;
                    if ((value != null))
                    {
                        value.Stocks.Add(this);
                        this._itemid = value.id;
                    }
                    else
                    {
                        this._itemid = default(string);
                    }
                    this.SendPropertyChanged("Article");
                }
            }
        }

        [AssociationAttribute(Name = "Store_Stock", Storage = "_Store", ThisKey = "storeid", OtherKey = "id", IsForeignKey = true)]
        public Store Store
        {
            get
            {
                return this._Store.Entity;
            }
            set
            {
                Store previousValue = this._Store.Entity;
                if (((previousValue != value)
                            || (this._Store.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Store.Entity = null;
                        previousValue.Stocks.Remove(this);
                    }
                    this._Store.Entity = value;
                    if ((value != null))
                    {
                        value.Stocks.Add(this);
                        this._storeid = value.id;
                    }
                    else
                    {
                        this._storeid = default(string);
                    }
                    this.SendPropertyChanged("Store");
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