## Cache locality

This benchmark shows that if you read/write from multiple threads, it might be a good idea
to make sure, that the addresses of where the threads are reading from/writing to are far 
from each other.

Note, that the mulltithreading itself is not the key here but the cacheline which works
inefficiently when we're reading a single int and then abandon the chunk of memory versus
when we use 100% of what it prepared for us.

Illustration of what I mean. Assume there's some continuous data, here are two out of many
ways to read/write it (number = job/thread/etc):
```
11111111
        22222222
                33333333
                        44444444
```
And
```
1   1   1   1   1   1   1   1
 2   2   2   2   2   2   2   2
  3   3   3   3   3   3   3   3
   4   4   4   4   4   4   4   4
```
The first one is marked as `'Threads read far from each other'` and the second one is marked
as `'Threads read one by one confusing the cacheline'`.



```ini
BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19042.1083 (20H2/October2020Update)
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.100-preview.7.21360.1
  [Host]     : .NET 6.0.0 (6.0.21.36001), X64 RyuJIT
  DefaultJob : .NET 6.0.0 (6.0.21.36001), X64 RyuJIT
```

|                                             Method | IsMultithreadingOn |      Mean |    Error |   StdDev |    Median |
|--------------------------------------------------- |------------------- |----------:|---------:|---------:|----------:|
|  'Threads read one by one confusing the cacheline' |              False | 143.17 ms | 2.850 ms | 4.839 ms | 142.78 ms |
|                 'Threads read far from each other' |              False |  54.35 ms | 0.964 ms | 0.805 ms |  54.00 ms |
| 'Threads write one by one confusing the cacheline' |              False | 189.52 ms | 3.725 ms | 4.711 ms | 189.78 ms |
|                'Threads write far from each other' |              False |  48.54 ms | 0.811 ms | 0.719 ms |  48.19 ms |
|  'Threads read one by one confusing the cacheline' |               True |  47.70 ms | 1.634 ms | 4.715 ms |  48.64 ms |
|                 'Threads read far from each other' |               True |  20.06 ms | 0.595 ms | 1.726 ms |  20.54 ms |
| 'Threads write one by one confusing the cacheline' |               True |  67.12 ms | 2.790 ms | 8.140 ms |  66.29 ms |
|                'Threads write far from each other' |               True |  22.11 ms | 0.433 ms | 0.759 ms |  22.24 ms |
