using System;

namespace Domain.Domain.Proxy
{
    public class CarProxy : IDrive
    {
        private readonly DriverProxy _driver;
        private readonly Car _realCar;

        public CarProxy(DriverProxy driver, Car car)
        {
            _driver = driver;
            _realCar = car;
        }

        public void Drive()
        {
            if (_driver.DriverLicence != true)
                Console.WriteLine("{0,-20} Sorry!!! U have no rights to drive", DriverProxy.Name);
                    //  FOR UnitTest Comment 
            //   throw new ApplicationException("U cannot drive");   FOR UnitTest Uncomment 
            if (_driver.AlcoTestPassed != true)
                Console.WriteLine("{0,-20} Sorry!!! U R Drunk. Do not touch anything", DriverProxy.Name);
                    //  FOR UnitTest Comment 
            //throw new ApplicationException("U R Drunk!!!");  FOR UnitTest Uncomment 
            _realCar.Drive();
        }
    }
}