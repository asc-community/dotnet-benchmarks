using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using BenchmarkUtils;

namespace BasicConstructions
{
    public class Recursion
    {
        [GlobalSetup]
        public void Setup()
        {

        }

        private const int NumberCount = 10; // shouldn't be too high to avoid benching RAM
        private const int IterCount = 10;
        private const int RandomSeed = 10;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int FromIterToNumber(int id) => id + 100;

        public static int GCDRec(int a, int b)
        {
            if (a == 0)
                return b;
            if (b == 0)
                return a;
            if (a > b)
                return GCDRec(a % b, b);
            else
                return GCDRec(a, b % a);
        }

        [Benchmark]
        public void BenchRecursion()
        {
            
            var sm = new SequentialRandom(new Random(RandomSeed), NumberCount);
            for (int i = 0; i < IterCount; i++)
            {
                for (int x = 0; x < NumberCount; x++)
                {
                    GCDRec(FromIterToNumber(sm.Next()), FromIterToNumber(sm.Next()));
                }
            }
        }

        public static int GCDLoop(int a, int b)
        {
            while (b > 0)
            {
                (a, b) = (b, a % b);
            }
            return a == 0 ? b : a;
        }

        [Benchmark]
        public void BenchWhile()
        {
            var sm = new SequentialRandom(new Random(RandomSeed), NumberCount);
            for (int i = 0; i < IterCount; i++)
            {
                for (int x = 0; x < NumberCount; x++)
                {
                    GCDLoop(FromIterToNumber(sm.Next()), FromIterToNumber(sm.Next()));
                }
            }
        }
    }
}

/*
 
BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1139 (1909/November2018Update/19H2)
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.100-rc.2.20479.15
  [Host]     : .NET Core 3.1.7 (CoreCLR 4.700.20.36602, CoreFX 4.700.20.37001), X64 RyuJIT
  DefaultJob : .NET Core 3.1.7 (CoreCLR 4.700.20.36602, CoreFX 4.700.20.37001), X64 RyuJIT


|         Method |     Mean |     Error |    StdDev |
|--------------- |---------:|----------:|----------:|
| BenchRecursion | 3.142 us | 0.0587 us | 0.0628 us |
|     BenchWhile | 3.057 us | 0.0564 us | 0.0528 us |
 
 */