using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page2._091___100
{
    // Amicable chains
    public class Problem095
    {

        public static string Algorithm()
        {
            int result = 0;
            int longest = 0;
            int limit = 1000000;

            for (int i = 12496; i < limit; i++)
            {
                List<int> chain = new List<int>();
                chain.Add(i);

                int n = SumProperDivisors(i);
                while (true)
                {
                    if (n == i)
                    {
                        if (chain.Count >= longest)
                        {
                            longest = chain.Count;
                            result = chain.Min();
                        }
                        break;
                    }

                    if (chain.Contains(n) && n != i)
                        break;

                    if (n >= limit || n == 1)
                        break;

                    chain.Add(n);
                    n = SumProperDivisors(n);
                }
            }

            return result.ToString();
        }

        public static int SumProperDivisors(int n)
        {
            int sum = 1;
            int max = (int)Math.Sqrt(n);
            for (int i = 2; i < max; i++)
            {
                if (n % i == 0)
                {
                    sum += i;
                    sum += n / i;
                }
            }
            return sum;
        }
    }
}
