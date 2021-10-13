// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

namespace Tests.ExtensionsFunctionalTests;

public class CountTest
{
    [Fact]
    public void Test1()
    {
        var seq =
            new[] { 1, 2, 3, 4 }
            .ToRefLinq()
            .Count(c => c > 3);
        Assert.Equal(1, seq);
    }

    [Fact]
    public void Test2()
    {
        var seq =
            new[] { 1, 2, 3, 4 }
            .ToRefLinq()
            .Count(c => c is >= 2 and <= 3);
        Assert.Equal(2, seq);
    }

    [Fact]
    public void Test3()
    {
        var seq =
            new int[] { }
            .ToRefLinq()
            .Count();
        Assert.Equal(0, seq);
    }
}