using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace IWSProject.Models.Entities
{
    [TableAttribute(Name = "dbo.JournalStock")]
    public partial class JournalStock : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private int _ItemID;

        private int _OID;

        private string _ItemType;

        private string _CustSupplierID;

        private string _StoreID;

        private string _ArticleID;

        private string _ArticleName;

        private decimal _Quantity;

        private decimal _Price;

        private decimal _AvgPrice;

        private DateTime _TransDate;

        private string _Periode;

        private string _Account;

        private string _OAccount;

        private decimal _Amount;

        private string _Side;

        private string _CompanyID;

        private Nullable<int> _ModelId;

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
        partial void OnArticleIDChanging(string value);
        partial void OnArticleIDChanged();
        partial void OnArticleNameChanging(string value);
        partial void OnArticleNameChanged();
        partial void OnQuantityChanging(decimal value);
        partial void OnQuantityChanged();
        partial void OnPriceChanging(decimal value);
        partial void OnPriceChanged();
        partial void OnAvgPriceChanging(decimal value);
        partial void OnAvgPriceChanged();
        partial void OnTransDateChanging(DateTime value);
        partial void OnTransDateChanged();
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
        partial void OnModelIdChanging(Nullable<int> value);
        partial void OnModelIdChanged();
        #endregion

        public JournalStock()
        {
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

        [ColumnAttribute(Storage = "_ItemType", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_ArticleID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string ArticleID
        {
            get
            {
                return this._ArticleID;
            }
            set
            {
                if ((this._ArticleID != value))
                {
                    this.OnArticleIDChanging(value);
                    this.SendPropertyChanging();
                    this._ArticleID = value;
                    this.SendPropertyChanged("ArticleID");
                    this.OnArticleIDChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_ArticleName", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string ArticleName
        {
            get
            {
                return this._ArticleName;
            }
            set
            {
                if ((this._ArticleName != value))
                {
                    this.OnArticleNameChanging(value);
                    this.SendPropertyChanging();
                    this._ArticleName = value;
                    this.SendPropertyChanged("ArticleName");
                    this.OnArticleNameChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Quantity", DbType = "Decimal(16,2) NOT NULL")]
        public decimal Quantity
        {
            get
            {
                return this._Quantity;
            }
            set
            {
                if ((this._Quantity != value))
                {
                    this.OnQuantityChanging(value);
                    this.SendPropertyChanging();
                    this._Quantity = value;
                    this.SendPropertyChanged("Quantity");
                    this.OnQuantityChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Price", DbType = "Decimal(16,2) NOT NULL")]
        public decimal Price
        {
            get
            {
                return this._Price;
            }
            set
            {
                if ((this._Price != value))
                {
                    this.OnPriceChanging(value);
                    this.SendPropertyChanging();
                    this._Price = value;
                    this.SendPropertyChanged("Price");
                    this.OnPriceChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_AvgPrice", DbType = "Decimal(16,2) NOT NULL")]
        public decimal AvgPrice
        {
            get
            {
                return this._AvgPrice;
            }
            set
            {
                if ((this._AvgPrice != value))
                {
                    this.OnAvgPriceChanging(value);
                    this.SendPropertyChanging();
                    this._AvgPrice = value;
                    this.SendPropertyChanged("AvgPrice");
                    this.OnAvgPriceChanged();
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
                    this.OnOAccountChanging(value);
                    this.SendPropertyChanging();
                    this._OAccount = value;
                    this.SendPropertyChanged("OAccount");
                    this.OnOAccountChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Amount", DbType = "Decimal(16,2) NOT NULL")]
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