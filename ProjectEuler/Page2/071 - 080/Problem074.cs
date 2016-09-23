using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page2._071___080
{
    // Digit factorial chains
    public class Problem074
    {

        private static long[] factorials = new long[] { 1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880 };

        public static string Algorithm()
        {
            long result = 0;
            int limit = 1000000;

            for (int i = 1; i <= limit; i++)
            {
                long n = i;
                List<long> seq = new List<long>();

                while (!seq.Contains(n) && seq.Count <= 60)
                {
                    seq.Add(n);
                    n = FactorialSum(n);
                }

                if (seq.Count == 60) 
                    result++;
            }

            return result.ToString();
        }

        private static long FactorialSum(long n)
        {
            long temp = n;
            long facsum = 0;

            while (temp > 0)
            {
                facsum += factorials[temp % 10];
                temp /= 10;
            }
            return facsum;
        }
    }
}
