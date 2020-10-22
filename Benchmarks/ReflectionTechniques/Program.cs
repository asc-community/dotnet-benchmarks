using BenchmarkDotNet.Running;

namespace ReflectionTechniques
{
	class Program
	{
		static void Main()
		{
			BenchmarkRunner.Run<ReflectionBenchmarks>();
		}
	}
}
