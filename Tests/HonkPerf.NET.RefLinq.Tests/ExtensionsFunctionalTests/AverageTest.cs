// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

namespace Tests.ExtensionsFunctionalTests;

public class AverageTest
{
    [Fact]
    public void Test1()
    {
        Assert.Equal(2, new[] { 1, 2, 3 }.ToRefLinq().Average());
    }

    [Fact]
    public void Test2()
    {
        Assert.Equal(1.625, new[] { 1, 2, 3.5, 0 }.ToRefLinq().Average());
    }
}