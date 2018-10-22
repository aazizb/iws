using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace IWSProject.Models.Entities
{
    [TableAttribute(Name = "dbo.AspNetUsers")]
    public partial class AspNetUser : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _Id;

        private Nullable<DateTime> _BirthDate;

        private string _FirstName;

        private string _LastName;

        private string _Company;

        private int _Gender;

        private string _Email;

        private bool _EmailConfirmed;

        private string _PasswordHash;

        private string _SecurityStamp;

        private string _PhoneNumber;

        private bool _PhoneNumberConfirmed;

        private bool _TwoFactorEnabled;

        private Nullable<DateTime> _LockoutEndDateUtc;

        private bool _LockoutEnabled;

        private int _AccessFailedCount;

        private string _UserName;

        private EntitySet<AspNetUserClaim> _AspNetUserClaims;

        private EntitySet<AspNetUserLogin> _AspNetUserLogins;

        private EntitySet<AspNetUserRole> _AspNetUserRoles;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnIdChanging(string value);
        partial void OnIdChanged();
        partial void OnBirthDateChanging(Nullable<DateTime> value);
        partial void OnBirthDateChanged();
        partial void OnFirstNameChanging(string value);
        partial void OnFirstNameChanged();
        partial void OnLastNameChanging(string value);
        partial void OnLastNameChanged();
        partial void OnCompanyChanging(string value);
        partial void OnCompanyChanged();
        partial void OnGenderChanging(int value);
        partial void OnGenderChanged();
        partial void OnEmailChanging(string value);
        partial void OnEmailChanged();
        partial void OnEmailConfirmedChanging(bool value);
        partial void OnEmailConfirmedChanged();
        partial void OnPasswordHashChanging(string value);
        partial void OnPasswordHashChanged();
        partial void OnSecurityStampChanging(string value);
        partial void OnSecurityStampChanged();
        partial void OnPhoneNumberChanging(string value);
        partial void OnPhoneNumberChanged();
        partial void OnPhoneNumberConfirmedChanging(bool value);
        partial void OnPhoneNumberConfirmedChanged();
        partial void OnTwoFactorEnabledChanging(bool value);
        partial void OnTwoFactorEnabledChanged();
        partial void OnLockoutEndDateUtcChanging(Nullable<DateTime> value);
        partial void OnLockoutEndDateUtcChanged();
        partial void OnLockoutEnabledChanging(bool value);
        partial void OnLockoutEnabledChanged();
        partial void OnAccessFailedCountChanging(int value);
        partial void OnAccessFailedCountChanged();
        partial void OnUserNameChanging(string value);
        partial void OnUserNameChanged();
        #endregion

        public AspNetUser()
        {
            this._AspNetUserClaims = new EntitySet<AspNetUserClaim>(new Action<AspNetUserClaim>(this.attach_AspNetUserClaims), new Action<AspNetUserClaim>(this.detach_AspNetUserClaims));
            this._AspNetUserLogins = new EntitySet<AspNetUserLogin>(new Action<AspNetUserLogin>(this.attach_AspNetUserLogins), new Action<AspNetUserLogin>(this.detach_AspNetUserLogins));
            this._AspNetUserRoles = new EntitySet<AspNetUserRole>(new Action<AspNetUserRole>(this.attach_AspNetUserRoles), new Action<AspNetUserRole>(this.detach_AspNetUserRoles));
            OnCreated();
        }

        [ColumnAttribute(Storage = "_Id", DbType = "NVarChar(128) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string Id
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

        [ColumnAttribute(Storage = "_BirthDate", DbType = "DateTime")]
        public Nullable<DateTime> BirthDate
        {
            get
            {
                return this._BirthDate;
            }
            set
            {
                if ((this._BirthDate != value))
                {
                    this.OnBirthDateChanging(value);
                    this.SendPropertyChanging();
                    this._BirthDate = value;
                    this.SendPropertyChanged("BirthDate");
                    this.OnBirthDateChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_FirstName", DbType = "NVarChar(MAX)")]
        public string FirstName
        {
            get
            {
                return this._FirstName;
            }
            set
            {
                if ((this._FirstName != value))
                {
                    this.OnFirstNameChanging(value);
                    this.SendPropertyChanging();
                    this._FirstName = value;
                    this.SendPropertyChanged("FirstName");
                    this.OnFirstNameChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_LastName", DbType = "NVarChar(MAX)")]
        public string LastName
        {
            get
            {
                return this._LastName;
            }
            set
            {
                if ((this._LastName != value))
                {
                    this.OnLastNameChanging(value);
                    this.SendPropertyChanging();
                    this._LastName = value;
                    this.SendPropertyChanged("LastName");
                    this.OnLastNameChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Company", DbType = "NVarChar(MAX)")]
        public string Company
        {
            get
            {
                return this._Company;
            }
            set
            {
                if ((this._Company != value))
                {
                    this.OnCompanyChanging(value);
                    this.SendPropertyChanging();
                    this._Company = value;
                    this.SendPropertyChanged("Company");
                    this.OnCompanyChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Gender", DbType = "Int NOT NULL")]
        public int Gender
        {
            get
            {
                return this._Gender;
            }
            set
            {
                if ((this._Gender != value))
                {
                    this.OnGenderChanging(value);
                    this.SendPropertyChanging();
                    this._Gender = value;
                    this.SendPropertyChanged("Gender");
                    this.OnGenderChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Email", DbType = "NVarChar(256)")]
        public string Email
        {
            get
            {
                return this._Email;
            }
            set
            {
                if ((this._Email != value))
                {
                    this.OnEmailChanging(value);
                    this.SendPropertyChanging();
                    this._Email = value;
                    this.SendPropertyChanged("Email");
                    this.OnEmailChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_EmailConfirmed", DbType = "Bit NOT NULL")]
        public bool EmailConfirmed
        {
            get
            {
                return this._EmailConfirmed;
            }
            set
            {
                if ((this._EmailConfirmed != value))
                {
                    this.OnEmailConfirmedChanging(value);
                    this.SendPropertyChanging();
                    this._EmailConfirmed = value;
                    this.SendPropertyChanged("EmailConfirmed");
                    this.OnEmailConfirmedChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_PasswordHash", DbType = "NVarChar(MAX)")]
        public string PasswordHash
        {
            get
            {
                return this._PasswordHash;
            }
            set
            {
                if ((this._PasswordHash != value))
                {
                    this.OnPasswordHashChanging(value);
                    this.SendPropertyChanging();
                    this._PasswordHash = value;
                    this.SendPropertyChanged("PasswordHash");
                    this.OnPasswordHashChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_SecurityStamp", DbType = "NVarChar(MAX)")]
        public string SecurityStamp
        {
            get
            {
                return this._SecurityStamp;
            }
            set
            {
                if ((this._SecurityStamp != value))
                {
                    this.OnSecurityStampChanging(value);
                    this.SendPropertyChanging();
                    this._SecurityStamp = value;
                    this.SendPropertyChanged("SecurityStamp");
                    this.OnSecurityStampChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_PhoneNumber", DbType = "NVarChar(MAX)")]
        public string PhoneNumber
        {
            get
            {
                return this._PhoneNumber;
            }
            set
            {
                if ((this._PhoneNumber != value))
                {
                    this.OnPhoneNumberChanging(value);
                    this.SendPropertyChanging();
                    this._PhoneNumber = value;
                    this.SendPropertyChanged("PhoneNumber");
                    this.OnPhoneNumberChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_PhoneNumberConfirmed", DbType = "Bit NOT NULL")]
        public bool PhoneNumberConfirmed
        {
            get
            {
                return this._PhoneNumberConfirmed;
            }
            set
            {
                if ((this._PhoneNumberConfirmed != value))
                {
                    this.OnPhoneNumberConfirmedChanging(value);
                    this.SendPropertyChanging();
                    this._PhoneNumberConfirmed = value;
                    this.SendPropertyChanged("PhoneNumberConfirmed");
                    this.OnPhoneNumberConfirmedChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_TwoFactorEnabled", DbType = "Bit NOT NULL")]
        public bool TwoFactorEnabled
        {
            get
            {
                return this._TwoFactorEnabled;
            }
            set
            {
                if ((this._TwoFactorEnabled != value))
                {
                    this.OnTwoFactorEnabledChanging(value);
                    this.SendPropertyChanging();
                    this._TwoFactorEnabled = value;
                    this.SendPropertyChanged("TwoFactorEnabled");
                    this.OnTwoFactorEnabledChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_LockoutEndDateUtc", DbType = "DateTime")]
        public Nullable<DateTime> LockoutEndDateUtc
        {
            get
            {
                return this._LockoutEndDateUtc;
            }
            set
            {
                if ((this._LockoutEndDateUtc != value))
                {
                    this.OnLockoutEndDateUtcChanging(value);
                    this.SendPropertyChanging();
                    this._LockoutEndDateUtc = value;
                    this.SendPropertyChanged("LockoutEndDateUtc");
                    this.OnLockoutEndDateUtcChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_LockoutEnabled", DbType = "Bit NOT NULL")]
        public bool LockoutEnabled
        {
            get
            {
                return this._LockoutEnabled;
            }
            set
            {
                if ((this._LockoutEnabled != value))
                {
                    this.OnLockoutEnabledChanging(value);
                    this.SendPropertyChanging();
                    this._LockoutEnabled = value;
                    this.SendPropertyChanged("LockoutEnabled");
                    this.OnLockoutEnabledChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_AccessFailedCount", DbType = "Int NOT NULL")]
        public int AccessFailedCount
        {
            get
            {
                return this._AccessFailedCount;
            }
            set
            {
                if ((this._AccessFailedCount != value))
                {
                    this.OnAccessFailedCountChanging(value);
                    this.SendPropertyChanging();
                    this._AccessFailedCount = value;
                    this.SendPropertyChanged("AccessFailedCount");
                    this.OnAccessFailedCountChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_UserName", DbType = "NVarChar(256) NOT NULL", CanBeNull = false)]
        public string UserName
        {
            get
            {
                return this._UserName;
            }
            set
            {
                if ((this._UserName != value))
                {
                    this.OnUserNameChanging(value);
                    this.SendPropertyChanging();
                    this._UserName = value;
                    this.SendPropertyChanged("UserName");
                    this.OnUserNameChanged();
                }
            }
        }

        [AssociationAttribute(Name = "AspNetUser_AspNetUserClaim", Storage = "_AspNetUserClaims", ThisKey = "Id", OtherKey = "UserId")]
        public EntitySet<AspNetUserClaim> AspNetUserClaims
        {
            get
            {
                return this._AspNetUserClaims;
            }
            set
            {
                this._AspNetUserClaims.Assign(value);
            }
        }

        [AssociationAttribute(Name = "AspNetUser_AspNetUserLogin", Storage = "_AspNetUserLogins", ThisKey = "Id", OtherKey = "UserId")]
        public EntitySet<AspNetUserLogin> AspNetUserLogins
        {
            get
            {
                return this._AspNetUserLogins;
            }
            set
            {
                this._AspNetUserLogins.Assign(value);
            }
        }

        [AssociationAttribute(Name = "AspNetUser_AspNetUserRole", Storage = "_AspNetUserRoles", ThisKey = "Id", OtherKey = "UserId")]
        public EntitySet<AspNetUserRole> AspNetUserRoles
        {
            get
            {
                return this._AspNetUserRoles;
            }
            set
            {
                this._AspNetUserRoles.Assign(value);
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

        private void attach_AspNetUserClaims(AspNetUserClaim entity)
        {
            this.SendPropertyChanging();
            entity.AspNetUser = this;
        }

        private void detach_AspNetUserClaims(AspNetUserClaim entity)
        {
            this.SendPropertyChanging();
            entity.AspNetUser = null;
        }

        private void attach_AspNetUserLogins(AspNetUserLogin entity)
        {
            this.SendPropertyChanging();
            entity.AspNetUser = this;
        }

        private void detach_AspNetUserLogins(AspNetUserLogin entity)
        {
            this.SendPropertyChanging();
            entity.AspNetUser = null;
        }

        private void attach_AspNetUserRoles(AspNetUserRole entity)
        {
            this.SendPropertyChanging();
            entity.AspNetUser = this;
        }

        private void detach_AspNetUserRoles(AspNetUserRole entity)
        {
            this.SendPropertyChanging();
            entity.AspNetUser = null;
        }
    }
}