using System;
using System.Linq;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using IWSProject.Models;
using IWSProject.Content;
namespace IWSProject.Controllers
{
    [Authorize]
    public class AccountsController : Controller
    {
        IWSDataContext db;
        public AccountsController()
        {
            db = new IWSDataContext();
        }
        // GET: Accounts
        public ActionResult Index()
        {
            return View(IWSLookUp.GetAccount());
        }

        [ValidateInput(false)]
        public ActionResult AccountsGridViewPartial()
        {
            return PartialView("AccountsGridViewPartial", IWSLookUp.GetAccount());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AccountsGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Account item)
        {
            var model = db.Accounts;
            item.CompanyID = (string)Session["CompanyID"];

            ViewData["accounts"] = item;
            if (ModelState.IsValid)
            {
                try
                {
                    model.InsertOnSubmit(item);
                    db.SubmitChanges();
                    return PartialView("AccountsGridViewPartial", IWSLookUp.GetAccount());
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
            return PartialView("AccountsGridViewPartial", item);
                                
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult AccountsGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))]Account item)
        {
            var model = db.Accounts;
            ViewData["accounts"] = item;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db.SubmitChanges();
                        return PartialView("AccountsGridViewPartial", IWSLookUp.GetAccount());
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
            return PartialView("AccountsGridViewPartial", item);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult AccountsGridViewPartialDelete(string id)
        {
            var model = db.Accounts;
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
            return PartialView("AccountsGridViewPartial",   IWSLookUp.GetAccount());
            }
    }
}
