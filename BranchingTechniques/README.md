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
|     switchStatement1 |       0.0041 ns |     0.0089 ns |     0.0069 ns |       0.0000 ns |
|    switchExpression1 |       0.2411 ns |     0.0059 ns |     0.0055 ns |       0.2395 ns |
|                  if1 |       0.2380 ns |     0.0049 ns |     0.0046 ns |       0.2393 ns |
|         conditional1 |       0.4968 ns |     0.0150 ns |     0.0117 ns |       0.4936 ns |
|     switchStatement2 |       1.4859 ns |     0.0135 ns |     0.0127 ns |       1.4869 ns |
|    switchExpression2 |       1.5071 ns |     0.0549 ns |     0.0714 ns |       1.5117 ns |
|                  if2 |       1.5020 ns |     0.0148 ns |     0.0131 ns |       1.4999 ns |
|         conditional2 |       1.2203 ns |     0.0501 ns |     0.0669 ns |       1.2190 ns |
|     switchStatement3 |       4.1964 ns |     0.0767 ns |     0.0680 ns |       4.1938 ns |
|    switchExpression3 |       4.0621 ns |     0.1047 ns |     0.0980 ns |       4.0089 ns |
|                  if3 |       2.9129 ns |     0.0653 ns |     0.0610 ns |       2.9171 ns |
|         conditional3 |       3.5388 ns |     0.0906 ns |     0.0803 ns |       3.5558 ns |
|     switchStatement4 |       5.6539 ns |     0.1398 ns |     0.2217 ns |       5.5957 ns |
|    switchExpression4 |       6.1669 ns |     0.1280 ns |     0.1135 ns |       6.2009 ns |
|                  if4 |       6.4234 ns |     0.0834 ns |     0.0780 ns |       6.4019 ns |
|         conditional4 |       5.6963 ns |     0.1180 ns |     0.1046 ns |       5.6696 ns |
|     switchStatement5 |       7.1302 ns |     0.1681 ns |     0.4631 ns |       6.8903 ns |
|    switchExpression5 |       6.8067 ns |     0.0729 ns |     0.0647 ns |       6.7913 ns |
|                  if5 |       9.4046 ns |     0.0975 ns |     0.0814 ns |       9.3969 ns |
|         conditional5 |       7.6240 ns |     0.0333 ns |     0.0296 ns |       7.6185 ns |
|    switchStatement10 |      14.8379 ns |     0.1509 ns |     0.1260 ns |      14.7890 ns |
|   switchExpression10 |      22.6056 ns |     3.2595 ns |     9.6107 ns |      15.1786 ns |
|                 if10 |      37.5589 ns |     0.7121 ns |     0.9259 ns |      37.1005 ns |
|        conditional10 |      16.6546 ns |     0.1360 ns |     0.1205 ns |      16.6106 ns |
|   switchStatement100 |     219.1269 ns |    31.6139 ns |    93.2144 ns |     153.3968 ns |
|  switchExpression100 |     161.8614 ns |     2.5963 ns |     2.3015 ns |     162.0861 ns |
|                if100 |   3,991.8982 ns |    70.1564 ns |   100.6162 ns |   3,981.9721 ns |
|       conditional100 |     712.3504 ns |    13.6491 ns |    14.0166 ns |     713.8268 ns |
|  switchStatement1000 |   5,983.2963 ns |   103.4955 ns |   123.2041 ns |   5,935.0021 ns |
| switchExpression1000 |   4,556.3652 ns |    38.0648 ns |    42.3090 ns |   4,540.0730 ns |
|               if1000 | 566,657.9362 ns | 3,719.6975 ns | 3,479.4074 ns | 566,030.3711 ns |
|      conditional1000 |              NA |            NA |            NA |              NA |

Benchmarks with issues:
  BranchingTechniquesBenchmarks.conditional1000: DefaultJob
