using DevExpress.Web.Mvc;
using IWSProject.Content;
using IWSProject.Models;
using IWSProject.Models.Entities;
using System;
using System.Data;
using System.Data.Linq;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.Mvc;

namespace IWSProject.Controllers
{

    [Authorize]
    public class MasterComptaController : IWSBaseController
    {
        #region Master
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
            int modelId = (int)IWSLookUp.ComptaMasterModelId.Default;
            if (Session["ModelId"] != null)
            {
                modelId = (int)Session["ModelId"];

                bool show = (modelId.Equals((int)IWSLookUp.ComptaMasterModelId.Payment) ||
                                          modelId.Equals((int)IWSLookUp.ComptaMasterModelId.Settlement)) ? true : false;
                Session["ShowDetail"] = show;
            }
            if (Session["IsVending"] == null)
            {
                Session["IsVending"] = "SU";
            }
            return PartialView("MasterGridViewPartial", 
                        IWSLookUp.GetMasterCompta((IWSLookUp.ComptaMasterModelId)modelId));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CallbackPanelPartialView(string selectedIDs, int currentModelId)
        {
            Session["ModelId"] = currentModelId;
            Session["IsVending"] = IsVending(currentModelId);
            if (!String.IsNullOrWhiteSpace(selectedIDs) && (currentModelId > 0))
            {
                string companyID = (string)Session["CompanyID"];
                ProcessData(selectedIDs, companyID, false, currentModelId);
            }
            return PartialView("CallbackPanelPartialView", 
                    IWSLookUp.GetMasterCompta((IWSLookUp.ComptaMasterModelId)currentModelId));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MasterGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] MasterCompta item)
        {
            int modelId = (int)Session["Modelid"];
            var model = db.MasterComptas;
            if (ModelState.IsValid)
            {
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
                                result = InsertDetailsDetails( itemOID, modelId);
                            }
                            if (result)
                            {
                                db.SubmitChanges(ConflictMode.FailOnFirstConflict);
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
            return PartialView("MasterGridViewPartial", 
                        IWSLookUp.GetMasterCompta((IWSLookUp.ComptaMasterModelId)modelId));
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
                    if (model != null)
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
            return PartialView("MasterGridViewPartial",
                                IWSLookUp.GetMasterCompta((IWSLookUp.ComptaMasterModelId)modelId));
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
            return PartialView("MasterGridViewPartial",
                                IWSLookUp.GetMasterCompta((IWSLookUp.ComptaMasterModelId)modelId));
        }
        #endregion

        #region Detail
        [ValidateInput(false)]
        public ActionResult DetailGridViewPartial(int transId, object newKeyValue)
        {
            Session["MasterComptaOID"] = IWSLookUp.GetMasterComptaOID(transId);
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
                    IWSLookUp.SetJournal(transId);
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
                        IWSLookUp.SetJournal(transId);
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
                    IWSLookUp.SetJournal(transId);
                }
                catch (Exception e)
                {
                    ViewData["GenericError"] = e.Message;
                }
            }
            return PartialView("DetailGridViewPartial", IWSLookUp.GetDetailCompta(transId));
        }
        #endregion

        #region DetailDetail
        [ValidateInput(false)]
        public ActionResult DetailDetailGridViewPartial(int transId)
        {
            int modelId = (int)Session["Modelid"];
            return PartialView("DetailDetailGridViewPartial", IWSLookUp.GetDetailDetailCompta(transId, modelId));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DetailDetailGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] DetailDetailCompta line, int transId)
        {
            decimal leftToPay = IWSLookUp.GetLeftToPay(line.OID);
            int modelId = (int)Session["Modelid"];
            var model = db.DetailDetailComptas;
            line.TransId = transId;
            line.ModelId = modelId;
            ViewData["lineDetail"] = line;
            if (leftToPay >= line.Amount)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        model.InsertOnSubmit(line);
                        if (line.Amount > 0)
                        {
                            db.SubmitChanges();
                            if (IWSLookUp.CheckIfBalanced(line.OID))
                            {
                                SetToBalanced(line);
                            }
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

            }
            else
            {
                ViewData["GenericError"] = IWSLocalResource.LeftToPay + leftToPay.ToString("N2", CultureInfo.GetCultureInfo(Thread.CurrentThread
                                                                    .CurrentUICulture.Name).NumberFormat) + " " +
                                           IWSLocalResource.LeftToPayEnd;
            }
            return PartialView("DetailDetailGridViewPartial", IWSLookUp.GetDetailDetailCompta(transId, modelId));

        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DetailDetailGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] DetailDetailCompta line, int transId)
        {
            decimal leftToPay = IWSLookUp.GetLeftToPay(line.OID);
            var model = db.DetailDetailComptas;
            ViewData["lineDetail"] = line;
            if (leftToPay >= line.Amount)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var modelItem = model.FirstOrDefault(p => p.Id == line.Id);
                        if (modelItem != null && line.Amount > 0)
                        {
                            this.UpdateModel(modelItem);
                            db.SubmitChanges();
                            if (IWSLookUp.CheckIfBalanced(line.OID))
                            {
                                SetToBalanced(line);
                            }
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
            }
            else
            {
                ViewData["GenericError"] = IWSLocalResource.LeftToPay + leftToPay.ToString("N2", CultureInfo.GetCultureInfo(Thread.CurrentThread
                                                                   .CurrentUICulture.Name).NumberFormat) + " " +
                                           IWSLocalResource.LeftToPayEnd;
            }
            return PartialView("DetailDetailGridViewPartial", IWSLookUp.GetDetailDetailCompta(transId, (int)Session["Modelid"]));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DetailDetailGridViewPartialDelete(int Id, int transId)
        {
            var model = db.DetailDetailComptas;
            if (Id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(i => i.Id == Id);
                    if (item != null)
                    {
                        model.DeleteOnSubmit(item);
                        db.SubmitChanges();

                        var details = from detail in db.DetailComptas
                                    where
                                      detail.id ==  item.OID
                                    select detail;
                        foreach (var detail in details)
                        {
                            detail.Balanced = false;
                        }
                        db.SubmitChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["GenericError"] = e.Message;
                }
            }
            return PartialView("DetailDetailGridViewPartial", IWSLookUp.GetDetailDetailCompta(transId, (int)Session["Modelid"]));
        }
        #endregion

        #region Helper
        private static void SetToBalanced(DetailDetailCompta line)
        {
            var items = from detail in db.DetailComptas
                        where
                          detail.id == line.OID
                        select detail;
            foreach (var item in items)
            {
                item.Balanced = true;
            }
            db.SubmitChanges();
        }
        public ActionResult HeaderText(int selectedOIDIndex)
        {
            return Json(IWSLookUp.GetHeaderText(selectedOIDIndex, (int)Session["ModelId"]));
        }
        public ActionResult Amount(int selectedDetailOIDIndex)
        {
            return Json(IWSLookUp.GetAmount(selectedDetailOIDIndex, (int)Session["ModelId"]));
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
                IWSLookUp.LogException(e);
                ViewData["GenericError"] = e.Message;
            }
            return results;
        }
        private bool InsertDetailsDetails(int itemOID, int modelId)
        {
            bool results = true;
            int detailId = 0;
            if(modelId.Equals((int)IWSLookUp.ComptaMasterModelId.Payment) || 
                modelId.Equals((int)IWSLookUp.ComptaMasterModelId.Settlement))
            {
                results = false;
                try
                {
                    var xv = db.DetailComptas;
                    if (xv.Any())
                    {
                        detailId = db.DetailComptas.Max(i => i.id);
                    }
                    else
                    {
                        detailId = 0;
                    }
                    detailId += 1;

                    var items = IWSLookUp.GetNewLineDetailDetail(detailId, itemOID, modelId);
                    foreach (var item in items)
                    {
                        DetailDetailCompta xc = new DetailDetailCompta()
                        {
                            TransId = item.TransId,
                            OID = item.OID,
                            Amount = item.Amount,
                            ModelId = item.ModelId
                        };
                        db.DetailDetailComptas.InsertOnSubmit(xc);// (DetailDetailCompta)item);
                    }
                    results = true;
                }
                catch (Exception e)
                {
                    IWSLookUp.LogException(e);
                }
            }
            return results;
        }
        private string IsVending(int modelId)
        {
            if (modelId.Equals((int)IWSLookUp.ComptaMasterModelId.VendorInvoice) ||
                (modelId.Equals((int)IWSLookUp.ComptaMasterModelId.Payment))){
                return "SU";
            }
            if (modelId.Equals((int)IWSLookUp.ComptaMasterModelId.CustomerInvoice) ||
                (modelId.Equals((int)IWSLookUp.ComptaMasterModelId.Settlement)))
            {
                return "CU";
            }
            if (modelId.Equals((int)IWSLookUp.ComptaMasterModelId.GeneralLedger))
            {
                return "GL";
            }
            return null;
        }
        #endregion
    }

}