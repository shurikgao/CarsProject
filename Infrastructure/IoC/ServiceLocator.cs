using ActionImplementations;
using InterfaceActions.Actions;
using Ninject;
using Repository;
using RepositoryInterfaces;

namespace Infrastructure.IoC
{
    internal static class ServiceLocator
    {
        private static readonly IKernel Kernel = new StandardKernel();

        public static void RegisterAll()
        {
            Kernel.Bind<INotifyUsersAction>().To<EmailNotification>();
            Kernel.Bind<INotifyUsersAction2>().To<SmsNotification>();
            Kernel.Bind<ICarRepository>().To<CarRepository>();
            Kernel.Bind<IDriverRepository>().To<DriverRepository>();
            Kernel.Bind<ITuningRepository>().To<TuningRepository>();
        }

        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }
    }
}