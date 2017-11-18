using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using TrabalhoFrontEnd.Services;

namespace TrabalhoFrontEnd
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
            
            container.Verify();

            DependencyResolver.SetResolver(
                new SimpleInjectorDependencyResolver(container));
        }
    }
}
