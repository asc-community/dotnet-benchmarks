using BenchmarkDotNet.Running;

namespace DynamicStringConstruction
{
	class Program
	{
		static void Main()
		{
			BenchmarkRunner.Run<DynamicStringConstructionBenchmarks>();
		}
	}
}
