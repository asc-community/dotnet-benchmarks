# String Formatting Techniques

This benchmark it to help determine the most appropriate pattern for creating formatted strings:
- `string.Format`
- `string` interpolation
- `string` addition operator `+`

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1016 (1909/November2018Update/19H2)
Intel Core i7-4790K CPU 4.00GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  DefaultJob : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT


```
|         Method |      Mean |    Error |   StdDev |    Median |
|--------------- |----------:|---------:|---------:|----------:|
|   AddOperator1 |  22.47 ns | 0.477 ns | 0.549 ns |  22.50 ns |
|        Format1 |  55.09 ns | 1.108 ns | 1.186 ns |  54.80 ns |
| Interpolation1 |  51.80 ns | 0.297 ns | 0.263 ns |  51.70 ns |
|   AddOperator2 |  51.61 ns | 0.549 ns | 0.458 ns |  51.58 ns |
|        Format2 |  82.08 ns | 1.604 ns | 1.500 ns |  81.55 ns |
| Interpolation2 |  80.48 ns | 0.962 ns | 0.803 ns |  80.62 ns |
|   AddOperator3 |  72.92 ns | 0.326 ns | 0.305 ns |  72.83 ns |
|        Format3 | 102.63 ns | 0.641 ns | 0.569 ns | 102.56 ns |
| Interpolation3 | 103.93 ns | 0.487 ns | 0.456 ns | 104.04 ns |
|   AddOperator4 |  90.72 ns | 0.961 ns | 0.803 ns |  90.70 ns |
|        Format4 | 156.92 ns | 3.169 ns | 5.794 ns | 155.42 ns |
| Interpolation4 | 155.94 ns | 3.051 ns | 3.513 ns | 155.97 ns |
|   AddOperator5 | 120.18 ns | 1.295 ns | 1.148 ns | 120.19 ns |
|        Format5 | 184.96 ns | 1.147 ns | 1.017 ns | 185.19 ns |
| Interpolation5 | 181.42 ns | 3.563 ns | 5.333 ns | 178.65 ns |
|   AddOperator6 | 130.15 ns | 0.965 ns | 0.855 ns | 130.05 ns |
|        Format6 | 215.98 ns | 1.737 ns | 1.624 ns | 215.48 ns |
| Interpolation6 | 216.15 ns | 1.146 ns | 1.016 ns | 216.13 ns |
|   AddOperator7 | 157.13 ns | 3.156 ns | 5.772 ns | 155.55 ns |
|        Format7 | 253.43 ns | 5.017 ns | 8.383 ns | 250.89 ns |
| Interpolation7 | 263.71 ns | 5.090 ns | 6.250 ns | 265.21 ns |
