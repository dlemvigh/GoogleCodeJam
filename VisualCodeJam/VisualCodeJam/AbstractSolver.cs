using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualCodeJam
{
    public abstract class AbstractSolver
    {
        public TextReader Reader { get; set; }
        public TextWriter Writer { get; set; }

        public void SolveAll()
        {
            var line = Reader.ReadLine();
            int numCases;
            if (int.TryParse(line, out numCases))
            {
                for (var c = 1; c <= numCases; c++)
                {
                    var result = Solve();
                    Writer.WriteLine("Case #{0}: {1}", c, result);
                }
            }
        }
        public abstract string Solve();

        public IEnumerable<int> parseIntList(string line)
        {
            return line.Split(' ').Select(x => int.Parse(x));
        }

        public static long GCD(long a, long b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }
        public static long GCD(IEnumerable<long> numbers)
        {
            return numbers.Aggregate(GCD);
        }

        public static long LCM(long a, long b)
        {
            return a * b / GCD(a, b);
        }

        public static long LCM(IEnumerable<long> numbers)
        {
            return numbers.Aggregate(LCM);
        }
    }
}
