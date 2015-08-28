using System;

namespace Domain.Domain
{
    public class ChinaCar : Car
    {
        public ChinaCar(string name, int engineVol, int tankVol, string bodyType, string countryOfOrigin,
            int percentOfOriginalPieces)
            : base(name, engineVol, tankVol, bodyType, countryOfOrigin)
        {
            Originality = percentOfOriginalPieces;
        }

        [Obsolete]
        protected ChinaCar()
        {
        }

        public virtual int Originality { get; protected set; }

        public override void CheckAllSystem()
        {
            //base.checkAllSystem();
            SystemOk = true;
        }
    }
}