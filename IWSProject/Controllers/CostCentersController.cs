using System;
using System.Linq;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using IWSProject.Models;
using IWSProject.Content;
namespace IWSProject.Controllers
{
    [Authorize]
    public class CostCentersController : Controller
    {

        IWSDataContext db;
        public CostCentersController()
        {
            db = new IWSDataContext();
        }

        // GET: costcenters
        public ActionResult Index()
        {
            return View(IWSLookUp.GetCostCenter());
        }
        [ValidateInput(false)]
        public ActionResult CostCentersGridViewPartial()
        {
            return PartialView("CostCentersGridViewPartial", IWSLookUp.GetCostCenter());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult CostCentersGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))]CostCenter item)
        {
            var model = db.CostCenters;
            item.CompanyID = (string)Session["CompanyID"];
            ViewData["costCenters"] = item;
            if (ModelState.IsValid)
            {
                try
                {
                    model.InsertOnSubmit(item);
                    db.SubmitChanges();
                    return PartialView("CostCentersGridViewPartial", IWSLookUp.GetCostCenter());
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
            return PartialView("CostCentersGridViewPartial", item);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CostCentersGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))]CostCenter item)
        {
            var model = db.CostCenters;
            ViewData["costCenters"] = item;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db.SubmitChanges();
                        return PartialView("CostCentersGridViewPartial", IWSLookUp.GetCostCenter());
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
            return PartialView("CostCentersGridViewPartial", item);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CostCentersGridViewPartialDelete(System.String id)
        {
            var model = db.CostCenters;
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
            return PartialView("CostCentersGridViewPartial", IWSLookUp.GetCostCenter());
        }
    }
}
