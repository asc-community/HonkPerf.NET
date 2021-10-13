// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

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
        return seq.Where(pred).enumerator.MoveNext();
    }

    public static bool Any<T, TEnumerator>(this RefLinqEnumerable<T, TEnumerator> seq, Func<T, bool> pred)
        where TEnumerator : IRefEnumerable<T>
    {
        return seq.Where(pred).enumerator.MoveNext();
    }

    public static bool Any<T, TCapture, TEnumerator>(this RefLinqEnumerable<T, TEnumerator> seq, Func<T, TCapture, bool> pred, TCapture capture)
        where TEnumerator : IRefEnumerable<T>
    {
        return seq.Where(pred, capture).enumerator.MoveNext();
    }
}