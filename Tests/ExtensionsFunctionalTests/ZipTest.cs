namespace Tests.ExtensionsFunctionalTests;

public class ZipTest
{
    [Fact]
    public void Test1()
    {
        var z = new[] { 1, 2, 3, 10, 20, 30, 502, 2342, 23 }.ToRefLinq();
        var w1 = z
            .Where(c => c > 5)
            .Select(c => c * 100.0);
        var w2 = z
            .Where(c => c > 5);
        var seq = w2.Zip(w1);
        TestUtils.EqualSequences(seq, new[] {
            (10, 1000d),
            (20, 2000d),
            (30, 3000d),
            (502, 50200d),
            (2342, 234200d),
            (23, 2300d)
            });
    }

    [Fact]
    public void Test2()
    {
        var a = new [] { 1, 2, 3 }.ToRefLinq();
        var b = new [] { "aa", "aaa", "b" }.ToRefLinq();
        TestUtils.EqualSequences(a.Zip(b), new [] { (1, "aa"), (2, "aaa"), (3, "b") });
    }

    [Fact]
    public void Test3()
    {
        var a = new[] { 1, 2, 3 }.ToRefLinq();
        var b = new[] { "aa", "aaa" }.ToRefLinq();
        Assert.Throws<System.InvalidOperationException>(() => a.Zip(b));
    }

    [Fact]
    public void Test4()
    {
        var a = new[] { 1, 2 }.ToRefLinq();
        var b = new[] { "aa", "aaa", "b" }.ToRefLinq();
        Assert.Throws<System.InvalidOperationException>(() => a.Zip(b));
    }

    [Fact]
    public void Test5()
    {
        var a = new int[] { }.ToRefLinq();
        var b = new string[] { }.ToRefLinq();
        TestUtils.EqualSequences(a.Zip(b), new (int, string)[0]);
    }
}