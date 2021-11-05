# Memory alignment


### AddArrays

``` ini
BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19042.1288 (20H2/October2020Update)
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.100-rc.2.21456.8
  [Host]     : .NET 6.0.0 (6.0.21.45401), X64 RyuJIT
  DefaultJob : .NET 6.0.0 (6.0.21.45401), X64 RyuJIT
```

|  Method | ElemCount | Offset |       Mean |    Error |   StdDev |
|-------- |---------- |------- |-----------:|---------:|---------:|
| SimdAdd |      4096 |      0 | 1,019.5 ns | 19.43 ns | 28.47 ns |
| SimdAdd |      4096 |      1 | 1,053.2 ns | 20.05 ns | 45.67 ns |
| SimdAdd |      4096 |      2 | 1,051.4 ns | 20.82 ns | 19.47 ns |
| SimdAdd |      4096 |      3 | 1,129.0 ns | 16.55 ns | 15.48 ns |
| SimdAdd |      4096 |      4 |   941.6 ns | 12.67 ns | 11.85 ns |
| SimdAdd |      4096 |      5 | 1,053.4 ns | 12.68 ns | 11.86 ns |
| SimdAdd |      4096 |      6 | 1,146.8 ns | 22.94 ns | 22.53 ns |
| SimdAdd |      4096 |      7 |   985.5 ns |  9.77 ns |  9.14 ns |
| SimdAdd |      4096 |      8 |   987.5 ns | 18.97 ns | 20.30 ns |
| SimdAdd |      4096 |      9 | 1,062.4 ns | 15.14 ns | 14.16 ns |
| SimdAdd |      4096 |     10 |   915.6 ns | 17.69 ns | 18.17 ns |
| SimdAdd |      4096 |     11 | 1,150.3 ns | 19.42 ns | 18.16 ns |
| SimdAdd |      4096 |     12 | 1,138.5 ns | 22.65 ns | 24.24 ns |
| SimdAdd |      4096 |     13 |   994.2 ns | 19.03 ns | 19.54 ns |
| SimdAdd |      4096 |     14 | 1,159.5 ns | 21.77 ns | 21.38 ns |
| SimdAdd |      4096 |     15 |   981.9 ns | 10.28 ns |  9.62 ns |
| SimdAdd |      4096 |     16 | 1,314.9 ns | 25.75 ns | 35.25 ns |
| SimdAdd |      4096 |     17 | 1,124.0 ns | 20.42 ns | 19.10 ns |
| SimdAdd |      4096 |     18 | 1,060.7 ns | 18.01 ns | 16.85 ns |
| SimdAdd |      4096 |     19 |   949.6 ns | 17.12 ns | 16.02 ns |
| SimdAdd |      4096 |     20 | 1,063.0 ns | 19.53 ns | 18.27 ns |
| SimdAdd |      4096 |     21 | 1,041.4 ns | 15.15 ns | 13.43 ns |
| SimdAdd |      4096 |     22 | 1,098.4 ns | 17.39 ns | 16.26 ns |
| SimdAdd |      4096 |     23 | 1,667.2 ns | 18.76 ns | 17.55 ns |
| SimdAdd |      4096 |     24 | 1,119.7 ns | 21.10 ns | 19.74 ns |
| SimdAdd |      4096 |     25 |   954.3 ns | 11.20 ns | 10.47 ns |
| SimdAdd |      4096 |     26 |   981.6 ns | 19.49 ns | 25.34 ns |
| SimdAdd |      4096 |     27 | 1,102.7 ns | 14.56 ns | 13.62 ns |
| SimdAdd |      4096 |     28 | 1,147.0 ns | 20.82 ns | 19.48 ns |
| SimdAdd |      4096 |     29 |   943.9 ns | 14.16 ns | 13.25 ns |
| SimdAdd |      4096 |     30 |   964.5 ns | 18.71 ns | 20.80 ns |
| SimdAdd |      4096 |     31 | 1,023.8 ns | 15.73 ns | 14.72 ns |
| SimdAdd |      4096 |     32 |   828.6 ns | 15.92 ns | 14.89 ns |
| SimdAdd |      4096 |     33 | 1,082.0 ns | 10.55 ns |  8.81 ns |
| SimdAdd |      4096 |     34 | 1,084.1 ns | 17.18 ns | 15.23 ns |
| SimdAdd |      4096 |     35 |   944.3 ns | 14.10 ns | 13.19 ns |
| SimdAdd |      4096 |     36 | 1,065.7 ns | 19.99 ns | 20.53 ns |
| SimdAdd |      4096 |     37 | 1,093.7 ns | 15.91 ns | 14.89 ns |
| SimdAdd |      4096 |     38 | 1,046.9 ns | 19.44 ns | 18.18 ns |
| SimdAdd |      4096 |     39 | 1,061.0 ns | 16.10 ns | 15.06 ns |
| SimdAdd |      4096 |     40 | 1,095.5 ns | 10.34 ns |  9.67 ns |
| SimdAdd |      4096 |     41 | 1,083.1 ns | 21.37 ns | 22.86 ns |
| SimdAdd |      4096 |     42 | 1,048.0 ns | 17.37 ns | 16.25 ns |
| SimdAdd |      4096 |     43 | 1,079.8 ns | 21.30 ns | 20.92 ns |
| SimdAdd |      4096 |     44 | 1,168.7 ns | 20.23 ns | 18.93 ns |
| SimdAdd |      4096 |     45 |   960.4 ns | 18.01 ns | 17.69 ns |
| SimdAdd |      4096 |     46 | 1,043.2 ns | 17.51 ns | 16.38 ns |
| SimdAdd |      4096 |     47 |   971.4 ns | 18.61 ns | 24.20 ns |
| SimdAdd |      4096 |     48 | 1,133.5 ns | 12.28 ns | 10.88 ns |
| SimdAdd |      4096 |     49 | 1,144.1 ns | 17.41 ns | 16.29 ns |
| SimdAdd |      4096 |     50 | 1,103.8 ns | 17.69 ns | 16.55 ns |
| SimdAdd |      4096 |     51 | 1,105.4 ns | 21.67 ns | 20.27 ns |
| SimdAdd |      4096 |     52 | 1,068.4 ns | 20.85 ns | 19.50 ns |
| SimdAdd |      4096 |     53 |   941.6 ns | 18.26 ns | 19.54 ns |
| SimdAdd |      4096 |     54 | 1,080.3 ns | 19.41 ns | 18.15 ns |
| SimdAdd |      4096 |     55 |   995.0 ns | 19.67 ns | 18.40 ns |
| SimdAdd |      4096 |     56 | 1,070.8 ns | 17.92 ns | 16.77 ns |
| SimdAdd |      4096 |     57 | 1,090.6 ns | 20.96 ns | 22.43 ns |
| SimdAdd |      4096 |     58 | 1,100.5 ns | 21.73 ns | 20.32 ns |
| SimdAdd |      4096 |     59 |   993.1 ns | 13.86 ns | 12.96 ns |
| SimdAdd |      4096 |     60 |   940.3 ns | 17.30 ns | 16.18 ns |
| SimdAdd |      4096 |     61 |   967.1 ns | 16.90 ns | 15.81 ns |
| SimdAdd |      4096 |     62 |   990.5 ns | 10.51 ns |  9.84 ns |
| SimdAdd |      4096 |     63 | 1,061.8 ns | 20.90 ns | 22.37 ns |

<details><summary><b>Distributions</b></summary>

```
AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=0]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 1.019 us, StdErr = 0.005 us (0.52%), N = 29, StdDev = 0.028 us
Min = 0.956 us, Q1 = 1.012 us, Median = 1.023 us, Q3 = 1.041 us, Max = 1.060 us
IQR = 0.029 us, LowerFence = 0.968 us, UpperFence = 1.085 us
ConfidenceInterval = [1.000 us; 1.039 us] (CI 99.9%), Margin = 0.019 us (1.91% of Mean)
Skewness = -0.73, Kurtosis = 2.51, MValue = 2
-------------------- Histogram --------------------
[0.944 us ; 0.984 us) | @@@@@
[0.984 us ; 1.018 us) | @@@@@
[1.018 us ; 1.042 us) | @@@@@@@@@@@@
[1.042 us ; 1.064 us) | @@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=1]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 1.053 us, StdErr = 0.006 us (0.55%), N = 62, StdDev = 0.046 us
Min = 0.985 us, Q1 = 1.020 us, Median = 1.039 us, Q3 = 1.084 us, Max = 1.179 us
IQR = 0.064 us, LowerFence = 0.925 us, UpperFence = 1.180 us
ConfidenceInterval = [1.033 us; 1.073 us] (CI 99.9%), Margin = 0.020 us (1.90% of Mean)
Skewness = 0.91, Kurtosis = 3.07, MValue = 2.15
-------------------- Histogram --------------------
[0.980 us ; 1.012 us) | @@@@@@@
[1.012 us ; 1.042 us) | @@@@@@@@@@@@@@@@@@@@@@@@@@@
[1.042 us ; 1.090 us) | @@@@@@@@@@@@@@@@@@
[1.090 us ; 1.125 us) | @@@
[1.125 us ; 1.155 us) | @@@@@
[1.155 us ; 1.185 us) | @@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=2]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 1.051 us, StdErr = 0.005 us (0.48%), N = 15, StdDev = 0.019 us
Min = 1.026 us, Q1 = 1.038 us, Median = 1.048 us, Q3 = 1.062 us, Max = 1.097 us
IQR = 0.024 us, LowerFence = 1.001 us, UpperFence = 1.099 us
ConfidenceInterval = [1.031 us; 1.072 us] (CI 99.9%), Margin = 0.021 us (1.98% of Mean)
Skewness = 0.72, Kurtosis = 2.74, MValue = 2
-------------------- Histogram --------------------
[1.016 us ; 1.053 us) | @@@@@@@@@
[1.053 us ; 1.079 us) | @@@@@
[1.079 us ; 1.108 us) | @
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=3]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 1.129 us, StdErr = 0.004 us (0.35%), N = 15, StdDev = 0.015 us
Min = 1.104 us, Q1 = 1.118 us, Median = 1.134 us, Q3 = 1.139 us, Max = 1.155 us
IQR = 0.021 us, LowerFence = 1.086 us, UpperFence = 1.170 us
ConfidenceInterval = [1.112 us; 1.146 us] (CI 99.9%), Margin = 0.017 us (1.47% of Mean)
Skewness = -0.12, Kurtosis = 1.79, MValue = 2
-------------------- Histogram --------------------
[1.096 us ; 1.164 us) | @@@@@@@@@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=4]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 941.593 ns, StdErr = 3.061 ns (0.33%), N = 15, StdDev = 11.854 ns
Min = 925.685 ns, Q1 = 930.662 ns, Median = 943.162 ns, Q3 = 952.337 ns, Max = 961.431 ns
IQR = 21.675 ns, LowerFence = 898.150 ns, UpperFence = 984.850 ns
ConfidenceInterval = [928.920 ns; 954.266 ns] (CI 99.9%), Margin = 12.673 ns (1.35% of Mean)
Skewness = 0.02, Kurtosis = 1.47, MValue = 2
-------------------- Histogram --------------------
[921.207 ns ; 967.740 ns) | @@@@@@@@@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=5]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 1.053 us, StdErr = 0.003 us (0.29%), N = 15, StdDev = 0.012 us
Min = 1.025 us, Q1 = 1.047 us, Median = 1.056 us, Q3 = 1.062 us, Max = 1.069 us
IQR = 0.015 us, LowerFence = 1.025 us, UpperFence = 1.084 us
ConfidenceInterval = [1.041 us; 1.066 us] (CI 99.9%), Margin = 0.013 us (1.20% of Mean)
Skewness = -0.72, Kurtosis = 2.74, MValue = 2
-------------------- Histogram --------------------
[1.019 us ; 1.072 us) | @@@@@@@@@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=6]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 1.147 us, StdErr = 0.006 us (0.49%), N = 16, StdDev = 0.023 us
Min = 1.091 us, Q1 = 1.135 us, Median = 1.147 us, Q3 = 1.158 us, Max = 1.190 us
IQR = 0.023 us, LowerFence = 1.101 us, UpperFence = 1.193 us
ConfidenceInterval = [1.124 us; 1.170 us] (CI 99.9%), Margin = 0.023 us (2.00% of Mean)
Skewness = -0.36, Kurtosis = 3.47, MValue = 2
-------------------- Histogram --------------------
[1.080 us ; 1.103 us) | @
[1.103 us ; 1.139 us) | @@@@
[1.139 us ; 1.196 us) | @@@@@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=7]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 985.504 ns, StdErr = 2.359 ns (0.24%), N = 15, StdDev = 9.138 ns
Min = 970.255 ns, Q1 = 980.053 ns, Median = 984.089 ns, Q3 = 992.718 ns, Max = 1,001.811 ns
IQR = 12.665 ns, LowerFence = 961.055 ns, UpperFence = 1,011.716 ns
ConfidenceInterval = [975.735 ns; 995.274 ns] (CI 99.9%), Margin = 9.769 ns (0.99% of Mean)
Skewness = 0.16, Kurtosis = 1.88, MValue = 2
-------------------- Histogram --------------------
[965.391 ns ; 1,006.674 ns) | @@@@@@@@@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=8]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 987.545 ns, StdErr = 4.785 ns (0.48%), N = 18, StdDev = 20.300 ns
Min = 934.517 ns, Q1 = 983.952 ns, Median = 993.262 ns, Q3 = 996.948 ns, Max = 1,011.642 ns
IQR = 12.996 ns, LowerFence = 964.459 ns, UpperFence = 1,016.441 ns
ConfidenceInterval = [968.572 ns; 1,006.518 ns] (CI 99.9%), Margin = 18.973 ns (1.92% of Mean)
Skewness = -1.48, Kurtosis = 4.46, MValue = 2
-------------------- Histogram --------------------
[927.167 ns ;   947.501 ns) | @@
[947.501 ns ;   968.364 ns) |
[968.364 ns ; 1,021.809 ns) | @@@@@@@@@@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=9]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 1.062 us, StdErr = 0.004 us (0.34%), N = 15, StdDev = 0.014 us
Min = 1.032 us, Q1 = 1.056 us, Median = 1.065 us, Q3 = 1.072 us, Max = 1.085 us
IQR = 0.016 us, LowerFence = 1.031 us, UpperFence = 1.097 us
ConfidenceInterval = [1.047 us; 1.078 us] (CI 99.9%), Margin = 0.015 us (1.42% of Mean)
Skewness = -0.62, Kurtosis = 2.5, MValue = 2
-------------------- Histogram --------------------
[1.025 us ; 1.059 us) | @@@@@@
[1.059 us ; 1.092 us) | @@@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=10]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 915.599 ns, StdErr = 4.407 ns (0.48%), N = 17, StdDev = 18.171 ns
Min = 882.339 ns, Q1 = 901.875 ns, Median = 918.570 ns, Q3 = 929.618 ns, Max = 947.716 ns
IQR = 27.743 ns, LowerFence = 860.260 ns, UpperFence = 971.232 ns
ConfidenceInterval = [897.904 ns; 933.293 ns] (CI 99.9%), Margin = 17.694 ns (1.93% of Mean)
Skewness = -0.05, Kurtosis = 1.86, MValue = 2
-------------------- Histogram --------------------
[876.847 ns ; 895.467 ns) | @@
[895.467 ns ; 918.151 ns) | @@@@@@
[918.151 ns ; 956.991 ns) | @@@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=11]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 1.150 us, StdErr = 0.005 us (0.41%), N = 15, StdDev = 0.018 us
Min = 1.119 us, Q1 = 1.139 us, Median = 1.150 us, Q3 = 1.163 us, Max = 1.180 us
IQR = 0.024 us, LowerFence = 1.103 us, UpperFence = 1.200 us
ConfidenceInterval = [1.131 us; 1.170 us] (CI 99.9%), Margin = 0.019 us (1.69% of Mean)
Skewness = -0.02, Kurtosis = 1.87, MValue = 2
-------------------- Histogram --------------------
[1.115 us ; 1.157 us) | @@@@@@@@@@
[1.157 us ; 1.183 us) | @@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=12]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 1.139 us, StdErr = 0.006 us (0.50%), N = 18, StdDev = 0.024 us
Min = 1.060 us, Q1 = 1.132 us, Median = 1.142 us, Q3 = 1.154 us, Max = 1.167 us
IQR = 0.022 us, LowerFence = 1.098 us, UpperFence = 1.188 us
ConfidenceInterval = [1.116 us; 1.161 us] (CI 99.9%), Margin = 0.023 us (1.99% of Mean)
Skewness = -1.78, Kurtosis = 6.5, MValue = 2
-------------------- Histogram --------------------
[1.048 us ; 1.072 us) | @
[1.072 us ; 1.110 us) |
[1.110 us ; 1.134 us) | @@@@
[1.134 us ; 1.179 us) | @@@@@@@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=13]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 994.199 ns, StdErr = 4.739 ns (0.48%), N = 17, StdDev = 19.541 ns
Min = 967.726 ns, Q1 = 978.763 ns, Median = 996.821 ns, Q3 = 1,005.043 ns, Max = 1,033.947 ns
IQR = 26.280 ns, LowerFence = 939.343 ns, UpperFence = 1,044.463 ns
ConfidenceInterval = [975.170 ns; 1,013.227 ns] (CI 99.9%), Margin = 19.029 ns (1.91% of Mean)
Skewness = 0.35, Kurtosis = 1.93, MValue = 2
-------------------- Histogram --------------------
[967.437 ns ;   995.995 ns) | @@@@@@@@
[995.995 ns ; 1,039.104 ns) | @@@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=14]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 1.159 us, StdErr = 0.005 us (0.46%), N = 16, StdDev = 0.021 us
Min = 1.110 us, Q1 = 1.150 us, Median = 1.159 us, Q3 = 1.178 us, Max = 1.191 us
IQR = 0.028 us, LowerFence = 1.107 us, UpperFence = 1.220 us
ConfidenceInterval = [1.138 us; 1.181 us] (CI 99.9%), Margin = 0.022 us (1.88% of Mean)
Skewness = -0.37, Kurtosis = 2.57, MValue = 2
-------------------- Histogram --------------------
[1.099 us ; 1.144 us) | @@@
[1.144 us ; 1.196 us) | @@@@@@@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=15]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 981.879 ns, StdErr = 2.484 ns (0.25%), N = 15, StdDev = 9.619 ns
Min = 963.456 ns, Q1 = 978.280 ns, Median = 981.529 ns, Q3 = 988.415 ns, Max = 1,000.336 ns
IQR = 10.135 ns, LowerFence = 963.078 ns, UpperFence = 1,003.617 ns
ConfidenceInterval = [971.595 ns; 992.163 ns] (CI 99.9%), Margin = 10.284 ns (1.05% of Mean)
Skewness = -0.12, Kurtosis = 2.32, MValue = 2
-------------------- Histogram --------------------
[958.337 ns ; 1,005.455 ns) | @@@@@@@@@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=16]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 1.315 us, StdErr = 0.007 us (0.53%), N = 26, StdDev = 0.035 us
Min = 1.260 us, Q1 = 1.288 us, Median = 1.306 us, Q3 = 1.341 us, Max = 1.387 us
IQR = 0.053 us, LowerFence = 1.209 us, UpperFence = 1.420 us
ConfidenceInterval = [1.289 us; 1.341 us] (CI 99.9%), Margin = 0.026 us (1.96% of Mean)
Skewness = 0.32, Kurtosis = 2, MValue = 2
-------------------- Histogram --------------------
[1.245 us ; 1.272 us) | @@
[1.272 us ; 1.303 us) | @@@@@@@@@@@
[1.303 us ; 1.352 us) | @@@@@@@@@
[1.352 us ; 1.388 us) | @@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=17]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 1.124 us, StdErr = 0.005 us (0.44%), N = 15, StdDev = 0.019 us
Min = 1.093 us, Q1 = 1.115 us, Median = 1.117 us, Q3 = 1.134 us, Max = 1.158 us
IQR = 0.018 us, LowerFence = 1.088 us, UpperFence = 1.161 us
ConfidenceInterval = [1.104 us; 1.144 us] (CI 99.9%), Margin = 0.020 us (1.82% of Mean)
Skewness = 0.37, Kurtosis = 2.07, MValue = 2
-------------------- Histogram --------------------
[1.090 us ; 1.134 us) | @@@@@@@@@@@
[1.134 us ; 1.166 us) | @@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=18]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 1.061 us, StdErr = 0.004 us (0.41%), N = 15, StdDev = 0.017 us
Min = 1.025 us, Q1 = 1.050 us, Median = 1.068 us, Q3 = 1.074 us, Max = 1.080 us
IQR = 0.025 us, LowerFence = 1.013 us, UpperFence = 1.111 us
ConfidenceInterval = [1.043 us; 1.079 us] (CI 99.9%), Margin = 0.018 us (1.70% of Mean)
Skewness = -0.66, Kurtosis = 2.07, MValue = 2
-------------------- Histogram --------------------
[1.016 us ; 1.057 us) | @@@@@
[1.057 us ; 1.085 us) | @@@@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=19]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 949.613 ns, StdErr = 4.135 ns (0.44%), N = 15, StdDev = 16.017 ns
Min = 921.754 ns, Q1 = 934.250 ns, Median = 953.103 ns, Q3 = 961.827 ns, Max = 970.744 ns
IQR = 27.576 ns, LowerFence = 892.886 ns, UpperFence = 1,003.191 ns
ConfidenceInterval = [932.491 ns; 966.736 ns] (CI 99.9%), Margin = 17.123 ns (1.80% of Mean)
Skewness = -0.32, Kurtosis = 1.49, MValue = 2
-------------------- Histogram --------------------
[913.230 ns ; 945.863 ns) | @@@@@@
[945.863 ns ; 974.336 ns) | @@@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=20]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 1.063 us, StdErr = 0.005 us (0.44%), N = 15, StdDev = 0.018 us
Min = 1.039 us, Q1 = 1.045 us, Median = 1.061 us, Q3 = 1.079 us, Max = 1.091 us
IQR = 0.034 us, LowerFence = 0.994 us, UpperFence = 1.130 us
ConfidenceInterval = [1.044 us; 1.083 us] (CI 99.9%), Margin = 0.020 us (1.84% of Mean)
Skewness = 0.07, Kurtosis = 1.43, MValue = 2
-------------------- Histogram --------------------
[1.033 us ; 1.057 us) | @@@@@
[1.057 us ; 1.101 us) | @@@@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=21]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 1.041 us, StdErr = 0.004 us (0.34%), N = 14, StdDev = 0.013 us
Min = 1.017 us, Q1 = 1.030 us, Median = 1.043 us, Q3 = 1.052 us, Max = 1.058 us
IQR = 0.022 us, LowerFence = 0.997 us, UpperFence = 1.085 us
ConfidenceInterval = [1.026 us; 1.057 us] (CI 99.9%), Margin = 0.015 us (1.46% of Mean)
Skewness = -0.34, Kurtosis = 1.64, MValue = 2
-------------------- Histogram --------------------
[1.010 us ; 1.063 us) | @@@@@@@@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=22]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 1.098 us, StdErr = 0.004 us (0.38%), N = 15, StdDev = 0.016 us
Min = 1.070 us, Q1 = 1.083 us, Median = 1.103 us, Q3 = 1.110 us, Max = 1.121 us
IQR = 0.026 us, LowerFence = 1.044 us, UpperFence = 1.150 us
ConfidenceInterval = [1.081 us; 1.116 us] (CI 99.9%), Margin = 0.017 us (1.58% of Mean)
Skewness = -0.32, Kurtosis = 1.61, MValue = 2
-------------------- Histogram --------------------
[1.068 us ; 1.097 us) | @@@@@
[1.097 us ; 1.130 us) | @@@@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=23]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 1.667 us, StdErr = 0.005 us (0.27%), N = 15, StdDev = 0.018 us
Min = 1.637 us, Q1 = 1.657 us, Median = 1.668 us, Q3 = 1.680 us, Max = 1.692 us
IQR = 0.023 us, LowerFence = 1.623 us, UpperFence = 1.715 us
ConfidenceInterval = [1.648 us; 1.686 us] (CI 99.9%), Margin = 0.019 us (1.13% of Mean)
Skewness = -0.26, Kurtosis = 1.84, MValue = 2
-------------------- Histogram --------------------
[1.628 us ; 1.701 us) | @@@@@@@@@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=24]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 1.120 us, StdErr = 0.005 us (0.46%), N = 15, StdDev = 0.020 us
Min = 1.083 us, Q1 = 1.112 us, Median = 1.125 us, Q3 = 1.131 us, Max = 1.151 us
IQR = 0.020 us, LowerFence = 1.082 us, UpperFence = 1.161 us
ConfidenceInterval = [1.099 us; 1.141 us] (CI 99.9%), Margin = 0.021 us (1.88% of Mean)
Skewness = -0.42, Kurtosis = 2.05, MValue = 2
-------------------- Histogram --------------------
[1.078 us ; 1.110 us) | @@@
[1.110 us ; 1.157 us) | @@@@@@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=25]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 954.336 ns, StdErr = 2.704 ns (0.28%), N = 15, StdDev = 10.473 ns
Min = 936.124 ns, Q1 = 947.884 ns, Median = 954.149 ns, Q3 = 962.654 ns, Max = 974.236 ns
IQR = 14.770 ns, LowerFence = 925.730 ns, UpperFence = 984.808 ns
ConfidenceInterval = [943.140 ns; 965.533 ns] (CI 99.9%), Margin = 11.197 ns (1.17% of Mean)
Skewness = 0.07, Kurtosis = 2.05, MValue = 2
-------------------- Histogram --------------------
[930.550 ns ; 959.398 ns) | @@@@@@@@@@
[959.398 ns ; 979.810 ns) | @@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=26]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 981.566 ns, StdErr = 5.172 ns (0.53%), N = 24, StdDev = 25.338 ns
Min = 925.574 ns, Q1 = 965.044 ns, Median = 981.732 ns, Q3 = 1,001.563 ns, Max = 1,020.234 ns
IQR = 36.518 ns, LowerFence = 910.267 ns, UpperFence = 1,056.340 ns
ConfidenceInterval = [962.079 ns; 1,001.052 ns] (CI 99.9%), Margin = 19.487 ns (1.99% of Mean)
Skewness = -0.31, Kurtosis = 2.14, MValue = 2
-------------------- Histogram --------------------
[  914.045 ns ;   952.642 ns) | @@@
[  952.642 ns ;   978.869 ns) | @@@@@@
[  978.869 ns ; 1,001.927 ns) | @@@@@@@@@@
[1,001.927 ns ; 1,024.304 ns) | @@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=27]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 1.103 us, StdErr = 0.004 us (0.32%), N = 15, StdDev = 0.014 us
Min = 1.077 us, Q1 = 1.095 us, Median = 1.105 us, Q3 = 1.110 us, Max = 1.123 us
IQR = 0.015 us, LowerFence = 1.072 us, UpperFence = 1.133 us
ConfidenceInterval = [1.088 us; 1.117 us] (CI 99.9%), Margin = 0.015 us (1.32% of Mean)
Skewness = -0.39, Kurtosis = 2.16, MValue = 2
-------------------- Histogram --------------------
[1.070 us ; 1.130 us) | @@@@@@@@@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=28]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 1.147 us, StdErr = 0.005 us (0.44%), N = 15, StdDev = 0.019 us
Min = 1.106 us, Q1 = 1.137 us, Median = 1.149 us, Q3 = 1.163 us, Max = 1.171 us
IQR = 0.026 us, LowerFence = 1.098 us, UpperFence = 1.201 us
ConfidenceInterval = [1.126 us; 1.168 us] (CI 99.9%), Margin = 0.021 us (1.82% of Mean)
Skewness = -0.56, Kurtosis = 2.09, MValue = 2
-------------------- Histogram --------------------
[1.095 us ; 1.119 us) | @
[1.119 us ; 1.145 us) | @@@@@
[1.145 us ; 1.181 us) | @@@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=29]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 943.912 ns, StdErr = 3.420 ns (0.36%), N = 15, StdDev = 13.246 ns
Min = 925.533 ns, Q1 = 934.412 ns, Median = 941.393 ns, Q3 = 957.050 ns, Max = 966.658 ns
IQR = 22.637 ns, LowerFence = 900.456 ns, UpperFence = 991.006 ns
ConfidenceInterval = [929.751 ns; 958.073 ns] (CI 99.9%), Margin = 14.161 ns (1.50% of Mean)
Skewness = 0.22, Kurtosis = 1.52, MValue = 2
-------------------- Histogram --------------------
[925.274 ns ; 970.793 ns) | @@@@@@@@@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=30]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 964.512 ns, StdErr = 4.771 ns (0.49%), N = 19, StdDev = 20.797 ns
Min = 921.323 ns, Q1 = 952.680 ns, Median = 966.480 ns, Q3 = 977.280 ns, Max = 1,004.034 ns
IQR = 24.600 ns, LowerFence = 915.780 ns, UpperFence = 1,014.180 ns
ConfidenceInterval = [945.801 ns; 983.223 ns] (CI 99.9%), Margin = 18.711 ns (1.94% of Mean)
Skewness = -0.4, Kurtosis = 2.75, MValue = 2
-------------------- Histogram --------------------
[911.093 ns ;   932.392 ns) | @@
[932.392 ns ;   963.831 ns) | @@@@@@
[963.831 ns ;   984.290 ns) | @@@@@@@@@
[984.290 ns ; 1,007.574 ns) | @@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=31]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 1.024 us, StdErr = 0.004 us (0.37%), N = 15, StdDev = 0.015 us
Min = 0.987 us, Q1 = 1.019 us, Median = 1.023 us, Q3 = 1.036 us, Max = 1.042 us
IQR = 0.017 us, LowerFence = 0.993 us, UpperFence = 1.061 us
ConfidenceInterval = [1.008 us; 1.040 us] (CI 99.9%), Margin = 0.016 us (1.54% of Mean)
Skewness = -0.8, Kurtosis = 3.27, MValue = 2
-------------------- Histogram --------------------
[0.979 us ; 1.012 us) | @@
[1.012 us ; 1.050 us) | @@@@@@@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=32]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 828.582 ns, StdErr = 3.845 ns (0.46%), N = 15, StdDev = 14.890 ns
Min = 808.557 ns, Q1 = 814.233 ns, Median = 829.858 ns, Q3 = 841.571 ns, Max = 852.867 ns
IQR = 27.338 ns, LowerFence = 773.226 ns, UpperFence = 882.577 ns
ConfidenceInterval = [812.664 ns; 844.500 ns] (CI 99.9%), Margin = 15.918 ns (1.92% of Mean)
Skewness = 0.01, Kurtosis = 1.34, MValue = 2
-------------------- Histogram --------------------
[807.298 ns ; 828.432 ns) | @@@@@@@
[828.432 ns ; 860.791 ns) | @@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=33]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 1.082 us, StdErr = 0.002 us (0.23%), N = 13, StdDev = 0.009 us
Min = 1.068 us, Q1 = 1.075 us, Median = 1.084 us, Q3 = 1.087 us, Max = 1.100 us
IQR = 0.012 us, LowerFence = 1.057 us, UpperFence = 1.105 us
ConfidenceInterval = [1.071 us; 1.093 us] (CI 99.9%), Margin = 0.011 us (0.98% of Mean)
Skewness = 0.17, Kurtosis = 2.29, MValue = 2
-------------------- Histogram --------------------
[1.063 us ; 1.105 us) | @@@@@@@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=34]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 1.084 us, StdErr = 0.004 us (0.38%), N = 14, StdDev = 0.015 us
Min = 1.060 us, Q1 = 1.075 us, Median = 1.084 us, Q3 = 1.093 us, Max = 1.111 us
IQR = 0.018 us, LowerFence = 1.048 us, UpperFence = 1.121 us
ConfidenceInterval = [1.067 us; 1.101 us] (CI 99.9%), Margin = 0.017 us (1.58% of Mean)
Skewness = 0.08, Kurtosis = 1.96, MValue = 2
-------------------- Histogram --------------------
[1.057 us ; 1.120 us) | @@@@@@@@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=35]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 944.265 ns, StdErr = 3.405 ns (0.36%), N = 15, StdDev = 13.189 ns
Min = 919.909 ns, Q1 = 934.551 ns, Median = 948.629 ns, Q3 = 954.552 ns, Max = 963.472 ns
IQR = 20.000 ns, LowerFence = 904.551 ns, UpperFence = 984.552 ns
ConfidenceInterval = [930.166 ns; 958.365 ns] (CI 99.9%), Margin = 14.099 ns (1.49% of Mean)
Skewness = -0.27, Kurtosis = 1.68, MValue = 2
-------------------- Histogram --------------------
[912.890 ns ; 941.383 ns) | @@@@@@
[941.383 ns ; 970.491 ns) | @@@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=36]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 1.066 us, StdErr = 0.005 us (0.47%), N = 17, StdDev = 0.021 us
Min = 1.025 us, Q1 = 1.053 us, Median = 1.068 us, Q3 = 1.081 us, Max = 1.097 us
IQR = 0.028 us, LowerFence = 1.011 us, UpperFence = 1.123 us
ConfidenceInterval = [1.046 us; 1.086 us] (CI 99.9%), Margin = 0.020 us (1.88% of Mean)
Skewness = -0.29, Kurtosis = 1.89, MValue = 2
-------------------- Histogram --------------------
[1.020 us ; 1.047 us) | @@
[1.047 us ; 1.071 us) | @@@@@@@
[1.071 us ; 1.107 us) | @@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=37]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 1.094 us, StdErr = 0.004 us (0.35%), N = 15, StdDev = 0.015 us
Min = 1.070 us, Q1 = 1.084 us, Median = 1.092 us, Q3 = 1.103 us, Max = 1.123 us
IQR = 0.018 us, LowerFence = 1.057 us, UpperFence = 1.130 us
ConfidenceInterval = [1.078 us; 1.110 us] (CI 99.9%), Margin = 0.016 us (1.46% of Mean)
Skewness = 0.15, Kurtosis = 2.07, MValue = 2
-------------------- Histogram --------------------
[1.064 us ; 1.086 us) | @@@@
[1.086 us ; 1.127 us) | @@@@@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=38]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 1.047 us, StdErr = 0.005 us (0.45%), N = 15, StdDev = 0.018 us
Min = 1.018 us, Q1 = 1.029 us, Median = 1.054 us, Q3 = 1.059 us, Max = 1.074 us
IQR = 0.031 us, LowerFence = 0.982 us, UpperFence = 1.106 us
ConfidenceInterval = [1.027 us; 1.066 us] (CI 99.9%), Margin = 0.019 us (1.86% of Mean)
Skewness = -0.31, Kurtosis = 1.52, MValue = 2
-------------------- Histogram --------------------
[1.015 us ; 1.044 us) | @@@@@
[1.044 us ; 1.084 us) | @@@@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=39]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 1.061 us, StdErr = 0.004 us (0.37%), N = 15, StdDev = 0.015 us
Min = 1.036 us, Q1 = 1.052 us, Median = 1.063 us, Q3 = 1.072 us, Max = 1.088 us
IQR = 0.019 us, LowerFence = 1.023 us, UpperFence = 1.101 us
ConfidenceInterval = [1.045 us; 1.077 us] (CI 99.9%), Margin = 0.016 us (1.52% of Mean)
Skewness = -0.02, Kurtosis = 1.92, MValue = 2
-------------------- Histogram --------------------
[1.033 us ; 1.054 us) | @@@@
[1.054 us ; 1.096 us) | @@@@@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=40]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 1.095 us, StdErr = 0.002 us (0.23%), N = 15, StdDev = 0.010 us
Min = 1.083 us, Q1 = 1.088 us, Median = 1.097 us, Q3 = 1.102 us, Max = 1.112 us
IQR = 0.014 us, LowerFence = 1.068 us, UpperFence = 1.123 us
ConfidenceInterval = [1.085 us; 1.106 us] (CI 99.9%), Margin = 0.010 us (0.94% of Mean)
Skewness = 0.23, Kurtosis = 1.64, MValue = 2
-------------------- Histogram --------------------
[1.078 us ; 1.117 us) | @@@@@@@@@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=41]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 1.083 us, StdErr = 0.005 us (0.50%), N = 18, StdDev = 0.023 us
Min = 1.051 us, Q1 = 1.064 us, Median = 1.079 us, Q3 = 1.106 us, Max = 1.122 us
IQR = 0.042 us, LowerFence = 1.001 us, UpperFence = 1.168 us
ConfidenceInterval = [1.062 us; 1.104 us] (CI 99.9%), Margin = 0.021 us (1.97% of Mean)
Skewness = 0.22, Kurtosis = 1.55, MValue = 2
-------------------- Histogram --------------------
[1.039 us ; 1.081 us) | @@@@@@@@@@
[1.081 us ; 1.133 us) | @@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=42]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 1.048 us, StdErr = 0.004 us (0.40%), N = 15, StdDev = 0.016 us
Min = 1.004 us, Q1 = 1.043 us, Median = 1.050 us, Q3 = 1.058 us, Max = 1.073 us
IQR = 0.015 us, LowerFence = 1.021 us, UpperFence = 1.081 us
ConfidenceInterval = [1.031 us; 1.065 us] (CI 99.9%), Margin = 0.017 us (1.66% of Mean)
Skewness = -1.08, Kurtosis = 4.09, MValue = 2
-------------------- Histogram --------------------
[0.996 us ; 1.023 us) | @
[1.023 us ; 1.082 us) | @@@@@@@@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=43]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 1.080 us, StdErr = 0.005 us (0.48%), N = 16, StdDev = 0.021 us
Min = 1.039 us, Q1 = 1.068 us, Median = 1.078 us, Q3 = 1.092 us, Max = 1.119 us
IQR = 0.024 us, LowerFence = 1.033 us, UpperFence = 1.128 us
ConfidenceInterval = [1.058 us; 1.101 us] (CI 99.9%), Margin = 0.021 us (1.97% of Mean)
Skewness = -0.09, Kurtosis = 2.41, MValue = 2
-------------------- Histogram --------------------
[1.032 us ; 1.054 us) | @@
[1.054 us ; 1.084 us) | @@@@@@@@
[1.084 us ; 1.130 us) | @@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=44]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 1.169 us, StdErr = 0.005 us (0.42%), N = 15, StdDev = 0.019 us
Min = 1.145 us, Q1 = 1.154 us, Median = 1.166 us, Q3 = 1.175 us, Max = 1.207 us
IQR = 0.022 us, LowerFence = 1.121 us, UpperFence = 1.208 us
ConfidenceInterval = [1.148 us; 1.189 us] (CI 99.9%), Margin = 0.020 us (1.73% of Mean)
Skewness = 0.71, Kurtosis = 2.57, MValue = 2
-------------------- Histogram --------------------
[1.139 us ; 1.183 us) | @@@@@@@@@@@@@
[1.183 us ; 1.217 us) | @@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=45]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 960.352 ns, StdErr = 4.423 ns (0.46%), N = 16, StdDev = 17.693 ns
Min = 929.246 ns, Q1 = 943.661 ns, Median = 963.056 ns, Q3 = 971.676 ns, Max = 988.348 ns
IQR = 28.015 ns, LowerFence = 901.638 ns, UpperFence = 1,013.698 ns
ConfidenceInterval = [942.337 ns; 978.367 ns] (CI 99.9%), Margin = 18.015 ns (1.88% of Mean)
Skewness = -0.1, Kurtosis = 1.7, MValue = 2
-------------------- Histogram --------------------
[927.116 ns ; 952.267 ns) | @@@@@
[952.267 ns ; 993.951 ns) | @@@@@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=46]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 1.043 us, StdErr = 0.004 us (0.41%), N = 15, StdDev = 0.016 us
Min = 1.006 us, Q1 = 1.038 us, Median = 1.045 us, Q3 = 1.052 us, Max = 1.070 us
IQR = 0.014 us, LowerFence = 1.017 us, UpperFence = 1.073 us
ConfidenceInterval = [1.026 us; 1.061 us] (CI 99.9%), Margin = 0.018 us (1.68% of Mean)
Skewness = -0.61, Kurtosis = 2.77, MValue = 2
-------------------- Histogram --------------------
[0.998 us ; 1.032 us) | @@@
[1.032 us ; 1.077 us) | @@@@@@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=47]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 971.360 ns, StdErr = 4.940 ns (0.51%), N = 24, StdDev = 24.202 ns
Min = 910.046 ns, Q1 = 963.946 ns, Median = 975.921 ns, Q3 = 984.544 ns, Max = 1,012.076 ns
IQR = 20.598 ns, LowerFence = 933.049 ns, UpperFence = 1,015.442 ns
ConfidenceInterval = [952.747 ns; 989.973 ns] (CI 99.9%), Margin = 18.613 ns (1.92% of Mean)
Skewness = -1, Kurtosis = 3.59, MValue = 2
-------------------- Histogram --------------------
[906.893 ns ;   928.918 ns) | @@@
[928.918 ns ;   949.410 ns) |
[949.410 ns ;   969.766 ns) | @@@@@
[969.766 ns ;   996.515 ns) | @@@@@@@@@@@@@@
[996.515 ns ; 1,018.540 ns) | @@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=48]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 1.133 us, StdErr = 0.003 us (0.26%), N = 14, StdDev = 0.011 us
Min = 1.119 us, Q1 = 1.123 us, Median = 1.135 us, Q3 = 1.138 us, Max = 1.152 us
IQR = 0.016 us, LowerFence = 1.099 us, UpperFence = 1.162 us
ConfidenceInterval = [1.121 us; 1.146 us] (CI 99.9%), Margin = 0.012 us (1.08% of Mean)
Skewness = 0.2, Kurtosis = 1.65, MValue = 2
-------------------- Histogram --------------------
[1.113 us ; 1.158 us) | @@@@@@@@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=49]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 1.144 us, StdErr = 0.004 us (0.37%), N = 15, StdDev = 0.016 us
Min = 1.110 us, Q1 = 1.139 us, Median = 1.147 us, Q3 = 1.154 us, Max = 1.164 us
IQR = 0.015 us, LowerFence = 1.116 us, UpperFence = 1.177 us
ConfidenceInterval = [1.127 us; 1.161 us] (CI 99.9%), Margin = 0.017 us (1.52% of Mean)
Skewness = -0.87, Kurtosis = 2.62, MValue = 2
-------------------- Histogram --------------------
[1.101 us ; 1.138 us) | @@@@
[1.138 us ; 1.172 us) | @@@@@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=50]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 1.104 us, StdErr = 0.004 us (0.39%), N = 15, StdDev = 0.017 us
Min = 1.084 us, Q1 = 1.092 us, Median = 1.098 us, Q3 = 1.113 us, Max = 1.143 us
IQR = 0.021 us, LowerFence = 1.060 us, UpperFence = 1.145 us
ConfidenceInterval = [1.086 us; 1.122 us] (CI 99.9%), Margin = 0.018 us (1.60% of Mean)
Skewness = 0.87, Kurtosis = 2.7, MValue = 2
-------------------- Histogram --------------------
[1.075 us ; 1.107 us) | @@@@@@@@@@
[1.107 us ; 1.152 us) | @@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=51]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 1.105 us, StdErr = 0.005 us (0.47%), N = 15, StdDev = 0.020 us
Min = 1.068 us, Q1 = 1.089 us, Median = 1.108 us, Q3 = 1.118 us, Max = 1.135 us
IQR = 0.029 us, LowerFence = 1.045 us, UpperFence = 1.162 us
ConfidenceInterval = [1.084 us; 1.127 us] (CI 99.9%), Margin = 0.022 us (1.96% of Mean)
Skewness = -0.15, Kurtosis = 1.76, MValue = 2
-------------------- Histogram --------------------
[1.057 us ; 1.099 us) | @@@@@@
[1.099 us ; 1.146 us) | @@@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=52]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 1.068 us, StdErr = 0.005 us (0.47%), N = 15, StdDev = 0.020 us
Min = 1.024 us, Q1 = 1.064 us, Median = 1.069 us, Q3 = 1.081 us, Max = 1.097 us
IQR = 0.017 us, LowerFence = 1.038 us, UpperFence = 1.107 us
ConfidenceInterval = [1.048 us; 1.089 us] (CI 99.9%), Margin = 0.021 us (1.95% of Mean)
Skewness = -0.77, Kurtosis = 2.8, MValue = 2
-------------------- Histogram --------------------
[1.019 us ; 1.040 us) | @@
[1.040 us ; 1.064 us) | @@
[1.064 us ; 1.107 us) | @@@@@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=53]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 941.602 ns, StdErr = 4.606 ns (0.49%), N = 18, StdDev = 19.542 ns
Min = 906.642 ns, Q1 = 930.139 ns, Median = 950.277 ns, Q3 = 954.941 ns, Max = 969.121 ns
IQR = 24.801 ns, LowerFence = 892.937 ns, UpperFence = 992.143 ns
ConfidenceInterval = [923.339 ns; 959.866 ns] (CI 99.9%), Margin = 18.264 ns (1.94% of Mean)
Skewness = -0.5, Kurtosis = 1.75, MValue = 2
-------------------- Histogram --------------------
[901.011 ns ; 925.107 ns) | @@@@
[925.107 ns ; 944.808 ns) | @@@@
[944.808 ns ; 978.908 ns) | @@@@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=54]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 1.080 us, StdErr = 0.005 us (0.43%), N = 15, StdDev = 0.018 us
Min = 1.044 us, Q1 = 1.070 us, Median = 1.085 us, Q3 = 1.090 us, Max = 1.113 us
IQR = 0.020 us, LowerFence = 1.040 us, UpperFence = 1.120 us
ConfidenceInterval = [1.061 us; 1.100 us] (CI 99.9%), Margin = 0.019 us (1.80% of Mean)
Skewness = -0.09, Kurtosis = 2.3, MValue = 2
-------------------- Histogram --------------------
[1.035 us ; 1.074 us) | @@@@@@
[1.074 us ; 1.099 us) | @@@@@@@
[1.099 us ; 1.123 us) | @@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=55]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 995.023 ns, StdErr = 4.751 ns (0.48%), N = 15, StdDev = 18.402 ns
Min = 950.203 ns, Q1 = 986.987 ns, Median = 993.283 ns, Q3 = 1,007.718 ns, Max = 1,024.193 ns
IQR = 20.731 ns, LowerFence = 955.890 ns, UpperFence = 1,038.815 ns
ConfidenceInterval = [975.350 ns; 1,014.695 ns] (CI 99.9%), Margin = 19.673 ns (1.98% of Mean)
Skewness = -0.48, Kurtosis = 3.14, MValue = 2
-------------------- Histogram --------------------
[940.409 ns ;   978.313 ns) | @
[978.313 ns ; 1,025.218 ns) | @@@@@@@@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=56]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 1.071 us, StdErr = 0.004 us (0.40%), N = 15, StdDev = 0.017 us
Min = 1.050 us, Q1 = 1.057 us, Median = 1.075 us, Q3 = 1.080 us, Max = 1.108 us
IQR = 0.023 us, LowerFence = 1.023 us, UpperFence = 1.114 us
ConfidenceInterval = [1.053 us; 1.089 us] (CI 99.9%), Margin = 0.018 us (1.67% of Mean)
Skewness = 0.46, Kurtosis = 2.27, MValue = 2
-------------------- Histogram --------------------
[1.047 us ; 1.073 us) | @@@@@@@
[1.073 us ; 1.117 us) | @@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=57]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 1.091 us, StdErr = 0.005 us (0.48%), N = 18, StdDev = 0.022 us
Min = 1.053 us, Q1 = 1.072 us, Median = 1.093 us, Q3 = 1.109 us, Max = 1.129 us
IQR = 0.037 us, LowerFence = 1.016 us, UpperFence = 1.165 us
ConfidenceInterval = [1.070 us; 1.112 us] (CI 99.9%), Margin = 0.021 us (1.92% of Mean)
Skewness = -0.11, Kurtosis = 1.67, MValue = 2
-------------------- Histogram --------------------
[1.042 us ; 1.063 us) | @@
[1.063 us ; 1.086 us) | @@@@@@
[1.086 us ; 1.140 us) | @@@@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=58]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 1.100 us, StdErr = 0.005 us (0.48%), N = 15, StdDev = 0.020 us
Min = 1.073 us, Q1 = 1.080 us, Median = 1.103 us, Q3 = 1.119 us, Max = 1.128 us
IQR = 0.039 us, LowerFence = 1.022 us, UpperFence = 1.176 us
ConfidenceInterval = [1.079 us; 1.122 us] (CI 99.9%), Margin = 0.022 us (1.97% of Mean)
Skewness = -0.05, Kurtosis = 1.15, MValue = 2
-------------------- Histogram --------------------
[1.073 us ; 1.132 us) | @@@@@@@@@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=59]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 993.078 ns, StdErr = 3.347 ns (0.34%), N = 15, StdDev = 12.962 ns
Min = 971.014 ns, Q1 = 983.588 ns, Median = 991.286 ns, Q3 = 1,004.903 ns, Max = 1,010.840 ns
IQR = 21.315 ns, LowerFence = 951.615 ns, UpperFence = 1,036.876 ns
ConfidenceInterval = [979.220 ns; 1,006.935 ns] (CI 99.9%), Margin = 13.858 ns (1.40% of Mean)
Skewness = -0.04, Kurtosis = 1.57, MValue = 2
-------------------- Histogram --------------------
[964.115 ns ; 1,017.739 ns) | @@@@@@@@@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=60]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 940.330 ns, StdErr = 4.177 ns (0.44%), N = 15, StdDev = 16.179 ns
Min = 902.129 ns, Q1 = 938.833 ns, Median = 942.271 ns, Q3 = 950.599 ns, Max = 960.469 ns
IQR = 11.767 ns, LowerFence = 921.183 ns, UpperFence = 968.249 ns
ConfidenceInterval = [923.034 ns; 957.627 ns] (CI 99.9%), Margin = 17.296 ns (1.84% of Mean)
Skewness = -1.13, Kurtosis = 3.3, MValue = 2
-------------------- Histogram --------------------
[896.450 ns ; 919.618 ns) | @@
[919.618 ns ; 969.080 ns) | @@@@@@@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=61]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 967.098 ns, StdErr = 4.082 ns (0.42%), N = 15, StdDev = 15.810 ns
Min = 931.760 ns, Q1 = 959.763 ns, Median = 968.436 ns, Q3 = 975.444 ns, Max = 995.661 ns
IQR = 15.681 ns, LowerFence = 936.242 ns, UpperFence = 998.966 ns
ConfidenceInterval = [950.196 ns; 983.999 ns] (CI 99.9%), Margin = 16.901 ns (1.75% of Mean)
Skewness = -0.46, Kurtosis = 2.88, MValue = 2
-------------------- Histogram --------------------
[928.046 ns ; 957.001 ns) | @@
[957.001 ns ; 997.904 ns) | @@@@@@@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=62]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 990.469 ns, StdErr = 2.539 ns (0.26%), N = 15, StdDev = 9.835 ns
Min = 975.487 ns, Q1 = 984.213 ns, Median = 986.786 ns, Q3 = 1,000.300 ns, Max = 1,004.008 ns
IQR = 16.086 ns, LowerFence = 960.083 ns, UpperFence = 1,024.429 ns
ConfidenceInterval = [979.954 ns; 1,000.983 ns] (CI 99.9%), Margin = 10.514 ns (1.06% of Mean)
Skewness = 0.05, Kurtosis = 1.36, MValue = 2
-------------------- Histogram --------------------
[972.496 ns ; 1,009.243 ns) | @@@@@@@@@@@@@@@
---------------------------------------------------

AddArrays.SimdAdd: DefaultJob [ElemCount=4096, Offset=63]
Runtime = .NET 6.0.0 (6.0.21.45401), X64 RyuJIT; GC = Concurrent Workstation
Mean = 1.062 us, StdErr = 0.005 us (0.50%), N = 18, StdDev = 0.022 us
Min = 1.026 us, Q1 = 1.047 us, Median = 1.062 us, Q3 = 1.078 us, Max = 1.096 us
IQR = 0.031 us, LowerFence = 1.000 us, UpperFence = 1.125 us
ConfidenceInterval = [1.041 us; 1.083 us] (CI 99.9%), Margin = 0.021 us (1.97% of Mean)
Skewness = -0.01, Kurtosis = 1.76, MValue = 2
-------------------- Histogram --------------------
[1.017 us ; 1.043 us) | @@@
[1.043 us ; 1.065 us) | @@@@@@@@
[1.065 us ; 1.100 us) | @@@@@@@
---------------------------------------------------
```

</details>