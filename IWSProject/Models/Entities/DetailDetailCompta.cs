using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace IWSProject.Models.Entities
{
    [TableAttribute(Name = "dbo.DetailDetailCompta")]
    public partial class DetailDetailCompta : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _Id;

        private int _TransId;

        private int _OID;

        private decimal _Amount;

        private int _ModelId;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnIdChanging(int value);
        partial void OnIdChanged();
        partial void OnTransIdChanging(int value);
        partial void OnTransIdChanged();
        partial void OnOIDChanging(int value);
        partial void OnOIDChanged();
        partial void OnAmountChanging(decimal value);
        partial void OnAmountChanged();
        partial void OnModelIdChanging(int value);
        partial void OnModelIdChanged();
        #endregion

        public DetailDetailCompta()
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

        [ColumnAttribute(Storage = "_OID", DbType = "Int NOT NULL")]
        public int OID
        {
            get
            {
                return this._OID;
            }
            set
            {
                if ((this._OID != value))
                {
                    this.OnOIDChanging(value);
                    this.SendPropertyChanging();
                    this._OID = value;
                    this.SendPropertyChanged("OID");
                    this.OnOIDChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Amount", DbType = "Money NOT NULL")]
        public decimal Amount
        {
            get
            {
                return this._Amount;
            }
            set
            {
                if ((this._Amount != value))
                {
                    this.OnAmountChanging(value);
                    this.SendPropertyChanging();
                    this._Amount = value;
                    this.SendPropertyChanged("Amount");
                    this.OnAmountChanged();
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

        public static explicit operator DetailDetailCompta(List<DetailDetailViewModel> v)
        {
            throw new NotImplementedException();
        }

        public static explicit operator DetailDetailCompta(DetailDetailViewModel v)
        {
            throw new NotImplementedException();
        }
    }
}