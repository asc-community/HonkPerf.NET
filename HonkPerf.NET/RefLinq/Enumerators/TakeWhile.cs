namespace HonkPerf.NET.RefLinq.Enumerators;

public struct TakeWhile<T, TEnumerator, TDelegate>
    : IRefEnumerable<T>
    where TEnumerator : IRefEnumerable<T>
    where TDelegate : IValueDelegate<T, bool>
{
    private TEnumerator en;
    private TDelegate pred;
    public TakeWhile(TEnumerator en, TDelegate pred)
    {
        this.en = en;
        this.pred = pred;
        Current = default!;
    }
    public bool MoveNext()
    {
        return en.MoveNext()
            && pred.Invoke(Current = en.Current);
    }

    public T Current { get; private set; }
}