# Indexed Collection Abstractions

The `IList<T>` type in C# allows you to abstract indexed types like `List<T>` and `T[]` so that you can code against one type, `IList<T>` and support multiple types. However there is a cost to this abstraction. This benchmark is to help you determine if you should rely on `IList<T>` or if you shoudl include explicit versions for `T[]` as well.

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1016 (1909/November2018Update/19H2)
Intel Core i7-4790K CPU 4.00GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  DefaultJob : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT


```
|     Method | Size |         Mean |      Error |     StdDev |
|----------- |----- |-------------:|-----------:|-----------:|
|      **Array** |   **10** |     **3.003 ns** |  **0.0298 ns** |  **0.0264 ns** |
|       List |   10 |     5.077 ns |  0.1159 ns |  0.0968 ns |
| IListArray |   10 |    25.452 ns |  0.4401 ns |  0.4117 ns |
|  IListList |   10 |    20.818 ns |  0.4045 ns |  0.3784 ns |
|      **Array** |  **100** |    **36.439 ns** |  **0.3145 ns** |  **0.2788 ns** |
|       List |  100 |    49.675 ns |  0.4670 ns |  0.4140 ns |
| IListArray |  100 |   260.702 ns |  4.3079 ns |  4.0296 ns |
|  IListList |  100 |   207.413 ns |  2.0283 ns |  1.8973 ns |
|      **Array** | **1000** |   **261.166 ns** |  **2.5422 ns** |  **2.2536 ns** |
|       List | 1000 |   415.206 ns |  3.1724 ns |  2.6491 ns |
| IListArray | 1000 | 2,534.601 ns | 26.5846 ns | 23.5665 ns |
|  IListList | 1000 | 2,003.540 ns | 14.7835 ns | 13.8285 ns |
