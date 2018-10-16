using DevExpress.XtraReports.UI;
using IWSProject.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace IWSProject.Controllers
{
    [Authorize]
    public class JournalController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult JournalPartialView()
        {
            string start = (string)Session["Start"];
            string end = (string)Session["End"];
            string selectedIDs = (string)Session["selectedIDs"];
            string company = (string)Session["CompanyID"];
            List<JournalViewModel> model = (List<JournalViewModel>)IWSLookUp.GetJournal(start, end, selectedIDs, company);
            return PartialView("JournalPartialView", model);
        }
        [ValidateInput(false)]
        public ActionResult GridLookupPartial()
        {
            if(ViewData["accounts"]==null)
                ViewData["accounts"] = IWSLookUp.GetAccounts();
            return PartialView("GridLookupPartial", ViewData["accounts"]);
        }
        public ActionResult CallbackPanelPartial(string start, string end, string selectedIDs)
        {
            if (string.IsNullOrWhiteSpace(start) || string.IsNullOrWhiteSpace(end))
                return PartialView("_CallbackPartialView");

            Session["Start"] = start;
            Session["End"] = end;
            Session["selectedIDs"] = selectedIDs;
            string company = (string)Session["CompanyID"];
            List<JournalViewModel> model = (List<JournalViewModel>)IWSLookUp.GetJournal(start, end, selectedIDs, company);
            Session["Journal"] = model;
            return PartialView("_CallbackPartialView", model);
        }
        public ActionResult Export()
        {
            var model = Session["Journal"];

            MVCxGridViewState gridViewState = (MVCxGridViewState)Session["gridViewJournal"];

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
            //if (e.FieldName == "Discontinued")
            //{
            //    XRShape control = new XRShape
            //    {
            //        SizeF = e.Owner.SizeF,
            //        LocationF = new PointF(0, 0)
            //    };
            //    e.Owner.Controls.Add(control);

            //    control.Shape = new ShapeStar()
            //    {
            //        StarPointCount = 5,
            //        Concavity = 30
            //    };
            //    control.BeforePrint += new System.Drawing.Printing.PrintEventHandler(BeforePrint);
            //    e.IsModified = true;
            //}
        }
        void CustomizeColumnsCollection(object source, ColumnsCreationEventArgs e)
        {
            e.ColumnsInfo[3].ColumnWidth *= 4;
            e.ColumnsInfo[4].ColumnWidth *= 2;
        }

    }
}