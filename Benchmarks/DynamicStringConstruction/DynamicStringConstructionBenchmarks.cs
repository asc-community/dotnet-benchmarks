using BenchmarkDotNet.Attributes;
using System;
using System.Text;

namespace DynamicStringConstruction
{
	[MemoryDiagnoser]
	public class DynamicStringConstructionBenchmarks
	{
		[Params(1, 5, 10, 100, 1000, 10000, 100000)]
		public int N;

		string temp;

		public static char Select(int index) => (char)(index % 26 + 'a');

		[Benchmark]
		public void StringBuilder()
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < N; i++)
			{
				stringBuilder.Append(Select(i));
			}
			temp = stringBuilder.ToString();
		}

		[Benchmark]
		public unsafe void CharPointer()
		{
			string result = new string(' ', N);
			fixed (char* c = result)
			{
				for (int i = 0; i < N; i++)
				{
					*(c + i) = Select(i);
				}
			}
			temp = result;
		}

		[Benchmark]
		public unsafe void CharPointerDelegate()
		{
			temp = CharPointerDelegateHelper(N, Select);
		}

		[Benchmark]
		public unsafe void CharPointerGeneric()
		{
			temp = CharPointerGenericHelper<SelectStruct>(N);
		}

		[Benchmark]
		public void CharArray()
		{
			char[] array = new char[N];
			for (int i = 0; i < N; i++)
			{
				array[i] = Select(i);
			}
			temp = new string(array);
		}

		[Benchmark]
		public void StringCreate()
		{
			temp = string.Create<object>(N, default, (chars, _) =>
			{
				for (int i = 0; i < N; i++)
				{
					chars[i] = Select(i);
				}
			});
		}

		[Benchmark]
		public void StringCreateHelperDelegate()
		{
			temp = StringCreateHelper(N, Select);
		}

		[Benchmark]
		public void StringCreateHelperGeneric()
		{
			temp = StringCreateHelperGeneric<SelectStruct>(N);
		}

		public unsafe string CharPointerDelegateHelper(int length, Func<int, char> get) =>
			CharPointerGenericHelper<FuncRuntime<int, char>>(length, get);

		public unsafe string CharPointerGenericHelper<Get>(int length, Get get = default)
			where Get : struct, IFunc<int, char>
		{
			string result = new string(' ', length);
			fixed (char* c = result)
			{
				for (int i = 0; i < length; i++)
				{
					*(c + i) = get.Do(i);
				}
			}
			return result;
		}

		struct SelectStruct : IFunc<int, char>
		{
			public char Do(int arg1) => Select(arg1);
		}

		public static string StringCreateHelper(int length, Func<int, char> get) =>
			StringCreateHelperGeneric<FuncRuntime<int, char>>(length, get);

		public static string StringCreateHelperGeneric<Get>(int length, Get get = default)
			where Get : struct, IFunc<int, char> =>
			string.Create(length, get, (chars, _) =>
			{
				for (int i = 0; i < length; i++)
				{
					chars[i] = get.Do(i);
				}
			});

		public interface IFunc<T1, TResult>
		{
			TResult Do(T1 arg1);
		}

		public struct FuncRuntime<T1, TResult> : IFunc<T1, TResult>
		{
			internal Func<T1, TResult> _delegate;
			public TResult Do(T1 arg1) => _delegate(arg1);
			public static implicit operator FuncRuntime<T1, TResult>(Func<T1, TResult> @delegate) => new FuncRuntime<T1, TResult>() { _delegate = @delegate, };
		}
	}
}