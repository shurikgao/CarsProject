using Domain.Domain;
using InterfaceActions.Actions;

namespace Factories.Factory
{
    public class JapanCarFactory
    {
        private readonly INotifyUsersAction2 _notifyUsersAction;

        public JapanCarFactory(INotifyUsersAction2 notifyUsersAction)
        {
            _notifyUsersAction = notifyUsersAction;
        }

        public int percentOfSafety { get; set; }

        public JapanCar CreateNewJapanCar(string brand,string name, int engineVol, int tankVol, string bodyType,
            string countryOfOrigin, int percentOfSafety)
            //Action<IProductOptions> optionalParams)
        {
            var japanCar = new JapanCar(brand,name, engineVol, tankVol, bodyType, countryOfOrigin, percentOfSafety);
            OnJapanCarCreation(japanCar);
            return japanCar;
        }

        public void OnJapanCarCreation(JapanCar japanCar)
        {
            _notifyUsersAction.Notify(japanCar);
        }
    }
}