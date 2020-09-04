using BenchmarkDotNet.Running;

namespace BranchingTechniques
{
	class Program
	{
		static void Main()
		{
			BenchmarkRunner.Run<BranchingTechniquesBenchmarks>();
		}
	}
}
