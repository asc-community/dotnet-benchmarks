/*
 *  Results of benchmark for i7-7700HQ are at the end of the file
 */

using System;
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
        private const int SIZE = 10000;

        [GlobalSetup]
        public void Setup()
        { 
            //var arr = new int[SIZE];
            //arr1 = (int*)Unsafe.AsPointer(ref arr);
            //arr = new int[SIZE];
            //arr2 = (int*)Unsafe.AsPointer(ref arr);
            //arr = new int[SIZE];
            //arr3 = (int*)Unsafe.AsPointer(ref arr);
            arr1 = (int*)Marshal.AllocHGlobal(SIZE * sizeof(int));
            arr2 = (int*)Marshal.AllocHGlobal(SIZE * sizeof(int));
            arr3 = (int*)Marshal.AllocHGlobal(SIZE * sizeof(int));
        }

        [Benchmark]
        public void ParallelForNaive()
        {
            Parallel.For(0, SIZE, i => *(arr1 + i) = *(arr2 + i) + *(arr3 + i));
        }

        [Benchmark]
        public void ParallelForBatch()
        {
            const int Threads = 16;
            Parallel.For(0, Threads, 
                id => {
                    var lArr1 = arr1;
                    var lArr2 = arr2;
                    var lArr3 = arr3;
                    var startId = SIZE / Threads * id;
                    var finishId = SIZE / Threads * (id + 1);
                    for (int i = startId; i < finishId; i++)
                        *(lArr1 + i) = *(lArr2 + i) + *(lArr3 + i);
                });
        }
    }
}
