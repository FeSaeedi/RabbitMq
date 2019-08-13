using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusManagement.Plugins.Contract;
using ChannelManagment.Core;

namespace BusManagment.Core.Plugin
{
    public class PluginManeger : IPluginManeger
    {
        public void RegisterOnChannel(IConsumerPlugin pl, IChannel channel)
        {
            string queueName = pl.QueueName;
            channel.RegisterConsumer( queueName, pl.Notify);
        }
    }
}
