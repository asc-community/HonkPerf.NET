using BenchmarkDotNet.Attributes;
using HonkPerf.NET.RefLinq;
using System.Runtime.CompilerServices;
using NoAlloq;

namespace Benchmarks;

/*

|         Method |     Mean |     Error |    StdDev |   Median | Code Size |  Gen 0 | Allocated |
|--------------- |---------:|----------:|----------:|---------:|----------:|-------:|----------:|
| ClassicLinqSum | 2.756 us | 0.0551 us | 0.1607 us | 2.705 us |   3,436 B | 0.1831 |     584 B |
|     RefLinqSum | 2.017 us | 0.0394 us | 0.0701 us | 2.014 us |   2,714 B |      - |         - |
|     RefLinqAgg | 2.032 us | 0.0405 us | 0.0827 us | 2.007 us |   2,706 B |      - |         - |

 * */

[MemoryDiagnoser, DisassemblyDiagnoser(maxDepth: 5, exportHtml: true)]
public class SelectWhereZipSumBenchmarks
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
    public double RefLinqSum()
    {
        var res = 0.0;
        var local = GetThing();
        var seq = arr.ToRefLinq()
            .Select(c => c + 5)
            .Where(c => c % 2 == 0)
            .Select((c, local) => c - 6.0 / local, local)
            .Zip(arr.ToRefLinq().Where(c => c % 2 == 1))
            .Where((p, local) => local > 10, local)
            .Select(p => p.Item1 * p.Item2)
            ;
        return seq.Sum();
    }

    private struct AddInts : IValueDelegate<double, double, double>
    {
        public double Invoke(double a, double b)
            => a + b;
    }

    [Benchmark]
    public double RefLinqAgg()
    {
        var res = 0.0;
        var local = GetThing();
        var seq = arr.ToRefLinq()
            .Select(c => c + 5)
            .Where(c => c % 2 == 0)
            .Select((c, local) => c - 6.0 / local, local)
            .Zip(arr.ToRefLinq().Where(c => c % 2 == 1))
            .Where((p, local) => local > 10, local)
            .Select(p => p.Item1 * p.Item2)
            ;
        return seq.Aggregate(0.0, new AddInts());
    }

    [Benchmark]
    public double ClassicLinqSum()
    {
        var local = GetThing();
        var seq = arr
            .Select(c => c + 5)
            .Where(c => c % 2 == 0)
            .Select(c => c - 6.0 / local)
            .Zip(arr.Where(c => c % 2 == 1))
            .Where(p => local > 10)
            .Select(p => p.Item1 * p.Item2)
            ;
        return seq.Sum();
    }
}