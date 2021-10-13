// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

namespace Tests.ExtensionsFunctionalTests;

public class MultiplyTest
{
    [Fact]
    public void Test1()
    {
        var s = 
            new [] { 1, 2, 3 }
            .ToRefLinq()
            .Multiply();
        Assert.Equal(6, s);
    }

    [Fact]
    public void Test2()
    {
        var s =
            new[] { 4, 0.5, 7 }
            .ToRefLinq()
            .Multiply();
        Assert.Equal(14d, s);
    }

    [Fact]
    public void Test3()
    {
        var s =
            new int[] { }
            .ToRefLinq()
            .Multiply();
        Assert.Equal(1, s);
    }
}