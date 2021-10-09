using BenchmarkDotNet.Attributes;
using HonkPerf.NET.RefLinq;

namespace Benchmarks;

[MemoryDiagnoser, DisassemblyDiagnoser(maxDepth: 5, exportHtml: true)]
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
    public double ClassicLinqCombined()
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
    public double RefLinqCombined()
    {
        var res = 0.0;
        var seq = arr.It()
            .RefSelect((int c) => c + 5)
            .RefWhere((int c) => c % 2 == 0)
            .RefSelect((int c) => c - 6.0)
            .RefZip(arr.It());
        foreach (var (a, b) in seq)
            res += a * b;
        return res;
    }
}