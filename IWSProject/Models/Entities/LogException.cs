using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace IWSProject.Models.Entities
{
    [TableAttribute(Name = "dbo.LogExceptions")]
    public partial class LogException : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private long _LogId;

        private string _EMessage;

        private string _EType;

        private string _ESource;

        private string _ETarget;

        private string _EURL;

        private DateTime _LogDate;

        private string _CompanyId;

        private string _UserName;

        private Nullable<int> _ModelId;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnLogIdChanging(long value);
        partial void OnLogIdChanged();
        partial void OnEMessageChanging(string value);
        partial void OnEMessageChanged();
        partial void OnETypeChanging(string value);
        partial void OnETypeChanged();
        partial void OnESourceChanging(string value);
        partial void OnESourceChanged();
        partial void OnETargetChanging(string value);
        partial void OnETargetChanged();
        partial void OnEURLChanging(string value);
        partial void OnEURLChanged();
        partial void OnLogDateChanging(DateTime value);
        partial void OnLogDateChanged();
        partial void OnCompanyIdChanging(string value);
        partial void OnCompanyIdChanged();
        partial void OnUserNameChanging(string value);
        partial void OnUserNameChanged();
        partial void OnModelIdChanging(Nullable<int> value);
        partial void OnModelIdChanged();
        #endregion

        public LogException()
        {
            OnCreated();
        }

        [ColumnAttribute(Storage = "_LogId", AutoSync = AutoSync.OnInsert, DbType = "BigInt NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public long LogId
        {
            get
            {
                return this._LogId;
            }
            set
            {
                if ((this._LogId != value))
                {
                    this.OnLogIdChanging(value);
                    this.SendPropertyChanging();
                    this._LogId = value;
                    this.SendPropertyChanged("LogId");
                    this.OnLogIdChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_EMessage", DbType = "VarChar(MAX) NOT NULL", CanBeNull = false)]
        public string EMessage
        {
            get
            {
                return this._EMessage;
            }
            set
            {
                if ((this._EMessage != value))
                {
                    this.OnEMessageChanging(value);
                    this.SendPropertyChanging();
                    this._EMessage = value;
                    this.SendPropertyChanged("EMessage");
                    this.OnEMessageChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_EType", DbType = "VarChar(256)")]
        public string EType
        {
            get
            {
                return this._EType;
            }
            set
            {
                if ((this._EType != value))
                {
                    this.OnETypeChanging(value);
                    this.SendPropertyChanging();
                    this._EType = value;
                    this.SendPropertyChanged("EType");
                    this.OnETypeChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_ESource", DbType = "NVarChar(256)")]
        public string ESource
        {
            get
            {
                return this._ESource;
            }
            set
            {
                if ((this._ESource != value))
                {
                    this.OnESourceChanging(value);
                    this.SendPropertyChanging();
                    this._ESource = value;
                    this.SendPropertyChanged("ESource");
                    this.OnESourceChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_ETarget", DbType = "NVarChar(256)")]
        public string ETarget
        {
            get
            {
                return this._ETarget;
            }
            set
            {
                if ((this._ETarget != value))
                {
                    this.OnETargetChanging(value);
                    this.SendPropertyChanging();
                    this._ETarget = value;
                    this.SendPropertyChanged("ETarget");
                    this.OnETargetChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_EURL", DbType = "VarChar(256)")]
        public string EURL
        {
            get
            {
                return this._EURL;
            }
            set
            {
                if ((this._EURL != value))
                {
                    this.OnEURLChanging(value);
                    this.SendPropertyChanging();
                    this._EURL = value;
                    this.SendPropertyChanged("EURL");
                    this.OnEURLChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_LogDate", DbType = "DateTime NOT NULL")]
        public DateTime LogDate
        {
            get
            {
                return this._LogDate;
            }
            set
            {
                if ((this._LogDate != value))
                {
                    this.OnLogDateChanging(value);
                    this.SendPropertyChanging();
                    this._LogDate = value;
                    this.SendPropertyChanged("LogDate");
                    this.OnLogDateChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_CompanyId", DbType = "NVarChar(6) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_UserName", DbType = "VarChar(100) NOT NULL", CanBeNull = false)]
        public string UserName
        {
            get
            {
                return this._UserName;
            }
            set
            {
                if ((this._UserName != value))
                {
                    this.OnUserNameChanging(value);
                    this.SendPropertyChanging();
                    this._UserName = value;
                    this.SendPropertyChanged("UserName");
                    this.OnUserNameChanged();
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