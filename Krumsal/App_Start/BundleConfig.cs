using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Kurumsal.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/css/layout").Include(
               "~/Content/css/cart.css",
               "~/Content/css/cart_responsive.css",
               "~/Content/css/categories.css",
               "~/Content/css/categories_responsive.css",
               "~/Content/css/checkout.css",
               "~/Content/css/checkout_responsive.css",
               "~/Content/css/contact.css",
               "~/Content/css/contact_responsive.css",
               "~/Content/css/main_styles.css",
               "~/Content/css/product.css",
               "~/Content/css/product_responsive.css",
               "~/Content/css/responsive.css",
               "~/Content/css/bootstrap4/bootstrap.min.css",
               "~/Content/plugins/OwlCarousel2-2.2.1/owl.theme.default.css",
               "~/Content/plugins/OwlCarousel2-2.2.1/owl.carousel.css",
               "~/Content/plugins/OwlCarousel2-2.2.1/animate.css"

                ));

            bundles.Add(new ScriptBundle("~/script/layout").Include(
               "~/Content/js/cart.js",
               "~/Content/js/categories.js",
               "~/Content/js/checkout.js",
               "~/Content/js/contact.js",
               "~/Content/js/custom.js",
               "~/Content/js/jquery-3.2.1.min.js",
               "~/Content/js/product.js",
               "~/Content/js/bootstrap4/popper.js",
               "~/Content/js/bootstrap4/bootstrap.min.js",
               "~/Content/plugins/easing/easing.js",
               "~/Content/plugins/greensock/animation.gsap.min.js",
               "~/Content/plugins/greensock/ScrollToPlugin.min.js",
               "~/Content/plugins/greensock/TimelineMax.min.js",
               "~/Content/plugins/greensock/TweenMax.min.js",
               "~/Content/plugins/Isotope/isotope.min.js",
               "~/Content/plugins/OwlCarousel2-2.2-1/owl.carousel.js",
               "~/Content/plugins/scrollmagic/ScrollMagic.min.js"
               ));

            bundles.Add(new StyleBundle("~/css/adminlayout").Include(
                "~/Content/Admin Panel/css/sb-admin-2.min.css",
                "~/Content/DataTables/css/jquery.dataTables.css",
                "~/Content/DataTables/css/dataTables.bootstrap4.css",
                "~/Content/ckeditor/contents.css"

                ));

            bundles.Add(new ScriptBundle("~/script/adminlayout").Include(
                "~/Scripts/DataTables/dataTables.bootstrap4.js",
                "~/Scripts/DataTables/jquery.dataTables.js"
                ));

            bundles.Add(new ScriptBundle("~/script/adminlayout2").Include(
                "~/Content/Admin Panel/vendor/bootstrap/js/bootstrap.bundle.min.js",
                "~/Content/Admin Panel/js/sb-admin-2.min.js",
                "~/Content/Admin Panel/vendor/chart.js/Chart.min.js",
                "~/Content/Admin Panel/js/demo/chart-area-demo.js",
                "~/Content/Admin Panel/js/demo/chart-pie-demo.js"
                ));

            bundles.Add(new StyleBundle("~/css/login").Include(
                    "~/Content/Admin Panel/css/sb-admin-2.min.css",
                    "~/Content/DataTables/css/jquery.dataTables.css",
                    "~/Content/DataTables/css/dataTables.bootstrap4.css"
                ));

            bundles.Add(new ScriptBundle("~/script/login").Include(
                    "~/Content/Admin Panel/vendor/jquery-easing/jquery.easing.min.js",
                    "~/Content/Admin Panel/vendor/jquery/jquery.min.js",
                    "~/Scripts/DataTables/jquery.dataTables.js",
                    "~/Scripts/DataTables/dataTables.bootstrap4.js"
                ));

            bundles.Add(new ScriptBundle("~/script/login2").Include(
                    "~/Content/Admin Panel/vendor/bootstrap/js/bootstrap.bundle.min.js",
                    "~/Content/Admin Panel/js/sb-admin-2.min.js",
                    "~/Content/Admin Panel/vendor/chart.js/Chart.min.js",
                    "~/Content/Admin Panel/js/demo/chart-area-demo.js",
                    "~/Content/Admin Panel/js/demo/chart-pie-demo.js"
                ));


            BundleTable.EnableOptimizations = true;
        }
    }
}