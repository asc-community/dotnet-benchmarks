using BenchmarkDotNet.Running;

namespace IndexedCollectionAbstractions
{
	public class Program
	{
		public static void Main()
		{
			BenchmarkRunner.Run<IndexedCollectionBenchmarks>();
		}
	}
}