
namespace HonkPerf.NET.RefLinq;

public static partial class ActiveLinqExtensions
{
    public static int Sum<TEnumerator>(this RefLinqEnumerable<int, TEnumerator> seq)
        where TEnumerator : IRefEnumerable<int>
    {
        int c = 0;
        foreach (var e in seq)
            c += e;
        return c;
    }
    public static uint Sum<TEnumerator>(this RefLinqEnumerable<uint, TEnumerator> seq)
        where TEnumerator : IRefEnumerable<uint>
    {
        uint c = 0;
        foreach (var e in seq)
            c += e;
        return c;
    }
    public static long Sum<TEnumerator>(this RefLinqEnumerable<long, TEnumerator> seq)
        where TEnumerator : IRefEnumerable<long>
    {
        long c = 0;
        foreach (var e in seq)
            c += e;
        return c;
    }
    public static ulong Sum<TEnumerator>(this RefLinqEnumerable<ulong, TEnumerator> seq)
        where TEnumerator : IRefEnumerable<ulong>
    {
        ulong c = 0;
        foreach (var e in seq)
            c += e;
        return c;
    }
    public static float Sum<TEnumerator>(this RefLinqEnumerable<float, TEnumerator> seq)
        where TEnumerator : IRefEnumerable<float>
    {
        float c = 0;
        foreach (var e in seq)
            c += e;
        return c;
    }
    public static double Sum<TEnumerator>(this RefLinqEnumerable<double, TEnumerator> seq)
        where TEnumerator : IRefEnumerable<double>
    {
        double c = 0;
        foreach (var e in seq)
            c += e;
        return c;
    }
    public static decimal Sum<TEnumerator>(this RefLinqEnumerable<decimal, TEnumerator> seq)
        where TEnumerator : IRefEnumerable<decimal>
    {
        decimal c = 0;
        foreach (var e in seq)
            c += e;
        return c;
    }
}