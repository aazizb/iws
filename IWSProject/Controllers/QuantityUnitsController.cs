﻿using DevExpress.Web.Mvc;
using IWSProject.Models;
using IWSProject.Models.Entities;
using System;
using System.Linq;
using System.Web.Mvc;
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
            return PartialView(Session["QuantityUnits"]);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult QuantityUnitsGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] QuantityUnit item)
        {
            var model = db.QuantityUnits;
            item.CompanyID = (string)Session["CompanyID"];
            item.ModelId = (int)IWSLookUp.MetaModelId.QuantityUnit;
            DateTime dateTime = IWSLookUp.GetCurrentDateTime();
            item.Posted = dateTime;
            item.Updated = dateTime;
            ViewBag.QuantityUnit = item;
            if (ModelState.IsValid)
            {
                try
                {
                    model.InsertOnSubmit(item);

                    db.SubmitChanges();
                    Session["QuantityUnits"] = IWSLookUp.GetQuantityUnits();
                    return PartialView("QuantityUnitsGridViewPartial", Session["QuantityUnits"]);
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

            ViewBag.QuantityUnit = item;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);

                        db.SubmitChanges();
                        Session["QuantityUnits"] = IWSLookUp.GetQuantityUnits();
                        return PartialView("QuantityUnitsGridViewPartial", Session["QuantityUnits"]);
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
                    Session["QuantityUnits"] = IWSLookUp.GetQuantityUnits();
                }
                catch (Exception e)
                {
                    ViewData["GenericError"] = e.Message;
                    IWSLookUp.LogException(e);
                }
            }
            return PartialView("QuantityUnitsGridViewPartial", IWSLookUp.GetQuantityUnits());
        }
        public ActionResult QuantityUnitView()
        {
            return PartialView(Session["QuantityUnits"]);
        }
    }
}
