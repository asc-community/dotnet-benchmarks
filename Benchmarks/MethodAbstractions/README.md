# Method Abstractions

There are numerous ways to abstract methods in C# to make them more reusable. This benchmark
puts several patterns of abstraction to the test to see help you determine what abstraction
pattern you should use in your code.

### AdditionBenchmarks

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1016 (1909/November2018Update/19H2)
Intel Core i7-4790K CPU 4.00GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  DefaultJob : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT


```
|                                 Method |       Mean |     Error |    StdDev |
|--------------------------------------- |-----------:|----------:|----------:|
|                             IntegerAdd |  0.7552 ns | 0.0195 ns | 0.0182 ns |
| IntegerAddStructWithAggressiveInlining |  0.9201 ns | 0.0086 ns | 0.0072 ns |
|   IntegerAddLinqWithAggressiveInlining | 10.1687 ns | 0.1508 ns | 0.1337 ns |
|                       IntegerAddStruct |  6.2190 ns | 0.1140 ns | 0.1066 ns |
|                         IntegerAddLinq |  9.9643 ns | 0.1672 ns | 0.1564 ns |

### EnumerableBenchmarks

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1016 (1909/November2018Update/19H2)
Intel Core i7-4790K CPU 4.00GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  DefaultJob : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT


```
|                                         Method |      Mean |     Error |    StdDev |
|----------------------------------------------- |----------:|----------:|----------:|
|                                        Control |  7.544 ns | 0.1754 ns | 0.2088 ns |
|                                LinqWhereLambda | 73.708 ns | 1.2615 ns | 1.2390 ns |
|                                      LinqWhere | 85.193 ns | 0.5620 ns | 0.4693 ns |
|                              CustomWhereLambda | 82.561 ns | 1.2625 ns | 1.0542 ns |
|                                    CustomWhere | 92.224 ns | 1.8695 ns | 2.1529 ns |
|                             GenericStructWhere | 64.016 ns | 0.9528 ns | 0.7438 ns |
|                       GenericStructWhereAction | 11.295 ns | 0.1643 ns | 0.1537 ns |
|              CustomWhereWithAggressiveInlining | 96.397 ns | 1.5992 ns | 1.4959 ns |
|       GenericStructWhereWithAggressiveInlining | 61.405 ns | 0.9640 ns | 1.0315 ns |
| GenericStructWhereActionWithAggressiveInlining | 11.479 ns | 0.2485 ns | 0.2862 ns |
