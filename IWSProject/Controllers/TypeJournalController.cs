using DevExpress.Web.Mvc;
using IWSProject.Models;
using System;
using System.Linq;
using System.Web.Mvc;
namespace IWSProject.Controllers
{
    [Authorize]
    [HandleError()]
    public class TypeJournalController : Controller
    {
        IWSDataContext db;
        public TypeJournalController()
        {
            db = new IWSDataContext();
        }
        // GET: bankaccounts
        public ActionResult Index()
        {
            return View(IWSLookUp.GetTypeJournals());
        }

        [ValidateInput(false)]
        public ActionResult TypeJournalsGridViewPartial()
        {
            return PartialView("TypeJournalsGridViewPartial", IWSLookUp.GetTypeJournals());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult TypeJournalsGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] TypeJournal item)
        {
            var model = db.TypeJournals;
            item.CompanyId = (string)Session["CompanyID"];
            ViewData["typeDraft"] = item;
            if (ModelState.IsValid)
            {
                try
                {
                    item.Posted = DateTime.Now;
                    item.Updated = DateTime.Now;
                    model.InsertOnSubmit(item);
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
            return PartialView("TypeJournalsGridViewPartial", IWSLookUp.GetTypeJournals());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult TypeJournalsGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] TypeJournal item)
        {
            var model = db.TypeJournals;
            ViewData["typeJournal"] = item;

            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.Id == item.Id);
                    if (modelItem != null)
                    {
                        modelItem.Updated = DateTime.Now;
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
            return PartialView("TypeJournalsGridViewPartial", IWSLookUp.GetTypeJournals());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult TypeJournalsGridViewPartialDelete(string id)
        {
            var model = db.TypeJournals;
            if (id != null)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.Id == id);
                    if (item != null)
                        model.DeleteOnSubmit(item);

                    db.SubmitChanges();
                }
                catch (Exception e)
                {
                    ViewData["GenericError"] = e.Message;
                }
            }
            return PartialView("TypeJournalsGridViewPartial", IWSLookUp.GetTypeJournals());
        }
    }
}
