using BenchmarkDotNet.Attributes;
using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace MethodAbstractions
{
	public class AdditionBenchmarks
	{
		int temp;
		int _1;
		int _2;
		int _3;
		int _4;
		int _5;

		[GlobalSetup]
		public void Setup()
		{
			_1 = 1;
			_2 = 2;
			_3 = 3;
			_4 = 4;
			_5 = 5;
		}

		[Benchmark]
		public void IntegerAdd()
		{
			temp = _1 + _1;
			temp = _2 + _2;
			temp = _3 + _3;
			temp = _4 + _4;
			temp = _5 + _5;
		}

		[Benchmark]
		public void IntegerAddStructWithAggressiveInlining()
		{
			temp = DoWithAggressiveInlining<int, g__AdditionWithAggressiveInlining_1>(_1, _1);
			temp = DoWithAggressiveInlining<int, g__AdditionWithAggressiveInlining_1>(_2, _2);
			temp = DoWithAggressiveInlining<int, g__AdditionWithAggressiveInlining_1>(_3, _3);
			temp = DoWithAggressiveInlining<int, g__AdditionWithAggressiveInlining_1>(_4, _4);
			temp = DoWithAggressiveInlining<int, g__AdditionWithAggressiveInlining_1>(_5, _5);
		}

		[Benchmark]
		public void IntegerAddLinqWithAggressiveInlining()
		{
			temp = AdditionWithAggressiveInlining(_1, _1);
			temp = AdditionWithAggressiveInlining(_2, _2);
			temp = AdditionWithAggressiveInlining(_3, _3);
			temp = AdditionWithAggressiveInlining(_4, _4);
			temp = AdditionWithAggressiveInlining(_5, _5);
		}

		[Benchmark]
		public void IntegerAddStruct()
		{
			temp = Do<int, g__Addition_1>(_1, _1);
			temp = Do<int, g__Addition_1>(_2, _2);
			temp = Do<int, g__Addition_1>(_3, _3);
			temp = Do<int, g__Addition_1>(_4, _4);
			temp = Do<int, g__Addition_1>(_5, _5);
		}

		[Benchmark]
		public void IntegerAddLinq()
		{
			temp = Addition(_1, _1);
			temp = Addition(_2, _2);
			temp = Addition(_3, _3);
			temp = Addition(_4, _4);
			temp = Addition(_5, _5);
		}

		public struct g__AdditionWithAggressiveInlining_1 : IFunction<int, int, int>
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public int Do(int a, int b) => a + b;
		}

		public struct g__Addition_1 : IFunction<int, int, int>
		{
			public int Do(int a, int b) => a + b;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T DoWithAggressiveInlining<T, Addition>(T a, T b)
			where Addition : struct, IFunction<T, T, T>
		{
			Addition addition = default;
			return addition.Do(a, b);
		}

		public static T Do<T, Addition>(T a, T b)
			where Addition : struct, IFunction<T, T, T>
		{
			Addition addition = default;
			return addition.Do(a, b);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T AdditionWithAggressiveInlining<T>(T a, T b)
		{
			return AdditionImplementation<T>.Function(a, b);
		}

		public static T Addition<T>(T a, T b)
		{
			return AdditionImplementation<T>.Function(a, b);
		}

		internal static class AdditionImplementation<T>
		{
			internal static Func<T, T, T> Function = (T a, T b) =>
			{
				ParameterExpression A = Expression.Parameter(typeof(T));
				ParameterExpression B = Expression.Parameter(typeof(T));
				Expression BODY = Expression.Add(A, B);
				Function = Expression.Lambda<Func<T, T, T>>(BODY, A, B).Compile();
				return Function(a, b);
			};
		}
	}

	public interface IFunction<A, B, C> { C Do(A a, B b); }
}
