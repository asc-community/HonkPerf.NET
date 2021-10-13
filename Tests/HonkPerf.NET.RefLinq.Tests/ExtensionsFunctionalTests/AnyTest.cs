// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

namespace Tests.ExtensionsFunctionalTests;

public class AnyTest
{
    [Fact]
    public void Test1()
    {
        var seq =
            new[] { 1, 2, 3, 4 }
            .ToRefLinq()
            .Any(c => c > 3);
        Assert.True(seq);
    }

    [Fact]
    public void Test2()
    {
        var seq =
            new[] { 1, 2, 3, 4 }
            .ToRefLinq()
            .Any(c => c < 1);
        Assert.False(seq);
    }

    [Fact]
    public void Test3()
    {
        var seq =
            new int[] { }
            .ToRefLinq();
        Assert.False(seq.Any(c => c < 5));
        Assert.False(seq.Any(c => c > 5));
        Assert.False(seq.Any(c => c == 5));
    }
}