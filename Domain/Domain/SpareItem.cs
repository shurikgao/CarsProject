using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain
{
    public class SpareItem : Entity
    {
        public SpareItem(string name, string madeIn, int quantity, int price)
        {
            Name = name;
            MadeIn = madeIn;
            Quantity = quantity;
            Price = price;
        }
        protected SpareItem()
        { }

        public virtual string Name { get; set; }
        public virtual string MadeIn { get; set; }
        public virtual int Quantity { get; set; }
        public virtual int Price { get; set; }

        private readonly IList<SpareParts> _sparePartses = new List<SpareParts>();

        public virtual IList<SpareParts> SparePartses
        {
            get { return _sparePartses; }
        }
    }
}
