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
        public ActionResult AssetsGridView()
        {
            ViewBag.ComboAccountId = IWSLookUp.GetAccounts();
            ViewBag.Currency = IWSLookUp.GetCurrency();
            return PartialView("AssetsGridViewPartial", IWSLookUp.GetAssets());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult AssetsGridViewAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Asset item)
        {
            var model = db.Assets;
            item.CompanyId = (string)Session["CompanyID"];
            item.ModelId = (int)IWSLookUp.MetaModelId.Asset;
            item.Posted = DateTime.Now.Date;
            item.Updated = DateTime.Now.Date;
            ViewBag.Assets = item;
            if (ModelState.IsValid)
            {
                try
                {
                    model.InsertOnSubmit(item);

                    db.SubmitChanges();
                    return PartialView("AssetsGridViewPartial", IWSLookUp.GetAssets());
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
                        return PartialView("AssetsGridViewPartial", IWSLookUp.GetAssets());
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
                }
                catch (Exception e)
                {
                    ViewData["GenericError"] = e.Message;
                    IWSLookUp.LogException(e);
                }
            }
            return PartialView("AssetsGridViewPartial", IWSLookUp.GetAssets());
        }
    }
}