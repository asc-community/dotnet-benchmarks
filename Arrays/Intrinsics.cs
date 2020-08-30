using BenchmarkDotNet.Attributes;
using System.Numerics;
using System.Runtime.CompilerServices;
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
    public unsafe void NoVector()
    {
        unchecked
        {
            fixed (int* ap = a, bp = b, cp = c)
            {
                for (int i = 0; i < Length; i++)
                    cp[i] = ap[i] * bp[i];
            }
        }
    }
    
    [Benchmark]
    public unsafe void VectorT()
    {
        unchecked
        {
            fixed (int* ap = a, bp = b, cp = c)
            {
                for (int i = 0; i < Length; i += 8)
                {
                    var block1 = *(Vector<int>*)(ap + i);
                    var block2 = *(Vector<int>*)(bp + i);
                    *(Vector<int>*)(cp + i) = block1 * block2;
                }
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

|     Method |   Length |             Mean |          Error |         StdDev |           Median | Ratio | RatioSD |
|----------- |--------- |-----------------:|---------------:|---------------:|-----------------:|------:|--------:|
|   NoVector |      160 |        117.27 ns |       1.054 ns |       0.880 ns |        116.94 ns |  1.00 |    0.00 |
|    VectorT |      160 |         19.99 ns |       0.417 ns |       0.480 ns |         19.90 ns |  0.17 |    0.00 |
| Vector256T |      160 |         19.50 ns |       0.361 ns |       0.338 ns |         19.43 ns |  0.17 |    0.00 |
|            |          |                  |                |                |                  |       |         |
|   NoVector |     1600 |      1,070.47 ns |       9.314 ns |       7.272 ns |      1,072.03 ns |  1.00 |    0.00 |
|    VectorT |     1600 |        168.75 ns |       3.239 ns |       3.030 ns |        169.31 ns |  0.16 |    0.00 |
| Vector256T |     1600 |        153.90 ns |       3.090 ns |       4.125 ns |        153.01 ns |  0.15 |    0.00 |
|            |          |                  |                |                |                  |       |         |
|   NoVector |    16000 |     11,140.08 ns |     217.774 ns |     305.288 ns |     11,104.45 ns |  1.00 |    0.00 |
|    VectorT |    16000 |      2,601.62 ns |      33.129 ns |      29.368 ns |      2,601.89 ns |  0.23 |    0.01 |
| Vector256T |    16000 |      2,606.40 ns |      30.515 ns |      27.051 ns |      2,604.79 ns |  0.23 |    0.01 |
|            |          |                  |                |                |                  |       |         |
|   NoVector |   160000 |    112,583.93 ns |   2,024.219 ns |   1,794.417 ns |    112,123.37 ns |  1.00 |    0.00 |
|    VectorT |   160000 |     43,904.00 ns |     634.792 ns |     593.785 ns |     43,888.51 ns |  0.39 |    0.01 |
| Vector256T |   160000 |     43,470.56 ns |     733.789 ns |     720.679 ns |     43,172.89 ns |  0.39 |    0.01 |
|            |          |                  |                |                |                  |       |         |
|   NoVector |  1600000 |  1,395,028.32 ns |  19,602.973 ns |  18,336.633 ns |  1,399,623.44 ns |  1.00 |    0.00 |
|    VectorT |  1600000 |  1,039,098.82 ns |  30,624.182 ns |  90,296.093 ns |  1,000,621.19 ns |  0.85 |    0.05 |
| Vector256T |  1600000 |  1,097,105.87 ns |  21,939.680 ns |  48,158.129 ns |  1,091,926.32 ns |  0.78 |    0.06 |
|            |          |                  |                |                |                  |       |         |
|   NoVector | 16000000 | 14,293,466.20 ns | 278,722.532 ns | 309,799.356 ns | 14,160,007.81 ns |  1.00 |    0.00 |
|    VectorT | 16000000 | 11,581,997.24 ns | 132,511.740 ns | 110,653.305 ns | 11,581,384.38 ns |  0.81 |    0.02 |
| Vector256T | 16000000 | 11,712,245.86 ns | 224,194.448 ns | 230,231.192 ns | 11,628,498.44 ns |  0.82 |    0.03 |

*/