using Domain.Domain;
using FluentNHibernate.Mapping;

namespace DomainMapping
{
    public class ChinaCarMap : SubclassMap<ChinaCar>
    {
        public ChinaCarMap()
        {
            Map(x => x.Originality);
        }
    }
}