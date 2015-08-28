
using Domain;
using Domain.Domain;

namespace RepositoryInterfaces
{
    public interface IRepository
    {
        #region Public members

        void Save<TEntity>(TEntity entity) where TEntity : Entity;

        #endregion
    }
}