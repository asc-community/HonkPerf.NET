namespace HonkPerf.NET.RefLinq;

public static partial class ActiveLinqExtensions
{
    public static T Single<T, TEnumerator>(this RefLinqEnumerable<T, TEnumerator> seq)
        where TEnumerator : IRefEnumerable<T>
    {
        if (!seq.enumerator.MoveNext())
        {
            ThrowHelpers.ThrowSequenceContainsNoElements();
        }
        var res = seq.enumerator.Current;
        if (seq.enumerator.MoveNext())
            ThrowHelpers.ThrowSequenceContainsMoreThanOneElement();
        return res;
    }
}