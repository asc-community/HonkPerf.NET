# HonkPerf.NET

[![](https://img.shields.io/nuget/vpre/HonkPerf.NET?label=NuGet&logo=nuget)](https://www.nuget.org/packages/HonkPerf.NET/)

Collection of performant (but limited in usage) replacements for BCL's types and methods;

## RefLinq

### Summary

RefLinq is like Linq, but it must be only used within a method, so behaves more limited than `ref` structs. Its benefit - it does not make allocations for enumerators and captured variables (given that you use it properly). Its API does not differ *much* from that of Linq.

So, basically given that you have some sequence, you do `.ToRefLinq()` on it, and the rest of API is the same. All API which does not make heap allocations is available.

Example:

```cs
var arr = new [] { 1, 2, 3, 4 };

...

var localVar = 5;
var seq =
    arr
    .ToRefLinq()                // magic method
    .Select(c => c + 5)
    .Where(c => c % 2 == 0)
    .Select((c, localVar) => c - 6.0 / localVar, localVar) // capture-less capture
    .Append(3)                  // alloc-less append
    .Append(5)
    .Prepend(3)
    .Concat(arr.ToRefLinq().Select(c => c / 1d))  // concatenation
    ;
return seq.Sum() + seq.Max();
```

In the example above, no heap allocation happens aside from the one to allocate `arr` in the first line. Though even that may be optimized if you make stack allocation (and use HonkPerf.NET's `FixedReadOnlySpan<T>`), but that's on your side.

### Benchmarks

That's yet another linq library. Why use it? Here's a few benchmarks.

We mark bold the one doing the **least allocations** and italic the *fastest* one.

#### Select & Where

|              Method |       Mean |    Error |   StdDev |     Median | Code Size |  Gen 0 | Allocated |
|-------------------- |-----------:|---------:|---------:|-----------:|----------:|-------:|----------:|
| **RefLinqCombined** |   782.3 ns |  9.78 ns |  9.15 ns |   782.0 ns |   1,246 B |      - |         - |
| ClassicLinqCombined | 1,337.9 ns | 26.57 ns | 72.73 ns | 1,318.1 ns |   2,112 B | 0.0801 |     256 B |
|     NoAlloqCombined | 1,370.4 ns | 27.32 ns | 46.39 ns | 1,364.9 ns |   2,114 B | 0.0267 |      88 B |
|  LinqFasterCombined |   789.3 ns | 15.74 ns | 34.54 ns |   793.1 ns |   1,971 B | 0.4253 |   1,336 B |
|   HyperlinqCombined |   701.8 ns | 13.51 ns | 16.60 ns |   696.8 ns |   1,506 B | 0.0277 |      88 B |
|   ValueLinqCombined |   795.3 ns | 15.84 ns | 37.03 ns |   782.2 ns |   1,364 B | 0.0172 |      56 B |
|    *LinqAFCombined* |   656.9 ns | 13.01 ns | 23.13 ns |   650.3 ns |   1,807 B | 0.0277 |      88 B |
|  StructLinqCombined |   752.9 ns | 14.93 ns | 18.88 ns |   751.4 ns |     933 B | 0.0582 |     184 B |


#### Append & Prepend

|             Method |      Mean |    Error |    StdDev |  Gen 0 | Allocated |
|------------------- |----------:|---------:|----------:|-------:|----------:|
| ***RefLinqBench*** |  96.51 ns | 1.968 ns |  3.931 ns |      - |         - |
|          LinqBench | 248.80 ns | 4.945 ns | 11.263 ns | 0.1938 |     608 B |
|     HyperLinqBench | 293.72 ns | 6.392 ns | 18.746 ns | 0.2165 |     680 B |
|        LinqAFBench | 253.92 ns | 5.094 ns | 13.509 ns |      - |         - |


#### Select, Where, Zip, Sum

|         Method |     Mean |     Error |    StdDev |   Median | Code Size |  Gen 0 | Allocated |
|--------------- |---------:|----------:|----------:|---------:|----------:|-------:|----------:|
| **RefLinqSum** | 1.870 us | 0.0344 us | 0.0409 us | 1.863 us |   2,714 B |      - |         - |
| ClassicLinqSum | 2.724 us | 0.0562 us | 0.1640 us | 2.679 us |   3,436 B | 0.1831 |     584 B |
|   HyperLinqSum | 2.446 us | 0.0466 us | 0.0816 us | 2.431 us |   2,780 B | 0.1755 |     560 B |
| *ValueLinqSum* | 1.574 us | 0.0311 us | 0.0553 us | 1.582 us |   3,545 B | 0.0401 |     128 B |
|      LinqAFSum | 2.268 us | 0.0453 us | 0.1201 us | 2.250 us |   4,228 B | 0.0458 |     152 B |


#### Select, Where, Append, Prepend, Concat, Sum, Max

|                Method |     Mean |     Error |    StdDev | Code Size |  Gen 0 | Allocated |
|---------------------- |---------:|----------:|----------:|----------:|-------:|----------:|
| ***RefLinqCombined*** | 4.193 us | 0.0835 us | 0.2125 us |   2,679 B |      - |         - |
|   ClassicLinqCombined | 8.053 us | 0.1582 us | 0.2971 us |   3,173 B | 0.3204 |   1,032 B |
|     HyperlinqCombined | 7.555 us | 0.1397 us | 0.2410 us |   2,491 B | 0.2975 |     944 B |
|     ValueLinqCombined | 5.142 us | 0.1021 us | 0.1967 us |   3,903 B | 0.2823 |     888 B |
|        LinqAFCombined | 5.938 us | 0.1128 us | 0.1299 us |   5,431 B | 0.0381 |     120 B |

#### Conclusion

There's no "best" linq library. RefLinq is great at avoiding allocations, but sometimes there are
faster alternatives (see benchmarks). It provides good API to avoid allocations on captures:
you provide the captured function as a last argument, and accept it in the delegate. It also
allows to create value delegates identically to how it's done in other libraries. However,
it does not offer hundreds of overloads for different use cases to save a few nanoseconds.

Also, the mentioned libraries have different APIs and different coverage of LINQ methods.
Some of them don't require the "magic" method, but they may conflict with LINQ then.
Some of them lack methods like `Append` and `Prepend`, others don't have `Zip`, etc. RefLinq
is not an exception, and it does not have APIs which would require heap allocation.
