using Domain.Domain;
using InterfaceActions.Actions;

namespace Factories.Factory
{
    public class GermanyCarFactory
    {
        private readonly INotifyUsersAction _notifyUsersAction;

        public GermanyCarFactory(INotifyUsersAction notifyUsersAction)
        {
            _notifyUsersAction = notifyUsersAction;
        }

        public int percentOfPrestige { get; set; }

        public GermanyCar CreateNewGermanyCar(string name, int engineVol, int tankVol, string bodyType,
            string countryOfOrigin, int percentOfPrestige)
            //Action<IProductOptions> optionalParams)
        {
            var germanyCar = new GermanyCar(name, engineVol, tankVol, bodyType, countryOfOrigin, percentOfPrestige);
            OnGermanyCarCreation(germanyCar);
            return germanyCar;
        }

        public void OnGermanyCarCreation(GermanyCar germanyCar)
        {
            _notifyUsersAction.Notify(germanyCar);
        }
    }
}