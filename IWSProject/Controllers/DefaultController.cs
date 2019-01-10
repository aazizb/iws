using DevExpress.Web.Mvc;
using IWSProject.Models;
using System;
using System.Web.Mvc;

namespace IWSProject.Controllers
{
    public class DefaultController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            string companyId = (string)Session["CompanyID"];
            ViewBag.FiscalYear = IWSLookUp.GetFiscalYear(companyId);
            return View();//ViewBag.FiscalYear);// IWSLookUp.GetCurrentFiscalYear(companyId));
        }
        public ActionResult GridViewPartialView()
        {
            string companyId = (string)Session["CompanyID"];
            try
            {
                int cstart = Convert.ToInt32(Request.Params["cpCStart"]);
                int cend = Convert.ToInt32(Request.Params["cpCEnd"]);
                int ostart = Convert.ToInt32(Request.Params["cpOStart"]);
                int oend = Convert.ToInt32(Request.Params["cpOEnd"]);
                int nstart = Convert.ToInt32(Request.Params["cpNStart"]);
                int nend = Convert.ToInt32(Request.Params["cpNEnd"]);
                string newYearStart = Request.Params["cpNStart"];
                string newYearEnd = Request.Params["cpNEnd"];
                if (nend >= nstart && nstart > cend && nend - nstart < 26)
                {
                    var model = IWSLookUp.CloseCurrentFiscalYear(companyId);
                    IWSLookUp.OpenNewFiscalYear(newYearStart, newYearEnd, companyId, true, true);
                    ViewBag.FiscalYear = IWSLookUp.GetFiscalYears(companyId);
                    return PartialView("Index", model);
                }
            }
            catch (Exception ex)
            {
                ViewData["GenericError"] = ex.Message;
                IWSLookUp.LogException(ex);
            }
            return PartialView("PopupPartialView", IWSLookUp.GetCurrentFiscalYear(companyId));
        }
        public ActionResult CallbackPanelPartial()
        {
            return PartialView("_CallbackPanelPartial");
        }
    }
}