using Domain.Domain;

namespace InterfaceActions.Actions
{
    public interface INotifyUsersAction
    {
        void Notify(GermanyCar germanyCar);
    }

    //public class SmsNotification : INotifyUsersAction
    //{
    //    public void Notify(GermanyCar germanyCar)
    //    {
    //        Console.WriteLine("Send SMS: Congrats !!!");
    //    }

    //    //public void Notify(JapanCar japanCar)
    //    //{
    //    //    throw new NotImplementedException();
    //    //}
    //}

    //public class EmailNotification : INotifyUsersAction
    //{
    //    public void Notify(GermanyCar germanyCar)
    //    {
    //        Console.WriteLine("Send Email: Mega Congrats !!!");
    //    }

    //    //public void Notify(JapanCar japanCar)
    //    //{
    //    //    throw new NotImplementedException();
    //    //}
    //}
}