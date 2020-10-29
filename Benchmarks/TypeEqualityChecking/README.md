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
|               TypeOfEquals |  2.541 ns | 0.0924 ns | 0.1027 ns |
|        TypeOfEqualsGeneric | 23.888 ns | 0.2411 ns | 0.2137 ns |
| TypeOfEqualsGenericInlined |  2.729 ns | 0.0874 ns | 0.1106 ns |
|            StructWrappedIs | 41.723 ns | 0.7184 ns | 0.6369 ns |
|     StructWrappedIsInlined |  2.705 ns | 0.0927 ns | 0.1300 ns |
|         CachedTypeEquality |  2.860 ns | 0.0937 ns | 0.1642 ns |
