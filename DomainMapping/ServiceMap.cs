using Domain.Domain;

namespace DomainMapping
{
    public class ServiceMap : EntityMap<Service>
    {
        public ServiceMap()
        {
            References(x => x.Car);
            HasMany(x => x.SparePartses).Cascade.SaveUpdate().Inverse();
        }
    }
}