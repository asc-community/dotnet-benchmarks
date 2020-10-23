using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexedCollectionAbstractions
{
    public class LazyNDArray
    {
        public int this[params int[] ids]
        {
            get
            {
                var sum = 0;
                var length = ids.Length; // caching to guarantee no reuse of potentially expensive Length
                for (int i = 0; i < length; i++)
                    sum += ids[i];
                return sum;
            }
        }
    }

    public class OverloadedNDArray
    {
        public int this[int a] => a;
        public int this[int a, params int[] other]
        {
            get
            {
                var sum = a;
                var length = other.Length; // caching to guarantee no reuse of potentially expensive Length
                for (int i = 0; i < length; i++)
                    sum += other[i];
                return sum;
            }
        }
    }

    public class ParamsIndexerVsOverloads
    {
        private LazyNDArray lazy;
        private OverloadedNDArray overloaded;
        private const int ITERATIONS = 100;

        // To avoid any attempts to cache the result
        private int currId;
        public int GetCurrent()
            => currId++;

        [GlobalSetup]
        public void Setup()
        {
            lazy = new();
            overloaded = new();
        }

        [Benchmark]
        public void HowMuchGetCurrentTakes()
        {
            for (int i = 0; i < ITERATIONS; i++)
                GetCurrent(); 
        }

        [Benchmark]
        public void BenchLazy1D()
        {
            for (int i = 0; i < ITERATIONS; i++) // to avoid nano-benchmark problems
            {
                _ = lazy[GetCurrent()];
            }
        }

        [Benchmark]
        public void BenchLazy2D()
        {
            for (int i = 0; i < ITERATIONS; i++) // to avoid nano-benchmark problems
            {
                _ = lazy[GetCurrent(), 4];
            }
        }

        [Benchmark]
        public void BenchOverloaded1D()
        {
            for (int i = 0; i < ITERATIONS; i++) // to avoid nano-benchmark problems
            {
                _ = overloaded[GetCurrent()];
            }
        }

        [Benchmark]
        public void BenchOverloaded2D()
        {
            for (int i = 0; i < ITERATIONS; i++) // to avoid nano-benchmark problems
            {
                _ = overloaded[GetCurrent(), 4];
            }
        }
    }
}

/*
 
i7 7700 HQ

(ITERATIONS iterations for each method to avoid micro-benchmark issues)

|                 Method |       Mean |    Error |   StdDev |
|----------------------- |-----------:|---------:|---------:|
| HowMuchGetCurrentTakes |   167.1 ns |  2.16 ns |  1.80 ns |
|            BenchLazy1D |   656.5 ns | 13.14 ns | 20.83 ns |
|            BenchLazy2D |   752.2 ns | 15.04 ns | 26.33 ns |
|      BenchOverloaded1D |   172.2 ns |  2.24 ns |  2.10 ns |
|      BenchOverloaded2D | 1,250.3 ns | 23.72 ns | 21.03 ns |
 
 */