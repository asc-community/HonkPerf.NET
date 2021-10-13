// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

using System;

namespace Tests.ExtensionsFunctionalTests;

public class MaxByTest
{
    [Fact]
    public void Test1()
    {
        var seq =
            new[] { (1, "a"), (7, "b"), (3, "c"), (4, "d"), (5, "e"), (1, "f"), (1, "g") }
            .ToRefLinq()
            .MaxBy(c => c.Item1);
        Assert.Equal((7, "b"), seq);
    }

    [Fact]
    public void Test2()
    {
        var seq =
            new[] { (2.4, "ohNO!"), (2.0, "hahah!"), (-3.3, ":d") }
            .ToRefLinq()
            .MaxBy(a => a.Item1);
        Assert.Equal("ohNO!", seq.Item2);
    }

    [Fact]
    public void Test3()
    {
        var seq =
            new float [] { }
            .ToRefLinq();
        Assert.Throws<InvalidOperationException>(() => seq.MaxBy(c => c));
    }

    [Fact]
    public void Test4()
    {
        var seq =
            new [] { (1.0f, "aaaa") }
            .ToRefLinq()
            .MaxBy(c => c.Item1);
        Assert.Equal("aaaa", seq.Item2);
    }
}