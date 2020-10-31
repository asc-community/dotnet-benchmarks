# Type Equality Checking

This benchmark compares some patterns for comparing types for equality.

Currently, the JIT is not optimizing the generic methods in these
benchmarks without the `[MethodImpl(MethodImplOptions.AggressiveInlining)]`
attribute, but with the attribute they are optimized.

Although the cached version achieves similar performance as the inlined
methods without the need of `[MethodImpl(MethodImplOptions.AggressiveInlining)]`
it has memory overhead that the others do not.

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1139 (1909/November2018Update/19H2)
Intel Core i7-4790K CPU 4.00GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.100-rc.2.20479.15
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.47505, CoreFX 5.0.20.47505), X64 RyuJIT
  DefaultJob : .NET Core 5.0.0 (CoreCLR 5.0.20.47505, CoreFX 5.0.20.47505), X64 RyuJIT


```
|                      Method |      Mean |     Error |    StdDev |
|---------------------------- |----------:|----------:|----------:|
|                TypeOfEquals |  1.816 ns | 0.0550 ns | 0.0487 ns |
|         TypeOfEqualsGeneric | 16.369 ns | 0.1464 ns | 0.1222 ns |
|  TypeOfEqualsGenericInlined |  1.920 ns | 0.0667 ns | 0.1114 ns |
|             StructWrappedIs | 16.188 ns | 0.1151 ns | 0.0961 ns |
|      StructWrappedIsInlined |  1.954 ns | 0.0520 ns | 0.0461 ns |
|        GetTypeEqualsGeneric | 36.403 ns | 0.5152 ns | 0.4820 ns |
| GetTypeEqualsGenericInlined | 16.548 ns | 0.2444 ns | 0.2286 ns |
|          CachedTypeEquality |  1.936 ns | 0.0208 ns | 0.0185 ns |
