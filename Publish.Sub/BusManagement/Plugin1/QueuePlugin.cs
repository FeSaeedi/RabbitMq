using BusManagement.Plugins.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin1
{
    [Export("Plugin1", typeof(IQueuePlugin))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class QueuePlugin : IQueuePlugin
    {
        public int test(int x)
        {
            return x + 6;
        }
    }

    [Export("Plugin1", typeof(IQueuePlugin))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class QueuePlugin2 : IQueuePlugin
    {
        public int test(int x)
        {
            return x + 9;
        }
    }
}
