namespace HonkPerf.NET.RefLinq.Enumerators;

public interface IRefEnumerable<T>
{
    bool MoveNext();

    T Current { get; }
}

public struct RefLinqEnumerable<T, TEnumerator>
    where TEnumerator : IRefEnumerable<T>
{
    internal TEnumerator enumerator;
    
    public RefLinqEnumerable(TEnumerator en)
        => enumerator = en;

    public TEnumerator GetEnumerator() => enumerator;
}

