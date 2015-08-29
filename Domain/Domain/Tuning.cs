using Domain.Domain.Decorator;

namespace Domain.Domain
{
    public class Tuning : Entity
    {
        public Tuning(char airConditioneer, char alarmSystem, char parcTronic, Car car)
        {
            AirConditioner = airConditioneer;
            AlarmSystem = alarmSystem;
            Parctronic = parcTronic;
            Car = car;
        }
        protected Tuning()
        { }

        public virtual char AirConditioner { get; set; }
        public virtual char AlarmSystem { get; set; }
        public virtual char Parctronic { get; set; }
        public virtual Car Car { get; set; }

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