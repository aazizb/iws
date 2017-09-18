using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for PurchaseOrderXS
/// </summary>
public class PurchaseOrderXS : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private DevExpress.DataAccess.Sql.SqlDataSource purchaseOrderDS;
    private DevExpress.XtraReports.Parameters.Parameter pPurchaseOrder;
    private XRLabel xrLabel24;
    private XRLabel xrLabel23;
    private XRLabel xrLabel22;
    private XRLabel xrLabel1;
    private XRLabel xrLabel2;
    private XRLabel xrLabel3;
    private XRLabel xrLabel4;
    private XRLabel xrLabel5;
    private XRLabel xrLabel7;
    private XRLabel xrLabel8;
    private XRLabel xrLabel9;
    private XRLabel xrLabel10;
    private XRLabel xrLabel11;
    private XRLabel xrLabel12;
    private XRLabel xrLabel13;
    private XRLabel xrLabel14;
    private XRLabel xrLabel15;
    private XRLabel xrLabel16;
    private XRLabel xrLabel17;
    private XRLabel xrLabel18;
    private XRLabel xrLabel19;
    private XRLabel xrLabel20;
    private XRLabel xrLabel21;
    private DetailReportBand DetailReport;
    private DetailBand Detail1;
    private GroupHeaderBand GroupHeader1;
    private CalculatedField lineNet;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell5;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell10;
    private XRLine xrLine2;
    private CalculatedField tLineNet;
    private GroupFooterBand GroupFooter2;
    private XRLabel xrLabel6;
    private XRLabel xrLabel26;
    private XRLabel xrLabel25;
    private XRLine xrLine1;
    private PageHeaderBand PageHeader;
    private XRLabel xrLabel27;
    private XRLabel xrLabel28;
    private XRPageInfo xrPageInfo1;
    private XRLabel xrLabel29;
    private XRLabel xrLabelShipDate;
    private XRLabel xrLabelInvoiceNumber;
    private XRPageInfo xrPageInfo2;
    private XRLabel xrLabel30;
    private XRLabel xrLabel31;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public PurchaseOrderXS()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //
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
        DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PurchaseOrderXS));
        DevExpress.DataAccess.Sql.SelectQuery selectQuery1 = new DevExpress.DataAccess.Sql.SelectQuery();
        DevExpress.DataAccess.Sql.Column column1 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression1 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Table table1 = new DevExpress.DataAccess.Sql.Table();
        DevExpress.DataAccess.Sql.Column column2 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression2 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Table table2 = new DevExpress.DataAccess.Sql.Table();
        DevExpress.DataAccess.Sql.Column column3 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression3 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column4 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression4 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column5 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression5 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column6 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression6 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column7 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression7 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Column column8 = new DevExpress.DataAccess.Sql.Column();
        DevExpress.DataAccess.Sql.ColumnExpression columnExpression8 = new DevExpress.DataAccess.Sql.ColumnExpression();
        DevExpress.DataAccess.Sql.Join join1 = new DevExpress.DataAccess.Sql.Join();
        DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo1 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
        DevExpress.DataAccess.Sql.MasterDetailInfo masterDetailInfo1 = new DevExpress.DataAccess.Sql.MasterDetailInfo();
        DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo2 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
        DevExpress.XtraReports.Parameters.DynamicListLookUpSettings dynamicListLookUpSettings1 = new DevExpress.XtraReports.Parameters.DynamicListLookUpSettings();
        this.purchaseOrderDS = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.pPurchaseOrder = new DevExpress.XtraReports.Parameters.Parameter();
        this.DetailReport = new DevExpress.XtraReports.UI.DetailReportBand();
        this.Detail1 = new DevExpress.XtraReports.UI.DetailBand();
        this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
        this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
        this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
        this.GroupFooter2 = new DevExpress.XtraReports.UI.GroupFooterBand();
        this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
        this.lineNet = new DevExpress.XtraReports.UI.CalculatedField();
        this.tLineNet = new DevExpress.XtraReports.UI.CalculatedField();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.xrLabel31 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
        this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabelShipDate = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabelInvoiceNumber = new DevExpress.XtraReports.UI.XRLabel();
        this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
        this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // purchaseOrderDS
        // 
        this.purchaseOrderDS.ConnectionName = "IWSConnectionString";
        this.purchaseOrderDS.Name = "purchaseOrderDS";
        customSqlQuery1.Name = "Master";
        customSqlQuery1.Sql = resources.GetString("customSqlQuery1.Sql");
        columnExpression1.ColumnName = "transid";
        table1.MetaSerializable = "30|30|125|323";
        table1.Name = "LinePurchaseOrder";
        columnExpression1.Table = table1;
        column1.Expression = columnExpression1;
        columnExpression2.ColumnName = "name";
        table2.MetaSerializable = "185|30|125|392";
        table2.Name = "Article";
        columnExpression2.Table = table2;
        column2.Expression = columnExpression2;
        columnExpression3.ColumnName = "unit";
        columnExpression3.Table = table1;
        column3.Expression = columnExpression3;
        columnExpression4.ColumnName = "price";
        columnExpression4.Table = table1;
        column4.Expression = columnExpression4;
        columnExpression5.ColumnName = "quantity";
        columnExpression5.Table = table1;
        column5.Expression = columnExpression5;
        columnExpression6.ColumnName = "Currency";
        columnExpression6.Table = table1;
        column6.Expression = columnExpression6;
        columnExpression7.ColumnName = "text";
        columnExpression7.Table = table1;
        column7.Expression = columnExpression7;
        columnExpression8.ColumnName = "duedate";
        columnExpression8.Table = table1;
        column8.Expression = columnExpression8;
        selectQuery1.Columns.Add(column1);
        selectQuery1.Columns.Add(column2);
        selectQuery1.Columns.Add(column3);
        selectQuery1.Columns.Add(column4);
        selectQuery1.Columns.Add(column5);
        selectQuery1.Columns.Add(column6);
        selectQuery1.Columns.Add(column7);
        selectQuery1.Columns.Add(column8);
        selectQuery1.MetaSerializable = "20|20|100|231";
        selectQuery1.Name = "Details";
        relationColumnInfo1.NestedKeyColumn = "id";
        relationColumnInfo1.ParentKeyColumn = "item";
        join1.KeyColumns.Add(relationColumnInfo1);
        join1.Nested = table2;
        join1.Parent = table1;
        selectQuery1.Relations.Add(join1);
        selectQuery1.Tables.Add(table1);
        selectQuery1.Tables.Add(table2);
        this.purchaseOrderDS.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1,
            selectQuery1});
        masterDetailInfo1.DetailQueryName = "Details";
        relationColumnInfo2.NestedKeyColumn = "transid";
        relationColumnInfo2.ParentKeyColumn = "PurchaseOrderId";
        masterDetailInfo1.KeyColumns.Add(relationColumnInfo2);
        masterDetailInfo1.MasterQueryName = "Master";
        this.purchaseOrderDS.Relations.AddRange(new DevExpress.DataAccess.Sql.MasterDetailInfo[] {
            masterDetailInfo1});
        this.purchaseOrderDS.ResultSchemaSerializable = resources.GetString("purchaseOrderDS.ResultSchemaSerializable");
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel24,
            this.xrLabel23,
            this.xrLabel22,
            this.xrLabel1,
            this.xrLabel2,
            this.xrLabel3,
            this.xrLabel4,
            this.xrLabel5,
            this.xrLabel7,
            this.xrLabel8,
            this.xrLabel9,
            this.xrLabel10,
            this.xrLabel11,
            this.xrLabel12,
            this.xrLabel13,
            this.xrLabel14,
            this.xrLabel15,
            this.xrLabel16,
            this.xrLabel17,
            this.xrLabel18,
            this.xrLabel19,
            this.xrLabel20,
            this.xrLabel21});
        this.Detail.Dpi = 100F;
        this.Detail.HeightF = 249.6666F;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel24
        // 
        this.xrLabel24.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.supplierEmail")});
        this.xrLabel24.Dpi = 100F;
        this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(234.6163F, 170.0001F);
        this.xrLabel24.Name = "xrLabel24";
        this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel24.SizeF = new System.Drawing.SizeF(293.6219F, 23.00001F);
        this.xrLabel24.StylePriority.UsePadding = false;
        // 
        // xrLabel23
        // 
        this.xrLabel23.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.supplierBIC")});
        this.xrLabel23.Dpi = 100F;
        this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(234.6163F, 147.0001F);
        this.xrLabel23.Name = "xrLabel23";
        this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel23.SizeF = new System.Drawing.SizeF(293.6219F, 23.00001F);
        this.xrLabel23.StylePriority.UsePadding = false;
        // 
        // xrLabel22
        // 
        this.xrLabel22.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.supplierBank")});
        this.xrLabel22.Dpi = 100F;
        this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(234.6162F, 123F);
        this.xrLabel22.Name = "xrLabel22";
        this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel22.SizeF = new System.Drawing.SizeF(293.6219F, 23.00001F);
        this.xrLabel22.StylePriority.UsePadding = false;
        // 
        // xrLabel1
        // 
        this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.companyName")});
        this.xrLabel1.Dpi = 100F;
        this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(8.499939F, 0F);
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel1.SizeF = new System.Drawing.SizeF(206.1163F, 23F);
        this.xrLabel1.StylePriority.UsePadding = false;
        this.xrLabel1.Text = "xrLabel1";
        // 
        // xrLabel2
        // 
        this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.companyStreet")});
        this.xrLabel2.Dpi = 100F;
        this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(8.499939F, 23.00001F);
        this.xrLabel2.Name = "xrLabel2";
        this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel2.SizeF = new System.Drawing.SizeF(206.1163F, 23F);
        this.xrLabel2.StylePriority.UsePadding = false;
        this.xrLabel2.Text = "xrLabel2";
        // 
        // xrLabel3
        // 
        this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.companyZip")});
        this.xrLabel3.Dpi = 100F;
        this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(8.499939F, 46.00001F);
        this.xrLabel3.Name = "xrLabel3";
        this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel3.SizeF = new System.Drawing.SizeF(90F, 23F);
        this.xrLabel3.StylePriority.UsePadding = false;
        this.xrLabel3.Text = "xrLabel3";
        // 
        // xrLabel4
        // 
        this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.customerCity")});
        this.xrLabel4.Dpi = 100F;
        this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(98.49994F, 46.00001F);
        this.xrLabel4.Name = "xrLabel4";
        this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel4.SizeF = new System.Drawing.SizeF(116.1163F, 23F);
        this.xrLabel4.StylePriority.UsePadding = false;
        this.xrLabel4.Text = "xrLabel4";
        // 
        // xrLabel5
        // 
        this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.companyState")});
        this.xrLabel5.Dpi = 100F;
        this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(8.499939F, 69.00002F);
        this.xrLabel5.Name = "xrLabel5";
        this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel5.SizeF = new System.Drawing.SizeF(206.1163F, 23F);
        this.xrLabel5.StylePriority.UsePadding = false;
        this.xrLabel5.Text = "xrLabel5";
        // 
        // xrLabel7
        // 
        this.xrLabel7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.companyCIF")});
        this.xrLabel7.Dpi = 100F;
        this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(234.6162F, 23.00001F);
        this.xrLabel7.Name = "xrLabel7";
        this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel7.SizeF = new System.Drawing.SizeF(293.6219F, 23F);
        this.xrLabel7.StylePriority.UsePadding = false;
        this.xrLabel7.Text = "xrLabel7";
        // 
        // xrLabel8
        // 
        this.xrLabel8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.companyTaxCode")});
        this.xrLabel8.Dpi = 100F;
        this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(234.6162F, 46.00001F);
        this.xrLabel8.Name = "xrLabel8";
        this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel8.SizeF = new System.Drawing.SizeF(293.6219F, 23F);
        this.xrLabel8.StylePriority.UsePadding = false;
        this.xrLabel8.Text = "xrLabel8";
        // 
        // xrLabel9
        // 
        this.xrLabel9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.companyVatCode")});
        this.xrLabel9.Dpi = 100F;
        this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(234.6162F, 69.00002F);
        this.xrLabel9.Name = "xrLabel9";
        this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel9.SizeF = new System.Drawing.SizeF(293.6219F, 23F);
        this.xrLabel9.StylePriority.UsePadding = false;
        this.xrLabel9.Text = "xrLabel9";
        // 
        // xrLabel10
        // 
        this.xrLabel10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.supplierName")});
        this.xrLabel10.Dpi = 100F;
        this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(8.499939F, 100F);
        this.xrLabel10.Name = "xrLabel10";
        this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel10.SizeF = new System.Drawing.SizeF(208.283F, 23F);
        this.xrLabel10.StylePriority.UsePadding = false;
        // 
        // xrLabel11
        // 
        this.xrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.supplierStreet")});
        this.xrLabel11.Dpi = 100F;
        this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(8.499939F, 123F);
        this.xrLabel11.Name = "xrLabel11";
        this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel11.SizeF = new System.Drawing.SizeF(208.283F, 23F);
        this.xrLabel11.StylePriority.UsePadding = false;
        // 
        // xrLabel12
        // 
        this.xrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.supplierZip")});
        this.xrLabel12.Dpi = 100F;
        this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(8.499939F, 146F);
        this.xrLabel12.Name = "xrLabel12";
        this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel12.SizeF = new System.Drawing.SizeF(90F, 23F);
        this.xrLabel12.StylePriority.UsePadding = false;
        // 
        // xrLabel13
        // 
        this.xrLabel13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.supplierCity")});
        this.xrLabel13.Dpi = 100F;
        this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(98.49994F, 146F);
        this.xrLabel13.Name = "xrLabel13";
        this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel13.SizeF = new System.Drawing.SizeF(118.283F, 23F);
        this.xrLabel13.StylePriority.UsePadding = false;
        // 
        // xrLabel14
        // 
        this.xrLabel14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.supplierState")});
        this.xrLabel14.Dpi = 100F;
        this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(8.499939F, 169.0001F);
        this.xrLabel14.Name = "xrLabel14";
        this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel14.SizeF = new System.Drawing.SizeF(208.283F, 23F);
        this.xrLabel14.StylePriority.UsePadding = false;
        // 
        // xrLabel15
        // 
        this.xrLabel15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.supplierIBAN")});
        this.xrLabel15.Dpi = 100F;
        this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(234.6162F, 100F);
        this.xrLabel15.Name = "xrLabel15";
        this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel15.SizeF = new System.Drawing.SizeF(293.6219F, 23.00001F);
        this.xrLabel15.StylePriority.UsePadding = false;
        // 
        // xrLabel16
        // 
        this.xrLabel16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.storeName")});
        this.xrLabel16.Dpi = 100F;
        this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(567.7858F, 99.99998F);
        this.xrLabel16.Name = "xrLabel16";
        this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel16.SizeF = new System.Drawing.SizeF(223.7142F, 23.00001F);
        this.xrLabel16.StylePriority.UsePadding = false;
        this.xrLabel16.Text = "xrLabel16";
        // 
        // xrLabel17
        // 
        this.xrLabel17.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.storeStreet")});
        this.xrLabel17.Dpi = 100F;
        this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(567.7858F, 123F);
        this.xrLabel17.Name = "xrLabel17";
        this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel17.SizeF = new System.Drawing.SizeF(223.7142F, 23F);
        this.xrLabel17.StylePriority.UsePadding = false;
        this.xrLabel17.Text = "xrLabel17";
        // 
        // xrLabel18
        // 
        this.xrLabel18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.storeZip")});
        this.xrLabel18.Dpi = 100F;
        this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(567.7858F, 146F);
        this.xrLabel18.Name = "xrLabel18";
        this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel18.SizeF = new System.Drawing.SizeF(88.5238F, 23F);
        this.xrLabel18.StylePriority.UsePadding = false;
        this.xrLabel18.Text = "xrLabel18";
        // 
        // xrLabel19
        // 
        this.xrLabel19.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.storeCity")});
        this.xrLabel19.Dpi = 100F;
        this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(656.3095F, 146F);
        this.xrLabel19.Name = "xrLabel19";
        this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel19.SizeF = new System.Drawing.SizeF(135.1904F, 23F);
        this.xrLabel19.StylePriority.UsePadding = false;
        this.xrLabel19.Text = "xrLabel19";
        // 
        // xrLabel20
        // 
        this.xrLabel20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.storeState")});
        this.xrLabel20.Dpi = 100F;
        this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(567.7858F, 169.0001F);
        this.xrLabel20.Name = "xrLabel20";
        this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel20.SizeF = new System.Drawing.SizeF(223.7142F, 23F);
        this.xrLabel20.StylePriority.UsePadding = false;
        this.xrLabel20.Text = "xrLabel20";
        // 
        // xrLabel21
        // 
        this.xrLabel21.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.purchaseOrderText")});
        this.xrLabel21.Dpi = 100F;
        this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(8.499939F, 199F);
        this.xrLabel21.Name = "xrLabel21";
        this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel21.SizeF = new System.Drawing.SizeF(783.0001F, 50.6666F);
        this.xrLabel21.StylePriority.UsePadding = false;
        // 
        // TopMargin
        // 
        this.TopMargin.Dpi = 100F;
        this.TopMargin.HeightF = 0F;
        this.TopMargin.Name = "TopMargin";
        this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // BottomMargin
        // 
        this.BottomMargin.Dpi = 100F;
        this.BottomMargin.HeightF = 25.83333F;
        this.BottomMargin.Name = "BottomMargin";
        this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // pPurchaseOrder
        // 
        this.pPurchaseOrder.Description = "PurchaseOrder";
        dynamicListLookUpSettings1.DataAdapter = null;
        dynamicListLookUpSettings1.DataMember = "Master";
        dynamicListLookUpSettings1.DataSource = this.purchaseOrderDS;
        dynamicListLookUpSettings1.DisplayMember = "purchaseOrderId";
        dynamicListLookUpSettings1.FilterString = null;
        dynamicListLookUpSettings1.ValueMember = "purchaseOrderId";
        this.pPurchaseOrder.LookUpSettings = dynamicListLookUpSettings1;
        this.pPurchaseOrder.Name = "pPurchaseOrder";
        this.pPurchaseOrder.Type = typeof(int);
        this.pPurchaseOrder.ValueInfo = "0";
        // 
        // DetailReport
        // 
        this.DetailReport.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail1,
            this.GroupHeader1,
            this.GroupFooter2});
        this.DetailReport.DataMember = "Master.MasterDetails";
        this.DetailReport.DataSource = this.purchaseOrderDS;
        this.DetailReport.Dpi = 100F;
        this.DetailReport.Level = 0;
        this.DetailReport.Name = "DetailReport";
        this.DetailReport.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand;
        // 
        // Detail1
        // 
        this.Detail1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
        this.Detail1.Dpi = 100F;
        this.Detail1.HeightF = 29.16672F;
        this.Detail1.Name = "Detail1";
        // 
        // xrTable1
        // 
        this.xrTable1.Dpi = 100F;
        this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(10F, 1.00001F);
        this.xrTable1.Name = "xrTable1";
        this.xrTable1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
        this.xrTable1.SizeF = new System.Drawing.SizeF(781.4998F, 25F);
        this.xrTable1.StylePriority.UseFont = false;
        this.xrTable1.StylePriority.UsePadding = false;
        // 
        // xrTableRow1
        // 
        this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell3,
            this.xrTableCell4,
            this.xrTableCell5});
        this.xrTableRow1.Dpi = 100F;
        this.xrTableRow1.Name = "xrTableRow1";
        this.xrTableRow1.Weight = 11.5D;
        // 
        // xrTableCell1
        // 
        this.xrTableCell1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.MasterDetails.name")});
        this.xrTableCell1.Dpi = 100F;
        this.xrTableCell1.Name = "xrTableCell1";
        this.xrTableCell1.Text = "xrTableCell1";
        this.xrTableCell1.Weight = 0.66840286254882808D;
        // 
        // xrTableCell2
        // 
        this.xrTableCell2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.MasterDetails.unit")});
        this.xrTableCell2.Dpi = 100F;
        this.xrTableCell2.Name = "xrTableCell2";
        this.xrTableCell2.StylePriority.UseTextAlignment = false;
        this.xrTableCell2.Text = "xrTableCell2";
        this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell2.Weight = 0.15277773539225259D;
        // 
        // xrTableCell3
        // 
        this.xrTableCell3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.MasterDetails.quantity")});
        this.xrTableCell3.Dpi = 100F;
        this.xrTableCell3.Name = "xrTableCell3";
        this.xrTableCell3.StylePriority.UseTextAlignment = false;
        this.xrTableCell3.Text = "xrTableCell3";
        this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell3.Weight = 0.17881940205891928D;
        // 
        // xrTableCell4
        // 
        this.xrTableCell4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.MasterDetails.price", "{0:n2}")});
        this.xrTableCell4.Dpi = 100F;
        this.xrTableCell4.Name = "xrTableCell4";
        this.xrTableCell4.StylePriority.UseTextAlignment = false;
        this.xrTableCell4.Text = "xrTableCell4";
        this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell4.Weight = 0.33333333333333331D;
        // 
        // xrTableCell5
        // 
        this.xrTableCell5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.MasterDetails.lineNet", "{0:n2}")});
        this.xrTableCell5.Dpi = 100F;
        this.xrTableCell5.Name = "xrTableCell5";
        this.xrTableCell5.StylePriority.UseTextAlignment = false;
        this.xrTableCell5.Text = "xrTableCell5";
        this.xrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell5.Weight = 0.33333333333333331D;
        // 
        // GroupHeader1
        // 
        this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine2,
            this.xrTable2});
        this.GroupHeader1.Dpi = 100F;
        this.GroupHeader1.HeightF = 30.5F;
        this.GroupHeader1.Name = "GroupHeader1";
        // 
        // xrLine2
        // 
        this.xrLine2.Dpi = 100F;
        this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(8.50001F, 25.33332F);
        this.xrLine2.Name = "xrLine2";
        this.xrLine2.SizeF = new System.Drawing.SizeF(783F, 5.166677F);
        // 
        // xrTable2
        // 
        this.xrTable2.Dpi = 100F;
        this.xrTable2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(6.999995F, 0F);
        this.xrTable2.Name = "xrTable2";
        this.xrTable2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
        this.xrTable2.SizeF = new System.Drawing.SizeF(784.5001F, 25F);
        this.xrTable2.StylePriority.UseFont = false;
        this.xrTable2.StylePriority.UsePadding = false;
        this.xrTable2.StylePriority.UseTextAlignment = false;
        this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrTableRow2
        // 
        this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell6,
            this.xrTableCell7,
            this.xrTableCell8,
            this.xrTableCell9,
            this.xrTableCell10});
        this.xrTableRow2.Dpi = 100F;
        this.xrTableRow2.Name = "xrTableRow2";
        this.xrTableRow2.Weight = 11.5D;
        // 
        // xrTableCell6
        // 
        this.xrTableCell6.Dpi = 100F;
        this.xrTableCell6.Name = "xrTableCell6";
        this.xrTableCell6.StylePriority.UseTextAlignment = false;
        this.xrTableCell6.Text = global::IWSProject.Content.IWSLocalResource.description;
        this.xrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell6.Weight = 0.66840286254882808D;
        // 
        // xrTableCell7
        // 
        this.xrTableCell7.Dpi = 100F;
        this.xrTableCell7.Name = "xrTableCell7";
        this.xrTableCell7.StylePriority.UseTextAlignment = false;
        this.xrTableCell7.Text = global::IWSProject.Content.IWSLocalResource.unit;
        this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell7.Weight = 0.15277773539225259D;
        // 
        // xrTableCell8
        // 
        this.xrTableCell8.Dpi = 100F;
        this.xrTableCell8.Name = "xrTableCell8";
        this.xrTableCell8.Text = global::IWSProject.Content.IWSLocalResource.quantity;
        this.xrTableCell8.Weight = 0.17881940205891928D;
        // 
        // xrTableCell9
        // 
        this.xrTableCell9.Dpi = 100F;
        this.xrTableCell9.Name = "xrTableCell9";
        this.xrTableCell9.Text = global::IWSProject.Content.IWSLocalResource.price;
        this.xrTableCell9.Weight = 0.33333333333333331D;
        // 
        // xrTableCell10
        // 
        this.xrTableCell10.Dpi = 100F;
        this.xrTableCell10.Name = "xrTableCell10";
        this.xrTableCell10.Text = global::IWSProject.Content.IWSLocalResource.net;
        this.xrTableCell10.Weight = 0.33333333333333331D;
        // 
        // GroupFooter2
        // 
        this.GroupFooter2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel6,
            this.xrLabel26,
            this.xrLabel25,
            this.xrLine1});
        this.GroupFooter2.Dpi = 100F;
        this.GroupFooter2.HeightF = 30.83333F;
        this.GroupFooter2.Name = "GroupFooter2";
        // 
        // xrLabel6
        // 
        this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.MasterDetails.tLineNet")});
        this.xrLabel6.Dpi = 100F;
        this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(635.95F, 2.500011F);
        this.xrLabel6.Name = "xrLabel6";
        this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel6.SizeF = new System.Drawing.SizeF(156.3F, 25F);
        this.xrLabel6.StylePriority.UseFont = false;
        this.xrLabel6.StylePriority.UsePadding = false;
        this.xrLabel6.StylePriority.UseTextAlignment = false;
        this.xrLabel6.Text = "xrLabel6";
        this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel26
        // 
        this.xrLabel26.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.purchaseOrderCurrency")});
        this.xrLabel26.Dpi = 100F;
        this.xrLabel26.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel26.LocationFloat = new DevExpress.Utils.PointFloat(568.5359F, 2.500011F);
        this.xrLabel26.Name = "xrLabel26";
        this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel26.SizeF = new System.Drawing.SizeF(67.414F, 25F);
        this.xrLabel26.StylePriority.UseFont = false;
        this.xrLabel26.StylePriority.UsePadding = false;
        this.xrLabel26.StylePriority.UseTextAlignment = false;
        this.xrLabel26.Text = "xrLabel26";
        this.xrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel25
        // 
        this.xrLabel25.Dpi = 100F;
        this.xrLabel25.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(395.0515F, 2.5F);
        this.xrLabel25.Name = "xrLabel25";
        this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel25.SizeF = new System.Drawing.SizeF(173.4844F, 25F);
        this.xrLabel25.StylePriority.UseFont = false;
        this.xrLabel25.StylePriority.UsePadding = false;
        this.xrLabel25.StylePriority.UseTextAlignment = false;
        this.xrLabel25.Text = global::IWSProject.Content.IWSLocalResource.Total;
        this.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLine1
        // 
        this.xrLine1.Dpi = 100F;
        this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(7.750061F, 0.4999886F);
        this.xrLine1.Name = "xrLine1";
        this.xrLine1.SizeF = new System.Drawing.SizeF(783F, 2F);
        // 
        // lineNet
        // 
        this.lineNet.DataMember = "Master.MasterDetails";
        this.lineNet.Expression = "ROUND([price]*[quantity],2)";
        this.lineNet.Name = "lineNet";
        // 
        // tLineNet
        // 
        this.tLineNet.DataMember = "Master.MasterDetails";
        this.tLineNet.Expression = "Sum([lineNet])";
        this.tLineNet.Name = "tLineNet";
        // 
        // PageHeader
        // 
        this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel31,
            this.xrLabel27,
            this.xrLabel28,
            this.xrPageInfo1,
            this.xrLabel29,
            this.xrLabelShipDate,
            this.xrLabelInvoiceNumber,
            this.xrPageInfo2,
            this.xrLabel30});
        this.PageHeader.Dpi = 100F;
        this.PageHeader.HeightF = 102F;
        this.PageHeader.Name = "PageHeader";
        // 
        // xrLabel31
        // 
        this.xrLabel31.Dpi = 100F;
        this.xrLabel31.Font = new System.Drawing.Font("Times New Roman", 28F, System.Drawing.FontStyle.Bold);
        this.xrLabel31.LocationFloat = new DevExpress.Utils.PointFloat(10F, 19.66666F);
        this.xrLabel31.Name = "xrLabel31";
        this.xrLabel31.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel31.SizeF = new System.Drawing.SizeF(431.6667F, 53.33335F);
        this.xrLabel31.StylePriority.UseFont = false;
        this.xrLabel31.Text = global::IWSProject.Content.IWSLocalResource.PurchaseOrder;
        // 
        // xrLabel27
        // 
        this.xrLabel27.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.purchaseOrderId")});
        this.xrLabel27.Dpi = 100F;
        this.xrLabel27.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(668.7857F, 4F);
        this.xrLabel27.Name = "xrLabel27";
        this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel27.SizeF = new System.Drawing.SizeF(121.857F, 23F);
        this.xrLabel27.StylePriority.UseFont = false;
        this.xrLabel27.StylePriority.UsePadding = false;
        this.xrLabel27.StylePriority.UseTextAlignment = false;
        this.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel28
        // 
        this.xrLabel28.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.purchaseOrderDate", "{0:yyyy-MM-dd}")});
        this.xrLabel28.Dpi = 100F;
        this.xrLabel28.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel28.LocationFloat = new DevExpress.Utils.PointFloat(668.7857F, 53.83336F);
        this.xrLabel28.Name = "xrLabel28";
        this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel28.SizeF = new System.Drawing.SizeF(121.857F, 22.99999F);
        this.xrLabel28.StylePriority.UseFont = false;
        this.xrLabel28.StylePriority.UsePadding = false;
        this.xrLabel28.StylePriority.UseTextAlignment = false;
        this.xrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrPageInfo1
        // 
        this.xrPageInfo1.Dpi = 100F;
        this.xrPageInfo1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrPageInfo1.Format = "{0:yyyy-MM-dd}";
        this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(668.7857F, 28.66666F);
        this.xrPageInfo1.Name = "xrPageInfo1";
        this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
        this.xrPageInfo1.SizeF = new System.Drawing.SizeF(121.857F, 23F);
        this.xrPageInfo1.StylePriority.UseFont = false;
        this.xrPageInfo1.StylePriority.UsePadding = false;
        this.xrPageInfo1.StylePriority.UseTextAlignment = false;
        this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel29
        // 
        this.xrLabel29.AutoWidth = true;
        this.xrLabel29.CanGrow = false;
        this.xrLabel29.Dpi = 100F;
        this.xrLabel29.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel29.LocationFloat = new DevExpress.Utils.PointFloat(567.7858F, 28.66666F);
        this.xrLabel29.Name = "xrLabel29";
        this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel29.SizeF = new System.Drawing.SizeF(100F, 23.99999F);
        this.xrLabel29.StylePriority.UseFont = false;
        this.xrLabel29.StylePriority.UsePadding = false;
        this.xrLabel29.StylePriority.UseTextAlignment = false;
        this.xrLabel29.Text = global::IWSProject.Content.IWSLocalResource.PurchaseOrderDate;
        this.xrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrLabel29.WordWrap = false;
        // 
        // xrLabelShipDate
        // 
        this.xrLabelShipDate.AutoWidth = true;
        this.xrLabelShipDate.Dpi = 100F;
        this.xrLabelShipDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabelShipDate.LocationFloat = new DevExpress.Utils.PointFloat(567.7858F, 53.83336F);
        this.xrLabelShipDate.Name = "xrLabelShipDate";
        this.xrLabelShipDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabelShipDate.SizeF = new System.Drawing.SizeF(100F, 23F);
        this.xrLabelShipDate.StylePriority.UseFont = false;
        this.xrLabelShipDate.StylePriority.UsePadding = false;
        this.xrLabelShipDate.StylePriority.UseTextAlignment = false;
        this.xrLabelShipDate.Text = global::IWSProject.Content.IWSLocalResource.ShipDate;
        this.xrLabelShipDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrLabelShipDate.WordWrap = false;
        // 
        // xrLabelInvoiceNumber
        // 
        this.xrLabelInvoiceNumber.AutoWidth = true;
        this.xrLabelInvoiceNumber.Dpi = 100F;
        this.xrLabelInvoiceNumber.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabelInvoiceNumber.LocationFloat = new DevExpress.Utils.PointFloat(567.7858F, 4F);
        this.xrLabelInvoiceNumber.Name = "xrLabelInvoiceNumber";
        this.xrLabelInvoiceNumber.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabelInvoiceNumber.SizeF = new System.Drawing.SizeF(100F, 24.00002F);
        this.xrLabelInvoiceNumber.StylePriority.UseFont = false;
        this.xrLabelInvoiceNumber.StylePriority.UsePadding = false;
        this.xrLabelInvoiceNumber.StylePriority.UseTextAlignment = false;
        this.xrLabelInvoiceNumber.Text = global::IWSProject.Content.IWSLocalResource.PurchaseOrder;
        this.xrLabelInvoiceNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrLabelInvoiceNumber.WordWrap = false;
        // 
        // xrPageInfo2
        // 
        this.xrPageInfo2.Dpi = 100F;
        this.xrPageInfo2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrPageInfo2.Format = "{0} / {1}";
        this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(668.7857F, 79.00001F);
        this.xrPageInfo2.Name = "xrPageInfo2";
        this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrPageInfo2.SizeF = new System.Drawing.SizeF(121.857F, 23.00002F);
        this.xrPageInfo2.StylePriority.UseFont = false;
        this.xrPageInfo2.StylePriority.UsePadding = false;
        this.xrPageInfo2.StylePriority.UseTextAlignment = false;
        this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel30
        // 
        this.xrLabel30.AutoWidth = true;
        this.xrLabel30.Dpi = 100F;
        this.xrLabel30.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel30.LocationFloat = new DevExpress.Utils.PointFloat(567.7858F, 79.00003F);
        this.xrLabel30.Name = "xrLabel30";
        this.xrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel30.SizeF = new System.Drawing.SizeF(100F, 23F);
        this.xrLabel30.StylePriority.UseFont = false;
        this.xrLabel30.StylePriority.UsePadding = false;
        this.xrLabel30.StylePriority.UseTextAlignment = false;
        this.xrLabel30.Text = global::IWSProject.Content.IWSLocalResource.page;
        this.xrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrLabel30.WordWrap = false;
        // 
        // PurchaseOrderXS
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.DetailReport,
            this.PageHeader});
        this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.lineNet,
            this.tLineNet});
        this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.purchaseOrderDS});
        this.DataMember = "Master";
        this.DataSource = this.purchaseOrderDS;
        this.FilterString = "[purchaseOrderId] = ?pPurchaseOrder";
        this.Margins = new System.Drawing.Printing.Margins(22, 28, 0, 26);
        this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.pPurchaseOrder});
        this.Version = "16.2";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
