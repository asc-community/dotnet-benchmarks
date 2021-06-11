# Iteration Ref Parameters Vs Returns

`IEnumerable<T>` does not allow for modification during iteration. But if you want to support
that functionality on custom generic data structures, is it faster to modify and return the
value (example: using `Func<T, T>`), or is it faster to use `ref` parameters? That is the goal
of this benchmark.

Conclusion from results below:
The results below show that if you use struct generic parameters, then simply returning the updated
value is currently more efficient. If you use delegates, then using `ref` parameters are currently slightly
more efficient.

``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19042.1052 (20H2/October2020Update)
Intel Core i7-4790K CPU 4.00GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.100-preview.4.21255.9
  [Host]     : .NET 5.0.7 (5.0.721.25508), X64 RyuJIT
  Job-BIQPHE : .NET 5.0.7 (5.0.721.25508), X64 RyuJIT

InvocationCount=1  UnrollFactor=1  

```
|                Method |     N |           Mean |       Error |      StdDev |         Median |
|---------------------- |------ |---------------:|------------:|------------:|---------------:|
|               **Control** |    **10** |      **0.0000 ns** |   **0.0000 ns** |   **0.0000 ns** |      **0.0000 ns** |
|        DelegateReturn |    10 |    153.0000 ns |  18.9508 ns |  55.8768 ns |    150.0000 ns |
|      DelegateRefParam |    10 |    145.0000 ns |  17.6295 ns |  51.9810 ns |    100.0000 ns |
|   StructGenericReturn |    10 |    100.0000 ns |   0.0000 ns |   0.0000 ns |    100.0000 ns |
| StructGenericRefParam |    10 |    100.0000 ns |   0.0000 ns |   0.0000 ns |    100.0000 ns |
|               **Control** |   **100** |    **100.0000 ns** |   **0.0000 ns** |   **0.0000 ns** |    **100.0000 ns** |
|        DelegateReturn |   100 |    343.2990 ns |  17.8740 ns |  51.8556 ns |    300.0000 ns |
|      DelegateRefParam |   100 |    333.3333 ns |  18.8652 ns |  55.3283 ns |    300.0000 ns |
|   StructGenericReturn |   100 |    138.0000 ns |  16.5450 ns |  48.7832 ns |    100.0000 ns |
| StructGenericRefParam |   100 |    156.5657 ns |  18.3304 ns |  53.7599 ns |    200.0000 ns |
|               **Control** |  **1000** |    **655.2083 ns** |  **20.0336 ns** |  **57.8015 ns** |    **700.0000 ns** |
|        DelegateReturn |  1000 |  2,284.6154 ns |  44.9717 ns |  37.5534 ns |  2,300.0000 ns |
|      DelegateRefParam |  1000 |  2,050.0000 ns |  42.0726 ns |  62.9724 ns |  2,000.0000 ns |
|   StructGenericReturn |  1000 |    560.6383 ns |  22.5330 ns |  64.2878 ns |    600.0000 ns |
| StructGenericRefParam |  1000 |    555.3191 ns |  20.3124 ns |  57.9526 ns |    600.0000 ns |
|               **Control** | **10000** |  **5,990.0000 ns** | **121.2411 ns** | **317.2668 ns** |  **5,800.0000 ns** |
|        DelegateReturn | 10000 | 21,191.6667 ns | 176.6228 ns | 137.8954 ns | 21,200.0000 ns |
|      DelegateRefParam | 10000 | 19,425.0000 ns | 145.7833 ns | 113.8180 ns | 19,400.0000 ns |
|   StructGenericReturn | 10000 |  4,862.6374 ns | 101.5164 ns | 284.6629 ns |  5,000.0000 ns |
| StructGenericRefParam | 10000 |  5,478.5714 ns |  78.8848 ns |  69.9293 ns |  5,500.0000 ns |
