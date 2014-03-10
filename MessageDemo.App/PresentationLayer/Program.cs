using System;
using RabbitMQ.Client;

namespace PresentationLayer
{
    class Program
    {
        private const string HostName = "localhost";
        private const string UserName = "guest";
        private const string Password = "guest";
        static void Main(string[] args)
        {
            Console.WriteLine("Starting RabbitMQ Queue Creator");
            Console.WriteLine();
            Console.WriteLine();

            var connectionFactory = new RabbitMQ.Client.ConnectionFactory(){Password = Password,UserName = UserName,HostName = HostName};
            var connection = connectionFactory.CreateConnection();
            var model = connection.CreateModel();
            model.QueueDeclare("IncomingQueue",true,false,false,null);
            Console.WriteLine("Queue created");
            model.ExchangeDeclare("MySecondExchange",ExchangeType.Topic);
            Console.WriteLine("Exchange created...");
            model.QueueBind("IncomingQueue","MySecondExchange","cars");
            Console.WriteLine("Exchange and Queue bound");
            Console.ReadLine();
        }
    }
}
