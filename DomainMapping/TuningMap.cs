using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainMapping;

namespace Domain.Domain
{
    public class TuningMap : EntityMap<Tuning>
    {
        public TuningMap()
        {
            Map(x => x.AirConditioner);
            Map(x => x.AlarmSystem);
            Map(x => x.Parctronic);
            References(x => x.Car);
        }
    }
}
