using System;
using System.Linq;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using IWSProject.Content;
using IWSProject.Models;
namespace IWSProject.Controllers
{
    [Authorize]
    public class MenuUIController : Controller
    {
        IWSDataContext db;
        public MenuUIController()
        {
            db = new IWSDataContext();
        }

        // GET: MenuUI
        public ActionResult Index()
        {
            return View(IWSLookUp.GetMenus());
        }

        [ValidateInput(false)]
        public ActionResult MenuUIGridViewPartial()
        {
            return PartialView("MenuUIGridViewPartial", IWSLookUp.GetMenus());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult MenuUIGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Menu item)
        {
            var model = db.Menus;
            item.CompanyID = (string)Session["CompanyID"];
            ViewData["menus"] = item;
            if (ModelState.IsValid)
            {
                try
                {
                    model.InsertOnSubmit(item);

                    db.SubmitChanges();
                    return PartialView("MenuUIGridViewPartial", IWSLookUp.GetMenus());
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
            return PartialView("MenuUIGridViewPartial", item);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MenuUIGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Menu item)
        {
            var model = db.Menus;
            ViewData["menus"] = item;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.ID == item.ID);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);

                        db.SubmitChanges();
                        return PartialView("MenuUIGridViewPartial", IWSLookUp.GetMenus());
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
            return PartialView("MenuUIGridViewPartial", item);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MenuUIGridViewPartialDelete(int id)
        {
            var model = db.Menus;
            try
            {
                var item = model.FirstOrDefault(it => it.ID == id);
                if (item != null)
                    model.DeleteOnSubmit(item);

                db.SubmitChanges();
            }
            catch (Exception e)
            {
                ViewData["GenericError"] = e.Message;
                IWSLookUp.LogException(e);
            }
            return PartialView("MenuUIGridViewPartial", IWSLookUp.GetMenus());
        }
    }
}