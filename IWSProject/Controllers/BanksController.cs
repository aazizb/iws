using System;
using System.Linq;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using IWSProject.Models;
using IWSProject.Content;
namespace IWSProject.Controllers
{
    [Authorize]
    public class BanksController : Controller
    {
        IWSDataContext db;
        public BanksController()
        {
            db = new IWSDataContext();
        }
        // GET: Banks
        public ActionResult Index()
        {
            return View(IWSLookUp.GetBanks());
        }

        [ValidateInput(false)]
        public ActionResult BanksGridViewPartial()
        {
            return PartialView("BanksGridViewPartial", IWSLookUp.GetBanks());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult BanksGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Bank item)
        {
            var model = db.Banks;
            ViewData["bank"] = item;
            item.CompanyID = (string)Session["CompanyID"];
            if (ModelState.IsValid)
            {
                try
                {
                    model.InsertOnSubmit(item);
                    db.SubmitChanges();
                    return PartialView("BanksGridViewPartial", IWSLookUp.GetBanks());
                }
                catch (Exception e)
                {
                    ViewData["GenericError"] = e.Message;
                    IWSLookUp.LogException(e);
                }
            }
            else
            {
                ViewData["GenericError"] = IWSLookUp.GetModelSateErrors(ModelState);
            }
            return PartialView("BanksGridViewPartial", item);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult BanksGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Bank item)
        {
            var model = db.Banks;
            ViewData["bank"] = item;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db.SubmitChanges();
                        return PartialView("BanksGridViewPartial", IWSLookUp.GetBanks());
                    }
                }
                catch (Exception e)
                {
                    ViewData["GenericError"] = e.Message;
                    IWSLookUp.LogException(e);
                }
            }
            else
            {
                ViewData["GenericError"] = IWSLookUp.GetModelSateErrors(ModelState);
            }
            return PartialView("BanksGridViewPartial", item);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult BanksGridViewPartialDelete(string id)
        {
            var model = db.Banks;
            if (id != null)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.id == id);
                    if (item != null)
                        model.DeleteOnSubmit(item);

                    db.SubmitChanges();
                }
                catch (Exception e)
                {
                    ViewData["GenericError"] = e.Message;
                    IWSLookUp.LogException(e);
                }
            }
            return PartialView("BanksGridViewPartial", IWSLookUp.GetBanks());
        }
    }
}
