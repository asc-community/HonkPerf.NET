namespace HonkPerf.NET.RefLinq.Enumerators;

public struct Take<T, TEnumerator>
    : IRefEnumerable<T>
    where TEnumerator : IRefEnumerable<T>
{
    private TEnumerator en;
    private int toTake;
    public Take(TEnumerator en, int toTake)
    {
        this.en = en;
        this.toTake = toTake;
        Current = default!;
    }
    public bool MoveNext()
    {
        if (toTake > 0 && en.MoveNext())
        {
            Current = en.Current;
            toTake--;
            return true;
        }
        return false;
    }

    public T Current { get; private set; }
}