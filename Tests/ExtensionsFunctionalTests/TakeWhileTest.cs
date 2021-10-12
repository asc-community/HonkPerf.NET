namespace Tests.ExtensionsFunctionalTests;

public class TakeWhileTest
{
    [Fact]
    public void Test1()
    {
        var seq =
            new [] { 1, 2, 3 }
            .ToRefLinq()
            .TakeWhile(c => c < 3);
        TestUtils.EqualSequences(seq, new [] { 1, 2 });
    }

    [Fact]
    public void Test2()
    {
        var seq =
            new[] { "aaa", "ohnooo", "aaa" }
            .ToRefLinq()
            .TakeWhile(c => c.Length < 5);
        TestUtils.EqualSequences(seq, new[] { "aaa" });
    }

    [Fact]
    public void Test3()
    {
        var seq =
            new[] { 1, 2, 3 }
            .ToRefLinq()
            .TakeWhile(new Enumerable.Tautology<int>());
        TestUtils.EqualSequences(seq, new[] { 1, 2, 3 });
    }

    [Fact]
    public void Test4()
    {
        var seq =
            new[] { 1, 2, 3 }
            .ToRefLinq()
            .TakeWhile(_ => false);
        TestUtils.EqualSequences(seq, new int[] { });
    }
}
