// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

namespace Tests.ExtensionsFunctionalTests;

public class AggregateTest
{
    [Fact]
    public void Test1()
    {
        var seq = 
            new [] { "aa", "bbb", "ccc" }
            .ToRefLinq()
            .Aggregate("", (string a, string b) => a + b);
        Assert.Equal("aabbbccc", seq);
    }

    [Fact]
    public void Test2()
    {
        var seq =
            new[] { "aa", "bbb", "ccc" }
            .ToRefLinq()
            .Aggregate("", (string a, string b) => a + b);
        Assert.Equal("aabbbccc", seq);
    }
}