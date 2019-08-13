using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTask
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionFactory connectionFactory = new ConnectionFactory() { HostName = "192.168.12.19",UserName="deldel", Password="frefre", VirtualHost="/" };
            using (var connection = connectionFactory.CreateConnection())
            using (var chanel = connection.CreateModel())
            {
                string message = GetMesage(args);
                var body = Encoding.UTF8.GetBytes(message);
                var properties = chanel.CreateBasicProperties();
                properties.Persistent = true;
                chanel.BasicPublish(exchange: "", routingKey: "task_queu", basicProperties: properties, body: body);
                Console.Write("Send Message");
                Console.ReadLine();
            }
        }
        private static string GetMesage(string[] args)
        {
            return (args.Length > 0) ? string.Join(" ", args) : "Hello World";
        }
    }
}
