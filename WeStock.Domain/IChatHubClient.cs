﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeStock.Domain
{
    public interface IChatHubClient
    {
        Task SendMessage(string displayName, string message);
    }
}
