using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page1._031___040
{
    // Pandigital products
    public class Problem032
    {

        public static string Algorithm()
        {
            long result = 0;

            for (int i = 1; i < 10000; i++)
            {
                if (ConsistOfUniqueNumbers(i))
                {
                    List<int> divs = GetDivisors(i);

                    if (divs.Count() >= 2)
                    {
                        for (int a = 0; a < divs.Count(); a++)
                        {
                            for (int b = a; b < divs.Count(); b++)
                            {
                                if (divs[a] * divs[b] == i)
                                {
                                    int n = Convert.ToInt32(i.ToString() + divs[a].ToString() + divs[b].ToString());

                                    if (IsPandigital(n))
                                    {
                                        result += i;
                                        b = divs.Count;
                                        a = divs.Count;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return result.ToString();
        }

        private static bool ConsistOfUniqueNumbers(int n)
        {
            if (n.ToString().Contains('0'))
                return false;

            int count1 = 0, count2 = 0, count3 = 0,
                count4 = 0, count5 = 0, count6 = 0,
                count7 = 0, count8 = 0, count9 = 0;

            char[] chars = n.ToString().ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                switch (chars[i])
                {
                    case '1':
                        count1++;
                        break;

                    case '2':
                        count2++;
                        break;

                    case '3':
                        count3++;
                        break;

                    case '4':
                        count4++;
                        break;

                    case '5':
                        count5++;
                        break;

                    case '6':
                        count6++;
                        break;

                    case '7':
                        count7++;
                        break;

                    case '8':
                        count8++;
                        break;

                    case '9':
                        count9++;
                        break;
                }
            }

            if (count1 > 1 || count2 > 1 || count3 > 1 ||
                count4 > 1 || count5 > 1 || count6 > 1 ||
                count7 > 1 || count8 > 1 || count9 > 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static List<int> GetDivisors(int n)
        {
            List<int> divisors = new List<int>();
            divisors.Add(n);
            int sqrt = (int)Math.Sqrt(n) + 1;
            for (int i = 1; i <= sqrt; i++)
            {
                if (n % i == 0 && !divisors.Contains(i))
                {
                    divisors.Add(i);
                    int quotient = n / i;
                    if (quotient != n && !divisors.Contains(quotient)) divisors.Add(quotient);
                }
            }

            return divisors;
        }

        private static bool IsPandigital(long n)
        {
            bool[] digits = new bool[10];

            while (n > 0)
            {
                long rem = n % 10;
                if (digits[rem]) return false;
                digits[rem] = true;
                n /= 10;
            }

            return true;
        }
    }
}
