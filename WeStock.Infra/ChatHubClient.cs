using Microsoft.AspNetCore.Authorization;
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
    //[Authorize]
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

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            Console.WriteLine("A client connected to MyChatHub: " + Context.ConnectionId);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
            Console.WriteLine("A client disconnected from MyChatHub: " + Context.ConnectionId);
        }

        public string GetConnectionId => Context.ConnectionId;
    }
}
