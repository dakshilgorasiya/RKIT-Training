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

namespace OrmLiteDemo
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Get connection string from Web.config
            string connStr = ConfigurationManager
                .ConnectionStrings["DefaultConnection"].ConnectionString;

            // Set the dialect provider to MySQL
            OrmLiteConfig.DialectProvider = MySqlDialect.Provider;

            // Initialize the DbFactory with the connection string and MySQL dialect
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

        // Static property to hold the OrmLiteConnectionFactory instance
        public static OrmLiteConnectionFactory DbFactory { get; private set; }
    }
}
