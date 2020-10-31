using BenchmarkDotNet.Running;
using System;

namespace BasicConstructions
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Recursion>();
        }
    }
}
