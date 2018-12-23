using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace IWSProject.Models.Entities
{

    [TableAttribute(Name = "dbo.TimeSheetLines")]
    public partial class TimeSheetLine : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _Id;

        private int _TransId;

        private System.DateTime _Datum;

        private string _ArbeitsZeitVon;

        private string _ArbeitsZeitBis;

        private string _GerundetVon;

        private string _GerundetBis;

        private string _Pause;

        private string _Project;

        private string _TatigkeitEinsatzort;

        private string _Gerundet;

        private string _StundenNetto;

        private EntityRef<TimeSheet> _TimeSheet;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIdChanging(int value);
        partial void OnIdChanged();
        partial void OnTransIdChanging(int value);
        partial void OnTransIdChanged();
        partial void OnDatumChanging(System.DateTime value);
        partial void OnDatumChanged();
        partial void OnArbeitsZeitVonChanging(string value);
        partial void OnArbeitsZeitVonChanged();
        partial void OnArbeitsZeitBisChanging(string value);
        partial void OnArbeitsZeitBisChanged();
        partial void OnGerundetVonChanging(string value);
        partial void OnGerundetVonChanged();
        partial void OnGerundetBisChanging(string value);
        partial void OnGerundetBisChanged();
        partial void OnPauseChanging(string value);
        partial void OnPauseChanged();
        partial void OnProjectChanging(string value);
        partial void OnProjectChanged();
        partial void OnTatigkeitEinsatzortChanging(string value);
        partial void OnTatigkeitEinsatzortChanged();
        partial void OnGerundetChanging(string value);
        partial void OnGerundetChanged();
        partial void OnStundenNettoChanging(string value);
        partial void OnStundenNettoChanged();
        #endregion

        public TimeSheetLine()
        {
            this._TimeSheet = default(EntityRef<TimeSheet>);
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
                    if (this._TimeSheet.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnTransIdChanging(value);
                    this.SendPropertyChanging();
                    this._TransId = value;
                    this.SendPropertyChanged("TransId");
                    this.OnTransIdChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Datum", DbType = "Date NOT NULL")]
        public System.DateTime Datum
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

        [ColumnAttribute(Storage = "_ArbeitsZeitVon", DbType = "NVarChar(5)")]
        public string ArbeitsZeitVon
        {
            get
            {
                return this._ArbeitsZeitVon;
            }
            set
            {
                if ((this._ArbeitsZeitVon != value))
                {
                    this.OnArbeitsZeitVonChanging(value);
                    this.SendPropertyChanging();
                    this._ArbeitsZeitVon = value;
                    this.SendPropertyChanged("ArbeitsZeitVon");
                    this.OnArbeitsZeitVonChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_ArbeitsZeitBis", DbType = "NVarChar(5)")]
        public string ArbeitsZeitBis
        {
            get
            {
                return this._ArbeitsZeitBis;
            }
            set
            {
                if ((this._ArbeitsZeitBis != value))
                {
                    this.OnArbeitsZeitBisChanging(value);
                    this.SendPropertyChanging();
                    this._ArbeitsZeitBis = value;
                    this.SendPropertyChanged("ArbeitsZeitBis");
                    this.OnArbeitsZeitBisChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_GerundetVon", DbType = "NVarChar(5)")]
        public string GerundetVon
        {
            get
            {
                return this._GerundetVon;
            }
            set
            {
                if ((this._GerundetVon != value))
                {
                    this.OnGerundetVonChanging(value);
                    this.SendPropertyChanging();
                    this._GerundetVon = value;
                    this.SendPropertyChanged("GerundetVon");
                    this.OnGerundetVonChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_GerundetBis", DbType = "NVarChar(5)")]
        public string GerundetBis
        {
            get
            {
                return this._GerundetBis;
            }
            set
            {
                if ((this._GerundetBis != value))
                {
                    this.OnGerundetBisChanging(value);
                    this.SendPropertyChanging();
                    this._GerundetBis = value;
                    this.SendPropertyChanged("GerundetBis");
                    this.OnGerundetBisChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Pause", DbType = "NVarChar(5)")]
        public string Pause
        {
            get
            {
                return this._Pause;
            }
            set
            {
                if ((this._Pause != value))
                {
                    this.OnPauseChanging(value);
                    this.SendPropertyChanging();
                    this._Pause = value;
                    this.SendPropertyChanged("Pause");
                    this.OnPauseChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Project", DbType = "NVarChar(255)")]
        public string Project
        {
            get
            {
                return this._Project;
            }
            set
            {
                if ((this._Project != value))
                {
                    this.OnProjectChanging(value);
                    this.SendPropertyChanging();
                    this._Project = value;
                    this.SendPropertyChanged("Project");
                    this.OnProjectChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_TatigkeitEinsatzort", DbType = "NVarChar(255)")]
        public string TatigkeitEinsatzort
        {
            get
            {
                return this._TatigkeitEinsatzort;
            }
            set
            {
                if ((this._TatigkeitEinsatzort != value))
                {
                    this.OnTatigkeitEinsatzortChanging(value);
                    this.SendPropertyChanging();
                    this._TatigkeitEinsatzort = value;
                    this.SendPropertyChanged("TatigkeitEinsatzort");
                    this.OnTatigkeitEinsatzortChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Gerundet", DbType = "NVarChar(5)")]
        public string Gerundet
        {
            get
            {
                return this._Gerundet;
            }
            set
            {
                if ((this._Gerundet != value))
                {
                    this.OnGerundetChanging(value);
                    this.SendPropertyChanging();
                    this._Gerundet = value;
                    this.SendPropertyChanged("Gerundet");
                    this.OnGerundetChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_StundenNetto", DbType = "NVarChar(5)")]
        public string StundenNetto
        {
            get
            {
                return this._StundenNetto;
            }
            set
            {
                if ((this._StundenNetto != value))
                {
                    this.OnStundenNettoChanging(value);
                    this.SendPropertyChanging();
                    this._StundenNetto = value;
                    this.SendPropertyChanged("StundenNetto");
                    this.OnStundenNettoChanged();
                }
            }
        }

        [AssociationAttribute(Name = "TimeSheet_TimeSheetLine", Storage = "_TimeSheet", ThisKey = "TransId", OtherKey = "Id", IsForeignKey = true, DeleteOnNull = true, DeleteRule = "CASCADE")]
        public TimeSheet TimeSheet
        {
            get
            {
                return this._TimeSheet.Entity;
            }
            set
            {
                TimeSheet previousValue = this._TimeSheet.Entity;
                if (((previousValue != value)
                            || (this._TimeSheet.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._TimeSheet.Entity = null;
                        previousValue.TimeSheetLines.Remove(this);
                    }
                    this._TimeSheet.Entity = value;
                    if ((value != null))
                    {
                        value.TimeSheetLines.Add(this);
                        this._TransId = value.Id;
                    }
                    else
                    {
                        this._TransId = default(int);
                    }
                    this.SendPropertyChanged("TimeSheet");
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