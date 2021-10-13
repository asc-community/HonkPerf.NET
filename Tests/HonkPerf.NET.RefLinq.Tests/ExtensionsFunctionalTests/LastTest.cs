namespace Tests.ExtensionsFunctionalTests;

public class LastTest
{
    [Fact]
    public void Test1()
    {
        var seq =
            new[] { 2, 3, 4 }
            .ToRefLinq()
            .Last();
        Assert.Equal(4, seq);
    }
    [Fact]
    public void Test3()
    {
        var seq =
            new int[] { }
            .ToRefLinq();
        Assert.Throws<System.InvalidOperationException>(() => seq.Last());
    }
}