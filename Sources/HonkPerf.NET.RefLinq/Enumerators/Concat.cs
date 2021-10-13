namespace HonkPerf.NET.RefLinq.Enumerators;

public struct Concat<T, TEnumerator1, TEnumerator2>
    : IRefEnumerable<T>
    where TEnumerator1 : IRefEnumerable<T>
    where TEnumerator2 : IRefEnumerable<T>
{
    private TEnumerator1 first;
    private TEnumerator2 second;
    private bool firstIsOver;

    public Concat(TEnumerator1 first, TEnumerator2 second)
    {
        this.first = first;
        this.second = second;
        firstIsOver = false;
        Current = default!;
    }

    public bool MoveNext()
    {
        if (firstIsOver)
        {
            if (second.MoveNext())
            {
                Current = second.Current;
                return true;
            }
            return false;
        }
        if (first.MoveNext())
        {
            Current = first.Current;
            return true;
        }
        else
        {
            firstIsOver = true;
            return MoveNext();
        }
    }

    public T Current { get; private set; }
}