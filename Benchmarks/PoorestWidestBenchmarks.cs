using BenchmarkDotNet.Attributes;
using HonkPerf.NET.RefLinq;
using System.Runtime.CompilerServices;
using NoAlloq;
using JM.LinqFaster;
using NetFabric.Hyperlinq;

namespace Benchmarks;

/*
 
|              Method |       Mean |    Error |   StdDev |     Median | Code Size |  Gen 0 | Allocated |
|-------------------- |-----------:|---------:|---------:|-----------:|----------:|-------:|----------:|
| ClassicLinqCombined | 1,167.8 ns | 23.32 ns | 28.64 ns | 1,165.5 ns |   2,112 B | 0.0801 |     256 B |
|     RefLinqCombined | 1,295.0 ns | 25.80 ns | 67.05 ns | 1,277.0 ns |   1,245 B |      - |         - |
|     NoAlloqCombined | 1,345.6 ns | 26.72 ns | 44.65 ns | 1,329.2 ns |   2,114 B | 0.0267 |      88 B |
|  LinqFasterCombined |   671.0 ns | 13.03 ns | 26.91 ns |   660.7 ns |   1,971 B | 0.4253 |   1,336 B |
|   HyperlinqCombined |   664.0 ns | 13.09 ns | 14.55 ns |   661.1 ns |   1,506 B | 0.0277 |      88 B |
 
 
 */

[MemoryDiagnoser, DisassemblyDiagnoser(maxDepth: 5, exportHtml: true)]
public class PWBenchmark
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
            ;
        foreach (var a in seq)
            res += a;
        return res;
    }

    [Benchmark]
    public double RefLinqCombined()
    {
        var res = 0.0;
        var local = GetThing();
        var seq = arr
            .ToRefLinq()
            .RefSelect(c => c + 5)
            .RefWhere(c => c % 2 == 0)
            .RefSelect((c, local) => c - 6.0 / local, local)
            ;
        foreach (var a in seq)
            res += a;
        return res;
    }

    [Benchmark]
    public double NoAlloqCombined()
    {
        var res = 0.0;
        var local = GetThing();
        ReadOnlySpan<int> span = arr;
        var seq =
            span
            .Select(c => c + 5)
            .Where(c => c % 2 == 0)
            .Select(c => c - 6.0 / local)
            ;
        Span<double> dst = stackalloc double[100];
        seq.CopyInto(dst);
        foreach (var a in dst)
            res += a;
        return res;
    }

    [Benchmark]
    public double LinqFasterCombined()
    {
        var res = 0.0;
        var local = GetThing();
        var seq = arr
            .SelectF(c => c + 5)
            .WhereF(c => c % 2 == 0)
            .SelectF(c => c - 6.0 / local)
            ;
        foreach (var a in seq)
            res += a;
        return res;
    }

    [Benchmark]
    public double HyperlinqCombined()
    {
        var res = 0.0;
        var local = GetThing();
        var seq = arr
            .AsValueEnumerable()
            .Select(c => c + 5)
            .Where(c => c % 2 == 0)
            .Select(c => c - 6.0 / local)
            ;
        foreach (var a in seq)
            res += a;
        return res;
    }
}