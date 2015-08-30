using Domain.Domain;

namespace DomainMapping
{
    public class ServiceMap : EntityMap<Service>
    {
        public ServiceMap()
        {
            References(x => x.Car);
        }
    }
}