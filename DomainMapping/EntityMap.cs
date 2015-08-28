using Domain;
using Domain.Domain;
using FluentNHibernate.Mapping;

namespace DomainMapping
{
    public abstract class EntityMap<TEntity> : ClassMap<TEntity> where TEntity : Entity
    {
        protected EntityMap()
        {
            Id(x => x.Id).GeneratedBy.HiLo("100");

            DynamicUpdate();
        }
    }
}