using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page1._021___030
{
    // Quadratic primes
    public class Problem027
    {

        public static string Algorithm()
        {
            long result = 0;
            long primeCount = 0;
            long finalA = 0;
            long finalB = 0;

            for (int a = -999; a <= 999; a++)
            {
                for (int b = -999; b <= 999; b++)
                {
                    long subPrimeCount = 0;
                    long value = 0;
                    while (true)
                    {
                        long y = (long)(Math.Pow(value, 2) + (a * value) + b);
                        if (IsPrime(y))
                        {
                            subPrimeCount++;
                            value++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (subPrimeCount > primeCount)
                    {
                        primeCount = subPrimeCount;
                        finalA = a;
                        finalB = b;
                    }
                }
            }

            result = finalA * finalB;

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
