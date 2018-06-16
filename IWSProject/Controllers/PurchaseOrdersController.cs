using DevExpress.Web.Mvc;
using IWSProject.Models;
using IWSProject.Content;
using System;
using System.Linq;
using System.Web.Mvc;
namespace IWSProject.Controllers
{
    [Authorize]
    public class PurchaseOrdersController : Controller
    {
        IWSDataContext db;
        public PurchaseOrdersController()
        {
            db = new IWSDataContext();
        }
        // GET: purchaseorders
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MasterGridViewPartial()
        {
            ViewBag.Store = IWSLookUp.GetStore();

            ViewBag.ComboSupplierId = IWSLookUp.GetSuppliers();

            return PartialView("MasterGridViewPartial", IWSLookUp.GetPurchaseOrder());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CallbackPanelPartialView(string selectedIDs)
        {
            if (!string.IsNullOrEmpty(selectedIDs) && selectedIDs != null)
            {
                string companyId = (string)Session["CompanyID"];
                AccountingController c = new AccountingController();
            
                string items=c.SetDocType(selectedIDs,
                                        IWSLookUp.DocsType.PurchaseOrder.ToString());
                c.ProcessData(items, companyId, false);
            }
            return PartialView("CallbackPanelPartialView", IWSLookUp.GetPurchaseOrder());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MasterGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] PurchaseOrder item)
        {
            var model = db.PurchaseOrders;
            item.IsValidated = false;
            item.CompanyId = (string)Session["CompanyID"];
            item.ShippingTerms = item.ShippingTerms ?? "N/A";
            item.HeaderText = item.HeaderText ?? "N/A";
            ViewData["item"] = item;
            ViewBag.IsNewRow = true;

            if (ModelState.IsValid)
            {
                try
                {
                    model.InsertOnSubmit(item);
                    bool result = IWSLookUp.CheckPeriod(item.TransDate, item.CompanyId, true, true);
                    if (result)
                    {
                        db.SubmitChanges();
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

            return PartialView("MasterGridViewPartial", IWSLookUp.GetPurchaseOrder());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MasterGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] PurchaseOrder item)
        {
            var model = db.PurchaseOrders;
            ViewData["item"] = item;
            ViewBag.IsNewRow = false;
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
            return PartialView("MasterGridViewPartial", IWSLookUp.GetPurchaseOrder());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MasterGridViewPartialDelete(int id)
        {
            var model = db.PurchaseOrders;

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
            return PartialView("MasterGridViewPartial", IWSLookUp.GetPurchaseOrder());
        }
        [ValidateInput(false)]
        public ActionResult DetailGridViewPartial(int transId, object newKeyValue)
        {
            if (newKeyValue != null)
            {
                ViewData["IsNewDetailRow"] = true;
            }
            ViewBag.ComboArticleId = IWSLookUp.GetArticle();

            ViewBag.QttyUnit = IWSLookUp.GetQuantityUnits();

            ViewBag.Currency = IWSLookUp.GetCurrency();

            return PartialView("DetailGridViewPartial", IWSLookUp.GetLinePurchaseOrders(transId));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DetailGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] LinePurchaseOrder line, int transId)
        {
            var model = db.LinePurchaseOrders;
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
            return PartialView("DetailGridViewPartial", model.Where(m => m.transid == transId));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DetailGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] LinePurchaseOrder line, int transId)
        {
            var model = db.LinePurchaseOrders;
            line.transid = transId;

            ViewData["line"] = line;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == line.id);

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
            return PartialView("DetailGridViewPartial", db.LinePurchaseOrders.Where(p => p.transid == transId));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DetailGridViewPartialDelete(int Id, int transId)
        {

            var model = db.LinePurchaseOrders;
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
            return PartialView("DetailGridViewPartial", db.LinePurchaseOrders.Where(p => p.transid == transId));
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
        public ActionResult VatCode(string selectedItemIndex)
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

        #endregion
    }
}
