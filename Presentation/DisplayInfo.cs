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
        private static GermanyCarFactory GermanyCarFactory;
        private static JapanCarFactory JapanCarFactory;
        // private static ChinaCarFactory ChinaCarFactory;

        private static ITuningRepository TuningRepository;
        private static ICarRepository CarRepository;
        private static IDriverRepository DriverRepository;
        private static IServiceRepository ServiceRepository;
        private static RDSTransmitter RdsTrans;

        static DisplayInfo()
        {
            ServiceLocator.RegisterAll();

            NHibernateProfiler.Initialize();
        }

        private static void Main(string[] args)
        {
            GermanyCarFactory = ServiceLocator.Get<GermanyCarFactory>();
            JapanCarFactory = ServiceLocator.Get<JapanCarFactory>();

            CarRepository = ServiceLocator.Get<ICarRepository>();
            DriverRepository = ServiceLocator.Get<IDriverRepository>();

            var bmw = GermanyCarFactory.CreateNewGermanyCar("BMW", "X5", 3500, 100, "Sedan", "Germany", 98);
            var germanyCarFactory = new GermanyCarFactory(new EmailNotification());

            var honda = JapanCarFactory.CreateNewJapanCar("Honda", "Civic", 2000, 70, "Hatchbag", "Japan", 99);
            var japanCarFactory = new JapanCarFactory(new SmsNotification());

            var testDriver = new Driver("UasiaWay", 17, bmw);
            var testDriver1 = new Driver("JoriK", 22, bmw);
            var testDriver2 = new Driver("Fed`ka", 23, honda);
            var testDriver3 = new Driver("Gri6ka", 24, honda);
            var testDriver4 = new Driver("Bor`ka", 25, honda);
            //var testPlate1 = new RegistrationPlate("DE-345-JO", bmw);

            bmw.Drivers.Add(testDriver);
            bmw.Drivers.Add(testDriver1);
            honda.Drivers.Add(testDriver2);
            honda.Drivers.Add(testDriver3);
            honda.Drivers.Add(testDriver4);
            CarRepository.Save(bmw);
            CarRepository.Save(honda);


            DriverRepository.UpdDriverAge(205, 28);
            DriverRepository.DeleteDriver(204);

            Console.ReadKey();


            var audi = GermanyCarFactory.CreateNewGermanyCar("Audi", "A8", 2500, 80, "Universal", "Germany", 99);
            Console.WriteLine(new string('-', 30));
            CarRepository.Save(audi);
            //var JapanCarFactory = new JapanCarFactory(); 


            var ChinaCarFactory = new ChinaCarFactory();
            var byd = ChinaCarFactory.CreateNewChinaCar("BYD", "*BYD*", 1300, 50, "ChinaStyle", "China", 101);
            CarRepository.Save(byd);

            #region Tuning

            Tuning.TuneAir(audi);
            Tuning.TuneAlarm(bmw);
            Tuning.TuneCar(byd);

            Console.WriteLine(new string('=', 30));

            var tuneAudi = new Tuning('Y', 'N', 'N', audi);
            audi.Tunings.Add(tuneAudi);
            CarRepository.Save(audi);
            var tuneBmw = new Tuning('N', 'Y', 'N', bmw);
            bmw.Tunings.Add(tuneBmw);
            CarRepository.Save(bmw);
            var tuneByd = new Tuning('Y', 'Y', 'Y', byd);
            byd.Tunings.Add(tuneByd);
            CarRepository.Save(byd);
       //     TuningRepository.TuneCar(404,'Y');

            #endregion

            #region Germany car info

            Console.WriteLine(new string('-', 30));
            Console.WriteLine("GermanyCar : " + bmw.Brand + " " + bmw.Name);
            Console.WriteLine(bmw.Name + " engine: " + bmw.EngineIsStarted);
            Console.WriteLine(bmw.Name + " lights: " + bmw.lights);
            Console.WriteLine(new string('-', 30));
            bmw.CheckAllSystem();
            bmw.StartEngine();

            #endregion

            #region Japan car info

            Console.WriteLine("JapanCar : " + honda.Brand + " " + honda.Name);
            Console.WriteLine(honda.Name + " engine: " + honda.EngineIsStarted);
            Console.WriteLine(honda.Name + " lights: " + honda.lights);
            Console.WriteLine(new string('-', 30));
            honda.CheckAllSystem();
            honda.StartEngine();
            honda.lights = false;

            #endregion

            #region China car info

            Console.WriteLine("ChinaCar : " + byd.Brand + " " + byd.Name);
            Console.WriteLine(byd.Name + " engine: " + byd.EngineIsStarted);
            Console.WriteLine(byd.Name + " lights: " + byd.lights);
            Console.WriteLine(new string('-', 30));
            byd.CheckAllSystem();
            byd.StartEngine();

            #endregion

            Console.WriteLine(new string('-', 30));

            audi.BattOk = false;
            byd.BattOk = false;
         //   var srv = new Service();

            #region Service check

            Service.Check(bmw);
            Service.Check(honda);
            Service.Check(byd);
            Console.WriteLine();
            Service.Check(audi);
            Service.Repair(audi);
            CarRepository.Save(audi);
            Service.Check(audi);
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