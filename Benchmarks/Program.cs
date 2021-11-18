// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

global using HonkPerf.NET.Core;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;


[DisassemblyDiagnoser(exportHtml: true)]
public class Program
{
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<Program>();
    }

    [Benchmark]
    public Vector256<long> Test1()
    {
        var left = Vector256.Create(0L);
        var right = Vector256.Create(1L);

        var tmp = Avx2.CompareGreaterThan(left, right);
        var res = Avx2.CompareEqual(left, right);
        return Avx2.Or(res, tmp);
    }

    [Benchmark]
    public Vector256<long> Test2()
    {
        var left = Vector256.Create(0L);
        var right = Vector256.Create(1L);

        var tmp = Avx2.CompareEqual(left, right);
        var res = Avx2.CompareGreaterThan(left, right);
        return Avx2.Or(res, tmp);
    }
}
