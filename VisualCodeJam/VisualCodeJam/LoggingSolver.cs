using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualCodeJam
{
    public class LoggingSolver : AbstractSolver
    {
        public override string Solve()
        {
            var line = Reader.ReadLine();
            var N = int.Parse(line);

            var trees = new Point[N];
            for (var i = 0; i < N; i++)
            {
                line = Reader.ReadLine();
                var values = line.Split(' ').Select(x => int.Parse(x));
                trees[i] = new Point(values.First(), values.Last());
            }

            var result = new StringBuilder();
            foreach(var P in trees)
            {
                var min = int.MaxValue;
                foreach(var Q in trees.Where(x => x != P))
                {
                    var count = 0;
                    var PQ = Q - P;
                    foreach(var T in trees.Where(x => x != P && x != Q))
                    {
                        var PT = T - P;
                        var angle = PQ.GetAngle(PT);
                        if (angle < Math.PI && angle > 0)
                        {
                            //T is left of PQ
                            count++;
                        }
                    }
                    if (count < min)
                    {
                        min = count;
                    }
                }
                result.Append(Environment.NewLine + min.ToString());
            }

            return result.ToString();
        }

        class Point
        {
            public int X { get; set; }
            public int Y { get; set; }

            public double Angle {
                get
                {
                    return (Math.Atan2(Y, X) + TAU) % TAU;
                }
            }

            private static double TAU = Math.PI * 2;

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public override string ToString()
            {
                return string.Format("({0},{1})", X, Y);
            }

            internal double GetAngle(Point pt)
            {
                return (pt.Angle - Angle + TAU) % TAU;
            }

            public static Point operator +(Point a, Point b)
            {
                return new Point(a.X + b.Y, a.Y + b.Y);
            }

            public static Point operator -(Point a, Point b)
            {
                return new Point(a.X - b.X, a.Y - b.Y);
            }
        }
    }
}
