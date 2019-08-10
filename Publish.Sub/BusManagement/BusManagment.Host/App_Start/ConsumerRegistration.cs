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
            List<CounsumerModel> consumers = consumerServ.GetAllConsumerDB();
            consumers.ForEach(con=> consumerServ.RegisterChannel(con.Exchange,con.QeueuName, con.Address, con.TypeId));
        }
    }
}