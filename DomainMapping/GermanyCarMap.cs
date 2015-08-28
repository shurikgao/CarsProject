using Domain.Domain;
using FluentNHibernate.Mapping;

namespace DomainMapping
{
    public class GermanyCarMap : SubclassMap<GermanyCar>
    {
        public GermanyCarMap()
        {
            Map(x => x.Prestige);
        }
    }
}