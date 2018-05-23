﻿using DevExpress.Web.Mvc;
using IWSProject.Content;
using IWSProject.Models;
using System;
using System.Linq;
using System.Web.Mvc;
namespace IWSProject.Controllers
{
    [Authorize]
    public class VendorInvoicesController : Controller
    {
        IWSDataContext db;
        public VendorInvoicesController()
        {
            db = new IWSDataContext();
        }
        // GET: VendorInvoices
        public ActionResult Index(string MenuID)
        {
            Session["MenuID"] = MenuID;
            return View(IWSLookUp.GetVendorInvoice());
        }
        [ValidateInput(false)]
        public ActionResult MasterGridViewPartial()
        {
            return PartialView("MasterGridViewPartial", IWSLookUp.GetVendorInvoice());
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
                                        IWSLookUp.DocsType.VendorInvoice.ToString());
                c.ProcessData(items, companyID, false);
            }
            return PartialView("CallbackPanelPartialView", IWSLookUp.GetVendorInvoice());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MasterGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] VendorInvoice item)
        {
            if (ModelState.IsValid)
            {
                var model = db.VendorInvoices;
                item.IsValidated = false;
                item.CompanyId = (string)Session["CompanyID"];
                int itemOID = item.oid;
                ViewData["item"] = item;
                bool result = false;
                try
                {
                    model.InsertOnSubmit(item);
                    result = IWSLookUp.CheckPeriod(item.TransDate, item.CompanyId, true, true);
                    if (result)
                    {
                        db.SubmitChanges();
                        if (itemOID != 0)
                        {
                            int itemID = db.VendorInvoices.Max(i => i.id);

                            result = InsertLines(itemID, itemOID, IWSLookUp.DocsType.VendorInvoice.ToString());
                            if (result)
                            {
                                db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                                result = IWSLookUp.SetTypeJournal(IWSLookUp.DocsType.VendorInvoice.ToString(), itemID);
                            }
                        }
                    }
                    else
                    {
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
            return PartialView("MasterGridViewPartial", IWSLookUp.GetVendorInvoice());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MasterGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] VendorInvoice item)
        {
            var model = db.VendorInvoices;

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
            return PartialView("MasterGridViewPartial", IWSLookUp.GetVendorInvoice());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MasterGridViewPartialDelete(int id)
        {
            var model = db.VendorInvoices;

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
            return PartialView("MasterGridViewPartial", IWSLookUp.GetVendorInvoice());
        }
        [ValidateInput(false)]
        public ActionResult DetailGridViewPartial(int transid, object newKeyValue)
        {
            if (newKeyValue != null)
            {
                ViewData["IsNewDetailRow"] = true;
            }
            ViewBag.DefaultCurrency = IWSLookUp.GetCurrencyDefault();
            return PartialView("DetailGridViewPartial", db.LineVendorInvoices.Where(p => p.transid == transid).ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DetailGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] LineVendorInvoice line, int transId)
        {
            var model = db.LineVendorInvoices;
            line.transid = transId;
            ViewData["line"] = line;
            if (ModelState.IsValid)
            {
                try
                {
                    model.InsertOnSubmit(line);
                    db.SubmitChanges();
                    bool result = IWSLookUp.SetTypeJournal(IWSLookUp.DocsType.VendorInvoice.ToString(), transId);
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
        public ActionResult DetailGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] LineVendorInvoice line, int transId)
        {
            var model = db.LineVendorInvoices;
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
                        bool result = IWSLookUp.SetTypeJournal(IWSLookUp.DocsType.VendorInvoice.ToString(), transId);
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
            return PartialView("DetailGridViewPartial", db.LineVendorInvoices.Where(p => p.transid == transId).ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DetailGridViewPartialDelete(int Id, int transId)
        {

            var model = db.LineVendorInvoices;

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
            return PartialView("DetailGridViewPartial", db.LineVendorInvoices.Where(p => p.transid == transId).ToList());
        }

        #region Helper
        public ActionResult HeaderText(int selectedOIDIndex)
        {
            return Json(IWSLookUp.GetHeaderText(selectedOIDIndex, IWSLookUp.DocsType.VendorInvoice.ToString()));
        }
        public ActionResult Supplier(int selectedOIDIndex)
        {
            return Json(IWSLookUp.GetSupplier(selectedOIDIndex, IWSLookUp.DocsType.VendorInvoice.ToString()));
        }
        public ActionResult TypeJournal(int selectedOIDIndex)
        {
            return Json(IWSLookUp.GetTypeJournal(selectedOIDIndex, IWSLookUp.DocsType.VendorInvoice.ToString()));
        }
        public ActionResult AccountingAccount(int selectedOIDIndex)
        {
            return Json(IWSLookUp.GetAccount(selectedOIDIndex, IWSLookUp.DocsType.VendorInvoice.ToString()));
        }
        public ActionResult GetCompteTier(string selectedSupplierId)
        {
            return Json(IWSLookUp.GetCompteTier(selectedSupplierId, IWSLookUp.DocsType.VendorInvoice.ToString()));
        }
        public bool InsertLines(int itemID, int OID, string ItemType)
        {
            bool results = false;

            if (ItemType.Equals(IWSLookUp.DocsType.VendorInvoice.ToString()))
            {
                try
                {
                    var items = IWSLookUp.GetNewLineVendorInvoice(itemID, OID);
                    foreach (var item in items)
                    {
                        db.LineVendorInvoices.InsertOnSubmit((LineVendorInvoice)item);
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