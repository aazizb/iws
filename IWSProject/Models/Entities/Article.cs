using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace IWSProject.Models.Entities
{
    [TableAttribute(Name = "dbo.Article")]
    public partial class Article : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _id;

        private string _name;

        private string _description;

        private decimal _price;

        private decimal _avgprice;

        private decimal _salesprice;

        private string _qttyunit;

        private string _packunit;

        private string _VatCode;

        private bool _IsService;

        private string _CompanyID;

        private string _StockAccount;

        private string _ExpenseAccount;

        private string _Currency;

        private string _GroupId;

        private string _RevenuAccountId;

        private DateTime _Posted;

        private DateTime _Updated;

        private int _ModelId;

        private EntitySet<DetailLogistic> _DetailLogistics;

        private EntitySet<Stock> _Stocks;

        private EntityRef<Vat> _Vat;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnidChanging(string value);
        partial void OnidChanged();
        partial void OnnameChanging(string value);
        partial void OnnameChanged();
        partial void OndescriptionChanging(string value);
        partial void OndescriptionChanged();
        partial void OnpriceChanging(decimal value);
        partial void OnpriceChanged();
        partial void OnavgpriceChanging(decimal value);
        partial void OnavgpriceChanged();
        partial void OnsalespriceChanging(decimal value);
        partial void OnsalespriceChanged();
        partial void OnqttyunitChanging(string value);
        partial void OnqttyunitChanged();
        partial void OnpackunitChanging(string value);
        partial void OnpackunitChanged();
        partial void OnVatCodeChanging(string value);
        partial void OnVatCodeChanged();
        partial void OnIsServiceChanging(bool value);
        partial void OnIsServiceChanged();
        partial void OnCompanyIDChanging(string value);
        partial void OnCompanyIDChanged();
        partial void OnStockAccountChanging(string value);
        partial void OnStockAccountChanged();
        partial void OnExpenseAccountChanging(string value);
        partial void OnExpenseAccountChanged();
        partial void OnCurrencyChanging(string value);
        partial void OnCurrencyChanged();
        partial void OnGroupIdChanging(string value);
        partial void OnGroupIdChanged();
        partial void OnRevenuAccountIdChanging(string value);
        partial void OnRevenuAccountIdChanged();
        partial void OnPostedChanging(DateTime value);
        partial void OnPostedChanged();
        partial void OnUpdatedChanging(DateTime value);
        partial void OnUpdatedChanged();
        partial void OnModelIdChanging(int value);
        partial void OnModelIdChanged();
        #endregion

        public Article()
        {
            this._DetailLogistics = new EntitySet<DetailLogistic>(new Action<DetailLogistic>(this.attach_DetailLogistics), new Action<DetailLogistic>(this.detach_DetailLogistics));
            this._Stocks = new EntitySet<Stock>(new Action<Stock>(this.attach_Stocks), new Action<Stock>(this.detach_Stocks));
            this._Vat = default(EntityRef<Vat>);
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

        [ColumnAttribute(Storage = "_name", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_avgprice", DbType = "Money NOT NULL")]
        public decimal avgprice
        {
            get
            {
                return this._avgprice;
            }
            set
            {
                if ((this._avgprice != value))
                {
                    this.OnavgpriceChanging(value);
                    this.SendPropertyChanging();
                    this._avgprice = value;
                    this.SendPropertyChanged("avgprice");
                    this.OnavgpriceChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_salesprice", DbType = "Money NOT NULL")]
        public decimal salesprice
        {
            get
            {
                return this._salesprice;
            }
            set
            {
                if ((this._salesprice != value))
                {
                    this.OnsalespriceChanging(value);
                    this.SendPropertyChanging();
                    this._salesprice = value;
                    this.SendPropertyChanged("salesprice");
                    this.OnsalespriceChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_qttyunit", DbType = "NVarChar(255)")]
        public string qttyunit
        {
            get
            {
                return this._qttyunit;
            }
            set
            {
                if ((this._qttyunit != value))
                {
                    this.OnqttyunitChanging(value);
                    this.SendPropertyChanging();
                    this._qttyunit = value;
                    this.SendPropertyChanged("qttyunit");
                    this.OnqttyunitChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_packunit", DbType = "NVarChar(255)")]
        public string packunit
        {
            get
            {
                return this._packunit;
            }
            set
            {
                if ((this._packunit != value))
                {
                    this.OnpackunitChanging(value);
                    this.SendPropertyChanging();
                    this._packunit = value;
                    this.SendPropertyChanged("packunit");
                    this.OnpackunitChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_VatCode", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string VatCode
        {
            get
            {
                return this._VatCode;
            }
            set
            {
                if ((this._VatCode != value))
                {
                    if (this._Vat.HasLoadedOrAssignedValue)
                    {
                        throw new ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnVatCodeChanging(value);
                    this.SendPropertyChanging();
                    this._VatCode = value;
                    this.SendPropertyChanged("VatCode");
                    this.OnVatCodeChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_IsService", DbType = "Bit NOT NULL")]
        public bool IsService
        {
            get
            {
                return this._IsService;
            }
            set
            {
                if ((this._IsService != value))
                {
                    this.OnIsServiceChanging(value);
                    this.SendPropertyChanging();
                    this._IsService = value;
                    this.SendPropertyChanged("IsService");
                    this.OnIsServiceChanged();
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

        [ColumnAttribute(Storage = "_StockAccount", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string StockAccount
        {
            get
            {
                return this._StockAccount;
            }
            set
            {
                if ((this._StockAccount != value))
                {
                    this.OnStockAccountChanging(value);
                    this.SendPropertyChanging();
                    this._StockAccount = value;
                    this.SendPropertyChanged("StockAccount");
                    this.OnStockAccountChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_ExpenseAccount", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string ExpenseAccount
        {
            get
            {
                return this._ExpenseAccount;
            }
            set
            {
                if ((this._ExpenseAccount != value))
                {
                    this.OnExpenseAccountChanging(value);
                    this.SendPropertyChanging();
                    this._ExpenseAccount = value;
                    this.SendPropertyChanged("ExpenseAccount");
                    this.OnExpenseAccountChanged();
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

        [ColumnAttribute(Storage = "_GroupId", DbType = "NVarChar(50)")]
        public string GroupId
        {
            get
            {
                return this._GroupId;
            }
            set
            {
                if ((this._GroupId != value))
                {
                    this.OnGroupIdChanging(value);
                    this.SendPropertyChanging();
                    this._GroupId = value;
                    this.SendPropertyChanged("GroupId");
                    this.OnGroupIdChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_RevenuAccountId", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string RevenuAccountId
        {
            get
            {
                return this._RevenuAccountId;
            }
            set
            {
                if ((this._RevenuAccountId != value))
                {
                    this.OnRevenuAccountIdChanging(value);
                    this.SendPropertyChanging();
                    this._RevenuAccountId = value;
                    this.SendPropertyChanged("RevenuAccountId");
                    this.OnRevenuAccountIdChanged();
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

        [AssociationAttribute(Name = "Article_DetailLogistic", Storage = "_DetailLogistics", ThisKey = "id", OtherKey = "item")]
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

        [AssociationAttribute(Name = "Article_Stock", Storage = "_Stocks", ThisKey = "id", OtherKey = "itemid")]
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

        [AssociationAttribute(Name = "Vat_Article", Storage = "_Vat", ThisKey = "VatCode", OtherKey = "id", IsForeignKey = true)]
        public Vat Vat
        {
            get
            {
                return this._Vat.Entity;
            }
            set
            {
                Vat previousValue = this._Vat.Entity;
                if (((previousValue != value)
                            || (this._Vat.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Vat.Entity = null;
                        previousValue.Articles.Remove(this);
                    }
                    this._Vat.Entity = value;
                    if ((value != null))
                    {
                        value.Articles.Add(this);
                        this._VatCode = value.id;
                    }
                    else
                    {
                        this._VatCode = default(string);
                    }
                    this.SendPropertyChanged("Vat");
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
            entity.Article = this;
        }

        private void detach_DetailLogistics(DetailLogistic entity)
        {
            this.SendPropertyChanging();
            entity.Article = null;
        }

        private void attach_Stocks(Stock entity)
        {
            this.SendPropertyChanging();
            entity.Article = this;
        }

        private void detach_Stocks(Stock entity)
        {
            this.SendPropertyChanging();
            entity.Article = null;
        }
    }
}