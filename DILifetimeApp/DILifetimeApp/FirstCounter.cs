namespace DILifetimeApp
{
    public class FirstCounter : IFirstCounter
    {
        private readonly ICounter _couner;

        public FirstCounter(ICounter counter)
        {
            _couner = counter;
        }

        public int IncrementAndGet()
        {
            _couner.Increment();
            return _couner.Get();
        }
    }
}
