using DevExpress.Web.Mvc;
using IWSProject.Models;
using IWSProject.Models.Entities;
using System;
using System.Linq;
using System.Web.Mvc;

namespace IWSProject.Controllers
{
    [Authorize]
    //[HandleError()]
    public class AffectationJournalController : Controller
    {

        IWSDataContext db;
        public AffectationJournalController()
        {
            db = new IWSDataContext();
        }
        //GET: AffectationJournal
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult AffectationJournalGridViewPartial()
        {
            return PartialView("AffectationJournalGridViewPartial", IWSLookUp.GetAffectationJournal());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AffectationJournalGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] AffectationJournal item)
        {
            item.CompanyID = (string)Session["CompanyID"];
            ViewData["affectationJournal"] = item;
            if (ModelState.IsValid)
            {
                try
                {
                    db.AffectationJournals.InsertOnSubmit(item);
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
            ViewBag.Aff = IWSLookUp.GetAffectationJournal();
            return PartialView("AffectationJournalGridViewPartial", ViewBag.Aff);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult AffectationJournalGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] AffectationJournal item)
        {
            var model = db.AffectationJournals;
            item.CompanyID = (string)Session["CompanyID"];
            ViewData["affectationJournal"] = item;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(i => i.AccountID == item.AccountID &&
                                                                i.OAccountID==item.OAccountID &&
                                                                i.Side==item.Side &&
                                                                i.CompanyID==item.CompanyID
                                                                );
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
            ViewBag.Aff = IWSLookUp.GetAffectationJournal();
            return PartialView("AffectationJournalGridViewPartial", ViewBag.Aff);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult AffectationJournalGridViewPartialDelete(string accountID, bool side, string oaccountID)
        {
            var model = db.AffectationJournals;

            try
            {
                var item = model.FirstOrDefault(i => i.AccountID == accountID &&
                                                    i.OAccountID == oaccountID &&
                                                    i.Side == side  &&
                                                    i.CompanyID== (string)Session["CompanyID"]
                                                    );
                if (item != null)
                    model.DeleteOnSubmit(item);

                db.SubmitChanges();
            }
            catch (Exception e)
            {
                ViewData["GenericError"] = e.Message;
            }
            ViewBag.Aff = IWSLookUp.GetAffectationJournal();
            return PartialView("AffectationJournalGridViewPartial", ViewBag.Aff);
        }
        public ActionResult AccountIdComboBox()
        {
            object dataObject = IWSLookUp.GetAccounts();

            MVCxColumnComboBoxProperties combo = IWSComboBoxHelper.CreateComboBox("AffectationJournal", "AccountIdComboBox", 
                                                                            "Name", "id", dataObject);

            return GridViewExtension.GetComboBoxCallbackResult(combo);
        }
        public ActionResult AffectationJournalView()
        {
            return PartialView(IWSLookUp.GetAffectationJournal());
        }
    }
}