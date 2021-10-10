namespace Tests.ExtensionsFunctionalTests;

public class SelectTest
{
    [Fact]
    public void Test1()
    {
        var seq = 
            new [] { 1, 2, 3 } 
            .ToRefLinq()
            .RefSelect(c => c * 2);
        TestUtils.EqualSequences(seq, new [] { 2, 4, 6 });
    }

    [Fact]
    public void Test2()
    {
        var seq =
            new int[] { }
            .ToRefLinq()
            .RefSelect(c => c * 2);
        TestUtils.EqualSequences(seq, new int[] { });
    }

    [Fact]
    public void Test3()
    {
        var local = 5;
        var seq =
            new int[] { 1, 2, 3 }
            .ToRefLinq()
            .RefSelect((c, local) => c * local, local);
        TestUtils.EqualSequences(seq, new int[] { 5, 10, 15 });
    }
}