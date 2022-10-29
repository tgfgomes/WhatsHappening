using System.Web;
using System.Web.Optimization;

namespace WhatsHappening.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate.js",
                        "~/Scripts/jquery.validate.unobtrusive.js",
                        "~/Scripts/jquery.validate.unobtrusive.bootstrap.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.unobtrusive*",
            //            "~/Scripts/jquery.validate*",
            //            "~/Scripts/jquery.validate.unobtrusive.bootstrap.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //'Object reference not set to an instance of an object.' ????????
            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap*",
                //"~/Scripts/locales/bootstrap*",
                      "~/Scripts/select2.js",
                //"~/Scripts/Select2-locales/select2*",
                      "~/Scripts/bloodhound*",
                      "~/Scripts/typeahead*",
                      //"~/Scripts/site.js",
                      "~/Scripts/site.*",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/cssBundle").Include(
                        "~/Content/bootstrap.css",
                //"~/Content/bootstrap-theme.css",
                        "~/Content/bootstrap-datepicker.css",
                        "~/Content/bootstrap-datepicker3.css",
                        "~/Content/typeahead.css",
                        "~/Content/css/select2.css",
                        "~/Content/select2-bootstrap.css",
                        "~/Css/bootstrap-multiselect.css",
                        "~/Content/site.css"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = false;
        }
    }
}

