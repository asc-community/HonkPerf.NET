namespace HonkPerf.NET.RefLinq;

public static class LinqExtensions
{
    public static RefLinq<T, IReadOnlyListEnumerator<T>> It<T>(this IReadOnlyList<T> c)
        => new(new(c));

    public static RefLinq<U, Select<T, U, PureValueDelegate<T, U>, TPrevious>> RefSelect<T, U, TPrevious>(this RefLinq<T, TPrevious> prev, Func<T, U> map)
        where TPrevious : IRefEnumerable<T>
        => new(new(prev.enumerator, new(map)));

    public static RefLinq<U, Select<T, U, CapturingValueDelegate<T, TCapture, U>, TPrevious>> RefSelect<T, U, TCapture, TPrevious>(this RefLinq<T, TPrevious> prev, Func<T, TCapture, U> map, TCapture capture)
        where TPrevious : IRefEnumerable<T>
        => new(new(prev.enumerator, new(map, capture)));

    public static RefLinq<T, Where<T, PureValueDelegate<T, bool>, TPrevious>> RefWhere<T, TPrevious>(this RefLinq<T, TPrevious> prev, Func<T, bool> pred)
        where TPrevious : IRefEnumerable<T>
        => new(new(prev.enumerator, new(pred)));

    public static RefLinq<(T1, T2), Zip<T1, T2, TEnumerator1, TEnumerator2>> RefZip<T1, T2, TEnumerator1, TEnumerator2>(
        this RefLinq<T1, TEnumerator1> seq1, RefLinq<T2, TEnumerator2> seq2)
        where TEnumerator1 : IRefEnumerable<T1>
        where TEnumerator2 : IRefEnumerable<T2>
        => new(new(seq1.enumerator, seq2.enumerator));

    
}
