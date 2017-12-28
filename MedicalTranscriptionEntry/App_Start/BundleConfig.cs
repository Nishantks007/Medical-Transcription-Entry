using System.Web;
using System.Web.Optimization;

namespace MedicalTranscriptionEntry
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

        
            

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                       "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/DataTables").Include(
                      "~/Scripts/DataTables/jquery.dataTables.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/dataTables").Include(
     "~/Scripts/DataTables/jquery.dataTables.min.js",
     "~/Scripts/DataTables/dataTables.bootstrap.min.js",
     "~/Scripts/DataTables/dataTables.buttons.min.js",
     "~/Scripts/DataTables/buttons.flash.min.js",
     "~/Scripts/DataTables/jszip.min.js",
     "~/Scripts/DataTables/pdfmake.min.js",
     "~/Scripts/DataTables/vfs_fonts.js",
     "~/Scripts/DataTables/moment.min.js",
     "~/Scripts/DataTables/datetime.js",
     "~/Scripts/DataTables/buttons.html5.min.js",
     "~/Scripts/DataTables/buttons.print.min.js",
     "~/Scripts/bootStrapValidator.js"
     ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
          "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/customcss")
.Include("~/Content/DataTables/css/jquery.dataTables.min.css", new CssRewriteUrlTransform())
.Include("~/Content/DataTables/css/dataTables.jqueryui.min.css", new CssRewriteUrlTransform())
.Include("~/Content/DataTables/css/dataTables.bootstrap.min.css", new CssRewriteUrlTransform())
.Include("~/Content/DataTables/css/buttons.bootstrap.min.css", new CssRewriteUrlTransform())
.Include("~/Content/DataTables/css/buttons.dataTables.min.css", new CssRewriteUrlTransform())


);
            bundles.Add(new ScriptBundle("~/bundles/notify").Include(
                   "~/Scripts/notify.js",
                    "~/Scripts/notify.min.js"));

        }
    }
}
