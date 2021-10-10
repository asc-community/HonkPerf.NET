
namespace HonkPerf.NET.RefLinq;

public static partial class ActiveLinqExtensions
{
    public static int Min<TEnumerator>(this RefLinqEnumerable<int, TEnumerator> seq)
        where TEnumerator : IRefEnumerable<int>
    {
        int c = int.MaxValue;
        foreach (var e in seq)
            c = Math.Min(c, e);
        return c;
    }
    public static uint Min<TEnumerator>(this RefLinqEnumerable<uint, TEnumerator> seq)
        where TEnumerator : IRefEnumerable<uint>
    {
        uint c = uint.MaxValue;
        foreach (var e in seq)
            c = Math.Min(c, e);
        return c;
    }
    public static long Min<TEnumerator>(this RefLinqEnumerable<long, TEnumerator> seq)
        where TEnumerator : IRefEnumerable<long>
    {
        long c = long.MaxValue;
        foreach (var e in seq)
            c = Math.Min(c, e);
        return c;
    }
    public static ulong Min<TEnumerator>(this RefLinqEnumerable<ulong, TEnumerator> seq)
        where TEnumerator : IRefEnumerable<ulong>
    {
        ulong c = ulong.MaxValue;
        foreach (var e in seq)
            c = Math.Min(c, e);
        return c;
    }
    public static float Min<TEnumerator>(this RefLinqEnumerable<float, TEnumerator> seq)
        where TEnumerator : IRefEnumerable<float>
    {
        float c = float.MaxValue;
        foreach (var e in seq)
            c = Math.Min(c, e);
        return c;
    }
    public static double Min<TEnumerator>(this RefLinqEnumerable<double, TEnumerator> seq)
        where TEnumerator : IRefEnumerable<double>
    {
        double c = double.MaxValue;
        foreach (var e in seq)
            c = Math.Min(c, e);
        return c;
    }
    public static decimal Min<TEnumerator>(this RefLinqEnumerable<decimal, TEnumerator> seq)
        where TEnumerator : IRefEnumerable<decimal>
    {
        decimal c = decimal.MaxValue;
        foreach (var e in seq)
            c = Math.Min(c, e);
        return c;
    }
}