using BasicConstructions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _Tests
{
    [TestClass]
    public class GCDTest
    {
        [TestMethod] public void TestRecGCD1() => Assert.AreEqual(5, Recursion.GCDRec(15, 5));
        [TestMethod] public void TestRecGCD2() => Assert.AreEqual(1, Recursion.GCDRec(15, 4));
        [TestMethod] public void TestRecGCD3() => Assert.AreEqual(5, Recursion.GCDRec(5, 15));
        [TestMethod] public void TestRecGCD4() => Assert.AreEqual(1, Recursion.GCDRec(4, 15));
        [TestMethod] public void TestLoopGCD1() => Assert.AreEqual(5, Recursion.GCDLoop(15, 5));
        [TestMethod] public void TestLoopGCD2() => Assert.AreEqual(1, Recursion.GCDLoop(15, 4));
        [TestMethod] public void TestLoopGCD3() => Assert.AreEqual(5, Recursion.GCDLoop(5, 15));
        [TestMethod] public void TestLoopGCD4() => Assert.AreEqual(1, Recursion.GCDLoop(4, 15));
    }
}
