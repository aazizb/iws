using System.Web.Optimization;

namespace IWSProject.App_Start
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Scripts
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            //CSS
            bundles.Add(new StyleBundle("~/bundles/style").Include(
                "~/Content/Site.css"));
            bundles.Add(new StyleBundle("~/bundles/style").Include(
                "~/Content/jquery-ui.css"));
            bundles.Add(new StyleBundle("~/bundles/style").Include(
                "~/Content/jquery-ui.min.css"));


            BundleTable.EnableOptimizations = true;

        }
    }
}