# Multiple Returns Techniques

This benchmark it to help determine the most appropriate pattern for returning multiple values
from a method:
- `out` parameters
- returning classes (`Tuple<T...>`)
- returning structs (`ValueTuple<T...>`)

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1016 (1909/November2018Update/19H2)
Intel Core i7-4790K CPU 4.00GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  DefaultJob : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT


```
|              Method |      Mean |     Error |    StdDev |    Median |
|-------------------- |----------:|----------:|----------:|----------:|
|     return_object_1 |  5.512 ns | 0.1352 ns | 0.1660 ns |  5.453 ns |
|        out_object_1 |  7.174 ns | 0.1311 ns | 0.1226 ns |  7.188 ns |
|      tuple_object_1 | 12.453 ns | 0.2740 ns | 0.2814 ns | 12.435 ns |
| valuetuple_object_1 |  8.831 ns | 0.2009 ns | 0.1973 ns |  8.742 ns |
|        out_object_2 | 14.012 ns | 0.2429 ns | 0.2599 ns | 13.958 ns |
|      tuple_object_2 | 18.416 ns | 0.2248 ns | 0.2103 ns | 18.316 ns |
| valuetuple_object_2 | 17.783 ns | 0.1786 ns | 0.1583 ns | 17.756 ns |
|        out_object_3 | 19.789 ns | 0.3101 ns | 0.2901 ns | 19.742 ns |
|      tuple_object_3 | 25.341 ns | 0.2785 ns | 0.2469 ns | 25.248 ns |
| valuetuple_object_3 | 24.357 ns | 0.1456 ns | 0.1216 ns | 24.380 ns |
|        out_object_4 | 27.393 ns | 0.5725 ns | 0.9406 ns | 27.111 ns |
|      tuple_object_4 | 31.564 ns | 0.6439 ns | 0.6613 ns | 31.379 ns |
| valuetuple_object_4 | 31.492 ns | 0.4104 ns | 0.3638 ns | 31.456 ns |
|        out_object_5 | 32.031 ns | 0.5698 ns | 0.4758 ns | 31.896 ns |
|      tuple_object_5 | 38.926 ns | 0.7763 ns | 0.8940 ns | 38.631 ns |
| valuetuple_object_5 | 38.895 ns | 0.2511 ns | 0.2097 ns | 38.854 ns |
|        out_object_6 | 38.134 ns | 0.3765 ns | 0.3522 ns | 38.013 ns |
|      tuple_object_6 | 56.387 ns | 0.5732 ns | 0.5081 ns | 56.321 ns |
| valuetuple_object_6 | 47.245 ns | 0.9334 ns | 0.9987 ns | 47.181 ns |
|        out_object_7 | 46.267 ns | 0.9470 ns | 0.9301 ns | 46.146 ns |
|      tuple_object_7 | 55.636 ns | 1.1037 ns | 2.8292 ns | 54.674 ns |
| valuetuple_object_7 | 57.058 ns | 1.1644 ns | 1.8802 ns | 56.180 ns |

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1016 (1909/November2018Update/19H2)
Intel Core i7-4790K CPU 4.00GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  DefaultJob : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT


```
|           Method |     Mean |     Error |    StdDev |   Median |
|----------------- |---------:|----------:|----------:|---------:|
|     return_int_1 | 1.564 ns | 0.0462 ns | 0.0386 ns | 1.571 ns |
|        out_int_1 | 1.614 ns | 0.0604 ns | 0.1634 ns | 1.545 ns |
|      tuple_int_1 | 5.902 ns | 0.1449 ns | 0.1488 ns | 5.878 ns |
| valuetuple_int_1 | 2.519 ns | 0.0766 ns | 0.1321 ns | 2.508 ns |
|        out_int_2 | 1.524 ns | 0.0491 ns | 0.0459 ns | 1.506 ns |
|      tuple_int_2 | 5.852 ns | 0.0583 ns | 0.0545 ns | 5.835 ns |
| valuetuple_int_2 | 4.630 ns | 0.0283 ns | 0.0251 ns | 4.625 ns |
|        out_int_3 | 2.253 ns | 0.0243 ns | 0.0215 ns | 2.250 ns |
|      tuple_int_3 | 6.927 ns | 0.0515 ns | 0.0457 ns | 6.917 ns |
| valuetuple_int_3 | 5.942 ns | 0.0195 ns | 0.0173 ns | 5.937 ns |
|        out_int_4 | 2.906 ns | 0.0273 ns | 0.0256 ns | 2.894 ns |
|      tuple_int_4 | 6.974 ns | 0.0705 ns | 0.0659 ns | 6.982 ns |
| valuetuple_int_4 | 6.585 ns | 0.0215 ns | 0.0191 ns | 6.583 ns |
|        out_int_5 | 3.307 ns | 0.0309 ns | 0.0241 ns | 3.306 ns |
|      tuple_int_5 | 7.741 ns | 0.0642 ns | 0.0536 ns | 7.764 ns |
| valuetuple_int_5 | 7.248 ns | 0.1475 ns | 0.1380 ns | 7.351 ns |
|        out_int_6 | 4.201 ns | 0.1085 ns | 0.1065 ns | 4.186 ns |
|      tuple_int_6 | 8.544 ns | 0.1892 ns | 0.2103 ns | 8.500 ns |
| valuetuple_int_6 | 8.251 ns | 0.1036 ns | 0.0969 ns | 8.221 ns |
|        out_int_7 | 7.654 ns | 0.1287 ns | 0.1141 ns | 7.663 ns |
|      tuple_int_7 | 9.647 ns | 0.2139 ns | 0.2999 ns | 9.598 ns |
| valuetuple_int_7 | 8.702 ns | 0.1395 ns | 0.1305 ns | 8.641 ns |
