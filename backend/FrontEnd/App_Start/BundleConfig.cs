using System.Web;
using System.Web.Optimization;

namespace FrontEnd
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
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/bundles/Agendamentos/Styles/Home")
                .Include("~/Areas/Agendamentos/Content/Home.css"));

            bundles.Add(new ScriptBundle("~/Scripts/Disciplina").Include(
                "~/Areas/Agendamentos/Scripts/Disciplina/cadastrar.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Laboratorio").Include(
                "~/Areas/Agendamentos/Scripts/Laboratorio/laboratorio.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Usuario").Include(
                "~/Areas/Agendamentos/Scripts/Usuario/usuario.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Agendamento").Include(
                "~/Areas/Agendamentos/Scripts/Agendamento/cadastrar.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Home").Include(
                "~/Areas/Agendamentos/Scripts/Home/home.js"));
        }
    }
}
