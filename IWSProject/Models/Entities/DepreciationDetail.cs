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

        private int _TransId;

        private int _Period;

        private decimal _Depreciation;

        private decimal _StraightLineDepreciation;

        private decimal _StraightLineBookValue;

        private decimal _Accumulated;

        private decimal _BookValue;

        private decimal _Percentage;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIdChanging(int value);
        partial void OnIdChanged();
        partial void OnTransIdChanging(int value);
        partial void OnTransIdChanged();
        partial void OnPeriodChanging(int value);
        partial void OnPeriodChanged();
        partial void OnDepreciationChanging(decimal value);
        partial void OnDepreciationChanged();
        partial void OnStraightLineDepreciationChanging(decimal value);
        partial void OnStraightLineDepreciationChanged();
        partial void OnStraightLineBookValueChanging(decimal value);
        partial void OnStraightLineBookValueChanged();
        partial void OnAccumulatedChanging(decimal value);
        partial void OnAccumulatedChanged();
        partial void OnBookValueChanging(decimal value);
        partial void OnBookValueChanged();
        partial void OnPercentageChanging(decimal value);
        partial void OnPercentageChanged();
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

        [ColumnAttribute(Storage = "_TransId", DbType = "Int NOT NULL")]
        public int TransId
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

        [ColumnAttribute(Storage = "_Period", DbType = "Int NOT NULL")]
        public int Period
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

        [ColumnAttribute(Storage = "_StraightLineDepreciation", DbType = "Money NOT NULL")]
        public decimal StraightLineDepreciation
        {
            get
            {
                return this._StraightLineDepreciation;
            }
            set
            {
                if ((this._StraightLineDepreciation != value))
                {
                    this.OnStraightLineDepreciationChanging(value);
                    this.SendPropertyChanging();
                    this._StraightLineDepreciation = value;
                    this.SendPropertyChanged("StraightLineDepreciation");
                    this.OnStraightLineDepreciationChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_StraightLineBookValue", DbType = "Money NOT NULL")]
        public decimal StraightLineBookValue
        {
            get
            {
                return this._StraightLineBookValue;
            }
            set
            {
                if ((this._StraightLineBookValue != value))
                {
                    this.OnStraightLineBookValueChanging(value);
                    this.SendPropertyChanging();
                    this._StraightLineBookValue = value;
                    this.SendPropertyChanged("StraightLineBookValue");
                    this.OnStraightLineBookValueChanged();
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

    #region MyRegion

    //[TableAttribute(Name = "dbo.DepreciationDetail")]
    //public partial class DepreciationDetail : INotifyPropertyChanging, INotifyPropertyChanged
    //{

    //    private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

    //    private int _Id;

    //    private int _TransId;

    //    private int _Period;

    //    private decimal _Depreciation;

    //    private decimal _Accumulated;

    //    private decimal _BookValue;

    //    private decimal _Percentage;

    //    #region Extensibility Method Definitions
    //    partial void OnLoaded();
    //    partial void OnValidate(ChangeAction action);
    //    partial void OnCreated();
    //    partial void OnIdChanging(int value);
    //    partial void OnIdChanged();
    //    partial void OnTransIdChanging(int value);
    //    partial void OnTransIdChanged();
    //    partial void OnPeriodChanging(int value);
    //    partial void OnPeriodChanged();
    //    partial void OnDepreciationChanging(decimal value);
    //    partial void OnDepreciationChanged();
    //    partial void OnAccumulatedChanging(decimal value);
    //    partial void OnAccumulatedChanged();
    //    partial void OnBookValueChanging(decimal value);
    //    partial void OnBookValueChanged();
    //    partial void OnPercentageChanging(decimal value);
    //    partial void OnPercentageChanged();
    //    #endregion

    //    public DepreciationDetail()
    //    {
    //        OnCreated();
    //    }


    //    [ColumnAttribute(Storage = "_Id", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
    //    public int Id
    //    {
    //        get
    //        {
    //            return this._Id;
    //        }
    //        set
    //        {
    //            if ((this._Id != value))
    //            {
    //                this.OnIdChanging(value);
    //                this.SendPropertyChanging();
    //                this._Id = value;
    //                this.SendPropertyChanged("Id");
    //                this.OnIdChanged();
    //            }
    //        }
    //    }

    //    public static explicit operator DepreciationDetail(DepreciationInfo v)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    [ColumnAttribute(Storage = "_TransId", DbType = "Int NOT NULL")]
    //    public int TransId
    //    {
    //        get
    //        {
    //            return this._TransId;
    //        }
    //        set
    //        {
    //            if ((this._TransId != value))
    //            {
    //                this.OnTransIdChanging(value);
    //                this.SendPropertyChanging();
    //                this._TransId = value;
    //                this.SendPropertyChanged("TransId");
    //                this.OnTransIdChanged();
    //            }
    //        }
    //    }

    //    [ColumnAttribute(Storage = "_Period", DbType = "Int NOT NULL")]
    //    public int Period
    //    {
    //        get
    //        {
    //            return this._Period;
    //        }
    //        set
    //        {
    //            if ((this._Period != value))
    //            {
    //                this.OnPeriodChanging(value);
    //                this.SendPropertyChanging();
    //                this._Period = value;
    //                this.SendPropertyChanged("Period");
    //                this.OnPeriodChanged();
    //            }
    //        }
    //    }

    //    [ColumnAttribute(Storage = "_Depreciation", DbType = "Money NOT NULL")]
    //    public decimal Depreciation
    //    {
    //        get
    //        {
    //            return this._Depreciation;
    //        }
    //        set
    //        {
    //            if ((this._Depreciation != value))
    //            {
    //                this.OnDepreciationChanging(value);
    //                this.SendPropertyChanging();
    //                this._Depreciation = value;
    //                this.SendPropertyChanged("Depreciation");
    //                this.OnDepreciationChanged();
    //            }
    //        }
    //    }

    //    [ColumnAttribute(Storage = "_Accumulated", DbType = "Money NOT NULL")]
    //    public decimal Accumulated
    //    {
    //        get
    //        {
    //            return this._Accumulated;
    //        }
    //        set
    //        {
    //            if ((this._Accumulated != value))
    //            {
    //                this.OnAccumulatedChanging(value);
    //                this.SendPropertyChanging();
    //                this._Accumulated = value;
    //                this.SendPropertyChanged("Accumulated");
    //                this.OnAccumulatedChanged();
    //            }
    //        }
    //    }

    //    [ColumnAttribute(Storage = "_BookValue", DbType = "Money NOT NULL")]
    //    public decimal BookValue
    //    {
    //        get
    //        {
    //            return this._BookValue;
    //        }
    //        set
    //        {
    //            if ((this._BookValue != value))
    //            {
    //                this.OnBookValueChanging(value);
    //                this.SendPropertyChanging();
    //                this._BookValue = value;
    //                this.SendPropertyChanged("BookValue");
    //                this.OnBookValueChanged();
    //            }
    //        }
    //    }

    //    [ColumnAttribute(Storage = "_Percentage", DbType = "Money NOT NULL")]
    //    public decimal Percentage
    //    {
    //        get
    //        {
    //            return this._Percentage;
    //        }
    //        set
    //        {
    //            if ((this._Percentage != value))
    //            {
    //                this.OnPercentageChanging(value);
    //                this.SendPropertyChanging();
    //                this._Percentage = value;
    //                this.SendPropertyChanged("Percentage");
    //                this.OnPercentageChanged();
    //            }
    //        }
    //    }

    //    public event PropertyChangingEventHandler PropertyChanging;

    //    public event PropertyChangedEventHandler PropertyChanged;

    //    protected virtual void SendPropertyChanging()
    //    {
    //        if ((this.PropertyChanging != null))
    //        {
    //            this.PropertyChanging(this, emptyChangingEventArgs);
    //        }
    //    }

    //    protected virtual void SendPropertyChanged(String propertyName)
    //    {
    //        if ((this.PropertyChanged != null))
    //        {
    //            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    //        }
    //    }
    //}

    #endregion
}