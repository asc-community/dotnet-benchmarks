using BenchmarkDotNet.Running;
using System;

namespace IterationRefParametersVsReturns
{
	class Program
	{
		static void Main()
		{
			BenchmarkRunner.Run<IterationRefParametersVsReturnsBenchmarks>();
		}
	}
}
