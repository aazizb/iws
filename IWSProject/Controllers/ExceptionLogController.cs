using IWSProject.Models;
using System.Web.Mvc;

namespace IWSProject.Controllers
{
    public class ExceptionLogController : Controller
    {
        IWSDataContext db;
        public ExceptionLogController()
        {
            db = new IWSDataContext();
        }
        // GET: ExceptionLog
        public ActionResult Index()
        {
            ViewData["ShowCustomizationWindow"] = true;
            return View(IWSLookUp.GetExceptions());
        }
        [ValidateInput(false)]
        public ActionResult ExceptionsGridViewPartial()
        {
            ViewData["ShowCustomizationWindow"] = true;
            return PartialView(IWSLookUp.GetExceptions());
        }
    }
}