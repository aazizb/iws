using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using IWSProject.Content;
using IWSProject.Models;

namespace IWSProject.Controllers
{

    [Authorize]
    public class CompaniesController : Controller
    {
        IWSDataContext db;
        public CompaniesController()
        {
            db = new IWSDataContext();
        }

        // GET: Companies
        public ActionResult Index()
        {
            return View(IWSLookUp.GetCompany());
        }
        [ValidateInput(false)]
        public ActionResult SetLogo()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SetLogo(SetLogoViewModel logo)
        {
            if (ModelState.IsValid)
            {
                byte[] imageData = null;
                if (Request.Files.Count > 0)
                {
                    HttpPostedFileBase poImgFile = Request.Files["Logo"];

                    using (var binary = new BinaryReader(poImgFile.InputStream))
                    {
                        imageData = binary.ReadBytes(poImgFile.ContentLength);
                        logo.Logo = imageData;
                    }
                }
                var logoImage = new SetLogoViewModel
                {
                    CompanyID = logo.CompanyID,
                    Logo = logo.Logo
                };
            }
            return View();
        }
        
        [ValidateInput(false)]
        public ActionResult CompaniesGridViewPartial()
        {
            return PartialView("CompaniesGridViewPartial", IWSLookUp.GetCompany());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult CompaniesGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))]Company item)
        {
            var model = db.Companies;
            ViewData["company"] = item;
            if (ModelState.IsValid)
            {
                try
                {
                    model.InsertOnSubmit(item);
                    db.SubmitChanges();
                    return PartialView("CompaniesGridViewPartial", IWSLookUp.GetCompany());
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
            return PartialView("CompaniesGridViewPartial", item);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CompaniesGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))]Company item)
        {
            var model = db.Companies;
            ViewData["company"] = item;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db.SubmitChanges();
                        return PartialView("CompaniesGridViewPartial", IWSLookUp.GetCompany());
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
            return PartialView("CompaniesGridViewPartial", item);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CompaniesGridViewPartialDelete(string id)
        {
            var model = db.Companies;
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
            return PartialView("CompaniesGridViewPartial", IWSLookUp.GetCompany());
        }


        [ValidateInput(false)]
        public ActionResult DetailGridViewPartial(string owner)
        {
            return PartialView("DetailGridViewPartial", IWSLookUp.GetBankAccount(owner));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DetailGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] BankAccount line, string owner)
        {

            var model = db.BankAccounts;

            line.Owner = owner;
            line.CompanyID = (string)Session["CompanyID"];
            ViewData["bankAccount"] = line;

            if (ModelState.IsValid)
            {
                try
                {
                    model.InsertOnSubmit(line);

                    db.SubmitChanges();
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
            return PartialView("DetailGridViewPartial", IWSLookUp.GetBankAccount(owner));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DetailGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] BankAccount line, string owner)
        {
            var model = db.BankAccounts;

            line.Owner = owner;

            ViewData["bankAccount"] = line;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(i => i.IBAN == line.IBAN);

                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);

                        db.SubmitChanges();
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
            return PartialView("DetailGridViewPartial", IWSLookUp.GetBankAccount(owner));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DetailGridViewPartialDelete(string iban, string owner)
        {

            var model = db.BankAccounts;

            try
            {
                var item = model.FirstOrDefault(i => i.IBAN == iban);

                if (item != null)
                    model.DeleteOnSubmit(item);

                db.SubmitChanges();
            }
            catch (Exception e)
            {
                ViewData["GenericError"] = e.Message;
                IWSLookUp.LogException(e);
            }
            return PartialView("DetailGridViewPartial", IWSLookUp.GetBankAccount(owner));
        }
    }
}
