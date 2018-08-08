using DevExpress.Web.Mvc;
using IWSProject.Models;
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
            System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();

            ViewBag.Banks = IWSLookUp.GetBanks();

            sw.Stop();

            string elapsedTime = sw.ElapsedMilliseconds.ToString();

            if (Session["DurationBank"] == null)
            {
                Session["DurationBank"] = $"Data reading time: {elapsedTime} ms";

            }
            return View();
        }

        [ValidateInput(false)]
        public ActionResult BanksGridViewPartial()
        {
            System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
            ViewBag.BankX = IWSLookUp.GetBanks();
            sw.Stop();

            string elapsedTime = sw.ElapsedMilliseconds.ToString();
            Session["DurationBank"] = $"Data reading time: {elapsedTime} ms";

            return PartialView("BanksGridViewPartial", ViewBag.BankX);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult BanksGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Bank item)
        {
            var model = db.Banks;
            ViewData["bank"] = item;
            item.CompanyID = (string)Session["CompanyID"];
            item.ModelId = (int)IWSLookUp.MetaModelId.Banks;
            item.Posted = DateTime.Now.Date;
            item.Updated = DateTime.Now.Date;
            if (ModelState.IsValid)
            {
                try
                {
                    model.InsertOnSubmit(item);
                    db.SubmitChanges();
                    return PartialView("BanksGridViewPartial", IWSLookUp.GetBanks());
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
            ViewData["bank"] = item;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db.SubmitChanges();
                        return PartialView("BanksGridViewPartial", IWSLookUp.GetBanks());
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
                }
                catch (Exception e)
                {
                    ViewData["GenericError"] = e.Message;
                    IWSLookUp.LogException(e);
                }
            }
            return PartialView("BanksGridViewPartial", IWSLookUp.GetBanks());
        }
    }
}
