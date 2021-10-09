using BenchmarkDotNet.Attributes;
using HonkPerf.NET.RefLinq;
using System.Runtime.CompilerServices;
using NoAlloq;

namespace Benchmarks;

/*

|              Method |     Mean |     Error |    StdDev | Code Size |  Gen 0 | Allocated |
|-------------------- |---------:|----------:|----------:|----------:|-------:|----------:|
| ClassicLinqCombined | 2.523 us | 0.0486 us | 0.1137 us |   2,830 B | 0.1640 |     520 B |
|     RefLinqCombined | 2.481 us | 0.0457 us | 0.0406 us |   2,348 B |      - |         - |

 * */

[MemoryDiagnoser, DisassemblyDiagnoser(maxDepth: 5, exportHtml: true)]
public class RNBenchmark
{
    private readonly int[] arr = new[] {
        1, 2, 3, 10, 20, 30, 502, 2342, 23, 234, 23, 2235, 32, 324322, 333,
        1, 2, 3, 10, 20, 30, 502, 2342, 23, 234, 23, 2235, 32, 324322, 333,
        1, 2, 3, 10, 20, 30, 502, 2342, 23, 234, 23, 2235, 32, 324322, 333,
        1, 2, 3, 10, 20, 30, 502, 2342, 23, 234, 23, 2235, 32, 324322, 333,
        1, 2, 3, 10, 20, 30, 502, 2342, 23, 234, 23, 2235, 32, 324322, 333,
        1, 2, 3, 10, 20, 30, 502, 2342, 23, 234, 23, 2235, 32, 324322, 333,
        };


    [MethodImpl(MethodImplOptions.NoInlining)]
    static int GetThing()
        => 15;

    [Benchmark]
    public double ClassicLinqCombined()
    {
        var res = 0.0;
        var local = GetThing();
        var seq = arr
            .Select(c => c + 5)
            .Where(c => c % 2 == 0)
            .Select(c => c - 6.0 / local)
            .Zip(arr.Where(c => c % 2 == 1))
            .Where(p => local > 10)
            ;
        foreach (var (a, b) in seq)
            res += a * b;
        return res;
    }

    [Benchmark]
    public double RefLinqCombined()
    {
        var res = 0.0;
        var local = GetThing();
        var seq = arr.ToRefLinq()
            .RefSelect(c => c + 5)
            .RefWhere(c => c % 2 == 0)
            .RefSelect((c, local) => c - 6.0 / local, local)
            .RefZip(arr.ToRefLinq().RefWhere(c => c % 2 == 1))
            .RefWhere((p, local) => local > 10, local)
            ;
        foreach (var (a, b) in seq)
            res += a * b;
        return res;
    }
}