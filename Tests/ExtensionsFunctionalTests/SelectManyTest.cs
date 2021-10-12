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
}