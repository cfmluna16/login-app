using System;
using System.Web.Optimization;

namespace LoginApp
{
    public class BundleConfig
    {
        public BundleConfig()
        {

        }

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/import-js").Include(
                "~/Scripts/jquery-3.0.0.js",
                "~/Scripts/bootstrap.js"
                //"~/Scripts/bootstrap.bundle.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/modernizr-js").Include(
                "~/Scripts/modernizr-2.8.3.js"

            ));

            bundles.Add(new StyleBundle("~/bundles/styles").Include(
                "~/Content/bootstrap.css"
                , "~/Content/bootstrap-theme.css"
            ));
        }
    }
}
