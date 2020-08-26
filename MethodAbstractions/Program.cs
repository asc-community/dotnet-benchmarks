using BenchmarkDotNet.Running;

namespace MethodAbstractions
{
	public class Program
	{
		public static void Main()
		{
			BenchmarkRunner.Run<AdditionBenchmarks>();
			BenchmarkRunner.Run<EnumerableBenchmarks>();
		}
	}
}