using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualCodeJam
{
    public class HaircutSolver : AbstractSolver
    {
        public override string Solve()
        {
            var line = Reader.ReadLine();
            var ints = parseIntList(line);
            var B = ints.First();
            var N = ints.Last();

            var M = parseIntList(Reader.ReadLine());
            var cycle_time = LCM(M);
            var cycle_haircuts = M.Aggregate(0, (sum, next) => sum + cycle_time / next);

            var b = B % cycle_haircuts;

            var barbers = new SortedSet<Barber>();
            var b2 = M.Select(x => new Barber(x));

            while (b > 1)
            {
                var barber = barbers.First();
                barbers.Remove(barber);
                barber.Next();
                barbers.Add(barber);
                b--;
            }
            var index = barbers.First().Index;
            return (index + 1).ToString();
            throw new NotImplementedException();
        }

        class Barber : IComparable<Barber>
        {
            public int Speed { get; set; }
            public int NextAvailable { get; set; }
            public int Index { get; set; }

            private static int counter = 0;

            public Barber(int speed)
            {
                Index = counter++;
                Speed = speed;
            }

            public void Next()
            {
                NextAvailable += Speed;
            }

            public int CompareTo(Barber other)
            {
                if (NextAvailable == other.NextAvailable)
                {
                    Index.CompareTo(other.Index);
                }
                return NextAvailable.CompareTo(other.NextAvailable);
            }
        }
    }
}
