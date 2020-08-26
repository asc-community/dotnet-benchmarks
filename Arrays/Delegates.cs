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
            for (int i = 0; i < LENGTH; i++)
            {
                unchecked
                {
                    c[i] = a[i] + b[i];
                }
            }
        }

        public readonly Func<int, int, int> Add = (a, b) => unchecked(a + b);

        [Benchmark]
        [MethodImpl(MethodImplOptions.NoOptimization)]
        public void CallDelegateInLoop()
        {
            for (int i = 0; i < LENGTH; i++)
                c[i] = Add(a[i], b[i]);
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

No NoOptimization attribute

100:

|             Method |      Mean |    Error |   StdDev |
|------------------- |----------:|---------:|---------:|
|           PureLoop | 108.91 ns | 2.214 ns | 3.878 ns |
| CallDelegateInLoop | 281.05 ns | 3.851 ns | 3.602 ns |
|       CallDelegate |  79.36 ns | 0.743 ns | 0.659 ns |

1000:
|             Method |       Mean |    Error |   StdDev |
|------------------- |-----------:|---------:|---------:|
|           PureLoop | 1,041.2 ns | 18.65 ns | 17.44 ns |
| CallDelegateInLoop | 2,305.7 ns | 46.14 ns | 74.50 ns |
|       CallDelegate |   538.4 ns | 10.80 ns | 10.10 ns |

10000:
|             Method |      Mean |     Error |    StdDev |
|------------------- |----------:|----------:|----------:|
|           PureLoop | 10.261 us | 0.2030 us | 0.2417 us |
| CallDelegateInLoop | 27.037 us | 0.5253 us | 0.6451 us |
|       CallDelegate |  5.183 us | 0.0911 us | 0.1119 us |


With NoOptimization attribute


100:

|             Method |      Mean |    Error |    StdDev |
|------------------- |----------:|---------:|----------:|
|           PureLoop | 365.52 ns | 7.141 ns |  9.533 ns |
| CallDelegateInLoop | 516.24 ns | 9.957 ns | 12.947 ns |
|       CallDelegate |  74.91 ns | 0.455 ns |  0.403 ns |


1000: 

|             Method |       Mean |    Error |   StdDev |
|------------------- |-----------:|---------:|---------:|
|           PureLoop | 3,521.6 ns | 62.86 ns | 77.20 ns |
| CallDelegateInLoop | 4,995.9 ns | 58.02 ns | 54.27 ns |
|       CallDelegate |   672.2 ns | 12.86 ns | 14.81 ns |

10000:
|             Method |      Mean |     Error |    StdDev |
|------------------- |----------:|----------:|----------:|
|           PureLoop | 35.359 us | 0.4101 us | 0.3424 us |
| CallDelegateInLoop | 50.216 us | 0.3358 us | 0.3141 us |
|       CallDelegate |  5.115 us | 0.0906 us | 0.0803 us |
 *
 */