// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

namespace Tests.ExtensionsFunctionalTests;

public class SelectManyTest
{
    [Fact]
    public void Test1()
    {
        var a = 
            new [] { 1d, 2d, 3d }
            .ToRefLinq()
            .Select(c => Enumerable.Range(1, (int)c))
            .SelectMany();
        TestUtils.EqualSequences(a, new [] { 1, 1, 2, 1, 2, 3 });
    }

    [Fact]
    public void Test2()
    {
        var a =
            new[] { 1d, 2d, 3d }
            .ToRefLinq()
            .SelectMany(c => Enumerable.Range(1, (int)c));
        TestUtils.EqualSequences(a, new[] { 1, 1, 2, 1, 2, 3 });
    }

    [Fact]
    public void Test3()
    {
        var local = 1;
        var a =
            new[] { 1d, 2d, 3d }
            .ToRefLinq()
            .SelectMany((c, local) => Enumerable.Range(1, (int)c + local), local);
        TestUtils.EqualSequences(a, new[] { 1, 2, 1, 2, 3, 1, 2, 3, 4 });
    }

    [Fact]
    public void OnlyEmptyEnumerables()
    {
        var a =
            new[] { 1, 2, 3, 4, 5 }
            .ToRefLinq()
            .Select(i => System.Array.Empty<int>().ToRefLinq())
            .SelectMany();
        TestUtils.EqualSequences(a, new int[] { });
    }

    [Fact]
    public void WithEmptyEnumerables()
    {
        var a =
            new[] { 1, 2, 3, 4, 5 }
            .ToRefLinq()
            .Select(i => (i % 2 == 0 ? System.Array.Empty<int>() : new[] { i, i * 2, i * 3 }).ToRefLinq())
            .SelectMany();
        TestUtils.EqualSequences(a, new[] { 1, 2, 3, 3, 6, 9, 5, 10, 15 });
    }
}