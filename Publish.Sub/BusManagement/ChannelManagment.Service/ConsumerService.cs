using BusManagment.Core;
using BusManagment.Core.Consumer;
using ChannelManagment.Core;
using ChannelManagment.Data;
using System;
using System.Collections.Generic;

namespace ChannelManagment.Service
{
    public class ConsumerService : IConsumerService
    {
        private readonly IChannel channel;
        private readonly IConsumerRepository consumerRepository;
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
    }
}
