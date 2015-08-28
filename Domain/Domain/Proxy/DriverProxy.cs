namespace Domain.Domain.Proxy
{
    public class DriverProxy
    {
        public DriverProxy(string name, bool alcoTestPassed, bool driverLicence)
        {
            AlcoTestPassed = alcoTestPassed;
            DriverLicence = driverLicence;
            Name = name;
        }

        public bool AlcoTestPassed { get; private set; }
        public bool DriverLicence { get; private set; }
        public static string Name { get; private set; }
    }
}