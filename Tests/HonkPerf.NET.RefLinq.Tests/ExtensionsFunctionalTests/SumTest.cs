// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

namespace Tests.ExtensionsFunctionalTests;

public class SumTest
{
    [Fact]
    public void Test1()
    {
        var s = 
            new [] { 1, 2, 3 }
            .ToRefLinq()
            .Sum();
        Assert.Equal(6, s);
    }

    [Fact]
    public void Test2()
    {
        var s =
            new[] { 1.25, 2.5, 3.25 }
            .ToRefLinq()
            .Sum();
        Assert.Equal(7d, s);
    }

    [Fact]
    public void Test3()
    {
        var s =
            new int[] { }
            .ToRefLinq()
            .Sum();
        Assert.Equal(0, s);
    }
}