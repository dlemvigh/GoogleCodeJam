using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualCodeJam.Test
{
    public class BaseUnitTestCaseRunner
    {
        public static string SingleCase<T>(string input)
            where T : AbstractSolver, new()
        {
            var solver = new T();
            InitStreams(solver, input);

            var result = solver.Solve();            

            CloseStreams(solver);

            return result;
        }

        private static void InitStreams<T>(T solver, string input)
            where T : AbstractSolver
        {
            solver.Reader = new StringReader(input);
        }
        private static void CloseStreams<T>(T solver)
            where T : AbstractSolver
        {
            solver.Reader.Close();
        }
    }
}
