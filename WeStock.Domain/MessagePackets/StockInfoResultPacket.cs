using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeStock.Domain.MessagePackets
{
    public class StockInfoResultPacket : ConnectionContext
    {
        public string Result { get; set; }
    }
}
