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
        public const int LENGTH = 10000;

        public readonly int[] a = new int[LENGTH];
        public readonly int[] b = new int[LENGTH];
        public readonly int[] c = new int[LENGTH];

        [GlobalSetup]
        public void Setup()
        {
            for (int i = 0; i < LENGTH; i++)
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
        public void PureLoop()
        {
            var locA = a;
            var locB = b;
            var locC = c;
            for (int i = 0; i < LENGTH; i++)
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
        public void CallDelegateInLoop()
        {
            var locA = a;
            var locB = b;
            var locC = c;
            for (int i = 0; i < LENGTH; i++)
                locC[i] = Add(locA[i], locB[i]);
        }

        public readonly Action<int[], int[], int[]> FullLoop = (a, b, c) =>
        {
            for (int i = 0; i < LENGTH; i++)
            {
                unchecked
                {
                    c[i] = a[i] + b[i];
                }
            }
        };

        [Benchmark]
        [MethodImpl(MethodImplOptions.NoOptimization)]
        public void CallDelegate()
        {
            FullLoop(a, b, c);
        }
    }
}


/*

100:

|             Method |      Mean |    Error |    StdDev |
|------------------- |----------:|---------:|----------:|
|           PureLoop | 291.68 ns | 5.852 ns | 12.086 ns |
| CallDelegateInLoop | 449.32 ns | 8.251 ns | 12.601 ns |
|       CallDelegate |  75.28 ns | 0.601 ns |  0.533 ns |


1000:

|             Method |       Mean |    Error |    StdDev |     Median |
|------------------- |-----------:|---------:|----------:|-----------:|
|           PureLoop | 2,698.3 ns | 38.00 ns |  33.69 ns | 2,684.3 ns |
| CallDelegateInLoop | 4,386.3 ns | 87.37 ns | 225.54 ns | 4,270.2 ns |
|       CallDelegate |   521.6 ns |  8.75 ns |   7.31 ns |   521.6 ns |


10000:

|             Method |      Mean |     Error |    StdDev |
|------------------- |----------:|----------:|----------:|
|           PureLoop | 26.853 us | 0.5344 us | 0.6758 us |
| CallDelegateInLoop | 41.980 us | 0.6852 us | 0.6074 us |
|       CallDelegate |  5.026 us | 0.0309 us | 0.0289 us |

 */