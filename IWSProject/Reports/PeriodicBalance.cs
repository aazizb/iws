using DevExpress.XtraReports.UI;
//using IWSProject.Content;
using IWSProject.Models;
/// <summary>
/// Summary description for PeriodicBalance
/// </summary>
public class PeriodicBalance : DevExpress.XtraReports.UI.XtraReport
{
    private TopMarginBand topMarginBand1;
    private DetailBand detailBand1;
    private BottomMarginBand bottomMarginBand1;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell13;
    private XRTableCell xrTableCell14;
    private XRTableCell xrTableCell15;
    private XRTableCell xrTableCell16;
    private XRTableCell xrTableCell17;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource2;
    private XRLabel Credit;
    private XRLabel Debit;
    private XRLabel Periode;
    private XRLabel AccountName;
    private XRLabel AccountID;
    private XRLabel xrLabel1;
    private PageHeaderBand PageHeader;
    private DevExpress.XtraReports.Parameters.Parameter parameterAccount;
    private DevExpress.XtraReports.Parameters.Parameter paramPeriodFrom;
    private DevExpress.XtraReports.Parameters.Parameter paramPeriodTo;
    private XRControlStyle xrControlStyle1;


    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public PeriodicBalance()
    {
        InitializeComponent();

    }

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        DevExpress.DataAccess.Sql.SelectQuery selectQuery1 = new DevExpress.DataAccess.Sql.SelectQuery();
        DevExpress.DataAccess.Sql.Column column1 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression1 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Table table1 = new DevExpress.DataAccess.Sql.Table();
        DevExpress.DataAccess.Sql.Column column2 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression2 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column3 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression3 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column4 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression4 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column5 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression5 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column6 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.CustomExpression customExpression1 = new DevExpress.DataAccess.Sql.CustomExpression();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PeriodicBalance));
        DevExpress.XtraReports.Parameters.DynamicListLookUpSettings dynamicListLookUpSettings1 = new DevExpress.XtraReports.Parameters.DynamicListLookUpSettings();
        DevExpress.XtraReports.Parameters.DynamicListLookUpSettings dynamicListLookUpSettings2 = new DevExpress.XtraReports.Parameters.DynamicListLookUpSettings();
        DevExpress.XtraReports.Parameters.DynamicListLookUpSettings dynamicListLookUpSettings3 = new DevExpress.XtraReports.Parameters.DynamicListLookUpSettings();
        this.sqlDataSource2 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
        this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.Credit = new DevExpress.XtraReports.UI.XRLabel();
        this.Debit = new DevExpress.XtraReports.UI.XRLabel();
        this.Periode = new DevExpress.XtraReports.UI.XRLabel();
        this.AccountName = new DevExpress.XtraReports.UI.XRLabel();
        this.AccountID = new DevExpress.XtraReports.UI.XRLabel();
        this.detailBand1 = new DevExpress.XtraReports.UI.DetailBand();
        this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
        this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.parameterAccount = new DevExpress.XtraReports.Parameters.Parameter();
        this.paramPeriodFrom = new DevExpress.XtraReports.Parameters.Parameter();
        this.paramPeriodTo = new DevExpress.XtraReports.Parameters.Parameter();
        this.xrControlStyle1 = new DevExpress.XtraReports.UI.XRControlStyle();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // sqlDataSource2
        // 
        this.sqlDataSource2.ConnectionName = "IWSConnectionString";
        this.sqlDataSource2.Name = "sqlDataSource2";
        columnExpression1.ColumnName = "AccountId";
        table1.MetaSerializable = "30|30|125|200";
        table1.Name = "PeriodicAccountBalance";
        columnExpression1.Table = table1;
        column1.Expression = columnExpression1;
        columnExpression2.ColumnName = "Name";
        columnExpression2.Table = table1;
        column2.Expression = columnExpression2;
        columnExpression3.ColumnName = "Periode";
        columnExpression3.Table = table1;
        column3.Expression = columnExpression3;
        columnExpression4.ColumnName = "Debit";
        columnExpression4.Table = table1;
        column4.Expression = columnExpression4;

        columnExpression5.ColumnName = "Credit";
        columnExpression5.Table = table1;
        column5.Expression = columnExpression5;
        column6.Alias = "Account";
        customExpression1.Expression = "AccountId + \'-\' + Name";
        column6.Expression = customExpression1;
        selectQuery1.Columns.Add(column1);
        selectQuery1.Columns.Add(column2);
        selectQuery1.Columns.Add(column3);
        selectQuery1.Columns.Add(column4);
        selectQuery1.Columns.Add(column5);
        selectQuery1.Columns.Add(column6);
        selectQuery1.Name = "PeriodicAccountBalance";
        selectQuery1.Tables.Add(table1);
        this.sqlDataSource2.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            selectQuery1});
        this.sqlDataSource2.ResultSchemaSerializable = resources.GetString("sqlDataSource2.ResultSchemaSerializable");
        // 
        // topMarginBand1
        // 
        this.topMarginBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1});
        this.topMarginBand1.Dpi = 100F;
        this.topMarginBand1.HeightF = 75F;
        this.topMarginBand1.Name = "topMarginBand1";
        // 
        // xrLabel1
        // 
        this.xrLabel1.Dpi = 100F;
        this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(74.16666F, 18.33333F);
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel1.SizeF = new System.Drawing.SizeF(473.3333F, 33.33334F);
        this.xrLabel1.StylePriority.UseFont = false;
        this.xrLabel1.Text = global::IWSProject.Content.IWSLocalResource.PeriodicAccountBalance;
        // 
        // Credit
        // 
        this.Credit.BackColor = System.Drawing.Color.Gainsboro;
        this.Credit.Dpi = 100F;
        this.Credit.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold);
        this.Credit.LocationFloat = new DevExpress.Utils.PointFloat(532.5F, 10F);
        this.Credit.Name = "Credit";
        this.Credit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        this.Credit.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.Credit.SizeF = new System.Drawing.SizeF(117.5F, 23F);
        this.Credit.StylePriority.UseBackColor = false;
        this.Credit.StylePriority.UseFont = false;
        this.Credit.Text = global::IWSProject.Content.IWSLocalResource.credit;
        // 
        // Debit
        // 
        this.Debit.BackColor = System.Drawing.Color.Gainsboro;
        this.Debit.Dpi = 100F;
        this.Debit.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold);
        this.Debit.LocationFloat = new DevExpress.Utils.PointFloat(402.5F, 10F);
        this.Debit.Name = "Debit";
        this.Debit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        this.Debit.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.Debit.SizeF = new System.Drawing.SizeF(130F, 23F);
        this.Debit.StylePriority.UseBackColor = false;
        this.Debit.StylePriority.UseFont = false;
        this.Debit.Text = global::IWSProject.Content.IWSLocalResource.debit;
        // 
        // Periode
        // 
        this.Periode.BackColor = System.Drawing.Color.Gainsboro;
        this.Periode.Dpi = 100F;
        this.Periode.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold);
        this.Periode.LocationFloat = new DevExpress.Utils.PointFloat(314.1667F, 10F);
        this.Periode.Name = "Periode";
        this.Periode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        this.Periode.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.Periode.SizeF = new System.Drawing.SizeF(88.33334F, 23F);
        this.Periode.StylePriority.UseBackColor = false;
        this.Periode.StylePriority.UseFont = false;
        this.Periode.Text = global::IWSProject.Content.IWSLocalResource.periode;
        // 
        // AccountName
        // 
        this.AccountName.BackColor = System.Drawing.Color.Gainsboro;
        this.AccountName.Dpi = 100F;
        this.AccountName.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold);
        this.AccountName.LocationFloat = new DevExpress.Utils.PointFloat(74.16666F, 10F);
        this.AccountName.Name = "AccountName";
        this.AccountName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.AccountName.SizeF = new System.Drawing.SizeF(240F, 23F);
        this.AccountName.StylePriority.UseBackColor = false;
        this.AccountName.StylePriority.UseFont = false;
        this.AccountName.Text = global::IWSProject.Content.IWSLocalResource.name;
        // 
        // AccountID
        // 
        this.AccountID.BackColor = System.Drawing.Color.Gainsboro;
        this.AccountID.Dpi = 100F;
        this.AccountID.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold);
        this.AccountID.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10F);
        this.AccountID.Name = "AccountID";
        this.AccountID.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.AccountID.SizeF = new System.Drawing.SizeF(74.16667F, 23F);
        this.AccountID.StylePriority.UseBackColor = false;
        this.AccountID.StylePriority.UseFont = false;
        this.AccountID.Text = global::IWSProject.Content.IWSLocalResource.accountid;
        // 
        // detailBand1
        // 
        this.detailBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable3});
        this.detailBand1.Dpi = 100F;
        this.detailBand1.HeightF = 27.5F;
        this.detailBand1.Name = "detailBand1";
        // 
        // xrTable3
        // 
        this.xrTable3.Dpi = 100F;
        this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable3.Name = "xrTable3";
        this.xrTable3.OddStyleName = "xrControlStyle1";
        this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
        this.xrTable3.SizeF = new System.Drawing.SizeF(650F, 25F);
        // 
        // xrTableRow3
        // 
        this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell13,
            this.xrTableCell14,
            this.xrTableCell15,
            this.xrTableCell16,
            this.xrTableCell17});
        this.xrTableRow3.Dpi = 100F;
        this.xrTableRow3.Name = "xrTableRow3";
        this.xrTableRow3.Weight = 11.5D;
        // 
        // xrTableCell13
        // 
        this.xrTableCell13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PeriodicAccountBalance.AccountId")});
        this.xrTableCell13.Dpi = 100F;
        this.xrTableCell13.Name = "xrTableCell13";
        this.xrTableCell13.Text = "xrTableCell13";
        this.xrTableCell13.Weight = 0.38D;
        this.xrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrTableCell14
        // 
        this.xrTableCell14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PeriodicAccountBalance.Name")});
        this.xrTableCell14.Dpi = 100F;
        this.xrTableCell14.Name = "xrTableCell14";
        this.xrTableCell14.Weight = 1.23D;
        this.xrTableCell14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrTableCell15
        // 
        this.xrTableCell15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PeriodicAccountBalance.Periode")});
        this.xrTableCell15.Dpi = 100F;
        this.xrTableCell15.Name = "xrTableCell15";
        this.xrTableCell15.Weight = 0.45D;
        this.xrTableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // xrTableCell16
        // 
        this.xrTableCell16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PeriodicAccountBalance.Debit", "{0:0.00€}")});
        this.xrTableCell16.Dpi = 100F;
        this.xrTableCell16.Name = "xrTableCell16";
        this.xrTableCell16.Weight = 0.67D;
        this.xrTableCell16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // xrTableCell17
        // 
        this.xrTableCell17.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "PeriodicAccountBalance.Credit", "{0:0.00€}")});
        this.xrTableCell17.Dpi = 100F;
        this.xrTableCell17.Name = "xrTableCell17";
        this.xrTableCell17.Weight = 0.60D;
        this.xrTableCell17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // bottomMarginBand1
        // 
        this.bottomMarginBand1.Dpi = 100F;
        this.bottomMarginBand1.HeightF = 100F;
        this.bottomMarginBand1.Name = "bottomMarginBand1";
        // 
        // PageHeader
        // 
        this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.AccountName,
            this.AccountID,
            this.Periode,
            this.Debit,
            this.Credit});
        this.PageHeader.Dpi = 100F;
        this.PageHeader.HeightF = 45F;
        this.PageHeader.Name = "PageHeader";
        // 
        // parameterAccount
        // 
        this.parameterAccount.Description = global::IWSProject.Content.IWSLocalResource.account;
        dynamicListLookUpSettings1.DataAdapter = null;
        dynamicListLookUpSettings1.DataMember = "PeriodicAccountBalance";
        dynamicListLookUpSettings1.DataSource = this.sqlDataSource2;
        dynamicListLookUpSettings1.DisplayMember = "Account";
        dynamicListLookUpSettings1.ValueMember = "Account";
        this.parameterAccount.LookUpSettings = dynamicListLookUpSettings1;
        this.parameterAccount.MultiValue = true;
        this.parameterAccount.Name = "parameterAccount";
        // 
        // paramPeriodFrom
        // 
        this.paramPeriodFrom.Description = global::IWSProject.Content.IWSLocalResource.PeriodFrom;
        dynamicListLookUpSettings2.DataAdapter = null;
        dynamicListLookUpSettings2.DataMember = "PeriodicAccountBalance";
        dynamicListLookUpSettings2.DataSource = this.sqlDataSource2;
        dynamicListLookUpSettings2.DisplayMember = "Periode";
        dynamicListLookUpSettings2.FilterString = null;
        dynamicListLookUpSettings2.ValueMember = "Periode";
        this.paramPeriodFrom.LookUpSettings = dynamicListLookUpSettings2;
        this.paramPeriodFrom.Name = "paramPeriodFrom";
        //paramPeriodFrom.ValueInfo = IWSLookUp.GetPeriodMin();
        // 
        // paramPeriodTo
        // 
        this.paramPeriodTo.Description = global::IWSProject.Content.IWSLocalResource.PeriodTo;
        dynamicListLookUpSettings3.DataAdapter = null;
        dynamicListLookUpSettings3.DataMember = "PeriodicAccountBalance";
        dynamicListLookUpSettings3.DataSource = this.sqlDataSource2;
        dynamicListLookUpSettings3.DisplayMember = "Periode";
        dynamicListLookUpSettings3.FilterString = null;
        dynamicListLookUpSettings3.ValueMember = "Periode";
        this.paramPeriodTo.LookUpSettings = dynamicListLookUpSettings3;
        this.paramPeriodTo.Name = "paramPeriodTo";
        //paramPeriodTo.ValueInfo = IWSLookUp.GetPeriodMax();
        // xrControlStyle1
        // 
        this.xrControlStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
        this.xrControlStyle1.Name = "xrControlStyle1";
        // 
        // PeriodicBalance
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.topMarginBand1,
            this.detailBand1,
            this.bottomMarginBand1,
            this.PageHeader});
        this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource2});
        this.DataMember = "PeriodicAccountBalance";
        this.DataSource = this.sqlDataSource2;
        this.FilterString = "[Account] In (?parameterAccount) And [Periode] Between(?paramPeriodFrom, ?paramPe" +
                                "riodTo)";
        this.Margins = new System.Drawing.Printing.Margins(100, 100, 75, 100);
        this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.parameterAccount,
            this.paramPeriodFrom,
            this.paramPeriodTo});
        this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.xrControlStyle1});
        this.Version = "16.1";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
