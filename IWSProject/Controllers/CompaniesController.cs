﻿using DevExpress.Web.Mvc;
using IWSProject.Models;
using IWSProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace IWSProject.Controllers
{

    [Authorize]
    public class CompaniesController : IWSBaseController
    {
        IWSDataContext db;

        public CompaniesController()
        {
            db = new IWSDataContext();
        }

        // GET: Companies
        public ActionResult Index()
        {
            return View();
        }
        
        [ValidateInput(false)]
        public ActionResult CompaniesGridViewPartial()
        {
            return PartialView(Session["Company"]);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CompaniesGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))]Company item)
        {
            var model = db.Companies;
            ViewBag.Company = item;
            item.ModelId = (int)IWSLookUp.MetaModelId.Company;
            if (ModelState.IsValid)
            {
                try
                {
                    model.InsertOnSubmit(item);
                    db.SubmitChanges();
                    Session["Company"] = IWSLookUp.GetCompany();
                    return PartialView("CompaniesGridViewPartial", Session["Company"]);
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
            ViewBag.Company = item;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db.SubmitChanges();
                        Session["Company"] = IWSLookUp.GetCompany();
                        return PartialView("CompaniesGridViewPartial", Session["Company"]);
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
                    Session["Company"] = IWSLookUp.GetCompany();
                }
                catch (Exception e)
                {
                    ViewData["GenericError"] = e.Message;
                    IWSLookUp.LogException(e);
                }
            }
            return PartialView("CompaniesGridViewPartial", Session["Company"]);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult CallbackPanelPartialView()
        {
            return PartialView("CallbackPanelPartialView", Session["Company"]);
                    
        }
        public ActionResult UploadFile(string compId)
        {
            Session["compId"] = compId;

            return null;
        }
        public ActionResult UploadControlLogoUpload()
        {
            UploadControlExtension.GetUploadedFiles("UploadControlLogo", CompaniesControllerUploadControlLogoSettings.UploadValidationSettings,
                                                        CompaniesControllerUploadControlLogoSettings.FileUploadComplete);
            return null;
        }

        [ValidateInput(false)]
        public ActionResult DetailGridViewPartial(string owner)
        {
            if(Session["BankChildren"] == null)
            {
                Session["BankChildren"] = IWSLookUp.GetBankChildren();
            }
            return PartialView("DetailGridViewPartial", IWSLookUp.GetBankAccount(owner));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DetailGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] BankAccount line, string owner)
        {

            var model = db.BankAccounts;

            line.Owner = owner;
            line.CompanyID = (string)Session["CompanyID"];
            ViewBag.BankAccount = line;

            if (ModelState.IsValid)
            {
                try
                {
                    model.InsertOnSubmit(line);

                    db.SubmitChanges();
                    return PartialView("DetailGridViewPartial", IWSLookUp.GetBankAccount(owner));
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
            return PartialView("DetailGridViewPartial", line);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DetailGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] BankAccount line, string owner)
        {
            var model = db.BankAccounts;

            line.Owner = owner;

            ViewBag.BankAccount = line;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(i => i.IBAN == line.IBAN);

                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);

                        db.SubmitChanges();
                        return PartialView("DetailGridViewPartial", IWSLookUp.GetBankAccount(owner));
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
            return PartialView("DetailGridViewPartial", line);
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
        public ActionResult CompanyView()
        {
            return PartialView(Session["Company"]);
        }
    }
    public class CompaniesControllerUploadControlLogoSettings
    {
        private const string UploadDirectory = "~/Documents/";

        public static DevExpress.Web.UploadControlValidationSettings UploadValidationSettings = new DevExpress.Web.UploadControlValidationSettings()
        {
            AllowedFileExtensions = new string[] { ".jpg", ".jpeg", ".png", ".bmp" },
            MaxFileSize = 4000000
        };
        public static void FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            if (e.UploadedFile.IsValid)
            {
                string itemId = (string)(HttpContext.Current.Session["compId"]);
                string resultFilePath = HttpContext.Current.Request.MapPath(UploadDirectory + e.UploadedFile.FileName);
                IUrlResolutionService urlResolver = (IUrlResolutionService)sender;
                if (urlResolver != null)
                {
                    UploadedLogoInfo fileInfo = new UploadedLogoInfo()
                    {

                        Id = itemId,
                        FileName = e.UploadedFile.FileName,
                        FileContent = e.UploadedFile.FileBytes,
                        ContentType = e.UploadedFile.ContentType
                    };

                    SaveFileDetails(fileInfo);

                    e.CallbackData += fileInfo.FileName;
                }
            }
        }

        private static void SaveFileDetails(UploadedLogoInfo fileDetails)
        {
            
            string query = "Update Company set LogoName=@FileName, LogoContent=@FileContent, ContentType=@ContentType where id = @Id;";
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.
                            ConnectionStrings["IWSConnectionString"].ToString()))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        List<SqlParameter> p = new List<SqlParameter>
                        {
                            new SqlParameter("@Id", fileDetails.Id),
                            new SqlParameter("@FileName", fileDetails.FileName),
                            new SqlParameter("@FileContent", fileDetails.FileContent),
                            new SqlParameter("@ContentType", fileDetails.ContentType)
                        };

                        connection.Open();
                        AddParameters(command, p.ToArray());
                        command.ExecuteScalar();
                        command.Parameters.Clear();
                    }
                    catch (Exception ex)
                    {
                        IWSLookUp.LogException(ex);
                    }
                    finally
                    {
                        if (connection.State.Equals(ConnectionState.Open))
                            connection.Close();
                    }
                }
            }
        }

        private static void AddParameters(SqlCommand command, params SqlParameter[] p)
        {
            if (p != null && p.Any())
            {
                command.Parameters.AddRange(p);
            }
        }

    }
    public class UploadedLogoInfo
    {
        public string Id { get; set; }
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }
        public string ContentType { get; set; }
    }

}
