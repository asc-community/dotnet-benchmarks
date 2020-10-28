# Type Equality Checking

This benchmark compares some patterns for comparing types. Using `typeof(A) == typeof(B)` is best
when `A` and `B` are non-generic, but if they are generic, there is overhead to that equality that
may be optimized.

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1139 (1909/November2018Update/19H2)
Intel Core i7-4790K CPU 4.00GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.100-rc.2.20479.15
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.47505, CoreFX 5.0.20.47505), X64 RyuJIT
  DefaultJob : .NET Core 5.0.0 (CoreCLR 5.0.20.47505, CoreFX 5.0.20.47505), X64 RyuJIT


```
|              Method |      Mean |     Error |    StdDev |
|-------------------- |----------:|----------:|----------:|
|        TypeOfEquals |  1.824 ns | 0.0530 ns | 0.0469 ns |
| TypeOfEqualsGeneric | 16.163 ns | 0.0788 ns | 0.0699 ns |
|     StructWrappedIs | 29.837 ns | 0.2309 ns | 0.1803 ns |
|  CachedTypeEquality |  2.068 ns | 0.0365 ns | 0.0341 ns |
