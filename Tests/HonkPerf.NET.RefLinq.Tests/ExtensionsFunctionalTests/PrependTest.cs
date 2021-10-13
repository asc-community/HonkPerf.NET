// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

namespace Tests.ExtensionsFunctionalTests;

public class PrependTest
{
    [Fact]
    public void Test1()
    {
        TestUtils.EqualSequences(new [] { 1, 2, 3 }.ToRefLinq().Prepend(5), new [] { 5, 1, 2, 3 });
    }

    [Fact]
    public void Test2()
    {
        TestUtils.EqualSequences(new int[] { }.ToRefLinq().Prepend(5), new[] { 5 });
    }
}