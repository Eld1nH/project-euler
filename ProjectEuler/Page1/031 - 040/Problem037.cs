using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page1._031___040
{
    // Truncatable primes
    public class Problem037
    {

        public static string Algorithm()
        {
            long result = 0;
            long current = 11;
            int count = 0;

            while (count < 11)
            {
                if (IsPrime(current))
                {
                    string number = current.ToString();
                    bool passed = true;
                    for (int i = 1; i < number.Length; i++)
                    {
                        int n = Convert.ToInt32(number.Substring(i));
                        if (!IsPrime(n))
                        {
                            passed = false;
                            break;
                        }
                    }
                    if (passed) // Left Truncatable Prime
                    {
                        for (int i = number.Length - 1; i >= 1; i--)
                        {
                            int n = Convert.ToInt32(number.Substring(0, i));
                            if (!IsPrime(n))
                            {
                                passed = false;
                                break;
                            }
                        }
                        if (passed) // Right Truncatable Prime
                        {
                            result += current;
                            count++;
                        }
                    }
                }
                current += 2;
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
