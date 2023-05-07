using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeStock.Domain;
using WeStock.Domain.Services;

namespace WeStock.Infra
{
    public class ChatHubClient : Hub<IChatHubClient>
    {
        private readonly ChatBotService _chatBotService;

        public ChatHubClient(ChatBotService chatBotService)
        {
            _chatBotService = chatBotService;
        }

        public async Task SendMessage(string displayName, string message)
        {
            var result = await _chatBotService.GetCommandResult(message);
            await Clients.All.SendMessage(displayName, result);
        }

        public string GetConnectionId => Context.ConnectionId;
    }
}
