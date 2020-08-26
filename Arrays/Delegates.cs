/*
 *  Results of benchmark for i7-7700HQ are at the end of the file
 */

using System;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;

namespace Arrays
{
    public class BenchArrays
    {
        [Params(100, 1000, 10000)]
        public int Length { get; set; }
        public const int CAPACITY = 10000;

        public readonly int[] a = new int[CAPACITY];
        public readonly int[] b = new int[CAPACITY];
        public readonly int[] c = new int[CAPACITY];

        [GlobalSetup]
        public void Setup()
        {
            for (int i = 0; i < Length; i++)
            {
                unchecked
                {
                    a[i] = i * i;
                    b[i] = i * i * i;
                }
            }
        }

        [Benchmark]
        [MethodImpl(MethodImplOptions.NoOptimization)]
        public void PureLoopNoOptimization()
        {
            var locA = a;
            var locB = b;
            var locC = c;
            for (int i = 0; i < Length; i++)
            {
                unchecked
                {
                    locC[i] = locA[i] + locB[i];
                }
            }
        }

        [Benchmark]
        public void PureLoop()
        {
            var locA = a;
            var locB = b;
            var locC = c;
            for (int i = 0; i < Length; i++)
            {
                unchecked
                {
                    locC[i] = locA[i] + locB[i];
                }
            }
        }

        public readonly Func<int, int, int> Add = (a, b) => unchecked(a + b);

        [Benchmark]
        [MethodImpl(MethodImplOptions.NoOptimization)]
        public void CallDelegateInLoopNoOptimization()
        {
            var locA = a;
            var locB = b;
            var locC = c;
            for (int i = 0; i < Length; i++)
                locC[i] = Add(locA[i], locB[i]);
        }

        [Benchmark]
        public void CallDelegateInLoop()
        {
            var locA = a;
            var locB = b;
            var locC = c;
            for (int i = 0; i < Length; i++)
                locC[i] = Add(locA[i], locB[i]);
        }

        public readonly Action<int[], int[], int[], int> FullLoop = (a, b, c, locLength) =>
        {
            for (int i = 0; i < locLength; i++)
            {
                unchecked
                {
                    c[i] = a[i] + b[i];
                }
            }
        };

        [Benchmark]
        [MethodImpl(MethodImplOptions.NoOptimization)]
        public void CallDelegateNoOptimization()
        {
            FullLoop(a, b, c, Length);
        }

        [Benchmark]
        public void CallDelegate()
        {
            FullLoop(a, b, c, Length);
        }
    }
}


/*

|                           Method | Length |         Mean |      Error |     StdDev |
|--------------------------------- |------- |-------------:|-----------:|-----------:|
|           PureLoopNoOptimization |    100 |    308.77 ns |   5.890 ns |   5.785 ns |
|                         PureLoop |    100 |     89.21 ns |   0.684 ns |   0.606 ns |
| CallDelegateInLoopNoOptimization |    100 |    539.78 ns |  10.492 ns |  10.305 ns |
|               CallDelegateInLoop |    100 |    220.21 ns |   1.622 ns |   1.517 ns |
|       CallDelegateNoOptimization |    100 |     72.90 ns |   0.627 ns |   0.523 ns |
|                     CallDelegate |    100 |     70.48 ns |   0.731 ns |   0.684 ns |
|           PureLoopNoOptimization |   1000 |  2,906.22 ns |  34.718 ns |  32.475 ns |
|                         PureLoop |   1000 |    847.84 ns |  16.685 ns |  22.839 ns |
| CallDelegateInLoopNoOptimization |   1000 |  4,670.09 ns |  43.089 ns |  38.197 ns |
|               CallDelegateInLoop |   1000 |  2,155.94 ns |  35.198 ns |  34.569 ns |
|       CallDelegateNoOptimization |   1000 |    629.08 ns |  11.863 ns |   9.906 ns |
|                     CallDelegate |   1000 |    635.41 ns |   9.149 ns |   8.111 ns |
|           PureLoopNoOptimization |  10000 | 30,460.60 ns | 585.865 ns | 840.231 ns |
|                         PureLoop |  10000 |  8,481.05 ns | 164.510 ns | 219.616 ns |
| CallDelegateInLoopNoOptimization |  10000 | 46,725.67 ns | 436.313 ns | 386.780 ns |
|               CallDelegateInLoop |  10000 | 21,587.40 ns | 398.567 ns | 372.820 ns |
|       CallDelegateNoOptimization |  10000 |  6,199.72 ns | 108.509 ns |  96.190 ns |
|                     CallDelegate |  10000 |  6,356.80 ns | 121.489 ns | 119.318 ns |

 */