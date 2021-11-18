// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

using BenchmarkDotNet.Attributes;
using HonkPerf.NET.RefLinq;
using NetFabric.Hyperlinq;

/*

|         Method |      Mean |    Error |    StdDev |  Gen 0 | Allocated |
|--------------- |----------:|---------:|----------:|-------:|----------:|
|   RefLinqBench |  96.51 ns | 1.968 ns |  3.931 ns |      - |         - |
|      LinqBench | 248.80 ns | 4.945 ns | 11.263 ns | 0.1938 |     608 B |
| HyperLinqBench | 293.72 ns | 6.392 ns | 18.746 ns | 0.2165 |     680 B |
|    LinqAFBench | 253.92 ns | 5.094 ns | 13.509 ns |      - |         - |

*/

[MemoryDiagnoser]
public class AppendPrependBenchmark
{
    [Benchmark]
    public int RefLinqBench()
    {
        var seq =
            Array.Empty<int>()
            .ToRefLinq()
            .Append(2)
            .Append(5)
            .Append(10)
            .Prepend(15)
            .Prepend(3);
        var res = 0;
        foreach (var r in seq)
            res += r;
        return res;
    }
    
    [Benchmark]
    public int LinqBench()
    {
        var seq =
            Array.Empty<int>()
            .Append(2)
            .Append(5)
            .Append(10)
            .Prepend(15)
            .Prepend(3);
        var res = 0;
        foreach (var r in seq)
            res += r;
        return res;
    }

    [Benchmark]
    public int HyperLinqBench()
    {
        var seq =
            Array.Empty<int>()
            .AsValueEnumerable()
            .Append(2)
            .Append(5)
            .Append(10)
            .Prepend(15)
            .Prepend(3);
        var res = 0;
        foreach (var r in seq)
            res += r;
        return res;
    }

    [Benchmark]
    public int LinqAFBench()
    {
        return LinqAF.RunLinqAF3.LinqAFAppend();
    }
}

namespace LinqAF
{
    public static class RunLinqAF3
    {
        public static int LinqAFAppend()
        {
            var seq =
            Array.Empty<int>()
                .Append(2)
                .Append(5)
                .Append(10)
                .Prepend(15)
                .Prepend(3);
            var res = 0;
            foreach (var r in seq)
                res += r;
            return res;
        }
    }
}