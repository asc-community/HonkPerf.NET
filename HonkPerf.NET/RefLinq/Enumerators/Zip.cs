namespace HonkPerf.NET.RefLinq.Enumerators;

public struct Zip<T1, T2, TEnumerator1, TEnumerator2>
    : IRefEnumerable<(T1, T2)>
    where TEnumerator1 : IRefEnumerable<T1>
    where TEnumerator2 : IRefEnumerable<T2>
{
    private TEnumerator1 en1;
    private TEnumerator2 en2;

    public Zip(TEnumerator1 en1, TEnumerator2 en2)
    {
        this.en1 = en1;
        this.en2 = en2;
        Current = default;
    }

    public (T1, T2) Current { get; private set; }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool MoveNext()
    {
        var res1 = en1.MoveNext();
        var res2 = en2.MoveNext();
        if (!res1 && !res2)
            return false;
        if (res1 && res2)
        {
            Current = (en1.Current, en2.Current);
            return true;
        }
        ThrowInvalid();
        return default;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void ThrowInvalid()
        => throw new InvalidOperationException("Collections should have the same size");

    public Zip<T1, T2, TEnumerator1, TEnumerator2> GetEnumerator() => this;
}