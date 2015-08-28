using System;

namespace Domain.Domain
{
    public class GermanyCar : Car
    {
        public GermanyCar(string brand,string name, int engineVol, int tankVol, string bodyType, string countryOfOrigin,
            int percentOfPrestige)
            : base(brand,name, engineVol, tankVol, bodyType, countryOfOrigin)
        {
            Prestige = percentOfPrestige;
        }

        [Obsolete]
        protected GermanyCar()
        {
        }

        public virtual int Prestige { get; protected set; }
    }
}