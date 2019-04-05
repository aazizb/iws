using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace IWSProject.Models.Entities
{
    [TableAttribute(Name = "dbo.Company")]
    public partial class Company : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _id;

        private string _name;

        private string _street;

        private string _city;

        private string _state;

        private string _zip;

        private string _bankaccountid;

        private string _purchasingclearingaccountid;

        private string _salesclearingaccountid;

        private string _paymentclearingaccountid;

        private string _settlementclearingaccountid;

        private string _taxcode;

        private string _vatcode;

        private string _Currency;

        private string _IBAN;

        private string _CIF;

        private string _BalanceSheet;

        private string _IncomesStatement;

        private string _CashAccountId;

        private DateTime _Posted;

        private DateTime _Updated;

        private string _ClassCash;

        private string _ClassBank;

        private int _ModelId;

        private string _PageHeaderText;

        private string _PageFooterText;

        private string _HeaderText;

        private string _FooterText;

        private string _LogoName;

        private string _ContentType;

        private string _Partner;

        private string _Tel;

        private string _Fax;

        private string _Email;

        private string _TimeZone;

        private EntitySet<AffectationJournal> _AffectationJournals;

        private EntitySet<MasterCompta> _MasterComptas;

        private EntitySet<MasterLogistic> _MasterLogistics;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
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
        partial void OnbankaccountidChanging(string value);
        partial void OnbankaccountidChanged();
        partial void OnpurchasingclearingaccountidChanging(string value);
        partial void OnpurchasingclearingaccountidChanged();
        partial void OnsalesclearingaccountidChanging(string value);
        partial void OnsalesclearingaccountidChanged();
        partial void OnpaymentclearingaccountidChanging(string value);
        partial void OnpaymentclearingaccountidChanged();
        partial void OnsettlementclearingaccountidChanging(string value);
        partial void OnsettlementclearingaccountidChanged();
        partial void OntaxcodeChanging(string value);
        partial void OntaxcodeChanged();
        partial void OnvatcodeChanging(string value);
        partial void OnvatcodeChanged();
        partial void OnCurrencyChanging(string value);
        partial void OnCurrencyChanged();
        partial void OnIBANChanging(string value);
        partial void OnIBANChanged();
        partial void OnCIFChanging(string value);
        partial void OnCIFChanged();
        partial void OnBalanceSheetChanging(string value);
        partial void OnBalanceSheetChanged();
        partial void OnIncomesStatementChanging(string value);
        partial void OnIncomesStatementChanged();
        partial void OnCashAccountIdChanging(string value);
        partial void OnCashAccountIdChanged();
        partial void OnPostedChanging(DateTime value);
        partial void OnPostedChanged();
        partial void OnUpdatedChanging(DateTime value);
        partial void OnUpdatedChanged();
        partial void OnClassCashChanging(string value);
        partial void OnClassCashChanged();
        partial void OnClassBankChanging(string value);
        partial void OnClassBankChanged();
        partial void OnModelIdChanging(int value);
        partial void OnModelIdChanged();
        partial void OnPageHeaderTextChanging(string value);
        partial void OnPageHeaderTextChanged();
        partial void OnPageFooterTextChanging(string value);
        partial void OnPageFooterTextChanged();
        partial void OnHeaderTextChanging(string value);
        partial void OnHeaderTextChanged();
        partial void OnFooterTextChanging(string value);
        partial void OnFooterTextChanged();
        partial void OnLogoNameChanging(string value);
        partial void OnLogoNameChanged();
        partial void OnContentTypeChanging(string value);
        partial void OnContentTypeChanged();
        partial void OnPartnerChanging(string value);
        partial void OnPartnerChanged();
        partial void OnTelChanging(string value);
        partial void OnTelChanged();
        partial void OnFaxChanging(string value);
        partial void OnFaxChanged();
        partial void OnEmailChanging(string value);
        partial void OnEmailChanged();
        #endregion

        public Company()
        {
            this._AffectationJournals = new EntitySet<AffectationJournal>(new Action<AffectationJournal>(this.attach_AffectationJournals), new Action<AffectationJournal>(this.detach_AffectationJournals));
            this._MasterComptas = new EntitySet<MasterCompta>(new Action<MasterCompta>(this.attach_MasterComptas), new Action<MasterCompta>(this.detach_MasterComptas));
            this._MasterLogistics = new EntitySet<MasterLogistic>(new Action<MasterLogistic>(this.attach_MasterLogistics), new Action<MasterLogistic>(this.detach_MasterLogistics));
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

        [ColumnAttribute(Storage = "_bankaccountid", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
        public string bankaccountid
        {
            get
            {
                return this._bankaccountid;
            }
            set
            {
                if ((this._bankaccountid != value))
                {
                    this.OnbankaccountidChanging(value);
                    this.SendPropertyChanging();
                    this._bankaccountid = value;
                    this.SendPropertyChanged("bankaccountid");
                    this.OnbankaccountidChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_purchasingclearingaccountid", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
        public string purchasingclearingaccountid
        {
            get
            {
                return this._purchasingclearingaccountid;
            }
            set
            {
                if ((this._purchasingclearingaccountid != value))
                {
                    this.OnpurchasingclearingaccountidChanging(value);
                    this.SendPropertyChanging();
                    this._purchasingclearingaccountid = value;
                    this.SendPropertyChanged("purchasingclearingaccountid");
                    this.OnpurchasingclearingaccountidChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_salesclearingaccountid", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
        public string salesclearingaccountid
        {
            get
            {
                return this._salesclearingaccountid;
            }
            set
            {
                if ((this._salesclearingaccountid != value))
                {
                    this.OnsalesclearingaccountidChanging(value);
                    this.SendPropertyChanging();
                    this._salesclearingaccountid = value;
                    this.SendPropertyChanged("salesclearingaccountid");
                    this.OnsalesclearingaccountidChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_paymentclearingaccountid", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
        public string paymentclearingaccountid
        {
            get
            {
                return this._paymentclearingaccountid;
            }
            set
            {
                if ((this._paymentclearingaccountid != value))
                {
                    this.OnpaymentclearingaccountidChanging(value);
                    this.SendPropertyChanging();
                    this._paymentclearingaccountid = value;
                    this.SendPropertyChanged("paymentclearingaccountid");
                    this.OnpaymentclearingaccountidChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_settlementclearingaccountid", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
        public string settlementclearingaccountid
        {
            get
            {
                return this._settlementclearingaccountid;
            }
            set
            {
                if ((this._settlementclearingaccountid != value))
                {
                    this.OnsettlementclearingaccountidChanging(value);
                    this.SendPropertyChanging();
                    this._settlementclearingaccountid = value;
                    this.SendPropertyChanged("settlementclearingaccountid");
                    this.OnsettlementclearingaccountidChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_taxcode", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
        public string taxcode
        {
            get
            {
                return this._taxcode;
            }
            set
            {
                if ((this._taxcode != value))
                {
                    this.OntaxcodeChanging(value);
                    this.SendPropertyChanging();
                    this._taxcode = value;
                    this.SendPropertyChanged("taxcode");
                    this.OntaxcodeChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_vatcode", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
        public string vatcode
        {
            get
            {
                return this._vatcode;
            }
            set
            {
                if ((this._vatcode != value))
                {
                    this.OnvatcodeChanging(value);
                    this.SendPropertyChanging();
                    this._vatcode = value;
                    this.SendPropertyChanged("vatcode");
                    this.OnvatcodeChanged();
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

        [ColumnAttribute(Storage = "_IBAN", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_CIF", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string CIF
        {
            get
            {
                return this._CIF;
            }
            set
            {
                if ((this._CIF != value))
                {
                    this.OnCIFChanging(value);
                    this.SendPropertyChanging();
                    this._CIF = value;
                    this.SendPropertyChanged("CIF");
                    this.OnCIFChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_BalanceSheet", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string BalanceSheet
        {
            get
            {
                return this._BalanceSheet;
            }
            set
            {
                if ((this._BalanceSheet != value))
                {
                    this.OnBalanceSheetChanging(value);
                    this.SendPropertyChanging();
                    this._BalanceSheet = value;
                    this.SendPropertyChanged("BalanceSheet");
                    this.OnBalanceSheetChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_IncomesStatement", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string IncomesStatement
        {
            get
            {
                return this._IncomesStatement;
            }
            set
            {
                if ((this._IncomesStatement != value))
                {
                    this.OnIncomesStatementChanging(value);
                    this.SendPropertyChanging();
                    this._IncomesStatement = value;
                    this.SendPropertyChanged("IncomesStatement");
                    this.OnIncomesStatementChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_CashAccountId", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
        public string CashAccountId
        {
            get
            {
                return this._CashAccountId;
            }
            set
            {
                if ((this._CashAccountId != value))
                {
                    this.OnCashAccountIdChanging(value);
                    this.SendPropertyChanging();
                    this._CashAccountId = value;
                    this.SendPropertyChanged("CashAccountId");
                    this.OnCashAccountIdChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Posted", DbType = "DateTime2 NOT NULL")]
        public DateTime Posted
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
        public DateTime Updated
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

        [ColumnAttribute(Storage = "_ClassCash", DbType = "VarChar(50) NOT NULL", CanBeNull = false)]
        public string ClassCash
        {
            get
            {
                return this._ClassCash;
            }
            set
            {
                if ((this._ClassCash != value))
                {
                    this.OnClassCashChanging(value);
                    this.SendPropertyChanging();
                    this._ClassCash = value;
                    this.SendPropertyChanged("ClassCash");
                    this.OnClassCashChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_ClassBank", DbType = "VarChar(50) NOT NULL", CanBeNull = false)]
        public string ClassBank
        {
            get
            {
                return this._ClassBank;
            }
            set
            {
                if ((this._ClassBank != value))
                {
                    this.OnClassBankChanging(value);
                    this.SendPropertyChanging();
                    this._ClassBank = value;
                    this.SendPropertyChanged("ClassBank");
                    this.OnClassBankChanged();
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

        [ColumnAttribute(Storage = "_PageHeaderText", DbType = "NVarChar(350)")]
        public string PageHeaderText
        {
            get
            {
                return this._PageHeaderText;
            }
            set
            {
                if ((this._PageHeaderText != value))
                {
                    this.OnPageHeaderTextChanging(value);
                    this.SendPropertyChanging();
                    this._PageHeaderText = value;
                    this.SendPropertyChanged("PageHeaderText");
                    this.OnPageHeaderTextChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_PageFooterText", DbType = "NVarChar(350)")]
        public string PageFooterText
        {
            get
            {
                return this._PageFooterText;
            }
            set
            {
                if ((this._PageFooterText != value))
                {
                    this.OnPageFooterTextChanging(value);
                    this.SendPropertyChanging();
                    this._PageFooterText = value;
                    this.SendPropertyChanged("PageFooterText");
                    this.OnPageFooterTextChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_HeaderText", DbType = "NVarChar(350)")]
        public string HeaderText
        {
            get
            {
                return this._HeaderText;
            }
            set
            {
                if ((this._HeaderText != value))
                {
                    this.OnHeaderTextChanging(value);
                    this.SendPropertyChanging();
                    this._HeaderText = value;
                    this.SendPropertyChanged("HeaderText");
                    this.OnHeaderTextChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_FooterText", DbType = "NVarChar(350)")]
        public string FooterText
        {
            get
            {
                return this._FooterText;
            }
            set
            {
                if ((this._FooterText != value))
                {
                    this.OnFooterTextChanging(value);
                    this.SendPropertyChanging();
                    this._FooterText = value;
                    this.SendPropertyChanged("FooterText");
                    this.OnFooterTextChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_LogoName", DbType = "NVarChar(50)")]
        public string LogoName
        {
            get
            {
                return this._LogoName;
            }
            set
            {
                if ((this._LogoName != value))
                {
                    this.OnLogoNameChanging(value);
                    this.SendPropertyChanging();
                    this._LogoName = value;
                    this.SendPropertyChanged("LogoName");
                    this.OnLogoNameChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_ContentType", DbType = "NVarChar(50)")]
        public string ContentType
        {
            get
            {
                return this._ContentType;
            }
            set
            {
                if ((this._ContentType != value))
                {
                    this.OnContentTypeChanging(value);
                    this.SendPropertyChanging();
                    this._ContentType = value;
                    this.SendPropertyChanged("ContentType");
                    this.OnContentTypeChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Partner", DbType = "NVarChar(250)")]
        public string Partner
        {
            get
            {
                return this._Partner;
            }
            set
            {
                if ((this._Partner != value))
                {
                    this.OnPartnerChanging(value);
                    this.SendPropertyChanging();
                    this._Partner = value;
                    this.SendPropertyChanged("Partner");
                    this.OnPartnerChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Tel", DbType = "NVarChar(50)")]
        public string Tel
        {
            get
            {
                return this._Tel;
            }
            set
            {
                if ((this._Tel != value))
                {
                    this.OnTelChanging(value);
                    this.SendPropertyChanging();
                    this._Tel = value;
                    this.SendPropertyChanged("Tel");
                    this.OnTelChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Fax", DbType = "NVarChar(50)")]
        public string Fax
        {
            get
            {
                return this._Fax;
            }
            set
            {
                if ((this._Fax != value))
                {
                    this.OnFaxChanging(value);
                    this.SendPropertyChanging();
                    this._Fax = value;
                    this.SendPropertyChanged("Fax");
                    this.OnFaxChanged();
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
        [ColumnAttribute(Storage = "_TimeZone", DbType = "NVarChar(150)")]
        public string TimeZone
        {
            get
            {
                return this._TimeZone;
            }
            set
            {
                if ((this._TimeZone != value))
                {
                    this.OnEmailChanging(value);
                    this.SendPropertyChanging();
                    this._TimeZone = value;
                    this.SendPropertyChanged("TimeZone");
                    this.OnEmailChanged();
                }
            }
        }
        [AssociationAttribute(Name = "Company_AffectationJournal", Storage = "_AffectationJournals", ThisKey = "id", OtherKey = "CompanyID")]
        public EntitySet<AffectationJournal> AffectationJournals
        {
            get
            {
                return this._AffectationJournals;
            }
            set
            {
                this._AffectationJournals.Assign(value);
            }
        }

        [AssociationAttribute(Name = "Company_MasterCompta", Storage = "_MasterComptas", ThisKey = "id", OtherKey = "CompanyId")]
        public EntitySet<MasterCompta> MasterComptas
        {
            get
            {
                return this._MasterComptas;
            }
            set
            {
                this._MasterComptas.Assign(value);
            }
        }

        [AssociationAttribute(Name = "Company_MasterLogistic", Storage = "_MasterLogistics", ThisKey = "id", OtherKey = "CompanyId")]
        public EntitySet<MasterLogistic> MasterLogistics
        {
            get
            {
                return this._MasterLogistics;
            }
            set
            {
                this._MasterLogistics.Assign(value);
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

        private void attach_AffectationJournals(AffectationJournal entity)
        {
            this.SendPropertyChanging();
            entity.Company = this;
        }

        private void detach_AffectationJournals(AffectationJournal entity)
        {
            this.SendPropertyChanging();
            entity.Company = null;
        }

        private void attach_MasterComptas(MasterCompta entity)
        {
            this.SendPropertyChanging();
            entity.Company = this;
        }

        private void detach_MasterComptas(MasterCompta entity)
        {
            this.SendPropertyChanging();
            entity.Company = null;
        }

        private void attach_MasterLogistics(MasterLogistic entity)
        {
            this.SendPropertyChanging();
            entity.Company = this;
        }

        private void detach_MasterLogistics(MasterLogistic entity)
        {
            this.SendPropertyChanging();
            entity.Company = null;
        }
    }
}