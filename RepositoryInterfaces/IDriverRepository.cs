using Domain;

namespace RepositoryInterfaces
{
    public interface IDriverRepository //: IRepository
    {
        void AddDriver<TEntity>(TEntity entity) where TEntity : Entity;
        void UpdDriverAge(long id, int newAge);
        void DeleteDriver(long id);
    }
}