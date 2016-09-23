using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page1._031___040
{
    // Circular primes
    public class Problem035
    {

        public static string Algorithm()
        {
            long result = 0;

            for (int i = 2; i < 1000000; i++)
            {
                if (IsPrime(i))
                {
                    int rotations = i.ToString().Length;

                    if (rotations == 1)
                    {
                        result++;
                    }
                    else
                    {
                        string n = i.ToString();
                        bool circlePrime = true;
                        for (int j = 0; j < rotations - 1; j++)
                        {
                            n = n.Insert(n.Length, n.ElementAt(0).ToString()).Remove(0, 1);

                            if (!IsPrime(Convert.ToInt32(n)))
                            {
                                circlePrime = false;
                                break;
                            }
                        }

                        if (circlePrime)
                        {
                            result++;
                        }
                    }
                }
            }

            return result.ToString();
        }

        private static bool IsPrime(long input)
        {
            if (input <= 1)
                return false;

            long max = (long)Math.Sqrt(input);

            for (long i = 2; i <= max; i++)
            {
                if (input % i == 0)
                    return false;
            }

            return true;
        }
    }
}
