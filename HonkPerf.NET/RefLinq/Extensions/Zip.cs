namespace HonkPerf.NET.RefLinq;

static partial class LazyLinqExtensions
{
    public static RefLinqEnumerable<(T1, T2), Zip<T1, T2, TEnumerator1, TEnumerator2>> RefZip<T1, T2, TEnumerator1, TEnumerator2>(
        this RefLinqEnumerable<T1, TEnumerator1> seq1, RefLinqEnumerable<T2, TEnumerator2> seq2)
        where TEnumerator1 : IRefEnumerable<T1>
        where TEnumerator2 : IRefEnumerable<T2>
        => new(new(seq1.enumerator, seq2.enumerator));


}