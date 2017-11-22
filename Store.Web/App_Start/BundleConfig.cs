using System.Web;
using System.Web.Optimization;

namespace Store.Web
{
    public class BundleConfig
    {
  
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {


            bundles.Add(new StyleBundle("~/Common/css").Include(
                     "~/Common/css/bootstrap.css",
                     "~/Common/css/awe-icon.css",
                       "~/Common/css/font-awesome.css",
                         "~/Common/css/magnific-popup.css",
                           "~/Common/css/owl.carousel.css",
                             "~/Common/css/awemenu.css",
                               "~/Common/css/swiper.css",
                                 "~/Common/css/easyzoom.css",
                                   "~/Common/css/nanoscroller.css",
                                     "~/Common/css/awe-background.css",
                                       "~/Common/css/main.css",
                                         "~/Common/css/docs.css"));

            bundles.Add(new ScriptBundle("~/newbundles/jquery").Include(
                        "~/Common/js/vendor/jquery-1.11.3.min.js"));

            bundles.Add(new ScriptBundle("~/newbundles/modernizr").Include(
                       "~/Common/js/vendor/modernizr-*"));


            bundles.Add(new ScriptBundle("~/newbundles/bootstrap").Include(
                     "~/Common/js/vendor/jquery-ui.min.js",
                     "~/Common/js/plugins/bootstrap.min.js",
                     "~/Common/js/plugins/awemenu.min.js",
                     "~/Common/js/plugins/headroom.min.js",
                     "~/Common/js/plugins/hideshowpassword.min.js",
                     "~/Common/js/plugins/jquery.parallax-1.1.3.min.js",
                     "~/Common/js/plugins/jquery.magnific-popup.min.js",
                     "~/Common/js/plugins/jquery.nanoscroller.min.js",
                     "~/Common/js/plugins/swiper.min.js",
                     "~/Common/js/plugins/owl.carousel.min.js",
                     "~/Common/js/plugins/jquery.countdown.min.js",
                     "~/Common/js/plugins/easyzoom.js",
                     "~/Common/js/plugins/masonry.pkgd.min.js",
                     "~/Common/js/plugins/isotope.pkgd.min.js",
                     "~/Common/js/plugins/imagesloaded.pkgd.min.js",
                     "~/Common/js/plugins/gmaps.min.js",
                     "~/Common/js/awe/awe-carousel-branch.js",
                     "~/Common/js/awe/awe-carousel-blog.js",
                     "~/Common/js/awe/awe-carousel-products.js",
                     "~/Common/js/awe/awe-carousel-testimonial.js",
                     "~/Common/js/awe-hosoren.js",
                     "~/Common/js/main.js",
                     "~/Common/js/plugins/list.min.js",
                     "~/Common/js/docs.js"));



            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));






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
        }
    }
}
