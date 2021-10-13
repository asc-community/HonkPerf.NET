// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

namespace Tests.ExtensionsFunctionalTests;

public class FirstTest
{
    [Fact]
    public void Test1()
    {
        var seq =
            new[] { 2, 3, 4 }
            .ToRefLinq()
            .First();
        Assert.Equal(2, seq);
    }
    [Fact]
    public void Test3()
    {
        var seq =
            new int[] { }
            .ToRefLinq();
        Assert.Throws<System.InvalidOperationException>(() => seq.First());
    }
}