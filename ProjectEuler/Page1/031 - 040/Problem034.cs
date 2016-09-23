using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page1._031___040
{
    // Digit factorials
    public class Problem034
    {

        public static string Algorithm()
        {
            long result = 0;

            for (int i = 10; i < 40586; i++)
            {
                if (i == DigitFactorial(i))
                {
                    result += i;
                }
            }

            return result.ToString();
        }

        private static long DigitFactorial(int n)
        {
            int sum = 0;
            int[] digits = new int[n.ToString().Length];
            for (int i = 0; i < digits.Length; i++)
            {
                digits[i] = Convert.ToInt32(n.ToString().ElementAt(i).ToString());
                if (digits[i] == 0 || digits[i] == 1)
                {
                    sum += 1;
                }
                else if (digits[i] == 2)
                {
                    sum += 2;
                }
                else
                {
                    int sub = digits[i];
                    for (int j = digits[i] - 1; j >= 2; j--)
                    {
                        sub *= j;
                    }
                    sum += sub;
                }
            }

            return sum;
        }
    }
}
