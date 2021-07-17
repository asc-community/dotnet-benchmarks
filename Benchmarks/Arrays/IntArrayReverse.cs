using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public unsafe class IntArrayReversing
    {
        [Params(0x10_000, 0x100_000, 0x1_000_000, 0x10_000_000)]
        public int ArrayLength { get; set; }

        private int[] array;

        [GlobalSetup]
        public void Setup()
        {
            var random = new Random(4);
            array = Enumerable.Range(0, ArrayLength).ToArray();
        }

        [Benchmark]
        public void SwapLinear()
        {
            var len = array.Length;
            for (int i = 0; i < len / 2; i++)
                (array[i], array[len - i - 1]) = (array[len - i - 1], array[i]);
        }

        [Benchmark]
        public void SwapBatch()
        {
            fixed (int* ptr = array)
            {
                var v = (Vector256<int>*)ptr;
                var lenOuter = array.Length * sizeof(int) / sizeof(Vector256<int>);
                for (int i = 0; i < lenOuter / 2; i++)
                    (v[i], v[lenOuter - i - 1]) = (v[lenOuter - i - 1], v[i]);
                for (int i = 0; i < lenOuter / 2; i++)
                {
                    var vec = v[i];
                    var vecPtr = (int*)&vec;
                    (vecPtr[0], vecPtr[7]) = (vecPtr[7], vecPtr[0]);
                    (vecPtr[1], vecPtr[6]) = (vecPtr[6], vecPtr[1]);
                    (vecPtr[2], vecPtr[5]) = (vecPtr[5], vecPtr[2]);
                    (vecPtr[3], vecPtr[4]) = (vecPtr[4], vecPtr[3]);
                }
            }
        }
    }
}
