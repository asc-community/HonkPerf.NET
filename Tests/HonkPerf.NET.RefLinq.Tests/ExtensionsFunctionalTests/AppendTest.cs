namespace Tests.ExtensionsFunctionalTests;

public class AppendTest
{
    [Fact]
    public void Test1()
    {
        TestUtils.EqualSequences(new [] { 1, 2, 3 }.ToRefLinq().Append(5), new [] { 1, 2, 3, 5 });
    }

    [Fact]
    public void Test2()
    {
        TestUtils.EqualSequences(new int[] { }.ToRefLinq().Append(5), new[] { 5 });
    }
}