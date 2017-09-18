using System;
using System.Linq;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using IWSProject.Models;
using IWSProject.Content;
namespace IWSProject.Controllers
{
    [Authorize]
    [HandleError()]
    public class BankAccountsController : Controller
    {
        IWSDataContext db;
        public BankAccountsController()
        {
            db = new IWSDataContext();
        }
        // GET: bankaccounts
        public ActionResult Index()
        {
            return View(db.BankAccounts.Where(c => c.CompanyID == (string)Session["CompanyID"]));
        }

        [ValidateInput(false)]
        public ActionResult BankAccountsGridViewPartial()
        {
            return PartialView("BankAccountsGridViewPartial", db.BankAccounts.Where(c => c.CompanyID == (string)Session["CompanyID"]));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult BankAccountsGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] BankAccount item)
        {
            var model = db.BankAccounts;
            item.CompanyID = (string)Session["CompanyID"];
            ViewData["bankAccount"] = item;
            if (ModelState.IsValid)
            {
                try
                {
                    model.InsertOnSubmit(item);
                    db.SubmitChanges();
                }
                catch (Exception e)
                {
                    ViewData["GenericError"] = e.Message;
                }
            }
            else
            {
                ViewData["GenericError"] = IWSLookUp.GetModelSateErrors(ModelState);
            }
            return PartialView("BankAccountsGridViewPartial", db.BankAccounts.Where(c => c.CompanyID == (string)Session["CompanyID"]));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult BankAccountsGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] BankAccount item)
        {
            var model = db.BankAccounts;
            ViewData["bankAccount"] = item;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.IBAN == item.IBAN);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db.SubmitChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["GenericError"] = e.Message;
                }
            }
            else
            {
                ViewData["GenericError"] = IWSLookUp.GetModelSateErrors(ModelState);
            }
            return PartialView("BankAccountsGridViewPartial", db.BankAccounts.Where(c => c.CompanyID == (string)Session["CompanyID"]));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult BankAccountsGridViewPartialDelete(string iban)
        {
            var model = db.BankAccounts;
            if (iban != null)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.IBAN == iban);
                    if (item != null)
                        model.DeleteOnSubmit(item);

                    db.SubmitChanges();
                }
                catch (Exception e)
                {
                    ViewData["GenericError"] = e.Message;
                }
            }
            return PartialView("BankAccountsGridViewPartial", db.BankAccounts.Where(c => c.CompanyID == (string)Session["CompanyID"]));
        }
    }
}
