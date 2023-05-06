namespace WeStock.Domain.Repositories
{
    public interface IBaseRepository<TBase>
    {
        Task<TBase> GetById(long id);
        Task<List<TBase>> GetAll();

        Task<TBase> Add(TBase entity);
    }
}