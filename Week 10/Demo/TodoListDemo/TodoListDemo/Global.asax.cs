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
using NLog;

namespace TodoListDemo
{
    /// <summary>
    /// A class to configure and start the Web API application
    /// </summary>
    public class WebApiApplication : System.Web.HttpApplication
    {
        // Logger to log information
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Application start event handler
        /// </summary>
        protected void Application_Start()
        {
            // Configure NLog from the configuration file
            LogManager.Setup().LoadConfigurationFromFile("NLog.config");
            Logger.Info("Application starting...");

            // Get the connection string from configuration
            string connStr = ConfigurationManager
                .ConnectionStrings["DefaultConnection"].ConnectionString;

            // Set the dialect provider for OrmLite to MySQL
            OrmLiteConfig.DialectProvider = MySqlDialect.Provider;

            // Initialize the database factory
            DbFactory = new OrmLiteConnectionFactory(
            connStr,
            MySqlDialect.Provider
            );

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Logger.Info("Application started successfully");
        }

        /// <summary>
        /// A static property to hold the OrmLite connection factory
        /// </summary>
        public static OrmLiteConnectionFactory DbFactory { get; private set; }
    }
}
