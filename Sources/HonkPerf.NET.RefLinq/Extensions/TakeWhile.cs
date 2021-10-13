// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

namespace HonkPerf.NET.RefLinq;

static partial class LazyLinqExtensions
{
    public static RefLinqEnumerable<T, TakeWhile<T, TPrevious, TDelegate>> TakeWhile<T, TDelegate, TPrevious>(this RefLinqEnumerable<T, TPrevious> prev, TDelegate predicate)
        where TPrevious : IRefEnumerable<T>
        where TDelegate : IValueDelegate<T, bool>
        => new(new(prev.enumerator, predicate));

    public static RefLinqEnumerable<T, TakeWhile<T, TPrevious, PureValueDelegate<T, bool>>> TakeWhile<T, TPrevious>(this RefLinqEnumerable<T, TPrevious> prev, Func<T, bool> predicate)
        where TPrevious : IRefEnumerable<T>
        => prev.TakeWhile(new PureValueDelegate<T, bool>(predicate));

    public static RefLinqEnumerable<T, TakeWhile<T, TPrevious, CapturingValueDelegate<T, TCapture, bool>>> TakeWhile<T, TCapture, TPrevious>(this RefLinqEnumerable<T, TPrevious> prev, Func<T, TCapture, bool> predicate, TCapture capture)
        where TPrevious : IRefEnumerable<T>
        => prev.TakeWhile(new CapturingValueDelegate<T, TCapture, bool>(predicate, capture));
}