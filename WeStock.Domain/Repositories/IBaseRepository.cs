namespace WeStock.Domain.Repositories
{
    public interface IBaseRepository
    {
        T GetById<T>(object id) where T : IEntity, new();
        ICollection<T> GetAll<T>() where T : IEntity, new();
    }
}