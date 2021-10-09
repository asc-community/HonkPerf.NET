// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using Benchmarks;

var b = new RefLinqBenchmark();

Console.WriteLine($"Output classic: {b.ClassicLinqCombined()}");
Console.WriteLine($"Output reflinq: {b.RefLinqCombined()}");

BenchmarkRunner.Run<RefLinqBenchmark>();