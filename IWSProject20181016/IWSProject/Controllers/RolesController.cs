using System;
using System.Linq;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using IWSProject.Content;
using IWSProject.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IWSProject.Controllers
{
    [Authorize]
    public class RolesController : Controller
    {
        private ApplicationDbContext context;
        public RolesController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Roles
        public ActionResult Index()
        {
            return View(context.Roles.ToList());
        }

        [ValidateInput(false)]
        public ActionResult RolesGridViewPartial()
        {
            return PartialView("RolesGridViewPartial", context.Roles.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult RolesGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] IdentityRole item)
        {
            var roleManager=new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            ViewData["role"] = item;
            //item.CompanyID = (string)Session["CompanyID"];
            if (ModelState.IsValid)
            {
                if (roleManager.RoleExists(item.Name.Trim()))
                {
                    return PartialView("RolesGridViewPartial", roleManager.Roles.ToList());
                }
                try
                {
                    var role = new IdentityRole(item.Name.Trim());
                    roleManager.Create(role);
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
            return PartialView("RolesGridViewPartial", roleManager.Roles.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult RolesGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] IdentityRole item)
        {
            var model = context.Roles.ToList();
            ViewData["role"] = item;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.Id == item.Id);
                    if (modelItem != null)
                    {
                        UpdateModel(modelItem);
                        context.SaveChanges();
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
            return PartialView("RolesGridViewPartial", context.Roles.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult RolesGridViewPartialDelete(string id)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (id != null)
            {
                try
                {
                    IdentityRole role = roleManager.FindById(id);
                    if (role != null)
                        roleManager.Delete(role);
                }
                catch (Exception e)
                {
                    ViewData["GenericError"] = e.Message;
                    IWSLookUp.LogException(e);
                }
            }
            return PartialView("RolesGridViewPartial", roleManager.Roles.ToList());
        }
    }
}