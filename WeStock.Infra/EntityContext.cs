using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeStock.Domain.Entities;

namespace WeStock.Infra
{
    public class EntityContext : DbContext
    {
        public const string DB_NAME = "WeStockDb";
        public EntityContext(DbContextOptions<EntityContext> options) : base(options)
        {
            
        }
    }
}
