using IWSProject.Models;
using System.Collections.Generic;
using System.Web.Mvc;


namespace IWSProject.Controllers
{
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
            string end = (string)Session["txtEnd"];
            bool isBalance = (bool)Session["isBalance"];
            string company = (string)Session["CompanyID"];
            List<ResultsViewModel> model = (List<ResultsViewModel>)IWSLookUp.GetResultat(classId, start, end, company, isBalance);
            return PartialView("ResultatPartialView", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CallbackPanelPartial(string ClassId, string Start, string End)
        {
            if (string.IsNullOrWhiteSpace(Start) || string.IsNullOrWhiteSpace(End))
                return PartialView("_CallbackPartialView"); 
            Session["ClassId"] = ClassId;
            Session["txtStart"] = Start;
            Session["txtEnd"] = End;
            bool isBalance = IWSLookUp.IsBalance(ClassId);
            Session["isBalance"] = isBalance;
            string company = (string)Session["CompanyID"];
            List<ResultsViewModel> model = (List<ResultsViewModel>)IWSLookUp.GetResultat(ClassId, Start, End, company, isBalance);
            return PartialView("_CallbackPartialView", model);
        }
    }
}
