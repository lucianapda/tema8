using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using AutoMapper;
using TrabalhoBackEnd.Mapeamentos;

namespace TrabalhoBackEnd
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RegistrarMapeamentos.Registrar();

            AutoMapper.Mapper.Initialize(configuration =>
            {
                var map = RegistrarMapeamentos.GetProfiles()
                .Union(RegistrarMapeamentos.GetProfiles());

                foreach (Profile profile in map)
                {
                    configuration.AddProfile(profile);
                }
            });
        }
    }
}
