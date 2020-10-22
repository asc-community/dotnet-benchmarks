using BenchmarkDotNet.Running;

namespace StringFormattingTechniques
{
	class Program
	{
		static void Main()
		{
			BenchmarkRunner.Run<StringBenchmarks>();
		}
	}
}
