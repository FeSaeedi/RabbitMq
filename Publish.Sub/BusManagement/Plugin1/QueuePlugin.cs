using BusManagement.Plugins.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin1
{
    public class QueuePlugin : IQueuePlugin
    {
        public int test(int x)
        {
            return x + 6;
        }
    }
}
