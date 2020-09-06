# Exception Handling Techniques

This benchmark compares the performance of `try`+`catch` blocks vs versus try method patterns such as `int.TryParse`.

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1016 (1909/November2018Update/19H2)
Intel Core i7-4790K CPU 4.00GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.100-preview.8.20417.9
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.40711, CoreFX 5.0.20.40711), X64 RyuJIT
  DefaultJob : .NET Core 5.0.0 (CoreCLR 5.0.20.40711, CoreFX 5.0.20.40711), X64 RyuJIT


```
|               Method |          Mean |      Error |     StdDev |
|--------------------- |--------------:|-----------:|-----------:|
|     TryMethodPattern |      1.528 ns |  0.0459 ns |  0.0406 ns |
|             TryCatch | 16,020.844 ns | 78.5419 ns | 65.5861 ns |
|       Int32_TryParse |     11.376 ns |  0.1443 ns |  0.1349 ns |
| Int32_Parse_TryCatch | 19,084.244 ns | 81.3079 ns | 67.8958 ns |
