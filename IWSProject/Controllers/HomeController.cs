using System.Web.Mvc;
namespace IWSProject.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        //[ValidateInput(false)]
        //public ActionResult AccountBalance()
        //{
        //    AccountBalance accountBalance = new AccountBalance();
 
        //    accountBalance.Parameters["CompanyID"].Value = (string)Session["CompanyID"];

        //    return View(accountBalance);
        //}
        //[ValidateInput(false)]
        //public ActionResult PeriodicBalance()
        //{
        //    return View();
        //}
        //[ValidateInput(false)]
        //public ActionResult SalesInvoiceXS()
        //{
        //    return View();
        //}
        //[ValidateInput(false)]
        //public ActionResult PurchaseOrderXS()
        //{
        //    return View();
        //}
    }
}
