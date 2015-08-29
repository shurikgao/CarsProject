namespace RepositoryInterfaces
{
    public interface ITuningRepository : IRepository
    {
        //void AddTuning<TEntity>(TEntity entity) where TEntity : Entity; 
        void TuneCar(long id, bool installedTuning);
    }
}