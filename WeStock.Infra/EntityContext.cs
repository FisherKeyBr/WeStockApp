using Microsoft.EntityFrameworkCore;
using WeStock.Domain.Entities;

namespace WeStock.Infra
{
    public class EntityContext : DbContext
    {
        public const string DB_NAME = "WeStockDb";
        public EntityContext(DbContextOptions<EntityContext> options) : base(options)
        {   
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
