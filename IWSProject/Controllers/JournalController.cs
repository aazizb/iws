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
            return PartialView("_CallbackPartialView", model);
        }
    }
}