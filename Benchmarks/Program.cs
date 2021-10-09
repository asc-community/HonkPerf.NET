// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using Benchmarks;

// var b = new RefLinqBenchmark();


var b = new PWBenchmark();
Console.WriteLine($"o1: {b.ClassicLinqCombined()}");
Console.WriteLine($"o2: {b.RefLinqCombined()}");
Console.WriteLine($"o3: {b.NoAlloqCombined()}");
Console.WriteLine($"o4: {b.LinqFasterCombined()}");
Console.WriteLine($"o5: {b.HyperlinqCombined()}");

BenchmarkRunner.Run<PWBenchmark>();