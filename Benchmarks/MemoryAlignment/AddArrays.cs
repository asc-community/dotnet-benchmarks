
using BenchmarkDotNet.Attributes;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

public unsafe class AddArrays
{
    private static T* Allocate<T>(int elemCount, int offsetFromAligned) where T : unmanaged
    {
        var toalloc = (nuint)(elemCount * sizeof(T) + offsetFromAligned);
        return (T*)((byte*)NativeMemory.AlignedAlloc(toalloc, 64) + offsetFromAligned);
    }

    [Params(0x1000)]
    public int ElemCount;

    [Params(0,  1,  2,  3,  4,  5,  6,  7,  8,  9,  10, 11, 12, 13, 14, 15,
            16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31,
            32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47,
            48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63)]
    public int Offset;

    private int* a;
    private int* b;
    private int* c;

    [GlobalSetup]
    public void Setup()
    {
        a = Allocate<int>(ElemCount, Offset);
        b = Allocate<int>(ElemCount, Offset);
        c = Allocate<int>(ElemCount, Offset);
        var rand = new Random(100);
        for (int i = 0; i < ElemCount; i++)
        {
            a[i] = rand.Next();
            b[i] = rand.Next();
        }
    }

    /*
    [Benchmark]
    public int NaiveAdd()
    {
        var e = ElemCount;
        for (int i = 0; i < e; i++)
            c[i] = a[i] + b[i];
        return c[Math.Abs(a[0] + b[e / 2]) % e];
    }*/

    [Benchmark]
    public int SimdAdd()
    {
        var e = ElemCount;
        for (int i = 0; i < e; i += Vector256<int>.Count)
        {
            var av = Avx2.LoadVector256(a + i);
            var bv = Avx2.LoadVector256(b + i);
            Avx2.Store(c + i, Avx2.Add(av, bv));
        }
        return c[Math.Abs(a[0] + b[e / 2]) % e];
    }
}