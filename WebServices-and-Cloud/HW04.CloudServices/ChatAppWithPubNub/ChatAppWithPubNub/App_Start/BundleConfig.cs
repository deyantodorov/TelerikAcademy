using System.Web.Optimization;

namespace ChatAppWithPubNub
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterScripts(bundles);
            RegisterStyles(bundles);

            // Set to True in production
            BundleTable.EnableOptimizations = true;
        }

        private static void RegisterScripts(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts")
                .Include(
                        "~/Scripts/lib/jquery-2.1.4.min.js",
                        "~/Scripts/lib/sammy-0.7.5.min.js",
                        "~/Scripts/lib/handlebars.min.js",
                        "~/Scripts/lib/bootstrap.min.js",
                        "~/Scripts/lib/toastr.min.js",
                        "~/Scripts/app/controllers/chatController.js",
                        "~/Scripts/app/validator.js",
                        "~/Scripts/app/data.js",
                        "~/Scripts/app/templates.js",
                        "~/Scripts/app/jsonRequester.js",
                        "~/Scripts/app/app.js"
                        ));
        }

        private static void RegisterStyles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-theme.css",
                      "~/Content/toastr.min.css",
                      "~/Content/main.css"
                    ));
        }
    }
}
