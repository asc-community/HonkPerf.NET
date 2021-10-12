global using HonkPerf.NET.Core;

using BenchmarkDotNet.Running;
using Benchmarks;

// 15873.600000000008
// var b = new PWBenchmark();
// Console.WriteLine($"o1: {b.ClassicLinqCombined()}");
// Console.WriteLine($"o2: {b.RefLinqCombined()}");
// Console.WriteLine($"o3: {b.NoAlloqCombined()}");
// Console.WriteLine($"o4: {b.LinqFasterCombined()}");
// Console.WriteLine($"o5: {b.HyperlinqCombined()}");
// Console.WriteLine($"o6: {b.ValueLinqCombined()}");
// Console.WriteLine($"o7: {b.LinqAFCombined()}");
// Console.WriteLine($"o8: {b.StructLinqCombined()}");

// var b = new RNBenchmark();
// Console.WriteLine($"o1: {b.ClassicLinqSum()}");
// Console.WriteLine($"o2: {b.RefLinqSum()}");
// Console.WriteLine($"o3: {b.RefLinqAgg()}");

// var b = new PWBenchmark2();
// Console.WriteLine($"o1: {b.ClassicLinqCombined()}");
// Console.WriteLine($"o2: {b.RefLinqCombined()}");
// Console.WriteLine($"o3: {b.HyperlinqCombined()}");
// Console.WriteLine($"o4: {b.ValueLinqCombined()}");
// Console.WriteLine($"o5: {b.LinqAFCombined()}");

var b = new AppendBench();
Console.WriteLine($"o1: {b.RefLinqBench()}");
Console.WriteLine($"o2: {b.LinqBench()}");


BenchmarkRunner.Run<AppendBench>();

// Console.WriteLine(StackAllocBenchmark.Count(() => new PWBenchmark().RefLinqCombined()));
