// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

using Silk.NET.Maths;

namespace HonkPerf.NET.RefLinq;

public static partial class ActiveLinqExtensions
{
    private struct MaxDelegate<T> : IValueDelegate<T, T, T> where T : unmanaged
    {
        public T Invoke(T a, T b) => Scalar.Max(a, b);
    }
    public static T Max<T, TEnumerator>(this RefLinqEnumerable<T, TEnumerator> seq)
        where TEnumerator : IRefEnumerable<T>
        where T : unmanaged
        => seq.Aggregate(new MaxDelegate<T>());
}