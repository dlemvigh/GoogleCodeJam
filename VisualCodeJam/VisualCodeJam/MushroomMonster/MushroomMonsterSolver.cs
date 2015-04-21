using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualCodeJam.MushroomMonster
{
    public class MushroomMonsterSolver : AbstractSolver
    {
        public override string Solve()
        {
            var line = Reader.ReadLine();
            var N = int.Parse(line);

            line = Reader.ReadLine();
            var m = line.Split(' ').Select(x => int.Parse(x)).ToArray();

            var eaten1 = 0;
            var biggestDiff = 0;
            for (var i = 0; i < N - 1; i++)
            {
                var diff = m[i] - m[i + 1];
                if (diff > 0)
                {
                    eaten1 += diff;
                }
                if (diff > biggestDiff)
                {
                    biggestDiff = diff;
                }
            }

            var eaten2 = 0;
            var rate = biggestDiff;
            for (var i = 0; i < N - 1; i++)
            {
                if (m[i] > rate)
                {
                    eaten2 += rate;
                }else
                {
                    eaten2 += m[i];
                }
             
            }

            return string.Format("{0} {1}", eaten1, eaten2);
        }
    }
}
