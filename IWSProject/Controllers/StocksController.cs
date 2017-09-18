using System.Collections.Generic;
using System.Web.Mvc;
using IWSProject.Models;

namespace IWSProject.Controllers
{
    [Authorize]
    public class StocksController : Controller
    {
        IWSDataContext db;
        public StocksController()
        {
            db = new IWSDataContext();
        }

        // GET: Stocks
        public ActionResult Index()
        {
            var SV = IWSLookUp.GetStock((string)Session["CompanyID"]);
            var model = new List<StockViewModel>();
            foreach (StockViewModel item in SV)
            {
                model.Add(item);
            }
            return View(model);
        }
        [ValidateInput(false)]
        public ActionResult StocksPartialView()
        {
            var SV = IWSLookUp.GetStock((string)Session["CompanyID"]);
            var model = new List<StockViewModel>();
            foreach (StockViewModel item in SV)
            {
                model.Add(item);
            }
            return PartialView(model);
        }
    }
}
