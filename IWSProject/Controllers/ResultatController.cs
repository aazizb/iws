using DevExpress.XtraReports.UI;
using IWSProject.Models;
using IWSProject.Content;
using System.Collections.Generic;
using System.Web.Mvc;

namespace IWSProject.Controllers
{

    [Authorize]
    public class ResultatController : Controller
    {
        // GET: Resultat
        public ActionResult Index()
        {
            ViewData["class"] = IWSLookUp.GetClass();

            return View();
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CallbackPanelPartial(string ClassId, string Start)
        {
            if (string.IsNullOrWhiteSpace(Start))
                return PartialView("_CallbackPartialView");
            try
            {
                string account = IWSLookUp.HasNoParent(Start);
                if (account != "")
                {
                    string message = $"{account} {IWSLocalResource.HasNoParent}";
                    throw new System.Exception(message);
                }
                Session["ClassId"] = ClassId;
                Session["txtStart"] = Start;
                string company = (string)Session["CompanyID"];
                List<ResultsViewModel> resultsView = (List<ResultsViewModel>)IWSLookUp.GetResultat(ClassId, Start, company);
                List<ResultsViewModel> incomesAndBalanceView = (List<ResultsViewModel>)IWSLookUp.GetIncomesAndBalance(ClassId, Start, company);
                IncomesAndBalanceViewModel models = new IncomesAndBalanceViewModel { ResultsView = resultsView, IncomesAndBalanceView = incomesAndBalanceView };
                Session["Results"] = resultsView;
                Session["IncomesAndBalance"] = incomesAndBalanceView;
                return PartialView("_CallbackPartialView");
            }
            catch (System.Exception ex)
            {
                ViewData["GenericError"] = ex.Message;
                IWSLookUp.LogException(ex);
                return PartialView("_CallbackPartialView");
            }
        }

        [ValidateInput(false)]
        public ActionResult IncomesAndBalancePartial()
        {
            string classId = (string)Session["ClassId"];
            string start = (string)Session["txtStart"];
            string company = (string)Session["CompanyID"];
            List<ResultsViewModel> model = (List<ResultsViewModel>)IWSLookUp.GetIncomesAndBalance(classId, start, company);
            return PartialView("IncomesAndBalancePartialView", model);
        }
        [ValidateInput(false)]
        public ActionResult ResultatPartial()
        {
            string classId = (string)Session["ClassId"];
            string start = (string)Session["txtStart"];
            string company = (string)Session["CompanyID"];
            List<ResultsViewModel> model = (List<ResultsViewModel>)IWSLookUp.GetResultat(classId, start, company);
            return PartialView("ResultatPartialView", model);
        }
        [ValidateInput(false)]
        public ActionResult ResultatView()
        {
            Session["Results"] = null;
            Session["IncomesAndBalance"] = null;
            ViewData["class"] = IWSLookUp.GetClass();
            return PartialView();
        }
        public ActionResult Export()
        {
            var model = Session["Results"];

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
            e.ColumnsInfo[0].IsVisible = false;
            e.ColumnsInfo[1].ColumnWidth *= 6;
            e.ColumnsInfo[4].ColumnWidth += 30;
            e.ColumnsInfo[3].ColumnWidth -= 30;
            e.ColumnsInfo[e.ColumnsInfo.Count - 1].IsVisible = true;
        }
    }
}
