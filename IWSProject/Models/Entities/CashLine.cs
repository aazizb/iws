using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace IWSProject.Models.Entities
{
    [TableAttribute(Name = "dbo.CashLine")]
    public partial class CashLine : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _Id;

        private int _TransId;

        private decimal _Einnahmen;

        private decimal _Ausgaben;

        private decimal _Bestand;

        private string _Currency;

        private string _konto;

        private Nullable<bool> _Side;

        private string _Gegenkonto;

        private string _BelegNr;

        private DateTime _Datum;

        private string _SteuerSatz;

        private string _Beschreibung;

        private string _CostCenter;

        private Nullable<int> _ModelId;

        private EntityRef<Cash> _Cash;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnIdChanging(int value);
        partial void OnIdChanged();
        partial void OnTransIdChanging(int value);
        partial void OnTransIdChanged();
        partial void OnEinnahmenChanging(decimal value);
        partial void OnEinnahmenChanged();
        partial void OnAusgabenChanging(decimal value);
        partial void OnAusgabenChanged();
        partial void OnBestandChanging(decimal value);
        partial void OnBestandChanged();
        partial void OnCurrencyChanging(string value);
        partial void OnCurrencyChanged();
        partial void OnkontoChanging(string value);
        partial void OnkontoChanged();
        partial void OnSideChanging(Nullable<bool> value);
        partial void OnSideChanged();
        partial void OnGegenkontoChanging(string value);
        partial void OnGegenkontoChanged();
        partial void OnBelegNrChanging(string value);
        partial void OnBelegNrChanged();
        partial void OnDatumChanging(DateTime value);
        partial void OnDatumChanged();
        partial void OnSteuerSatzChanging(string value);
        partial void OnSteuerSatzChanged();
        partial void OnBeschreibungChanging(string value);
        partial void OnBeschreibungChanged();
        partial void OnCostCenterChanging(string value);
        partial void OnCostCenterChanged();
        partial void OnModelIdChanging(Nullable<int> value);
        partial void OnModelIdChanged();
        #endregion

        public CashLine()
        {
            this._Cash = default(EntityRef<Cash>);
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

        [ColumnAttribute(Storage = "_TransId", DbType = "Int NOT NULL")]
        public int TransId
        {
            get
            {
                return this._TransId;
            }
            set
            {
                if ((this._TransId != value))
                {
                    if (this._Cash.HasLoadedOrAssignedValue)
                    {
                        throw new ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnTransIdChanging(value);
                    this.SendPropertyChanging();
                    this._TransId = value;
                    this.SendPropertyChanged("TransId");
                    this.OnTransIdChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Einnahmen", DbType = "Money NOT NULL")]
        public decimal Einnahmen
        {
            get
            {
                return this._Einnahmen;
            }
            set
            {
                if ((this._Einnahmen != value))
                {
                    this.OnEinnahmenChanging(value);
                    this.SendPropertyChanging();
                    this._Einnahmen = value;
                    this.SendPropertyChanged("Einnahmen");
                    this.OnEinnahmenChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Ausgaben", DbType = "Money NOT NULL")]
        public decimal Ausgaben
        {
            get
            {
                return this._Ausgaben;
            }
            set
            {
                if ((this._Ausgaben != value))
                {
                    this.OnAusgabenChanging(value);
                    this.SendPropertyChanging();
                    this._Ausgaben = value;
                    this.SendPropertyChanged("Ausgaben");
                    this.OnAusgabenChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Bestand", DbType = "Money NOT NULL")]
        public decimal Bestand
        {
            get
            {
                return this._Bestand;
            }
            set
            {
                if ((this._Bestand != value))
                {
                    this.OnBestandChanging(value);
                    this.SendPropertyChanging();
                    this._Bestand = value;
                    this.SendPropertyChanged("Bestand");
                    this.OnBestandChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Currency", DbType = "NVarChar(10)")]
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

        [ColumnAttribute(Storage = "_konto", DbType = "NVarChar(50)")]
        public string konto
        {
            get
            {
                return this._konto;
            }
            set
            {
                if ((this._konto != value))
                {
                    this.OnkontoChanging(value);
                    this.SendPropertyChanging();
                    this._konto = value;
                    this.SendPropertyChanged("konto");
                    this.OnkontoChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Side", DbType = "Bit")]
        public Nullable<bool> Side
        {
            get
            {
                return this._Side;
            }
            set
            {
                if ((this._Side != value))
                {
                    this.OnSideChanging(value);
                    this.SendPropertyChanging();
                    this._Side = value;
                    this.SendPropertyChanged("Side");
                    this.OnSideChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Gegenkonto", DbType = "NVarChar(50)")]
        public string Gegenkonto
        {
            get
            {
                return this._Gegenkonto;
            }
            set
            {
                if ((this._Gegenkonto != value))
                {
                    this.OnGegenkontoChanging(value);
                    this.SendPropertyChanging();
                    this._Gegenkonto = value;
                    this.SendPropertyChanged("Gegenkonto");
                    this.OnGegenkontoChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_BelegNr", DbType = "NVarChar(50)")]
        public string BelegNr
        {
            get
            {
                return this._BelegNr;
            }
            set
            {
                if ((this._BelegNr != value))
                {
                    this.OnBelegNrChanging(value);
                    this.SendPropertyChanging();
                    this._BelegNr = value;
                    this.SendPropertyChanged("BelegNr");
                    this.OnBelegNrChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Datum", DbType = "Date NOT NULL")]
        public DateTime Datum
        {
            get
            {
                return this._Datum;
            }
            set
            {
                if ((this._Datum != value))
                {
                    this.OnDatumChanging(value);
                    this.SendPropertyChanging();
                    this._Datum = value;
                    this.SendPropertyChanged("Datum");
                    this.OnDatumChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_SteuerSatz", DbType = "NVarChar(50)")]
        public string SteuerSatz
        {
            get
            {
                return this._SteuerSatz;
            }
            set
            {
                if ((this._SteuerSatz != value))
                {
                    this.OnSteuerSatzChanging(value);
                    this.SendPropertyChanging();
                    this._SteuerSatz = value;
                    this.SendPropertyChanged("SteuerSatz");
                    this.OnSteuerSatzChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Beschreibung", DbType = "NVarChar(256)")]
        public string Beschreibung
        {
            get
            {
                return this._Beschreibung;
            }
            set
            {
                if ((this._Beschreibung != value))
                {
                    this.OnBeschreibungChanging(value);
                    this.SendPropertyChanging();
                    this._Beschreibung = value;
                    this.SendPropertyChanged("Beschreibung");
                    this.OnBeschreibungChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_CostCenter", DbType = "NVarChar(10)")]
        public string CostCenter
        {
            get
            {
                return this._CostCenter;
            }
            set
            {
                if ((this._CostCenter != value))
                {
                    this.OnCostCenterChanging(value);
                    this.SendPropertyChanging();
                    this._CostCenter = value;
                    this.SendPropertyChanged("CostCenter");
                    this.OnCostCenterChanged();
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

        [AssociationAttribute(Name = "Cash_CashLine", Storage = "_Cash", ThisKey = "TransId", OtherKey = "Id", IsForeignKey = true, DeleteOnNull = true, DeleteRule = "CASCADE")]
        public Cash Cash
        {
            get
            {
                return this._Cash.Entity;
            }
            set
            {
                Cash previousValue = this._Cash.Entity;
                if (((previousValue != value)
                            || (this._Cash.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Cash.Entity = null;
                        previousValue.CashLines.Remove(this);
                    }
                    this._Cash.Entity = value;
                    if ((value != null))
                    {
                        value.CashLines.Add(this);
                        this._TransId = value.Id;
                    }
                    else
                    {
                        this._TransId = default(int);
                    }
                    this.SendPropertyChanged("Cash");
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