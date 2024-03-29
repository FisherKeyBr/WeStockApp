﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeStock.Domain.Entities;
using WeStock.Domain.Repositories;

namespace WeStock.Domain.Services
{
    public class MessageService
    {
        private readonly IMessageRepository _messageRepository;
        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task Add(long userId, string message)
        {
            var messageObject = new Message
            {
                Text = message,
                FromUserId = userId
            };

            await _messageRepository.Add(messageObject);
        }
    }
}
