using BenchmarkDotNet.Running;

namespace MultipleReturnsTechniques
{
	class Program
	{
		static void Main()
		{
			BenchmarkRunner.Run<MultipleReturnsIntBenchmarks>();
			BenchmarkRunner.Run<MultipleReturnsObjectBenchmarks>();
		}
	}
}
