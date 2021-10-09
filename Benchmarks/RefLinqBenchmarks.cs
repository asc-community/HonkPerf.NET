using BenchmarkDotNet.Attributes;
using HonkPerf.NET.RefLinq;

namespace Benchmarks;

/*

|              Method |     Mean |     Error |    StdDev |  Gen 0 | Code Size | Allocated |
|-------------------- |---------:|----------:|----------:|-------:|----------:|----------:|
| ClassicLinqCombined | 2.227 us | 0.0443 us | 0.1060 us | 0.0954 |   2,373 B |     304 B |
|     RefLinqCombined | 2.292 us | 0.0457 us | 0.0725 us |      - |   1,621 B |         - |

 * */

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
            .Select(c => c - 6.0)
            .Zip(arr.Where(c => c % 2 == 1))
            ;
        foreach (var (a, b) in seq)
            res += a * b;
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
            .RefZip(
                arr.It()
                .RefWhere((int c) => c % 2 == 1), 
                new TypeArg<double>(), new TypeArg<int>())
            ;
        foreach (var (a, b) in seq)
            res += a * b;
        return res;
    }
}