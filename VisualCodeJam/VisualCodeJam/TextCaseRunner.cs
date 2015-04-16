using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualCodeJam
{
    public class TextCaseRunner
    {
        public static void SingleCase<T>(string input)
            where T : AbstractSolver, new()
        {
            var solver = new T();
            InitStreams(solver, input);

            var result = solver.Solve();
            solver.Writer.WriteLine(result);

            CloseStreams(solver);
            Halt();
        }

        public static void AllCases<T>(string input)
            where T : AbstractSolver, new()
        {
            var solver = new T();
            InitStreams(solver, input);

            solver.SolveAll();

            CloseStreams(solver);
            Halt();
        }

        private static void Halt()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void InitStreams<T>(T solver, string input)
            where T : AbstractSolver
        {
            solver.Reader = new StringReader(input);
            solver.Writer = new StringWriter();
        }

        private static void CloseStreams<T>(T solver)
            where T : AbstractSolver
        {
            solver.Reader.Close();
            solver.Writer.Flush();
            Console.Write(solver.Writer);
            solver.Writer.Flush();
            solver.Writer.Close();
        }
    }
}
