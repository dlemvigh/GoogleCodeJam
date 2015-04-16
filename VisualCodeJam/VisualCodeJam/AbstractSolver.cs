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
        public StreamReader Reader { get; set; }
        public StreamWriter Writer { get; set; }

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
        protected abstract string Solve();
    }
}
