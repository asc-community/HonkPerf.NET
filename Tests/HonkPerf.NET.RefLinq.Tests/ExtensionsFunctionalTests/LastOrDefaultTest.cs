namespace Tests.ExtensionsFunctionalTests;

public class LastOrDefaultTest
{
    [Fact]
    public void Test1()
    {
        var seq =
            new[] { 2, 3, 4 }
            .ToRefLinq()
            .LastOrDefault();
        Assert.Equal(4, seq);
    }
    [Fact]
    public void Test3()
    {
        var seq =
            new int[] { }
            .ToRefLinq()
            .LastOrDefault();
        Assert.Equal(0, seq);
    }
}