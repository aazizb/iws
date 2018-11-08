using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace IWSProject.Models.Entities
{
    [TableAttribute(Name = "dbo.Asset")]
    public partial class Asset : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _Id;

        private string _Name;

        private System.Nullable<decimal> _ScrapValue;

        private string _Currency;

        private System.Nullable<int> _LifeSpan;

        private System.Nullable<int> _Depreciation;

        private System.Nullable<decimal> _Rate;

        private string _Account;

        private string _OAccount;

        private System.Nullable<System.DateTime> _Started;

        private System.Nullable<System.DateTime> _Posted;

        private System.Nullable<System.DateTime> _Updated;

        private string _Description;

        private int _ModelId;

        private string _CompanyId;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIdChanging(string value);
        partial void OnIdChanged();
        partial void OnNameChanging(string value);
        partial void OnNameChanged();
        partial void OnScrapValueChanging(System.Nullable<decimal> value);
        partial void OnScrapValueChanged();
        partial void OnCurrencyChanging(string value);
        partial void OnCurrencyChanged();
        partial void OnLifeSpanChanging(System.Nullable<int> value);
        partial void OnLifeSpanChanged();
        partial void OnDepreciationChanging(System.Nullable<int> value);
        partial void OnDepreciationChanged();
        partial void OnRateChanging(System.Nullable<decimal> value);
        partial void OnRateChanged();
        partial void OnAccountChanging(string value);
        partial void OnAccountChanged();
        partial void OnOAccountChanging(string value);
        partial void OnOAccountChanged();
        partial void OnStartedChanging(System.Nullable<System.DateTime> value);
        partial void OnStartedChanged();
        partial void OnPostedChanging(System.Nullable<System.DateTime> value);
        partial void OnPostedChanged();
        partial void OnUpdatedChanging(System.Nullable<System.DateTime> value);
        partial void OnUpdatedChanged();
        partial void OnDescriptionChanging(string value);
        partial void OnDescriptionChanged();
        partial void OnModelIdChanging(int value);
        partial void OnModelIdChanged();
        partial void OnCompanyIdChanging(string value);
        partial void OnCompanyIdChanged();
        #endregion

        public Asset()
        {
            OnCreated();
        }

        [ColumnAttribute(Storage = "_Id", DbType = "NVarChar(50) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
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

        [ColumnAttribute(Storage = "_Name", DbType = "NVarChar(50)")]
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

        [ColumnAttribute(Storage = "_ScrapValue", DbType = "Money")]
        public System.Nullable<decimal> ScrapValue
        {
            get
            {
                return this._ScrapValue;
            }
            set
            {
                if ((this._ScrapValue != value))
                {
                    this.OnScrapValueChanging(value);
                    this.SendPropertyChanging();
                    this._ScrapValue = value;
                    this.SendPropertyChanged("ScrapValue");
                    this.OnScrapValueChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Currency", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_LifeSpan", DbType = "Int")]
        public System.Nullable<int> LifeSpan
        {
            get
            {
                return this._LifeSpan;
            }
            set
            {
                if ((this._LifeSpan != value))
                {
                    this.OnLifeSpanChanging(value);
                    this.SendPropertyChanging();
                    this._LifeSpan = value;
                    this.SendPropertyChanged("LifeSpan");
                    this.OnLifeSpanChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Depreciation", DbType = "Int")]
        public System.Nullable<int> Depreciation
        {
            get
            {
                return this._Depreciation;
            }
            set
            {
                if ((this._Depreciation != value))
                {
                    this.OnDepreciationChanging(value);
                    this.SendPropertyChanging();
                    this._Depreciation = value;
                    this.SendPropertyChanged("Depreciation");
                    this.OnDepreciationChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Rate", DbType = "Decimal(5,2)")]
        public System.Nullable<decimal> Rate
        {
            get
            {
                return this._Rate;
            }
            set
            {
                if ((this._Rate != value))
                {
                    this.OnRateChanging(value);
                    this.SendPropertyChanging();
                    this._Rate = value;
                    this.SendPropertyChanged("Rate");
                    this.OnRateChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Account", DbType = "NVarChar(50)")]
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

        [ColumnAttribute(Storage = "_OAccount", DbType = "NVarChar(50)")]
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

        [ColumnAttribute(Storage = "_Started", DbType = "DateTime2")]
        public System.Nullable<System.DateTime> Started
        {
            get
            {
                return this._Started;
            }
            set
            {
                if ((this._Started != value))
                {
                    this.OnStartedChanging(value);
                    this.SendPropertyChanging();
                    this._Started = value;
                    this.SendPropertyChanged("Started");
                    this.OnStartedChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Posted", DbType = "DateTime2")]
        public System.Nullable<System.DateTime> Posted
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

        [ColumnAttribute(Storage = "_Updated", DbType = "DateTime2")]
        public System.Nullable<System.DateTime> Updated
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