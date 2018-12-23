using System.Web.Mvc;

namespace IWSProject.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CallbackPanelPartial(string itemName)
        {
            ViewBag.ActionName = itemName;
            return PartialView();
        }

    }
}
