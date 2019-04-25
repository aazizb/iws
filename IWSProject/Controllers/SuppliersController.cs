using DevExpress.Web.Mvc;
using IWSProject.Models;
using IWSProject.Models.Entities;
using System;
using System.Linq;
using System.Web.Mvc;
namespace IWSProject.Controllers
{
    [Authorize]
    public class SuppliersController : Controller
    {
        IWSDataContext db;
        public SuppliersController()
        {
            db = new IWSDataContext();
        }

        // GET: suppliers
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult SuppliersGridViewPartial()
        {
            return PartialView(Session["Suppliers"]);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult SuppliersGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Supplier item)
        {
            var model = db.Suppliers;
            item.CompanyID = (string)Session["CompanyID"];
            item.ModelId = (int)IWSLookUp.MetaModelId.Supplier;
            DateTime dateTime = IWSLookUp.GetCurrentDateTime();
            item.Posted = dateTime;
            item.Updated = dateTime;
            ViewBag.Supplier = item;
            if (ModelState.IsValid)
            {
                try
                {
                    model.InsertOnSubmit(item);
                    db.SubmitChanges();
                    Session["Suppliers"] = IWSLookUp.GetSupplier();
                    return PartialView("SuppliersGridViewPartial", Session["Suppliers"]);
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
            return PartialView("SuppliersGridViewPartial", item);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult SuppliersGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))]Supplier item)
        {
            var model = db.Suppliers;
            ViewBag.Supplier = item;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db.SubmitChanges();
                        Session["Suppliers"] = IWSLookUp.GetSupplier();
                        return PartialView("SuppliersGridViewPartial", Session["Suppliers"]);
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
            return PartialView("SuppliersGridViewPartial", item);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult SuppliersGridViewPartialDelete(string id)
        {
            var model = db.Suppliers;
            if (id != null)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.id == id);
                    if (item != null)
                        model.DeleteOnSubmit(item);
                    db.SubmitChanges();
                    Session["Suppliers"] = IWSLookUp.GetSupplier();
                }
                catch (Exception e)
                {
                    ViewData["GenericError"] = e.Message;
                }
            }
            return PartialView("SuppliersGridViewPartial", Session["Suppliers"]);
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

            ViewBag.BankAccount = line;

            if (ModelState.IsValid)
            {
                try
                {
                    model.InsertOnSubmit(line);

                    db.SubmitChanges();
                    return PartialView("DetailGridViewPartial", IWSLookUp.GetBankAccount(owner));
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
            return PartialView("DetailGridViewPartial", line);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DetailGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] BankAccount line, string owner)
        {
            var model = db.BankAccounts;

            line.Owner = owner;

            ViewBag.BankAccount = line;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(i => i.IBAN == line.IBAN);

                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);

                        db.SubmitChanges();
                        return PartialView("DetailGridViewPartial", IWSLookUp.GetBankAccount(owner));
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
            return PartialView("DetailGridViewPartial", line);
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

        public ActionResult SupplierView()
        {
            if (Session["ComboAccounts"] == null)
            {
                Session["ComboAccounts"] = IWSLookUp.GetAccounts();
            }
            if(Session["Suppliers"] == null)
            Session["Suppliers"] = IWSLookUp.GetSupplier();
            return PartialView(Session["Suppliers"]);
        }
    }
}
