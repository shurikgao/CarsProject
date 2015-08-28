using System;

namespace Domain.Domain.Decorator
{
    public class Parctronic : TuningElements<Car>
    {
        public Parctronic(Car i)
            : base(i)
        {
        }

        public override void AddTuning()
        {
            Input.AddTuning();
            Console.WriteLine("Parktronic installed in " + Input.Name);
        }
    }
}