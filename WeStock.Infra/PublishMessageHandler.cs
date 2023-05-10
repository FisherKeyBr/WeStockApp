using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using WeStock.Domain;

namespace WeStock.Infra
{
    public class PublishMessageHandler : IPublishMessageHandler
    {
        private IConnection _connection;
        private IModel _channel;

        public PublishMessageHandler(IConnection connection)
        {
            _connection = connection;
            _channel = connection.CreateModel();
            _channel.QueueDeclare(queue: MessageBrokerConstants.DEFAULT_QUEUE,
                                durable: false,
                                exclusive: false,
                                autoDelete: false,
                                arguments: null);
        }

        public void Dispose()
        {
            _connection?.Dispose();
            _channel?.Dispose();
        }

        public void Publish<T>(T message, string queue = MessageBrokerConstants.DEFAULT_QUEUE) where T: class, new()
        {
            var body = JsonConvert.SerializeObject(message);

            _channel.BasicPublish(exchange: string.Empty,
                                 routingKey: queue,
                                 basicProperties: null,
                                 body: Encoding.UTF8.GetBytes(body));
        }
    }
}