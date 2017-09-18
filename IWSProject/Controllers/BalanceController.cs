using System.Collections.Generic;
using System.Web.Mvc;
using IWSProject.Models;

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
            string start = (string)Session["Start"];
            string end = (string)Session["End"];
            bool detail = (bool)Session["Detail"];
            string company = (string)Session["CompanyID"];
            List<AccountBalanceViewModel> model = (List<AccountBalanceViewModel>)IWSLookUp.GetAccountBalance(start, end, detail, company);
            return PartialView("AccountBalancePartialView",model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CallbackPanelPartial(string start, string end, bool detail)
        {
            if (string.IsNullOrWhiteSpace(start) || string.IsNullOrWhiteSpace(end))
                return PartialView("_CallbackPartialView");

            Session["Start"] = start;
            Session["End"] = end;
            Session["Detail"] = detail;
            string company = (string)Session["CompanyID"];
            List<AccountBalanceViewModel> model = (List<AccountBalanceViewModel>)IWSLookUp.GetAccountBalance(start, end, detail, company);
            return PartialView("_CallbackPartialView", model);
        }
    }
}