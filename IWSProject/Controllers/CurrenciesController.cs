using DevExpress.Web.Mvc;
using IWSProject.Models;
using IWSProject.Models.Entities;
using System;
using System.Linq;
using System.Web.Mvc;

namespace IWSProject.Controllers
{
    public class CurrenciesController : Controller
    {
        IWSDataContext db;
        public CurrenciesController()
        {
            db = new IWSDataContext();
        }
        // GET: Currencies
        //[OutputCache(VaryByParam = "none", Duration = 3600)]
        public ActionResult Index()
        {
            return View();
        }
        [ValidateInput(false)]
        public ActionResult CurrenciesGridViewPartial()
        {
            return PartialView(Session["Currencies"]);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CurrenciesGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Currency item)
        {
            var model = db.Currencies;
            item.CompanyID = (string)Session["CompanyID"];
            item.ModelId = (int)IWSLookUp.MetaModelId.Currency;
            DateTime dateTime = IWSLookUp.GetCurrentDateTime();
            item.Posted = dateTime;
            item.Updated = dateTime;
            ViewBag.Currency = item;
            if (ModelState.IsValid)
            {
                try
                {
                    model.InsertOnSubmit(item);

                    db.SubmitChanges();
                    Session["Currencies"] = IWSLookUp.GetCurrencies();
                    return PartialView("CurrenciesGridViewPartial", Session["Currencies"]);
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
            return PartialView("CurrenciesGridViewPartial", item);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CurrenciesGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Currency item)
        {
            var model = db.Currencies;

            ViewBag.Currency = item;

            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.Id == item.Id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);

                        db.SubmitChanges();
                        Session["Currencies"] = IWSLookUp.GetCurrencies();
                        return PartialView("CurrenciesGridViewPartial", Session["Currencies"]);
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
            return PartialView("CurrenciesGridViewPartial", item);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CurrenciesGridViewPartialDelete(string id)
        {
            var model = db.Currencies;
            if (id != null)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.Id == id);
                    if (item != null)
                        model.DeleteOnSubmit(item);
                    db.SubmitChanges();
                    Session["Currencies"] = IWSLookUp.GetCurrencies();
                }
                catch (Exception e)
                {
                    ViewData["GenericError"] = e.Message;
                    IWSLookUp.LogException(e);
                }
            }
            return PartialView("CurrenciesGridViewPartial", Session["Currencies"]);
        }
        public ActionResult CurrencyView()
        {
            return PartialView(Session["Currencies"]);
        }
    }
}