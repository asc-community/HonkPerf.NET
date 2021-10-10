namespace HonkPerf.NET.RefLinq.Enumerators;

public struct ArrayEnumerator<T> : IRefEnumerable<T>
{
    private readonly T[] array;
    private int curr;

    public ArrayEnumerator(T[] array)
    {
        this.array = array;
        this.curr = -1;
        Current = default!;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool MoveNext()
    {
        curr++;
        if (curr < array.Length)
        {
            Current = array[curr];
            return true;
        }
        return false;
    }

    public T Current { get; private set; }
}