using DevExpress.XtraReports.UI;
using IWSProject.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace IWSProject.Controllers
{
    [Authorize]
    public class JournauxController : Controller
    {
        // GET: Balance
        public ActionResult Index()
        {
            return View();
        }
        [ValidateInput(false)]
        public ActionResult JournauxPartialView()
        {
            string start = (string)Session["Start"];
            string end = (string)Session["End"];
            string selectedIDs = (string)Session["selectedIDs"];
            string company = (string)Session["CompanyID"];
            List<JournauxViewModel> model = IWSLookUp.GetJournaux(selectedIDs, company);
            return PartialView("MasterGridViewPartial", model);
        }
        [ValidateInput(false)]
        public ActionResult DetailGridViewPartial(int transId)
        {
            Session["transid"] = transId;

            return PartialView("DetailGridViewPartial", IWSLookUp.GetLineJournaux(transId));
        }
        [ValidateInput(false)]
        public ActionResult GridLookupPartial()
        {
            if (ViewData["journaux"] == null)
                ViewData["journaux"] = IWSLookUp.GetTypeJournals();
            return PartialView("GridLookupPartial", ViewData["journaux"]);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CallbackPanelPartial(string start, string end, string selectedIDs)
        {
            if (string.IsNullOrWhiteSpace(start) || string.IsNullOrWhiteSpace(end))
                return PartialView("_CallbackPartialView");

            Session["Start"] = start;
            Session["End"] = end;
            Session["selectedIDs"] = selectedIDs;
            string company = (string)Session["CompanyID"];
            List<JournauxViewModel> model = IWSLookUp.GetJournaux(selectedIDs, company);
            Session["Journaux"] = model;
            return PartialView("_CallbackPartialView", model);
        }
        public ActionResult Export()
        {
            var model = Session["Journaux"];

            MVCxGridViewState gridViewState = (MVCxGridViewState)Session["gridViewJournaux"];

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
            e.ColumnsInfo[1].ColumnWidth *= 2;
            e.ColumnsInfo[2].ColumnWidth *= 1;
            e.ColumnsInfo[3].ColumnWidth *= 1;
            e.ColumnsInfo[4].ColumnWidth *= 3;
            e.ColumnsInfo[5].ColumnWidth *= 3;
            e.ColumnsInfo[6].ColumnWidth *= 3;
            e.ColumnsInfo[7].ColumnWidth *= 2;
            e.ColumnsInfo[8].ColumnWidth *= 2;
            e.ColumnsInfo[9].ColumnWidth *= 2;
            e.ColumnsInfo[10].ColumnWidth *= 4;
            e.ColumnsInfo[11].ColumnWidth *= 2;
            e.ColumnsInfo[12].ColumnWidth *= 2;
            e.ColumnsInfo[13].ColumnWidth *= 6;
            e.ColumnsInfo[e.ColumnsInfo.Count - 1].IsVisible = true;
        }

    }
}