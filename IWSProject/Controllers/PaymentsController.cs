using System;
using System.Linq;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using IWSProject.Models;
using IWSProject.Content;
namespace IWSProject.Controllers
{
    [Authorize]
    public class PaymentsController : Controller
    {
        IWSDataContext db;
        public PaymentsController()
        {
            db = new IWSDataContext();
        }
        // GET: Payments
        public ActionResult Index(string MenuID)
        {
            Session["MenuID"] = MenuID;
            return View(IWSLookUp.GetPayment());
        }
        [ValidateInput(false)]
        public ActionResult MasterGridViewPartial()
        {
            return PartialView("MasterGridViewPartial", IWSLookUp.GetPayment());
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
                                        IWSLookUp.DocsType.Payment.ToString());
                c.ProcessData(items, companyID, false);
            }
            return PartialView("CallbackPanelPartialView", IWSLookUp.GetPayment());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MasterGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Payment item)
        {
            var model = db.Payments;
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
                        int itemID = db.Payments.Max(i => i.id);
                        if (itemOID != 0)
                        {

                            result = InsertLines(itemID, itemOID);
                            if (result)
                            {
                                db.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                                result = IWSLookUp.SetTypeJournal(IWSLookUp.DocsType.Payment.ToString(), itemID);
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
            return PartialView("MasterGridViewPartial", IWSLookUp.GetPayment());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MasterGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Payment item)
        {
            var model = db.Payments;

            ViewData["item"] = item;
            if (ModelState.IsValid)
            {
                int id = item.id;
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
            return PartialView("MasterGridViewPartial", IWSLookUp.GetPayment());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MasterGridViewPartialDelete(int id)
        {
            var model = db.Payments;

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
            return PartialView("MasterGridViewPartial", IWSLookUp.GetPayment());
        }
        [ValidateInput(false)]
        public ActionResult DetailGridViewPartial(int transId, object newKeyValue)
        {

            if (newKeyValue != null)
            {
                ViewData["IsNewDetailRow"] = true;
            }
            ViewBag.DefaultCurrency = IWSLookUp.GetCurrencyDefault();
            return PartialView("DetailGridViewPartial", IWSLookUp.GetLinePayment(transId));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DetailGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] LinePayment line, int transId)
        {
            var model = db.LinePayments;
            line.transid = transId;
            ViewData["line"] = line;
            if (ModelState.IsValid)
            {
                try
                {
                    model.InsertOnSubmit(line);
                    db.SubmitChanges();
                    bool result = IWSLookUp.SetTypeJournal(IWSLookUp.DocsType.Payment.ToString(), transId);
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
            return PartialView("DetailGridViewPartial", IWSLookUp.GetLinePayment(transId));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DetailGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] LinePayment line, int transId)
        {
            var model = db.LinePayments;
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
                        bool result = IWSLookUp.SetTypeJournal(IWSLookUp.DocsType.Payment.ToString(), transId);
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
            return PartialView("DetailGridViewPartial", IWSLookUp.GetLinePayment(transId));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DetailGridViewPartialDelete(int Id, int transId)
        {

            var model = db.LinePayments;

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
            return PartialView("DetailGridViewPartial", IWSLookUp.GetLinePayment(transId));
        }

        #region Helper
        public ActionResult HeaderText(int selectedItemIndex)
        {
            return Json(IWSLookUp.GetHeaderText(selectedItemIndex, IWSLookUp.DocsType.Payment.ToString()));
        }
        public ActionResult Supplier(int selectedItemIndex)
        {
            return Json(IWSLookUp.GetSupplier(selectedItemIndex, IWSLookUp.DocsType.Payment.ToString()));
        }
        public ActionResult CostCenter(int selectedItemIndex)
        {
            return Json(IWSLookUp.GetCostCenter(selectedItemIndex, IWSLookUp.DocsType.Payment.ToString()));
        }
        public ActionResult TypeJournal(int selectedItemIndex)
        {
            return Json(IWSLookUp.GetTypeJournal(selectedItemIndex, IWSLookUp.DocsType.Payment.ToString()));
        }
        public ActionResult AccountingAccount(int selectedItemIndex)
        {
            return Json(IWSLookUp.GetAccount(selectedItemIndex, IWSLookUp.DocsType.Payment.ToString()));
        }
        public bool InsertLines(int itemID, int OID)
        {
            bool results = false;
            try
            {
                var items = IWSLookUp.GetNewLinePayment(itemID, OID);
                foreach (var item in items)
                {
                    db.LinePayments.InsertOnSubmit((LinePayment)item);
                }
                results = true;
            }
            catch (Exception e)
            {
                ViewData["GenericError"] = e.Message;
            }
            return results;
        }

        #endregion

    }
}