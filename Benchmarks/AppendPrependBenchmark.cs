namespace Benchmarks;

public class AppendBench
{
    [Benchmark]
    public int RefLinqBench()
    {
        var seq =
            new int[0]
            .ToRefLinq()
            .Append(2)
            .Append(5)
            .Append(10)
            .Prepend(15)
            .Prepend(3);
        var res = 0;
        foreach (var r in seq)
            res += r;
        return res;
    }
    
    [Benchmark]
    public int LinqBench()
    {
        var seq =
            new int[0]
            .Append(2)
            .Append(5)
            .Append(10)
            .Prepend(15)
            .Prepend(3);
        var res = 0;
        foreach (var r in seq)
            res += r;
        return res;
    }
}
