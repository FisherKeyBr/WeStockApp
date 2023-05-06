namespace WeStock.Domain.Repositories
{
    public interface IBaseRepository<TBase>
    {
        Task<TBase> GetById(object id);
        Task<List<TBase>> GetAll();
    }
}