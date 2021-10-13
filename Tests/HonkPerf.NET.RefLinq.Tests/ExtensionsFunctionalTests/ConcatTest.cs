// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

namespace Tests.ExtensionsFunctionalTests;

public class ConcatTest
{
    [Fact]
    public void Test1()
    {
        var seq =
            new [] { 1, 2, 3 }
            .ToRefLinq()
            .Concat(new [] { 4, 5 }.ToRefLinq());
        TestUtils.EqualSequences(seq, new [] { 1, 2, 3, 4, 5 });
    }

    [Fact]
    public void Test2()
    {
        var seq =
            new int[] { }
            .ToRefLinq()
            .Concat(new[] { 4, 5 }.ToRefLinq());
        TestUtils.EqualSequences(seq, new[] { 4, 5 });
    }

    [Fact]
    public void Test3()
    {
        var seq =
            new[] { 1, 2, 3 }
            .ToRefLinq()
            .Concat(new int[] { }.ToRefLinq());
        TestUtils.EqualSequences(seq, new[] { 1, 2, 3 });
    }

    [Fact]
    public void Test4()
    {
        var seq =
            new int[] { }
            .ToRefLinq()
            .Concat(new int[] { }.ToRefLinq());
        TestUtils.EqualSequences(seq, new int[] { });
    }
}