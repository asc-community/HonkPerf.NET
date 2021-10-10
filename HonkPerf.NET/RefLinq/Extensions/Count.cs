namespace HonkPerf.NET.RefLinq;

public static partial class ActiveLinqExtensions
{
    public static int Count<T, TEnumerator>(this RefLinqEnumerable<T, TEnumerator> seq)
        where TEnumerator : IRefEnumerable<T>
    {
        var c = 0;
        foreach (var _ in seq)
            c++;
        return c;
    }

    public static int Count<T, TDelegate, TEnumerator>(this RefLinqEnumerable<T, TEnumerator> seq, TDelegate pred)
        where TEnumerator : IRefEnumerable<T>
        where TDelegate : IValueDelegate<T, bool>
        => seq.RefWhere(pred).Count();

    public static int Count<T, TEnumerator>(this RefLinqEnumerable<T, TEnumerator> seq, Func<T, bool> pred)
        where TEnumerator : IRefEnumerable<T>
        => seq.RefWhere(pred).Count();

    public static int Count<T, TCapture, TEnumerator>(this RefLinqEnumerable<T, TEnumerator> seq, Func<T, TCapture, bool> pred, TCapture capture)
        where TEnumerator : IRefEnumerable<T>
        => seq.RefWhere(pred, capture).Count();
}