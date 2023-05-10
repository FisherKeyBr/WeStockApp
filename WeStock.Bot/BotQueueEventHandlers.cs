using RabbitMQ.Client;
using WeStock.Domain;
using WeStock.Domain.MessagePackets;
using WeStock.Domain.Services;
using WeStock.Infra;

namespace WeStock.Bot
{
    public class BotQueueEventHandlers : QueueBaseEventHandler, IDisposable
    {
        private static IPublishMessageHandler _publishMessageHandler;
        
        private static IModel _commandRequested;

        private static ChatBotService _chatBotService;

        public BotQueueEventHandlers(
            IPublishMessageHandler publishMessageHandler,
            ChatBotService chatBotService)
        {
            _publishMessageHandler = publishMessageHandler;
            _chatBotService = chatBotService;
        }

        public void Register(IConnection connection)
        {
            _commandRequested = connection.CreateModel();

            RegisterEventBy<CommandPacket>(async (message) =>
            {
                //call api and wait for result
                var result = await _chatBotService.GetCommandResult(message.Text);

                Console.WriteLine(result);

                //send back result so SignalR can send to client.
                _publishMessageHandler.Publish(new StockInfoResultPacket
                {
                    ConnectionId = message.ConnectionId,
                    Result = result
                }, MessageBrokerConstants.COMMAND_RECEIVED_QUEUE);

            }, _commandRequested, MessageBrokerConstants.COMMAND_REQUESTED_QUEUE);
        }

        public void Dispose()
        {
            _commandRequested?.Dispose();
        }
    }
}
