using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace BenchmarkUtils
{
    /// <summary>
    /// Used to go over a permutations of numbers from 0 to arrayLength - 1 inclusive,
    /// that is, if you need to go over all elements from 0 to 99 without order,
    /// you should pass 100 as the only ctor's argument
    /// </summary>
    public unsafe struct SequentialRandom
    {
        private Random random;
        private int arrayLength;
        private int[] array;
        private int currentState;

        public SequentialRandom(Random random, int arrayLength)
        {
            this.random = random;
            this.arrayLength = arrayLength;

            // that's just a permutation
            var loop = Enumerable.Range(0, arrayLength).OrderBy(_ => random.Next(0, arrayLength * 100)).ToArray();

            // here we create an array such that we will guaranteedly go over the whole array
            array = new int[arrayLength];
            for (int i = 0; i < arrayLength - 1; i++)
                array[loop[i]] = loop[i + 1];
            array[loop[loop.Length - 1]] = loop[0];


            currentState = 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Next()
        {
            fixed (int* arrayPointer = array)
            {
                currentState = arrayPointer[currentState];
            }
            return currentState;
        }
    }
}
