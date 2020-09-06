# Branching Techniques

This benchmark compares various types of branching that is possible inside of C#: switch statements,
switch expressions, and if statements.

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1016 (1909/November2018Update/19H2)
Intel Core i7-4790K CPU 4.00GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.100-preview.8.20417.9
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.40711, CoreFX 5.0.20.40711), X64 RyuJIT
  DefaultJob : .NET Core 5.0.0 (CoreCLR 5.0.20.40711, CoreFX 5.0.20.40711), X64 RyuJIT


```
|              Method |          Mean |      Error |     StdDev |        Median |
|-------------------- |--------------:|-----------:|-----------:|--------------:|
|    switchStatement1 |     0.2125 ns |  0.0064 ns |  0.0060 ns |     0.2128 ns |
|   switchExpression1 |     0.4244 ns |  0.0344 ns |  0.0321 ns |     0.4218 ns |
|                 if1 |     0.0984 ns |  0.0046 ns |  0.0043 ns |     0.0974 ns |
|        conditional1 |     0.2130 ns |  0.0048 ns |  0.0045 ns |     0.2131 ns |
|    switchStatement2 |     1.9207 ns |  0.0045 ns |  0.0040 ns |     1.9217 ns |
|   switchExpression2 |     1.3847 ns |  0.0173 ns |  0.0153 ns |     1.3820 ns |
|                 if2 |     1.3032 ns |  0.0132 ns |  0.0124 ns |     1.3076 ns |
|        conditional2 |     1.9967 ns |  0.0625 ns |  0.0791 ns |     2.0015 ns |
|    switchStatement3 |     4.1489 ns |  0.0250 ns |  0.0234 ns |     4.1491 ns |
|   switchExpression3 |     5.2536 ns |  0.5834 ns |  1.7201 ns |     4.1257 ns |
|                 if3 |     3.7513 ns |  0.0342 ns |  0.0320 ns |     3.7513 ns |
|        conditional3 |     3.0552 ns |  0.0852 ns |  0.1077 ns |     3.0481 ns |
|    switchStatement4 |     4.5788 ns |  0.0426 ns |  0.0356 ns |     4.5800 ns |
|   switchExpression4 |     6.3861 ns |  0.0990 ns |  0.2352 ns |     6.2929 ns |
|                 if4 |     5.9512 ns |  0.0195 ns |  0.0173 ns |     5.9529 ns |
|        conditional4 |     4.9664 ns |  0.1242 ns |  0.1700 ns |     4.9258 ns |
|    switchStatement5 |     8.2305 ns |  0.1917 ns |  0.3739 ns |     8.0942 ns |
|   switchExpression5 |     8.2019 ns |  0.1888 ns |  0.2455 ns |     8.0907 ns |
|                 if5 |     9.3838 ns |  0.1951 ns |  0.1825 ns |     9.3067 ns |
|        conditional5 |     6.5049 ns |  0.1541 ns |  0.2109 ns |     6.4374 ns |
|   switchStatement10 |    15.3499 ns |  0.1430 ns |  0.1268 ns |    15.3371 ns |
|  switchExpression10 |    15.0133 ns |  0.1491 ns |  0.1322 ns |    14.9726 ns |
|                if10 |    36.0373 ns |  0.1396 ns |  0.1306 ns |    36.0263 ns |
|       conditional10 |    20.9504 ns |  0.0939 ns |  0.0878 ns |    20.9298 ns |
|  switchStatement100 |   137.3561 ns |  2.7208 ns |  2.5450 ns |   137.4857 ns |
| switchExpression100 |   136.4285 ns |  2.0243 ns |  1.6904 ns |   136.2560 ns |
|               if100 | 3,670.4530 ns | 11.5974 ns | 10.2808 ns | 3,669.9791 ns |
|      conditional100 |   691.0875 ns | 13.4771 ns | 12.6065 ns |   688.7974 ns |
