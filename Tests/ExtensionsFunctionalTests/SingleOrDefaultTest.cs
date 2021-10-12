using System;

namespace Tests.ExtensionsFunctionalTests;

public class SingleOrDefaultTest
{
    [Fact]
    public void Test1()
    {
        var seq =
            new[] { 2 }
            .ToRefLinq()
            .SingleOrDefault();
        Assert.Equal(2, seq);
    }

    [Fact]
    public void Test2()
    {
        var seq =
            new int[] { }
            .ToRefLinq()
            .SingleOrDefault();
        Assert.Equal(0, seq);
    }

    [Fact]
    public void Test3()
    {
        var seq =
            new int[] { 1, 2 }
            .ToRefLinq()
            .SingleOrDefault();
        Assert.Equal(0, seq);
    }
}