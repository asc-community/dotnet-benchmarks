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
