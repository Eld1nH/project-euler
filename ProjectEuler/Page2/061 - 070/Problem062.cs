using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ProjectEuler.Page2._061___070
{
    // Cubic permutations
    public class Problem062
    {

        public static string Algorithm()
        {
            long result = 0;
            SortedList<long, Cuboid> cubes = new SortedList<long, Cuboid>();

            long n = 0;
            while (true)
            {
                n++;
                long largePerm = LargestPermutation(n * n * n);

                if (!cubes.ContainsKey(largePerm))
                    cubes.Add(largePerm, new Cuboid() { N = n, Perms = 0 });

                if (++cubes[largePerm].Perms == 5)
                {
                    result = cubes[largePerm].N;
                    break;
                }
            }

            return (result * result * result).ToString();
        }

        private static long LargestPermutation(long n)
        {
            long k = n;
            int[] digits = new int[10];
            long result = 0;

            while (k > 0)
            {
                digits[k % 10]++;
                k /= 10;
            }

            for (int i = 9; i >= 0; i--)
            {
                for (int j = 0; j < digits[i]; j++)
                {
                    result = result * 10 + i;
                }
            }

            return result;
        }
    }

    class Cuboid
    {
        public long N { get; set; }
        public int Perms { get; set; }
    }
}
