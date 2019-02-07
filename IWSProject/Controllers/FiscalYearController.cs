using IWSProject.Models;
using IWSProject.Content;
using System;
using System.Web.Mvc;
namespace IWSProject.Controllers
{
    [Authorize]
    public class FiscalYearController : Controller
    {
        IWSDataContext db;
        public FiscalYearController()
        {
            db = new IWSDataContext();
        }
        // GET: FiscalYear
        [HttpGet]
        public ActionResult Index()
        {
            string companyId = (string)Session["CompanyID"];
            ViewBag.FiscalYear = IWSLookUp.GetFiscalYear(companyId);
            return View(IWSLookUp.GetCurrentFiscalYear(companyId));
        }
        public ActionResult GridViewPartialView()
        {
            string companyId = (string)Session["CompanyID"];
            ViewBag.FiscalYear = IWSLookUp.GetFiscalYear(companyId);
            return PartialView("MasterGridViewPartial", IWSLookUp.GetCurrentFiscalYear(companyId));
        }
        [HttpGet]
        public ActionResult FiscalYearView()
        {
            string companyId = (string)Session["CompanyID"];
            ViewBag.FiscalYear = IWSLookUp.GetFiscalYear(companyId);
            return PartialView(IWSLookUp.GetCurrentFiscalYear(companyId));
        }
        public ActionResult CallbackPanel(string cpCStart, string cpCEnd, string cpOStart, string cpOEnd, string cpNStart, string cpNEnd)
        {
            string companyId = (string)Session["CompanyID"];
            try
            {
                
                int cstart = Convert.ToInt32(cpCStart);
                int cend = Convert.ToInt32(cpCEnd);
                int ostart = Convert.ToInt32(cpOStart);
                int oend = Convert.ToInt32(cpOEnd);
                int nstart = Convert.ToInt32(cpNStart);
                int nend = Convert.ToInt32(cpNEnd);
                string newYearStart = cpNStart;
                string newYearEnd = cpNEnd;
                int dateDiffY = (Convert.ToInt32(newYearEnd.Substring(0, 4)) - Convert.ToInt32(newYearStart.Substring(0, 4))) * 12;
                int dateDiffM = Convert.ToInt32(newYearEnd.Substring(4, 2)) - Convert.ToInt32(newYearStart.Substring(4, 2));
                if (nend > nstart && nstart >= ostart && dateDiffY + dateDiffM < 25)
                {
                    var model = IWSLookUp.CloseCurrentFiscalYear(companyId);
                    IWSLookUp.OpenNewFiscalYear(newYearStart, newYearEnd, companyId, true, true);
                    ViewBag.FiscalYear = IWSLookUp.GetFiscalYears(companyId);
                    return PartialView("CallbackPanel", model);
                }
                else
                {
                    ViewData["GenericError"] = IWSLocalResource.Inadequade;
                }
            }
            catch (Exception ex)
            {
                ViewData["GenericError"] = ex.Message;
                IWSLookUp.LogException(ex);
            }
            return PartialView("CallbackPanel", IWSLookUp.GetCurrentFiscalYear(companyId));
        }
    }
}