using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualCodeJam
{
    public class CaseFileRunner
    {
        public static void Solve<T>(string caseName)
            where T : AbstractSolver, new()
        {
            var solver = new T();

            solver.Reader = new StreamReader(caseName + ".in");
            solver.Writer = new StreamWriter(caseName + ".out");

            solver.SolveAll();

            solver.Reader.Close();
            solver.Writer.Flush();
            solver.Writer.Close();
        }

        
    }
}
