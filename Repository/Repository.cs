using Domain;
using NHibernate;
using RepositoryInterfaces;

namespace Repository
{
    public abstract class Repository : IRepository
    {
        private readonly ISession _session = SessionGenerator.Instance.GetSession();

        public void Save<TEntity>(TEntity entity) where TEntity : Entity
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(entity);
                tran.Commit();
            }
        }
    }
}