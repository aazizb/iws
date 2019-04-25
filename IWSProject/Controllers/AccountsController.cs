using System;
using System.Linq;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using IWSProject.Models;
using IWSProject.Models.Entities;
using IWSProject.Content;
namespace IWSProject.Controllers
{
    [Authorize]
    public class AccountsController : IWSBaseController
    {
        IWSDataContext db;
        public AccountsController()
        {
            db = new IWSDataContext();
        }
        // GET: Accounts
        public ActionResult Index()
        {
      
            return View();
        }

        [ValidateInput(false)]
        public ActionResult AccountsGridViewPartial()
        {
            return PartialView("AccountsGridViewPartial", Session["Accounts"]);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AccountsGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Account item)
        {
            DateTime dateTime = IWSLookUp.GetCurrentDateTime();
            var model = db.GetAccounts();
            item.CompanyID = (string)Session["CompanyID"];
            item.ModelId = (int)IWSLookUp.MetaModelId.Account;
            item.Posted = dateTime;
            item.Updated = dateTime;
            item.IsDebit = true;
            ViewBag.Account = item;
            if (ModelState.IsValid)
            {
                try
                {
                    model.InsertOnSubmit(item);
                    db.SubmitChanges();

                    Session["Accounts"] = IWSLookUp.GetAccount();
                    return PartialView("AccountsGridViewPartial", Session["Accounts"]);
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
            var model = db.GetAccounts();
            ViewBag.Account = item;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db.SubmitChanges();
                        Session["Accounts"] = IWSLookUp.GetAccount();
                        return PartialView("AccountsGridViewPartial", Session["Accounts"]);
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
            var model = db.GetAccounts();
            if (id != null)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.id == id);
                    if (item != null)
                        model.DeleteOnSubmit(item);
                    db.SubmitChanges();
                    Session["Accounts"] = IWSLookUp.GetAccount();
                }
                catch (Exception e)
                {
                    ViewData["GenericError"] = e.Message;
                    IWSLookUp.LogException(e);
                }
            }
            return PartialView("AccountsGridViewPartial", Session["Accounts"]);
        }
        public ActionResult AccountsView()
        {
            return PartialView(Session["Accounts"]);
        }
    }
}
