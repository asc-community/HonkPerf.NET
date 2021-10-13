namespace HonkPerf.NET.RefLinq;

public static partial class ActiveLinqExtensions
{
    public static T SingleOrDefault<T, TEnumerator>(this RefLinqEnumerable<T, TEnumerator> seq)
        where TEnumerator : IRefEnumerable<T>
    {
        if (!seq.enumerator.MoveNext())
            return default!;
        var res = seq.enumerator.Current;
        if (seq.enumerator.MoveNext())
            return default!;
        return res;
    }
}