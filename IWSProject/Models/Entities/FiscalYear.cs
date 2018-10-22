using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace IWSProject.Models.Entities
{

    [TableAttribute(Name = "dbo.FiscalYear")]
    public partial class FiscalYear : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _Id;

        private string _Period;

        private string _CompanyId;

        private Nullable<bool> _Current;

        private Nullable<bool> _Open;

        private Nullable<int> _ModelId;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnIdChanging(int value);
        partial void OnIdChanged();
        partial void OnPeriodChanging(string value);
        partial void OnPeriodChanged();
        partial void OnCompanyIdChanging(string value);
        partial void OnCompanyIdChanged();
        partial void OnCurrentChanging(Nullable<bool> value);
        partial void OnCurrentChanged();
        partial void OnOpenChanging(Nullable<bool> value);
        partial void OnOpenChanged();
        partial void OnModelIdChanging(Nullable<int> value);
        partial void OnModelIdChanged();
        #endregion

        public FiscalYear()
        {
            OnCreated();
        }

        [ColumnAttribute(Storage = "_Id", AutoSync = AutoSync.Always, DbType = "Int NOT NULL IDENTITY", IsDbGenerated = true)]
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

        [ColumnAttribute(Storage = "_Period", DbType = "NChar(6) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
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

        [ColumnAttribute(Storage = "_CompanyId", DbType = "NVarChar(50) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
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

        [ColumnAttribute(Name = "[Current]", Storage = "_Current", DbType = "Bit")]
        public Nullable<bool> Current
        {
            get
            {
                return this._Current;
            }
            set
            {
                if ((this._Current != value))
                {
                    this.OnCurrentChanging(value);
                    this.SendPropertyChanging();
                    this._Current = value;
                    this.SendPropertyChanged("Current");
                    this.OnCurrentChanged();
                }
            }
        }

        [ColumnAttribute(Name = "[Open]", Storage = "_Open", DbType = "Bit")]
        public Nullable<bool> Open
        {
            get
            {
                return this._Open;
            }
            set
            {
                if ((this._Open != value))
                {
                    this.OnOpenChanging(value);
                    this.SendPropertyChanging();
                    this._Open = value;
                    this.SendPropertyChanged("Open");
                    this.OnOpenChanged();
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