﻿using System;
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

            Musterije users = new Musterije(@"C:\WebAPI\WP1718-PR21-2015\WebAPI\App_Data\Musterije.txt");
            Dispeceri disp = new Dispeceri(@"C:\WebAPI\WP1718-PR21-2015\WebAPI\App_Data\Dispeceri.txt");
            Vozaci drivers = new Vozaci(@"C:\WebAPI\WP1718-PR21-2015\WebAPI\App_Data\App_Data\Vozaci.txt");
            Voznje rides = new Voznje(@"C:\WebAPI\WP1718-PR21-2015\WebAPI\App_Data\Voznje.txt");
        }
    }
}
