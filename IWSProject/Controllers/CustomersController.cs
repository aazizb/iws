using DevExpress.Web.Mvc;
using IWSProject.Content;
using IWSProject.Models;
using System;
using System.Linq;
using System.Web.Mvc;
namespace IWSProject.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        IWSDataContext db;
        public CustomersController()
        {
            db = new IWSDataContext();
        }

        // GET: Customers
        public ActionResult Index()
        {
            return View(IWSLookUp.GetCustomer());
        }

        [ValidateInput(false)]
        public ActionResult CustomersGridViewPartial()
        {
            return PartialView("CustomersGridViewPartial", IWSLookUp.GetCustomer());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult CustomersGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))]Customer item)
        {
            var model = db.Customers;
            item.CompanyID = (string)Session["CompanyID"];
            ViewData["customer"] = item;
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
                    IWSLookUp.LogException(e);
                }
            }
            else
                ViewData["GenericError"] = IWSLookUp.GetModelSateErrors(ModelState);
            return PartialView("CustomersGridViewPartial", IWSLookUp.GetCustomer());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CustomersGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))]Customer item)
        {
            var model = db.Customers;
            ViewData["customer"] = item;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(i => i.id == item.id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db.SubmitChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["GenericError"] = e.Message;
                    IWSLookUp.LogException(e);
                }
            }
            else
                ViewData["GenericError"] = IWSLookUp.GetModelSateErrors(ModelState);
            return PartialView("CustomersGridViewPartial", IWSLookUp.GetCustomer());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CustomersGridViewPartialDelete(string id)
        {
            var model = db.Customers;
            if (id != null)
            {
                try
                {
                    var item = model.FirstOrDefault(i => i.id == id);
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
            return PartialView("CustomersGridViewPartial", IWSLookUp.GetCustomer());
        }

        [ValidateInput(false)]
        public ActionResult DetailGridViewPartial(string owner)
        {
            return PartialView("DetailGridViewPartial", IWSLookUp.GetBankAccount(owner));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DetailGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] BankAccount line, string owner)
        {
            var model = db.BankAccounts;

            line.Owner = owner;
            line.CompanyID = (string)Session["CompanyID"];
            ViewData["bankAccount"] = line;

            if (ModelState.IsValid)
            {
                try
                {
                    model.InsertOnSubmit(line);

                    db.SubmitChanges();
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
            return PartialView("DetailGridViewPartial", IWSLookUp.GetBankAccount(owner));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DetailGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] BankAccount line, string owner)
        {
            var model = db.BankAccounts;

            line.Owner = owner;

            ViewData["bankAccount"] = line;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(i => i.IBAN == line.IBAN);

                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);

                        db.SubmitChanges();
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
            return PartialView("DetailGridViewPartial", IWSLookUp.GetBankAccount(owner));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DetailGridViewPartialDelete(string iban, string owner)
        {

            var model = db.BankAccounts;

                try
                {
                    var item = model.FirstOrDefault(i => i.IBAN == iban);

                    if (item != null)
                        model.DeleteOnSubmit(item);

                    db.SubmitChanges();
                }
                catch (Exception e)
                {
                    ViewData["GenericError"] = e.Message;
                IWSLookUp.LogException(e);
            }
            return PartialView("DetailGridViewPartial", IWSLookUp.GetBankAccount(owner));
        }
    }
}
