// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using Benchmarks;

// 15873.600000000008
var b = new PWBenchmark();
Console.WriteLine($"o1: {b.ClassicLinqCombined()}");
Console.WriteLine($"o2: {b.RefLinqCombined()}");
Console.WriteLine($"o3: {b.NoAlloqCombined()}");
Console.WriteLine($"o4: {b.LinqFasterCombined()}");
Console.WriteLine($"o5: {b.HyperlinqCombined()}");
Console.WriteLine($"o6: {b.ValueLinqCombined()}");
Console.WriteLine($"o7: {b.LinqAFCombined()}");
Console.WriteLine($"o8: {b.StructLinqCombined()}");

BenchmarkRunner.Run<PWBenchmark>();

// Console.WriteLine(StackAllocBenchmark.Count(() => new PWBenchmark().RefLinqCombined()));
