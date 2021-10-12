using System.Linq;

namespace Tests.ExtensionsFunctionalTests;

public class SelectManyTest
{
    [Fact]
    public void Test1()
    {
        var a = 
            new [] { 1d, 2d, 3d }
            .ToRefLinq()
            .Select(c => Enumerable.Range(1, (int)c).ToArray().ToRefLinq())
            .SelectMany();
        TestUtils.EqualSequences(a, new [] { 1, 1, 2, 1, 2, 3 });
    }

    [Fact]
    public void OnlyEmptyEnumerables()
    {
        var a =
            new[] { 1, 2, 3, 4, 5 }
            .ToRefLinq()
            .Select(i => Array.Empty<int>().ToRefLinq())
            .SelectMany();
        TestUtils.EqualSequences(a, new int[] { });
    }

    [Fact]
    public void WithEmptyEnumerables()
    {
        var a =
            new[] { 1, 2, 3, 4, 5 }
            .ToRefLinq()
            .Select(i => (i % 2 == 0 ? Array.Empty<int>() : new[] { i, i * 2, i * 3 }).ToRefLinq())
            .SelectMany();
        TestUtils.EqualSequences(a, new[] { 1, 2, 3, 3, 6, 9, 5, 10, 15 });
    }
}