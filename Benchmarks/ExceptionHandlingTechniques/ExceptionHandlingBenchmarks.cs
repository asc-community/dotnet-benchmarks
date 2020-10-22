using BenchmarkDotNet.Attributes;
using System;
using System.Runtime.CompilerServices;

namespace ExceptionHandlingTechniques
{
	public class ExceptionHandlingBenchmarks
	{
		int temp;

		[Benchmark]
		[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
		public void TryMethodPattern()
		{
			if (!TryDo(2, out temp))
			{
				temp = -1;
			}
		}
		public static bool TryDo(int value, out int result)
		{
			if (value % 2 == 0)
			{
				result = default;
				return false;
			}
			else
			{
				result = value;
				return true;
			}
		}

		[Benchmark]
		[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
		public void TryCatch()
		{
			try
			{
				temp = Do(2);
			}
			catch
			{
				temp = -1;
			}
		}
		public static int Do(int value)
		{
			if (value % 2 == 0)
			{
				throw new Exception();
			}
			else
			{
				return value;
			}
		}

		[Benchmark]
		[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
		public void Int32_TryParse()
		{
			if (!int.TryParse(" ", out temp))
			{
				temp = -1;
			}
		}

		[Benchmark]
		[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
		public void Int32_Parse_TryCatch()
		{
			try
			{
				temp = int.Parse(" ");
			}
			catch
			{
				temp = -1;
			}
		}
	}
}
