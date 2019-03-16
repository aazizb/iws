using DevExpress.XtraReports.UI;
using IWSProject.Models;
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
        [ValidateInput(false)]
        public ActionResult ResultatPartial()
        {
            string classId = (string)Session["ClassId"];
            string start = (string)Session["txtStart"];
            //string end = (string)Session["txtEnd"];
            bool isBalance = (bool)Session["isBalance"];
            string company = (string)Session["CompanyID"];
            List<ResultsViewModel> model = (List<ResultsViewModel>)IWSLookUp.GetResultat(classId, start, company, isBalance);//end,
            return PartialView("ResultatPartialView", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CallbackPanelPartial(string ClassId, string Start)//, string End
        {
            if (string.IsNullOrWhiteSpace(Start))// || string.IsNullOrWhiteSpace(End))
                return PartialView("_CallbackPartialView"); 
            Session["ClassId"] = ClassId;
            Session["txtStart"] = Start;
            //Session["txtEnd"] = End;
            bool isBalance = IWSLookUp.IsBalance(ClassId);
            Session["isBalance"] = isBalance;
            string company = (string)Session["CompanyID"];
            List<ResultsViewModel> model = (List<ResultsViewModel>)IWSLookUp.GetResultat(ClassId, Start, company, isBalance);// End, 
            Session["Results"] = model;
            return PartialView("_CallbackPartialView", model);
        }
        public ActionResult ResultatView()
        {
            ViewData["class"] = IWSLookUp.GetClass();
            return PartialView();
        }
        public  ActionResult Export()
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
