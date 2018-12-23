using System;
using System.ComponentModel;
using System.Data.Linq.Mapping;

namespace IWSProject.Models.Entities
{
    [TableAttribute(Name = "dbo.Supplier")]
    public partial class Supplier : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _id;

        private string _name;

        private string _street;

        private string _city;

        private string _state;

        private string _zip;

        private string _Phone;

        private string _Email;

        private string _accountid;

        private string _CompanyID;

        private string _IBAN;

        private string _Bank;

        private string _BIC;

        private string _VatCode;

        private string _Charge;

        private System.DateTime _Posted;

        private System.DateTime _Updated;

        private int _ModelId;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnidChanging(string value);
        partial void OnidChanged();
        partial void OnnameChanging(string value);
        partial void OnnameChanged();
        partial void OnstreetChanging(string value);
        partial void OnstreetChanged();
        partial void OncityChanging(string value);
        partial void OncityChanged();
        partial void OnstateChanging(string value);
        partial void OnstateChanged();
        partial void OnzipChanging(string value);
        partial void OnzipChanged();
        partial void OnPhoneChanging(string value);
        partial void OnPhoneChanged();
        partial void OnEmailChanging(string value);
        partial void OnEmailChanged();
        partial void OnaccountidChanging(string value);
        partial void OnaccountidChanged();
        partial void OnCompanyIDChanging(string value);
        partial void OnCompanyIDChanged();
        partial void OnIBANChanging(string value);
        partial void OnIBANChanged();
        partial void OnBankChanging(string value);
        partial void OnBankChanged();
        partial void OnBICChanging(string value);
        partial void OnBICChanged();
        partial void OnVatCodeChanging(string value);
        partial void OnVatCodeChanged();
        partial void OnChargeChanging(string value);
        partial void OnChargeChanged();
        partial void OnPostedChanging(System.DateTime value);
        partial void OnPostedChanged();
        partial void OnUpdatedChanging(System.DateTime value);
        partial void OnUpdatedChanged();
        partial void OnModelIdChanging(int value);
        partial void OnModelIdChanged();
        #endregion

        public Supplier()
        {
            OnCreated();
        }

        [ColumnAttribute(Storage = "_id", DbType = "NVarChar(50) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    this.OnidChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("id");
                    this.OnidChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_name", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
        public string name
        {
            get
            {
                return this._name;
            }
            set
            {
                if ((this._name != value))
                {
                    this.OnnameChanging(value);
                    this.SendPropertyChanging();
                    this._name = value;
                    this.SendPropertyChanged("name");
                    this.OnnameChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_street", DbType = "NVarChar(255)")]
        public string street
        {
            get
            {
                return this._street;
            }
            set
            {
                if ((this._street != value))
                {
                    this.OnstreetChanging(value);
                    this.SendPropertyChanging();
                    this._street = value;
                    this.SendPropertyChanged("street");
                    this.OnstreetChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_city", DbType = "NVarChar(255)")]
        public string city
        {
            get
            {
                return this._city;
            }
            set
            {
                if ((this._city != value))
                {
                    this.OncityChanging(value);
                    this.SendPropertyChanging();
                    this._city = value;
                    this.SendPropertyChanged("city");
                    this.OncityChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_state", DbType = "NVarChar(255)")]
        public string state
        {
            get
            {
                return this._state;
            }
            set
            {
                if ((this._state != value))
                {
                    this.OnstateChanging(value);
                    this.SendPropertyChanging();
                    this._state = value;
                    this.SendPropertyChanged("state");
                    this.OnstateChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_zip", DbType = "NVarChar(255)")]
        public string zip
        {
            get
            {
                return this._zip;
            }
            set
            {
                if ((this._zip != value))
                {
                    this.OnzipChanging(value);
                    this.SendPropertyChanging();
                    this._zip = value;
                    this.SendPropertyChanged("zip");
                    this.OnzipChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Phone", DbType = "NVarChar(50)")]
        public string Phone
        {
            get
            {
                return this._Phone;
            }
            set
            {
                if ((this._Phone != value))
                {
                    this.OnPhoneChanging(value);
                    this.SendPropertyChanging();
                    this._Phone = value;
                    this.SendPropertyChanged("Phone");
                    this.OnPhoneChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Email", DbType = "NVarChar(50)")]
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

        [ColumnAttribute(Storage = "_accountid", DbType = "NVarChar(50)")]
        public string accountid
        {
            get
            {
                return this._accountid;
            }
            set
            {
                if ((this._accountid != value))
                {
                    this.OnaccountidChanging(value);
                    this.SendPropertyChanging();
                    this._accountid = value;
                    this.SendPropertyChanged("accountid");
                    this.OnaccountidChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_CompanyID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_IBAN", DbType = "NVarChar(50)")]
        public string IBAN
        {
            get
            {
                return this._IBAN;
            }
            set
            {
                if ((this._IBAN != value))
                {
                    this.OnIBANChanging(value);
                    this.SendPropertyChanging();
                    this._IBAN = value;
                    this.SendPropertyChanged("IBAN");
                    this.OnIBANChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Bank", DbType = "NVarChar(50)")]
        public string Bank
        {
            get
            {
                return this._Bank;
            }
            set
            {
                if ((this._Bank != value))
                {
                    this.OnBankChanging(value);
                    this.SendPropertyChanging();
                    this._Bank = value;
                    this.SendPropertyChanged("Bank");
                    this.OnBankChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_BIC", DbType = "NVarChar(50)")]
        public string BIC
        {
            get
            {
                return this._BIC;
            }
            set
            {
                if ((this._BIC != value))
                {
                    this.OnBICChanging(value);
                    this.SendPropertyChanging();
                    this._BIC = value;
                    this.SendPropertyChanged("BIC");
                    this.OnBICChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_VatCode", DbType = "NVarChar(50)")]
        public string VatCode
        {
            get
            {
                return this._VatCode;
            }
            set
            {
                if ((this._VatCode != value))
                {
                    this.OnVatCodeChanging(value);
                    this.SendPropertyChanging();
                    this._VatCode = value;
                    this.SendPropertyChanged("VatCode");
                    this.OnVatCodeChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Charge", DbType = "NVarChar(50)")]
        public string Charge
        {
            get
            {
                return this._Charge;
            }
            set
            {
                if ((this._Charge != value))
                {
                    this.OnChargeChanging(value);
                    this.SendPropertyChanging();
                    this._Charge = value;
                    this.SendPropertyChanged("Charge");
                    this.OnChargeChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Posted", DbType = "DateTime2 NOT NULL")]
        public System.DateTime Posted
        {
            get
            {
                return this._Posted;
            }
            set
            {
                if ((this._Posted != value))
                {
                    this.OnPostedChanging(value);
                    this.SendPropertyChanging();
                    this._Posted = value;
                    this.SendPropertyChanged("Posted");
                    this.OnPostedChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Updated", DbType = "DateTime2 NOT NULL")]
        public System.DateTime Updated
        {
            get
            {
                return this._Updated;
            }
            set
            {
                if ((this._Updated != value))
                {
                    this.OnUpdatedChanging(value);
                    this.SendPropertyChanging();
                    this._Updated = value;
                    this.SendPropertyChanged("Updated");
                    this.OnUpdatedChanged();
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
    }

}