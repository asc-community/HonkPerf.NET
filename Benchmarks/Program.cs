// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

global using HonkPerf.NET.Core;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using CodegenAnalysis;
using CodegenAnalysis.Benchmarks;
using HonkPerf.NET.RefLinq;
using Iced.Intel;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// 15873.600000000008
// var b = new SelectWhereBenchmark();
// b.Setup();
// Console.WriteLine($"o1: {b.ClassicLinqCombined()}");
// Console.WriteLine($"o2: {b.RefLinqCombined()}");
// Console.WriteLine($"o3: {b.NoAlloqCombined()}");
// Console.WriteLine($"o4: {b.LinqFasterCombined()}");
// Console.WriteLine($"o5: {b.HyperlinqCombined()}");
// Console.WriteLine($"o6: {b.ValueLinqCombined()}");
// Console.WriteLine($"o7: {b.LinqAFCombined()}");
// Console.WriteLine($"o8: {b.StructLinqCombined()}");
BenchmarkRunner.Run<DifferentLengths>();

// var b = new SelectWhereZipSumBenchmarks();
// Console.WriteLine($"o1: {b.RefLinqSum()}");
// Console.WriteLine($"o2: {b.ClassicLinqSum()}");
// Console.WriteLine($"o3: {b.HyperLinqSum()}");
// Console.WriteLine($"o4: {b.ValueLinqSum()}");
// Console.WriteLine($"o5: {b.LinqAFSum()}");


// var b = new SelectWhereAppendPrependConcatSumMaxBenchmarks();
// BenchmarkRunner.Run<SelectWhereAppendPrependConcatSumMaxBenchmarks>();
// Console.WriteLine($"o1: {b.ClassicLinqCombined()}");
// Console.WriteLine($"o2: {b.RefLinqCombined()}");
// Console.WriteLine($"o3: {b.HyperlinqCombined()}");
// Console.WriteLine($"o4: {b.ValueLinqCombined()}");
// Console.WriteLine($"o5: {b.LinqAFCombined()}");

// var b = new AppendPrependBenchmark();
// Console.WriteLine($"o1: {b.RefLinqBench()}");
// Console.WriteLine($"o2: {b.LinqBench()}");
// Console.WriteLine($"o3: {b.HyperLinqBench()}");
// Console.WriteLine($"o4: {b.LinqAFBench()}");
// 
// 

// CodegenBenchmarkRunner.Run<Quack>();
// Console.WriteLine(CodegenBenchmarks.LinqAFManyAppends());
// Console.WriteLine(CodegenBenchmarks.RefLinqManyAppends());

public class Quack
{
    [MethodImpl(MethodImplOptions.NoInlining)]
    public int DoSomethingUseful(BigStruct b)
    {
        return 3;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public BigStruct GetItFromSomewhere() => new();

    [CAAnalyze]
    public int Aaa()
    {
        var a = GetItFromSomewhere();
        return DoSomethingUseful(a);
    }
}

[StructLayout(LayoutKind.Explicit, Size = 100)]
public struct BigStruct
{
}