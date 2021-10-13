// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

namespace Tests.ExtensionsFunctionalTests;

public class TakeTest
{
    [Fact]
    public void Test1()
    {
        var seq =
            new [] { 1, 2, 3 }
            .ToRefLinq()
            .Take(2);
        TestUtils.EqualSequences(seq, new [] { 1, 2 });
    }

    [Fact]
    public void Test2()
    {
        var seq =
            new[] { 1, 2, 3 }
            .ToRefLinq()
            .Take(3);
        TestUtils.EqualSequences(seq, new[] { 1, 2, 3 });
    }

    [Fact]
    public void Test3()
    {
        var seq =
            new[] { 1, 2, 3 }
            .ToRefLinq()
            .Take(6);
        TestUtils.EqualSequences(seq, new[] { 1, 2, 3 });
    }

    [Fact]
    public void Test4()
    {
        var seq =
            new[] { 1, 2, 3 }
            .ToRefLinq()
            .Take(0);
        TestUtils.EqualSequences(seq, new int[] { });
    }
}
