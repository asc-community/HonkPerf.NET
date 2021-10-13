namespace Tests.ExtensionsFunctionalTests;

public class WhereTest
{
    [Fact]
    public void Test1()
    {
        var seq =
            new[] { 1, 2, 3 }
            .ToRefLinq()
            .Where(c => c > 1);
        TestUtils.EqualSequences(seq, new[] { 2, 3 });
    }

    [Fact]
    public void Test2()
    {
        var seq =
            new[] { 1, 2, 3, 4, 5, 6 }
            .ToRefLinq()
            .Where(c => c % 3 == 0);
        TestUtils.EqualSequences(seq, new[] { 3, 6 });
    }

    [Fact]
    public void Test3()
    {
        var seq =
            new[] { 1, 2, 3, 4, 5, 6 }
            .ToRefLinq()
            .Where(c => true);
        TestUtils.EqualSequences(seq, new[] { 1, 2, 3, 4, 5, 6 });
    }

    [Fact]
    public void Test4()
    {
        var local = 6;
        var seq =
            new[] { 1, 2, 3, 4, 5, 6 }
            .ToRefLinq()
            .Where((c, local) => c + local > 8, local);
        TestUtils.EqualSequences(seq, new[] { 3, 4, 5, 6 });
    }
}

