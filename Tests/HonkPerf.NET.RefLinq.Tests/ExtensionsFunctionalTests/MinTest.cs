using System;

namespace Tests.ExtensionsFunctionalTests;

public class MinTest
{
    [Fact]
    public void Test1()
    {
        var seq =
            new[] { 1, 7, 3, 4, 5, 1, 1 }
            .ToRefLinq()
            .Min();
        Assert.Equal(1, seq);
    }

    [Fact]
    public void Test2()
    {
        var seq =
            new[] { 2.4, 6.7, -2.4 }
            .ToRefLinq()
            .Min();
        Assert.Equal(-2.4, seq);
    }

    [Fact]
    public void Test3()
    {
        var seq =
            new float [] { }
            .ToRefLinq();
        Assert.Throws<InvalidOperationException>(() => seq.Min());
    }

    [Fact]
    public void Test4()
    {
        var seq =
            new float[] { 1.0f }
            .ToRefLinq()
            .Min();
        Assert.Equal(1.0f, seq);
    }
}