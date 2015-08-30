using Domain.Domain;

namespace DomainMapping
{
    public class SparePartsMap : EntityMap<SpareParts>
    {
        public SparePartsMap()
        {
            References(x => x.Service);
            References(x => x.SpareItem);
        }
    }
}