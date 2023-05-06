using Microsoft.EntityFrameworkCore;
using WeStock.Domain;
using WeStock.Domain.Entities;
using WeStock.Domain.Repositories;

namespace WeStock.Infra.Repositories
{
    public abstract class BaseRepository<TBase> : IBaseRepository<TBase> where TBase: BaseEntity
    {
        private EntityContext _entityContext;

        public BaseRepository(EntityContext entityContext)
        {
            _entityContext = entityContext;
        }
        
        public async Task<TBase> Add(TBase entity)
        {
            var dbSet = _entityContext.Set<TBase>();
            var result = await dbSet.AddAsync(entity);
            await _entityContext.SaveChangesAsync();
            return result.Entity;
        } 

        public Task<List<TBase>> GetAll()
        {
            var dbSet = _entityContext.Set<TBase>();
            return dbSet.ToListAsync();
        }

        public Task<TBase> GetById(long id)
        {
            var dbSet = _entityContext.Set<TBase>();
            return dbSet.FirstOrDefaultAsync(x => x.Id == id)!;
        }

        protected async Task<TBase> Execute(Func<EntityContext, Task<TBase>> func)
        {
            var result = func.Invoke(_entityContext);
            await _entityContext.SaveChangesAsync();
            return await result;
        }

        protected DbSet<T> GetTable<T>() where T: BaseEntity
        {
            var dbSet = _entityContext.Set<T>();
            return dbSet;
        }

        //the internal context keeps each type as a key saved in a dictionary, so no problem with new instances.
        protected DbSet<TBase> GetTable()
        {
            var dbSet = _entityContext.Set<TBase>();
            return dbSet;
        }

        
    }
}