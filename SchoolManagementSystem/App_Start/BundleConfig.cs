using System.Web.Optimization;

namespace InstituteManagement.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundle)
        {
            AddJavascriptsReferencesIntoBundle(bundle);

            AddCSSReferencesIntoBundle(bundle);

            BundleTable.EnableOptimizations = true;
        }
        private static void AddJavascriptsReferencesIntoBundle(BundleCollection bundle)
        {
            bundle.Add(new ScriptBundle("~/js/jsbundle").Include(
                                  ));
        }

        private static void AddCSSReferencesIntoBundle(BundleCollection bundle)
        {
            bundle.Add(new StyleBundle("~/css/cssbundle")
                      .Include("~/Content/styles/extras.1.1.0.min.css", new CssRewriteUrlTransform())
                      .Include("~/Content/styles/shards-dashboards.1.1.0.min.css", new CssRewriteUrlTransform()));
        }
    }
}