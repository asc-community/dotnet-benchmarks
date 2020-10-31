using BenchmarkDotNet.Running;

namespace TypeEqualityChecking
{
	public class Program
	{
		public static void Main()
		{
			BenchmarkRunner.Run<TypeEqualityCheckingBenchmarks>();
		}
	}
}