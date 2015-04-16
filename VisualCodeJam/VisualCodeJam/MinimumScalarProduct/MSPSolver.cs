using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualCodeJam.MinimumScalarProduct
{
    public class MSPSolver : AbstractSolver
    {
        public override string Solve()
        {
            Reader.ReadLine();
            var line1 = Reader.ReadLine();
            var line2 = Reader.ReadLine();

            var v1 = line1.Split(' ').Select(text => long.Parse(text));
            var v2 = line2.Split(' ').Select(text => long.Parse(text));

            v1 = v1.OrderBy(x => x);
            v2 = v2.OrderByDescending(x => x);

            var sum = v1.Zip(v2, (a, b) => a * b).Sum();

            return sum.ToString();
        }
    }
}
