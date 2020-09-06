# String Formatting Techniques

This benchmark it to help determine the most appropriate pattern for creating formatted strings:
- `string.Format`
- `string` interpolation
- `string` addition operator `+`
- `StringBuilder`
- `string` add equals operator `+=`

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1016 (1909/November2018Update/19H2)
Intel Core i7-4790K CPU 4.00GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.100-preview.8.20417.9
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.40711, CoreFX 5.0.20.40711), X64 RyuJIT
  DefaultJob : .NET Core 5.0.0 (CoreCLR 5.0.20.40711, CoreFX 5.0.20.40711), X64 RyuJIT


```
|               Method |             Mean |          Error |         StdDev |
|--------------------- |-----------------:|---------------:|---------------:|
|         AddOperator1 |        22.961 ns |      0.3090 ns |      0.2739 ns |
|              Format1 |        55.118 ns |      0.3584 ns |      0.3177 ns |
|       Interpolation1 |        55.272 ns |      0.6065 ns |      0.5674 ns |
|       StringBuilder1 |        30.872 ns |      0.1677 ns |      0.1568 ns |
|    AddEqualOperator1 |         6.498 ns |      0.0270 ns |      0.0239 ns |
|         AddOperator2 |        56.347 ns |      0.8599 ns |      0.8043 ns |
|              Format2 |        79.243 ns |      0.3093 ns |      0.2893 ns |
|       Interpolation2 |        81.008 ns |      1.0415 ns |      0.9232 ns |
|       StringBuilder2 |        44.355 ns |      0.8961 ns |      0.9960 ns |
|    AddEqualOperator2 |        42.667 ns |      0.4390 ns |      0.4107 ns |
|         AddOperator3 |        75.785 ns |      0.4617 ns |      0.3605 ns |
|              Format3 |       106.975 ns |      0.5524 ns |      0.5167 ns |
|       Interpolation3 |       107.281 ns |      0.3851 ns |      0.3414 ns |
|       StringBuilder3 |        57.998 ns |      0.7790 ns |      0.6906 ns |
|    AddEqualOperator3 |        76.572 ns |      0.5050 ns |      0.4477 ns |
|         AddOperator4 |        97.348 ns |      0.9971 ns |      0.9327 ns |
|              Format4 |       165.042 ns |      1.5476 ns |      1.4476 ns |
|       Interpolation4 |       166.676 ns |      2.3155 ns |      2.1659 ns |
|       StringBuilder4 |        68.374 ns |      0.3730 ns |      0.3489 ns |
|    AddEqualOperator4 |       113.818 ns |      1.9551 ns |      1.5264 ns |
|         AddOperator5 |       131.207 ns |      2.2805 ns |      2.0216 ns |
|              Format5 |       199.479 ns |      3.9837 ns |      6.6558 ns |
|       Interpolation5 |       196.637 ns |      3.9564 ns |      8.7671 ns |
|       StringBuilder5 |        85.043 ns |      0.8415 ns |      0.7459 ns |
|    AddEqualOperator5 |       152.302 ns |      2.7093 ns |      2.4017 ns |
|        AddOperator10 |       244.037 ns |      4.8842 ns |      6.8470 ns |
|             Format10 |       359.045 ns |      6.5015 ns |      8.8993 ns |
|      Interpolation10 |       355.757 ns |      4.7031 ns |      4.3993 ns |
|      StringBuilder10 |       193.610 ns |      0.7254 ns |      0.6057 ns |
|   AddEqualOperator10 |       338.843 ns |      2.0532 ns |      1.8201 ns |
|       AddOperator100 |     2,838.257 ns |     50.7540 ns |     58.4483 ns |
|            Format100 |     3,335.966 ns |     12.6428 ns |     10.5573 ns |
|     Interpolation100 |     3,333.107 ns |     22.5725 ns |     20.0099 ns |
|     StringBuilder100 |     1,761.460 ns |     31.1816 ns |     33.3640 ns |
|  AddEqualOperator100 |     8,614.066 ns |    170.7518 ns |    175.3496 ns |
|      AddOperator1000 |    40,346.405 ns |    797.8959 ns |  1,265.5475 ns |
|           Format1000 |    38,812.243 ns |    141.7401 ns |    125.6489 ns |
|    Interpolation1000 |    38,626.021 ns |    163.6661 ns |    145.0857 ns |
|    StringBuilder1000 |    20,031.543 ns |     84.5701 ns |     74.9692 ns |
| AddEqualOperator1000 | 1,160,990.195 ns | 17,763.3426 ns | 16,615.8417 ns |
