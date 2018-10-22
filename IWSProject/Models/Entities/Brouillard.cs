using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace IWSProject.Models.Entities
{
    [TableAttribute(Name = "dbo.Brouillard")]
    public partial class Brouillard : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _Id;

        private string _Date;

        private string _NumPiece;

        private string _AccountID;

        private string _OAccountID;

        private string _Owner;

        private string _Text;

        private string _Debit;

        private string _Credit;

        private string _Currency;

        private string _TypeDoc;

        private string _CompanyId;

        private Nullable<bool> _IsValidated;

        private Nullable<int> _ModelId;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnIdChanging(int value);
        partial void OnIdChanged();
        partial void OnDateChanging(string value);
        partial void OnDateChanged();
        partial void OnNumPieceChanging(string value);
        partial void OnNumPieceChanged();
        partial void OnAccountIDChanging(string value);
        partial void OnAccountIDChanged();
        partial void OnOAccountIDChanging(string value);
        partial void OnOAccountIDChanged();
        partial void OnOwnerChanging(string value);
        partial void OnOwnerChanged();
        partial void OnTextChanging(string value);
        partial void OnTextChanged();
        partial void OnDebitChanging(string value);
        partial void OnDebitChanged();
        partial void OnCreditChanging(string value);
        partial void OnCreditChanged();
        partial void OnCurrencyChanging(string value);
        partial void OnCurrencyChanged();
        partial void OnTypeDocChanging(string value);
        partial void OnTypeDocChanged();
        partial void OnCompanyIdChanging(string value);
        partial void OnCompanyIdChanged();
        partial void OnIsValidatedChanging(Nullable<bool> value);
        partial void OnIsValidatedChanged();
        partial void OnModelIdChanging(Nullable<int> value);
        partial void OnModelIdChanged();
        #endregion

        public Brouillard()
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

        [ColumnAttribute(Storage = "_Date", DbType = "NVarChar(10) NOT NULL", CanBeNull = false)]
        public string Date
        {
            get
            {
                return this._Date;
            }
            set
            {
                if ((this._Date != value))
                {
                    this.OnDateChanging(value);
                    this.SendPropertyChanging();
                    this._Date = value;
                    this.SendPropertyChanged("Date");
                    this.OnDateChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_NumPiece", DbType = "NVarChar(10) NOT NULL", CanBeNull = false)]
        public string NumPiece
        {
            get
            {
                return this._NumPiece;
            }
            set
            {
                if ((this._NumPiece != value))
                {
                    this.OnNumPieceChanging(value);
                    this.SendPropertyChanging();
                    this._NumPiece = value;
                    this.SendPropertyChanged("NumPiece");
                    this.OnNumPieceChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_AccountID", DbType = "NVarChar(10) NOT NULL", CanBeNull = false)]
        public string AccountID
        {
            get
            {
                return this._AccountID;
            }
            set
            {
                if ((this._AccountID != value))
                {
                    this.OnAccountIDChanging(value);
                    this.SendPropertyChanging();
                    this._AccountID = value;
                    this.SendPropertyChanged("AccountID");
                    this.OnAccountIDChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_OAccountID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string OAccountID
        {
            get
            {
                return this._OAccountID;
            }
            set
            {
                if ((this._OAccountID != value))
                {
                    this.OnOAccountIDChanging(value);
                    this.SendPropertyChanging();
                    this._OAccountID = value;
                    this.SendPropertyChanged("OAccountID");
                    this.OnOAccountIDChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Owner", DbType = "NVarChar(10)")]
        public string Owner
        {
            get
            {
                return this._Owner;
            }
            set
            {
                if ((this._Owner != value))
                {
                    this.OnOwnerChanging(value);
                    this.SendPropertyChanging();
                    this._Owner = value;
                    this.SendPropertyChanged("Owner");
                    this.OnOwnerChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Text", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
        public string Text
        {
            get
            {
                return this._Text;
            }
            set
            {
                if ((this._Text != value))
                {
                    this.OnTextChanging(value);
                    this.SendPropertyChanging();
                    this._Text = value;
                    this.SendPropertyChanged("Text");
                    this.OnTextChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Debit", DbType = "NVarChar(50)")]
        public string Debit
        {
            get
            {
                return this._Debit;
            }
            set
            {
                if ((this._Debit != value))
                {
                    this.OnDebitChanging(value);
                    this.SendPropertyChanging();
                    this._Debit = value;
                    this.SendPropertyChanged("Debit");
                    this.OnDebitChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Credit", DbType = "NVarChar(50)")]
        public string Credit
        {
            get
            {
                return this._Credit;
            }
            set
            {
                if ((this._Credit != value))
                {
                    this.OnCreditChanging(value);
                    this.SendPropertyChanging();
                    this._Credit = value;
                    this.SendPropertyChanged("Credit");
                    this.OnCreditChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Currency", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string Currency
        {
            get
            {
                return this._Currency;
            }
            set
            {
                if ((this._Currency != value))
                {
                    this.OnCurrencyChanging(value);
                    this.SendPropertyChanging();
                    this._Currency = value;
                    this.SendPropertyChanged("Currency");
                    this.OnCurrencyChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_TypeDoc", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string TypeDoc
        {
            get
            {
                return this._TypeDoc;
            }
            set
            {
                if ((this._TypeDoc != value))
                {
                    this.OnTypeDocChanging(value);
                    this.SendPropertyChanging();
                    this._TypeDoc = value;
                    this.SendPropertyChanged("TypeDoc");
                    this.OnTypeDocChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_CompanyId", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CompanyId
        {
            get
            {
                return this._CompanyId;
            }
            set
            {
                if ((this._CompanyId != value))
                {
                    this.OnCompanyIdChanging(value);
                    this.SendPropertyChanging();
                    this._CompanyId = value;
                    this.SendPropertyChanged("CompanyId");
                    this.OnCompanyIdChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_IsValidated", DbType = "Bit")]
        public Nullable<bool> IsValidated
        {
            get
            {
                return this._IsValidated;
            }
            set
            {
                if ((this._IsValidated != value))
                {
                    this.OnIsValidatedChanging(value);
                    this.SendPropertyChanging();
                    this._IsValidated = value;
                    this.SendPropertyChanged("IsValidated");
                    this.OnIsValidatedChanged();
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