namespace HonkPerf.NET.RefLinq;

static partial class LazyLinqExtensions
{
    public static RefLinqEnumerable<U, Select<T, U, PureValueDelegate<T, U>, TPrevious>> RefSelect<T, U, TPrevious>(this RefLinqEnumerable<T, TPrevious> prev, Func<T, U> map)
        where TPrevious : IRefEnumerable<T>
        => new(new(prev.enumerator, new(map)));

    public static RefLinqEnumerable<U, Select<T, U, CapturingValueDelegate<T, TCapture, U>, TPrevious>> RefSelect<T, U, TCapture, TPrevious>(this RefLinqEnumerable<T, TPrevious> prev, Func<T, TCapture, U> map, TCapture capture)
        where TPrevious : IRefEnumerable<T>
        => new(new(prev.enumerator, new(map, capture)));
}