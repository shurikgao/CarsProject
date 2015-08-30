using System;
using System.Collections.Generic;
using System.Globalization;

namespace Domain.Domain
{
    public class Service : Entity
    {
        public Service(Car car)
        {
            Car = car;
        }
        protected Service()
        { }

        private readonly IList<SpareParts> _sparePartses = new List<SpareParts>();

        public virtual IList<SpareParts> SparePartses
        {
            get { return _sparePartses; }
        }

        public virtual Car Car { get; set; }
       
        public static void Check(Car car)
        {
            if (car.SystemOk)
            {
                Console.WriteLine("Car's systems are OK..."+ car.Brand + " " + car.Name);
                Console.WriteLine(new string('-', 30));
            }
            else
            {
                Console.WriteLine("Info=Service is needed - {0,-13} deffect = Battery{1,8}", car.Brand + " " + car.Name, car.BattOk);
                
                Console.WriteLine(new string('-', 30));
            }
        }

        public static void Repair(Car car)
        {
            if (car.BattOk == false)
            {
                car.BattOk = true;
            }
            car.CheckAllSystem();
            var bill = CashRegister.Payd;
            bill.AddBill(200);
            var carService = new Service(car);
            car.Services.Add(carService);
            
            Console.WriteLine(" {0,26} Repaired.  Please pay:{1,14}", car.Brand + " " + car.Name,
                bill.BillSize.ToString("C", CultureInfo.CurrentCulture));
            //bill.AddBill(200); 
            // Console.WriteLine("please pay:" + bill.BillSize.ToString("C",CultureInfo.CurrentCulture));
            bill.ResetCashRegister();
        }

        public sealed class CashRegister // class with Singleton pattern
        {
            private static readonly CashRegister PrintBill = new CashRegister(); // Singleton

            static CashRegister()
            {
            }

            private CashRegister()
            {
                BillSize = 0;
            }

            public int BillSize { get; private set; }

            public static CashRegister Payd
            {
                get { return PrintBill; }
            }

            public void AddBill(int price)
            {
                BillSize += price;
            }

            public void ResetCashRegister()
            {
                BillSize = 0;
            }
        }
    }
}