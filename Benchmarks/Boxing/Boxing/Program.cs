using BenchmarkDotNet.Running;
using System;

namespace Boxing
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<EqualsBoxing>();
        }
    }
}
