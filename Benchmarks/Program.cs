// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

global using HonkPerf.NET.Core;

using BenchmarkDotNet.Running;

// 15873.600000000008
// var b = new SelectWhereBenchmark();
// Console.WriteLine($"o1: {b.ClassicLinqCombined()}");
// Console.WriteLine($"o2: {b.RefLinqCombined()}");
// Console.WriteLine($"o3: {b.NoAlloqCombined()}");
// Console.WriteLine($"o4: {b.LinqFasterCombined()}");
// Console.WriteLine($"o5: {b.HyperlinqCombined()}");
// Console.WriteLine($"o6: {b.ValueLinqCombined()}");
// Console.WriteLine($"o7: {b.LinqAFCombined()}");
// Console.WriteLine($"o8: {b.StructLinqCombined()}");

// var b = new SelectWhereZipSumBenchmarks();
// Console.WriteLine($"o1: {b.RefLinqSum()}");
// Console.WriteLine($"o2: {b.ClassicLinqSum()}");
// Console.WriteLine($"o3: {b.HyperLinqSum()}");
// Console.WriteLine($"o4: {b.ValueLinqSum()}");
// Console.WriteLine($"o5: {b.LinqAFSum()}");


// var b = new SelectWhereAppendPrependConcatSumMaxBenchmarks();
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

if (args.Length is 0)
    BenchmarkRunner.Run<SelectWhereBenchmark>();
else
{
    var type = Type.GetType(args[0]);
    if (type is null)
        throw new($"Type {type} not found");
    BenchmarkRunner.Run(type);
}

// Console.WriteLine(StackAllocBenchmark.Count(() => new PWBenchmark().RefLinqCombined()));
