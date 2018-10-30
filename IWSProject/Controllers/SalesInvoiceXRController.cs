using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IWSProject.Reports;
using IWSProject.Models;
namespace IWSProject.Controllers
{
    [Authorize]
    public class SalesInvoiceXRController : Controller
    {
        // GET: SalesInvoiceXR
        public ActionResult Index()
        {
            string companyID = (string)Session["CompanyID"];
            int modelId = (int)IWSLookUp.LogisticMasterModelId.SalesInvoice;
            SalesInvoiceXS report = new SalesInvoiceXS();

            report.Parameters["CompanyId"].Value = companyID;
            report.Parameters["CompanyId"].Visible = false;
            report.Parameters["ModelId"].Value = modelId;
            report.Parameters["ModelId"].Visible = false;
            ViewData["Report"] = report;

            return View();

        }

        public ActionResult DocumentViewerPartial()
        {
            string companyID = (string)Session["CompanyID"];
            int modelId = (int)IWSLookUp.LogisticMasterModelId.SalesInvoice;
            SalesInvoiceXS report = new SalesInvoiceXS();

            report.Parameters["CompanyId"].Value = companyID;
            report.Parameters["ModelId"].Value = modelId;
            ViewData["Report"] = report;

            return PartialView("DocumentViewerPartial");
        }

        public ActionResult ExportDocumentViewer()
        {
            return DevExpress.Web.Mvc.ReportViewerExtension.ExportTo(new SalesInvoiceXS());
        }
    }
}