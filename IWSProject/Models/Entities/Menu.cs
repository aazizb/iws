using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace IWSProject.Models.Entities
{

    [TableAttribute(Name = "dbo.Menu")]
    public partial class Menu : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private string _CompanyID;

        private string _Name;

        private string _Action;

        private string _Controller;

        private string _Roles;

        private Nullable<bool> _Disable;

        private Nullable<bool> _HasAccess;

        private Nullable<int> _Parent;

        private Nullable<int> _MenuOrder;

        private Nullable<int> _ModelId;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnCompanyIDChanging(string value);
        partial void OnCompanyIDChanged();
        partial void OnNameChanging(string value);
        partial void OnNameChanged();
        partial void OnActionChanging(string value);
        partial void OnActionChanged();
        partial void OnControllerChanging(string value);
        partial void OnControllerChanged();
        partial void OnRolesChanging(string value);
        partial void OnRolesChanged();
        partial void OnDisableChanging(Nullable<bool> value);
        partial void OnDisableChanged();
        partial void OnHasAccessChanging(Nullable<bool> value);
        partial void OnHasAccessChanged();
        partial void OnParentChanging(Nullable<int> value);
        partial void OnParentChanged();
        partial void OnMenuOrderChanging(Nullable<int> value);
        partial void OnMenuOrderChanged();
        partial void OnModelIdChanging(Nullable<int> value);
        partial void OnModelIdChanged();
        #endregion

        public Menu()
        {
            OnCreated();
        }

        [ColumnAttribute(Storage = "_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                if ((this._ID != value))
                {
                    this.OnIDChanging(value);
                    this.SendPropertyChanging();
                    this._ID = value;
                    this.SendPropertyChanged("ID");
                    this.OnIDChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_CompanyID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string CompanyID
        {
            get
            {
                return this._CompanyID;
            }
            set
            {
                if ((this._CompanyID != value))
                {
                    this.OnCompanyIDChanging(value);
                    this.SendPropertyChanging();
                    this._CompanyID = value;
                    this.SendPropertyChanged("CompanyID");
                    this.OnCompanyIDChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Name", DbType = "NVarChar(50)")]
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

        [ColumnAttribute(Storage = "_Action", DbType = "NVarChar(50)")]
        public string Action
        {
            get
            {
                return this._Action;
            }
            set
            {
                if ((this._Action != value))
                {
                    this.OnActionChanging(value);
                    this.SendPropertyChanging();
                    this._Action = value;
                    this.SendPropertyChanged("Action");
                    this.OnActionChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Controller", DbType = "NVarChar(50)")]
        public string Controller
        {
            get
            {
                return this._Controller;
            }
            set
            {
                if ((this._Controller != value))
                {
                    this.OnControllerChanging(value);
                    this.SendPropertyChanging();
                    this._Controller = value;
                    this.SendPropertyChanged("Controller");
                    this.OnControllerChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Roles", DbType = "NVarChar(150)")]
        public string Roles
        {
            get
            {
                return this._Roles;
            }
            set
            {
                if ((this._Roles != value))
                {
                    this.OnRolesChanging(value);
                    this.SendPropertyChanging();
                    this._Roles = value;
                    this.SendPropertyChanged("Roles");
                    this.OnRolesChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Disable", DbType = "Bit")]
        public Nullable<bool> Disable
        {
            get
            {
                return this._Disable;
            }
            set
            {
                if ((this._Disable != value))
                {
                    this.OnDisableChanging(value);
                    this.SendPropertyChanging();
                    this._Disable = value;
                    this.SendPropertyChanged("Disable");
                    this.OnDisableChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_HasAccess", DbType = "Bit")]
        public Nullable<bool> HasAccess
        {
            get
            {
                return this._HasAccess;
            }
            set
            {
                if ((this._HasAccess != value))
                {
                    this.OnHasAccessChanging(value);
                    this.SendPropertyChanging();
                    this._HasAccess = value;
                    this.SendPropertyChanged("HasAccess");
                    this.OnHasAccessChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Parent", DbType = "Int")]
        public Nullable<int> Parent
        {
            get
            {
                return this._Parent;
            }
            set
            {
                if ((this._Parent != value))
                {
                    this.OnParentChanging(value);
                    this.SendPropertyChanging();
                    this._Parent = value;
                    this.SendPropertyChanged("Parent");
                    this.OnParentChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_MenuOrder", DbType = "Int")]
        public Nullable<int> MenuOrder
        {
            get
            {
                return this._MenuOrder;
            }
            set
            {
                if ((this._MenuOrder != value))
                {
                    this.OnMenuOrderChanging(value);
                    this.SendPropertyChanging();
                    this._MenuOrder = value;
                    this.SendPropertyChanged("MenuOrder");
                    this.OnMenuOrderChanged();
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