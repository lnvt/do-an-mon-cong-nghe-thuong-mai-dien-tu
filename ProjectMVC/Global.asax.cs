using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ProjectMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start( )
        {
            Application.Add("Count", 0);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        void Session_Start()
        {
            Application.Lock();
            int number = int.Parse(Application.Get("Count").ToString());
            number++;
            Application.Set("Count", number);
            Application.UnLock();
        }
    }
}
