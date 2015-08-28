using Domain.Domain;

namespace DomainMapping
{
    public class DriverMap : EntityMap<Driver>
    {
        public DriverMap()
        {
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Age).Not.Nullable();
            References(x => x.Car);
        }
    }
}