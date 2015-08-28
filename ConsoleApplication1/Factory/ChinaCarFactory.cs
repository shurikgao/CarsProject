using Domain.Domain;

namespace Factories.Factory
{
    public class ChinaCarFactory
    {
        public static int percentOfOriginalPieces { get; set; }

        public static ChinaCar CreateNewChinaCar(string brand,string name, int engineVol, int tankVol, string bodyType,
            string countryOfOrigin, int percentOfOriginalPieces)
            //Action<IProductOptions> optionalParams)
        {
            var chinaCar = new ChinaCar(brand, name, engineVol, tankVol, bodyType, countryOfOrigin, percentOfOriginalPieces);
            return chinaCar;
        }
    }
}