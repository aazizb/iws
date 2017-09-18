using System;
using System.Linq;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using IWSProject.Models;
using IWSProject.Content;
namespace IWSProject.Controllers
{
    [Authorize]
    public class StoresController : Controller
    {
        IWSDataContext db;
        public StoresController()
        {
            db = new IWSDataContext();
        }

        // GET: stores
        public ActionResult Index()
        {
            return View(IWSLookUp.GetStores());
        }

        [ValidateInput(false)]
        public ActionResult StoresGridViewPartial()
        {
            return PartialView("StoresGridViewPartial", IWSLookUp.GetStores());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult StoresGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))]Store item)
        {
            var model = db.Stores;
            item.CompanyID = (string)Session["CompanyID"];
            ViewData["stores"] = item;
            if (ModelState.IsValid)
            {
                try
                {
                    model.InsertOnSubmit(item);
                    db.SubmitChanges();
                    return PartialView("StoresGridViewPartial", IWSLookUp.GetStores());
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
            return PartialView("StoresGridViewPartial", item);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult StoresGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Store item)
        {
            var model = db.Stores;
            ViewData["stores"] = item;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db.SubmitChanges();
                        return PartialView("StoresGridViewPartial", IWSLookUp.GetStores());
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
            return PartialView("StoresGridViewPartial", item);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult StoresGridViewPartialDelete(string id)
        {
            var model = db.Stores;
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
            return PartialView("StoresGridViewPartial", IWSLookUp.GetStores());
        }
    }
}
