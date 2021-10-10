namespace HonkPerf.NET.RefLinq;

public static partial class ActiveLinqExtensions
{
    public static bool All<T, TDelegate, TEnumerator>(this RefLinqEnumerable<T, TEnumerator> seq, TDelegate pred)
        where TEnumerator : IRefEnumerable<T>
        where TDelegate : IValueDelegate<T, bool>
    {
        foreach (var el in seq)
            if (!pred.Invoke(el))
                return false;
        return true;
    }
}