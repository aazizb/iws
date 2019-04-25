using IWSProject.Models;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using IWSProject.Models.Entities;
using IWSProject.Content;
using System.Data.Linq;
using System.Linq;
using DevExpress.Web.Mvc;

namespace IWSProject.Controllers
{
    [Authorize]
    public class AssetsController : IWSBaseController
    {
        public AssetsController()
        {
            db = new IWSDataContext();
        }
        // GET: Assets
        public ActionResult Index()
        {
            return View();
        }
        [ValidateInput(false)]
        public ActionResult AssetsGridViewPartial()
        {
            return PartialView(Session["Assets"]);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult AssetsGridViewAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Asset item)
        {
            var model = db.Assets;
            DateTime dateTime = IWSLookUp.GetCurrentDateTime();
            item.CompanyId = (string)Session["CompanyID"];
            item.ModelId = (int)IWSLookUp.MetaModelId.Asset;
            item.Posted = dateTime;
            item.Updated = dateTime;
            if (item.Rate == null)
                item.Rate = 1;
            item.Frequency = 12;
            ViewBag.Assets = item;
            if (ModelState.IsValid)
            {
                try
                {
                    model.InsertOnSubmit(item);

                    db.SubmitChanges();
                    Session["Assets"] = IWSLookUp.GetAssets();
                    return PartialView("AssetsGridViewPartial", Session["Assets"]);
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
            return PartialView("AssetsGridViewPartial", item);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult AssetsGridViewUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Asset item)
        {
            var model = db.Assets;

            ViewBag.Assets = item;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.Id == item.Id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);

                        db.SubmitChanges();
                        Session["Assets"] = IWSLookUp.GetAssets();
                        return PartialView("AssetsGridViewPartial", Session["Assets"]);
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
            return PartialView("AssetsGridViewPartial", item);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult AssetsGridViewDelete(string id)
        {
            var model = db.Assets;
            if (id != null)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.Id == id);
                    if (item != null)
                        model.DeleteOnSubmit(item);

                    db.SubmitChanges();
                    Session["Assets"] = IWSLookUp.GetAssets();
                }
                catch (Exception e)
                {
                    ViewData["GenericError"] = e.Message;
                    IWSLookUp.LogException(e);
                }
            }
            return PartialView("AssetsGridViewPartial", Session["Assets"]);
        }
        public ActionResult AssetView()
        {
            return PartialView(Session["Assets"]);
        }
    }
}