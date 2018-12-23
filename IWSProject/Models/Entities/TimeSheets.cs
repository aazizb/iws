using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace IWSProject.Models.Entities
{

    [TableAttribute(Name = "dbo.TimeSheets")]
    public partial class TimeSheet : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _Id;

        private string _TatigkeitsNachweis;

        private string _MonatJahr;

        private string _Firma;

        private string _Mitarbeiter;

        private string _Kunde;

        private string _EBNummer;

        private string _AuftragsNummer;

        private System.Nullable<decimal> _SummeDerStunden;

        private System.Nullable<decimal> _SummeTage;

        private string _CompanyId;

        private System.Nullable<bool> _IsValidated;

        private System.Nullable<int> _ModelId;

        private EntitySet<TimeSheetLine> _TimeSheetLines;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIdChanging(int value);
        partial void OnIdChanged();
        partial void OnTatigkeitsNachweisChanging(string value);
        partial void OnTatigkeitsNachweisChanged();
        partial void OnMonatJahrChanging(string value);
        partial void OnMonatJahrChanged();
        partial void OnFirmaChanging(string value);
        partial void OnFirmaChanged();
        partial void OnMitarbeiterChanging(string value);
        partial void OnMitarbeiterChanged();
        partial void OnKundeChanging(string value);
        partial void OnKundeChanged();
        partial void OnEBNummerChanging(string value);
        partial void OnEBNummerChanged();
        partial void OnAuftragsNummerChanging(string value);
        partial void OnAuftragsNummerChanged();
        partial void OnSummeDerStundenChanging(System.Nullable<decimal> value);
        partial void OnSummeDerStundenChanged();
        partial void OnSummeTageChanging(System.Nullable<decimal> value);
        partial void OnSummeTageChanged();
        partial void OnCompanyIdChanging(string value);
        partial void OnCompanyIdChanged();
        partial void OnIsValidatedChanging(System.Nullable<bool> value);
        partial void OnIsValidatedChanged();
        partial void OnModelIdChanging(System.Nullable<int> value);
        partial void OnModelIdChanged();
        #endregion

        public TimeSheet()
        {
            this._TimeSheetLines = new EntitySet<TimeSheetLine>(new Action<TimeSheetLine>(this.attach_TimeSheetLines), new Action<TimeSheetLine>(this.detach_TimeSheetLines));
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

        [ColumnAttribute(Storage = "_TatigkeitsNachweis", DbType = "NVarChar(255)")]
        public string TatigkeitsNachweis
        {
            get
            {
                return this._TatigkeitsNachweis;
            }
            set
            {
                if ((this._TatigkeitsNachweis != value))
                {
                    this.OnTatigkeitsNachweisChanging(value);
                    this.SendPropertyChanging();
                    this._TatigkeitsNachweis = value;
                    this.SendPropertyChanged("TatigkeitsNachweis");
                    this.OnTatigkeitsNachweisChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_MonatJahr", DbType = "NVarChar(50)")]
        public string MonatJahr
        {
            get
            {
                return this._MonatJahr;
            }
            set
            {
                if ((this._MonatJahr != value))
                {
                    this.OnMonatJahrChanging(value);
                    this.SendPropertyChanging();
                    this._MonatJahr = value;
                    this.SendPropertyChanged("MonatJahr");
                    this.OnMonatJahrChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Firma", DbType = "NVarChar(50)")]
        public string Firma
        {
            get
            {
                return this._Firma;
            }
            set
            {
                if ((this._Firma != value))
                {
                    this.OnFirmaChanging(value);
                    this.SendPropertyChanging();
                    this._Firma = value;
                    this.SendPropertyChanged("Firma");
                    this.OnFirmaChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Mitarbeiter", DbType = "NChar(10)")]
        public string Mitarbeiter
        {
            get
            {
                return this._Mitarbeiter;
            }
            set
            {
                if ((this._Mitarbeiter != value))
                {
                    this.OnMitarbeiterChanging(value);
                    this.SendPropertyChanging();
                    this._Mitarbeiter = value;
                    this.SendPropertyChanged("Mitarbeiter");
                    this.OnMitarbeiterChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Kunde", DbType = "NVarChar(50)")]
        public string Kunde
        {
            get
            {
                return this._Kunde;
            }
            set
            {
                if ((this._Kunde != value))
                {
                    this.OnKundeChanging(value);
                    this.SendPropertyChanging();
                    this._Kunde = value;
                    this.SendPropertyChanged("Kunde");
                    this.OnKundeChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_EBNummer", DbType = "NChar(10)")]
        public string EBNummer
        {
            get
            {
                return this._EBNummer;
            }
            set
            {
                if ((this._EBNummer != value))
                {
                    this.OnEBNummerChanging(value);
                    this.SendPropertyChanging();
                    this._EBNummer = value;
                    this.SendPropertyChanged("EBNummer");
                    this.OnEBNummerChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_AuftragsNummer", DbType = "NVarChar(50)")]
        public string AuftragsNummer
        {
            get
            {
                return this._AuftragsNummer;
            }
            set
            {
                if ((this._AuftragsNummer != value))
                {
                    this.OnAuftragsNummerChanging(value);
                    this.SendPropertyChanging();
                    this._AuftragsNummer = value;
                    this.SendPropertyChanged("AuftragsNummer");
                    this.OnAuftragsNummerChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_SummeDerStunden", DbType = "Decimal(10,2)")]
        public System.Nullable<decimal> SummeDerStunden
        {
            get
            {
                return this._SummeDerStunden;
            }
            set
            {
                if ((this._SummeDerStunden != value))
                {
                    this.OnSummeDerStundenChanging(value);
                    this.SendPropertyChanging();
                    this._SummeDerStunden = value;
                    this.SendPropertyChanged("SummeDerStunden");
                    this.OnSummeDerStundenChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_SummeTage", DbType = "Decimal(10,2)")]
        public System.Nullable<decimal> SummeTage
        {
            get
            {
                return this._SummeTage;
            }
            set
            {
                if ((this._SummeTage != value))
                {
                    this.OnSummeTageChanging(value);
                    this.SendPropertyChanging();
                    this._SummeTage = value;
                    this.SendPropertyChanged("SummeTage");
                    this.OnSummeTageChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_CompanyId", DbType = "NChar(10) NOT NULL", CanBeNull = false)]
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
        public System.Nullable<bool> IsValidated
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
        public System.Nullable<int> ModelId
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

        [AssociationAttribute(Name = "TimeSheet_TimeSheetLine", Storage = "_TimeSheetLines", ThisKey = "Id", OtherKey = "TransId")]
        public EntitySet<TimeSheetLine> TimeSheetLines
        {
            get
            {
                return this._TimeSheetLines;
            }
            set
            {
                this._TimeSheetLines.Assign(value);
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

        private void attach_TimeSheetLines(TimeSheetLine entity)
        {
            this.SendPropertyChanging();
            entity.TimeSheet = this;
        }

        private void detach_TimeSheetLines(TimeSheetLine entity)
        {
            this.SendPropertyChanging();
            entity.TimeSheet = null;
        }
    }

}