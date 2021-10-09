using BenchmarkDotNet.Attributes;
using HonkPerf.NET.RefLinq;
using System.Runtime.CompilerServices;
using NoAlloq;
using JM.LinqFaster;
using NetFabric.Hyperlinq;
using StructLinq;

/*
 
|              Method |       Mean |    Error |   StdDev | Code Size |  Gen 0 | Allocated |
|-------------------- |-----------:|---------:|---------:|----------:|-------:|----------:|
| ClassicLinqCombined | 1,272.3 ns | 25.41 ns | 48.96 ns |   2,112 B | 0.0801 |     256 B |
|     RefLinqCombined | 1,303.9 ns | 25.56 ns | 32.33 ns |   1,245 B |      - |         - |
|     NoAlloqCombined | 1,362.8 ns | 26.61 ns | 54.96 ns |   2,114 B | 0.0267 |      88 B |
|  LinqFasterCombined |   774.4 ns | 15.48 ns | 25.86 ns |   1,971 B | 0.4253 |   1,336 B |
|   HyperlinqCombined |   702.6 ns | 10.77 ns | 16.45 ns |   1,506 B | 0.0277 |      88 B |
|   ValueLinqCombined |   770.8 ns | 15.32 ns | 14.33 ns |   1,364 B | 0.0172 |      56 B |
|      LinqAFCombined |   771.9 ns | 15.10 ns | 14.13 ns |   1,807 B | 0.0277 |      88 B |
|  StructLinqCombined |   768.8 ns | 10.16 ns |  9.01 ns |     933 B | 0.0582 |     184 B |


 
 
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

    [Benchmark]
    public double ValueLinqCombined()
    {
        return Cistern.ValueLinq.RunValueLinq.ValueLinqCombined(arr, GetThing());
    }

    
    [Benchmark]
    public double LinqAFCombined()
    {
        return LinqAF.RunLinqAF.LinqAFCombined(arr, GetThing());
    }

    [Benchmark]
    public double StructLinqCombined()
    {
        var res = 0.0;
        var local = GetThing();
        var seq = arr
            .ToStructEnumerable()
            .Select(c => c + 5)
            .Where(c => c % 2 == 0)
            .Select(c => c - 6.0 / local)
            ;
        foreach (var a in seq)
            res += a;
        return res;
    }
}

namespace Cistern.ValueLinq
{
    struct ValueLinqCapture : Cistern.ValueLinq.IFunc<int, double>
    {
        private int capture;
        public ValueLinqCapture(int capture)
            => this.capture = capture;
        public double Invoke(int c) => c - 6.0 / capture;
    }

    public static class RunValueLinq
    {
        public static double ValueLinqCombined(int[] arr, int local)
        {
            var res = 0.0;
            var seq = arr
                .Select(c => c + 5)
                .Where(c => c % 2 == 0)
                .Select(
                new ValueLinqCapture(local),
                default(double))
                ;
            foreach (var a in seq)
                res += a;
            return res;
        }
    }
}

namespace LinqAF
{
    public static class RunLinqAF
    {
        public static double LinqAFCombined(int[] arr, int local)
        {
            var res = 0.0;
            var seq = arr
                .Select(c => c + 5)
                .Where(c => c % 2 == 0)
                .Select(c => c - 6.0 / local)
                ;
            foreach (var a in seq)
                res += a;
            return res;
        }
    }
}