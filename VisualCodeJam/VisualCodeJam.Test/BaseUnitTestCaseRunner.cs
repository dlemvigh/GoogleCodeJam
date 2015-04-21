﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualCodeJam.Test
{
    public class BaseUnitTestCaseRunner
    {
        protected static string baseDir = null;

        public static string SingleCase<T>(string input)
            where T : AbstractSolver, new()
        {
            var solver = new T();
            solver.Reader = new StringReader(input);

            var result = solver.Solve();

            solver.Reader.Close();

            return result;
        }

        public static void File<T>(string path)
            where T : AbstractSolver, new()
        {
            var solver = new T();

            if (!string.IsNullOrEmpty(baseDir))
            {
                path = Path.Combine(baseDir, path);
            }

            solver.Reader = new StreamReader(path + ".in");
            solver.Writer = new StreamWriter(path + ".out");

            solver.SolveAll();

            solver.Reader.Close();
            solver.Writer.Flush();
            solver.Writer.Close();
        }
    }
}
