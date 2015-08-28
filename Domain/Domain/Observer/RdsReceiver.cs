using System;

namespace Domain.Domain.Observer
{
    internal class RdsReceiver : IRdsSubscriber
    {
        public RdsReceiver(string carName)
        {
            CarName = carName;
        }

        public string CarName { get; set; }

        public void Update(string newsText)
        {
            Console.WriteLine("RDS... Latest news  [{0, -4}]: {1}", CarName, newsText);
        }
    }
}