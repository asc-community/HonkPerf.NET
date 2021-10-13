// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

namespace HonkPerf.NET.RefLinq;

public static partial class ActiveLinqExtensions
{
    public static bool Contains<T, TEnumerator>(this RefLinqEnumerable<T, TEnumerator> seq, T toFind)
        where TEnumerator : IRefEnumerable<T>
    {
        foreach (var el in seq)
        {
            if (toFind is not null && toFind.Equals(el) || toFind is null && el is null)
                return true;
        }
        return false;
    }
}