using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AccessTokenRefreshTokenDemo
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            string connStr = ConfigurationManager
                .ConnectionStrings["DefaultConnection"].ConnectionString;

            OrmLiteConfig.DialectProvider = MySqlDialect.Provider;

            DbFactory = new OrmLiteConnectionFactory(
            connStr,
            MySqlDialect.Provider
            );

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public static OrmLiteConnectionFactory DbFactory { get; private set; }
    }
}
