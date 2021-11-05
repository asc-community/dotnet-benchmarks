/*
var b = new AddArrays();

b.ElemCount = 0x10;
b.Offset = 0;
b.Setup();
Console.WriteLine(b.NaiveAdd());
Console.WriteLine(b.SimdAdd());

b.ElemCount = 0x10;
b.Offset = 46;
b.Setup();
Console.WriteLine(b.NaiveAdd());
Console.WriteLine(b.SimdAdd());
*/

using BenchmarkDotNet.Running;

BenchmarkRunner.Run<AddArrays>();