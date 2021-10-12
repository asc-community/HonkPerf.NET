
namespace HonkPerf.NET.RefLinq.Enumerators;

public struct SelectMany<T, TEnumerator, TEnumeratorOfEnumerators>
    : IRefEnumerable<T>
    where TEnumerator : IRefEnumerable<T>
    where TEnumeratorOfEnumerators : IRefEnumerable<RefLinqEnumerable<T, TEnumerator>>
{
    private TEnumeratorOfEnumerators en;
    private TEnumerator currEn;
    private bool iterStarted;

    public SelectMany(TEnumeratorOfEnumerators en)
    {
        this.en = en;
        currEn = default!;
        iterStarted = false;
        Current = default!;
    }

    public bool MoveNext()
    {
        if (!iterStarted)
        {
            iterStarted = true;
            if (en.MoveNext())
            {
                currEn = en.Current.enumerator;
                return MoveNext();
            }
            return false;
        }
        if (currEn.MoveNext())
        {
            Current = currEn.Current;
            return true;
        }
        iterStarted = false;
        return MoveNext();
    }

    public T Current { get; private set; }
}