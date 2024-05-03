using Financial.Queue.Repositories.Interfaces;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Financial.Queue.Repositories.Repository
{
    public class RabbitMessageRepository : IRabbitMessageRepository
    {
        private readonly IModel _channel;

        public RabbitMessageRepository(IConnection connection)
        {
            _channel = connection.CreateModel();
        }
        public async Task SendMessageAsync<T>(T message, string queueName)
        {
            await Task.Run(() =>
            {
                _channel.QueueDeclare(queue: queueName,
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var json = JsonSerializer.Serialize(message);
                var body = Encoding.UTF8.GetBytes(json);

                _channel.BasicPublish(exchange: "",
                                     routingKey: queueName,
                                     basicProperties: null,
                                     body: body);
            });
        }
    }
}
