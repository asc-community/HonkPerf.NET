namespace Tests.ExtensionsFunctionalTests;

public class ContainsTest
{
    [Fact]
    public void Test1()
    {
        var seq =
            new[] { 1, 2, 3, 4 }
            .ToRefLinq()
            .Contains(2);
        Assert.True(seq);
    }

    [Fact]
    public void Test2()
    {
        var seq =
            new[] { 1, 2, 3, 4 }
            .ToRefLinq()
            .Contains(5);
        Assert.False(seq);
    }
}