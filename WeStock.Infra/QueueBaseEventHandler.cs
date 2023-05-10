using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeStock.Domain.Extensions;

namespace WeStock.Infra
{
    public abstract class QueueBaseEventHandler
    {
        protected void RegisterEventBy<T>(Action<T> action, IModel channel, string queue) where T : class, new()
        {
            channel.QueueDeclare(queue: queue,
                               durable: false,
                               exclusive: false,
                               autoDelete: false,
                               arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var obj = body.ToObject<T>();

                action.Invoke(obj);
            };
            channel.BasicConsume(queue: queue,
                                 autoAck: true,
                                 consumer: consumer);
        }
    }
}
