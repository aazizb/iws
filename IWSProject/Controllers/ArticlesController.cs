﻿using DevExpress.Web.Mvc;
using IWSProject.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

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
            System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();

            ViewBag.ComboAccountId = IWSLookUp.GetAccounts();
            ViewBag.Currency = IWSLookUp.GetCurrency();
            ViewBag.QttyUnit = IWSLookUp.GetQuantityUnits();
            ViewBag.PackUnit = IWSLookUp.GetPackUnits();
            ViewBag.VAT = IWSLookUp.GetVAT();
            ViewBag.ComboArticleId = IWSLookUp.GetArticle();
            ViewBag.Articles = IWSLookUp.GetArticles();

            sw.Stop();

            string elapsedTime = sw.ElapsedMilliseconds.ToString();
            //if(Session["DurationArt"] == null)
            //{
                Session["DurationArt"] = $"Data reading time: {elapsedTime} ms";

            //}

            return View();
        }

        [ValidateInput(false)]
        public ActionResult ArticlesGridViewPartial()
        {
            System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
            ViewBag.ComboAccountId = IWSLookUp.GetAccounts();
            ViewBag.Currency = IWSLookUp.GetCurrency();
            ViewBag.QttyUnit = IWSLookUp.GetQuantityUnits();
            ViewBag.PackUnit = IWSLookUp.GetPackUnits();
            ViewBag.VAT = IWSLookUp.GetVAT();
            ViewBag.ComboArticleId = IWSLookUp.GetArticle();
            ViewBag.Art = IWSLookUp.GetArticles();
            sw.Stop();

            string elapsedTime = sw.ElapsedMilliseconds.ToString();
            Session["DurationArt"] = $"Data reading time: {elapsedTime} ms";
            return PartialView(ViewBag.Art);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ArticlesGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Article item)
        {
            var model = db.Articles;
            item.CompanyID = (string)Session["CompanyID"];
            item.ModelId = (int)IWSLookUp.MetaModelId.Account;
            item.Posted = DateTime.Now.Date;
            item.Updated = DateTime.Now.Date;
            ViewData["article"] = item;
            if (ModelState.IsValid)
            {
                try
                {
                    model.InsertOnSubmit(item);

                    db.SubmitChanges();
                    return PartialView("ArticlesGridViewPartial", IWSLookUp.GetArticles());
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
            ViewData["article"] = item;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);

                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);

                        db.SubmitChanges();
                        PartialView("ArticlesGridViewPartial", IWSLookUp.GetArticles());
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
            return PartialView("ArticlesGridViewPartial", IWSLookUp.GetArticles());
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

                }
                catch (Exception e)
                {
                    ViewData["GenericError"] = e.Message;
                    IWSLookUp.LogException(e);
                }
            }
            return PartialView("ArticlesGridViewPartial", IWSLookUp.GetArticles());
        }
    }
}
