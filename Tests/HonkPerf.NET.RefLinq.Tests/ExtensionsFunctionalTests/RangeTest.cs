// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

namespace Tests.ExtensionsFunctionalTests;

public class RangeTest
{
    [Fact]
    public void Test1()
    {
        var seq = 
            Enumerable.Range(1, 5);
        TestUtils.EqualSequences(seq, new [] { 1, 2, 3, 4, 5 });
    }

    [Fact]
    public void Test2()
    {
        var seq =
            Enumerable.Range(3, 3);
        TestUtils.EqualSequences(seq, new[] { 3, 4, 5 });
    }
}
