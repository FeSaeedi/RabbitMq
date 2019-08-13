using ChannelManagment.Core;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusManagment.Core
{
    public class RabbitmqChannel : IChannel
    {
        #region Fields
        ILog log;
        private static RabbitmqChannel _instance;
        private IModel _channel;
        #endregion

        #region Cto
        private RabbitmqChannel()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            factory.Port = AmqpTcpEndpoint.UseDefaultPort;
            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();

        }
        #endregion

        public static RabbitmqChannel GetRabbitmq()
        {
            if (_instance == null)
            {
                _instance = new RabbitmqChannel();
            }
            return _instance;
        }
        public void RegisterConsumer(string exchange, string queueName, string address, int protocolType)
        {
            //  _subscribes.Add(queueName, new SubscribeDTO(address, protocolType));

            log = LogFactory.GetLog(protocolType);

            // _channel.ExchangeDeclare(exchange: exchange, type: "fanout");
            //  var rabbitQueueName = _channel.QueueDeclare(queueName,true).QueueName;
            //  _channel.QueueBind(queue: rabbitQueueName,exchange: exchange,routingKey: "");
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (model, ea) =>
            {
                Debug.WriteLine("Recive Step1");
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                try
                {
                    bool result = await log.Write(message);
                    if (result)
                    {
                        _channel.BasicAck(ea.DeliveryTag, false);
                        Debug.WriteLine("Recive Step2");
                    }
                    else
                    {
                        _channel.BasicNack(ea.DeliveryTag, true, true);
                        Debug.WriteLine("Recive Step20");
                    }
                }
                catch (Exception exp)
                {
                    _channel.BasicNack(ea.DeliveryTag, true, true);
                    Debug.WriteLine("Recive Step3" + exp.Message);
                }
                Debug.WriteLine("Recive Step Final");
            };
            _channel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);

        }

        public void RemoveSubscriber(string queueName, string address)
        {
            // _subscribes.Remove(queueName);
        }

        public void RegisterConsumer( string queueName, Func<string, Task<int>> notifyFunc)
        {
            var rabbitQueueName = _channel.QueueDeclare(queueName, true).QueueName;
            //if (string.IsNullOrEmpty(exchangeName))
            //{
            //    _channel.ExchangeDeclare(exchange: exchangeName, type: "fanout");
            //    _channel.QueueBind(queue: rabbitQueueName,exchange: exchangeName, routingKey: "");
            //}

            ////  
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (model, ea) =>
            {
                Debug.WriteLine("Recive Step1");
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                try
                {
                    int result = await notifyFunc(message);
                    _channel.BasicAck(ea.DeliveryTag, false);
                    Debug.WriteLine("Recive Step2");
                }
                catch (Exception exp)
                {
                    _channel.BasicNack(ea.DeliveryTag, true, true);
                    Debug.WriteLine("Recive Step3" + exp.Message);
                }
                Debug.WriteLine("Recive Step Final");
            };
            _channel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);

        }
    }
}
