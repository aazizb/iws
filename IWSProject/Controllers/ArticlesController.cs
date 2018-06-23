using DevExpress.Web.Mvc;
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

            sw.Stop();

            string elapsedTime = sw.ElapsedMilliseconds.ToString();
            if(Session["DurationArt"] == null)
            {
                Session["DurationArt"] = $"Data reading time: {elapsedTime}";

            }

            return View();
        }

        [ValidateInput(false)]
        public ActionResult ArticlesGridViewPartial()
        {
            
            ViewBag.ComboAccountId = IWSLookUp.GetAccounts();
            ViewBag.Currency = IWSLookUp.GetCurrency();
            ViewBag.QttyUnit = IWSLookUp.GetQuantityUnits();
            ViewBag.PackUnit = IWSLookUp.GetPackUnits();
            ViewBag.VAT = IWSLookUp.GetVAT();
            ViewBag.ComboArticleId = IWSLookUp.GetArticle();
            //System.Diagnostics.Debug.WriteLine($"start 1: {DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")}");
            //System.Diagnostics.Debug.WriteLine($"start 2: {DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")}");
            //System.Diagnostics.Debug.WriteLine($"start 3: {DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")}");
            //System.Diagnostics.Debug.WriteLine($"start 4: {DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")}");
            //System.Diagnostics.Debug.WriteLine($"start 5: {DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")}");
            //System.Diagnostics.Debug.WriteLine($"start 6: {DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")}");
            //System.Diagnostics.Debug.WriteLine($"start 7: {DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")}");
            //System.Diagnostics.Debug.WriteLine($"end   7: {DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")}");

            return PartialView(IWSLookUp.GetArticles());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ArticlesGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Article item)
        {
            var model = db.Articles;
            item.CompanyID = (string)Session["CompanyID"];
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
