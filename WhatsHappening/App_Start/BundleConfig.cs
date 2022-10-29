using System.Web;
using System.Web.Optimization;

namespace WhatsHappening
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/cssBundle").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/css/select2.css",
                      "~/Content/css/select2-bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/animations.css",
                      "~/Content/typehead*")
                      .IncludeDirectory("~/Content/themes/base", "*.css"));
                      //.IncludeDirectory("~/Content/themes/base/minified", "*.css"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                     "~/Scripts/select2.js",
                     "~/Scripts/angular.js",
                     "~/Scripts/angular-*",
                     "~/Scripts/angular-ui/ui-bootstrap*",
                     "~/Scripts/ui-select2.js")
                     .IncludeDirectory("~/app/AngularJsScripts", "*.js"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                      "~/Scripts/typehead*",
                      "~/Scripts/bloodhound*"));
            
        }
    }
}
