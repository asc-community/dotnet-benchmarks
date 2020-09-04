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
|               Method |            Mean |         Error |        StdDev |
|--------------------- |----------------:|--------------:|--------------:|
|     switchStatement1 |       0.0177 ns |     0.0141 ns |     0.0131 ns |
|    switchExpression1 |       0.3611 ns |     0.0204 ns |     0.0191 ns |
|                  if1 |       0.0412 ns |     0.0145 ns |     0.0135 ns |
|     switchStatement2 |       2.0416 ns |     0.0154 ns |     0.0145 ns |
|    switchExpression2 |       1.4612 ns |     0.0091 ns |     0.0076 ns |
|                  if2 |       1.3814 ns |     0.0169 ns |     0.0158 ns |
|     switchStatement3 |       3.7786 ns |     0.0894 ns |     0.0698 ns |
|    switchExpression3 |       3.9597 ns |     0.0443 ns |     0.0415 ns |
|                  if3 |       4.0179 ns |     0.0561 ns |     0.0524 ns |
|     switchStatement4 |       4.8798 ns |     0.0529 ns |     0.0442 ns |
|    switchExpression4 |       6.9204 ns |     0.1561 ns |     0.1533 ns |
|                  if4 |       6.2919 ns |     0.0710 ns |     0.0664 ns |
|     switchStatement5 |       8.4929 ns |     0.1755 ns |     0.1370 ns |
|    switchExpression5 |       9.3780 ns |     0.0583 ns |     0.0487 ns |
|                  if5 |       9.9306 ns |     0.0804 ns |     0.0712 ns |
|    switchStatement10 |      16.7478 ns |     0.1733 ns |     0.1621 ns |
|   switchExpression10 |      15.9794 ns |     0.1573 ns |     0.1395 ns |
|                 if10 |      38.0446 ns |     0.4347 ns |     0.3630 ns |
|   switchStatement100 |     143.9048 ns |     1.7874 ns |     1.5845 ns |
|  switchExpression100 |     137.2257 ns |     1.7554 ns |     1.5561 ns |
|                if100 |   3,862.5234 ns |    16.8451 ns |    14.9328 ns |
|  switchStatement1000 |   6,037.8563 ns |    58.9303 ns |    55.1234 ns |
| switchExpression1000 |   4,848.7897 ns |    39.7233 ns |    37.1572 ns |
|               if1000 | 578,935.8924 ns | 2,782.7754 ns | 2,323.7435 ns |
