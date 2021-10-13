// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

namespace HonkPerf.NET.RefLinq;

public static partial class ActiveLinqExtensions
{
    public static T FirstOrDefault<T, TEnumerator>(this RefLinqEnumerable<T, TEnumerator> seq)
        where TEnumerator : IRefEnumerable<T>
    {
        if (seq.enumerator.MoveNext())
            return seq.enumerator.Current;
        return default!;
    }
}