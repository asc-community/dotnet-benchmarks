# Reflection Techniques

This benchmark compares some patterns for using reflection.

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1016 (1909/November2018Update/19H2)
Intel Core i7-4790K CPU 4.00GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.100-preview.8.20417.9
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.40711, CoreFX 5.0.20.40711), X64 RyuJIT
  DefaultJob : .NET Core 5.0.0 (CoreCLR 5.0.20.40711, CoreFX 5.0.20.40711), X64 RyuJIT


```
|                                 Method |       Mean |     Error |    StdDev |
|--------------------------------------- |-----------:|----------:|----------:|
|                            FieldDirect |  0.4253 ns | 0.0328 ns | 0.0307 ns |
|                        FieldReflection | 89.7686 ns | 0.5237 ns | 0.4373 ns |
|                  FieldReflectionCached |  2.5252 ns | 0.0303 ns | 0.0283 ns |
|   FieldReflectionCachedLookUpKnownType | 19.8763 ns | 0.1196 ns | 0.1060 ns |
| FieldReflectionCachedLookUpUnknownType | 52.8681 ns | 0.8062 ns | 0.7147 ns |
