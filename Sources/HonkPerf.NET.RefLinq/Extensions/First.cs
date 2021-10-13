namespace HonkPerf.NET.RefLinq;

public static partial class ActiveLinqExtensions
{
    public static T First<T, TEnumerator>(this RefLinqEnumerable<T, TEnumerator> seq)
        where TEnumerator : IRefEnumerable<T>
    {
        if (seq.enumerator.MoveNext())
            return seq.enumerator.Current;
        ThrowHelpers.ThrowSequenceContainsNoElements();
        return default!;
    }
}