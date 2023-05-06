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

        public async Task SendMessage(string message)
        {
            Console.WriteLine(message);
            var result = await _chatBotService.GetClientMessage(message);
            await Clients.All.SendMessage(result);
        }
    }
}
