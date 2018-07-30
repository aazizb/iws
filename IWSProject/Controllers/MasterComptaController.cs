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
    public class MasterComptaController : IWSBaseController
    {
        public MasterComptaController()
        {
            db = new IWSDataContext();
        }
        // GET: 
        public ActionResult Index()
        {
            if (Session["IsVending"] == null)
            {
                Session["IsVending"] = "SU";
            }
            return View(IWSLookUp.GetMasterCompta(IWSLookUp.ComptaMasterModelId.Default));
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
            return PartialView("MasterGridViewPartial", IWSLookUp.GetMasterCompta((IWSLookUp.ComptaMasterModelId)modelId));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CallbackPanelPartialView(string selectedIDs, int modelId)
        {

            Session["ModelId"] = modelId;

            Session["IsVending"] = IsVending(modelId);

            if (!String.IsNullOrWhiteSpace(selectedIDs) && (modelId > 0))
            {
                string companyID = (string)Session["CompanyID"];

                ProcessData(selectedIDs, companyID, false, modelId);
            }
            return PartialView("CallbackPanelPartialView", IWSLookUp.GetMasterCompta((IWSLookUp.ComptaMasterModelId)modelId));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MasterGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] MasterCompta item)
        {
            int modelId = (int)Session["Modelid"];

            if (ModelState.IsValid)
            {
                var model = db.MasterComptas;
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
                            int itemId = db.MasterComptas.Max(i => i.id);

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
            return PartialView("MasterGridViewPartial", IWSLookUp.GetMasterCompta((IWSLookUp.ComptaMasterModelId)modelId));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MasterGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] MasterCompta item)
        {
            var model = db.MasterComptas;
            int modelId = (int)Session["Modelid"];
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
            return PartialView("MasterGridViewPartial", IWSLookUp.GetMasterCompta((IWSLookUp.ComptaMasterModelId)modelId));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MasterGridViewPartialDelete(int id)
        {
            var model = db.MasterComptas;

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
            return PartialView("MasterGridViewPartial", IWSLookUp.GetMasterCompta((IWSLookUp.ComptaMasterModelId)modelId));
        }
        [ValidateInput(false)]
        public ActionResult DetailGridViewPartial(int transId, object newKeyValue)
        {
            if (newKeyValue != null)
            {
                ViewData["IsNewDetailRow"] = true;
            }
            ViewBag.DefaultCurrency = IWSLookUp.GetCurrencyDefault();

            return PartialView("DetailGridViewPartial", IWSLookUp.GetDetailCompta(transId));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DetailGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] DetailCompta line, int transId)
        {

            int modelId = (int)Session["Modelid"];

            var model = db.DetailComptas;

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
            return PartialView("DetailGridViewPartial", IWSLookUp.GetDetailCompta(transId));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DetailGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] DetailCompta line, int transId)
        {
            var model = db.DetailComptas;
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
            return PartialView("DetailGridViewPartial", IWSLookUp.GetDetailCompta(transId));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DetailGridViewPartialDelete(int Id, int transId)
        {

            var model = db.DetailComptas;

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
            return PartialView("DetailGridViewPartial", IWSLookUp.GetDetailCompta(transId));
        }

        #region Helper
        public ActionResult HeaderText(int selectedOIDIndex)
        {
            return Json(IWSLookUp.GetHeaderText(selectedOIDIndex, (int)Session["ModelId"]));
        }
        public ActionResult CostCenter(int selectedOIDIndex)
        {
            return Json(IWSLookUp.GetCostCenter(selectedOIDIndex, (int)Session["ModelId"]));
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
                var items = IWSLookUp.GetNewLineDetailCompta(itemId, OID, modelId);

                foreach (var item in items)
                {
                    db.DetailComptas.InsertOnSubmit((DetailCompta)item);
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
            if (Math.Round(modelId * 0.01) == 50)
            {
                return "SU";
            }
            if (Math.Round(modelId * 0.01) == 55)
            {
                return "CU";
            }
            if (Math.Round(modelId * 0.01) == 58)
            {
                return "GL";
            }
            return null;
        }
        #endregion
    }
}