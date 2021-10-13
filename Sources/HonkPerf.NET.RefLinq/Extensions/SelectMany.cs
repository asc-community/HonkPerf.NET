namespace HonkPerf.NET.RefLinq;

static partial class LazyLinqExtensions
{
    public static RefLinqEnumerable<T, SelectMany<T, TEnumerator, TEnumeratorOfEnumerators>> SelectMany<T, TEnumerator, TEnumeratorOfEnumerators>(this RefLinqEnumerable<RefLinqEnumerable<T, TEnumerator>, TEnumeratorOfEnumerators> prev)
        where TEnumerator : IRefEnumerable<T>
        where TEnumeratorOfEnumerators : IRefEnumerable<RefLinqEnumerable<T, TEnumerator>>
        => new(new(prev.enumerator));

    public static RefLinqEnumerable<U, SelectMany<U, TUEnumerator, Select<T, RefLinqEnumerable<U, TUEnumerator>, TDelegate, TEnumerator>>> SelectMany<T, U, TDelegate, TEnumerator, TUEnumerator>(this RefLinqEnumerable<T, TEnumerator> prev, TDelegate func)
        where TEnumerator : IRefEnumerable<T>
        where TUEnumerator : IRefEnumerable<U>
        where TDelegate : IValueDelegate<T, RefLinqEnumerable<U, TUEnumerator>>
    {
        var res = prev.Select<T, RefLinqEnumerable<U, TUEnumerator>, TDelegate, TEnumerator>(func);
        var r = res.SelectMany();
        return r;
    }

    public static RefLinqEnumerable<U, SelectMany<U, TUEnumerator, Select<T, RefLinqEnumerable<U, TUEnumerator>, PureValueDelegate<T, RefLinqEnumerable<U, TUEnumerator>>, TEnumerator>>> SelectMany<T, U, TEnumerator, TUEnumerator>(this RefLinqEnumerable<T, TEnumerator> prev, Func<T, RefLinqEnumerable<U, TUEnumerator>> func)
        where TEnumerator : IRefEnumerable<T>
        where TUEnumerator : IRefEnumerable<U>
        => prev.SelectMany<T, U, PureValueDelegate<T, RefLinqEnumerable<U, TUEnumerator>>, TEnumerator, TUEnumerator>(new PureValueDelegate<T, RefLinqEnumerable<U, TUEnumerator>>(func));

    public static RefLinqEnumerable<U, SelectMany<U, TUEnumerator, Select<T, RefLinqEnumerable<U, TUEnumerator>, CapturingValueDelegate<T, TCapture, RefLinqEnumerable<U, TUEnumerator>>, TEnumerator>>> SelectMany<T, U, TCapture, TEnumerator, TUEnumerator>(this RefLinqEnumerable<T, TEnumerator> prev, Func<T, TCapture, RefLinqEnumerable<U, TUEnumerator>> func, TCapture capture)
        where TEnumerator : IRefEnumerable<T>
        where TUEnumerator : IRefEnumerable<U>
        => prev.SelectMany<T, U, CapturingValueDelegate<T, TCapture, RefLinqEnumerable<U, TUEnumerator>>, TEnumerator, TUEnumerator>(new CapturingValueDelegate<T, TCapture, RefLinqEnumerable<U, TUEnumerator>>(func, capture));
}