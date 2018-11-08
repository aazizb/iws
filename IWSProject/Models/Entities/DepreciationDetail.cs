using System;
using System.ComponentModel;
using System.Data.Linq.Mapping;

namespace IWSProject.Models.Entities
{
    [TableAttribute(Name = "dbo.DepreciationDetail")]
    public partial class DepreciationDetail : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _Id;

        private string _TransId;

        private string _Period;

        private decimal _Depreciation;

        private decimal _Accumulated;

        private decimal _BookValue;

        private decimal _Percentage;

        private string _Currency;

        private System.Nullable<bool> _IsValidated;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIdChanging(int value);
        partial void OnIdChanged();
        partial void OnTransIdChanging(string value);
        partial void OnTransIdChanged();
        partial void OnPeriodChanging(string value);
        partial void OnPeriodChanged();
        partial void OnDepreciationChanging(decimal value);
        partial void OnDepreciationChanged();
        partial void OnAccumulatedChanging(decimal value);
        partial void OnAccumulatedChanged();
        partial void OnBookValueChanging(decimal value);
        partial void OnBookValueChanged();
        partial void OnPercentageChanging(decimal value);
        partial void OnPercentageChanged();
        partial void OnCurrencyChanging(string value);
        partial void OnCurrencyChanged();
        partial void OnIsValidatedChanging(System.Nullable<bool> value);
        partial void OnIsValidatedChanged();
        #endregion

        public DepreciationDetail()
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

        [ColumnAttribute(Storage = "_TransId", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string TransId
        {
            get
            {
                return this._TransId;
            }
            set
            {
                if ((this._TransId != value))
                {
                    this.OnTransIdChanging(value);
                    this.SendPropertyChanging();
                    this._TransId = value;
                    this.SendPropertyChanged("TransId");
                    this.OnTransIdChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Period", DbType = "NVarChar(7) NOT NULL", CanBeNull = false)]
        public string Period
        {
            get
            {
                return this._Period;
            }
            set
            {
                if ((this._Period != value))
                {
                    this.OnPeriodChanging(value);
                    this.SendPropertyChanging();
                    this._Period = value;
                    this.SendPropertyChanged("Period");
                    this.OnPeriodChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Depreciation", DbType = "Money NOT NULL")]
        public decimal Depreciation
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

        [ColumnAttribute(Storage = "_Accumulated", DbType = "Money NOT NULL")]
        public decimal Accumulated
        {
            get
            {
                return this._Accumulated;
            }
            set
            {
                if ((this._Accumulated != value))
                {
                    this.OnAccumulatedChanging(value);
                    this.SendPropertyChanging();
                    this._Accumulated = value;
                    this.SendPropertyChanged("Accumulated");
                    this.OnAccumulatedChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_BookValue", DbType = "Money NOT NULL")]
        public decimal BookValue
        {
            get
            {
                return this._BookValue;
            }
            set
            {
                if ((this._BookValue != value))
                {
                    this.OnBookValueChanging(value);
                    this.SendPropertyChanging();
                    this._BookValue = value;
                    this.SendPropertyChanged("BookValue");
                    this.OnBookValueChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Percentage", DbType = "Money NOT NULL")]
        public decimal Percentage
        {
            get
            {
                return this._Percentage;
            }
            set
            {
                if ((this._Percentage != value))
                {
                    this.OnPercentageChanging(value);
                    this.SendPropertyChanging();
                    this._Percentage = value;
                    this.SendPropertyChanged("Percentage");
                    this.OnPercentageChanged();
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

        [ColumnAttribute(Storage = "_IsValidated", DbType = "Bit")]
        public System.Nullable<bool> IsValidated
        {
            get
            {
                return this._IsValidated;
            }
            set
            {
                if ((this._IsValidated != value))
                {
                    this.OnIsValidatedChanging(value);
                    this.SendPropertyChanging();
                    this._IsValidated = value;
                    this.SendPropertyChanged("IsValidated");
                    this.OnIsValidatedChanged();
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