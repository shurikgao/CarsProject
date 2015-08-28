using Domain.Domain;

namespace DomainMapping
{
    public class RegistrationPlateMap : EntityMap<RegistrationPlate>
    {
        public RegistrationPlateMap()
        {
            Map(x => x.Plate);
            References(x => x.Car).Cascade.All().Unique();
        }
    }
}
