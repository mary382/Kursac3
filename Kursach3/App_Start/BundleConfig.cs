using System.Web;
using System.Web.Optimization;

namespace Kursach3
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.rateyo.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/summernote").Include(
                        "~/Scripts/summernote.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                      "~/Scripts/angular.min.js",
                      "~/Scripts/angular-ui-router.min.js",
                      "~/Scripts/angular-route.min.js",
                      "~/Scripts/angular-resource.min.js",
                      "~/Scripts/angular-sanitize.min.js"

                      ));

            bundles.Add(new ScriptBundle("~/bundles/angularApp").Include(
                      "~/Scripts/app.js",
                      "~/Scripts/Controllers/searchController.js",
                      "~/Scripts/Controllers/searchPageController.js",
                      "~/Scripts/Controllers/popularCreativeController.js",
                      "~/Scripts/Controllers/newCreativeController.js",
                      "~/Scripts/Controllers/tagsController.js",
                      "~/Scripts/Controllers/userDataController.js",
                      "~/Scripts/Controllers/userCreativesController.js",
                      "~/Scripts/Controllers/addController.js",
                      "~/Scripts/Controllers/readController.js",
                      "~/Scripts/Controllers/redactController.js",
                      "~/Scripts/Services/homePageService.js",
                      "~/Scripts/Services/userPageService.js",
                      "~/Scripts/Directives/modalDialog.js",
                      "~/Scripts/Directives/tagInput.js",
                      "~/Scripts/Configs/readConfig.js"));

            bundles.Add(new StyleBundle("~/Content/day").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/UserPage.Day.css"));

            bundles.Add(new StyleBundle("~/Content/night").Include(
                      "~/Content/bootstrap.darkly.css",
                      "~/Content/UserPage.Night.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Site.css",
                      "~/Content/search.css",
                      "~/Content/creative-reader-style.css",
                      "~/Content/day-night-ru-en-style.css",
                      "~/Content/tag-style.css",
                      "~/Content/creating-style.css",
                      "~/Content/tag-cloud.css",
                      "~/Content/userpage.css",
                      "~/Content/jquery.rateyo.css",
                      "~/Content/summernote.css"));

        }
    }
}
