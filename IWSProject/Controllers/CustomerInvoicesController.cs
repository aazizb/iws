﻿using DevExpress.Web.Mvc;
using IWSProject.Models;
using IWSProject.Content;
using System;
using System.Linq;
using System.Web.Mvc;

namespace IWSProject.Controllers
{
    [Authorize]
    public class CustomerInvoicesController : Controller
    {
        IWSDataContext db;
        public CustomerInvoicesController()
        {
            db = new IWSDataContext();
        }
        // GET: CustomerInvoices
        public ActionResult Index()
        {
            return View(IWSLookUp.GetCustomerInvoice());
        }
        [ValidateInput(false)]
        public ActionResult MasterGridViewPartial()
        {
            return PartialView("MasterGridViewPartial", IWSLookUp.GetCustomerInvoice());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CallbackPanelPartialView(string selectedIDs)
        {
            string selectedItems = selectedIDs;
            if (!string.IsNullOrEmpty(selectedItems) && selectedItems != null)
            {
                string companyID = (string)Session["CompanyID"];

                AccountingController c = new AccountingController();

                string items = c.SetDocType(selectedItems,
                                        IWSLookUp.DocsType.CustomerInvoice.ToString());
                c.ProcessData(items, companyID, false);
            }
            return PartialView("CallbackPanelPartialView", IWSLookUp.GetCustomerInvoice());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MasterGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] CustomerInvoice item)
        {
            var model = db.CustomerInvoices;
            item.IsValidated = false;
            item.CompanyId = (string)Session["CompanyID"];
            int itemOID = item.oid;
            ViewData["item"] = item;
            bool result;
            if (ModelState.IsValid)
            {
                try
                {
                    model.InsertOnSubmit(item);
                    result = IWSLookUp.CheckPeriod(item.TransDate, item.CompanyId, true, true);
                    if (result)
                    {
                        db.SubmitChanges();
                        if (itemOID != 0)
                        {
                            int itemID = db.CustomerInvoices.Max(i => i.id);

                            result = InsertLines(itemID, itemOID, IWSLookUp.DocsType.CustomerInvoice.ToString());
                            if (result)
                            {
                                db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                            }
                        }
                    }
                    else
                    {
                        ViewBag.NoEval = true;
                        ViewData["GenericError"] = $"{IWSLocalResource.GenericError}! {IWSLocalResource.CheckPeriodKeyIn}";
                    }
                    ViewData["NewKeyValue"] = item.id;
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
            return PartialView("MasterGridViewPartial", IWSLookUp.GetCustomerInvoice());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MasterGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] CustomerInvoice item)
        {
            var model = db.CustomerInvoices;

            ViewData["item"] = item;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
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
            return PartialView("MasterGridViewPartial", IWSLookUp.GetCustomerInvoice());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MasterGridViewPartialDelete(int id)
        {
            var model = db.CustomerInvoices;

            if (id >= 0)
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
                }
            }
            return PartialView("MasterGridViewPartial", IWSLookUp.GetCustomerInvoice());
        }
        [ValidateInput(false)]
        public ActionResult DetailGridViewPartial(int transid, object newKeyValue)
        {
            if (newKeyValue != null)
            {
                ViewData["IsNewDetailRow"] = true;
            }
            return PartialView("DetailGridViewPartial", db.LineCustomerInvoices.Where(p => p.transid == transid).ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DetailGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] LineCustomerInvoice line, int transId)
        {
            var model = db.LineCustomerInvoices;
            line.transid = transId;
            ViewData["line"] = line;
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
                }
            }
            else
            {
                ViewData["GenericError"] = IWSLookUp.GetModelSateErrors(ModelState);
            }
            return PartialView("DetailGridViewPartial", model.Where(p => p.transid == transId).ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DetailGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] LineCustomerInvoice line, int transId)
        {
            var model = db.LineCustomerInvoices;
            line.transid = transId;
            ViewData["line"] = line;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(p => p.id == line.id);

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
            return PartialView("DetailGridViewPartial", db.LineCustomerInvoices.Where(p => p.transid == transId).ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DetailGridViewPartialDelete(int Id, int transId)
        {

            var model = db.LineCustomerInvoices;

            if (Id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.id == Id);

                    if (item != null)
                        model.DeleteOnSubmit(item);

                    db.SubmitChanges();
                }
                catch (Exception e)
                {
                    ViewData["GenericError"] = e.Message;
                }
            }
            return PartialView("DetailGridViewPartial", db.LineCustomerInvoices.Where(p => p.transid == transId).ToList());
        }

        #region Helper
         public ActionResult HeaderText(int selectedItemIndex)
        {
            return Json(IWSLookUp.GetHeaderText(selectedItemIndex, IWSLookUp.DocsType.CustomerInvoice.ToString()));
        }
 
        public ActionResult Supplier(int selectedOIDIndex)
        {
            return Json(IWSLookUp.GetSupplier(selectedOIDIndex, IWSLookUp.DocsType.CustomerInvoice.ToString()));
        }
        public bool InsertLines(int itemID, int OID, string ItemType)
        {
            bool results = false;
            
            if (ItemType.Equals(IWSLookUp.DocsType.CustomerInvoice.ToString()))
            {
                try
                {
                    var items = IWSLookUp.GetNewLineCustomerInvoice(itemID, OID);
                    foreach (var item in items)
                    {
                        db.LineCustomerInvoices.InsertOnSubmit((LineCustomerInvoice)item);
                    }
                    results = true;
                }
                catch (Exception e)
                {
                    ViewData["GenericError"] = e.Message;
                }
            }
            return results;
        }

        #endregion
    }
}
