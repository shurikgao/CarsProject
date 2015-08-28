namespace Domain.Domain.Decorator
{
    public abstract class TuningElements<TITuning> : ITuning where TITuning : ITuning
    {
        protected TITuning Input;

        protected TuningElements(TITuning i)
        {
            Input = i;
        }

        public abstract void AddTuning();
    }
}