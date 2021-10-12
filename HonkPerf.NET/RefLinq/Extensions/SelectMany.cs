namespace HonkPerf.NET.RefLinq;

static partial class LazyLinqExtensions
{
    public static RefLinqEnumerable<T, SelectMany<T, TEnumerator, TEnumeratorOfEnumerators>> SelectMany<T, TEnumerator, TEnumeratorOfEnumerators>(this RefLinqEnumerable<RefLinqEnumerable<T, TEnumerator>, TEnumeratorOfEnumerators> prev)
        where TEnumerator : IRefEnumerable<T>
        where TEnumeratorOfEnumerators : IRefEnumerable<RefLinqEnumerable<T, TEnumerator>>
        => new(new(prev.enumerator));
}