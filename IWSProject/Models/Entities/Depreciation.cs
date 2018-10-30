using System;
using System.ComponentModel;
using System.Data.Linq.Mapping;

[TableAttribute(Name = "dbo.Depreciation")]
public partial class Depreciation : INotifyPropertyChanging, INotifyPropertyChanged
{

    private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

    private string _Id;

    private System.Nullable<decimal> _CostOfAsset;

    private System.Nullable<decimal> _ScrapValue;

    private System.Nullable<int> _LifeSpan;

    private string _Currency;

    private string _Asset;

    private string _Account;

    private string _OAccount;

    private System.Nullable<int> _Frequency;

    private System.Nullable<System.DateTime> _Started;

    private string _CompanyId;

    private int _ModelId;

    private System.Nullable<System.DateTime> _Posted;

    private System.Nullable<System.DateTime> _Updated;

    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(string value);
    partial void OnIdChanged();
    partial void OnCostOfAssetChanging(System.Nullable<decimal> value);
    partial void OnCostOfAssetChanged();
    partial void OnScrapValueChanging(System.Nullable<decimal> value);
    partial void OnScrapValueChanged();
    partial void OnLifeSpanChanging(System.Nullable<int> value);
    partial void OnLifeSpanChanged();
    partial void OnCurrencyChanging(string value);
    partial void OnCurrencyChanged();
    partial void OnAssetChanging(string value);
    partial void OnAssetChanged();
    partial void OnAccountChanging(string value);
    partial void OnAccountChanged();
    partial void OnOAccountChanging(string value);
    partial void OnOAccountChanged();
    partial void OnFrequencyChanging(System.Nullable<int> value);
    partial void OnFrequencyChanged();
    partial void OnStartedChanging(System.Nullable<System.DateTime> value);
    partial void OnStartedChanged();
    partial void OnCompanyIdChanging(string value);
    partial void OnCompanyIdChanged();
    partial void OnModelIdChanging(int value);
    partial void OnModelIdChanged();
    partial void OnPostedChanging(System.Nullable<System.DateTime> value);
    partial void OnPostedChanged();
    partial void OnUpdatedChanging(System.Nullable<System.DateTime> value);
    partial void OnUpdatedChanged();
    #endregion

    public Depreciation()
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

    [ColumnAttribute(Storage = "_CostOfAsset", DbType = "Money")]
    public System.Nullable<decimal> CostOfAsset
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

    [ColumnAttribute(Storage = "_Frequency", DbType = "Int")]
    public System.Nullable<int> Frequency
    {
        get
        {
            return this._Frequency;
        }
        set
        {
            if ((this._Frequency != value))
            {
                this.OnFrequencyChanging(value);
                this.SendPropertyChanging();
                this._Frequency = value;
                this.SendPropertyChanged("Frequency");
                this.OnFrequencyChanged();
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