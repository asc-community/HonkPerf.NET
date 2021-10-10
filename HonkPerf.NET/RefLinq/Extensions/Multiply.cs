
namespace HonkPerf.NET.RefLinq;

public static partial class ActiveLinqExtensions
{
    public static int Multiply<TEnumerator>(this RefLinqEnumerable<int, TEnumerator> seq)
        where TEnumerator : IRefEnumerable<int>
    {
        int c = 1;
        foreach (var e in seq)
            c *= e;
        return c;
    }
    public static uint Multiply<TEnumerator>(this RefLinqEnumerable<uint, TEnumerator> seq)
        where TEnumerator : IRefEnumerable<uint>
    {
        uint c = 1;
        foreach (var e in seq)
            c *= e;
        return c;
    }
    public static long Multiply<TEnumerator>(this RefLinqEnumerable<long, TEnumerator> seq)
        where TEnumerator : IRefEnumerable<long>
    {
        long c = 1;
        foreach (var e in seq)
            c *= e;
        return c;
    }
    public static ulong Multiply<TEnumerator>(this RefLinqEnumerable<ulong, TEnumerator> seq)
        where TEnumerator : IRefEnumerable<ulong>
    {
        ulong c = 1;
        foreach (var e in seq)
            c *= e;
        return c;
    }
    public static float Multiply<TEnumerator>(this RefLinqEnumerable<float, TEnumerator> seq)
        where TEnumerator : IRefEnumerable<float>
    {
        float c = 1;
        foreach (var e in seq)
            c *= e;
        return c;
    }
    public static double Multiply<TEnumerator>(this RefLinqEnumerable<double, TEnumerator> seq)
        where TEnumerator : IRefEnumerable<double>
    {
        double c = 1;
        foreach (var e in seq)
            c *= e;
        return c;
    }
    public static decimal Multiply<TEnumerator>(this RefLinqEnumerable<decimal, TEnumerator> seq)
        where TEnumerator : IRefEnumerable<decimal>
    {
        decimal c = 1;
        foreach (var e in seq)
            c *= e;
        return c;
    }
}