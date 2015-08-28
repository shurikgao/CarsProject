using System;
using Domain.Domain;
using Domain.Logger;
using InterfaceActions.Actions;

namespace ActionImplementations
{
    public class EmailNotification : INotifyUsersAction
    {
        public void Notify(GermanyCar germanyCar)
        {
            Console.WriteLine("Send Email: MEGA Congrats. New GERMANY car created!");
            Logger.SaveMessageToLog("Email was sended");
            Console.WriteLine(new string('-', 30));
        }

        public void Notify(JapanCar japanCar)
        {
            Console.WriteLine("Send Email: MEGA Congrats. New JAPAN car created!");
            Console.WriteLine(new string('-', 30));
        }
    }
}