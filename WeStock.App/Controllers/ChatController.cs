using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WeStock.App.Dtos;
using WeStock.Domain;
using WeStock.Domain.Enums;
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
        private readonly IValidator<SendMessageDto> _sendMessageValidator;
        private readonly MessageService _messageService;
        private readonly ChatBotService _chatBotService;

        public ChatController(
            IHubContext<ChatHubClient, IChatHubClient> chatHubClient,
            IValidator<SendMessageDto> sendMessageValidator,
            MessageService messageService)
        {
            _chatHubClient = chatHubClient;
            _sendMessageValidator = sendMessageValidator;
            _messageService = messageService;
        }

        [HttpPost("sendMessage")]
        public async Task SendMessage([FromBody] SendMessageDto dto)
        {
            var userClaims = GetUserClaims();
            _sendMessageValidator.ValidateAndThrow(dto);

            var messageType = _chatBotService.GetMessageType(dto.Message);

            //keeping it simple without saving bot response history
            if (messageType == MessageTypeEnum.COMMAND)
            {
                var result = await _chatBotService.GetCommandResult(dto.Message);
                await _chatHubClient.Clients
                    .User(dto.ConnectionId)
                    .SendMessage(ChatConstants.BOT_NAME, result);
            }
            else
            {
                await _chatHubClient.Clients.All.SendMessage(userClaims.DisplayName, dto.Message);
                //only keeping user message history for now
                await _messageService.Add(userClaims.Id, dto.Message);
            }
        }
    }
}
