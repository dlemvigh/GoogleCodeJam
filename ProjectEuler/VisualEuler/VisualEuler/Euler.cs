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
            using (var reader = new StreamReader("base64pdf.txt"))
            using(var writer = new BinaryWriter("binary.pdf"))
            {
                var data = reader.ReadLine();
                var bin = Convert.FromBase64String(data);
                writer.Write(bin);
                writer.Flush();
                writer.Close();
            }
            Halt();
        }

        private static void Halt()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
