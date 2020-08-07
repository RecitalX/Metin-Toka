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
            #region Kullanıcı Cascading Style Layers
            bundles.Add(new StyleBundle("~/css/layout").Include(
               "~/Content/img/favicon.ico",
               "~/Content/css/bootstrap.min.css",
               "~/Content/css/font-awesome.min.css",
               "~/Content/css/owl.carousel.css",
               "~/Content/css/animate.css",
               "~/Content/css/style.css"
                ));
            #endregion

            #region Kullanıcı Javascript
            bundles.Add(new ScriptBundle("~/script/layout").Include(
               "~/Content/js/jquery-3.2.1.min.js",
               "~/Content/js/owl.carousel.min.js",
               "~/Content/js/main.js"
               ));
            #endregion

            #region Admin Cascading Style Layers
            bundles.Add(new StyleBundle("~/css/adminlayout").Include(
                "~/Content/Admin Panel/css/sb-admin-2.min.css",
                "~/Content/ckeditor/contents.css"
                ));
            #endregion

            #region Admin Javascript
            bundles.Add(new ScriptBundle("~/script/adminlayout").Include(
                "~/Content/Admin Panel/vendor/bootstrap/js/bootstrap.bundle.min.js",
                "~/Content/Admin Panel/js/sb-admin-2.min.js",
                "~/Content/Admin Panel/vendor/chart.js/Chart.min.js",
                "~/Content/Admin Panel/vendor/jquery-easing/jquery.easing.min.js",
                "~/Content/Admin Panel/js/demo/chart-area-demo.js",
                "~/Content/Admin Panel/js/demo/chart-pie-demo.js"
                ));
            #endregion

            #region Login Cascading Style Layers
            bundles.Add(new StyleBundle("~/css/login").Include(
                    "~/Content/Admin Panel/css/sb-admin-2.min.css",
                    "~/Content/DataTables/css/jquery.dataTables.css",
                    "~/Content/DataTables/css/dataTables.bootstrap4.css"
                ));
            #endregion

            #region Login Javascript
            bundles.Add(new ScriptBundle("~/script/login").Include(
                    "~/Content/Admin Panel/vendor/jquery-easing/jquery.easing.min.js",
                    "~/Content/Admin Panel/vendor/jquery/jquery.min.js",
                    "~/Scripts/DataTables/dataTables.bootstrap4.js"
                ));
            #endregion

            #region Login Javascript-2
            bundles.Add(new ScriptBundle("~/script/login2").Include(
                    "~/Content/Admin Panel/vendor/bootstrap/js/bootstrap.bundle.min.js",
                    "~/Content/Admin Panel/js/sb-admin-2.min.js",
                    "~/Content/Admin Panel/vendor/chart.js/Chart.min.js",
                    "~/Content/Admin Panel/js/demo/chart-area-demo.js",
                    "~/Content/Admin Panel/js/demo/chart-pie-demo.js"
                ));
            #endregion

            BundleTable.EnableOptimizations = true;
        }
    }
}