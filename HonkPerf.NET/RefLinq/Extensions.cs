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
}
