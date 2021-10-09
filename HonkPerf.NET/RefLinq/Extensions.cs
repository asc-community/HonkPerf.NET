namespace HonkPerf.NET.RefLinq;

public static class LinqExtensions
{
    public static RefLinqEnumerable<T, IReadOnlyListEnumerator<T>> ToRefLinq<T>(this IReadOnlyList<T> c)
        => new(new(c));
    public static RefLinqEnumerable<T, IArrayEnumerator<T>> ToRefLinq<T>(this T[] c)
        => new(new(c));

    public static RefLinqEnumerable<U, Select<T, U, PureValueDelegate<T, U>, TPrevious>> RefSelect<T, U, TPrevious>(this RefLinqEnumerable<T, TPrevious> prev, Func<T, U> map)
        where TPrevious : IRefEnumerable<T>
        => new(new(prev.enumerator, new(map)));

    public static RefLinqEnumerable<U, Select<T, U, CapturingValueDelegate<T, TCapture, U>, TPrevious>> RefSelect<T, U, TCapture, TPrevious>(this RefLinqEnumerable<T, TPrevious> prev, Func<T, TCapture, U> map, TCapture capture)
        where TPrevious : IRefEnumerable<T>
        => new(new(prev.enumerator, new(map, capture)));

    public static RefLinqEnumerable<T, Where<T, PureValueDelegate<T, bool>, TPrevious>> RefWhere<T, TPrevious>(this RefLinqEnumerable<T, TPrevious> prev, Func<T, bool> pred)
        where TPrevious : IRefEnumerable<T>
        => new(new(prev.enumerator, new(pred)));

    public static RefLinqEnumerable<T, Where<T, CapturingValueDelegate<T, TCapture, bool>, TPrevious>> RefWhere<T, TCapture, TPrevious>(this RefLinqEnumerable<T, TPrevious> prev, Func<T, TCapture, bool> pred, TCapture capture)
        where TPrevious : IRefEnumerable<T>
        => new(new(prev.enumerator, new(pred, capture)));

    public static RefLinqEnumerable<(T1, T2), Zip<T1, T2, TEnumerator1, TEnumerator2>> RefZip<T1, T2, TEnumerator1, TEnumerator2>(
        this RefLinqEnumerable<T1, TEnumerator1> seq1, RefLinqEnumerable<T2, TEnumerator2> seq2)
        where TEnumerator1 : IRefEnumerable<T1>
        where TEnumerator2 : IRefEnumerable<T2>
        => new(new(seq1.enumerator, seq2.enumerator));

    
}
