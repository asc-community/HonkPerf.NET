namespace HonkPerf.NET.RefLinq;

public static class Enumerable
{
    public static RefLinqEnumerable<int, RangeEnumerator> Range(int start, int count)
        => new(new RangeEnumerator(start, count));

    public struct Identity<T> : IValueDelegate<T, T>
    {
        public T Invoke(T arg) => arg;
    }

    public struct Tautology<T> : IValueDelegate<T, bool>
    {
        public bool Invoke(T _) => true;
    }
}