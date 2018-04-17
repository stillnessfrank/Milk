using System.Web.Optimization;

namespace BIMFM.Web
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            //VENDOR RESOURCES

            //~/Bundles/vendor/css
            bundles.Add(
                new StyleBundle("~/Bundles/vendor/css")
                    .Include("~/theme/assets/plugins/jquery-ui/themes/base/minified/jquery-ui.min.css", new CssRewriteUrlTransform())
                    .Include("~/theme/assets/plugins/bootstrap/css/bootstrap.min.css", new CssRewriteUrlTransform())
                    .Include("~/theme/assets/plugins/font-awesome/css/font-awesome.min.css", new CssRewriteUrlTransform())
                    .Include("~/theme/assets/css/animate.min.css", new CssRewriteUrlTransform())
                    .Include("~/theme/assets/css/style.min.css", new CssRewriteUrlTransform())
                    .Include("~/theme/assets/css/style-responsive.min.css", new CssRewriteUrlTransform())
                    .Include("~/theme/assets/css/theme/default.css", new CssRewriteUrlTransform())
                );

            //~/Bundles/vendor/js/top (These scripts should be included in the head of the page)
            bundles.Add(
                new ScriptBundle("~/Bundles/vendor/js/top")
                    .Include()
                );

            //~/Bundles/vendor/bottom (Included in the bottom for fast page load)
            bundles.Add(
                new ScriptBundle("~/Bundles/vendor/js/bottom")
                    .Include(
                        //"~/Scripts/json2.min.js",
                        "~/Scripts/jquery-1.12.1.min.js",
                        //"~/theme/assets/plugins/jquery/jquery-1.9.1.min.js",
                        "~/theme/assets/plugins/jquery/jquery-migrate-1.1.0.min.js",
                        "~/theme/assets/plugins/jquery-ui/ui/minified/jquery-ui.min.js",
                        "~/theme/assets/plugins/bootstrap/js/bootstrap.min.js",

                        "~/theme/assets/plugins/pace/pace.min.js",

                        //"~/theme/assets/plugins/bootstrap/js/popper.min.js",
                        //"~/theme/assets/plugins/bootstrap/js/bootstrap.min.js",

                        //"~/Scripts/moment-with-locales.min.js",
                        //"~/Scripts/jquery.validate.min.js",
                        //"~/Scripts/jquery.blockUI.js",
                        //"~/Scripts/toastr.min.js",
                        //"~/Scripts/sweetalert/sweet-alert.min.js",
                        //"~/Scripts/others/spinjs/spin.js",
                        //"~/Scripts/others/spinjs/jquery.spin.js",

                        //"~/Abp/Framework/scripts/abp.js",
                        //"~/Abp/Framework/scripts/libs/abp.jquery.js",
                        //"~/Abp/Framework/scripts/libs/abp.toastr.js",
                        //"~/Abp/Framework/scripts/libs/abp.blockUI.js",
                        //"~/Abp/Framework/scripts/libs/abp.spin.js",
                        //"~/Abp/Framework/scripts/libs/abp.sweet-alert.js",

                        //"~/Scripts/jquery.signalR-2.2.1.min.js",

                        "~/theme/assets/plugins/slimscroll/jquery.slimscroll.min.js",
                        "~/theme/assets/plugins/jquery-cookie/jquery.cookie.js"
                        
                    //"~/theme/js/perfect-scrollbar.jquery.min.js",
                    //"~/theme/js/waves.js",
                    //"~/theme/js/sidebarmenu.js",
                    //"~/theme/assets/plugins/sticky-kit-master/dist/sticky-kit.min.js",
                    //"~/theme/assets/plugins/sparkline/jquery.sparkline.min.js",
                    //"~/theme/js/custom.min.js",

                    //"~/theme/assets/plugins/styleswitcher/jQuery.style.switcher.js"
                    )
                );

            //APPLICATION RESOURCES

            //~/Bundles/css
            bundles.Add(
                new StyleBundle("~/Bundles/css")
                    .Include("~/css/bootstrap-reset.css",
                    "~/css/style.css",
                    "~/css/style-responsive.css",
                    "~/css/custom.css"
                    )
                );

            //~/Bundles/js
            bundles.Add(
                new ScriptBundle("~/Bundles/js")
                    .Include(/*"~/js/main.js"*/)
                );
        }
    }
}