namespace Tests.ExtensionsFunctionalTests;

public class SkipTest
{
    [Fact]
    public void Test1()
    {
        var seq =
            new [] { 1, 2, 3, 4 }
            .ToRefLinq()
            .RefSkip(2);
        TestUtils.EqualSequences(seq, new [] { 3, 4 });
    }

    [Fact]
    public void Test2()
    {
        var seq =
            new[] { 1, 2, 3, 4 }
            .ToRefLinq()
            .RefSkip(0);
        TestUtils.EqualSequences(seq, new[] { 1, 2, 3, 4 });
    }

    [Fact]
    public void Test3()
    {
        var seq =
            new[] { 1, 2, 3, 4 }
            .ToRefLinq()
            .RefSkip(4);
        TestUtils.EqualSequences(seq, new int[] { });
    }

    [Fact]
    public void Test4()
    {
        var seq =
            new[] { 1, 2, 3, 4 }
            .ToRefLinq()
            .RefSkip(6);
        TestUtils.EqualSequences(seq, new int[] { });
    }
}