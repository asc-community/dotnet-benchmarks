using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IterationRefParametersVsReturns
{
	public unsafe class IterationRefParametersVsReturnsBenchmarks
	{
		[Params(10, 100, 1000, 10000)]
		public int N;

		int[] array;

		[IterationSetup]
		public void Setup()
		{
			array = new int[N];
			for (int i = 0; i < N; i++)
			{
				array[i] = i;
			}
		}

		[Benchmark]
		public void Control()
		{
			for (int i = 0; i < N; i++)
			{
				array[i] += 1;
			}
		}

		[Benchmark]
		public void DelegateReturn() => Update(array, x => x + 1);

		public void Update<T>(T[] array, Func<T, T> updater)
		{
			for (int i = 0; i < N; i++)
			{
				array[i] = updater(array[i]);
			}
		}

		[Benchmark]
		public void DelegateRefParam() => Update(array, (ref int x) => x += 1);

		public delegate void Updater<T>(ref T value);

		public void Update<T>(T[] array, Updater<T> updater)
		{
			for (int i = 0; i < N; i++)
			{
				updater(ref array[i]);
			}
		}

		[Benchmark]
		public void StructGenericReturn() => UpdateReturn<int, Int32Increment>(array);

		/// <inheritdoc cref="Func{T1, TResult}"/>
		public interface IFunc<T1, TResult>
		{
			/// <inheritdoc cref="Func{T1, TResult}.Invoke"/>
			TResult Invoke(T1 arg1);
		}

		struct Int32Increment : IFunc<int, int> { public int Invoke(int a) => a + 1; }

		public void UpdateReturn<T, Updater>(T[] array, Updater updater = default)
			where Updater : struct, IFunc<T, T>
		{
			for (int i = 0; i < N; i++)
			{
				array[i] = updater.Invoke(array[i]);
			}
		}

		[Benchmark]
		public void StructGenericRefParam() => UpdateRefParam<int, Int32RefIncrement>(array);

		public interface IUpdater<T1>
		{
			void Invoke(ref T1 arg1);
		}

		struct Int32RefIncrement : IUpdater<int> { public void Invoke(ref int a) => a += 1; }

		public void UpdateRefParam<T, Updater>(T[] array, Updater updater = default)
			where Updater : struct, IUpdater<T>
		{
			for (int i = 0; i < N; i++)
			{
				updater.Invoke(ref array[i]);
			}
		}
		
		[Benchmark]
		public void FunctionPointer() => UpdateWithPointer(array, &IncrementInt32);
		static int IncrementInt32(int x) => x + 1;
		public void UpdateWithPointer<T>(T[] array, delegate*<T, T> updater)
		{
			for (int i = 0; i < N; i++)
			{
				array[i] = updater(array[i]);
			}
		}

		[Benchmark]
		public void FunctionPointerRefParam() => UpdateWithPointerRef(array, &IncrementInt32);
		static void IncrementInt32(ref int x) => x += 1;
		public void UpdateWithPointerRef<T>(T[] array, delegate*<ref T, void> updater)
		{
			for (int i = 0; i < N; i++)
			{
				updater(ref array[i]);
			}
		}
	}
}
