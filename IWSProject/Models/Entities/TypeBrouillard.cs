using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace IWSProject.Models.Entities
{
    [TableAttribute(Name = "dbo.TypeBrouillard")]
    public partial class TypeBrouillard : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _ItemID;

        private string _UICulture;

        private string _Name;

        private Nullable<int> _ModelId;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnItemIDChanging(string value);
        partial void OnItemIDChanged();
        partial void OnUICultureChanging(string value);
        partial void OnUICultureChanged();
        partial void OnNameChanging(string value);
        partial void OnNameChanged();
        partial void OnModelIdChanging(Nullable<int> value);
        partial void OnModelIdChanged();
        #endregion

        public TypeBrouillard()
        {
            OnCreated();
        }

        [ColumnAttribute(Storage = "_ItemID", DbType = "Char(2) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string ItemID
        {
            get
            {
                return this._ItemID;
            }
            set
            {
                if ((this._ItemID != value))
                {
                    this.OnItemIDChanging(value);
                    this.SendPropertyChanging();
                    this._ItemID = value;
                    this.SendPropertyChanged("ItemID");
                    this.OnItemIDChanged();
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

        [ColumnAttribute(Storage = "_Name", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                if ((this._Name != value))
                {
                    this.OnNameChanging(value);
                    this.SendPropertyChanging();
                    this._Name = value;
                    this.SendPropertyChanged("Name");
                    this.OnNameChanged();
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