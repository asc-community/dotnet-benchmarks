/*
 *  Results of benchmark for i7-7700HQ are at the end of the file
 */

using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Arrays
{
    [SkewnessColumn, KurtosisColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public unsafe class ParallelFor
    {
        private int* arr1;
        private int* arr2;
        private int* arr3;
        private const int CAPACITY = 4_000_000;
        
        [Params(128, 128 * 8, 128 * 8 * 8, 128 * 8 * 8 * 8)]
        public int Size { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            arr1 = (int*)Marshal.AllocHGlobal(CAPACITY * sizeof(int));
            arr2 = (int*)Marshal.AllocHGlobal(CAPACITY * sizeof(int));
            arr3 = (int*)Marshal.AllocHGlobal(CAPACITY * sizeof(int));
        }

        [Benchmark(Baseline = true)]
        public void ParallelForNaive()
        {
            Parallel.For(0, Size, i => *(arr1 + i) = *(arr2 + i) + *(arr3 + i));
        }

        private const int Threads = 16;
        
        [Benchmark]
        public void ParallelForBatch()
        {
            Parallel.For(0, Threads, 
                id => {
                    var lArr1 = arr1;
                    var lArr2 = arr2;
                    var lArr3 = arr3;
                    var startId = Size / Threads * id;
                    var finishId = Size / Threads * (id + 1);
                    for (int i = startId; i < finishId; i++)
                        *(lArr1 + i) = *(lArr2 + i) + *(lArr3 + i);
                });
        }

        [Benchmark]
        public void ParallelForBatchSimd()
        {            
            Parallel.For(0, Threads,
                id => {
                    var lArr1 = arr1;
                    var lArr2 = arr2;
                    var lArr3 = arr3;
                    var startId = Size / Threads * id;
                    var finishId = Size / Threads * (id + 1);
                    var c = Vector<int>.Count;
                    for (int i = startId; i < finishId; i += c)
                    {
                        var vec1 = *(Vector<int>*)(lArr1 + i);
                        var vec2 = *(Vector<int>*)(lArr2 + i);
                        *(Vector<int>*)(lArr3 + i) = vec1 + vec2;
                    }
                });
        }
    }
}

/*

|               Method |  Size |      Mean |     Error |    StdDev | Skewness | Kurtosis | Ratio | RatioSD |
|--------------------- |------ |----------:|----------:|----------:|---------:|---------:|------:|--------:|
| ParallelForBatchSimd |   128 |  3.030 us | 0.0473 us | 0.0443 us |   0.3389 |    1.817 |  0.79 |    0.01 |
|     ParallelForBatch |   128 |  3.226 us | 0.0607 us | 0.0623 us |  -0.5232 |    1.542 |  0.84 |    0.02 |
|     ParallelForNaive |   128 |  3.817 us | 0.0344 us | 0.0322 us |  -0.4436 |    1.810 |  1.00 |    0.00 |
|                      |       |           |           |           |          |          |       |         |
| ParallelForBatchSimd |  1024 |  3.286 us | 0.0591 us | 0.0552 us |   0.8498 |    2.142 |  0.38 |    0.01 |
|     ParallelForBatch |  1024 |  3.968 us | 0.0546 us | 0.0511 us |   0.2136 |    2.525 |  0.46 |    0.01 |
|     ParallelForNaive |  1024 |  8.548 us | 0.0459 us | 0.0429 us |  -0.5724 |    2.300 |  1.00 |    0.00 |
|                      |       |           |           |           |          |          |       |         |
| ParallelForBatchSimd |  8192 |  4.776 us | 0.0653 us | 0.0611 us |   0.0559 |    2.010 |  0.27 |    0.01 |
|     ParallelForBatch |  8192 |  6.402 us | 0.0230 us | 0.0216 us |   0.1045 |    2.139 |  0.37 |    0.01 |
|     ParallelForNaive |  8192 | 17.450 us | 0.2988 us | 0.3778 us |   0.1228 |    2.103 |  1.00 |    0.00 |
|                      |       |           |           |           |          |          |       |         |
| ParallelForBatchSimd | 65536 | 10.768 us | 0.0642 us | 0.0601 us |  -0.5767 |    2.684 |  0.14 |    0.00 |
|     ParallelForBatch | 65536 | 20.390 us | 0.4062 us | 0.4171 us |  -0.3309 |    1.512 |  0.26 |    0.01 |
|     ParallelForNaive | 65536 | 80.463 us | 1.5860 us | 2.7358 us |  -0.0386 |    2.190 |  1.00 |    0.00 |

 */