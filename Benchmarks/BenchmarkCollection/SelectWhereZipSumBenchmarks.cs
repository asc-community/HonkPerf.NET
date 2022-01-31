// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

using BenchmarkDotNet.Attributes;
using HonkPerf.NET.RefLinq;
using System.Runtime.CompilerServices;
using NoAlloq;
using NetFabric.Hyperlinq;

/*

|         Method |     Mean |     Error |    StdDev |   Median | Code Size |  Gen 0 | Allocated |
|--------------- |---------:|----------:|----------:|---------:|----------:|-------:|----------:|
|     RefLinqSum | 1.870 us | 0.0344 us | 0.0409 us | 1.863 us |   2,714 B |      - |         - |
| ClassicLinqSum | 2.724 us | 0.0562 us | 0.1640 us | 2.679 us |   3,436 B | 0.1831 |     584 B |
|   HyperLinqSum | 2.446 us | 0.0466 us | 0.0816 us | 2.431 us |   2,780 B | 0.1755 |     560 B |
|   ValueLinqSum | 1.574 us | 0.0311 us | 0.0553 us | 1.582 us |   3,545 B | 0.0401 |     128 B |
|      LinqAFSum | 2.268 us | 0.0453 us | 0.1201 us | 2.250 us |   4,228 B | 0.0458 |     152 B |

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
        var local = GetThing();
        var seq = arr
            .ToRefLinq()
            .Select(c => c + 5)
            .Where(c => c % 2 == 0)
            .Select((c, local) => c - 6.0 / local, local)
            .Zip(arr.ToRefLinq().Where(c => c % 2 == 1))
            .Where((p, local) => local > 10, local)
            .Select(p => p.Item1 * p.Item2)
            ;
        return seq.Sum();
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

    [Benchmark]
    public double HyperLinqSum()
    {
        var local = GetThing();
        var seq = arr
            .AsValueEnumerable()
            .Select(c => c + 5)
            .Where(c => c % 2 == 0)
            .Select(c => c - 6.0 / local)
            .Zip(arr.AsValueEnumerable().Where(c => c % 2 == 1))
            .Where(p => local > 10)
            .Select(p => p.Item1 * p.Item2)
            ;
        return seq.Sum();
    }

    [Benchmark]
    public double ValueLinqSum()
    {
        return Cistern.ValueLinq.RunValueLinq4.ValueLinqCombined(arr, GetThing());
    }

    [Benchmark]
    public double LinqAFSum()
    {
        return LinqAF.RunLinqAF4.LinqAFCombined(arr, GetThing());
    }
}

namespace Cistern.ValueLinq
{
    struct ValueLinqCapture4 : Cistern.ValueLinq.IFunc<int, double>
    {
        private int capture;
        public ValueLinqCapture4(int capture)
            => this.capture = capture;
        public double Invoke(int c) => c - 6.0 / capture;
    }

    public static class RunValueLinq4
    {
        public static double ValueLinqCombined(int[] arr, int local)
        {
            var seq = arr
                .Select(c => c + 5)
                .Where(c => c % 2 == 0)
                .Select(new ValueLinqCapture4(local), default(double))
                .Zip(arr.Where(c => c % 2 == 1))
                .Where(p => local > 10)
                .Select(p => p.Item1 * p.Item2)
                ;
            return seq.Sum();
        }
    }
}

namespace LinqAF
{
    public static class RunLinqAF4
    {
        public static double LinqAFCombined(int[] arr, int local)
        {
            var seq = arr
                .Select(c => c + 5)
                .Where(c => c % 2 == 0)
                .Select(c => c - 6.0 / local)
                .Zip(arr.Where(c => c % 2 == 1), (a, b) => (a, b))
                .Where(p => local > 10)
                .Select(p => p.Item1 * p.Item2)
                ;
            return seq.Sum();
        }
    }
}