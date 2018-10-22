using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace IWSProject.Models.Entities
{
    [TableAttribute(Name = "dbo.Depreciation")]
    public partial class Depreciation : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _Id;

        private Nullable<decimal> _CostOfAsset;

        private Nullable<decimal> _ScrapValue;

        private Nullable<int> _LifeSpan;

        private string _Asset;

        private string _CompanyId;

        private int _ModelId;

        private Nullable<DateTime> _Posted;

        private Nullable<DateTime> _Updated;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnIdChanging(int value);
        partial void OnIdChanged();
        partial void OnCostOfAssetChanging(Nullable<decimal> value);
        partial void OnCostOfAssetChanged();
        partial void OnScrapValueChanging(Nullable<decimal> value);
        partial void OnScrapValueChanged();
        partial void OnLifeSpanChanging(Nullable<int> value);
        partial void OnLifeSpanChanged();
        partial void OnAssetChanging(string value);
        partial void OnAssetChanged();
        partial void OnCompanyIdChanging(string value);
        partial void OnCompanyIdChanged();
        partial void OnModelIdChanging(int value);
        partial void OnModelIdChanged();
        partial void OnPostedChanging(Nullable<DateTime> value);
        partial void OnPostedChanged();
        partial void OnUpdatedChanging(Nullable<DateTime> value);
        partial void OnUpdatedChanged();
        #endregion

        public Depreciation()
        {
            OnCreated();
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

        [ColumnAttribute(Storage = "_CostOfAsset", DbType = "Money")]
        public Nullable<decimal> CostOfAsset
        {
            get
            {
                return this._CostOfAsset;
            }
            set
            {
                if ((this._CostOfAsset != value))
                {
                    this.OnCostOfAssetChanging(value);
                    this.SendPropertyChanging();
                    this._CostOfAsset = value;
                    this.SendPropertyChanged("CostOfAsset");
                    this.OnCostOfAssetChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_ScrapValue", DbType = "Money")]
        public Nullable<decimal> ScrapValue
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

        [ColumnAttribute(Storage = "_LifeSpan", DbType = "Int")]
        public Nullable<int> LifeSpan
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

        [ColumnAttribute(Storage = "_Asset", DbType = "NVarChar(50)")]
        public string Asset
        {
            get
            {
                return this._Asset;
            }
            set
            {
                if ((this._Asset != value))
                {
                    this.OnAssetChanging(value);
                    this.SendPropertyChanging();
                    this._Asset = value;
                    this.SendPropertyChanged("Asset");
                    this.OnAssetChanged();
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

        [ColumnAttribute(Storage = "_Posted", DbType = "DateTime2")]
        public Nullable<DateTime> Posted
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
        public Nullable<DateTime> Updated
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