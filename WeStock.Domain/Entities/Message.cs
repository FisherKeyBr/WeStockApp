using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeStock.Domain.Entities
{
    public class Message : BaseEntity
    {
        public long UserId { get; set; }
        public string Text { get; set; }
    }
}
