using Microsoft.AspNetCore.SignalR;
using RabbitMQ.Client;
using WeStock.Domain;
using WeStock.Domain.MessagePackets;
using WeStock.Infra;

namespace WeStock.App
{
    public class AppQueueEventHandlers : QueueBaseEventHandler, IDisposable
    {
        private static IHubContext<ChatHubClient, IChatHubClient> _chatHubClient;
        private static IModel _commandReceived;

        public AppQueueEventHandlers(IHubContext<ChatHubClient, IChatHubClient> chatHubClient)
        {
            _chatHubClient = chatHubClient;
        }

        public void Register(IConnection connection)
        {
            _commandReceived = connection.CreateModel();

            RegisterEventBy<StockInfoResultPacket>(async (message) =>
            {
                await _chatHubClient
                    .Clients
                    .User(message.ConnectionId)
                    .SendMessage(message.DisplayName, message.Result);

            }, _commandReceived, MessageBrokerConstants.COMMAND_RECEIVED_QUEUE);
        }

        public void Dispose()
        {
            _commandReceived?.Dispose();
        }
    }
}
