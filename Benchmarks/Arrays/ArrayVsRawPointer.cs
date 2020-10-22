using System;
using System.Linq;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;

public class ArrayVsRawPointer
{
    // TODO: replace a const with [Params]
    // but keep in mind LENGTH is used in Setup
    public const int LENGTH = 1_000;

    public int slowChaoticId = 0;
    public int fastChaoticId = 0;
    public int slowRowId = 0;
    public int fastRowId = 0;

    [GlobalSetup]
    public unsafe void Setup()
    {
        slowChaoticId = 0;
        fastChaoticId = 0;
        slowRowId = 0;
        fastRowId = 0;
        arrSlow = new int[LENGTH];
        for (int i = 0; i < LENGTH; i++)
            arrSlow[i] = i;
        var r = new Random();
        arrSlow = arrSlow.OrderBy(c => r.Next(0, LENGTH)).ToArray();

        arrFast = (int*)Marshal.AllocHGlobal(LENGTH * sizeof(int)).ToPointer();
        for (int i = 0; i < LENGTH; i++)
            arrFast[i] = arrSlow[i];
    }

    [GlobalCleanup]
    public unsafe void Cleanup()
    {
        Marshal.FreeHGlobal((IntPtr)arrFast);
    }

    public int[] arrSlow;
    public unsafe int* arrFast;


    [Benchmark]
    public void TestSlowChaotic()
    {
        slowChaoticId = arrSlow[slowChaoticId];
    }

    [Benchmark]
    public unsafe void TestFastChaotic()
    {
        fastChaoticId = arrFast[fastChaoticId];
    }

    [Benchmark]
    public void TestSlowRow()
    {
        var _ = arrSlow[slowRowId];
        slowRowId++;
        if (slowRowId >= LENGTH)
            slowRowId = 0;
    }

    [Benchmark]
    public unsafe void TestFastRow()
    {
        var _ = arrFast[fastRowId];
        fastRowId++;
        if (fastRowId >= LENGTH)
            fastRowId = 0;
    }
}

/*
Outdated

|          Method |        10 |     1_000 |    30_000 |  1_000_000 | 16_000_000 |
|---------------- |----------:|----------:|----------:|-----------:|-----------:|
| TestSlowChaotic | 0.9583 ns | 1.0177 ns | 2.8141 ns | 21.2463 ns | 86.9868 ns |
| TestFastChaotic | 0.9741 ns | 0.9583 ns | 2.7750 ns | 24.7405 ns | 86.9611 ns |
|     TestSlowRow | 0.8036 ns | 0.7278 ns | 0.7230 ns |  0.7543 ns |  0.6666 ns |
|     TestFastRow | 0.3722 ns | 0.3746 ns | 0.3648 ns |  0.6517 ns |  0.5979 ns |
 
 */