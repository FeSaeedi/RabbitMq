using BusManagement.Plugins.Contract;
using BusManagment.Core;
using BusManagment.Core.Consumer;
using BusManagment.Core.Plugin;
using ChannelManagment.Core;
using ChannelManagment.Data;
using System;
using System.Collections.Generic;

namespace ChannelManagment.Service
{
    public class ConsumerService : IConsumerService
    {
        private readonly IChannel channel;
        private readonly  IConsumerRepository consumerRepository;
        private readonly IPluginManeger pluginManeger;
        public ConsumerService()
        {
            channel = RabbitmqChannel.GetRabbitmq();
            consumerRepository = new ConsumerRepository();

        }
        public void Add(string exchange, string qeueuName, string address, int typeId)
        {
            this.RegisterChannel(exchange, qeueuName, address, typeId);
            consumerRepository.Add(exchange, qeueuName, address, typeId);
        }

        public List<CounsumerModel> GetAllConsumerDB()
        {
            return consumerRepository.GetAll();
        }

        public void RegisterChannel(string exchange, string qeueuName, string address, int typeId)
        {
            channel.RegisterConsumer(exchange, qeueuName, address, typeId);
        }

        public void RegisterOnChannel(List<IConsumerPlugin> plugins)
        {
            //Plugin
            plugins.ForEach(pl=>pluginManeger.RegisterOnChannel(pl, channel));
            //Apis
            List<CounsumerModel> apiConsumers = this.GetAllConsumerDB();
            apiConsumers.ForEach(con => this.RegisterChannel(con.Exchange, con.QeueuName, con.Address, con.TypeId));

        }
    }
}
