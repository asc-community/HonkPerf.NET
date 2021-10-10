namespace HonkPerf.NET.RefLinq;

public static partial class ActiveLinqExtensions
{
    public static bool Any<T, TEnumerator>(this RefLinqEnumerable<T, TEnumerator> seq)
        where TEnumerator : IRefEnumerable<T>
    {
        return seq.enumerator.MoveNext();
    }

    public static bool Any<T, TDelegate, TEnumerator>(this RefLinqEnumerable<T, TEnumerator> seq, TDelegate pred)
        where TEnumerator : IRefEnumerable<T>
        where TDelegate : IValueDelegate<T, bool>
    {
        return seq.RefWhere(pred).enumerator.MoveNext();
    }

    public static bool Any<T, TEnumerator>(this RefLinqEnumerable<T, TEnumerator> seq, Func<T, bool> pred)
        where TEnumerator : IRefEnumerable<T>
    {
        return seq.RefWhere(pred).enumerator.MoveNext();
    }

    public static bool Any<T, TCapture, TEnumerator>(this RefLinqEnumerable<T, TEnumerator> seq, Func<T, TCapture, bool> pred, TCapture capture)
        where TEnumerator : IRefEnumerable<T>
    {
        return seq.RefWhere(pred, capture).enumerator.MoveNext();
    }
}