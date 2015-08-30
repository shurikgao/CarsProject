using System.Collections.Generic;
using Domain.Domain;

namespace DomainMapping
{
    public class SpareItemMap : EntityMap<SpareItem>
    {
        
        public SpareItemMap()
        {
            Map(x => x.Name).Not.Nullable();
            Map(x => x.MadeIn).Not.Nullable();
            Map(x => x.Quantity);
            Map(x => x.Price).Not.Nullable();
            HasMany(x => x.SparePartses).Cascade.SaveUpdate().Inverse();
        }


       
    }
}