using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory();
            factory.HostName = "localhost";
           // factory.UserName = "deldel";
           // factory.Password = "frefre";
           // factory.VirtualHost = "/";
           // factory.Port = AmqpTcpEndpoint.UseDefaultPort;
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                //channel.QueueDeclare(queue: "hello",
                //                     durable: false,
                //                     exclusive: false,
                //                     autoDelete: false,
                //                     arguments: null);

                //string message = "Hello World!";
                //var body = Encoding.UTF8.GetBytes(message);

                //channel.BasicPublish(exchange: "",
                //                     routingKey: "hello",
                //                     basicProperties: null,
                //                     body: body);

                var message = "Hello World!";
                var body = Encoding.UTF8.GetBytes(message);
                

                channel.BasicPublish(exchange: "complete_register",
                      routingKey: "",
                      basicProperties: null,
                      body: body);


                Console.WriteLine(" [x] Sent {0}", message);

                var input = Console.ReadLine();
                body = Encoding.UTF8.GetBytes(input);


                channel.BasicPublish(exchange: "complete_register",
                      routingKey: "",
                      basicProperties: null,
                      body: body);

                Console.WriteLine(" [x] Sent {0}", message);

                var input2 = Console.ReadLine();
                body = Encoding.UTF8.GetBytes(input2);


                channel.BasicPublish(exchange: "complete_register",
                      routingKey: "",
                      basicProperties: null,
                      body: body);

            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
    
}
