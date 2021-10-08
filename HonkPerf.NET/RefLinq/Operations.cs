namespace HonkPerf.NET.RefLinq;

public interface IRefEnumerable<T>
{
    bool MoveNext();
    T Current { get; }
}


public struct Select<T, U, TEnumerator>
    : IRefEnumerable<U>
    where TEnumerator : IRefEnumerable<T>
{
    public Select(TEnumerator prev, Func<T, U> map)
    {
        this.prev = prev;
        this.map = map;
        Current = default!;
    }
    private TEnumerator prev;
    private readonly Func<T, U> map;
    public bool MoveNext()
    {
        var res = prev.MoveNext();
        if (res)
            Current = map(prev.Current);
        return res;
    }
    public U Current { get; private set;}

    public Select<T, U, TEnumerator> GetEnumerator() => this;
}

public struct Where<T, TEnumerator>
    : IRefEnumerable<T>
    where TEnumerator : IRefEnumerable<T>
{
    public Where(TEnumerator prev, Func<T, bool> map)
    {
        this.prev = prev;
        this.map = map;
    }
    private TEnumerator prev;
    private readonly Func<T, bool> map;
    public bool MoveNext()
    {
        tryAgain:
        if (!prev.MoveNext())
            return false;
        if (!map(prev.Current))
            goto tryAgain;
        return true;
    }
    public T Current => prev.Current;

    public Where<T, TEnumerator> GetEnumerator() => this;
}


public struct IReadOnlyListEnumerator<T> : IRefEnumerable<T>
{
    private readonly IReadOnlyList<T> list;
    private int curr;

    public IReadOnlyListEnumerator(IReadOnlyList<T> list)
    {
        this.list = list;
        this.curr = -1;
    }

    public bool MoveNext()
    {
        curr++;
        return curr < list.Count;
    }

    public T Current => list[curr];
}