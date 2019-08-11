using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Web;

namespace BusManagment.Host.App_Start
{
    public class Bootstrapper
    {
        private static CompositionContainer compositioncontainer;
        private static bool isloaded = false;

        public static void Compose(List<string> pluginfolders)
        {
            if (isloaded) return;

            var catalog = new AggregateCatalog();

            catalog.Catalogs.Add(new DirectoryCatalog(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin")));

            foreach (var plugin in pluginfolders)
            {
                var directorycatalog = new DirectoryCatalog(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins", plugin));
                catalog.Catalogs.Add(directorycatalog);

            }
            compositioncontainer = new CompositionContainer(catalog);

            compositioncontainer.ComposeParts();
            isloaded = true;
        }

        public static t GetInstance<t>(string contractname = null)
        {
            var type = default(t);
            if (compositioncontainer == null) return type;

            if (!string.IsNullOrWhiteSpace(contractname))
                type = compositioncontainer.GetExportedValue<t>(contractname);
            else
                type = compositioncontainer.GetExportedValue<t>();

            return type;
        }
    }
}