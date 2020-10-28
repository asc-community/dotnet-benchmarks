# Type Equality Checking

This benchmark compares some patterns for comparing types. Using `typeof(A) == typeof(B)` is best
when `A` and `B` are non-generic, but if they are generic, there is overhead to that equality that
may be optimized.

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1139 (1909/November2018Update/19H2)
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.100-rc.2.20479.15
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.47505, CoreFX 5.0.20.47505), X64 RyuJIT
  DefaultJob : .NET Core 5.0.0 (CoreCLR 5.0.20.47505, CoreFX 5.0.20.47505), X64 RyuJIT


```

|                     Method |      Mean |     Error |    StdDev |
|--------------------------- |----------:|----------:|----------:|
|               TypeOfEquals |  2.498 ns | 0.0904 ns | 0.1630 ns |
|        TypeOfEqualsGeneric | 22.482 ns | 0.4369 ns | 0.4086 ns |
| TypeOfEqualsGenericInlined |  2.537 ns | 0.0883 ns | 0.0826 ns |
|            StructWrappedIs | 38.606 ns | 0.7684 ns | 0.8540 ns |
|         CachedTypeEquality |  2.466 ns | 0.0874 ns | 0.1577 ns |
