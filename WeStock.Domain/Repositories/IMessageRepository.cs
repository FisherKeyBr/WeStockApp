using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeStock.Domain.Entities;

namespace WeStock.Domain.Repositories
{
    public interface IMessageRepository : IBaseRepository<Message>
    {
    }
}
