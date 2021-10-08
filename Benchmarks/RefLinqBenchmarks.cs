using BenchmarkDotNet.Attributes;
using HonkPerf.NET.RefLinq;

namespace Benchmarks;

[MemoryDiagnoser]
public class RefLinqBenchmark
{
    private readonly int[] arr = new[] {
        1, 2, 3, 10, 20, 30, 502, 2342, 23, 234, 23, 2235, 32, 324322, 333,
        1, 2, 3, 10, 20, 30, 502, 2342, 23, 234, 23, 2235, 32, 324322, 333,
        1, 2, 3, 10, 20, 30, 502, 2342, 23, 234, 23, 2235, 32, 324322, 333,
        1, 2, 3, 10, 20, 30, 502, 2342, 23, 234, 23, 2235, 32, 324322, 333,
        1, 2, 3, 10, 20, 30, 502, 2342, 23, 234, 23, 2235, 32, 324322, 333,
        1, 2, 3, 10, 20, 30, 502, 2342, 23, 234, 23, 2235, 32, 324322, 333,
        };

    [Benchmark]
    public double ClassicLinq()
    {
        var res = 0.0;
        var seq = arr
            .Select(c => c + 5)
            .Where(c => c % 2 == 0)
            .Select(c => c - 6.0);
        foreach (var a in seq)
            res += a;
        return res;
    }

    [Benchmark]
    public double RefLinq()
    {
        var res = 0.0;
        var seq = arr.It()
            .RefSelect<int, int, IReadOnlyListEnumerator<int>>(c => c + 5)
            .RefWhere<int, Select<int, int, IReadOnlyListEnumerator<int>>>(c => c % 2 == 0)
            .RefSelect<int, double, Where<int, Select<int, int, IReadOnlyListEnumerator<int>>>>(c => c - 6.0);
        foreach (var a in seq)
            res += a;
        return res;
    }
}