using DevExpress.Web.Mvc;
using IWSProject.Content;
using IWSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace IWSProject.Controllers
{
    [Authorize]
    public class MasterLogisticController : Controller
    {
        IWSDataContext db;

        public MasterLogisticController()
        {
            db = new IWSDataContext();
        }
        // GET: InventoryInvoices
        public ActionResult Index()
        {
            if (Session["IsVending"] == null)
            {
                Session["IsVending"] = "SU";
            }
            return View(IWSLookUp.GetMasterLogistic(IWSLookUp.LogisticMasterModelId.Default));
        }
        [ValidateInput(false)]
        public ActionResult MasterGridViewPartial()
        {
            int modelId = 0;

            if (Session["ModelId"] != null)
            {
                modelId = (int)Session["ModelId"];

            }
            if (Session["IsVending"] == null)
            {
                Session["IsVending"] = "SU";
            }
            return PartialView("MasterGridViewPartial", IWSLookUp.GetMasterLogistic((IWSLookUp.LogisticMasterModelId)modelId));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CallbackPanelPartialView(string selectedIDs, int modelId)
        {
            Session["ModelId"] = modelId;

            Session["IsVending"] = IsVending(modelId);

            string selectedItems = selectedIDs;

            if (!string.IsNullOrEmpty(selectedItems) && selectedItems != null)
            {
                string companyID = (string)Session["CompanyID"];

                AccountingController c = new AccountingController();

                string items = c.SetDocType(selectedItems,
                                        IWSLookUp.DocsType.InventoryInvoice.ToString());
                c.ProcessData(items, companyID, false);
            }
            return PartialView("CallbackPanelPartialView", IWSLookUp.GetMasterLogistic((IWSLookUp.LogisticMasterModelId)modelId));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MasterGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] MasterLogistic item)
        {
            int modelId = (int)Session["Modelid"];

            if (ModelState.IsValid)
            {
                var model = db.MasterLogistics;
                item.IsValidated = false;
                item.CompanyId = (string)Session["CompanyID"];
                int itemOID = item.oid;
                item.ModelId = modelId;
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
                            int itemID = db.MasterLogistics.Max(i => i.id);

                            result = InsertLines(itemID, itemOID, modelId);
                            if (result)
                            {
                                db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
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
            return PartialView("MasterGridViewPartial", IWSLookUp.GetMasterLogistic((IWSLookUp.LogisticMasterModelId)modelId));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MasterGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] MasterLogistic item)
        {
            var model = db.MasterLogistics;

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
            return PartialView("MasterGridViewPartial", IWSLookUp.GetMasterLogistic(000));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MasterGridViewPartialDelete(int id)
        {
            var model = db.MasterLogistics;

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
            return PartialView("MasterGridViewPartial", IWSLookUp.GetMasterLogistic(000));
        }
        [ValidateInput(false)]
        public ActionResult DetailGridViewPartial(int transId, object newKeyValue)
        {
            if (newKeyValue != null)
            {
                ViewData["IsNewDetailRow"] = true;
            }
            return PartialView("DetailGridViewPartial", IWSLookUp.GetDetailLogistic(transId));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DetailGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] DetailLogistic line, int transId)
        {

            int modelId = (int)Session["Modelid"];

            var model = db.DetailLogistics;

            line.transid = transId;
            line.ModelId = modelId;
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
            return PartialView("DetailGridViewPartial", IWSLookUp.GetDetailLogistic(transId));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DetailGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] DetailLogistic line, int transId)
        {
            var model = db.DetailLogistics;
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
            return PartialView("DetailGridViewPartial", IWSLookUp.GetDetailLogistic(transId));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DetailGridViewPartialDelete(int Id, int transId)
        {

            var model = db.DetailLogistics;

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
            return PartialView("DetailGridViewPartial", IWSLookUp.GetDetailLogistic(transId));
        }

        #region Helper
        public ActionResult PackUnit(string selectedItemIndex)
        {
            return Json(IWSLookUp.GetPackUnit(selectedItemIndex));
        }
        public ActionResult QttyUnit(string selectedItemIndex)
        {
            return Json(IWSLookUp.GetQttyUnit(selectedItemIndex));
        }
        public ActionResult VATCode(string selectedItemIndex)
        {
            return Json(IWSLookUp.GetVatCode(selectedItemIndex));
        }
        public ActionResult Price(string selectedItemIndex)
        {
            return Json(IWSLookUp.GetSalesPrice(selectedItemIndex));
        }
        public ActionResult Currency(string selectedItemIndex)
        {
            return Json(IWSLookUp.GetCurrency(selectedItemIndex));
        }
        public ActionResult HeaderText(int selectedItemIndex)
        {
            return Json(IWSLookUp.GetHeaderText(selectedItemIndex, (int)Session["Modelid"]));
        }
        public ActionResult Store(int selectedOIDIndex)
        {
            return Json(IWSLookUp.GetStore(selectedOIDIndex, (int)Session["Modelid"]));
        }
        public ActionResult Account(int selectedOIDIndex)
        {
            return Json(IWSLookUp.GetAccount(selectedOIDIndex, (int)Session["Modelid"]));
        }
        private bool InsertLines(int itemID, int OID, int modelId)
        {
            bool results = false;

                try
                {
                    if (modelId.Equals(IWSLookUp.LogisticMasterModelId.GoodReceiving))
                    {
                        List<DetailLogistic> items = IWSLookUp.GetNewLineDetailLogistic(itemID, OID,
                                                                (int)IWSLookUp.LogisticMasterModelId.PurchaseOrder);

                        foreach (var item in items)
                        {
                            db.DetailLogistics.InsertOnSubmit(item);
                        }
                        results = true;
                    }
                }
                catch (Exception e)
                {
                    ViewData["GenericError"] = e.Message;
                }
                return results;
        }


        private string IsVending(int modelId)
        {
            if (Math.Round(modelId * 0.01) == 30)
            {
                return "SU";
            }
            if (Math.Round(modelId * 0.01) == 35)
            {
                return "CU";
            }
            return null;
        }

        #endregion

    }
}