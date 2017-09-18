using System;
using System.Linq;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using IWSProject.Models;
using IWSProject.Content;

namespace IWSProject.Controllers
{
    [Authorize]
    public class SettlementsController : Controller
    {
        IWSDataContext db;
        public SettlementsController()
        {
            db = new IWSDataContext();
        }
        // GET: CashInflow
        public ActionResult Index()
        {
            return View(IWSLookUp.GetSettlement());
        }
        [ValidateInput(false)]
        public ActionResult MasterGridViewPartial()
        {
            return PartialView("MasterGridViewPartial", IWSLookUp.GetSettlement());
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
                                        IWSLookUp.DocsType.Settlement.ToString());
                c.ProcessData(items, companyID, false);
            }
            return PartialView("CallbackPanelPartialView", IWSLookUp.GetSettlement());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MasterGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Settlement item)
        {
            var model = db.Settlements;
            item.IsValidated = false;
            item.CompanyId = (string)Session["CompanyID"];
            int itemOID = (int)item.oid;
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
                        int itemID = db.Settlements.Max(i => i.id);

                        result = InsertLines(itemID, itemOID, IWSLookUp.DocsType.Settlement.ToString());
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
            return PartialView("MasterGridViewPartial", IWSLookUp.GetSettlement());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MasterGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Settlement  item)
        {
            var model = db.Settlements;

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
            return PartialView("MasterGridViewPartial", IWSLookUp.GetSettlement());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MasterGridViewPartialDelete(Int32 id)
        {
            var model = db.Settlements;

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
            return PartialView("MasterGridViewPartial", IWSLookUp.GetSettlement());
        }
        [ValidateInput(false)]
        public ActionResult DetailGridViewPartial(int transid)
        {
            return PartialView("DetailGridViewPartial", db.LineSettlements.Where(p => p.transid == transid).ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DetailGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] LineSettlement line, int transId)
        {
            var model = db.LineSettlements;
            line.transid = transId;
            ViewData["lineSettlement"] = line;
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
        public ActionResult DetailGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] LineSettlement linegood, int transId)
        {
            var model = db.LineSettlements;
            ViewData["lineSettlement"] = linegood;
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
            return PartialView("DetailGridViewPartial", db.LineSettlements.Where(p => p.transid == transId).ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DetailGridViewPartialDelete(int Id, int transId)
        {

            var model = db.LineSettlements;

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
            return PartialView("DetailGridViewPartial", db.LineSettlements.Where(p => p.transid == transId).ToList());
        }

        #region Helper
        public ActionResult HeaderText(int selectedItemIndex)
        {
            return Json(IWSLookUp.GetHeaderText(selectedItemIndex, IWSLookUp.DocsType.Settlement.ToString()));
        }
        public ActionResult Supplier(int selectedOIDIndex)
        {
            return Json(IWSLookUp.GetSupplier(selectedOIDIndex, IWSLookUp.DocsType.Settlement.ToString()));
        }
        public ActionResult CostCenter(int selectedOIDIndex)
        {
            return Json(IWSLookUp.GetCostCenter(selectedOIDIndex, IWSLookUp.DocsType.Settlement.ToString()));
        }
        public bool InsertLines(int itemID, int OID, string ItemType)
        {
            bool results = false;

            if (ItemType.Equals(IWSLookUp.DocsType.Settlement.ToString()))
            {
                try
                {
                    var items = IWSLookUp.GetNewLineSettlement(itemID, OID);
                    foreach (var item in items)
                    {
                        db.LineSettlements.InsertOnSubmit((LineSettlement)item);
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
