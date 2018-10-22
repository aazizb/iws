using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace IWSProject.Models.Entities
{

    [TableAttribute(Name = "dbo.BankStatement")]
    public partial class BankStatement : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _id;

        private string _Auftragskonto;

        private Nullable<DateTime> _Buchungstag;

        private Nullable<DateTime> _Valutadatum;

        private string _Buchungstext;

        private string _Verwendungszweck;

        private string _BeguenstigterZahlungspflichtiger;

        private string _Kontonummer;

        private string _BLZ;

        private Nullable<decimal> _Betrag;

        private string _Waehrung;

        private string _Info;

        private string _CompanyID;

        private string _CompanyIBAN;

        private Nullable<bool> _IsValidated;

        private Nullable<int> _ModelId;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnidChanging(int value);
        partial void OnidChanged();
        partial void OnAuftragskontoChanging(string value);
        partial void OnAuftragskontoChanged();
        partial void OnBuchungstagChanging(Nullable<DateTime> value);
        partial void OnBuchungstagChanged();
        partial void OnValutadatumChanging(Nullable<DateTime> value);
        partial void OnValutadatumChanged();
        partial void OnBuchungstextChanging(string value);
        partial void OnBuchungstextChanged();
        partial void OnVerwendungszweckChanging(string value);
        partial void OnVerwendungszweckChanged();
        partial void OnBeguenstigterZahlungspflichtigerChanging(string value);
        partial void OnBeguenstigterZahlungspflichtigerChanged();
        partial void OnKontonummerChanging(string value);
        partial void OnKontonummerChanged();
        partial void OnBLZChanging(string value);
        partial void OnBLZChanged();
        partial void OnBetragChanging(Nullable<decimal> value);
        partial void OnBetragChanged();
        partial void OnWaehrungChanging(string value);
        partial void OnWaehrungChanged();
        partial void OnInfoChanging(string value);
        partial void OnInfoChanged();
        partial void OnCompanyIDChanging(string value);
        partial void OnCompanyIDChanged();
        partial void OnCompanyIBANChanging(string value);
        partial void OnCompanyIBANChanged();
        partial void OnIsValidatedChanging(Nullable<bool> value);
        partial void OnIsValidatedChanged();
        partial void OnModelIdChanging(Nullable<int> value);
        partial void OnModelIdChanged();
        #endregion

        public BankStatement()
        {
            OnCreated();
        }

        [ColumnAttribute(Storage = "_id", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int id
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

        [ColumnAttribute(Storage = "_Auftragskonto", DbType = "NVarChar(50)")]
        public string Auftragskonto
        {
            get
            {
                return this._Auftragskonto;
            }
            set
            {
                if ((this._Auftragskonto != value))
                {
                    this.OnAuftragskontoChanging(value);
                    this.SendPropertyChanging();
                    this._Auftragskonto = value;
                    this.SendPropertyChanged("Auftragskonto");
                    this.OnAuftragskontoChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Buchungstag", DbType = "DateTime")]
        public Nullable<DateTime> Buchungstag
        {
            get
            {
                return this._Buchungstag;
            }
            set
            {
                if ((this._Buchungstag != value))
                {
                    this.OnBuchungstagChanging(value);
                    this.SendPropertyChanging();
                    this._Buchungstag = value;
                    this.SendPropertyChanged("Buchungstag");
                    this.OnBuchungstagChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Valutadatum", DbType = "DateTime")]
        public Nullable<DateTime> Valutadatum
        {
            get
            {
                return this._Valutadatum;
            }
            set
            {
                if ((this._Valutadatum != value))
                {
                    this.OnValutadatumChanging(value);
                    this.SendPropertyChanging();
                    this._Valutadatum = value;
                    this.SendPropertyChanged("Valutadatum");
                    this.OnValutadatumChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Buchungstext", DbType = "NVarChar(200)")]
        public string Buchungstext
        {
            get
            {
                return this._Buchungstext;
            }
            set
            {
                if ((this._Buchungstext != value))
                {
                    this.OnBuchungstextChanging(value);
                    this.SendPropertyChanging();
                    this._Buchungstext = value;
                    this.SendPropertyChanged("Buchungstext");
                    this.OnBuchungstextChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Verwendungszweck", DbType = "NVarChar(250)")]
        public string Verwendungszweck
        {
            get
            {
                return this._Verwendungszweck;
            }
            set
            {
                if ((this._Verwendungszweck != value))
                {
                    this.OnVerwendungszweckChanging(value);
                    this.SendPropertyChanging();
                    this._Verwendungszweck = value;
                    this.SendPropertyChanged("Verwendungszweck");
                    this.OnVerwendungszweckChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_BeguenstigterZahlungspflichtiger", DbType = "NVarChar(250)")]
        public string BeguenstigterZahlungspflichtiger
        {
            get
            {
                return this._BeguenstigterZahlungspflichtiger;
            }
            set
            {
                if ((this._BeguenstigterZahlungspflichtiger != value))
                {
                    this.OnBeguenstigterZahlungspflichtigerChanging(value);
                    this.SendPropertyChanging();
                    this._BeguenstigterZahlungspflichtiger = value;
                    this.SendPropertyChanged("BeguenstigterZahlungspflichtiger");
                    this.OnBeguenstigterZahlungspflichtigerChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Kontonummer", DbType = "NVarChar(50)")]
        public string Kontonummer
        {
            get
            {
                return this._Kontonummer;
            }
            set
            {
                if ((this._Kontonummer != value))
                {
                    this.OnKontonummerChanging(value);
                    this.SendPropertyChanging();
                    this._Kontonummer = value;
                    this.SendPropertyChanged("Kontonummer");
                    this.OnKontonummerChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_BLZ", DbType = "NVarChar(50)")]
        public string BLZ
        {
            get
            {
                return this._BLZ;
            }
            set
            {
                if ((this._BLZ != value))
                {
                    this.OnBLZChanging(value);
                    this.SendPropertyChanging();
                    this._BLZ = value;
                    this.SendPropertyChanged("BLZ");
                    this.OnBLZChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Betrag", DbType = "Money")]
        public Nullable<decimal> Betrag
        {
            get
            {
                return this._Betrag;
            }
            set
            {
                if ((this._Betrag != value))
                {
                    this.OnBetragChanging(value);
                    this.SendPropertyChanging();
                    this._Betrag = value;
                    this.SendPropertyChanged("Betrag");
                    this.OnBetragChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Waehrung", DbType = "NVarChar(200)")]
        public string Waehrung
        {
            get
            {
                return this._Waehrung;
            }
            set
            {
                if ((this._Waehrung != value))
                {
                    this.OnWaehrungChanging(value);
                    this.SendPropertyChanging();
                    this._Waehrung = value;
                    this.SendPropertyChanged("Waehrung");
                    this.OnWaehrungChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Info", DbType = "NVarChar(250)")]
        public string Info
        {
            get
            {
                return this._Info;
            }
            set
            {
                if ((this._Info != value))
                {
                    this.OnInfoChanging(value);
                    this.SendPropertyChanging();
                    this._Info = value;
                    this.SendPropertyChanged("Info");
                    this.OnInfoChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_CompanyID", DbType = "NVarChar(50)")]
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

        [ColumnAttribute(Storage = "_CompanyIBAN", DbType = "NVarChar(50)")]
        public string CompanyIBAN
        {
            get
            {
                return this._CompanyIBAN;
            }
            set
            {
                if ((this._CompanyIBAN != value))
                {
                    this.OnCompanyIBANChanging(value);
                    this.SendPropertyChanging();
                    this._CompanyIBAN = value;
                    this.SendPropertyChanged("CompanyIBAN");
                    this.OnCompanyIBANChanged();
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