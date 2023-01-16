// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

namespace HonkPerf.NET.RefLinq;

public static partial class LazyLinqExtensions
{
    public static RefLinqEnumerable<T, IReadOnlyListEnumerator<T>> ToRefLinq<T>(this IReadOnlyList<T> c)
        => new(new(c));
    public static RefLinqEnumerable<T, ArrayEnumerator<T>> ToRefLinq<T>(this T[] c)
        => new(new(c));
    public static RefLinqEnumerable<T, HashSetEnumerator<T>> ToRefLinq<T>(this HashSet<T> c) 
        => new(new(c));

    public unsafe static RefLinqEnumerable<T, FixedReadOnlySpanEnumerator<T>> ToRefLinq<T>(this FixedReadOnlySpan<T> c)
        where T : unmanaged
        => new(new(c));
}
