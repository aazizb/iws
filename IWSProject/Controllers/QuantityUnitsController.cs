using System;
using System.Linq;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using IWSProject.Models;
using IWSProject.Content;
namespace IWSProject.Controllers
{
    [Authorize]
    public class QuantityUnitsController : Controller
    {
        IWSDataContext db;
        public QuantityUnitsController()
        {
            db = new IWSDataContext();
        }

        // GET: QuantityUnits
        public ActionResult Index()
        {
            return View(IWSLookUp.GetQuantityUnits());
        }

        [ValidateInput(false)]
        public ActionResult QuantityUnitsGridViewPartial()
        {
            return PartialView("QuantityUnitsGridViewPartial", IWSLookUp.GetQuantityUnits());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult QuantityUnitsGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] QuantityUnit item)
        {
            var model = db.QuantityUnits;
            item.CompanyID = (string)Session["CompanyID"];
            ViewData["quantityunit"] = item;
            if (ModelState.IsValid)
            {
                try
                {
                    model.InsertOnSubmit(item);

                    db.SubmitChanges();
                    return PartialView("QuantityUnitsGridViewPartial", IWSLookUp.GetQuantityUnits());
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
            return PartialView("QuantityUnitsGridViewPartial", item);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult QuantityUnitsGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] QuantityUnit item)
        {
            var model = db.QuantityUnits;

            ViewData["quantityunit"] = item;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);

                        db.SubmitChanges();
                        return PartialView("QuantityUnitsGridViewPartial", IWSLookUp.GetQuantityUnits());
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
            return PartialView("QuantityUnitsGridViewPartial", item);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult QuantityUnitsGridViewPartialDelete(string id)
        {
            var model = db.QuantityUnits;
            if (id != null)
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
                    IWSLookUp.LogException(e);
                }
            }
            return PartialView("QuantityUnitsGridViewPartial", IWSLookUp.GetQuantityUnits());
        }
    }
}
