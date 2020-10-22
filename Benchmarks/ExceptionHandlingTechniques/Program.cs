using BenchmarkDotNet.Running;

namespace ExceptionHandlingTechniques
{
	class Program
	{
		static void Main()
		{
			BenchmarkRunner.Run<ExceptionHandlingBenchmarks>();
		}
	}
}
