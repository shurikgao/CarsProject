using Domain.Domain;

namespace DomainMapping
{
    public class CarMap : EntityMap<Car>
    {
        public CarMap()
        {
            //Id(x => x.Id);
            Map(x => x.Name).Not.Nullable();
            Map(x => x.EngineVol).Not.Nullable();
            Map(x => x.TankVol).Not.Nullable();
            Map(x => x.BodyType).Not.Nullable();
            Map(x => x.CountryOfOrigin).Not.Nullable();
            HasMany(x => x.Drivers).Cascade.SaveUpdate().Inverse(); //.KeyColumn("DriverId");
        }
    }
}