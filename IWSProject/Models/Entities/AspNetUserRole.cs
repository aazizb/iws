using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using IWSProject.Models.Entities;

namespace IWSProject.Models.Entities
{
    [TableAttribute(Name = "dbo.AspNetUserRoles")]
    public partial class AspNetUserRole : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _UserId;

        private string _RoleId;

        private EntityRef<AspNetRole> _AspNetRole;

        private EntityRef<AspNetUser> _AspNetUser;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnUserIdChanging(string value);
        partial void OnUserIdChanged();
        partial void OnRoleIdChanging(string value);
        partial void OnRoleIdChanged();
        #endregion

        public AspNetUserRole()
        {
            this._AspNetRole = default(EntityRef<AspNetRole>);
            this._AspNetUser = default(EntityRef<AspNetUser>);
            OnCreated();
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

        [ColumnAttribute(Storage = "_RoleId", DbType = "NVarChar(128) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string RoleId
        {
            get
            {
                return this._RoleId;
            }
            set
            {
                if ((this._RoleId != value))
                {
                    if (this._AspNetRole.HasLoadedOrAssignedValue)
                    {
                        throw new ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnRoleIdChanging(value);
                    this.SendPropertyChanging();
                    this._RoleId = value;
                    this.SendPropertyChanged("RoleId");
                    this.OnRoleIdChanged();
                }
            }
        }

        [AssociationAttribute(Name = "AspNetRole_AspNetUserRole", Storage = "_AspNetRole", ThisKey = "RoleId", OtherKey = "Id", IsForeignKey = true, DeleteOnNull = true, DeleteRule = "CASCADE")]
        public AspNetRole AspNetRole
        {
            get
            {
                return this._AspNetRole.Entity;
            }
            set
            {
                AspNetRole previousValue = this._AspNetRole.Entity;
                if (((previousValue != value)
                            || (this._AspNetRole.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._AspNetRole.Entity = null;
                        previousValue.AspNetUserRoles.Remove(this);
                    }
                    this._AspNetRole.Entity = value;
                    if ((value != null))
                    {
                        value.AspNetUserRoles.Add(this);
                        this._RoleId = value.Id;
                    }
                    else
                    {
                        this._RoleId = default(string);
                    }
                    this.SendPropertyChanged("AspNetRole");
                }
            }
        }

        [AssociationAttribute(Name = "AspNetUser_AspNetUserRole", Storage = "_AspNetUser", ThisKey = "UserId", OtherKey = "Id", IsForeignKey = true, DeleteOnNull = true, DeleteRule = "CASCADE")]
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
                        previousValue.AspNetUserRoles.Remove(this);
                    }
                    this._AspNetUser.Entity = value;
                    if ((value != null))
                    {
                        value.AspNetUserRoles.Add(this);
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