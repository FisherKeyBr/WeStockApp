using WeStock.Domain.Entities;
using WeStock.Domain.Enums;
using WeStock.Domain.Extensions;
using WeStock.Domain.ExternalApis;

namespace WeStock.Domain.Services
{
    public class ChatBotService
    {
        private IStockMarketApi _stockMarketApi;

        public ChatBotService(IStockMarketApi stockMarketApi)
        {
            _stockMarketApi = stockMarketApi;
        }

        public async Task<string> GetClientMessage(string message)
        {
            var result = await GetMessage(message);
            return result;
        }

        private async Task<string> GetMessage(string message)
        {
            var messageType = GetMessageType(message);

            switch (messageType)
            {
                case MessageTypeEnum.NORMAL:
                    return await Task.FromResult(message);
                case MessageTypeEnum.COMMAND:
                    return await ExecuteCommand(message);
                default:
                    throw new IndexOutOfRangeException("Message type not supported!");
            }
        }

        private async Task<string> ExecuteCommand(string message)
        {
            var commandEnum = CommandTypeHelper.GetBy(message);

            switch (commandEnum)
            {
                case CommandTypeEnum.FETCH_STOCK_QUOTE:
                    var symbol = commandEnum.ExtractSymbol(message);
                    var lastQuoteSymbol = await _stockMarketApi.GetLastQuoteBy(symbol);
                    return lastQuoteSymbol?.GetFormattedMessage()!;
                default:
                    throw new IndexOutOfRangeException($"Command not supported!");
            }   
        }

        private MessageTypeEnum GetMessageType(string message)
        {
            if (CommandTypeHelper.IsCommand(message))
            {
                return MessageTypeEnum.COMMAND;
            }

            return MessageTypeEnum.NORMAL;
        }
    }
}
