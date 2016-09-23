using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page1._011___020
{
    // Number letter counts
    public class Problem017
    {

        public static string Algorithm()
        {
            long result = 0;

            for (int i = 1; i <= 1000; i++)
            {
                result += Phoneticize(i).Length;
            }

            return result.ToString();
        }

        private static string[] tens = new string[] { "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        private static string[] units = new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };

        private static string Phoneticize(long n)
        {
            string w = "";

            if ((n / 1000) > 0)
            {
                w += Phoneticize(n / 1000) + "thousand";
                n %= 1000;
            }

            if ((n / 100) > 0)
            {
                w += Phoneticize(n / 100) + "hundred";
                n %= 100;
            }

            if (n > 0)
            {
                if (w != "")
                {
                    w += "and";
                }

                if (n < 20)
                {
                    w += units[n - 1];
                }
                else
                {
                    w += tens[(n / 10) - 1];

                    if ((n % 10) > 0)
                    {
                        w += units[(n % 10) - 1];
                    }
                }
            }

            return w;
        }
    }
}
