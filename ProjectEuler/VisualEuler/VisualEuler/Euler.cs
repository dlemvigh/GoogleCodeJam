using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualEuler
{
    partial class Euler
    {
        static void Main(string[] args)
        {
            Euler_8();
            Halt();
        }

        private static void Halt()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
