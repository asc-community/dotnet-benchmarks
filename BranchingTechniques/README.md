# Branching Techniques

This benchmark compares various types of branching that is possible inside of C#: switch statements,
switch expressions, if statements, and conditional expressions.

_Note: large conditional expressions cause a `StackOverflowException` in Roslyn and cannot be built._

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1016 (1909/November2018Update/19H2)
Intel Core i7-4790K CPU 4.00GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.100-preview.8.20417.9
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.40711, CoreFX 5.0.20.40711), X64 RyuJIT
  DefaultJob : .NET Core 5.0.0 (CoreCLR 5.0.20.40711, CoreFX 5.0.20.40711), X64 RyuJIT


```
|               Method |            Mean |         Error |        StdDev |          Median |
|--------------------- |----------------:|--------------:|--------------:|----------------:|
|     switchStatement1 |       0.0014 ns |     0.0029 ns |     0.0027 ns |       0.0000 ns |
|    switchExpression1 |       0.2407 ns |     0.0097 ns |     0.0090 ns |       0.2412 ns |
|                  if1 |       0.2357 ns |     0.0076 ns |     0.0071 ns |       0.2352 ns |
|         conditional1 |       0.5756 ns |     0.0365 ns |     0.0448 ns |       0.5699 ns |
|     switchStatement2 |       1.4590 ns |     0.0133 ns |     0.0124 ns |       1.4559 ns |
|    switchExpression2 |       1.5196 ns |     0.0555 ns |     0.0814 ns |       1.5300 ns |
|                  if2 |       1.3594 ns |     0.0532 ns |     0.0523 ns |       1.3353 ns |
|         conditional2 |       1.1767 ns |     0.0333 ns |     0.0311 ns |       1.1730 ns |
|     switchStatement3 |       4.1114 ns |     0.0771 ns |     0.0602 ns |       4.1107 ns |
|    switchExpression3 |       4.3437 ns |     0.1110 ns |     0.1520 ns |       4.3152 ns |
|                  if3 |       3.8700 ns |     0.0404 ns |     0.0358 ns |       3.8752 ns |
|         conditional3 |       3.5161 ns |     0.0676 ns |     0.0632 ns |       3.5530 ns |
|     switchStatement4 |       5.6173 ns |     0.0763 ns |     0.1470 ns |       5.6022 ns |
|    switchExpression4 |       6.1340 ns |     0.1434 ns |     0.1271 ns |       6.0750 ns |
|                  if4 |       6.2361 ns |     0.1501 ns |     0.2338 ns |       6.2479 ns |
|         conditional4 |       5.5457 ns |     0.0675 ns |     0.0599 ns |       5.5537 ns |
|     switchStatement5 |       7.0590 ns |     0.1593 ns |     0.1897 ns |       7.0144 ns |
|    switchExpression5 |       6.9517 ns |     0.1623 ns |     0.2756 ns |       6.8837 ns |
|                  if5 |       8.8664 ns |     0.0877 ns |     0.0820 ns |       8.8887 ns |
|         conditional5 |       7.8437 ns |     0.1637 ns |     0.1608 ns |       7.8131 ns |
|    switchStatement10 |      15.2778 ns |     0.3325 ns |     0.3696 ns |      15.2038 ns |
|   switchExpression10 |      17.0714 ns |     0.3612 ns |     0.5730 ns |      16.9284 ns |
|                 if10 |      28.8714 ns |     0.4889 ns |     0.5231 ns |      28.7261 ns |
|        conditional10 |      16.4725 ns |     0.1321 ns |     0.1235 ns |      16.4475 ns |
|   switchStatement100 |     143.5896 ns |     1.1010 ns |     0.9760 ns |     143.2851 ns |
|  switchExpression100 |     157.8319 ns |     2.9648 ns |     2.3147 ns |     157.1144 ns |
|                if100 |   1,788.5813 ns |    35.2708 ns |    39.2034 ns |   1,787.3701 ns |
|       conditional100 |     701.0713 ns |     3.3936 ns |     3.1744 ns |     699.9504 ns |
|  switchStatement1000 |   6,243.7404 ns |   126.9243 ns |   366.2056 ns |   6,067.1780 ns |
| switchExpression1000 |   4,642.0040 ns |    90.2316 ns |    96.5468 ns |   4,622.6555 ns |
|               if1000 | 270,967.1061 ns | 2,022.8634 ns | 1,579.3187 ns | 271,108.5205 ns |
|      conditional1000 |              NA |            NA |            NA |              NA |

Benchmarks with issues:
  BranchingTechniquesBenchmarks.conditional1000: DefaultJob
