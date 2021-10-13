// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

namespace HonkPerf.NET.RefLinq;

static partial class LazyLinqExtensions
{
    public static RefLinqEnumerable<T, Skip<T, TPrevious>> Skip<T, TPrevious>(this RefLinqEnumerable<T, TPrevious> prev, int toSkip)
        where TPrevious : IRefEnumerable<T>
        => new(new(prev.enumerator, toSkip));
}