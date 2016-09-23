using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page2._051___060
{
    // Spiral primes
    public class Problem058
    {

        public static string Algorithm()
        {
            long result = 0;
            long n = 0;
            double primes = 0;
            double diagonals = 1;

            while (true)
            {
                n++;
                result = 2 * n + 1;
                diagonals += 4;

                if (IsPrime(result * result)) primes++;
                if (IsPrime((result * result) - (result - 1))) primes++;
                if (IsPrime((result * result) - ((result - 1) * 2))) primes++;
                if (IsPrime((result * result) - ((result - 1) * 3))) primes++;

                if (primes / diagonals < 0.10)
                    break;
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
