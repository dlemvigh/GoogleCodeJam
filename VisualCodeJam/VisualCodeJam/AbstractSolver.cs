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

        public static int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }
        public static int GCD(IEnumerable<int> numbers)
        {
            return numbers.Aggregate(GCD);
        }

        public static int LCM(int a, int b)
        {
            return a * b / GCD(a, b);
        }

        public static int LCM(IEnumerable<int> numbers)
        {
            return numbers.Aggregate(LCM);
        }
    }
}
