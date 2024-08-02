using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.Services
{
    public class MessagingService : IMessagingService
    {
        private readonly IConnection _connection;
        public MessagingService(IConfiguration configuration)
        {
            string rabbitMQConnectionString = configuration.GetConnectionString("RabbitMQConnectionString")!;

            var factory = new ConnectionFactory()
            {
                Uri = new Uri(rabbitMQConnectionString)
            };
            _connection = factory.CreateConnection();
        }

        public void SendMessage(string queueName, string message)
        {
            using (var channel = _connection.CreateModel())
            {
                channel.QueueDeclare(queue: queueName,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: queueName,
                                     basicProperties: null,
                                     body: body);
            }
        }

        public void ReceiveMessage(string queueName)
        {
            using (var channel = _connection.CreateModel())
            {
                channel.QueueDeclare(queue: queueName,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine("Received message: {0}", message);
                };

                channel.BasicConsume(queue: queueName,
                                     autoAck: true,
                                     consumer: consumer);
            }
        }


    }
}
