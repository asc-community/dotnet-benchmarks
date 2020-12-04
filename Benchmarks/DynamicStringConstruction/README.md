# Exception Handling Techniques

This benchmark compares several ways to dynamically construct strings.

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1198 (1909/November2018Update/19H2)
Intel Core i7-4790K CPU 4.00GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.100
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT
  DefaultJob : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT


```
|                     Method |      N |           Mean |         Error |        StdDev |    Gen 0 |    Gen 1 |    Gen 2 | Allocated |
|--------------------------- |------- |---------------:|--------------:|--------------:|---------:|---------:|---------:|----------:|
|              **StringBuilder** |      **1** |      **24.442 ns** |     **0.5116 ns** |     **0.8548 ns** |   **0.0306** |        **-** |        **-** |     **128 B** |
|                CharPointer |      1 |       9.111 ns |     0.0487 ns |     0.0432 ns |   0.0057 |        - |        - |      24 B |
|        CharPointerDelegate |      1 |      20.295 ns |     0.3914 ns |     0.4660 ns |   0.0210 |        - |        - |      88 B |
|         CharPointerGeneric |      1 |      10.298 ns |     0.0486 ns |     0.0454 ns |   0.0057 |        - |        - |      24 B |
|                  CharArray |      1 |      14.336 ns |     0.1096 ns |     0.1025 ns |   0.0134 |        - |        - |      56 B |
|               StringCreate |      1 |      16.567 ns |     0.0848 ns |     0.0751 ns |   0.0210 |        - |        - |      88 B |
| StringCreateHelperDelegate |      1 |      35.558 ns |     0.6991 ns |     1.0463 ns |   0.0440 |        - |        - |     184 B |
|  StringCreateHelperGeneric |      1 |      23.736 ns |     0.4555 ns |     0.4260 ns |   0.0287 |        - |        - |     120 B |
|              **StringBuilder** |      **5** |      **36.656 ns** |     **0.7254 ns** |     **0.7124 ns** |   **0.0325** |        **-** |        **-** |     **136 B** |
|                CharPointer |      5 |      15.284 ns |     0.1705 ns |     0.1595 ns |   0.0076 |        - |        - |      32 B |
|        CharPointerDelegate |      5 |      31.671 ns |     0.6396 ns |     0.7109 ns |   0.0229 |        - |        - |      96 B |
|         CharPointerGeneric |      5 |      17.237 ns |     0.2626 ns |     0.2193 ns |   0.0076 |        - |        - |      32 B |
|                  CharArray |      5 |      20.640 ns |     0.2963 ns |     0.2627 ns |   0.0172 |        - |        - |      72 B |
|               StringCreate |      5 |      22.944 ns |     0.1616 ns |     0.1350 ns |   0.0229 |        - |        - |      96 B |
| StringCreateHelperDelegate |      5 |      45.136 ns |     0.9213 ns |     1.4614 ns |   0.0459 |        - |        - |     192 B |
|  StringCreateHelperGeneric |      5 |      28.683 ns |     0.1971 ns |     0.1747 ns |   0.0306 |        - |        - |     128 B |
|              **StringBuilder** |     **10** |      **52.829 ns** |     **1.0808 ns** |     **1.4794 ns** |   **0.0363** |        **-** |        **-** |     **152 B** |
|                CharPointer |     10 |      22.776 ns |     0.4415 ns |     0.4130 ns |   0.0115 |        - |        - |      48 B |
|        CharPointerDelegate |     10 |      46.533 ns |     0.6915 ns |     0.6468 ns |   0.0268 |        - |        - |     112 B |
|         CharPointerGeneric |     10 |      25.248 ns |     0.3716 ns |     0.3294 ns |   0.0115 |        - |        - |      48 B |
|                  CharArray |     10 |      29.176 ns |     0.5900 ns |     0.5230 ns |   0.0229 |        - |        - |      96 B |
|               StringCreate |     10 |      30.790 ns |     0.2714 ns |     0.2267 ns |   0.0268 |        - |        - |     112 B |
| StringCreateHelperDelegate |     10 |      61.822 ns |     0.4384 ns |     0.3887 ns |   0.0497 |        - |        - |     208 B |
|  StringCreateHelperGeneric |     10 |      37.433 ns |     0.5666 ns |     0.5300 ns |   0.0344 |        - |        - |     144 B |
|              **StringBuilder** |    **100** |     **440.419 ns** |     **5.3358 ns** |     **4.9911 ns** |   **0.1836** |        **-** |        **-** |     **768 B** |
|                CharPointer |    100 |     162.369 ns |     1.7027 ns |     1.5927 ns |   0.0534 |        - |        - |     224 B |
|        CharPointerDelegate |    100 |     308.707 ns |     4.0529 ns |     3.3844 ns |   0.0687 |        - |        - |     288 B |
|         CharPointerGeneric |    100 |     160.004 ns |     3.1690 ns |     2.9643 ns |   0.0534 |        - |        - |     224 B |
|                  CharArray |    100 |     180.620 ns |     2.6459 ns |     2.2094 ns |   0.1070 |        - |        - |     448 B |
|               StringCreate |    100 |     167.981 ns |     2.7305 ns |     2.5541 ns |   0.0687 |        - |        - |     288 B |
| StringCreateHelperDelegate |    100 |     337.329 ns |     5.6865 ns |     5.3192 ns |   0.0916 |        - |        - |     384 B |
|  StringCreateHelperGeneric |    100 |     174.017 ns |     1.3309 ns |     1.1113 ns |   0.0763 |        - |        - |     320 B |
|              **StringBuilder** |   **1000** |   **3,143.532 ns** |    **54.0841 ns** |    **50.5903 ns** |   **1.0910** |        **-** |        **-** |    **4576 B** |
|                CharPointer |   1000 |   1,477.572 ns |    24.7531 ns |    23.1541 ns |   0.4826 |        - |        - |    2024 B |
|        CharPointerDelegate |   1000 |   2,804.211 ns |    18.6517 ns |    15.5750 ns |   0.4959 |        - |        - |    2088 B |
|         CharPointerGeneric |   1000 |   1,460.102 ns |    12.0865 ns |    11.3057 ns |   0.4826 |        - |        - |    2024 B |
|                  CharArray |   1000 |   1,634.348 ns |    15.5052 ns |    13.7450 ns |   0.9670 |        - |        - |    4048 B |
|               StringCreate |   1000 |   1,452.467 ns |    11.1382 ns |     9.8738 ns |   0.4978 |        - |        - |    2088 B |
| StringCreateHelperDelegate |   1000 |   2,683.280 ns |    29.7786 ns |    26.3979 ns |   0.5188 |        - |        - |    2184 B |
|  StringCreateHelperGeneric |   1000 |   1,453.323 ns |    26.9889 ns |    25.2454 ns |   0.5054 |        - |        - |    2120 B |
|              **StringBuilder** |  **10000** |  **33,489.982 ns** |   **614.7851 ns** |   **575.0704 ns** |  **12.6343** |   **2.0752** |        **-** |   **53200 B** |
|                CharPointer |  10000 |  13,930.211 ns |   260.9796 ns |   256.3169 ns |   4.7607 |        - |        - |   20024 B |
|        CharPointerDelegate |  10000 |  26,817.568 ns |   469.8686 ns |   439.5153 ns |   4.7607 |        - |        - |   20088 B |
|         CharPointerGeneric |  10000 |  13,964.402 ns |   251.7421 ns |   235.4797 ns |   4.7607 |        - |        - |   20024 B |
|                  CharArray |  10000 |  16,132.019 ns |   213.5359 ns |   199.7416 ns |   9.5215 |        - |        - |   40048 B |
|               StringCreate |  10000 |  14,113.128 ns |   266.8421 ns |   274.0272 ns |   4.7760 |        - |        - |   20088 B |
| StringCreateHelperDelegate |  10000 |  26,164.058 ns |    56.2994 ns |    52.6625 ns |   4.7913 |   0.0305 |        - |   20184 B |
|  StringCreateHelperGeneric |  10000 |  13,808.017 ns |    47.9691 ns |    40.0564 ns |   4.8065 |        - |        - |   20120 B |
|              **StringBuilder** | **100000** | **329,875.837 ns** | **3,697.8793 ns** | **3,278.0737 ns** |  **62.0117** |  **62.0117** |  **62.0117** |  **409992 B** |
|                CharPointer | 100000 | 146,584.978 ns | 2,316.5746 ns | 2,053.5831 ns |  62.2559 |  62.2559 |  62.2559 |  200024 B |
|        CharPointerDelegate | 100000 | 288,440.687 ns | 5,432.7750 ns | 5,081.8211 ns |  62.0117 |  62.0117 |  62.0117 |  200088 B |
|         CharPointerGeneric | 100000 | 145,186.229 ns | 2,618.3819 ns | 2,321.1273 ns |  62.2559 |  62.2559 |  62.2559 |  200024 B |
|                  CharArray | 100000 | 166,354.152 ns | 1,425.2741 ns | 1,263.4684 ns | 124.7559 | 124.7559 | 124.7559 |  400048 B |
|               StringCreate | 100000 | 139,888.672 ns |   663.4840 ns |   554.0392 ns |  62.2559 |  62.2559 |  62.2559 |  200088 B |
| StringCreateHelperDelegate | 100000 | 295,586.743 ns | 2,001.4322 ns | 1,774.2175 ns |  62.0117 |  62.0117 |  62.0117 |  200184 B |
|  StringCreateHelperGeneric | 100000 | 141,654.061 ns | 1,531.7513 ns | 1,432.8011 ns |  62.2559 |  62.2559 |  62.2559 |  200120 B |
