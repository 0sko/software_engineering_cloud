using RabbitMQ.Client;
using System.Text;

namespace CarRentalSystem.Services.MessageQueue
{
    public class Send
    {
        public static void NewMessage(string message = "Hello World!")
        {
            var factory = new ConnectionFactory { HostName = "rabbitmq", Port = 5672 };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: "hello",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: string.Empty,
                                 routingKey: "hello",
                                 basicProperties: null,
                                 body: body);

            Console.WriteLine($" [x] Sent {message}");
        }
    }
}
