# Iteration Ref Parameters Vs Returns

`IEnumerable<T>` does not allow for modification during iteration. But if you want to support
that functionality on custom generic data structures, is it faster to modify and return the
value (example: using `Func<T, T>`), or is it faster to use `ref` parameters? That is the goal
of this benchmark.

Conclusion from results below:
Using `ref` parameters are simply less efficient for passing `int`s.

``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19041.985 (2004/May2020Update/20H1)
Intel Core i5-8400 CPU 2.80GHz (Coffee Lake), 1 CPU, 6 logical and 6 physical cores
.NET SDK=5.0.301
  [Host]     : .NET 5.0.7 (5.0.721.25508), X64 RyuJIT
  Job-YFVYXE : .NET 5.0.7 (5.0.721.25508), X64 RyuJIT

InvocationCount=1  UnrollFactor=1

```
|                  Method |      N |          Mean |        Error |       StdDev |       Median |
|------------------------ |------- |--------------:|-------------:|-------------:|-------------:|
|                 **Control** |     **10** |      **75.26 ns** |    **17.959 ns** |    **52.104 ns** |     **100.0 ns** |
|          DelegateReturn |     10 |     188.10 ns |    12.127 ns |    32.579 ns |     200.0 ns |
|        DelegateRefParam |     10 |     242.05 ns |    21.827 ns |    60.118 ns |     200.0 ns |
|     StructGenericReturn |     10 |      84.62 ns |    14.068 ns |    36.314 ns |     100.0 ns |
|   StructGenericRefParam |     10 |     100.00 ns |     0.000 ns |     0.000 ns |     100.0 ns |
|         FunctionPointer |     10 |     100.00 ns |     0.000 ns |     0.000 ns |     100.0 ns |
| FunctionPointerRefParam |     10 |     137.37 ns |    17.281 ns |    50.681 ns |     100.0 ns |
|                 **Control** |    **100** |     **142.86 ns** |    **20.296 ns** |    **59.204 ns** |     **100.0 ns** |
|          DelegateReturn |    100 |     373.33 ns |    15.953 ns |    44.469 ns |     400.0 ns |
|        DelegateRefParam |    100 |     396.77 ns |    11.761 ns |    17.961 ns |     400.0 ns |
|     StructGenericReturn |    100 |     139.58 ns |    17.765 ns |    51.256 ns |     100.0 ns |
|   StructGenericRefParam |    100 |     173.00 ns |    18.579 ns |    54.781 ns |     200.0 ns |
|         FunctionPointer |    100 |     296.00 ns |     9.799 ns |    19.795 ns |     300.0 ns |
| FunctionPointerRefParam |    100 |     292.21 ns |    10.525 ns |    26.981 ns |     300.0 ns |
|                 **Control** |   **1000** |     **714.61 ns** |    **25.835 ns** |    **71.590 ns** |     **700.0 ns** |
|          DelegateReturn |   1000 |   2,111.76 ns |    45.134 ns |    72.883 ns |   2,100.0 ns |
|        DelegateRefParam |   1000 |   2,151.72 ns |    39.194 ns |    57.450 ns |   2,100.0 ns |
|     StructGenericReturn |   1000 |     630.00 ns |    18.197 ns |    50.725 ns |     600.0 ns |
|   StructGenericRefParam |   1000 |     670.73 ns |    18.252 ns |    48.401 ns |     700.0 ns |
|         FunctionPointer |   1000 |   1,968.42 ns |    42.966 ns |    47.757 ns |   2,000.0 ns |
| FunctionPointerRefParam |   1000 |   1,992.31 ns |    36.682 ns |    94.689 ns |   1,950.0 ns |
|                 **Control** |  **10000** |   **6,061.54 ns** |    **60.640 ns** |    **50.637 ns** |   **6,100.0 ns** |
|          DelegateReturn |  10000 |  19,041.67 ns |    85.632 ns |    66.856 ns |  19,000.0 ns |
|        DelegateRefParam |  10000 |  19,642.86 ns |   186.226 ns |   165.084 ns |  19,600.0 ns |
|     StructGenericReturn |  10000 |   5,473.91 ns |   109.817 ns |   138.883 ns |   5,400.0 ns |
|   StructGenericRefParam |  10000 |   6,507.69 ns |   103.266 ns |    86.232 ns |   6,500.0 ns |
|         FunctionPointer |  10000 |  18,769.23 ns |    57.528 ns |    48.038 ns |  18,800.0 ns |
| FunctionPointerRefParam |  10000 |  18,830.77 ns |   157.547 ns |   131.559 ns |  18,800.0 ns |
|                 **Control** | **100000** |  **60,658.82 ns** |   **850.069 ns** | **1,372.703 ns** |  **60,150.0 ns** |
|          DelegateReturn | 100000 | 191,573.33 ns | 3,422.537 ns | 3,201.443 ns | 191,000.0 ns |
|        DelegateRefParam | 100000 | 195,771.43 ns | 2,473.219 ns | 2,192.445 ns | 194,500.0 ns |
|     StructGenericReturn | 100000 |  53,325.00 ns | 1,007.244 ns |   786.390 ns |  53,000.0 ns |
|   StructGenericRefParam | 100000 |  63,509.52 ns | 1,174.654 ns | 2,147.921 ns |  63,500.0 ns |
|         FunctionPointer | 100000 | 186,592.31 ns | 1,296.685 ns | 1,082.791 ns | 186,100.0 ns |
| FunctionPointerRefParam | 100000 | 187,740.00 ns | 1,850.697 ns | 1,731.143 ns | 186,900.0 ns |
