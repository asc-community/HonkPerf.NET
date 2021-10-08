// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using Benchmarks;

Console.WriteLine("Hello, World!");
BenchmarkRunner.Run<RefLinqBenchmark>();