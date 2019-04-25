using System;
using System.Linq;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using IWSProject.Models;
using IWSProject.Models.Entities;
using IWSProject.Content;
namespace IWSProject.Controllers
{
    [Authorize]
    public class VatsController : Controller
    {
        IWSDataContext db;
        public VatsController()
        {
            
            db = new IWSDataContext();
        }
        // GET: Vats
        public ActionResult Index()
        {
            return View();
        }
        [ValidateInput(false)]
        public ActionResult VatsGridViewPartial()
        {
            return PartialView(Session["VAT"]);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult VatsGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Vat item)
        {
            var model = db.Vats;
            item.CompanyID = (string)Session["CompanyID"];
            item.ModelId = (int)IWSLookUp.MetaModelId.VAT;
            DateTime dateTime = IWSLookUp.GetCurrentDateTime();
            item.Posted = dateTime;
            item.Updated = dateTime;
            ViewBag.VAT = item;
            if (ModelState.IsValid)
            {
                try
                {
                    model.InsertOnSubmit(item);

                    db.SubmitChanges();
                    Session["VAT"] = IWSLookUp.GetVats();
                    return PartialView("VatsGridViewPartial", Session["VAT"]);
                }
                catch (Exception e)
                {
                    ViewData["GenericError"] = e.Message;
                    IWSLookUp.LogException(e);
                }
            }
            else
            {
                ViewData["GenericError"] = IWSLookUp.GetModelSateErrors(ModelState);
            }
            return PartialView("VatsGridViewPartial", item);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult VatsGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Vat item)
        {
            var model = db.Vats;
            ViewBag.VAT = item;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);

                        db.SubmitChanges();
                        Session["VAT"] = IWSLookUp.GetVats();
                        return PartialView("VatsGridViewPartial", Session["VAT"]);
                    }
                }
                catch (Exception e)
                {
                    ViewData["GenericError"] = e.Message;
                    IWSLookUp.LogException(e);
                }
            }
            else
            {
                ViewData["GenericError"] = IWSLookUp.GetModelSateErrors(ModelState);
            }
            return PartialView("VatsGridViewPartial", item);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult VatsGridViewPartialDelete(string id)
        {
            var model = db.Vats;
            if (id != null)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.id == id);
                    if (item != null)
                        model.DeleteOnSubmit(item);

                    db.SubmitChanges();
                    Session["VAT"] = IWSLookUp.GetVats();
                }
                catch (Exception e)
                {
                    ViewData["GenericError"] = e.Message;
                    IWSLookUp.LogException(e);

                }
            }
            return PartialView("VatsGridViewPartial", Session["VAT"]);
        }
        public ActionResult VatView()
        {
            return PartialView(Session["VAT"]);
        }
    }
}
