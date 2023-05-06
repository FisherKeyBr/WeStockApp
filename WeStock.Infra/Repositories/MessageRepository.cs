using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeStock.Domain.Entities;
using WeStock.Domain.Repositories;

namespace WeStock.Infra.Repositories
{
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        public MessageRepository(EntityContext entityContext) : base(entityContext)
        {
        }
    }
}
