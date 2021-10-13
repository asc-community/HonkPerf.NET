// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

namespace HonkPerf.NET.RefLinq;

static partial class LazyLinqExtensions
{
    public static RefLinqEnumerable<U, Select<T, U, PureValueDelegate<T, U>, TPrevious>> Select<T, U, TPrevious>(this RefLinqEnumerable<T, TPrevious> prev, Func<T, U> map)
        where TPrevious : IRefEnumerable<T>
        => new(new(prev.enumerator, new(map)));

    public static RefLinqEnumerable<U, Select<T, U, CapturingValueDelegate<T, TCapture, U>, TPrevious>> Select<T, U, TCapture, TPrevious>(this RefLinqEnumerable<T, TPrevious> prev, Func<T, TCapture, U> map, TCapture capture)
        where TPrevious : IRefEnumerable<T>
        => new(new(prev.enumerator, new(map, capture)));

    public static RefLinqEnumerable<U, Select<T, U, TDelegate, TPrevious>> Select<T, U, TDelegate, TPrevious>(this RefLinqEnumerable<T, TPrevious> prev, TDelegate map, U typeInferenceHint = default!)
        where TPrevious : IRefEnumerable<T>
        where TDelegate : IValueDelegate<T, U>
        => new(new(prev.enumerator, map));
}