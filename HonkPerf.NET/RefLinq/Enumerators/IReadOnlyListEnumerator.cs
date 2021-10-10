namespace HonkPerf.NET.RefLinq.Enumerators;

public struct IReadOnlyListEnumerator<T> : IRefEnumerable<T>
{
    private readonly IReadOnlyList<T> list;
    private int curr;

    public IReadOnlyListEnumerator(IReadOnlyList<T> list)
    {
        this.list = list;
        this.curr = -1;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool MoveNext()
    {
        curr++;
        return curr < list.Count;
    }

    public T Current => list[curr];
}