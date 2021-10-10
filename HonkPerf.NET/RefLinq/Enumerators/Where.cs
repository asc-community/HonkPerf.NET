namespace HonkPerf.NET.RefLinq.Enumerators;

public struct Where<T, TDelegate, TEnumerator>
    : IRefEnumerable<T>
    where TDelegate : IValueDelegate<T, bool>
    where TEnumerator : IRefEnumerable<T>
{
    public Where(TEnumerator prev, TDelegate map)
    {
        this.prev = prev;
        this.map = map;
    }
    private TEnumerator prev;
    private readonly TDelegate map;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool MoveNext()
    {
        tryAgain:
        if (!prev.MoveNext())
            return false;
        if (!map.Invoke(prev.Current))
            goto tryAgain;
        return true;
    }
    public T Current => prev.Current;

    public Where<T, TDelegate, TEnumerator> GetEnumerator() => this;
}