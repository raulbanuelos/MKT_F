using System.Web;
using System.Web.Optimization;

namespace MKT.Web
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/js/bootstrap.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/JSTheme").Include(
                "~/js/jquery.scrollTo.min.js",
                "~/js/jquery.nicescroll.js",
                "~/js/jquery.validate.min.js",
                "~/js/form-validation-script.js",
                "~/js/scripts.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/css/bootstrap-theme.css",
                      "~/css/elegant-icons-style.css",
                      "~/css/font-awesome.min.css",
                      "~/css/style.css",
                      "~/css/style-responsive.css",
                      "~/css/jquery.dataTables.min.css"
                      ));


        }
    }
}
