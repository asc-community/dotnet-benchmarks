using BenchmarkDotNet.Attributes;
using System.Numerics;
using System.Runtime.Intrinsics.X86;

public class VectorVsVector256
{
    public const int CAPACITY = 16_000_000;
    [Params(160, 1_600, 16_000, 160_000, 1_600_000, 16_000_000)]
    public int Length { get; set; }
    public int[] a;
    public int[] b;
    public int[] c;

    [GlobalSetup]
    public void Setup()
    {
        a = new int[CAPACITY];
        b = new int[CAPACITY];
        c = new int[CAPACITY];
        for (int i = 0; i < CAPACITY; i++)
        {
            b[i] = i * 3;
            a[i] = i * 5;
        }
    }

    [Benchmark(Baseline = true)]
    public void NoVector()
    {
        unchecked
        {
            for (int i = 0; i < Length; i++)
                c[i] = a[i] * b[i];
        }
    }

    [Benchmark]
    public void VectorT()
    {
        unchecked
        {
            for (int i = 0; i < Length; i += 8)
            {
                var block1 = new Vector<int>(a, i);
                var block2 = new Vector<int>(b, i);
                var bl = block1 * block2;
                bl.CopyTo(c, i);
            }
        }
    }

    [Benchmark]
    public unsafe void Vector256T()
    {
        unchecked
        {
            fixed (int* ap = a, bp = b, cp = c)
            {
                for (int i = 0; i < Length; i += 8)
                {
                    var block1 = Avx2.LoadVector256(ap + i);
                    var block2 = Avx2.LoadVector256(bp + i);
                    var bl = Avx2.MultiplyLow(block1, block2);
                    Avx2.Store(cp + i, bl);
                }
            }
        }
    }
}

/*

i7-7700HQ

|     Method |   Length |             Mean |          Error |         StdDev | Ratio | RatioSD |
|----------- |--------- |-----------------:|---------------:|---------------:|------:|--------:|
|   NoVector |      160 |        199.57 ns |       1.731 ns |       1.619 ns |  1.00 |    0.00 |
|    VectorT |      160 |         47.97 ns |       0.526 ns |       0.492 ns |  0.24 |    0.00 |
| Vector256T |      160 |         19.82 ns |       0.401 ns |       0.335 ns |  0.10 |    0.00 |
|            |          |                  |                |                |       |         |
|   NoVector |     1600 |      1,883.08 ns |      34.066 ns |      30.199 ns |  1.00 |    0.00 |
|    VectorT |     1600 |        472.19 ns |       6.664 ns |       6.234 ns |  0.25 |    0.01 |
| Vector256T |     1600 |        152.49 ns |       2.973 ns |       2.781 ns |  0.08 |    0.00 |
|            |          |                  |                |                |       |         |
|   NoVector |    16000 |     19,166.22 ns |     352.569 ns |     294.411 ns |  1.00 |    0.00 |
|    VectorT |    16000 |      5,695.69 ns |     106.595 ns |     109.465 ns |  0.30 |    0.01 |
| Vector256T |    16000 |      2,611.60 ns |      51.638 ns |      84.842 ns |  0.14 |    0.01 |
|            |          |                  |                |                |       |         |
|   NoVector |   160000 |    203,053.19 ns |   4,048.488 ns |   8,178.145 ns |  1.00 |    0.00 |
|    VectorT |   160000 |     58,105.00 ns |   1,146.751 ns |   1,569.686 ns |  0.29 |    0.02 |
| Vector256T |   160000 |     43,851.32 ns |     863.055 ns |   1,237.767 ns |  0.21 |    0.01 |
|            |          |                  |                |                |       |         |
|   NoVector |  1600000 |  2,067,324.41 ns |  41,314.648 ns |  82,509.815 ns |  1.00 |    0.00 |
|    VectorT |  1600000 |  1,299,171.61 ns |  25,956.609 ns |  56,427.532 ns |  0.63 |    0.04 |
| Vector256T |  1600000 |  1,205,481.25 ns |  22,643.346 ns |  25,168.019 ns |  0.59 |    0.02 |
|            |          |                  |                |                |       |         |
|   NoVector | 16000000 | 20,411,832.08 ns | 394,841.798 ns | 369,335.263 ns |  1.00 |    0.00 |
|    VectorT | 16000000 | 12,051,374.15 ns | 240,450.404 ns | 312,653.444 ns |  0.59 |    0.02 |
| Vector256T | 16000000 | 11,653,012.50 ns | 167,229.207 ns | 139,643.962 ns |  0.57 |    0.01 |

*/