using System;
using System.Linq;
using System.Web.Mvc;
using IWSProject.Models;
using DevExpress.Web.Mvc;

namespace IWSProject.Controllers
{
    [Authorize]
    [HandleError()]
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
            Session["ComboAccountId"] = IWSLookUp.GetAccounts();

            Session["TypeJournal"] = IWSLookUp.GetTypeJournal();
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

            return PartialView("AffectationJournalGridViewPartial", IWSLookUp.GetAffectationJournal());
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

            return PartialView ("AffectationJournalGridViewPartial", IWSLookUp.GetAffectationJournal());
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

            return PartialView("AffectationJournalGridViewPartial", IWSLookUp.GetAffectationJournal());
        }
    }
}