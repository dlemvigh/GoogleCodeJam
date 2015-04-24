using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VisualCodeJam.MushroomMonster;
using System.IO;

namespace VisualCodeJam.Test
{
    [TestClass]
    public class MushroomMonsterTest : BaseUnitTestCaseRunner
    {
        [TestMethod]
        public void TestMethod1()
        {
            var expected = "15 25";
            var actual = SingleCase<MushroomMonsterSolver>("4\n10 5 15 5");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var expected = "0 0";
            var actual = SingleCase<MushroomMonsterSolver>("2\n100 100");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var expected = "81 567";
            var actual = SingleCase<MushroomMonsterSolver>("8\n81 81 81 81 81 81 81 0");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var expected = "181 244";
            var actual = SingleCase<MushroomMonsterSolver>("6\n23 90 40 0 100 9");

            Assert.AreEqual(expected, actual);
        }
    }
}
