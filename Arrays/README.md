# Arrays

_TODO_

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1016 (1909/November2018Update/19H2)
Intel Core i7-4790K CPU 4.00GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  DefaultJob : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT


```
|                           Method | Length |         Mean |      Error |     StdDev |
|--------------------------------- |------- |-------------:|-----------:|-----------:|
|           **PureLoopNoOptimization** |    **100** |    **260.93 ns** |   **2.487 ns** |   **2.327 ns** |
|                         PureLoop |    100 |     87.00 ns |   1.750 ns |   2.875 ns |
| CallDelegateInLoopNoOptimization |    100 |    402.99 ns |   6.323 ns |   5.605 ns |
|               CallDelegateInLoop |    100 |    203.18 ns |   2.381 ns |   2.227 ns |
|       CallDelegateNoOptimization |    100 |     58.08 ns |   1.061 ns |   0.940 ns |
|                     CallDelegate |    100 |     55.21 ns |   0.455 ns |   0.380 ns |
|           **PureLoopNoOptimization** |   **1000** |  **2,583.44 ns** |   **7.935 ns** |   **7.034 ns** |
|                         PureLoop |   1000 |    779.35 ns |   7.917 ns |   6.611 ns |
| CallDelegateInLoopNoOptimization |   1000 |  3,968.34 ns |  78.333 ns |  76.934 ns |
|               CallDelegateInLoop |   1000 |  2,020.55 ns |  10.171 ns |   8.493 ns |
|       CallDelegateNoOptimization |   1000 |    463.66 ns |   5.475 ns |   4.853 ns |
|                     CallDelegate |   1000 |    457.76 ns |   1.083 ns |   1.013 ns |
|           **PureLoopNoOptimization** |  **10000** | **25,320.75 ns** | **188.888 ns** | **176.686 ns** |
|                         PureLoop |  10000 |  7,777.32 ns |  24.456 ns |  22.876 ns |
| CallDelegateInLoopNoOptimization |  10000 | 38,489.62 ns | 109.517 ns | 102.442 ns |
|               CallDelegateInLoop |  10000 | 22,932.48 ns | 390.801 ns | 365.555 ns |
|       CallDelegateNoOptimization |  10000 |  4,520.21 ns |  17.053 ns |  15.117 ns |
|                     CallDelegate |  10000 |  4,472.78 ns |  17.625 ns |  14.717 ns |
