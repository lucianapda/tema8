using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Aplicacao.Services;
using FrontEnd.Services;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;

namespace FrontEnd
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ConfigurarDependencias();
        }

        private void ConfigurarDependencias()
        {
            var container = new Container();

            container.Register<AutenticarService>();
            container.Register<ServiceDisciplina>();
            container.Register<ServiceLaboratorio>();
            container.Register<ServiceUsuario>();
            container.Register<ServiceAgendamento>();


            container.Verify();

            DependencyResolver.SetResolver(
                new SimpleInjectorDependencyResolver(container));
        }
    }
}
