using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace IndexedCollectionAbstractions
{
	public class IndexedCollectionBenchmarks
	{
		[Params(10, 100, 1000)]
		public int Size;

		int[] array;
		List<int> list;
		IList<int> ilist_array;
		IList<int> ilist_list;

		[GlobalSetup]
		public void Setup()
		{
			array = Enumerable.Range(0, Size).ToArray();
			list = new List<int>(array);
			ilist_array = array;
			ilist_list = list;
		}

		[Benchmark]
		public void Array()
		{
			for (int i = 0; i < Size; i++)
			{
				_ = array[i];
			}
		}

		[Benchmark]
		public void List()
		{
			for (int i = 0; i < Size; i++)
			{
				_ = list[i];
			}
		}

		[Benchmark]
		public void IListArray()
		{
			for (int i = 0; i < Size; i++)
			{
				_ = ilist_array[i];
			}
		}

		[Benchmark]
		public void IListList()
		{
			for (int i = 0; i < Size; i++)
			{
				_ = ilist_list[i];
			}
		}
	}
}
