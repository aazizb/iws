using DevExpress.Web.Mvc;
using IWSProject.Content;
using IWSProject.Models;
using IWSProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace IWSProject.Controllers
{
    [Authorize]
    public class MasterLogisticController : IWSBaseController
    {
        // GET: 
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
            int modelId = (int)IWSLookUp.LogisticMasterModelId.Default;

            if (Session["IsVending"] == null)
            {
                Session["IsVending"] = "SU";
            }
            if (Session["ModelId"] != null)
            {
                modelId = (int)Session["ModelId"];
                Session["IsVending"] = IsVending(modelId);
            }

            Session["ComboOwner"] = IWSLookUp.GetOwners((string)Session["IsVending"]);

            if (Session["LogisticOID"] == null)
            {
                Session["LogisticOID"] = IWSLookUp.GetMasterLogisticOID();
            }

            Session["MasterLogistic"] = IWSLookUp.GetMasterLogistic((IWSLookUp.LogisticMasterModelId)modelId);
            return PartialView(Session["MasterLogistic"]);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CallbackPanelPartialView(string selectedIDs, int currentModelId)
        {
            Session["ModelId"] = currentModelId;

            Session["IsVending"] = IsVending(currentModelId);

            Session["ComboOwner"] = IWSLookUp.GetOwners((string)Session["IsVending"]);

            if (!String.IsNullOrWhiteSpace(selectedIDs) && (currentModelId > 0))
            {
                string companyID = (string)Session["CompanyID"];

                ProcessData(selectedIDs, companyID, false, currentModelId);
            }
            Session["MasterLogistic"] = IWSLookUp.GetMasterLogistic((IWSLookUp.LogisticMasterModelId)currentModelId);
            return PartialView(Session["MasterLogistic"]);
        }
        public ActionResult CustomGridViewCallback(bool isChecked)
        {
            ViewBag.select = isChecked;
            int modelId = (int)IWSLookUp.ComptaMasterModelId.Default;
            if (Session["ModelId"] != null)
            {
                modelId = (int)Session["ModelId"];
            }
            return PartialView("MasterGridViewPartial", IWSLookUp.GetMasterLogistic((IWSLookUp.LogisticMasterModelId)modelId));
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
                ViewBag.MasterLogistic = item;
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
                            int itemId = db.MasterLogistics.Max(i => i.id);

                            result = InsertLines(itemId, itemOID, modelId);
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
            int modelId = (int)Session["Modelid"];
            ViewBag.MasterLogistic = item;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        UpdateModel(modelItem);
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
            return PartialView("MasterGridViewPartial", IWSLookUp.GetMasterLogistic((IWSLookUp.LogisticMasterModelId)modelId));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MasterGridViewPartialDelete(int id)
        {
            var model = db.MasterLogistics;

            int modelId = (int)Session["Modelid"];

            if (id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.id == id);
                    if (item != null)
                    {
                        model.DeleteOnSubmit(item);
                        db.SubmitChanges();
                    }

                }
                catch (Exception e)
                {
                    ViewData["GenericError"] = e.Message;
                }
            }
            return PartialView("MasterGridViewPartial", IWSLookUp.GetMasterLogistic((IWSLookUp.LogisticMasterModelId)modelId));
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
        public ActionResult LogisticView()
        {
            return PartialView(IWSLookUp.GetMasterLogistic(IWSLookUp.LogisticMasterModelId.Default));
        }

        #region Helper
        public ActionResult PackUnit(string selectedIndex)
        {
            return Json(IWSLookUp.GetPackUnit(selectedIndex));
        }
        public ActionResult VATCode(string selectedIndex)
        {
            return Json(IWSLookUp.GetVatCode(selectedIndex));
        }
        public ActionResult Price(string selectedIndex)
        {
            return Json(IWSLookUp.GetSalesPrice(selectedIndex));
        }
        public ActionResult Currency(string selectedIndex)
        {
            return Json(IWSLookUp.GetCurrency(selectedIndex));
        }
        public ActionResult HeaderText(int selectedOIDIndex)
        {
            return Json(IWSLookUp.GetHeaderText(selectedOIDIndex, (int)Session["ModelId"]));
        }
        public ActionResult Store(int selectedOIDIndex)
        {
            return Json(IWSLookUp.GetStore(selectedOIDIndex));
        }
        public ActionResult Account(int selectedOIDIndex)
        {
            return Json(IWSLookUp.GetAccount(selectedOIDIndex, (int)Session["ModelId"]));
        }
        private bool InsertLines(int itemId, int OID, int modelId)
        {
            bool results = false;

                try
                {
                    var items = IWSLookUp.GetNewLineDetailLogistic(itemId, OID, modelId);

                    foreach (var item in items)
                    {
                        db.DetailLogistics.InsertOnSubmit((DetailLogistic)item);
                    }
                    results = true;
                }
                catch (Exception e)
                {
                    ViewData["GenericError"] = e.Message;
                }
                return results;
        }
        private string IsVending(int modelId)
        {
            if (modelId.Equals((int)IWSLookUp.LogisticMasterModelId.SalesOrder) ||
                modelId.Equals((int)IWSLookUp.LogisticMasterModelId.BillOfDelivery) ||
                modelId.Equals((int)IWSLookUp.LogisticMasterModelId.SalesInvoice))
                {
                return "CU";
                }
            if (modelId.Equals((int)IWSLookUp.LogisticMasterModelId.PurchaseOrder) ||
                modelId.Equals((int)IWSLookUp.LogisticMasterModelId.GoodReceiving) ||
                modelId.Equals((int)IWSLookUp.LogisticMasterModelId.InventoryInvoice))
                {
                    return "SU";
                }
            return null;
        }
        #endregion
    }
}