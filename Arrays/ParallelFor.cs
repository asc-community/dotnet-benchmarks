/*
 *  Results of benchmark for i7-7700HQ are at the end of the file
 */

using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace Arrays
{
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

        [Benchmark]
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

|--------------------- |------ |----------:|----------:|----------:|
|     ParallelForNaive |   128 |  3.804 us | 0.0162 us | 0.0136 us |
|     ParallelForBatch |   128 |  3.139 us | 0.0493 us | 0.0462 us |
| ParallelForBatchSimd |   128 |  3.119 us | 0.0506 us | 0.0473 us |
|     ParallelForNaive |  1024 |  8.546 us | 0.0489 us | 0.0457 us |
|     ParallelForBatch |  1024 |  3.855 us | 0.0269 us | 0.0225 us |
| ParallelForBatchSimd |  1024 |  3.299 us | 0.0434 us | 0.0385 us |
|     ParallelForNaive |  8192 | 17.545 us | 0.2511 us | 0.2349 us |
|     ParallelForBatch |  8192 |  6.300 us | 0.0149 us | 0.0140 us |
| ParallelForBatchSimd |  8192 |  4.608 us | 0.0264 us | 0.0247 us |
|     ParallelForNaive | 65536 | 75.179 us | 1.1303 us | 1.0573 us |
|     ParallelForBatch | 65536 | 19.142 us | 0.2403 us | 0.2130 us |
| ParallelForBatchSimd | 65536 | 10.735 us | 0.0306 us | 0.0286 us |

 */