namespace Architecture.Architecture.Extensions.Coroutines
{
    public class CoroutineLifetime
    {
        public bool isStopped { get; private set; }

        public void Stop() => isStopped = true;
    }
}