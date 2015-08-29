using System;
using Domain.Domain;
using NHibernate;
using RepositoryInterfaces;
using Domain;

namespace Repository
{
    public class TuningRepository : ITuningRepository
    {
        //private readonly ISession _session = SessionGenerator.Instance.GetSession();

        //public void TuneCar(long id, char newInstalledTuning)
        //{
        //    using (var tran = _session.BeginTransaction())
        //    {
        //        try
        //        {
        //            var tuning = _session.Get<Tuning>(id);
        //            //tuning.AirConditioner = newInstalledTuning;
        //            //tuning.AlarmSystem = newInstalledTuning;
        //            tuning.Parctronic = newInstalledTuning;
        //            Console.WriteLine("Tuning is in process...");
        //            _session.Update(tuning);
        //            Console.WriteLine("Congrats!");
        //            tran.Commit();
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //            tran.Rollback();
        //        }
        //    }
        //}

    }
}