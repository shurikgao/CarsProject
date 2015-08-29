using System;
using Domain;
using Domain.Domain;
using NHibernate;
using RepositoryInterfaces;

namespace Repository
{
    public class DriverRepository : IDriverRepository //Repository
    {
        private readonly ISession _session = SessionGenerator.Instance.GetSession();

        public void AddDriver<TEntity>(TEntity entity) where TEntity : Entity
        {
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    Console.WriteLine("Wait... driver is on the way in DB...");
                    _session.Save(entity);
                    Console.WriteLine("Congrats");
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    tran.Rollback();
                }
            }
        }

        public void UpdDriverAge(long id, int newAge)
        {
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    var driver = _session.Get<Driver>(id); 
                    driver.Age = newAge;
                    Console.WriteLine("Driver info is updating...");
                    _session.Update(driver);
                    Console.WriteLine("Congrats!");
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    tran.Rollback();
                }
            }
        }

        public void DeleteDriver(long id)
        {
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    var driver = _session.Get<Driver>(id);
                    Console.WriteLine("deleting driver from DB");
                    _session.Delete(driver);
                    Console.WriteLine("Congrats!");
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    tran.Rollback();
                }
            }
        }

        public void DeleteDriver<TEntity>(TEntity entity) where TEntity : Entity
        {
        }
    }
}