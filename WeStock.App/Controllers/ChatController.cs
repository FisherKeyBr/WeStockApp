using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WeStock.App.Dtos;
using WeStock.Domain;
using WeStock.Domain.Enums;
using WeStock.Domain.MessagePackets;
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
        private readonly IPublishMessageHandler _publishMessageHandler;
        private readonly ChatBotService _chatBotService;

        public ChatController(
            IHubContext<ChatHubClient, IChatHubClient> chatHubClient,
            IValidator<SendMessageDto> sendMessageValidator,
            IPublishMessageHandler publishMessageHandler,
            ChatBotService chatBotService,
            MessageService messageService)
        {
            _chatHubClient = chatHubClient;
            _sendMessageValidator = sendMessageValidator;
            _messageService = messageService;
            _chatBotService = chatBotService;
            _publishMessageHandler = publishMessageHandler;
        }

        [HttpPost("sendMessage")]
        public async Task<ActionResult> SendMessage([FromBody] SendMessageDto dto)
        {
            var userClaims = GetUserClaims();
            _sendMessageValidator.ValidateAndThrow(dto);

            var messageType = _chatBotService.GetMessageType(dto.Message);

            if (messageType == MessageTypeEnum.COMMAND)
            {
                _publishMessageHandler.Publish(new CommandPacket
                {
                    UserId = userClaims.Id,
                    DisplayName = userClaims.DisplayName,
                    ConnectionId = dto.ConnectionId,
                    Text = dto.Message,
                }, MessageBrokerConstants.COMMAND_REQUESTED_QUEUE);

                return Accepted();
            }

            await _chatHubClient.Clients.All.SendMessage(userClaims.DisplayName, dto.Message);
            //only keeping user message history for now
            await _messageService.Add(userClaims.Id, dto.Message);

            return Ok();
        }
    }
}
