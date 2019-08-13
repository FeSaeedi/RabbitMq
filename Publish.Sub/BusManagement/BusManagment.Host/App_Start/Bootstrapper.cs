using BusManagement.Plugins.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;

namespace BusManagment.Host.App_Start
{
    public class Bootstrapper
    {
        private static CompositionContainer compositioncontainer;
        private static bool isloaded = false;

        public static void Compose(List<string> pluginfolders)
        {
            if (isloaded)
            {
                return;
            }

            var catalog = new AggregateCatalog();


            catalog.Catalogs.Add(new DirectoryCatalog(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin")));

            foreach (var plugin in pluginfolders)
            {
                var directorycatalog = new DirectoryCatalog(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins", plugin));
                catalog.Catalogs.Add(directorycatalog);

            }




            compositioncontainer = new CompositionContainer(catalog);
            compositioncontainer.ComposeParts();
            //var plugins = GetInstance<IQueuePlugin>("Plugin1");
            //foreach (var item in plugins)
            //{
            //    var index = item.test(40);
            //}

            isloaded = true;
        }

        public static List<t> GetInstance<t>(string contractname = null)
        {
            var type = new List<t>();
            if (compositioncontainer == null)
            {
                return type;
            }

            if (!string.IsNullOrWhiteSpace(contractname))
            {
                var rerr = compositioncontainer.GetExportedValue<t>(contractname);
                type = compositioncontainer.GetExportedValues<t>(contractname).ToList<t>();
            }
            else
            {
                type = compositioncontainer.GetExportedValues<t>().ToList<t>();
            }

            return type;
        }
    }
}