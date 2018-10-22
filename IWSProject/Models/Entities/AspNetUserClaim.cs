using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace IWSProject.Models.Entities
{

    [TableAttribute(Name = "dbo.AspNetUserClaims")]
    public partial class AspNetUserClaim : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _Id;

        private string _UserId;

        private string _ClaimType;

        private string _ClaimValue;

        private EntityRef<AspNetUser> _AspNetUser;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnIdChanging(int value);
        partial void OnIdChanged();
        partial void OnUserIdChanging(string value);
        partial void OnUserIdChanged();
        partial void OnClaimTypeChanging(string value);
        partial void OnClaimTypeChanged();
        partial void OnClaimValueChanging(string value);
        partial void OnClaimValueChanged();
        #endregion

        public AspNetUserClaim()
        {
            this._AspNetUser = default(EntityRef<AspNetUser>);
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

        [ColumnAttribute(Storage = "_UserId", DbType = "NVarChar(128) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_ClaimType", DbType = "NVarChar(MAX)")]
        public string ClaimType
        {
            get
            {
                return this._ClaimType;
            }
            set
            {
                if ((this._ClaimType != value))
                {
                    this.OnClaimTypeChanging(value);
                    this.SendPropertyChanging();
                    this._ClaimType = value;
                    this.SendPropertyChanged("ClaimType");
                    this.OnClaimTypeChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_ClaimValue", DbType = "NVarChar(MAX)")]
        public string ClaimValue
        {
            get
            {
                return this._ClaimValue;
            }
            set
            {
                if ((this._ClaimValue != value))
                {
                    this.OnClaimValueChanging(value);
                    this.SendPropertyChanging();
                    this._ClaimValue = value;
                    this.SendPropertyChanged("ClaimValue");
                    this.OnClaimValueChanged();
                }
            }
        }

        [AssociationAttribute(Name = "AspNetUser_AspNetUserClaim", Storage = "_AspNetUser", ThisKey = "UserId", OtherKey = "Id", IsForeignKey = true, DeleteOnNull = true, DeleteRule = "CASCADE")]
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
                        previousValue.AspNetUserClaims.Remove(this);
                    }
                    this._AspNetUser.Entity = value;
                    if ((value != null))
                    {
                        value.AspNetUserClaims.Add(this);
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