using System;
using Domain;
using Domain.Domain;
using Domain.Domain.Proxy;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public abstract class CarProxyFixture
    {
        [SetUp]
        public void CarProxySetUp()
        {
        //    _driver = new Driver("vasea", false, true);
         //   _realCar = new Car("Audi", 2500, 80, "Universal");
        }

        private DriverProxy _driver;
        private Car _realCar;

        [TestFixture]
        public class DriveFixture : CarProxyFixture
        {
            public void ActByCallingDrive()
            {
          //      var carProxy = new CarProxy(_driver, _realCar);
               // carProxy.Drive();
            }

            [TestFixture]
            public class WhenDriverIsDrunk : DriveFixture
            {
                [TestCase(true, false, Description = "Drunk driver is not allowed")]
                public void DriveShouldThrowApplicationExceptionWhenDriverHasNoLocence(bool alcoTestPassed,
                    bool driverLicence)
                {
             //       _driver = new Driver("vasea", alcoTestPassed, driverLicence);
                    var exception = Assert.Throws<ApplicationException>(() => ActByCallingDrive());

                    Assert.AreEqual("U cannot drive", exception.Message);
                }
            }

            [TestFixture]
            public class WhenDriverHasNoLicence : DriveFixture
            {
                [TestCase(false, true, Description = "U need a licence to drive")]
                public void DriveShouldThrowApplicationExceptionWhenDriverDrunk(bool alcoTestPassed,
                    bool driverLicence)
                {
               //     _driver = new Driver("vasea", alcoTestPassed, driverLicence);
                    var exception = Assert.Throws<ApplicationException>(() => ActByCallingDrive());

                    Assert.AreEqual("U R Drunk!!!", exception.Message);
                }
            }
        }
    }
}