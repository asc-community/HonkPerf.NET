namespace HonkPerf.NET.RefLinq.Enumerators;

public struct HashSetEnumerator<T> : IRefEnumerable<T>
{
    private T curr;
    private HashSet<T>.Enumerator ie;
	
    public HashSetEnumerator(HashSet<T> set)
    {
        ie = set.GetEnumerator();
        curr = default;
    }
	
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool MoveNext()
    {
        bool t = ie.MoveNext();
        curr = ie.Current;
        if(!t)
        	ie.Dispose();
        return t;
    }
	
    public T Current => curr;
}
