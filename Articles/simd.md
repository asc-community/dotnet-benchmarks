## SIMD Instructions. When to use and when not to use

<a href="../Benchmarks/Arrays/Intrinsics.cs">Benchmark</a>

### Use on small data

Modern CPUs are capable of storing decent amount of data in their caches, and for
many cases it will even store it in L1. Let us see how efficient it for an array of integers
on a machine that supports AVX-256:

|     Method |   Length |             Mean |
|----------- |--------- |-----------------:|
|   NoVector |      160 |        117.27 ns |
|    VectorT |      160 |         19.99 ns |
| Vector256T |      160 |         19.50 ns |
|            |          |                  |
|   NoVector |     1600 |      1,070.47 ns |
|    VectorT |     1600 |        168.75 ns |
| Vector256T |     1600 |        153.90 ns |

That's a huge boost.

### Don't use on big data

If you know that you are going to process a huge chunk of data, you are likely to
face RAM access performance issues, as CPUs cannot store a lot of data in their caches.
Let's have a look:

|     Method |   Length |             Mean |
|----------- |--------- |-----------------:|
|   NoVector |  1600000 |  1,395,028.32 ns |
|    VectorT |  1600000 |  1,039,098.82 ns |
| Vector256T |  1600000 |  1,097,105.87 ns |
|            |          |                  |
|   NoVector | 16000000 | 14,293,466.20 ns |
|    VectorT | 16000000 | 11,581,997.24 ns |
| Vector256T | 16000000 | 11,712,245.86 ns |

There's a slight performance improvement, but it may not worth the code you would write
to use SIMD.