# String Formatting Techniques

This benchmark it to help determine the most appropriate pattern for creating formatted strings:
- `string.Format`
- `string` interpolation
- `string` addition operator `+`
- `StringBuilder`
- `string` add equals operator `+=`
- `string.Concat`

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1016 (1909/November2018Update/19H2)
Intel Core i7-4790K CPU 4.00GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.100-preview.8.20417.9
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.40711, CoreFX 5.0.20.40711), X64 RyuJIT
  DefaultJob : .NET Core 5.0.0 (CoreCLR 5.0.20.40711, CoreFX 5.0.20.40711), X64 RyuJIT


```
|               Method |             Mean |          Error |         StdDev |
|--------------------- |-----------------:|---------------:|---------------:|
|         AddOperator1 |        22.936 ns |      0.0810 ns |      0.0757 ns |
|              Format1 |        54.764 ns |      0.2573 ns |      0.2281 ns |
|       Interpolation1 |        54.731 ns |      0.2984 ns |      0.2791 ns |
|       StringBuilder1 |        30.234 ns |      0.0941 ns |      0.0835 ns |
|        StringConcat1 |        29.510 ns |      0.1511 ns |      0.1339 ns |
|    AddEqualOperator1 |         6.472 ns |      0.0292 ns |      0.0259 ns |
|         AddOperator2 |        57.093 ns |      0.2869 ns |      0.2684 ns |
|              Format2 |        78.482 ns |      0.5314 ns |      0.4710 ns |
|       Interpolation2 |        80.777 ns |      1.5722 ns |      1.6822 ns |
|       StringBuilder2 |        44.757 ns |      0.1973 ns |      0.1845 ns |
|        StringConcat2 |        85.012 ns |      0.5368 ns |      0.4482 ns |
|    AddEqualOperator2 |        41.773 ns |      0.2032 ns |      0.1901 ns |
|         AddOperator3 |        75.102 ns |      0.3256 ns |      0.3046 ns |
|              Format3 |       105.266 ns |      0.4089 ns |      0.3825 ns |
|       Interpolation3 |       105.412 ns |      0.5524 ns |      0.4313 ns |
|       StringBuilder3 |        54.801 ns |      0.1994 ns |      0.1665 ns |
|        StringConcat3 |       117.253 ns |      0.4922 ns |      0.4363 ns |
|    AddEqualOperator3 |        76.963 ns |      1.5714 ns |      2.3521 ns |
|         AddOperator4 |        98.671 ns |      1.5725 ns |      1.3940 ns |
|              Format4 |       168.388 ns |      2.7069 ns |      2.5320 ns |
|       Interpolation4 |       166.350 ns |      0.5034 ns |      0.3930 ns |
|       StringBuilder4 |        69.490 ns |      1.0857 ns |      1.0155 ns |
|        StringConcat4 |       150.042 ns |      1.2438 ns |      1.1026 ns |
|    AddEqualOperator4 |       113.962 ns |      1.2124 ns |      1.0748 ns |
|         AddOperator5 |       129.662 ns |      1.6293 ns |      1.5241 ns |
|              Format5 |       199.057 ns |      3.5246 ns |      3.2969 ns |
|       Interpolation5 |       197.629 ns |      1.8404 ns |      1.7215 ns |
|       StringBuilder5 |        84.966 ns |      1.0275 ns |      0.9611 ns |
|        StringConcat5 |       196.839 ns |      0.8423 ns |      0.6576 ns |
|    AddEqualOperator5 |       147.956 ns |      0.8973 ns |      0.8393 ns |
|        AddOperator10 |       237.780 ns |      1.1644 ns |      1.0322 ns |
|             Format10 |       359.197 ns |      1.0668 ns |      0.8329 ns |
|      Interpolation10 |       362.663 ns |      1.4516 ns |      1.3578 ns |
|      StringBuilder10 |       202.503 ns |      1.3022 ns |      1.0167 ns |
|       StringConcat10 |       358.128 ns |      3.5933 ns |      3.1854 ns |
|   AddEqualOperator10 |       343.394 ns |      1.5348 ns |      1.3606 ns |
|       AddOperator100 |     2,915.839 ns |     44.0534 ns |     41.2076 ns |
|            Format100 |     3,478.252 ns |     14.5496 ns |     12.1495 ns |
|     Interpolation100 |     3,430.917 ns |     46.3178 ns |     43.3257 ns |
|     StringBuilder100 |     1,801.297 ns |      5.5425 ns |      4.9133 ns |
|      StringConcat100 |     4,019.209 ns |     51.3871 ns |     48.0675 ns |
|  AddEqualOperator100 |     8,783.083 ns |     94.8101 ns |     79.1707 ns |
|      AddOperator1000 |    40,973.943 ns |    238.3025 ns |    222.9083 ns |
|           Format1000 |    41,055.947 ns |    472.2821 ns |    441.7729 ns |
|    Interpolation1000 |    41,389.303 ns |    633.4845 ns |    592.5618 ns |
|    StringBuilder1000 |    20,599.310 ns |    206.1106 ns |    172.1117 ns |
|     StringConcat1000 |    52,959.182 ns |    401.8360 ns |    335.5513 ns |
| AddEqualOperator1000 | 1,273,860.226 ns | 14,541.0831 ns | 12,890.2914 ns |
