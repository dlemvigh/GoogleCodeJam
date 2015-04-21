using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualCodeJam.Test
{
    [TestClass]
    public class HaircutTest : BaseUnitTestCaseRunner
    {
        [TestMethod]
        public void Test1()
        {
            var actual = SingleCase<HaircutSolver>("2 4\n10 5");
            var expected = "1";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test2()
        {
            var actual = SingleCase<HaircutSolver>("3 12\n7 7 7");
            var expected = "3";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test3()
        {
            var actual = SingleCase<HaircutSolver>("3 8\n4 2 1");
            var expected = "1";

            Assert.AreEqual(expected, actual);
        }
    }
}
