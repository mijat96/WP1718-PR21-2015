using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebAPI.Models;

namespace WebAPI
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

            string path = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/Musterije.txt");
            Musterije users = new Musterije(path);

            path = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/Dispeceri.txt");
            Dispeceri disp = new Dispeceri(path);

            path = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/Vozaci.txt");
            Vozaci drivers = new Vozaci(path);

            path = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/Voznje.txt");
            Voznje rides = new Voznje(path);
        }
    }
}
