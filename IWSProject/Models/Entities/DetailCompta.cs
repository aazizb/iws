using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace IWSProject.Models.Entities
{
    [TableAttribute(Name = "dbo.DetailCompta")]
    public partial class DetailCompta : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _id;

        private int _transid;

        private string _account;

        private bool _side;

        private string _oaccount;

        private decimal _amount;

        private DateTime _duedate;

        private string _text;

        private string _Currency;

        private int _ModelId;

        private string _Terms;

        private bool _Balanced;

        private EntityRef<Account> _Account1;

        private EntityRef<Account> _Account2;

        private EntityRef<MasterCompta> _MasterCompta;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnidChanging(int value);
        partial void OnidChanged();
        partial void OntransidChanging(int value);
        partial void OntransidChanged();
        partial void OnaccountChanging(string value);
        partial void OnaccountChanged();
        partial void OnsideChanging(bool value);
        partial void OnsideChanged();
        partial void OnoaccountChanging(string value);
        partial void OnoaccountChanged();
        partial void OnamountChanging(decimal value);
        partial void OnamountChanged();
        partial void OnduedateChanging(DateTime value);
        partial void OnduedateChanged();
        partial void OntextChanging(string value);
        partial void OntextChanged();
        partial void OnCurrencyChanging(string value);
        partial void OnCurrencyChanged();
        partial void OnModelIdChanging(int value);
        partial void OnModelIdChanged();
        partial void OnTermsChanging(string value);
        partial void OnTermsChanged();
        partial void OnBalancedChanging(bool value);
        partial void OnBalancedChanged();
        #endregion

        public DetailCompta()
        {
            this._Account1 = default(EntityRef<Account>);
            this._Account2 = default(EntityRef<Account>);
            this._MasterCompta = default(EntityRef<MasterCompta>);
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

        [ColumnAttribute(Storage = "_transid", DbType = "Int NOT NULL")]
        public int transid
        {
            get
            {
                return this._transid;
            }
            set
            {
                if ((this._transid != value))
                {
                    if (this._MasterCompta.HasLoadedOrAssignedValue)
                    {
                        throw new ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OntransidChanging(value);
                    this.SendPropertyChanging();
                    this._transid = value;
                    this.SendPropertyChanged("transid");
                    this.OntransidChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_account", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string account
        {
            get
            {
                return this._account;
            }
            set
            {
                if ((this._account != value))
                {
                    if (this._Account1.HasLoadedOrAssignedValue)
                    {
                        throw new ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnaccountChanging(value);
                    this.SendPropertyChanging();
                    this._account = value;
                    this.SendPropertyChanged("account");
                    this.OnaccountChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_side", DbType = "Bit NOT NULL")]
        public bool side
        {
            get
            {
                return this._side;
            }
            set
            {
                if ((this._side != value))
                {
                    this.OnsideChanging(value);
                    this.SendPropertyChanging();
                    this._side = value;
                    this.SendPropertyChanged("side");
                    this.OnsideChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_oaccount", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string oaccount
        {
            get
            {
                return this._oaccount;
            }
            set
            {
                if ((this._oaccount != value))
                {
                    if (this._Account2.HasLoadedOrAssignedValue)
                    {
                        throw new ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnoaccountChanging(value);
                    this.SendPropertyChanging();
                    this._oaccount = value;
                    this.SendPropertyChanged("oaccount");
                    this.OnoaccountChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_amount", DbType = "Money NOT NULL")]
        public decimal amount
        {
            get
            {
                return this._amount;
            }
            set
            {
                if ((this._amount != value))
                {
                    this.OnamountChanging(value);
                    this.SendPropertyChanging();
                    this._amount = value;
                    this.SendPropertyChanged("amount");
                    this.OnamountChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_duedate", DbType = "DateTime2 NOT NULL")]
        public DateTime duedate
        {
            get
            {
                return this._duedate;
            }
            set
            {
                if ((this._duedate != value))
                {
                    this.OnduedateChanging(value);
                    this.SendPropertyChanging();
                    this._duedate = value;
                    this.SendPropertyChanged("duedate");
                    this.OnduedateChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_text", DbType = "NVarChar(250)")]
        public string text
        {
            get
            {
                return this._text;
            }
            set
            {
                if ((this._text != value))
                {
                    this.OntextChanging(value);
                    this.SendPropertyChanging();
                    this._text = value;
                    this.SendPropertyChanged("text");
                    this.OntextChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Currency", DbType = "NVarChar(10) NOT NULL", CanBeNull = false)]
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

        [ColumnAttribute(Storage = "_Terms", DbType = "VarChar(250)")]
        public string Terms
        {
            get
            {
                return this._Terms;
            }
            set
            {
                if ((this._Terms != value))
                {
                    this.OnTermsChanging(value);
                    this.SendPropertyChanging();
                    this._Terms = value;
                    this.SendPropertyChanged("Terms");
                    this.OnTermsChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_Balanced", DbType = "Bit NOT NULL")]
        public bool Balanced
        {
            get
            {
                return this._Balanced;
            }
            set
            {
                if ((this._Balanced != value))
                {
                    this.OnBalancedChanging(value);
                    this.SendPropertyChanging();
                    this._Balanced = value;
                    this.SendPropertyChanged("Balanced");
                    this.OnBalancedChanged();
                }
            }
        }

        [AssociationAttribute(Name = "Account_DetailCompta", Storage = "_Account1", ThisKey = "account", OtherKey = "id", IsForeignKey = true)]
        public Account Account1
        {
            get
            {
                return this._Account1.Entity;
            }
            set
            {
                Account previousValue = this._Account1.Entity;
                if (((previousValue != value)
                            || (this._Account1.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Account1.Entity = null;
                        previousValue.DetailComptas.Remove(this);
                    }
                    this._Account1.Entity = value;
                    if ((value != null))
                    {
                        value.DetailComptas.Add(this);
                        this._account = value.id;
                    }
                    else
                    {
                        this._account = default(string);
                    }
                    this.SendPropertyChanged("Account1");
                }
            }
        }

        [AssociationAttribute(Name = "Account_DetailCompta1", Storage = "_Account2", ThisKey = "oaccount", OtherKey = "id", IsForeignKey = true)]
        public Account Account2
        {
            get
            {
                return this._Account2.Entity;
            }
            set
            {
                Account previousValue = this._Account2.Entity;
                if (((previousValue != value)
                            || (this._Account2.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Account2.Entity = null;
                        previousValue.DetailComptas1.Remove(this);
                    }
                    this._Account2.Entity = value;
                    if ((value != null))
                    {
                        value.DetailComptas1.Add(this);
                        this._oaccount = value.id;
                    }
                    else
                    {
                        this._oaccount = default(string);
                    }
                    this.SendPropertyChanged("Account2");
                }
            }
        }

        [AssociationAttribute(Name = "MasterCompta_DetailCompta", Storage = "_MasterCompta", ThisKey = "transid", OtherKey = "id", IsForeignKey = true)]
        public MasterCompta MasterCompta
        {
            get
            {
                return this._MasterCompta.Entity;
            }
            set
            {
                MasterCompta previousValue = this._MasterCompta.Entity;
                if (((previousValue != value)
                            || (this._MasterCompta.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._MasterCompta.Entity = null;
                        previousValue.DetailComptas.Remove(this);
                    }
                    this._MasterCompta.Entity = value;
                    if ((value != null))
                    {
                        value.DetailComptas.Add(this);
                        this._transid = value.id;
                    }
                    else
                    {
                        this._transid = default(int);
                    }
                    this.SendPropertyChanged("MasterCompta");
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