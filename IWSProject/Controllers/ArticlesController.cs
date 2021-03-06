﻿using System;
using System.Linq;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using IWSProject.Models;
using IWSProject.Models.Entities;

namespace IWSProject.Controllers
{
    [Authorize]
    public class ArticlesController : Controller
    {
        IWSDataContext db;
        public ArticlesController()
        {
            db = new IWSDataContext();
        }
        // GET: articles
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult ArticlesGridViewPartial()
        {
            return PartialView(Session["Articles"]);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ArticlesGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Article item)
        {
            DateTime dateTime = IWSLookUp.GetCurrentDateTime();
            var model = db.Articles;
            item.CompanyID = (string)Session["CompanyID"];
            item.ModelId = (int)IWSLookUp.MetaModelId.Article;
            item.Posted = dateTime;
            item.Updated = dateTime;
            ViewData["Article"] = item;
            if (ModelState.IsValid)
            {
                try
                {
                    model.InsertOnSubmit(item);

                    db.SubmitChanges();
                    Session["Articles"] = IWSLookUp.GetArticles();
                    return PartialView("ArticlesGridViewPartial", Session["Articles"]);
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
            return PartialView("ArticlesGridViewPartial", item);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ArticlesGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Article item)
        {
            var model = db.Articles;
            ViewData["Article"] = item;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);

                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);

                        db.SubmitChanges();
                        Session["Articles"] = IWSLookUp.GetArticles();
                        return PartialView("ArticlesGridViewPartial", Session["Articles"]);
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
            return PartialView("ArticlesGridViewPartial", item);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ArticlesGridViewPartialDelete(string id)
        {
            var model = db.Articles;
            if (id != null)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.id == id);
                    if (item != null)
                        model.DeleteOnSubmit(item);
                    db.SubmitChanges();
                    Session["Articles"] = IWSLookUp.GetArticles();
                }
                catch (Exception e)
                {
                    ViewData["GenericError"] = e.Message;
                    IWSLookUp.LogException(e);
                }
            }
            return PartialView("ArticlesGridViewPartial", Session["Articles"]);
        }

        public ActionResult ArticleView()
        {
            return PartialView(Session["Articles"]);
        }
    }
}
