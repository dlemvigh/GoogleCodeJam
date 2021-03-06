﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
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

        static void Euler_16()
        {
            var @base = new BigInteger(2);
            var power = new BigInteger(1000);
            var value = BigInteger.Pow(@base, 1000);
            var sum = value.ToString().Select(x => x - '0').Sum();
            Console.WriteLine(sum);
        }

        static void Euler_18()
        {
            var input = @"75
95 64
17 47 82
18 35 87 10
20 04 82 47 65
19 01 23 75 03 34
88 02 77 73 07 63 67
99 65 04 28 06 16 70 92
41 41 26 56 83 40 80 70 33
41 48 72 33 47 32 37 16 94 29
53 71 44 65 25 43 91 52 97 51 14
70 11 33 28 77 73 17 78 39 68 17 57
91 71 52 38 17 14 91 43 58 50 27 29 48
63 66 04 68 89 53 67 30 73 16 69 87 40 31
04 62 98 27 23 09 70 98 73 93 38 53 60 04 23";

            var data = input.Split('\n').Select(line => line.Split(' ').Select(x => int.Parse(x)).ToList()).ToList();
            
            for(var row = data.Count()-2; row >= 0; row--)
            {
                for (var i = 0; i < data[row].Count(); i++)
                {
                    data[row][i] += Math.Max(data[row + 1][i], data[row + 1][i + 1]);
                }
            }

            var result = data[0][0];
            Console.WriteLine(result);
        }

        static void Euler_19()
        {
            var from = new DateTime(1901, 1, 1);
            var to = new DateTime(2000, 12, 31);
            var dates = Util.Date(from, to);
            var result = dates.Count(x => x.DayOfWeek == DayOfWeek.Sunday && x.Day == 1);
            Console.WriteLine(result);
        }

        static void Euler_20()
        {
            var range = Enumerable.Range(1, 100).Select(x => new BigInteger(x));
            var factorial = range.Aggregate((a, b) => a * b);
            var sum = factorial.ToString().Select(x => x - '0').Sum();
            Console.WriteLine(sum);
        }

        static void Euler_22()
        {
            using (var reader = new StreamReader("p022_names.txt"))
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                var raw = reader.ReadLine().Replace("\"", "");
                var names = raw.Split(',');
                Array.Sort(names);
                var sum = 0;
                for (var i = 0; i < names.Length; i++)
                {
                    var score = names[i].Select(x => x - 'A' + 1).Sum();
                    sum += score * (i+1);
                }
                Console.WriteLine(sum);
            }
        }

        static void Euler_59()
        {
            var msg = "79,59,12,2,79,35,8,28,20,2,3,68,8,9,68,45,0,12,9,67,68,4,7,5,23,27,1,21,79,85,78,79,85,71,38,10,71,27,12,2,79,6,2,8,13,9,1,13,9,8,68,19,7,1,71,56,11,21,11,68,6,3,22,2,14,0,30,79,1,31,6,23,19,10,0,73,79,44,2,79,19,6,28,68,16,6,16,15,79,35,8,11,72,71,14,10,3,79,12,2,79,19,6,28,68,32,0,0,73,79,86,71,39,1,71,24,5,20,79,13,9,79,16,15,10,68,5,10,3,14,1,10,14,1,3,71,24,13,19,7,68,32,0,0,73,79,87,71,39,1,71,12,22,2,14,16,2,11,68,2,25,1,21,22,16,15,6,10,0,79,16,15,10,22,2,79,13,20,65,68,41,0,16,15,6,10,0,79,1,31,6,23,19,28,68,19,7,5,19,79,12,2,79,0,14,11,10,64,27,68,10,14,15,2,65,68,83,79,40,14,9,1,71,6,16,20,10,8,1,79,19,6,28,68,14,1,68,15,6,9,75,79,5,9,11,68,19,7,13,20,79,8,14,9,1,71,8,13,17,10,23,71,3,13,0,7,16,71,27,11,71,10,18,2,29,29,8,1,1,73,79,81,71,59,12,2,79,8,14,8,12,19,79,23,15,6,10,2,28,68,19,7,22,8,26,3,15,79,16,15,10,68,3,14,22,12,1,1,20,28,72,71,14,10,3,79,16,15,10,68,3,14,22,12,1,1,20,28,68,4,14,10,71,1,1,17,10,22,71,10,28,19,6,10,0,26,13,20,7,68,14,27,74,71,89,68,32,0,0,71,28,1,9,27,68,45,0,12,9,79,16,15,10,68,37,14,20,19,6,23,19,79,83,71,27,11,71,27,1,11,3,68,2,25,1,21,22,11,9,10,68,6,13,11,18,27,68,19,7,1,71,3,13,0,7,16,71,28,11,71,27,12,6,27,68,2,25,1,21,22,11,9,10,68,10,6,3,15,27,68,5,10,8,14,10,18,2,79,6,2,12,5,18,28,1,71,0,2,71,7,13,20,79,16,2,28,16,14,2,11,9,22,74,71,87,68,45,0,12,9,79,12,14,2,23,2,3,2,71,24,5,20,79,10,8,27,68,19,7,1,71,3,13,0,7,16,92,79,12,2,79,19,6,28,68,8,1,8,30,79,5,71,24,13,19,1,1,20,28,68,19,0,68,19,7,1,71,3,13,0,7,16,73,79,93,71,59,12,2,79,11,9,10,68,16,7,11,71,6,23,71,27,12,2,79,16,21,26,1,71,3,13,0,7,16,75,79,19,15,0,68,0,6,18,2,28,68,11,6,3,15,27,68,19,0,68,2,25,1,21,22,11,9,10,72,71,24,5,20,79,3,8,6,10,0,79,16,8,79,7,8,2,1,71,6,10,19,0,68,19,7,1,71,24,11,21,3,0,73,79,85,87,79,38,18,27,68,6,3,16,15,0,17,0,7,68,19,7,1,71,24,11,21,3,0,71,24,5,20,79,9,6,11,1,71,27,12,21,0,17,0,7,68,15,6,9,75,79,16,15,10,68,16,0,22,11,11,68,3,6,0,9,72,16,71,29,1,4,0,3,9,6,30,2,79,12,14,2,68,16,7,1,9,79,12,2,79,7,6,2,1,73,79,85,86,79,33,17,10,10,71,6,10,71,7,13,20,79,11,16,1,68,11,14,10,3,79,5,9,11,68,6,2,11,9,8,68,15,6,23,71,0,19,9,79,20,2,0,20,11,10,72,71,7,1,71,24,5,20,79,10,8,27,68,6,12,7,2,31,16,2,11,74,71,94,86,71,45,17,19,79,16,8,79,5,11,3,68,16,7,11,71,13,1,11,6,1,17,10,0,71,7,13,10,79,5,9,11,68,6,12,7,2,31,16,2,11,68,15,6,9,75,79,12,2,79,3,6,25,1,71,27,12,2,79,22,14,8,12,19,79,16,8,79,6,2,12,11,10,10,68,4,7,13,11,11,22,2,1,68,8,9,68,32,0,0,73,79,85,84,79,48,15,10,29,71,14,22,2,79,22,2,13,11,21,1,69,71,59,12,14,28,68,14,28,68,9,0,16,71,14,68,23,7,29,20,6,7,6,3,68,5,6,22,19,7,68,21,10,23,18,3,16,14,1,3,71,9,22,8,2,68,15,26,9,6,1,68,23,14,23,20,6,11,9,79,11,21,79,20,11,14,10,75,79,16,15,6,23,71,29,1,5,6,22,19,7,68,4,0,9,2,28,68,1,29,11,10,79,35,8,11,74,86,91,68,52,0,68,19,7,1,71,56,11,21,11,68,5,10,7,6,2,1,71,7,17,10,14,10,71,14,10,3,79,8,14,25,1,3,79,12,2,29,1,71,0,10,71,10,5,21,27,12,71,14,9,8,1,3,71,26,23,73,79,44,2,79,19,6,28,68,1,26,8,11,79,11,1,79,17,9,9,5,14,3,13,9,8,68,11,0,18,2,79,5,9,11,68,1,14,13,19,7,2,18,3,10,2,28,23,73,79,37,9,11,68,16,10,68,15,14,18,2,79,23,2,10,10,71,7,13,20,79,3,11,0,22,30,67,68,19,7,1,71,8,8,8,29,29,71,0,2,71,27,12,2,79,11,9,3,29,71,60,11,9,79,11,1,79,16,15,10,68,33,14,16,15,10,22,73";
            var encrypted = msg.Split(',').Select(x => int.Parse(x));

            var range = Enumerable.Range('a', 26).ToList();
            var perm = new List<int[]>();
            range.ForEach(a =>
                range.ForEach(b =>
                    range.ForEach(c =>
                        perm.Add(new[] { a, b, c })
                    )
                )
            );

            var test = perm.Select(p => encrypted.Select((value, index) => p[index % 3] ^ value)).First();
       }
    }
}
