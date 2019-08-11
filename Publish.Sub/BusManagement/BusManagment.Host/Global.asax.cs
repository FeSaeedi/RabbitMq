using BusManagement.Plugins.Contract;
using BusManagment.Host.App_Start;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BusManagment.Host
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var pluginFolders = new List<string>();

            var plugins = Directory.GetDirectories(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins")).ToList();

            plugins.ForEach(s =>
            {
                var di = new DirectoryInfo(s);
                pluginFolders.Add(di.Name);
            });



            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Bootstrapper.Compose(pluginFolders);
           // ConsumerRegistration.Register();

            var controller = Bootstrapper.GetInstance<IQueuePlugin>();
            int x = 10;
        }
    }
}
