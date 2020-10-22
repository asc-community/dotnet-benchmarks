using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boxing
{
    public class EqualsBoxing
    {
        private int[] permutedArray;
        private const int PERMUTED_ARRAY_LENGTH = 20;

        [GlobalSetup]
        public void Setup()
        {
            var r = new Random();
            permutedArray = Enumerable.Range(0, PERMUTED_ARRAY_LENGTH).OrderBy(c => r.Next(0, 10000)).ToArray();
        }

        private int id1 = 0;
        private int id2 = PERMUTED_ARRAY_LENGTH / 2; // they should differ

        [Benchmark]
        public void NoEqualsCalled()
        {
            bool decision = id1 == id2;
            id1 = (id1 + (decision ? 1 : 0)) % permutedArray.Length;
            id1 = permutedArray[id1];
            id2 = permutedArray[id2];
        }

        public bool CallEqualsWithBoxing<T>(T a, T b)
            => a.Equals(b);

        [Benchmark]
        public void EqualsCalled()
        {
            bool decision = CallEqualsWithBoxing(id1, id2);
            id1 = (id1 + (decision ? 1 : 0)) % permutedArray.Length;
            id1 = permutedArray[id1];
            id2 = permutedArray[id2];
        }

        public bool CallEqualsWithBoxingForStructs<T>(T a, T b) where T : struct
            => a.Equals(b);

        [Benchmark]
        public void EqualsCalledOnStructs()
        {
            bool decision = CallEqualsWithBoxingForStructs(id1, id2);
            id1 = (id1 + (decision ? 1 : 0)) % permutedArray.Length;
            id1 = permutedArray[id1];
            id2 = permutedArray[id2];
        }
    }
}


/*
 * 
 * 
|                Method |     Mean |    Error |   StdDev |
|---------------------- |---------:|---------:|---------:|
|        NoEqualsCalled | 10.45 ns | 0.165 ns | 0.154 ns |
|          EqualsCalled | 12.95 ns | 0.289 ns | 0.270 ns |
| EqualsCalledOnStructs | 13.71 ns | 0.315 ns | 0.398 ns |
 
 Although it might be distorted a little bit as quite a significant chunk of time is taken by addressing fields of the array
and addressing the array itself, while the equality comparison of two ints is cheap


 */