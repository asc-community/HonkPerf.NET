namespace HonkPerf.NET.RefLinq;

public static class Enumerable
{
    public static RefLinqEnumerable<int, RangeEnumerator> Range(int start, int count)
        => new(new RangeEnumerator(start, count));
}