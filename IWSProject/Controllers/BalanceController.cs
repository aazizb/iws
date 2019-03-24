using System.Collections.Generic;
using System.Web.Mvc;
using IWSProject.Models;
using DevExpress.XtraReports.UI;

namespace IWSProject.Controllers
{
    [Authorize]
    public class BalanceController : Controller
    {
        // GET: Balance
        public ActionResult Index()
        {
            return View();
        }
        [ValidateInput(false)]
        public ActionResult AccountBalancePartialView()
        {
            string selectedIDs = (string)Session["selectedIDs"];
            string company = (string)Session["CompanyID"];
            string start = (string)Session["startBalance"];
            string end = (string)Session["endBalance"];
            List<AccountBalanceViewModel> model = (List<AccountBalanceViewModel>)IWSLookUp.GetAccountBalance(start, end, selectedIDs, company);
            return PartialView("AccountBalancePartialView", model);
        }
        [ValidateInput(false)]
        public ActionResult GridLookupPartial()
        {
            if (ViewData["accounts"] == null)
                ViewData["accounts"] = IWSLookUp.GetAccounts();
            return PartialView("GridLookupPartial", ViewData["accounts"]);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CallbackPanelPartial(string start, string end, string selectedIDs)
        {
            Session["selectedIDs"] = selectedIDs;
            Session["startBalance"] = start;
            Session["endBalance"] = end;
            string company = (string)Session["CompanyID"];
            List<AccountBalanceViewModel> model = (List<AccountBalanceViewModel>)IWSLookUp.GetAccountBalance(start, end, selectedIDs, company);
            ViewBag.Results = model;
            return PartialView("_CallbackPartialView", model);
        }
        public ActionResult BalanceView()
        {
            return PartialView();
        }
        public ActionResult Export()
        {
            var model = ViewBag.Results;

            MVCxGridViewState gridViewState = (MVCxGridViewState)Session["gridViewState"];

            if (gridViewState != null)
            {
                MVCReportGeneratonHelper generator = new MVCReportGeneratonHelper();
                generator.CustomizeColumnsCollection += new CustomizeColumnsCollectionEventHandler(CustomizeColumnsCollection);
                generator.CustomizeColumn += new CustomizeColumnEventHandler(CustomizeColumn);
                XtraReport report = generator.GenerateMVCReport(gridViewState, model);
                generator.WritePdfToResponse(Response, "iws.xlsx", System.Net.Mime.DispositionTypeNames.Attachment.ToString());
                return null;
            }
            else
                return View("Index");
        }
        void CustomizeColumn(object source, ControlCustomizationEventArgs e)
        {
           
        }
        void CustomizeColumnsCollection(object source, ColumnsCreationEventArgs e)
        {
            e.ColumnsInfo[1].ColumnWidth *= 6;
            e.ColumnsInfo[2].ColumnWidth *= 1;
            e.ColumnsInfo[3].ColumnWidth *= 1;
            e.ColumnsInfo[4].ColumnWidth *= 2;
            e.ColumnsInfo[5].ColumnWidth *= 2;
            e.ColumnsInfo[6].ColumnWidth *= 2;
            e.ColumnsInfo[7].ColumnWidth *= 2;
            e.ColumnsInfo[8].ColumnWidth *= 2;
            e.ColumnsInfo[e.ColumnsInfo.Count - 1].IsVisible = true;
        }


    }
}