using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WeStock.App.Dtos;
using WeStock.Domain;
using WeStock.Domain.Services;
using WeStock.Infra;

namespace WeStock.App.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ChatController : BaseController
    {
        private IHubContext<ChatHubClient, IChatHubClient> _chatHubClient;
        private readonly MessageService _messageService;
        private readonly IValidator<SendMessageDto> _sendMessageValidator;

        public ChatController(IHubContext<ChatHubClient, IChatHubClient> chatHubClient,
            MessageService messageService,
            IValidator<SendMessageDto> sendMessageValidator)
        {
            _chatHubClient = chatHubClient;
            _messageService = messageService;
            _sendMessageValidator = sendMessageValidator;
        }

        [HttpPost("sendMessage")]
        public async Task SendMessage([FromBody] SendMessageDto dto)
        {
            _sendMessageValidator.ValidateAndThrow(dto);
            await _chatHubClient.Clients.All.SendMessage(dto.Message);

            var userClaims = GetUserClaims();
            await _messageService.Add(userClaims.Id, dto.Message);
        }
    }
}
