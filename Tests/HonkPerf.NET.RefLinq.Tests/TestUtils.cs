global using HonkPerf.NET.RefLinq;
global using Xunit;
global using HonkPerf.NET.Core;

using HonkPerf.NET.RefLinq.Enumerators;
using System.Collections.Generic;

namespace Tests;

public static class TestUtils
{
    public static void EqualSequences<T, TEnumerator>(RefLinqEnumerable<T, TEnumerator> en, IEnumerable<T> expected)
        where TEnumerator : IRefEnumerable<T>
    {
        var list = new List<T>();
        foreach (var el in en)
            list.Add(el);
        Assert.Equal(expected, list);
    }
}