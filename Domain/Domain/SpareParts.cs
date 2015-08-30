using System.Collections.Generic;
using System.ComponentModel;

namespace Domain.Domain
{
    public class SpareParts : Entity
    {
        public SpareParts(Service service, SpareItem spareItem)
        {
            Service = service;
            SpareItem = spareItem;
        }

        protected SpareParts()
        { }

        public virtual Service Service { get; set; }
        public virtual SpareItem SpareItem { get; set; }

       
    } 
}