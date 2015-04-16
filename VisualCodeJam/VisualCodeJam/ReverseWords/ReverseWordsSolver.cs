using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualCodeJam.ReverseWords
{
    public class ReverseWordsSolver : AbstractSolver
    {
        public override string Solve()
        {
            var line = Reader.ReadLine();

            var words = line.Split(' ');
            var reversed = words.Reverse();
            var result = string.Join(" ", reversed);

            return result;
        }
    }
}
