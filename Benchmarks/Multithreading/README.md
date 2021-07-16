## Cache locality

This benchmark shows that if you read/write from multiple threads, it might be a good idea
to make sure, that the addresses of where the threads are reading from/writing to are far 
from each other.


```ini
BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19042.1083 (20H2/October2020Update)
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.100-preview.7.21360.1
  [Host]     : .NET 6.0.0 (6.0.21.36001), X64 RyuJIT
  DefaultJob : .NET 6.0.0 (6.0.21.36001), X64 RyuJIT
```

|                                             Method |     Mean |    Error |   StdDev |   Median |
|--------------------------------------------------- |---------:|---------:|---------:|---------:|
|  'Threads read one by one confusing the cacheline' | 45.22 ms | 1.934 ms | 5.701 ms | 45.54 ms |
|                 'Threads read far from each other' | 18.98 ms | 0.480 ms | 1.416 ms | 19.42 ms |
| 'Threads write one by one confusing the cacheline' | 66.64 ms | 3.129 ms | 9.175 ms | 65.38 ms |
|                'Threads write far from each other' | 22.46 ms | 0.441 ms | 0.969 ms | 22.63 ms |