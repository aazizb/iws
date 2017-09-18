using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for SalesInvoiceXS
/// </summary>
public class SalesInvoiceXS : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private DevExpress.DataAccess.Sql.SqlDataSource SalesInvoiceDS;
    private XRLabel xrLabel6;
    private XRLabel xrLabel5;
    private XRLabel xrLabel4;
    private XRLabel xrLabel3;
    private XRLabel xrLabel2;
    private XRLabel xrLabel1;
    private XRLabel xrLabel7;
    private XRLabel xrLabel20;
    private XRLabel xrLabel19;
    private XRLabel xrLabel18;
    private XRLabel xrLabel17;
    private XRLabel xrLabel16;
    private XRLabel xrLabel15;
    private XRLabel xrLabel14;
    private XRLabel xrLabel13;
    private XRLabel xrLabel12;
    private XRLabel xrLabel11;
    private XRLabel xrLabel10;
    private XRLabel xrLabel9;
    private XRLabel xrLabel8;
    private XRLabel xrLabel21;
    private DetailReportBand DetailReport;
    private DetailBand Detail1;
    private GroupHeaderBand GroupHeader1;
    private XRLine xrLine2;
    private XRLine xrLine1;
    private GroupFooterBand GroupFooter1;
    private CalculatedField tLineNet;
    private CalculatedField tLineVAT;
    private XRLabel xrLabel24;
    private CalculatedField lineGross;
    private CalculatedField tLineGross;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell10;
    private XRTableCell xrTableCell11;
    private XRTableCell xrTableCell12;
    private XRTableCell xrTableCell13;
    private XRTableCell xrTableCell14;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell7;
    private XRLabel xrLabel25;
    private XRLabel xrLabel23;
    private XRLabel xrLabel22;
    private XRLabel xrLabel26;
    private XRLabel xrLabel28;
    private XRLabel xrLabel27;
    private XRPageInfo xrPageInfo1;
    private XRLabel xrLabelInvoiceNumber;
    private XRLabel xrLabelDueDate;
    private XRLabel xrLabel29;
    private XRPageInfo xrPageInfo2;
    private XRLabel xrLabel30;
    private PageHeaderBand PageHeader;
    private XRLabel xrLabel31;
    private DevExpress.XtraReports.Parameters.Parameter pSalesInvoice;
    private XRLabel xrLabel33;
    private XRLabel xrLabel32;
    private XRLabel xrLabel35;
    private XRLabel xrLabel34;
    private XRLabel xrLabel37;
    private XRLabel xrLabel36;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public SalesInvoiceXS()
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesInvoiceXS));
        DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery2 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
        DevExpress.DataAccess.Sql.MasterDetailInfo masterDetailInfo1 = new DevExpress.DataAccess.Sql.MasterDetailInfo();
        DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo1 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
        DevExpress.XtraReports.Parameters.DynamicListLookUpSettings dynamicListLookUpSettings1 = new DevExpress.XtraReports.Parameters.DynamicListLookUpSettings();
        this.SalesInvoiceDS = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrLabel35 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel34 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.DetailReport = new DevExpress.XtraReports.UI.DetailReportBand();
        this.Detail1 = new DevExpress.XtraReports.UI.DetailBand();
        this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
        this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
        this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
        this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
        this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel32 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel31 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
        this.tLineNet = new DevExpress.XtraReports.UI.CalculatedField();
        this.tLineVAT = new DevExpress.XtraReports.UI.CalculatedField();
        this.lineGross = new DevExpress.XtraReports.UI.CalculatedField();
        this.tLineGross = new DevExpress.XtraReports.UI.CalculatedField();
        this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
        this.xrLabelInvoiceNumber = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabelDueDate = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
        this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.pSalesInvoice = new DevExpress.XtraReports.Parameters.Parameter();
        this.xrLabel36 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel37 = new DevExpress.XtraReports.UI.XRLabel();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // SalesInvoiceDS
        // 
        this.SalesInvoiceDS.ConnectionName = "IWSConnectionString";
        this.SalesInvoiceDS.Name = "SalesInvoiceDS";
        customSqlQuery1.MetaSerializable = "20|20|100|277";
        customSqlQuery1.Name = "Details";
        customSqlQuery1.Sql = resources.GetString("customSqlQuery1.Sql");
        customSqlQuery2.Name = "Master";
        customSqlQuery2.Sql = resources.GetString("customSqlQuery2.Sql");
        this.SalesInvoiceDS.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1,
            customSqlQuery2});
        masterDetailInfo1.DetailQueryName = "Details";
        relationColumnInfo1.NestedKeyColumn = "transid";
        relationColumnInfo1.ParentKeyColumn = "salesInvoiceid";
        masterDetailInfo1.KeyColumns.Add(relationColumnInfo1);
        masterDetailInfo1.MasterQueryName = "Master";
        this.SalesInvoiceDS.Relations.AddRange(new DevExpress.DataAccess.Sql.MasterDetailInfo[] {
            masterDetailInfo1});
        this.SalesInvoiceDS.ResultSchemaSerializable = resources.GetString("SalesInvoiceDS.ResultSchemaSerializable");
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel35,
            this.xrLabel34,
            this.xrLabel21,
            this.xrLabel20,
            this.xrLabel19,
            this.xrLabel18,
            this.xrLabel17,
            this.xrLabel16,
            this.xrLabel15,
            this.xrLabel14,
            this.xrLabel13,
            this.xrLabel12,
            this.xrLabel11,
            this.xrLabel10,
            this.xrLabel9,
            this.xrLabel8,
            this.xrLabel7,
            this.xrLabel6,
            this.xrLabel5,
            this.xrLabel4,
            this.xrLabel3,
            this.xrLabel2,
            this.xrLabel1});
        this.Detail.Dpi = 100F;
        this.Detail.HeightF = 294.6666F;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel35
        // 
        this.xrLabel35.Dpi = 100F;
        this.xrLabel35.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel35.LocationFloat = new DevExpress.Utils.PointFloat(570.1432F, 111.8333F);
        this.xrLabel35.Name = "xrLabel35";
        this.xrLabel35.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel35.SizeF = new System.Drawing.SizeF(222.8568F, 23F);
        this.xrLabel35.StylePriority.UseFont = false;
        this.xrLabel35.StylePriority.UsePadding = false;
        this.xrLabel35.Text = global::IWSProject.Content.IWSLocalResource.ShipTo;
        // 
        // xrLabel34
        // 
        this.xrLabel34.Dpi = 100F;
        this.xrLabel34.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel34.LocationFloat = new DevExpress.Utils.PointFloat(10F, 111.8333F);
        this.xrLabel34.Name = "xrLabel34";
        this.xrLabel34.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel34.SizeF = new System.Drawing.SizeF(208.283F, 23F);
        this.xrLabel34.StylePriority.UseFont = false;
        this.xrLabel34.StylePriority.UsePadding = false;
        this.xrLabel34.Text = global::IWSProject.Content.IWSLocalResource.BillTo;
        // 
        // xrLabel21
        // 
        this.xrLabel21.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.salesInvoiceText")});
        this.xrLabel21.Dpi = 100F;
        this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(10F, 244F);
        this.xrLabel21.Name = "xrLabel21";
        this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel21.SizeF = new System.Drawing.SizeF(783.0001F, 50.6666F);
        this.xrLabel21.StylePriority.UsePadding = false;
        this.xrLabel21.Text = "xrLabel21";
        // 
        // xrLabel20
        // 
        this.xrLabel20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.storeState")});
        this.xrLabel20.Dpi = 100F;
        this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(569.2858F, 214.0001F);
        this.xrLabel20.Name = "xrLabel20";
        this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel20.SizeF = new System.Drawing.SizeF(223.7142F, 23F);
        this.xrLabel20.StylePriority.UsePadding = false;
        this.xrLabel20.Text = "xrLabel20";
        // 
        // xrLabel19
        // 
        this.xrLabel19.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.storeCity")});
        this.xrLabel19.Dpi = 100F;
        this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(657.8096F, 191F);
        this.xrLabel19.Name = "xrLabel19";
        this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel19.SizeF = new System.Drawing.SizeF(135.1904F, 23F);
        this.xrLabel19.StylePriority.UsePadding = false;
        this.xrLabel19.Text = "xrLabel19";
        // 
        // xrLabel18
        // 
        this.xrLabel18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.storeZip")});
        this.xrLabel18.Dpi = 100F;
        this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(569.2858F, 191F);
        this.xrLabel18.Name = "xrLabel18";
        this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel18.SizeF = new System.Drawing.SizeF(88.5238F, 23F);
        this.xrLabel18.StylePriority.UsePadding = false;
        this.xrLabel18.Text = "xrLabel18";
        // 
        // xrLabel17
        // 
        this.xrLabel17.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.storeStreet")});
        this.xrLabel17.Dpi = 100F;
        this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(569.2858F, 168F);
        this.xrLabel17.Name = "xrLabel17";
        this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel17.SizeF = new System.Drawing.SizeF(223.7142F, 23F);
        this.xrLabel17.StylePriority.UsePadding = false;
        this.xrLabel17.Text = "xrLabel17";
        // 
        // xrLabel16
        // 
        this.xrLabel16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.storeName")});
        this.xrLabel16.Dpi = 100F;
        this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(569.2858F, 145F);
        this.xrLabel16.Name = "xrLabel16";
        this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel16.SizeF = new System.Drawing.SizeF(223.7142F, 23.00001F);
        this.xrLabel16.StylePriority.UsePadding = false;
        this.xrLabel16.Text = "xrLabel16";
        // 
        // xrLabel15
        // 
        this.xrLabel15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.customerIBAN")});
        this.xrLabel15.Dpi = 100F;
        this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(236.1163F, 145F);
        this.xrLabel15.Name = "xrLabel15";
        this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel15.SizeF = new System.Drawing.SizeF(293.6219F, 23.00001F);
        this.xrLabel15.StylePriority.UsePadding = false;
        this.xrLabel15.Text = "xrLabel15";
        // 
        // xrLabel14
        // 
        this.xrLabel14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.customerState")});
        this.xrLabel14.Dpi = 100F;
        this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(10F, 214.0001F);
        this.xrLabel14.Name = "xrLabel14";
        this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel14.SizeF = new System.Drawing.SizeF(208.283F, 23F);
        this.xrLabel14.StylePriority.UsePadding = false;
        this.xrLabel14.Text = "xrLabel14";
        // 
        // xrLabel13
        // 
        this.xrLabel13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.customerCity")});
        this.xrLabel13.Dpi = 100F;
        this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(100F, 191F);
        this.xrLabel13.Name = "xrLabel13";
        this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel13.SizeF = new System.Drawing.SizeF(118.283F, 23F);
        this.xrLabel13.StylePriority.UsePadding = false;
        this.xrLabel13.Text = "xrLabel13";
        // 
        // xrLabel12
        // 
        this.xrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.customerZip")});
        this.xrLabel12.Dpi = 100F;
        this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(10F, 191F);
        this.xrLabel12.Name = "xrLabel12";
        this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel12.SizeF = new System.Drawing.SizeF(90F, 23F);
        this.xrLabel12.StylePriority.UsePadding = false;
        this.xrLabel12.Text = "xrLabel12";
        // 
        // xrLabel11
        // 
        this.xrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.customerStreet")});
        this.xrLabel11.Dpi = 100F;
        this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(10F, 168F);
        this.xrLabel11.Name = "xrLabel11";
        this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel11.SizeF = new System.Drawing.SizeF(208.283F, 23F);
        this.xrLabel11.StylePriority.UsePadding = false;
        this.xrLabel11.Text = "xrLabel11";
        // 
        // xrLabel10
        // 
        this.xrLabel10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.customerName")});
        this.xrLabel10.Dpi = 100F;
        this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(10F, 145F);
        this.xrLabel10.Name = "xrLabel10";
        this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel10.SizeF = new System.Drawing.SizeF(208.283F, 23F);
        this.xrLabel10.StylePriority.UsePadding = false;
        this.xrLabel10.Text = "xrLabel10";
        // 
        // xrLabel9
        // 
        this.xrLabel9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.companyVatCode")});
        this.xrLabel9.Dpi = 100F;
        this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(236.1163F, 69.00002F);
        this.xrLabel9.Name = "xrLabel9";
        this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel9.SizeF = new System.Drawing.SizeF(293.6219F, 23F);
        this.xrLabel9.StylePriority.UsePadding = false;
        this.xrLabel9.Text = "xrLabel9";
        this.xrLabel9.Visible = false;
        // 
        // xrLabel8
        // 
        this.xrLabel8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.companyTaxCode")});
        this.xrLabel8.Dpi = 100F;
        this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(236.1163F, 46.00001F);
        this.xrLabel8.Name = "xrLabel8";
        this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel8.SizeF = new System.Drawing.SizeF(293.6219F, 23F);
        this.xrLabel8.StylePriority.UsePadding = false;
        this.xrLabel8.Text = "xrLabel8";
        // 
        // xrLabel7
        // 
        this.xrLabel7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.companyCIF")});
        this.xrLabel7.Dpi = 100F;
        this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(236.1163F, 23.00001F);
        this.xrLabel7.Name = "xrLabel7";
        this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel7.SizeF = new System.Drawing.SizeF(293.6219F, 23F);
        this.xrLabel7.StylePriority.UsePadding = false;
        this.xrLabel7.Text = "xrLabel7";
        // 
        // xrLabel6
        // 
        this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.companyIBAN")});
        this.xrLabel6.Dpi = 100F;
        this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(236.1163F, 0F);
        this.xrLabel6.Name = "xrLabel6";
        this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel6.SizeF = new System.Drawing.SizeF(293.6219F, 23F);
        this.xrLabel6.StylePriority.UsePadding = false;
        this.xrLabel6.Text = "xrLabel6";
        // 
        // xrLabel5
        // 
        this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.companyState")});
        this.xrLabel5.Dpi = 100F;
        this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(10F, 69.00002F);
        this.xrLabel5.Name = "xrLabel5";
        this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel5.SizeF = new System.Drawing.SizeF(206.1163F, 23F);
        this.xrLabel5.StylePriority.UsePadding = false;
        this.xrLabel5.Text = "xrLabel5";
        // 
        // xrLabel4
        // 
        this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.customerCity")});
        this.xrLabel4.Dpi = 100F;
        this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(100F, 46.00001F);
        this.xrLabel4.Name = "xrLabel4";
        this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel4.SizeF = new System.Drawing.SizeF(116.1163F, 23F);
        this.xrLabel4.StylePriority.UsePadding = false;
        this.xrLabel4.Text = "xrLabel4";
        // 
        // xrLabel3
        // 
        this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.companyZip")});
        this.xrLabel3.Dpi = 100F;
        this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(10F, 46.00001F);
        this.xrLabel3.Name = "xrLabel3";
        this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel3.SizeF = new System.Drawing.SizeF(90F, 23F);
        this.xrLabel3.StylePriority.UsePadding = false;
        this.xrLabel3.Text = "xrLabel3";
        // 
        // xrLabel2
        // 
        this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.companyStreet")});
        this.xrLabel2.Dpi = 100F;
        this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(10F, 23.00001F);
        this.xrLabel2.Name = "xrLabel2";
        this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel2.SizeF = new System.Drawing.SizeF(206.1163F, 23F);
        this.xrLabel2.StylePriority.UsePadding = false;
        this.xrLabel2.Text = "xrLabel2";
        // 
        // xrLabel1
        // 
        this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.companyName")});
        this.xrLabel1.Dpi = 100F;
        this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(10F, 0F);
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel1.SizeF = new System.Drawing.SizeF(206.1163F, 23F);
        this.xrLabel1.StylePriority.UsePadding = false;
        this.xrLabel1.Text = "xrLabel1";
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
        this.BottomMargin.HeightF = 46.00001F;
        this.BottomMargin.Name = "BottomMargin";
        this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // DetailReport
        // 
        this.DetailReport.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail1,
            this.GroupHeader1,
            this.GroupFooter1});
        this.DetailReport.DataMember = "Master.MasterDetails";
        this.DetailReport.DataSource = this.SalesInvoiceDS;
        this.DetailReport.Dpi = 100F;
        this.DetailReport.Level = 0;
        this.DetailReport.Name = "DetailReport";
        this.DetailReport.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand;
        // 
        // Detail1
        // 
        this.Detail1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
        this.Detail1.Dpi = 100F;
        this.Detail1.HeightF = 26.66667F;
        this.Detail1.Name = "Detail1";
        // 
        // xrTable2
        // 
        this.xrTable2.Dpi = 100F;
        this.xrTable2.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(10F, 1.666667F);
        this.xrTable2.Name = "xrTable2";
        this.xrTable2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
        this.xrTable2.SizeF = new System.Drawing.SizeF(783.0001F, 25F);
        this.xrTable2.StylePriority.UseFont = false;
        this.xrTable2.StylePriority.UsePadding = false;
        // 
        // xrTableRow2
        // 
        this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell8,
            this.xrTableCell9,
            this.xrTableCell10,
            this.xrTableCell11,
            this.xrTableCell12,
            this.xrTableCell13,
            this.xrTableCell14});
        this.xrTableRow2.Dpi = 100F;
        this.xrTableRow2.Name = "xrTableRow2";
        this.xrTableRow2.Weight = 11.5D;
        // 
        // xrTableCell8
        // 
        this.xrTableCell8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.MasterDetails.name")});
        this.xrTableCell8.Dpi = 100F;
        this.xrTableCell8.Name = "xrTableCell8";
        this.xrTableCell8.StylePriority.UseTextAlignment = false;
        this.xrTableCell8.Text = "xrTableCell8";
        this.xrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleJustify;
        this.xrTableCell8.Weight = 1.7890035133946181D;
        // 
        // xrTableCell9
        // 
        this.xrTableCell9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.MasterDetails.unit")});
        this.xrTableCell9.Dpi = 100F;
        this.xrTableCell9.Name = "xrTableCell9";
        this.xrTableCell9.StylePriority.UseTextAlignment = false;
        this.xrTableCell9.Text = "xrTableCell9";
        this.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell9.Weight = 0.64245305975128508D;
        // 
        // xrTableCell10
        // 
        this.xrTableCell10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.MasterDetails.quantity")});
        this.xrTableCell10.Dpi = 100F;
        this.xrTableCell10.Name = "xrTableCell10";
        this.xrTableCell10.StylePriority.UseTextAlignment = false;
        this.xrTableCell10.Text = "xrTableCell10";
        this.xrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell10.Weight = 0.72564017192232444D;
        // 
        // xrTableCell11
        // 
        this.xrTableCell11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.MasterDetails.price", "{0:n}")});
        this.xrTableCell11.Dpi = 100F;
        this.xrTableCell11.Name = "xrTableCell11";
        this.xrTableCell11.StylePriority.UseTextAlignment = false;
        this.xrTableCell11.Text = "xrTableCell11";
        this.xrTableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell11.Weight = 0.72639840056284044D;
        // 
        // xrTableCell12
        // 
        this.xrTableCell12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.MasterDetails.lineNet", "{0:n}")});
        this.xrTableCell12.Dpi = 100F;
        this.xrTableCell12.Name = "xrTableCell12";
        this.xrTableCell12.StylePriority.UseTextAlignment = false;
        this.xrTableCell12.Text = "xrTableCell12";
        this.xrTableCell12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell12.Weight = 0.970873786407767D;
        // 
        // xrTableCell13
        // 
        this.xrTableCell13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.MasterDetails.lineVAT", "{0:n}")});
        this.xrTableCell13.Dpi = 100F;
        this.xrTableCell13.Name = "xrTableCell13";
        this.xrTableCell13.StylePriority.UseTextAlignment = false;
        this.xrTableCell13.Text = "xrTableCell13";
        this.xrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell13.Weight = 0.970873786407767D;
        // 
        // xrTableCell14
        // 
        this.xrTableCell14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.MasterDetails.lineGross", "{0:n}")});
        this.xrTableCell14.Dpi = 100F;
        this.xrTableCell14.Name = "xrTableCell14";
        this.xrTableCell14.StylePriority.UseTextAlignment = false;
        this.xrTableCell14.Text = "xrTableCell14";
        this.xrTableCell14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell14.Weight = 0.970873786407767D;
        // 
        // GroupHeader1
        // 
        this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1,
            this.xrLine1});
        this.GroupHeader1.Dpi = 100F;
        this.GroupHeader1.HeightF = 31F;
        this.GroupHeader1.Name = "GroupHeader1";
        // 
        // xrTable1
        // 
        this.xrTable1.Dpi = 100F;
        this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(10F, 2F);
        this.xrTable1.Name = "xrTable1";
        this.xrTable1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
        this.xrTable1.SizeF = new System.Drawing.SizeF(783.0001F, 25F);
        this.xrTable1.StylePriority.UseFont = false;
        this.xrTable1.StylePriority.UsePadding = false;
        this.xrTable1.StylePriority.UseTextAlignment = false;
        this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrTableRow1
        // 
        this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell3,
            this.xrTableCell4,
            this.xrTableCell5,
            this.xrTableCell6,
            this.xrTableCell7});
        this.xrTableRow1.Dpi = 100F;
        this.xrTableRow1.Name = "xrTableRow1";
        this.xrTableRow1.Weight = 11.5D;
        // 
        // xrTableCell1
        // 
        this.xrTableCell1.Dpi = 100F;
        this.xrTableCell1.Name = "xrTableCell1";
        this.xrTableCell1.StylePriority.UseTextAlignment = false;
        this.xrTableCell1.Text = global::IWSProject.Content.IWSLocalResource.description;
        this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell1.Weight = 1.7890039008186833D;
        // 
        // xrTableCell2
        // 
        this.xrTableCell2.Dpi = 100F;
        this.xrTableCell2.Name = "xrTableCell2";
        this.xrTableCell2.Text = global::IWSProject.Content.IWSLocalResource.unit;
        this.xrTableCell2.Weight = 0.64245234122728312D;
        // 
        // xrTableCell3
        // 
        this.xrTableCell3.Dpi = 100F;
        this.xrTableCell3.Name = "xrTableCell3";
        this.xrTableCell3.Text = global::IWSProject.Content.IWSLocalResource.quantity;
        this.xrTableCell3.Weight = 0.74299967537243838D;
        // 
        // xrTableCell4
        // 
        this.xrTableCell4.Dpi = 100F;
        this.xrTableCell4.Name = "xrTableCell4";
        this.xrTableCell4.Text = global::IWSProject.Content.IWSLocalResource.price;
        this.xrTableCell4.Weight = 0.70903922821266308D;
        // 
        // xrTableCell5
        // 
        this.xrTableCell5.Dpi = 100F;
        this.xrTableCell5.Name = "xrTableCell5";
        this.xrTableCell5.Text = global::IWSProject.Content.IWSLocalResource.net;
        this.xrTableCell5.Weight = 0.970873786407767D;
        // 
        // xrTableCell6
        // 
        this.xrTableCell6.Dpi = 100F;
        this.xrTableCell6.Name = "xrTableCell6";
        this.xrTableCell6.Text = global::IWSProject.Content.IWSLocalResource.vat;
        this.xrTableCell6.Weight = 0.970873786407767D;
        // 
        // xrTableCell7
        // 
        this.xrTableCell7.Dpi = 100F;
        this.xrTableCell7.Name = "xrTableCell7";
        this.xrTableCell7.Text = global::IWSProject.Content.IWSLocalResource.gross;
        this.xrTableCell7.Weight = 0.970873786407767D;
        // 
        // xrLine1
        // 
        this.xrLine1.Dpi = 100F;
        this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(10F, 29F);
        this.xrLine1.Name = "xrLine1";
        this.xrLine1.SizeF = new System.Drawing.SizeF(783F, 2F);
        // 
        // GroupFooter1
        // 
        this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel33,
            this.xrLabel32,
            this.xrLabel31,
            this.xrLabel25,
            this.xrLabel23,
            this.xrLabel22,
            this.xrLabel24,
            this.xrLine2});
        this.GroupFooter1.Dpi = 100F;
        this.GroupFooter1.HeightF = 51.50001F;
        this.GroupFooter1.Name = "GroupFooter1";
        // 
        // xrLabel33
        // 
        this.xrLabel33.Dpi = 100F;
        this.xrLabel33.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel33.LocationFloat = new DevExpress.Utils.PointFloat(481.8097F, 28.50001F);
        this.xrLabel33.Name = "xrLabel33";
        this.xrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel33.SizeF = new System.Drawing.SizeF(133.3333F, 23F);
        this.xrLabel33.StylePriority.UseFont = false;
        this.xrLabel33.StylePriority.UsePadding = false;
        this.xrLabel33.StylePriority.UseTextAlignment = false;
        this.xrLabel33.Text = global::IWSProject.Content.IWSLocalResource.Total;
        this.xrLabel33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel32
        // 
        this.xrLabel32.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.salesInvoiceCurrency")});
        this.xrLabel32.Dpi = 100F;
        this.xrLabel32.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel32.LocationFloat = new DevExpress.Utils.PointFloat(616.143F, 28.50001F);
        this.xrLabel32.Name = "xrLabel32";
        this.xrLabel32.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel32.SizeF = new System.Drawing.SizeF(65F, 23F);
        this.xrLabel32.StylePriority.UseFont = false;
        this.xrLabel32.StylePriority.UsePadding = false;
        this.xrLabel32.StylePriority.UseTextAlignment = false;
        this.xrLabel32.Text = "xrLabel32";
        this.xrLabel32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel31
        // 
        this.xrLabel31.Dpi = 100F;
        this.xrLabel31.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel31.LocationFloat = new DevExpress.Utils.PointFloat(357.4286F, 1F);
        this.xrLabel31.Name = "xrLabel31";
        this.xrLabel31.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel31.SizeF = new System.Drawing.SizeF(100F, 23F);
        this.xrLabel31.StylePriority.UseFont = false;
        this.xrLabel31.StylePriority.UsePadding = false;
        this.xrLabel31.StylePriority.UseTextAlignment = false;
        this.xrLabel31.Text = global::IWSProject.Content.IWSLocalResource.subtotals;
        this.xrLabel31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel25
        // 
        this.xrLabel25.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.MasterDetails.tLineNet", "{0:n}")});
        this.xrLabel25.Dpi = 100F;
        this.xrLabel25.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(457.4286F, 0F);
        this.xrLabel25.Name = "xrLabel25";
        this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel25.SizeF = new System.Drawing.SizeF(111.8572F, 25F);
        this.xrLabel25.StylePriority.UseFont = false;
        this.xrLabel25.StylePriority.UsePadding = false;
        this.xrLabel25.StylePriority.UseTextAlignment = false;
        this.xrLabel25.Text = "xrLabel25";
        this.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel23
        // 
        this.xrLabel23.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.MasterDetails.tLineVAT", "{0:n}")});
        this.xrLabel23.Dpi = 100F;
        this.xrLabel23.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(569.2858F, 0F);
        this.xrLabel23.Name = "xrLabel23";
        this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel23.SizeF = new System.Drawing.SizeF(111.8571F, 25F);
        this.xrLabel23.StylePriority.UseFont = false;
        this.xrLabel23.StylePriority.UsePadding = false;
        this.xrLabel23.StylePriority.UseTextAlignment = false;
        this.xrLabel23.Text = "xrLabel23";
        this.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel22
        // 
        this.xrLabel22.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.MasterDetails.tLineGross", "{0:n}")});
        this.xrLabel22.Dpi = 100F;
        this.xrLabel22.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(681.143F, 0F);
        this.xrLabel22.Name = "xrLabel22";
        this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel22.SizeF = new System.Drawing.SizeF(111.8572F, 25F);
        this.xrLabel22.StylePriority.UseFont = false;
        this.xrLabel22.StylePriority.UsePadding = false;
        this.xrLabel22.StylePriority.UseTextAlignment = false;
        this.xrLabel22.Text = "xrLabel22";
        this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel24
        // 
        this.xrLabel24.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.salesInvoiceTotal", "{0:n}")});
        this.xrLabel24.Dpi = 100F;
        this.xrLabel24.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(681.1432F, 28.5F);
        this.xrLabel24.Name = "xrLabel24";
        this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel24.SizeF = new System.Drawing.SizeF(111.857F, 23F);
        this.xrLabel24.StylePriority.UseFont = false;
        this.xrLabel24.StylePriority.UsePadding = false;
        this.xrLabel24.StylePriority.UseTextAlignment = false;
        this.xrLabel24.Text = "xrLabel24";
        this.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLine2
        // 
        this.xrLine2.Dpi = 100F;
        this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(10F, 25.49998F);
        this.xrLine2.Name = "xrLine2";
        this.xrLine2.SizeF = new System.Drawing.SizeF(783F, 2F);
        // 
        // tLineNet
        // 
        this.tLineNet.DataMember = "Master.MasterDetails";
        this.tLineNet.Expression = "Sum([lineNet])";
        this.tLineNet.Name = "tLineNet";
        // 
        // tLineVAT
        // 
        this.tLineVAT.DataMember = "Master.MasterDetails";
        this.tLineVAT.Expression = "Sum([lineVAT])";
        this.tLineVAT.Name = "tLineVAT";
        // 
        // lineGross
        // 
        this.lineGross.DataMember = "Master.MasterDetails";
        this.lineGross.Expression = "[lineNet]+[lineVAT]";
        this.lineGross.Name = "lineGross";
        // 
        // tLineGross
        // 
        this.tLineGross.DataMember = "Master.MasterDetails";
        this.tLineGross.Expression = "Sum([lineGross])";
        this.tLineGross.Name = "tLineGross";
        // 
        // xrLabel26
        // 
        this.xrLabel26.Dpi = 100F;
        this.xrLabel26.Font = new System.Drawing.Font("Times New Roman", 28F, System.Drawing.FontStyle.Bold);
        this.xrLabel26.LocationFloat = new DevExpress.Utils.PointFloat(10F, 21.00001F);
        this.xrLabel26.Name = "xrLabel26";
        this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel26.SizeF = new System.Drawing.SizeF(288.3333F, 53.33334F);
        this.xrLabel26.StylePriority.UseFont = false;
        this.xrLabel26.Text = global::IWSProject.Content.IWSLocalResource.invoice;
        // 
        // xrLabel27
        // 
        this.xrLabel27.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.salesInvoiceid")});
        this.xrLabel27.Dpi = 100F;
        this.xrLabel27.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(671.1432F, 0F);
        this.xrLabel27.Name = "xrLabel27";
        this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel27.SizeF = new System.Drawing.SizeF(121.857F, 23F);
        this.xrLabel27.StylePriority.UseFont = false;
        this.xrLabel27.StylePriority.UsePadding = false;
        this.xrLabel27.StylePriority.UseTextAlignment = false;
        this.xrLabel27.Text = "xrLabel27";
        this.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel28
        // 
        this.xrLabel28.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.salesInvoiceDate", "{0:yyyy-MM-dd}")});
        this.xrLabel28.Dpi = 100F;
        this.xrLabel28.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel28.LocationFloat = new DevExpress.Utils.PointFloat(671.1432F, 50.16668F);
        this.xrLabel28.Name = "xrLabel28";
        this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel28.SizeF = new System.Drawing.SizeF(121.857F, 22.99999F);
        this.xrLabel28.StylePriority.UseFont = false;
        this.xrLabel28.StylePriority.UsePadding = false;
        this.xrLabel28.StylePriority.UseTextAlignment = false;
        this.xrLabel28.Text = "xrLabel28";
        this.xrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrPageInfo1
        // 
        this.xrPageInfo1.Dpi = 100F;
        this.xrPageInfo1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrPageInfo1.Format = "{0:yyyy-MM-dd}";
        this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(671.1432F, 25F);
        this.xrPageInfo1.Name = "xrPageInfo1";
        this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
        this.xrPageInfo1.SizeF = new System.Drawing.SizeF(121.857F, 23F);
        this.xrPageInfo1.StylePriority.UseFont = false;
        this.xrPageInfo1.StylePriority.UsePadding = false;
        this.xrPageInfo1.StylePriority.UseTextAlignment = false;
        this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabelInvoiceNumber
        // 
        this.xrLabelInvoiceNumber.AutoWidth = true;
        this.xrLabelInvoiceNumber.Dpi = 100F;
        this.xrLabelInvoiceNumber.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabelInvoiceNumber.LocationFloat = new DevExpress.Utils.PointFloat(570.1431F, 0F);
        this.xrLabelInvoiceNumber.Name = "xrLabelInvoiceNumber";
        this.xrLabelInvoiceNumber.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabelInvoiceNumber.SizeF = new System.Drawing.SizeF(100F, 24.00002F);
        this.xrLabelInvoiceNumber.StylePriority.UseFont = false;
        this.xrLabelInvoiceNumber.StylePriority.UsePadding = false;
        this.xrLabelInvoiceNumber.StylePriority.UseTextAlignment = false;
        this.xrLabelInvoiceNumber.Text = global::IWSProject.Content.IWSLocalResource.invoice;
        this.xrLabelInvoiceNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrLabelInvoiceNumber.WordWrap = false;
        // 
        // xrLabelDueDate
        // 
        this.xrLabelDueDate.AutoWidth = true;
        this.xrLabelDueDate.Dpi = 100F;
        this.xrLabelDueDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabelDueDate.LocationFloat = new DevExpress.Utils.PointFloat(570.1431F, 51.33335F);
        this.xrLabelDueDate.Name = "xrLabelDueDate";
        this.xrLabelDueDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabelDueDate.SizeF = new System.Drawing.SizeF(100F, 23F);
        this.xrLabelDueDate.StylePriority.UseFont = false;
        this.xrLabelDueDate.StylePriority.UsePadding = false;
        this.xrLabelDueDate.StylePriority.UseTextAlignment = false;
        this.xrLabelDueDate.Text = global::IWSProject.Content.IWSLocalResource.duedate;
        this.xrLabelDueDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrLabelDueDate.WordWrap = false;
        // 
        // xrLabel29
        // 
        this.xrLabel29.AutoWidth = true;
        this.xrLabel29.CanGrow = false;
        this.xrLabel29.Dpi = 100F;
        this.xrLabel29.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel29.LocationFloat = new DevExpress.Utils.PointFloat(570.1431F, 25F);
        this.xrLabel29.Name = "xrLabel29";
        this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel29.SizeF = new System.Drawing.SizeF(100F, 23.99999F);
        this.xrLabel29.StylePriority.UseFont = false;
        this.xrLabel29.StylePriority.UsePadding = false;
        this.xrLabel29.StylePriority.UseTextAlignment = false;
        this.xrLabel29.Text = global::IWSProject.Content.IWSLocalResource.InvoiceDate;
        this.xrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrLabel29.WordWrap = false;
        // 
        // xrPageInfo2
        // 
        this.xrPageInfo2.Dpi = 100F;
        this.xrPageInfo2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrPageInfo2.Format = "{0} / {1}";
        this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(671.1432F, 103.3334F);
        this.xrPageInfo2.Name = "xrPageInfo2";
        this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrPageInfo2.SizeF = new System.Drawing.SizeF(121.857F, 23.00002F);
        this.xrPageInfo2.StylePriority.UseFont = false;
        this.xrPageInfo2.StylePriority.UseTextAlignment = false;
        this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel30
        // 
        this.xrLabel30.AutoWidth = true;
        this.xrLabel30.Dpi = 100F;
        this.xrLabel30.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel30.LocationFloat = new DevExpress.Utils.PointFloat(570.1432F, 103.3334F);
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
        // PageHeader
        // 
        this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel37,
            this.xrLabel36,
            this.xrLabel30,
            this.xrPageInfo2,
            this.xrLabelInvoiceNumber,
            this.xrLabelDueDate,
            this.xrLabel29,
            this.xrPageInfo1,
            this.xrLabel28,
            this.xrLabel27,
            this.xrLabel26});
        this.PageHeader.Dpi = 100F;
        this.PageHeader.HeightF = 128.3334F;
        this.PageHeader.Name = "PageHeader";
        // 
        // pSalesInvoice
        // 
        this.pSalesInvoice.Description = "Sales Invoice";
        dynamicListLookUpSettings1.DataAdapter = null;
        dynamicListLookUpSettings1.DataMember = "Master";
        dynamicListLookUpSettings1.DataSource = this.SalesInvoiceDS;
        dynamicListLookUpSettings1.DisplayMember = "salesInvoiceid";
        dynamicListLookUpSettings1.FilterString = null;
        dynamicListLookUpSettings1.ValueMember = "salesInvoiceid";
        this.pSalesInvoice.LookUpSettings = dynamicListLookUpSettings1;
        this.pSalesInvoice.Name = "pSalesInvoice";
        this.pSalesInvoice.Type = typeof(int);
        this.pSalesInvoice.ValueInfo = "0";
        // 
        // xrLabel36
        // 
        this.xrLabel36.AutoWidth = true;
        this.xrLabel36.Dpi = 100F;
        this.xrLabel36.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel36.LocationFloat = new DevExpress.Utils.PointFloat(570.1431F, 77.33335F);
        this.xrLabel36.Name = "xrLabel36";
        this.xrLabel36.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel36.SizeF = new System.Drawing.SizeF(100F, 23F);
        this.xrLabel36.StylePriority.UseFont = false;
        this.xrLabel36.StylePriority.UsePadding = false;
        this.xrLabel36.StylePriority.UseTextAlignment = false;
        this.xrLabel36.Text = global::IWSProject.Content.IWSLocalResource.BillPeriod;
        this.xrLabel36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrLabel36.WordWrap = false;
        // 
        // xrLabel37
        // 
        this.xrLabel37.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.TransDate", "{0:MM - yyyy}")});
        this.xrLabel37.Dpi = 100F;
        this.xrLabel37.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel37.LocationFloat = new DevExpress.Utils.PointFloat(671.1432F, 77.33335F);
        this.xrLabel37.Name = "xrLabel37";
        this.xrLabel37.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
        this.xrLabel37.SizeF = new System.Drawing.SizeF(121.857F, 22.99999F);
        this.xrLabel37.StylePriority.UseFont = false;
        this.xrLabel37.StylePriority.UsePadding = false;
        this.xrLabel37.StylePriority.UseTextAlignment = false;
        this.xrLabel37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // SalesInvoiceXS
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.DetailReport,
            this.PageHeader});
        this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.tLineNet,
            this.tLineVAT,
            this.lineGross,
            this.tLineGross});
        this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.SalesInvoiceDS});
        this.DataMember = "Master";
        this.DataSource = this.SalesInvoiceDS;
        this.FilterString = "[salesInvoiceid] = ?pSalesInvoice";
        this.Font = new System.Drawing.Font("Times New Roman", 12F);
        this.Margins = new System.Drawing.Printing.Margins(23, 24, 0, 46);
        this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.pSalesInvoice});
        this.Version = "16.2";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
