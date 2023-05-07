using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeStock.Domain.Entities
{
    public class Message : BaseEntity
    {
        public long FromUserId { get; set; }
        public string Text { get; set; } = string.Empty;

        [NotMapped]
        public bool FromBot => FromUserId == decimal.Zero;
    }
}
