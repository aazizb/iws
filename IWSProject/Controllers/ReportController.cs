using DevExpress.Web.ASPxPivotGrid;
using DevExpress.Web.Mvc;
using DevExpress.XtraPivotGrid;
using IWSProject.Content;
using IWSProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace IWSProject.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        public ActionResult Index()
        {
             return View();
        }
        [ValidateInput(false)]
        public ActionResult PivotGridPartial()
        {
            string start = (string)Session["Start"];
            string end = (string)Session["End"];
            string companyId = (string)Session["CompanyID"];
            string accountId = string.Empty;
            List<JournalViewModel> model = (List<JournalViewModel>)IWSLookUp.GetJournal(start, end, accountId, companyId);
            return PartialView("PivotGridPartial", model.ToList());
        }
        public ActionResult CallbackPanelPartial(string start, string end)
        {
            if (string.IsNullOrWhiteSpace(start) || string.IsNullOrWhiteSpace(end))
                return PartialView("_CallbackPartialView");
            Session["Start"] = start;
            Session["End"] = end;
            string companyId = (string)Session["CompanyID"];
            string accountId = string.Empty;
            List<JournalViewModel> model = (List<JournalViewModel>)IWSLookUp.GetJournal(start, end, accountId, companyId);
            return PartialView("_CallbackPartialView", model);
        }
        public ActionResult ExportToXLS()
        {
            string start = (string)Session["Start"];
            string end = (string)Session["End"];
            string companyId = (string)Session["CompanyID"];
            string accountId = string.Empty;
            PivotXlsxExportOptions exportOptions = new PivotXlsxExportOptions() { ExportType = DevExpress.Export.ExportType.WYSIWYG };
            List<JournalViewModel> model = (List<JournalViewModel>)IWSLookUp.GetJournal(start, end, accountId, companyId);
            return PivotGridExtension.ExportToXlsx(PivotGridHelper.Settings, model.ToList(), exportOptions);
        }
        [ValidateInput(false)]
        public ActionResult AccountBalance()
        {
            AccountBalance accountBalance = new AccountBalance();

            accountBalance.Parameters["CompanyID"].Value = (string)Session["CompanyID"];

            return View(accountBalance);
        }
        public ActionResult ReportView()
        {
            return PartialView();
        }

    }
    public static class PivotGridHelper
    {
        private static PivotGridSettings pivotGridSettings;

        public static PivotGridSettings Settings
        {
            get
            {
                if (pivotGridSettings == null)
                    pivotGridSettings = CreatePivotGridSettings();
                return pivotGridSettings;
            }
        }
        private static PivotGridSettings CreatePivotGridSettings()
        {
            PivotGridSettings settings = new PivotGridSettings
            {
                Name = "pivotGrid",
                CallbackRouteValues = new { Controller = "Report", Action = "PivotGridPartial" },
                Width = new System.Web.UI.WebControls.Unit(99, System.Web.UI.WebControls.UnitType.Percentage)
            };
            settings.Fields.Add(field =>
            {
                field.Area = PivotArea.RowArea;
                field.FieldName = "ItemType";
                field.Caption = IWSLocalResource.ItemType;
                field.AreaIndex = 1;
            });
            settings.Fields.Add(field =>
            {
                field.Area = PivotArea.RowArea;
                field.FieldName = "Owner";
                field.Caption = IWSLocalResource.Owner;
                field.AreaIndex = 0;
            });
            settings.Fields.Add(field =>
            {
                field.Area = PivotArea.ColumnArea;
                field.FieldName = "TransDate";
                field.Caption = IWSLocalResource.Year;
                field.GroupInterval = PivotGroupInterval.DateYear;
                field.AreaIndex = 0;
            });
            settings.Fields.Add(field =>
            {
                field.Area = PivotArea.FilterArea;
                field.FieldName = "TransDate";
                field.Caption = IWSLocalResource.Quarter;
                field.GroupInterval = PivotGroupInterval.DateQuarter;
                field.AreaIndex = 1;
            });
            settings.Fields.Add(field =>
            {
                field.Area = PivotArea.RowArea;
                field.FieldName = "AccountName";
                field.Caption = IWSLocalResource.account;
                field.AreaIndex = 2;
            });
            settings.Fields.Add(field =>
            {
                field.Area = PivotArea.DataArea;
                field.FieldName = "Amount";
                field.Caption = IWSLocalResource.amount;
                field.AreaIndex = 0;
            });
            settings.Fields.Add(field =>
            {
                field.Area = PivotArea.FilterArea;
                field.FieldName = "Currency";
                field.Caption = IWSLocalResource.Currency;
                field.AreaIndex = 0;
            });
            settings.Fields.Add(field =>
            {
                field.Area = PivotArea.FilterArea;
                field.FieldName = "Side";
                field.Caption = IWSLocalResource.side;
                field.AreaIndex = 1;
            });
            return settings;
        }
    }

}