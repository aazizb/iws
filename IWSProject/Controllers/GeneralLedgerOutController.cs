using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IWSProject.Models;
using IWSProject.Content;
using DevExpress.Web.Mvc;

namespace IWSProject.Controllers
{
    [Authorize]
    public class GeneralLedgerOutController : Controller
    {
        IWSDataContext db;
        public GeneralLedgerOutController()
        {
            db = new IWSDataContext();
        }
        // GET: GeneralLedgers
        public ActionResult Index()
        {
            return View(IWSLookUp.GetGeneralLedger(IWSLookUp.Area.GeneralLedger.ToString()));
        }
        [ValidateInput(false)]
        public ActionResult MasterGridViewPartial()
        {
            return PartialView("MasterGridViewPartial", IWSLookUp.GetGeneralLedger(IWSLookUp.Area.GeneralLedger.ToString()));
        }
        public ActionResult CallbackPanelPartialView(string selectedIDs)
        {
            string selectedItems = selectedIDs;
            if (!string.IsNullOrEmpty(selectedItems) && selectedItems != null)
            {
                string companyID = (string)Session["CompanyID"];

                AccountingController c = new AccountingController();

                string items = c.SetDocType(selectedItems,
                                        IWSLookUp.DocsType.GeneralLedger.ToString());
                c.ProcessData(items, companyID, false);
            }
            return PartialView("CallbackPanelPartialView", IWSLookUp.GetGeneralLedger(IWSLookUp.Area.GeneralLedger.ToString()));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MasterGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] GeneralLedger item)
        {
            var model = db.GeneralLedgers;
            item.IsValidated = false;
            item.CompanyId = (string)Session["CompanyID"];
            int itemOID = item.oid;
            item.Area = IWSLookUp.Area.GeneralLedger.ToString();
            ViewData["item"] = item;
            bool result;
            if (ModelState.IsValid)
            {
                try
                {
                    model.InsertOnSubmit(item);
                    db.SubmitChanges();
                    if (itemOID != 0)
                    {
                        int itemID = db.GeneralLedgers.Max(i => i.id);

                        result = InsertLines(itemID, itemOID, IWSLookUp.DocsType.GeneralLedgerOut.ToString());
                        if (result)
                            db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
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
            return PartialView("MasterGridViewPartial", IWSLookUp.GetGeneralLedger(IWSLookUp.Area.GeneralLedger.ToString()));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MasterGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] GeneralLedger item)
        {
            var model = db.GeneralLedgers;

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
            return PartialView("MasterGridViewPartial", IWSLookUp.GetGeneralLedger(IWSLookUp.Area.GeneralLedger.ToString()));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MasterGridViewPartialDelete(Int32 id)
        {
            var model = db.GeneralLedgers;

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
            return PartialView("MasterGridViewPartial", IWSLookUp.GetGeneralLedger(IWSLookUp.Area.GeneralLedger.ToString()));
        }
        [ValidateInput(false)]
        public ActionResult DetailGridViewPartial(int transid)
        {
            return PartialView("DetailGridViewPartial", db.LineGeneralLedgers.Where(p => p.transid == transid).ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DetailGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] LineGeneralLedger line, int transId)
        {
            var model = db.LineGeneralLedgers;

            line.transid = transId;
            ViewData["lineGeneralLedger"] = line;
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
        public ActionResult DetailGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] LineGeneralLedger linegood, int transId)
        {
            var model = db.LineGeneralLedgers;
            ViewData["lineGeneralLedger"] = linegood;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(p => p.id == linegood.id);

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
            return PartialView("DetailGridViewPartial", db.LineGeneralLedgers.Where(p => p.transid == transId).ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DetailGridViewPartialDelete(int Id, int transId)
        {

            var model = db.LineGeneralLedgers;

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
            return PartialView("DetailGridViewPartial", db.LineGeneralLedgers.Where(p => p.transid == transId).ToList());
        }

        #region Helper
        public ActionResult HeaderText(int selectedItemIndex)
        {
            return Json(IWSLookUp.GetHeaderText(selectedItemIndex, IWSLookUp.DocsType.GeneralLedgerOut.ToString()));
        }
        public ActionResult CostCenter(int selectedOIDIndex)
        {
            return Json(IWSLookUp.GetCostCenter(selectedOIDIndex, IWSLookUp.DocsType.GeneralLedgerOut.ToString()));
        }
        public bool InsertLines(int itemID, int OID, string ItemType)
        {
            bool results = false;

            if (ItemType.Equals(IWSLookUp.DocsType.GeneralLedgerOut.ToString()))
            {
                try
                {
                    var items = IWSLookUp.GetNewGeneralLedgerOut(itemID, OID);
                    foreach (var item in items)
                    {
                        db.LineGeneralLedgers.InsertOnSubmit((LineGeneralLedger)item);
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