using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace IWSProject.Models.Entities
{
    [TableAttribute(Name = "dbo.LookupAccountAmount")]
    public partial class LookupAccountAmount : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _AccountName;

        private string _AccountCode;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnAccountNameChanging(string value);
        partial void OnAccountNameChanged();
        partial void OnAccountCodeChanging(string value);
        partial void OnAccountCodeChanged();
        #endregion

        public LookupAccountAmount()
        {
            OnCreated();
        }

        [ColumnAttribute(Storage = "_AccountName", DbType = "NVarChar(50) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string AccountName
        {
            get
            {
                return this._AccountName;
            }
            set
            {
                if ((this._AccountName != value))
                {
                    this.OnAccountNameChanging(value);
                    this.SendPropertyChanging();
                    this._AccountName = value;
                    this.SendPropertyChanged("AccountName");
                    this.OnAccountNameChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_AccountCode", DbType = "NVarChar(10) NOT NULL", CanBeNull = false)]
        public string AccountCode
        {
            get
            {
                return this._AccountCode;
            }
            set
            {
                if ((this._AccountCode != value))
                {
                    this.OnAccountCodeChanging(value);
                    this.SendPropertyChanging();
                    this._AccountCode = value;
                    this.SendPropertyChanged("AccountCode");
                    this.OnAccountCodeChanged();
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