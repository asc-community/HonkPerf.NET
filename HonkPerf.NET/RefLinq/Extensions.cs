namespace HonkPerf.NET.RefLinq;

public static class LinqExtensions
{
    public static IReadOnlyListEnumerator<T> It<T>(this IReadOnlyList<T> c)
        => new(c);

    public static Select<T, U, TPrevious> RefSelect<T, U, TPrevious>(this TPrevious prev, Func<T, U> map)
        where TPrevious : IRefEnumerable<T>
        => new(prev, map);

    public static Where<T, TPrevious> RefWhere<T, TPrevious>(this TPrevious prev, Func<T, bool> map)
        where TPrevious : IRefEnumerable<T>
        => new(prev, map);

    public static Zip<T1, T2, TEnumerator1, TEnumerator2> RefZip<T1, T2, TEnumerator1, TEnumerator2>(
        this TEnumerator1 seq1,
        TEnumerator2 seq2,
        TypeArg<T1> _,
        TypeArg<T2> __
        )
        where TEnumerator1 : IRefEnumerable<T1>
        where TEnumerator2 : IRefEnumerable<T2>
        => new(seq1, seq2);

    
}
