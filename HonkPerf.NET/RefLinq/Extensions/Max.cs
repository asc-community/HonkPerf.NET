
namespace HonkPerf.NET.RefLinq;

public static partial class ActiveLinqExtensions
{
    public static int Max<TEnumerator>(this RefLinqEnumerable<int, TEnumerator> seq)
        where TEnumerator : IRefEnumerable<int>
    {
        int c = int.MinValue;
        foreach (var e in seq)
            c = Math.Max(c, e);
        return c;
    }
    public static uint Max<TEnumerator>(this RefLinqEnumerable<uint, TEnumerator> seq)
        where TEnumerator : IRefEnumerable<uint>
    {
        uint c = uint.MinValue;
        foreach (var e in seq)
            c = Math.Max(c, e);
        return c;
    }
    public static long Max<TEnumerator>(this RefLinqEnumerable<long, TEnumerator> seq)
        where TEnumerator : IRefEnumerable<long>
    {
        long c = long.MinValue;
        foreach (var e in seq)
            c = Math.Max(c, e);
        return c;
    }
    public static ulong Max<TEnumerator>(this RefLinqEnumerable<ulong, TEnumerator> seq)
        where TEnumerator : IRefEnumerable<ulong>
    {
        ulong c = ulong.MinValue;
        foreach (var e in seq)
            c = Math.Max(c, e);
        return c;
    }
    public static float Max<TEnumerator>(this RefLinqEnumerable<float, TEnumerator> seq)
        where TEnumerator : IRefEnumerable<float>
    {
        float c = float.MinValue;
        foreach (var e in seq)
            c = Math.Max(c, e);
        return c;
    }
    public static double Max<TEnumerator>(this RefLinqEnumerable<double, TEnumerator> seq)
        where TEnumerator : IRefEnumerable<double>
    {
        double c = double.MinValue;
        foreach (var e in seq)
            c = Math.Max(c, e);
        return c;
    }
    public static decimal Max<TEnumerator>(this RefLinqEnumerable<decimal, TEnumerator> seq)
        where TEnumerator : IRefEnumerable<decimal>
    {
        decimal c = decimal.MinValue;
        foreach (var e in seq)
            c = Math.Max(c, e);
        return c;
    }
}