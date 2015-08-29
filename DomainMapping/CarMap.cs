using Domain.Domain;

namespace DomainMapping
{
    public class CarMap : EntityMap<Car>
    {
        public CarMap()
        {
            Map(x => x.Brand).Not.Nullable();
            Map(x => x.Name).Not.Nullable();
            Map(x => x.EngineVol).Not.Nullable();
            Map(x => x.TankVol).Not.Nullable();
            Map(x => x.BodyType).Not.Nullable();
            Map(x => x.CountryOfOrigin).Not.Nullable();
            HasMany(x => x.Tunings).Cascade.SaveUpdate().Inverse();
            HasMany(x => x.Drivers).Cascade.SaveUpdate().Inverse(); //.KeyColumn("DriverId");
            HasOne(x => x.Plate).PropertyRef(x => x.Id).Fetch.Join();
        }
    }
}