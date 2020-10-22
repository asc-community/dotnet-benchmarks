using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;

namespace MethodAbstractions
{
	public class EnumerableBenchmarks
	{
		private static int[] data;
		private static int sum;

		[GlobalSetup]
		public void Setup()
		{
			const int N = 10;
			int[] dataArray = new int[N];
			for (int i = 0; i < N; i++)
			{
				dataArray[i] = i;
			}
			data = dataArray;
		}

		[Benchmark]
		public void Control()
		{
			sum = 0;
			foreach (int i in data)
			{
				if (i % 2 == 0)
				{
					sum += i;
				}
			}
		}

		[Benchmark]
		public void LinqWhereLambda()
		{
			sum = 0;
			foreach (int i in data.Where(i => i % 2 == 0))
			{
				sum += i;
			}
		}

		[Benchmark]
		public void LinqWhere()
		{
			sum = 0;
			foreach (int i in data.Where(IsEven))
			{
				sum += i;
			}
		}

		[Benchmark]
		public void CustomWhereLambda()
		{
			sum = 0;
			foreach (int i in data.CustomWhere(i => i % 2 == 0))
			{
				sum += i;
			}
		}

		[Benchmark]
		public void CustomWhere()
		{
			sum = 0;
			foreach (int i in data.CustomWhere(IsEven))
			{
				sum += i;
			}
		}

		[Benchmark]
		public void GenericStructWhere()
		{
			sum = 0;
			foreach (int i in data.Where<int, g__IsEven_1>())
			{
				sum += i;
			}
		}

		[Benchmark]
		public void GenericStructWhereAction()
		{
			sum = 0;
			data.Where<int, g__IsEven_1, g__Action_1>();
		}

		[Benchmark]
		public void CustomWhereWithAggressiveInlining()
		{
			sum = 0;
			foreach (int i in data.CustomWhere(IsEvenWithAggressiveInlining))
			{
				sum += i;
			}
		}

		[Benchmark]
		public void GenericStructWhereWithAggressiveInlining()
		{
			sum = 0;
			foreach (int i in data.Where<int, g__IsEvenWithAggressiveInlining_1>())
			{
				sum += i;
			}
		}

		[Benchmark]
		public void GenericStructWhereActionWithAggressiveInlining()
		{
			sum = 0;
			data.Where<int, g__IsEvenWithAggressiveInlining_1, g__ActionWithAggressiveInlining_1>();
		}

		public struct g__ActionWithAggressiveInlining_1 : IAction<int>
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
			public void Do(int a) => sum += a;
		}

		public struct g__IsEvenWithAggressiveInlining_1 : IFunction<int, bool>
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
			public bool Do(int a) => IsEvenWithAggressiveInlining(a);
		}

		public struct g__Action_1 : IAction<int>
		{
			public void Do(int a) => sum += a;
		}

		public struct g__IsEven_1 : IFunction<int, bool>
		{
			public bool Do(int a) => IsEven(a);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public static bool IsEvenWithAggressiveInlining(int i) => i % 2 == 0;

		public static bool IsEven(int i) => i % 2 == 0;

	}

	#region Interface Types That Would Be Added To .NET

	public interface IAction<A> { void Do(A a); }
	public interface IFunction<A, B> { B Do(A a); }

	#endregion

	public static class Extensions
	{
		public static IEnumerable<T> CustomWhere<T>(this T[] ienumerable, Predicate<T> where)
		{
			foreach (T value in ienumerable)
			{
				if (where(value))
				{
					yield return value;
				}
			}
		}

		public static IEnumerable<T> Where<T, Predicate>(this T[] ienumerable)
			/// There should be syntax sugar on the constraints to
			/// make them look more like function constraints.
			where Predicate : struct, IFunction<T, bool> // -> where Predicate : [bool method(T)]
		{
			#region Code that should be unnecessary

			Predicate predicate = default;

			#endregion

			/// The generic parameter should be invocable directly the ".Do" calls should be unnecessary.

			foreach (T value in ienumerable)
			{
				if (predicate.Do(value))
				{
					yield return value;
				}
			}
		}

		public static void Where<T, Predicate, Action>(this T[] ienumerable)
			/// There should be syntax sugar on the constraints to
			/// make them look more like function constraints.
			where Predicate : struct, IFunction<T, bool> // -> where Predicate : [bool method(T)]
			where Action : struct, IAction<T>            // -> where Action    : [void method(T)]
		{
			#region Code that should be unnecessary

			Predicate predicate = default;
			Action action = default;

			#endregion

			/// The generic parameter should be invocable directly the ".Do" calls should be unnecessary.

			foreach (T value in ienumerable)
			{
				if (predicate.Do(value))
				{
					action.Do(value);
				}
			}
		}
	}
}