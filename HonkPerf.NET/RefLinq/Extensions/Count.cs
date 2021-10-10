namespace HonkPerf.NET.RefLinq;

public static partial class ActiveLinqExtensions
{
    public static int Count<T, TEnumerator>(this RefLinqEnumerable<T, TEnumerator> seq)
        where TEnumerator : IRefEnumerable<T>
    {
        var c = 0;
        foreach (var _ in seq)
            c++;
        return c;
    }
}