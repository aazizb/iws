using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace IWSProject.Models.Entities
{
    [TableAttribute(Name = "dbo.AspNetUserLogins")]
    public partial class AspNetUserLogin : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _LoginProvider;

        private string _ProviderKey;

        private string _UserId;

        private EntityRef<AspNetUser> _AspNetUser;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnLoginProviderChanging(string value);
        partial void OnLoginProviderChanged();
        partial void OnProviderKeyChanging(string value);
        partial void OnProviderKeyChanged();
        partial void OnUserIdChanging(string value);
        partial void OnUserIdChanged();
        #endregion

        public AspNetUserLogin()
        {
            this._AspNetUser = default(EntityRef<AspNetUser>);
            OnCreated();
        }

        [ColumnAttribute(Storage = "_LoginProvider", DbType = "NVarChar(128) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string LoginProvider
        {
            get
            {
                return this._LoginProvider;
            }
            set
            {
                if ((this._LoginProvider != value))
                {
                    this.OnLoginProviderChanging(value);
                    this.SendPropertyChanging();
                    this._LoginProvider = value;
                    this.SendPropertyChanged("LoginProvider");
                    this.OnLoginProviderChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_ProviderKey", DbType = "NVarChar(128) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string ProviderKey
        {
            get
            {
                return this._ProviderKey;
            }
            set
            {
                if ((this._ProviderKey != value))
                {
                    this.OnProviderKeyChanging(value);
                    this.SendPropertyChanging();
                    this._ProviderKey = value;
                    this.SendPropertyChanged("ProviderKey");
                    this.OnProviderKeyChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_UserId", DbType = "NVarChar(128) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string UserId
        {
            get
            {
                return this._UserId;
            }
            set
            {
                if ((this._UserId != value))
                {
                    if (this._AspNetUser.HasLoadedOrAssignedValue)
                    {
                        throw new ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnUserIdChanging(value);
                    this.SendPropertyChanging();
                    this._UserId = value;
                    this.SendPropertyChanged("UserId");
                    this.OnUserIdChanged();
                }
            }
        }

        [AssociationAttribute(Name = "AspNetUser_AspNetUserLogin", Storage = "_AspNetUser", ThisKey = "UserId", OtherKey = "Id", IsForeignKey = true, DeleteOnNull = true, DeleteRule = "CASCADE")]
        public AspNetUser AspNetUser
        {
            get
            {
                return this._AspNetUser.Entity;
            }
            set
            {
                AspNetUser previousValue = this._AspNetUser.Entity;
                if (((previousValue != value)
                            || (this._AspNetUser.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._AspNetUser.Entity = null;
                        previousValue.AspNetUserLogins.Remove(this);
                    }
                    this._AspNetUser.Entity = value;
                    if ((value != null))
                    {
                        value.AspNetUserLogins.Add(this);
                        this._UserId = value.Id;
                    }
                    else
                    {
                        this._UserId = default(string);
                    }
                    this.SendPropertyChanged("AspNetUser");
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