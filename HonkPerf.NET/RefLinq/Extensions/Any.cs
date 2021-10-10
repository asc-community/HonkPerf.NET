namespace HonkPerf.NET.RefLinq;

public static partial class ActiveLinqExtensions
{
    public static bool Any<T, TEnumerator>(this RefLinqEnumerable<T, TEnumerator> seq)
        where TEnumerator : IRefEnumerable<T>
    {
        return seq.enumerator.MoveNext();
    }
}