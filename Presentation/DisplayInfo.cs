using System;
using ActionImplementations;
using Domain.Domain;
using Domain.Domain.Observer;
using Domain.Domain.Proxy;
using Factories.Factory;
using HibernatingRhinos.Profiler.Appender.NHibernate;
using Infrastructure.IoC;
using RepositoryInterfaces;

namespace Presentation
{
    internal class DisplayInfo
    {
        static DisplayInfo()
        {
            ServiceLocator.RegisterAll();

            NHibernateProfiler.Initialize();
        }

        private static GermanyCarFactory GermanyCarFactory;
        private static JapanCarFactory JapanCarFactory;
        // private static ChinaCarFactory ChinaCarFactory;

        private static ICarRepository CarRepository;
        private static IDriverRepository DriverRepository;

        private static RDSTransmitter RdsTrans;

        private static void Main(string[] args)
        {
            GermanyCarFactory = ServiceLocator.Get<GermanyCarFactory>();
            JapanCarFactory = ServiceLocator.Get<JapanCarFactory>();

            CarRepository = ServiceLocator.Get<ICarRepository>();
            DriverRepository = ServiceLocator.Get<IDriverRepository>();

            var bmw = GermanyCarFactory.CreateNewGermanyCar("BMW", 3500, 100, "Sedan", "Germany", 98);
            var germanyCarFactory = new GermanyCarFactory(new EmailNotification());

            var honda = JapanCarFactory.CreateNewJapanCar("Honda", 2000, 70, "Hatchbag", "Japan", 99);
            var japanCarFactory = new JapanCarFactory(new SmsNotification());

            var testDriver = new Driver("UasiaWay", 21, bmw);
            var testDriver1 = new Driver("JoriK", 22, bmw);
            var testDriver2 = new Driver("Fed`ka", 23, honda);
            var testDriver3 = new Driver("Gri6ka", 24, honda);
            var testDriver4 = new Driver("Bor`ka", 25, honda);


            bmw.Drivers.Add(testDriver);
            bmw.Drivers.Add(testDriver1);
            honda.Drivers.Add(testDriver2);
            honda.Drivers.Add(testDriver3);
            honda.Drivers.Add(testDriver4);
            CarRepository.Save(bmw);
            CarRepository.Save(honda);
            CarRepository.Save(bmw);

            DriverRepository.UpdDriverAge(205, 28);
            DriverRepository.DeleteDriver(204);

            Console.ReadKey();


            var audi = GermanyCarFactory.CreateNewGermanyCar("Audi", 2500, 80, "Universal", "Germany", 99);
            Console.WriteLine(new string('-', 30));

            //var JapanCarFactory = new JapanCarFactory(); 


            var ChinaCarFactory = new ChinaCarFactory();
            var byd = ChinaCarFactory.CreateNewChinaCar("BYD", 1300, 50, "ChinaStyle", "China", 101);


            #region Tuning

            Tuning.TuneAir(audi);
            Tuning.TuneAlarm(bmw);
            Tuning.TunePark(audi);
            Tuning.TuneCar(byd);
            Console.WriteLine(new string('=', 30));

            #endregion

            #region Germany car info

            Console.WriteLine(new string('-', 30));
            Console.WriteLine("GermanyCar : " + bmw.Name);
            Console.WriteLine(bmw.Name + " engine: " + bmw.EngineIsStarted);
            Console.WriteLine(bmw.Name + " lights: " + bmw.lights);
            Console.WriteLine(new string('-', 30));
            bmw.CheckAllSystem();
            bmw.StartEngine();

            #endregion

            #region Japan car info

            Console.WriteLine("JapanCar : " + honda.Name);
            Console.WriteLine(honda.Name + " engine: " + honda.EngineIsStarted);
            Console.WriteLine(honda.Name + " lights: " + honda.lights);
            Console.WriteLine(new string('-', 30));
            honda.CheckAllSystem();
            honda.StartEngine();
            honda.lights = false;

            #endregion

            #region China car info

            Console.WriteLine("ChinaCar : " + byd.Name);
            Console.WriteLine(byd.Name + " engine: " + byd.EngineIsStarted);
            Console.WriteLine(byd.Name + " lights: " + byd.lights);
            Console.WriteLine(new string('-', 30));
            byd.CheckAllSystem();
            byd.StartEngine();

            #endregion

            Console.WriteLine(new string('-', 30));

            audi.BattOk = false;
            byd.BattOk = false;
            Service srv = new Service();

            #region Service check

            srv.Check(bmw);
            srv.Check(honda);
            srv.Check(byd);
            Console.WriteLine();
            srv.Check(audi);
            srv.Repair(audi);
            srv.Check(audi);
            Console.WriteLine();

            #endregion

            Console.WriteLine("!!! Start Engine !!!");
            Console.WriteLine(new string('-', 30));

            Console.WriteLine("     " + bmw);
            Console.WriteLine(honda.ToString());
            Console.WriteLine(byd.ToString());
            Console.WriteLine(audi.ToString());

            Console.WriteLine(new string('-', 30));
            UseProxy(bmw, audi, honda);

            #region Observer RDS

            Console.WriteLine(new string('=', 30));
            RdsTrans = new RDSTransmitter();
            RdsTrans.Subscribe(audi.Receiver);
            RdsTrans.Subscribe(byd.Receiver);
            RdsTrans.LastNews = DateTime.Now + " Have an ice day ";
            RdsTrans.UnSubscribe(byd.Receiver);
            RdsTrans.LastNews = "Weather for this evening";
            Console.WriteLine(new string('=', 30));

            #endregion

            #region Template method

            bmw.StartAirConditioner();
            audi.StartAirConditioner();
            honda.StartAirConditioner();
            Console.WriteLine(audi.ToString());

            #endregion

            Console.ReadLine();
        }

      private static void UseProxy(Car car1, Car car2, Car car3)
        {
            var car = new CarProxy(new DriverProxy("Otto  ", true, false), car1);
            car.Drive();
            car = new CarProxy(new DriverProxy("Adolf  ", false, true), car2);
            car.Drive();
            car = new CarProxy(new DriverProxy("To-Iama_To_Kanava  ", true, true), car3);
            car.Drive();
            Console.WriteLine(new string('-', 30));
        }
    }
}