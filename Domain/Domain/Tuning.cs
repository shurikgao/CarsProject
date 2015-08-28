using Domain.Domain.Decorator;

namespace Domain.Domain
{
    public class Tuning
    {
        public static void TuneCar(Car car)
        {
            TuneAir(car);
            TuneAlarm(car);
            TunePark(car);
        }

        public static void TuneAir(Car car)
        {
            ITuning air = new AirConditioner(car);
            air.AddTuning();
        }

        public static void TuneAlarm(Car car)
        {
            ITuning alarm = new AlarmSystem(car);
            alarm.AddTuning();
        }

        public static void TunePark(Car car)
        {
            ITuning park = new Parctronic(car);
            park.AddTuning();
        }
    }
}