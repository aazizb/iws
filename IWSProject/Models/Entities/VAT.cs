using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace IWSProject.Models.Entities
{
    [TableAttribute(Name = "dbo.Vat")]
    public partial class Vat : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _id;

        private string _name;

        private string _description;

        private decimal _PVat;

        private string _inputvataccountid;

        private string _outputvataccountid;

        private string _revenueaccountid;

        private string _CompanyID;

        private DateTime _Posted;

        private DateTime _Updated;

        private int _ModelId;

        private EntitySet<Article> _Articles;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnidChanging(string value);
        partial void OnidChanged();
        partial void OnnameChanging(string value);
        partial void OnnameChanged();
        partial void OndescriptionChanging(string value);
        partial void OndescriptionChanged();
        partial void OnPVatChanging(decimal value);
        partial void OnPVatChanged();
        partial void OninputvataccountidChanging(string value);
        partial void OninputvataccountidChanged();
        partial void OnoutputvataccountidChanging(string value);
        partial void OnoutputvataccountidChanged();
        partial void OnrevenueaccountidChanging(string value);
        partial void OnrevenueaccountidChanged();
        partial void OnCompanyIDChanging(string value);
        partial void OnCompanyIDChanged();
        partial void OnPostedChanging(DateTime value);
        partial void OnPostedChanged();
        partial void OnUpdatedChanging(DateTime value);
        partial void OnUpdatedChanged();
        partial void OnModelIdChanging(int value);
        partial void OnModelIdChanged();
        #endregion

        public Vat()
        {
            this._Articles = new EntitySet<Article>(new Action<Article>(this.attach_Articles), new Action<Article>(this.detach_Articles));
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

        [ColumnAttribute(Storage = "_description", DbType = "NVarChar(255)")]
        public string description
        {
            get
            {
                return this._description;
            }
            set
            {
                if ((this._description != value))
                {
                    this.OndescriptionChanging(value);
                    this.SendPropertyChanging();
                    this._description = value;
                    this.SendPropertyChanged("description");
                    this.OndescriptionChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_PVat", DbType = "Decimal(3,2) NOT NULL")]
        public decimal PVat
        {
            get
            {
                return this._PVat;
            }
            set
            {
                if ((this._PVat != value))
                {
                    this.OnPVatChanging(value);
                    this.SendPropertyChanging();
                    this._PVat = value;
                    this.SendPropertyChanged("PVat");
                    this.OnPVatChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_inputvataccountid", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
        public string inputvataccountid
        {
            get
            {
                return this._inputvataccountid;
            }
            set
            {
                if ((this._inputvataccountid != value))
                {
                    this.OninputvataccountidChanging(value);
                    this.SendPropertyChanging();
                    this._inputvataccountid = value;
                    this.SendPropertyChanged("inputvataccountid");
                    this.OninputvataccountidChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_outputvataccountid", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
        public string outputvataccountid
        {
            get
            {
                return this._outputvataccountid;
            }
            set
            {
                if ((this._outputvataccountid != value))
                {
                    this.OnoutputvataccountidChanging(value);
                    this.SendPropertyChanging();
                    this._outputvataccountid = value;
                    this.SendPropertyChanged("outputvataccountid");
                    this.OnoutputvataccountidChanged();
                }
            }
        }

        [ColumnAttribute(Storage = "_revenueaccountid", DbType = "NVarChar(255) NOT NULL", CanBeNull = false)]
        public string revenueaccountid
        {
            get
            {
                return this._revenueaccountid;
            }
            set
            {
                if ((this._revenueaccountid != value))
                {
                    this.OnrevenueaccountidChanging(value);
                    this.SendPropertyChanging();
                    this._revenueaccountid = value;
                    this.SendPropertyChanged("revenueaccountid");
                    this.OnrevenueaccountidChanged();
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

        [AssociationAttribute(Name = "Vat_Article", Storage = "_Articles", ThisKey = "id", OtherKey = "VatCode")]
        public EntitySet<Article> Articles
        {
            get
            {
                return this._Articles;
            }
            set
            {
                this._Articles.Assign(value);
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

        private void attach_Articles(Article entity)
        {
            this.SendPropertyChanging();
            entity.Vat = this;
        }

        private void detach_Articles(Article entity)
        {
            this.SendPropertyChanging();
            entity.Vat = null;
        }
    }

}