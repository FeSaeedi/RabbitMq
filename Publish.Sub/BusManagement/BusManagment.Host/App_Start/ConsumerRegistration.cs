using BusManagement.Plugins.Contract;
using BusManagment.Core.Consumer;
using ChannelManagment.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusManagment.Host.App_Start
{
    public class ConsumerRegistration
    {
        public static void Register()
        {
            IConsumerService consumerServ = new ConsumerService();
            var plugins = Bootstrapper.GetInstance<IConsumerPlugin>("ConsumerPlugin");
            consumerServ.RegisterOnChannel(plugins);

        }
    }
}