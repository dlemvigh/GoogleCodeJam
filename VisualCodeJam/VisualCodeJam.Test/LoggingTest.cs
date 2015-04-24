using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualCodeJam.Test
{
    [TestClass]
    public class LoggingTest : BaseUnitTestCaseRunner
    {
        [TestMethod]
        public void Test1()
        {
            var input = @"5
0 0
10 0
10 10
0 10
5 5";
            var expected = @"
0
0
0
0
1";

            var actual = SingleCase<LoggingSolver>(input, expected);
        }

        [TestMethod]
        public void Test2()
        {
            var input = @"9
0 0
5 0
10 0
0 5
5 5
10 5
0 10
5 10
10 10";
            var output = @"
0
0
0
0
3
0
0
0
0";
            SingleCase<LoggingSolver>(input, output);
        }
    }
}
