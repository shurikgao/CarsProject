using System;

namespace Domain.Domain.Decorator
{
    public class AlarmSystem : TuningElements<Car>
    {
        public AlarmSystem(Car i)
            : base(i)
        {
        }

        public override void AddTuning()
        {
            Input.AddTuning();
            Console.WriteLine("AlarmSystem installed in " + Input.Name);
        }
    }
}