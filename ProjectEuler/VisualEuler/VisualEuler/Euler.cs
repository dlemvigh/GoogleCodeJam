using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualEuler
{
    partial class Euler
    {
        static void Main(string[] args)
        {
            string input = null;
            input = "5H 5C 6S 7S KD 2C 3S 8S 8D TD\n5D 8C 9S JS AC 2C 5C 7D 8S QH\n2D 9C AS AH AC 3D 6D 7D TD QD\n4D 6S 9H QH QC 3D 6D 7H QD QS\n2H 2D 4C 4D 4S 3C 3D 3S 9S 9D";
            using (var reader = new StreamReader("p054_poker.txt"))
            {
                input = reader.ReadToEnd();
            }

            Euler54(input);
        }

        private static void Halt()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
