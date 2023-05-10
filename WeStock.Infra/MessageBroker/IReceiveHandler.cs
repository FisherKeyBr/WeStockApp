using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeStock.Infra.MessageBroker
{
    public interface IReceiveHandler
    {
        void Listen(string queue);
    }
}
