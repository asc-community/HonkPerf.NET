// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

using BenchmarkDotNet.Attributes;
using HonkPerf.NET.RefLinq;
using System.Runtime.CompilerServices;
using NoAlloq;
using JM.LinqFaster;
using NetFabric.Hyperlinq;
using StructLinq;

/*

|              Method |     Mean |     Error |    StdDev | Code Size |  Gen 0 | Allocated |
|-------------------- |---------:|----------:|----------:|----------:|-------:|----------:|
|     RefLinqCombined | 4.193 us | 0.0835 us | 0.2125 us |   2,679 B |      - |         - |
| ClassicLinqCombined | 8.053 us | 0.1582 us | 0.2971 us |   3,173 B | 0.3204 |   1,032 B |
|   HyperlinqCombined | 7.555 us | 0.1397 us | 0.2410 us |   2,491 B | 0.2975 |     944 B |
|   ValueLinqCombined | 5.142 us | 0.1021 us | 0.1967 us |   3,903 B | 0.2823 |     888 B |
|      LinqAFCombined | 5.938 us | 0.1128 us | 0.1299 us |   5,431 B | 0.0381 |     120 B |
 
 */

[MemoryDiagnoser, DisassemblyDiagnoser(maxDepth: 5, exportHtml: true)]
public class SelectWhereAppendPrependConcatSumMaxBenchmarks
{
    private static readonly int[] arr = new[] {
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
    public static double RefLinqCombined()
    {
        var seq = arr
            .ToRefLinq()
            .Select(c => c + 5)
            .Where(c => c % 2 == 0)
            .Select(c => c - 6.0)
            .Append(3)
            .Append(5)
            .Prepend(3)
            .Concat(arr
            .ToRefLinq().Select(c => c / 1d))
            ;
        return seq.Sum() + seq.Max();
    }

    [Benchmark]
    public static double ClassicLinqCombined()
    {
        var seq = arr
            .Select(c => c + 5)
            .Where(c => c % 2 == 0)
            .Select(c => c - 6.0)
            .Append(3)
            .Append(5)
            .Prepend(3)
            .Concat(arr.Select(c => c / 1d))
            ;
        return seq.Sum() + seq.Max();
    }


    [Benchmark]
    public double HyperlinqCombined()
    {
        var seq = arr
            .AsValueEnumerable()
            .Select(c => c + 5)
            .Where(c => c % 2 == 0)
            .Select(c => c - 6.0)
            .Append(3)
            .Append(5)
            .Prepend(3)
            .Concat(arr.AsValueEnumerable().Select(c => c / 1d))
            ;
        return seq.Sum() + seq.Max();
    }

    [Benchmark]
    public double ValueLinqCombined()
    {
        return Cistern.ValueLinq.RunValueLinq2.ValueLinqCombined(arr, GetThing());
    }

    
    [Benchmark]
    public double LinqAFCombined()
    {
        return LinqAF.RunLinqAF2.LinqAFCombined(arr, GetThing());
    }

}

namespace Cistern.ValueLinq
{
    struct ValueLinqCapture2 : Cistern.ValueLinq.IFunc<int, double>
    {
        private int capture;
        public ValueLinqCapture2(int capture)
            => this.capture = capture;
        public double Invoke(int c) => c - 6.0 / capture;
    }

    public static class RunValueLinq2
    {
        public static double ValueLinqCombined(int[] arr, int local)
        {
            var res = 0.0;
            var seq = arr
                .Select(c => c + 5)
                .Where(c => c % 2 == 0)
                .Select(c => c - 6.0)
                .Append(3)
                .Append(5)
                .Prepend(3)
                .Concat(arr.AsValueEnumerable().Select(c => c / 1d))
                ;
            return seq.Sum() + seq.Max();
        }
    }
}

namespace LinqAF
{
    public static class RunLinqAF2
    {
        public static double LinqAFCombined(int[] arr, int local)
        {
            var seq = arr
                .Select(c => c + 5)
                .Where(c => c % 2 == 0)
                .Select(c => c - 6.0)
                .Append(3)
                .Append(5)
                .Prepend(3)
                .Concat(arr.AsValueEnumerable().Select(c => c / 1d))
                ;
            return seq.Sum() + seq.Max();
        }
    }
}