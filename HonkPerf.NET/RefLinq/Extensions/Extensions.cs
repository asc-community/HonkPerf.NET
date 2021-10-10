namespace HonkPerf.NET.RefLinq;

public static partial class LazyLinqExtensions
{
    public static RefLinqEnumerable<T, IReadOnlyListEnumerator<T>> ToRefLinq<T>(this IReadOnlyList<T> c)
        => new(new(c));
    public static RefLinqEnumerable<T, ArrayEnumerator<T>> ToRefLinq<T>(this T[] c)
        => new(new(c));

    public unsafe static RefLinqEnumerable<T, FixedReadOnlySpanEnumerator<T>> ToRefLinq<T>(this FixedReadOnlySpan<T> c)
        where T : unmanaged
        => new(new(c));
}


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