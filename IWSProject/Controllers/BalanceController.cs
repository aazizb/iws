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
            string selectedIDs = (string)Session["selectedIDs"];
            string company = (string)Session["CompanyID"];
            List<AccountBalanceViewModel> model = (List<AccountBalanceViewModel>)IWSLookUp.GetAccountBalance(selectedIDs, company);
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
        public ActionResult CallbackPanelPartial(string selectedIDs)
        {
            Session["selectedIDs"] = selectedIDs;
            string company = (string)Session["CompanyID"];
            List<AccountBalanceViewModel> model = (List<AccountBalanceViewModel>)IWSLookUp.GetAccountBalance(selectedIDs, company);
            return PartialView("_CallbackPartialView", model);
        }
    }
}