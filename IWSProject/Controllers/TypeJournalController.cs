using DevExpress.Web.Mvc;
using IWSProject.Models;
using IWSProject.Models.Entities;
using System;
using System.Linq;
using System.Web.Mvc;
namespace IWSProject.Controllers
{
    [Authorize]
    public class TypeJournalController : Controller
    {
        IWSDataContext db;
        public TypeJournalController()
        {
            db = new IWSDataContext();
        }
        // GET: TypeJournal
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult TypeJournalsGridViewPartial()
        {
            return PartialView(Session["TypeJournal"]);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult TypeJournalsGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] TypeJournal item)
        {
            var model = db.TypeJournals;
            item.CompanyId = (string)Session["CompanyID"];
            item.ModelId = (int)IWSLookUp.MetaModelId.TypeJournal;
            DateTime dateTime = IWSLookUp.GetCurrentDateTime();
            item.Posted = dateTime;
            item.Updated = dateTime;
            ViewBag.TypeDraft = item;
            if (ModelState.IsValid)
            {
                try
                {
                    item.Posted = dateTime;
                    item.Updated = dateTime;
                    model.InsertOnSubmit(item);
                    db.SubmitChanges();
                    Session["TypeJournal"] = IWSLookUp.GetTypeJournals();

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
            return PartialView("TypeJournalsGridViewPartial", item);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult TypeJournalsGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] TypeJournal item)
        {
            var model = db.TypeJournals;
            ViewBag.TypeDraft = item;

            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.Id == item.Id);
                    if (modelItem != null)
                    {
                        modelItem.Updated = IWSLookUp.GetCurrentDateTime();
                        this.UpdateModel(modelItem);
                        db.SubmitChanges();
                        Session["TypeJournal"] = IWSLookUp.GetTypeJournals();
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
            return PartialView("TypeJournalsGridViewPartial", item);
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
                    Session["TypeJournal"] = IWSLookUp.GetTypeJournals();
                }
                catch (Exception e)
                {
                    ViewData["GenericError"] = e.Message;
                }
            }
            return PartialView("TypeJournalsGridViewPartial", Session["TypeJournal"]);
        }
        public ActionResult TypeJournalView()
        {
            return PartialView(Session["TypeJournal"]);
        }
    }
}
