using DevExpress.Web.Mvc;
using IWSProject.Models;
using IWSProject.Models.Entities;
using System;
using System.Linq;
using System.Web.Mvc;
namespace IWSProject.Controllers
{
    [Authorize]
    public class BanksController : Controller
    {
        IWSDataContext db;
        public BanksController()
        {
            db = new IWSDataContext();
        }
        // GET: Banks
        public ActionResult Index()
        {
            return View();
        }
        [ValidateInput(false)]
        public ActionResult BanksGridViewPartial()
        {
            return PartialView(Session["Banks"]);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult BanksGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Bank item)
        {
            var model = db.Banks;
            DateTime dateTime = IWSLookUp.GetCurrentDateTime();
            ViewBag.Bank = item;
            item.CompanyID = (string)Session["CompanyID"];
            item.ModelId = (int)IWSLookUp.MetaModelId.Banks;
            item.Posted = dateTime;
            item.Updated = dateTime;
            if (ModelState.IsValid)
            {
                try
                {
                    model.InsertOnSubmit(item);
                    db.SubmitChanges();
                    Session["Banks"] = IWSLookUp.GetBanks();
                    return PartialView("BanksGridViewPartial", Session["Banks"]);
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
            return PartialView("BanksGridViewPartial", item);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult BanksGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Bank item)
        {                                               
            var model = db.Banks;
            ViewBag.Bank = item;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db.SubmitChanges();
                        Session["Banks"] = IWSLookUp.GetBanks();
                        return PartialView("BanksGridViewPartial", Session["Banks"]);
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
            return PartialView("BanksGridViewPartial", item);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult BanksGridViewPartialDelete(string id)
        {
            var model = db.Banks;
            if (id != null)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.id == id);
                    if (item != null)
                        model.DeleteOnSubmit(item);
                    db.SubmitChanges();
                    Session["Banks"] = IWSLookUp.GetBanks();
                }
                catch (Exception e)
                {
                    ViewData["GenericError"] = e.Message;
                    IWSLookUp.LogException(e);
                }
            }
            return PartialView("BanksGridViewPartial", Session["Banks"]);
        }

        public ActionResult BankView()
        {
            return PartialView(Session["Banks"]);
        }
    }
}
