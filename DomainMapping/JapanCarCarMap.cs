using Domain.Domain;
using FluentNHibernate.Mapping;

namespace DomainMapping
{
    public class JapanCarCarMap : SubclassMap<JapanCar>
    {
        public JapanCarCarMap()
        {
            Map(x => x.Safety);
        }
    }
}