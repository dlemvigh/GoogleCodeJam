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

            line = Reader.ReadLine();
            var M = line.Split(' ').Select(x => long.Parse(x)).ToList();
            var cycle_time = LCM(M);
            var cycle_haircuts = M.Aggregate(0L, (sum, next) => sum + cycle_time / next);

            var barbers = new SortedSet<Barber>();
            for(var i = 0; i < M.Count(); i++)
            {
                var barber = new Barber(M[i], i);
                barbers.Add(barber);
            }

            var n = N % cycle_haircuts;
            if (n == 0)
            {
                n = cycle_haircuts;
            }
            while (n > 1)
            {
                var barber = barbers.First();
                barbers.Remove(barber);
                barber.Next();
                barbers.Add(barber);
                n--;
            }
            var index = barbers.First().Index;
            return (index + 1).ToString();
            throw new NotImplementedException();
        }

        class Barber : IComparable<Barber>
        {
            public long Speed { get; set; }
            public long NextAvailable { get; set; }
            public int Index { get; set; }

            public Barber(long speed, int index)
            {
                Index = index;
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
                    return Index.CompareTo(other.Index);
                }
                return NextAvailable.CompareTo(other.NextAvailable);
            }

            public override bool Equals(object obj)
            {
                if (obj is Barber)
                {
                    var barber = obj as Barber;
                    return Index.Equals(barber.Index);
                }
                return base.Equals(obj);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }
    }
}
