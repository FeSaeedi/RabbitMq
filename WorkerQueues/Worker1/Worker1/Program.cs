using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Worker1
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionFactory connectionFactory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = connectionFactory.CreateConnection())
            using (var chanel = connection.CreateModel())
            {
                chanel.QueueDeclare(queue: "task_queu", durable: false, exclusive: false, autoDelete: false, arguments: null);
              
                var consumer = new EventingBasicConsumer(chanel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine("[x] Recived {0}", message);
                    int dots = message.Split('.').Length - 1;
                    Thread.Sleep(dots * 1000);
                    Console.WriteLine("[x] Done");
                };
                chanel.BasicConsume(queue: "task_queu", autoAck: true, consumer: consumer);
                Console.WriteLine("Press enu Key");
                Console.ReadLine();
            }
        }
    }
}
