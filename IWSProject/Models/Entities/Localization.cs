using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace IWSProject.Models.Entities
{
    [TableAttribute(Name = "dbo.Localization")]
    public partial class Localization : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _ItemName;

        private string _UICulture;

        private string _LocalName;

        private Nullable<int> _ModelId;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnItemNameChanging(string value);
        partial void OnItemNameChanged();
        partial void OnUICultureChanging(string value);
        partial void OnUICultureChanged();
        partial void OnLocalNameChanging(string value);
        partial void OnLocalNameChanged();
        partial void OnModelIdChanging(Nullable<int> value);
        partial void OnModelIdChanged();
        #endregion

        public Localization()
        {
            OnCreated();
        }

        [ColumnAttribute(Storage = "_ItemName", DbType = "NVarChar(50) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string ItemName
        {
            get
            {
                return this._ItemName;
            }
            set
            {
                if ((this._ItemName != value))
                {
                    this.OnItemNameChanging(value);
                    this.SendPropertyChanging();
                    this._ItemName = value;
                    this.SendPropertyChanged("ItemName");
                    this.OnItemNameChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_UICulture", DbType = "Char(5) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string UICulture
        {
            get
            {
                return this._UICulture;
            }
            set
            {
                if ((this._UICulture != value))
                {
                    this.OnUICultureChanging(value);
                    this.SendPropertyChanging();
                    this._UICulture = value;
                    this.SendPropertyChanged("UICulture");
                    this.OnUICultureChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_LocalName", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string LocalName
        {
            get
            {
                return this._LocalName;
            }
            set
            {
                if ((this._LocalName != value))
                {
                    this.OnLocalNameChanging(value);
                    this.SendPropertyChanging();
                    this._LocalName = value;
                    this.SendPropertyChanged("LocalName");
                    this.OnLocalNameChanged();
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