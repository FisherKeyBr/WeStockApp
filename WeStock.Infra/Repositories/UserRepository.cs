using Microsoft.EntityFrameworkCore;
using WeStock.Domain.Entities;
using WeStock.Domain.Repositories;

namespace WeStock.Infra.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(EntityContext entityContext) : base(entityContext)
        {
        }

        public async Task<User> GetBy(string userName, string password)
        {
            return await Execute(async dbCtx =>
            {
                var table = GetTable();

                return await table.FirstOrDefaultAsync(x => x.UserName == userName && x.Password == password);
            });
        }

        public async Task<User> GetByUsername(string userName)
        {
            return await Execute(async dbCtx =>
            {
                var table = GetTable();
                return await table.FirstOrDefaultAsync(x => x.UserName == userName);
            });
        }
    }
}
