using System;

namespace Domain.Domain.Decorator
{
    public class AirConditioner : TuningElements<Car>
    {
        public AirConditioner(Car i) : base(i)
        {
        }

        public override void AddTuning()
        {
            Input.AddTuning();
            Console.WriteLine("AirConditioner installed in " + Input.Name);
        }
    }
}