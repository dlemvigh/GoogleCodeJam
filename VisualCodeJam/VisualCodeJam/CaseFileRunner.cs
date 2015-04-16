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

            var solverNamespace = typeof(T).Namespace;
            var runnerNamespace = typeof(CaseFileRunner).Namespace;
            var relativeNamespace = solverNamespace
                .Replace(runnerNamespace, "")
                .Replace('.', '/');

            var path = "../.." + relativeNamespace + "/";
            solver.Reader = new StreamReader(path + caseName + ".in");
            solver.Writer = new StreamWriter(path + caseName + ".out");

            solver.SolveAll();

            solver.Reader.Close();
            solver.Writer.Flush();
            solver.Writer.Close();
        }

        
    }
}
