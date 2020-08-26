using BenchmarkDotNet.Running;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchArrays>();
        }
    }
}
