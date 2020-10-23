## "Params" kills the performance

<a href="../Benchmarks/IndexedCollectionAbstractions/ParamsIndexerVsOverloads.cs">Benchmark</a>

### Do not use params when number of arguments vary very little

Unlike C++ (where you usually make a template method), 
in C# this merely creates an array. Say, you want to find the sum of numbers that you pass
to an index. Now, say that BenchOverloaded1D has an overload with one argument, while
BenchLazy1D only has an indexer (method, whatever) with `params int[] ids`:

|                 Method |       Mean |
|----------------------- |-----------:|
|            BenchLazy1D |   656.5 ns |
|      BenchOverloaded1D |   172.2 ns |    <- the overload is hit here

We see, that the method with an overload for one argument is by far more efficient, than
those without any overloads. So if you don't plan to have a lot of arguments passed to the method,
but varying from 0 to, say, 3, you are likely to switch to the overloaded mechanism.

### Use them when a lot of arguments likely to be passed

The tip about overloading won't work if you constantly pass quite a lot of arguments. Let us look
at the case for more than 1 argument passed:

|                 Method |       Mean |
|----------------------- |-----------:|
|            BenchLazy2D |   752.2 ns |
|      BenchOverloaded2D | 1,250.3 ns |

The overloaded version is now far behind (its arguments are (int, params int[])). Yes, you can
overload for 2 arguments as well, but in general, it might not work if you have no ideas how many
arguments potentially could be.

### Drawbacks of overloads

Is that you have to add (int[]) overload too, otherwise you won't be able to pass an array of those
arguments.

### Conclusion

That is how I see when 0 to 3 arguments are most likely to be passed:

```cs
Method() => ...
Method(T a) => ...
Method(T a, T b) => ...
Method(T a, T b, T c) => ...
Method(T a, T b, T c, params T[] others) => ...
Method(T[] values) => ...
```

which, in terms of logic, is equivalent to

```cs
Method(params T[] values) => ...
```
