// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

namespace HonkPerf.NET.RefLinq;

public static partial class ActiveLinqExtensions
{
    public static RefLinqEnumerable<T, Append<T, TPrevious>> Append<T, TPrevious>(this RefLinqEnumerable<T, TPrevious> prev, T toAppend)
        where TPrevious : IRefEnumerable<T>
        => new(new(prev.enumerator, toAppend));
}