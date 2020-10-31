using Microsoft.VisualStudio.TestTools.UnitTesting;
using BenchmarkUtils;
using System.Linq;

namespace _Tests
{
    [TestClass]
    public class SequentialRandomTest
    {
        private void TestShortWithSeed(int seed, int skipped)
        {
            SequentialRandom r = new(new(seed), 10);

            for (int _ = 0; _ < skipped; _++)
                r.Next(); // since it's circular, we can skip a few

            var b = new bool[10];
            for (int _ = 0; _ < 10; _++)
                b[r.Next()] = true;
            Assert.IsTrue(b.All(c => c), string.Join(", ", b));
        }

        [TestMethod] public void TestShort0() => TestShortWithSeed(10, 0);
        [TestMethod] public void TestShort1() => TestShortWithSeed(20, 0);
        [TestMethod] public void TestShort2() => TestShortWithSeed(30, 0);
        [TestMethod] public void TestShort3() => TestShortWithSeed(40, 0);
        [TestMethod] public void TestShort4() => TestShortWithSeed(50, 0);
        [TestMethod] public void TestShort5() => TestShortWithSeed(60, 0);
        [TestMethod] public void TestShort0WithSkipped() => TestShortWithSeed(10, 3);
        [TestMethod] public void TestShort1WithSkipped() => TestShortWithSeed(20, 3);
        [TestMethod] public void TestShort2WithSkipped() => TestShortWithSeed(30, 3);
        [TestMethod] public void TestShort3WithSkipped() => TestShortWithSeed(40, 3);
        [TestMethod] public void TestShort4WithSkipped() => TestShortWithSeed(50, 3);
        [TestMethod] public void TestShort5WithSkipped() => TestShortWithSeed(60, 3);
    }
}
