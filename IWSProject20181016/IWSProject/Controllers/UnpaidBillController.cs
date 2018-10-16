using IWSProject.Models;
using System.Web.Mvc;

namespace IWSProject.Controllers
{
    public class UnpaidBillController : Controller
    {
        // GET: 
        public ActionResult Index()
        {
            return View(IWSLookUp.GetUnPaidBill((int)IWSLookUp.ComptaMasterModelId.Default,true));
        }
        [ValidateInput(false)]
        public ActionResult MasterGridViewPartial()
        {
            int modelId = (int)IWSLookUp.ComptaMasterModelId.Default;
            if (Session["ModelId"] != null)
            {
                modelId = (int)Session["ModelId"];
            }
            return PartialView("MasterGridViewPartial",
                            IWSLookUp.GetUnPaidBill((IWSLookUp.ComptaMasterModelId)modelId, true));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CallbackPanelPartialView(int currentModelId, bool balanced)
        {
            Session["ModelId"] = currentModelId;
            return PartialView("CallbackPanelPartialView",
                            IWSLookUp.GetUnPaidBill((IWSLookUp.ComptaMasterModelId)currentModelId, balanced));
        }
    }
}