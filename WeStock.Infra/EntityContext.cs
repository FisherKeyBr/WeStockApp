using Microsoft.EntityFrameworkCore;

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
