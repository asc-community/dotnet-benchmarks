using BenchmarkDotNet.Attributes;
using System;
using System.Runtime.CompilerServices;
using System.Linq.Expressions;
using Microsoft.Diagnostics.Runtime.Interop;
using System.Collections.Generic;
using System.Reflection;

namespace ReflectionTechniques
{
	public class ReflectionBenchmarks
	{
		A a = new A();
		int temp;

		Func<A, int> cachedReflection;

		[GlobalSetup]
		public void GlobalSetup()
		{
			cachedReflection = FieldGetterDelegate<A, int>(nameof(A.a));
		}

		[Benchmark]
		[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
		public void FieldDirect()
		{
			temp = a.a;
		}

		[Benchmark]
		[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
		public void FieldReflection()
		{
			temp = (int)typeof(A).GetField(nameof(A.a)).GetValue(a);
		}

		[Benchmark]
		[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
		public void FieldReflectionCached()
		{
			temp = cachedReflection(a);
		}

		[Benchmark]
		[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
		public void FieldReflectionCachedLookUpKnownType()
		{
			temp = GetFieldValue<A, int>(a, nameof(A.a));
		}

		[Benchmark]
		[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
		public void FieldReflectionCachedLookUpUnknownType()
		{
			temp = (int)GetFieldValue(a, nameof(A.a));
		}

		public static Field GetFieldValue<Type, Field>(Type instance, string name) =>
			GetFieldValueImplementation<Type, Field>.Do(instance, name);

		internal static class GetFieldValueImplementation<Type, Field>
		{
			public static Dictionary<string, Func<Type, Field>> Delegates =
				new Dictionary<string, Func<Type, Field>>();

			internal static Field Do(Type instance, string field)
			{
				if (Delegates.TryGetValue(field, out var cachedGet))
				{
					return cachedGet(instance);
				}
				var newGet = FieldGetterDelegate<Type, Field>(field);
				Delegates.Add(field, newGet);
				return newGet(instance);
			}
		}

		public static object GetFieldValue(object instance, string name) =>
			GetFieldValueObjectImplementation.Do(instance, name);

		internal static class GetFieldValueObjectImplementation
		{
			public static Dictionary<(Type, string), Func<object, object>> Delegates =
				new Dictionary<(Type, string), Func<object, object>>();

			internal static object Do(object instance, string field)
			{
				Type type = instance.GetType();
				if (Delegates.TryGetValue((type, field), out var cachedGet))
				{
					return cachedGet(instance);
				}
				FieldInfo fieldInfo = type.GetField(field,
					BindingFlags.Instance |
					BindingFlags.Public |
					BindingFlags.NonPublic);
				ParameterExpression A = Expression.Parameter(typeof(object));
				Expression BODY = Expression.Convert(Expression.Field(Expression.Convert(A, type), fieldInfo), typeof(object));
				var newGet = Expression.Lambda<Func<object, object>>(BODY, A).Compile();
				Delegates.Add((type, field), newGet);
				return newGet(instance);
			}
		}

		public static Func<T1, F1> FieldGetterDelegate<T1, F1>(string name)
		{
			FieldInfo fieldInfo = typeof(T1).GetField(name,
				BindingFlags.Instance |
				BindingFlags.Public |
				BindingFlags.NonPublic);
			ParameterExpression A = Expression.Parameter(typeof(T1));
			Expression BODY = Expression.Field(A, fieldInfo);
			return Expression.Lambda<Func<T1, F1>>(BODY, A).Compile();
		}
	}

	public class A
	{
		public int a = -1;
	}
}
