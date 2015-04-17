using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualEuler
{
    partial class Euler
    {
        static void Euler_1()
        {
            var range = Enumerable.Range(1, 999);
            var result = range.Where(x => x % 3 == 0 || x % 5 == 0).Sum();
            Console.WriteLine(result);

        }

        static void Euler_2()
        {
            var result = Util.Fib()
                .TakeWhile(x => x < 4000000)
                .Where(x => x % 2 == 0)
                .Sum();

            Console.WriteLine(result);
        }

        static void Euler_3()
        {
            var number = 600851475143;
            var largest_prime = 0;
            var factors = new List<int>();

            while(number % 2 == 0)
            {
                number = number / 2;
                largest_prime = 2;
                factors.Add(2);
            }

            for (var cand = 3; cand <= Math.Sqrt(number); cand += 2)
            {
                while(number % cand == 0)
                {
                    number /= cand;
                    largest_prime = cand;
                    factors.Add(cand);
                }
            }
            Console.WriteLine(number);
        }

        static void Euler_6()
        {
            var range = Enumerable.Range(1, 100);

            var sum_of_the_squares = range.Select(x => x * x).Sum();
            var square_of_the_sum = Math.Pow(range.Sum(), 2);

            var diff = Math.Abs(sum_of_the_squares - square_of_the_sum);

            Console.WriteLine("{0} - {1} = {2}", square_of_the_sum, sum_of_the_squares, diff);
        }

        static void Euler_7()
        {
            var range = Util.Prime();
            var result = range.Skip(10000).First();
            Console.WriteLine(result);
        }
        
        static void Euler_8()
        {
            var number = @"73167176531330624919225119674426574742355349194934
96983520312774506326239578318016984801869478851843
85861560789112949495459501737958331952853208805511
12540698747158523863050715693290963295227443043557
66896648950445244523161731856403098711121722383113
62229893423380308135336276614282806444486645238749
30358907296290491560440772390713810515859307960866
70172427121883998797908792274921901699720888093776
65727333001053367881220235421809751254540594752243
52584907711670556013604839586446706324415722155397
53697817977846174064955149290862569321978468622482
83972241375657056057490261407972968652414535100474
82166370484403199890008895243450658541227588666881
16427171479924442928230863465674813919123162824586
17866458359124566529476545682848912883142607690042
24219022671055626321111109370544217506941658960408
07198403850962455444362981230987879927244284909188
84580156166097919133875499200524063689912560717606
05886116467109405077541002256983155200055935729725
71636269561882670428252483600823257530420752963450"
.Replace("\n", "");

            var digits = number.Select(x => x - '0');

            Func<int, int, int> sum_func = (sum, value) => sum + value;
            Func<int, int, int> prod_func = (prod, value) => prod * value;

            var parts = Enumerable.Range(0, digits.Count())
                .Select(x => digits.Skip(x).Take(13));

            var sums = parts.Select(x => x.Aggregate(prod_func));


            var result = sums.Max();
            Console.WriteLine(result);
        }
    }
}
