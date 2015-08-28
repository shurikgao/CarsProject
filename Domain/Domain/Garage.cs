using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain
{
    class Garage
    {
        private static int _totalCars;

        public int Count()
        {
           return _totalCars++;
        }
    }
}
