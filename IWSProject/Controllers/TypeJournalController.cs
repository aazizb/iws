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
            
            //System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();

            //ViewBag.TypeJournal = IWSLookUp.GetTypeJournals();

            //sw.Stop();

            //string elapsedTime = sw.ElapsedMilliseconds.ToString();
            ////if (Session["DurationTypeJ"] == null)
            ////{
            //    Session["DurationTypeJ"] = $"Data reading time: {elapsedTime} ms";

            ////}
            return View();
        }

        [ValidateInput(false)]
        public ActionResult TypeJournalsGridViewPartial()
        {
            
            //System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
            //ViewBag.TypeJour = IWSLookUp.GetTypeJournals();
            //var p = IWSLookUp.GetTypeJournals();
            //sw.Stop();

            //string elapsedTime = sw.ElapsedMilliseconds.ToString();
            //Session["DurationTypeJ"] = $"Data reading time: {elapsedTime} ms";
            return PartialView("TypeJournalsGridViewPartial", IWSLookUp.GetTypeJournals());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult TypeJournalsGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] TypeJournal item)
        {
            var model = db.TypeJournals;
            item.CompanyId = (string)Session["CompanyID"];
            item.ModelId = (int)IWSLookUp.MetaModelId.TypeJournal;
            item.Posted = DateTime.Now.Date;
            item.Updated = DateTime.Now.Date;
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
        public ActionResult TypeJournalView()
        {
            return PartialView(IWSLookUp.GetTypeJournals());
        }
    }
}
