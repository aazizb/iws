using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace IWSProject.Models.Entities
{
    [TableAttribute(Name = "dbo.tempAccountAmount")]
    public partial class tempAccountAmount : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private decimal _AccountAmount;

        private string _AccountCode;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnAccountAmountChanging(decimal value);
        partial void OnAccountAmountChanged();
        partial void OnAccountCodeChanging(string value);
        partial void OnAccountCodeChanged();
        #endregion

        public tempAccountAmount()
        {
            OnCreated();
        }

        [ColumnAttribute(Storage = "_AccountAmount", DbType = "Decimal(18,2) NOT NULL", IsPrimaryKey = true)]
        public decimal AccountAmount
        {
            get
            {
                return this._AccountAmount;
            }
            set
            {
                if ((this._AccountAmount != value))
                {
                    this.OnAccountAmountChanging(value);
                    this.SendPropertyChanging();
                    this._AccountAmount = value;
                    this.SendPropertyChanged("AccountAmount");
                    this.OnAccountAmountChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_AccountCode", DbType = "NVarChar(10) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
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