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
    public int ClassicLinq()
    {
        var res = 0;
        var seq = arr
            // .Select(c => c.ToString())
            // .Where(c => c.Length > 1)
            // .Select(c => int.Parse(c) * 100);
            .Select(c => c * 100);
        foreach (var a in seq)
            res += a;
        return res;
    }

    [Benchmark]
    public int RefLinq()
    {
        var res = 0;
        var seq = arr.It()
            // .RefSelect<int, string, IReadOnlyListEnumerator<int>>(c => c.ToString())
            // .RefWhere<string, Select<int, string, IReadOnlyListEnumerator<int>>>(c => c.Length > 1)
            // .RefSelect<string, int, Where<string, Select<int, string, IReadOnlyListEnumerator<int>>>>(c => int.Parse(c) * 100);
            // .RefSelect<string, int, Where<string, Select<int, string, IReadOnlyListEnumerator<int>>>>(c => c * 100);
            .RefSelect<int, int, IReadOnlyListEnumerator<int>>(c => c * 100);
        foreach (var a in seq)
            res += a;
        return res;
    }
}