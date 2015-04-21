using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualEuler
{
    public class Util
    {
        public static IEnumerable<int> Fib()
        {
            var a = 0;
            var b = 1;

            while (true)
            {
                var t = b;
                b += a;
                a = t;
                yield return b;
            }
        }

        public static IEnumerable<int> Prime()
        {
            yield return 2;

            var primes = new List<int>() { 2 };
            var cand = 1;

            while (true)
            {
                cand += 2;
                if (primes.Any(p => cand % p == 0))
                {
                    continue;
                }
                else
                {
                    primes.Add(cand);
                    yield return cand;
                }
            }
        }

        public static IEnumerable<DateTime> Date(DateTime from, DateTime? to = null)
        {
            var value = from;
            while (!to.HasValue || value <= to)
            {
                yield return value;
                value = value.AddDays(1);
            }

        }

        public static Func<int, int, int> aggr_factorial = (a, b) => a * b;
    }
}
