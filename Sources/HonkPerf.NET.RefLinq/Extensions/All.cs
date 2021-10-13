// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

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

    public static bool All<T, TEnumerator>(this RefLinqEnumerable<T, TEnumerator> seq, Func<T, bool> pred)
        where TEnumerator : IRefEnumerable<T>
        => seq.All(new PureValueDelegate<T, bool>(pred));

    public static bool All<T, TCapture, TEnumerator>(this RefLinqEnumerable<T, TEnumerator> seq, Func<T, TCapture, bool> pred, TCapture capture)
        where TEnumerator : IRefEnumerable<T>
        => seq.All(new CapturingValueDelegate<T, TCapture, bool>(pred, capture));
}