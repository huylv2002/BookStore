using System.Web;
using System.Web.Optimization;

namespace ThienLongBook
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

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/cssMain").Include("~/Content/css/bootstrap.min.css").Include("~/Content/css/normalize.css").Include("~/Content/css/font-awesome.min.css").Include(
     "~/Content/css/icomoon.css").Include("~/Content/css/jquery-ui.css").Include(
     "~/Content/css/owl.carousel.css").Include("~/Content/css/transitions.css").Include(
     "~/Content/css/main.css").Include("~/Content/css/color.css").Include("~/Content/css/responsive.css"));
            
            bundles.Add(new ScriptBundle("~/Script/jsMain").Include(
                "~/Scripts/js/vendor/modernizr-2.8.3-respond-1.4.2.min.js").Include(
                "~/Scripts/js/vendor/jquery-library.js").Include(
                "~/Scripts/js/vendor/bootstrap.min.js").Include(
		        "~/Scripts/js/owl.carousel.min.js"
	        ).Include(
                "~/Scripts/js/jquery.vide.min.js"
            ).Include(
                "~/Scripts/js/countdown.js"
            ).Include(
                "~/Scripts/js/parallax.js"
            ).Include(
                "~/Scripts/js/countTo.js" 
	        ).Include(
                "~/Scripts/js/appear.js"
            ).Include(
                "~/Scripts/js/gmap3.js"
            ).Include(
                "~/Scripts/js/main.js"
            ).Include("~/Scripts/js/jquery-ui.js"));
        }
    }
}
