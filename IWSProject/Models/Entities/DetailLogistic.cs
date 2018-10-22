using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace IWSProject.Models.Entities
{
    [TableAttribute(Name = "dbo.DetailLogistic")]
    public partial class DetailLogistic : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _id;

        private int _transid;

        private string _item;

        private string _unit;

        private decimal _price;

        private decimal _quantity;

        private decimal _Vat;

        private DateTime _duedate;

        private string _text;

        private Nullable<decimal> _lineNet;

        private Nullable<decimal> _lineVAT;

        private string _Currency;

        private int _ModelId;

        private string _Terms;

        private EntityRef<Article> _Article;

        private EntityRef<MasterLogistic> _MasterLogistic;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnidChanging(int value);
        partial void OnidChanged();
        partial void OntransidChanging(int value);
        partial void OntransidChanged();
        partial void OnitemChanging(string value);
        partial void OnitemChanged();
        partial void OnunitChanging(string value);
        partial void OnunitChanged();
        partial void OnpriceChanging(decimal value);
        partial void OnpriceChanged();
        partial void OnquantityChanging(decimal value);
        partial void OnquantityChanged();
        partial void OnVatChanging(decimal value);
        partial void OnVatChanged();
        partial void OnduedateChanging(DateTime value);
        partial void OnduedateChanged();
        partial void OntextChanging(string value);
        partial void OntextChanged();
        partial void OnlineNetChanging(Nullable<decimal> value);
        partial void OnlineNetChanged();
        partial void OnlineVATChanging(Nullable<decimal> value);
        partial void OnlineVATChanged();
        partial void OnCurrencyChanging(string value);
        partial void OnCurrencyChanged();
        partial void OnModelIdChanging(int value);
        partial void OnModelIdChanged();
        partial void OnTermsChanging(string value);
        partial void OnTermsChanged();
        #endregion

        public DetailLogistic()
        {
            this._Article = default(EntityRef<Article>);
            this._MasterLogistic = default(EntityRef<MasterLogistic>);
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

        [ColumnAttribute(Storage = "_transid", DbType = "Int NOT NULL")]
        public int transid
        {
            get
            {
                return this._transid;
            }
            set
            {
                if ((this._transid != value))
                {
                    if (this._MasterLogistic.HasLoadedOrAssignedValue)
                    {
                        throw new ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OntransidChanging(value);
                    this.SendPropertyChanging();
                    this._transid = value;
                    this.SendPropertyChanged("transid");
                    this.OntransidChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_item", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string item
        {
            get
            {
                return this._item;
            }
            set
            {
                if ((this._item != value))
                {
                    if (this._Article.HasLoadedOrAssignedValue)
                    {
                        throw new ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnitemChanging(value);
                    this.SendPropertyChanging();
                    this._item = value;
                    this.SendPropertyChanged("item");
                    this.OnitemChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_unit", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string unit
        {
            get
            {
                return this._unit;
            }
            set
            {
                if ((this._unit != value))
                {
                    this.OnunitChanging(value);
                    this.SendPropertyChanging();
                    this._unit = value;
                    this.SendPropertyChanged("unit");
                    this.OnunitChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_price", DbType = "Money NOT NULL")]
        public decimal price
        {
            get
            {
                return this._price;
            }
            set
            {
                if ((this._price != value))
                {
                    this.OnpriceChanging(value);
                    this.SendPropertyChanging();
                    this._price = value;
                    this.SendPropertyChanged("price");
                    this.OnpriceChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_quantity", DbType = "Decimal(10,2) NOT NULL")]
        public decimal quantity
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

        [ColumnAttribute(Storage = "_Vat", DbType = "Decimal(16,2) NOT NULL")]
        public decimal Vat
        {
            get
            {
                return this._Vat;
            }
            set
            {
                if ((this._Vat != value))
                {
                    this.OnVatChanging(value);
                    this.SendPropertyChanging();
                    this._Vat = value;
                    this.SendPropertyChanged("Vat");
                    this.OnVatChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_duedate", DbType = "DateTime2 NOT NULL")]
        public DateTime duedate
        {
            get
            {
                return this._duedate;
            }
            set
            {
                if ((this._duedate != value))
                {
                    this.OnduedateChanging(value);
                    this.SendPropertyChanging();
                    this._duedate = value;
                    this.SendPropertyChanged("duedate");
                    this.OnduedateChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_text", DbType = "NVarChar(250)")]
        public string text
        {
            get
            {
                return this._text;
            }
            set
            {
                if ((this._text != value))
                {
                    this.OntextChanging(value);
                    this.SendPropertyChanging();
                    this._text = value;
                    this.SendPropertyChanged("text");
                    this.OntextChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_lineNet", AutoSync = AutoSync.Always, DbType = "Money", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public Nullable<decimal> lineNet
        {
            get
            {
                return this._lineNet;
            }
            set
            {
                if ((this._lineNet != value))
                {
                    this.OnlineNetChanging(value);
                    this.SendPropertyChanging();
                    this._lineNet = value;
                    this.SendPropertyChanged("lineNet");
                    this.OnlineNetChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_lineVAT", AutoSync = AutoSync.Always, DbType = "Money", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public Nullable<decimal> lineVAT
        {
            get
            {
                return this._lineVAT;
            }
            set
            {
                if ((this._lineVAT != value))
                {
                    this.OnlineVATChanging(value);
                    this.SendPropertyChanging();
                    this._lineVAT = value;
                    this.SendPropertyChanged("lineVAT");
                    this.OnlineVATChanged();
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

        [ColumnAttribute(Storage = "_Terms", DbType = "VarChar(250)")]
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

        [AssociationAttribute(Name = "Article_DetailLogistic", Storage = "_Article", ThisKey = "item", OtherKey = "id", IsForeignKey = true)]
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
                        previousValue.DetailLogistics.Remove(this);
                    }
                    this._Article.Entity = value;
                    if ((value != null))
                    {
                        value.DetailLogistics.Add(this);
                        this._item = value.id;
                    }
                    else
                    {
                        this._item = default(string);
                    }
                    this.SendPropertyChanged("Article");
                }
            }
        }

        [AssociationAttribute(Name = "MasterLogistic_DetailLogistic", Storage = "_MasterLogistic", ThisKey = "transid", OtherKey = "id", IsForeignKey = true)]
        public MasterLogistic MasterLogistic
        {
            get
            {
                return this._MasterLogistic.Entity;
            }
            set
            {
                MasterLogistic previousValue = this._MasterLogistic.Entity;
                if (((previousValue != value)
                            || (this._MasterLogistic.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._MasterLogistic.Entity = null;
                        previousValue.DetailLogistics.Remove(this);
                    }
                    this._MasterLogistic.Entity = value;
                    if ((value != null))
                    {
                        value.DetailLogistics.Add(this);
                        this._transid = value.id;
                    }
                    else
                    {
                        this._transid = default(int);
                    }
                    this.SendPropertyChanged("MasterLogistic");
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