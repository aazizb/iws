using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace IWSProject.Models.Entities
{
    [TableAttribute(Name = "dbo.Cash")]
    public partial class Cash : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _Id;

        private string _Account;

        private string _SYear;

        private string _SMonth;

        private Nullable<decimal> _Report;

        private string _CompanyId;

        private Nullable<bool> _IsValidated;

        private Nullable<int> _ModelId;

        private EntitySet<CashLine> _CashLines;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnIdChanging(int value);
        partial void OnIdChanged();
        partial void OnAccountChanging(string value);
        partial void OnAccountChanged();
        partial void OnSYearChanging(string value);
        partial void OnSYearChanged();
        partial void OnSMonthChanging(string value);
        partial void OnSMonthChanged();
        partial void OnReportChanging(Nullable<decimal> value);
        partial void OnReportChanged();
        partial void OnCompanyIdChanging(string value);
        partial void OnCompanyIdChanged();
        partial void OnIsValidatedChanging(Nullable<bool> value);
        partial void OnIsValidatedChanged();
        partial void OnModelIdChanging(Nullable<int> value);
        partial void OnModelIdChanged();
        #endregion

        public Cash()
        {
            this._CashLines = new EntitySet<CashLine>(new Action<CashLine>(this.attach_CashLines), new Action<CashLine>(this.detach_CashLines));
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

        [ColumnAttribute(Storage = "_Account", DbType = "NVarChar(10)")]
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

        [ColumnAttribute(Storage = "_SYear", DbType = "NChar(4) NOT NULL", CanBeNull = false)]
        public string SYear
        {
            get
            {
                return this._SYear;
            }
            set
            {
                if ((this._SYear != value))
                {
                    this.OnSYearChanging(value);
                    this.SendPropertyChanging();
                    this._SYear = value;
                    this.SendPropertyChanged("SYear");
                    this.OnSYearChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_SMonth", DbType = "NChar(20) NOT NULL", CanBeNull = false)]
        public string SMonth
        {
            get
            {
                return this._SMonth;
            }
            set
            {
                if ((this._SMonth != value))
                {
                    this.OnSMonthChanging(value);
                    this.SendPropertyChanging();
                    this._SMonth = value;
                    this.SendPropertyChanged("SMonth");
                    this.OnSMonthChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Report", DbType = "Money")]
        public Nullable<decimal> Report
        {
            get
            {
                return this._Report;
            }
            set
            {
                if ((this._Report != value))
                {
                    this.OnReportChanging(value);
                    this.SendPropertyChanging();
                    this._Report = value;
                    this.SendPropertyChanged("Report");
                    this.OnReportChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_CompanyId", DbType = "NChar(10) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_IsValidated", DbType = "Bit")]
        public Nullable<bool> IsValidated
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

        [AssociationAttribute(Name = "Cash_CashLine", Storage = "_CashLines", ThisKey = "Id", OtherKey = "TransId")]
        public EntitySet<CashLine> CashLines
        {
            get
            {
                return this._CashLines;
            }
            set
            {
                this._CashLines.Assign(value);
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

        private void attach_CashLines(CashLine entity)
        {
            this.SendPropertyChanging();
            entity.Cash = this;
        }

        private void detach_CashLines(CashLine entity)
        {
            this.SendPropertyChanging();
            entity.Cash = null;
        }
    }
}