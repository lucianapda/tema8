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
        internal static HttpConfiguration HttpConfiguration { get; private set; }
        protected void Application_Start()
        {
            HttpConfiguration = new HttpConfiguration();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            WebApiConfig.Register(HttpConfiguration);

            AutoMapper.Mapper.Initialize(configuration =>
            {
                var map = AutoMapperConfig.GetProfiles()
                .Union(AutoMapperConfig.GetProfiles());

                foreach (Profile profile in map)
                {
                    configuration.AddProfile(profile);
                }
            });
        }
    }
}
