using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WeStock.App.Dtos;
using WeStock.Domain;
using WeStock.Domain.Services;
using WeStock.Infra;

namespace WeStock.App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : BaseController
    {
        private IHubContext<ChatHubClient, IChatHubClient> _chatHubClient;
        private readonly MessageService _messageService;

        public ChatController(IHubContext<ChatHubClient, IChatHubClient> chatHubClient,
            MessageService messageService)
        {
            _chatHubClient = chatHubClient;
            _messageService = messageService;
        }

        [HttpPost("sendMessage")]
        public async Task SendMessage([FromBody] SendMessageDto dto)
        {
            await _chatHubClient.Clients.All.SendMessage(dto.Message);

            var userClaims = GetUserClaims();
            await _messageService.Add(userClaims.Id, dto.Message);
        }
    }
}
