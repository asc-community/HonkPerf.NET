// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

namespace HonkPerf.NET.RefLinq;

static partial class LazyLinqExtensions
{
    public static RefLinqEnumerable<T, Where<T, PureValueDelegate<T, bool>, TPrevious>> Where<T, TPrevious>(this RefLinqEnumerable<T, TPrevious> prev, Func<T, bool> pred)
        where TPrevious : IRefEnumerable<T>
        => new(new(prev.enumerator, new(pred)));

    public static RefLinqEnumerable<T, Where<T, CapturingValueDelegate<T, TCapture, bool>, TPrevious>> Where<T, TCapture, TPrevious>(this RefLinqEnumerable<T, TPrevious> prev, Func<T, TCapture, bool> pred, TCapture capture)
        where TPrevious : IRefEnumerable<T>
        => new(new(prev.enumerator, new(pred, capture)));

    public static RefLinqEnumerable<T, Where<T, TDelegate, TPrevious>> Where<T, TDelegate, TPrevious>(this RefLinqEnumerable<T, TPrevious> prev, TDelegate pred)
        where TPrevious : IRefEnumerable<T>
        where TDelegate : IValueDelegate<T, bool>
        => new(new(prev.enumerator, pred));
}