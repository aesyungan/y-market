using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using y_market.Models;

namespace y_market
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //activar migracion automatica que comprueba si los models cambio
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<
                    Models.y_marketContext,
                Migrations.Configuration>());
            //end migraions
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }
    }
}
