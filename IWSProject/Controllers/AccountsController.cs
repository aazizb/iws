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
            ViewBag.Accounts = IWSLookUp.GetAccount();

            ViewBag.ComboAccountId = IWSLookUp.GetAccounts();

            ViewBag.Journal = IWSLookUp.GetTypeJournal();
      
            return View();
        }

        [ValidateInput(false)]
        public ActionResult AccountsGridViewPartial()
        {
            ViewBag.Acc = IWSLookUp.GetAccount();

            ViewBag.ComboAccountId = IWSLookUp.GetAccounts();

            ViewBag.Journal = IWSLookUp.GetTypeJournal();

            return PartialView("AccountsGridViewPartial", ViewBag.Acc);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AccountsGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Account item)
        {
            var model = db.GetAccounts();
            item.CompanyID = (string)Session["CompanyID"];
            item.ModelId = (int)IWSLookUp.MetaModelId.Account;
            item.Posted = DateTime.Now.Date;
            item.Updated = DateTime.Now.Date;
            item.IsDebit = true;
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
            var model = db.GetAccounts();
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
            var model = db.GetAccounts();
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
        public ActionResult AccountsView()
        {
            return PartialView(IWSLookUp.GetAccount());
        }
    }
}
