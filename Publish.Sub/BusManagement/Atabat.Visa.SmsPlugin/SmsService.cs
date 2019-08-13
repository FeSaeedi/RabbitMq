using BusManagement.Plugins.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atabat.Visa.SmsPlugin
{
    [Export("ConsumerPlugin", typeof(IConsumerPlugin))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SmsService : IConsumerPlugin
    {
        public string QueueName { get => "SMS"; }

        public async Task<int> Notify(string  x)
        {
            if (x == "0") return 0;

            return 1;
        }
    }
}
