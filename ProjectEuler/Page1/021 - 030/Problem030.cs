using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page1._021___030
{
    // Digit fifth powers
    public class Problem030
    {

        public static string Algorithm()
        {
            long result = 0;

            for (int i = 11; i < 200000; i++)
            {
                int[] digits = new int[i.ToString().Length];
                for (int d = 0; d < digits.Length; d++)
                {
                    digits[d] = Convert.ToInt32(i.ToString().ElementAt(d).ToString());
                }

                long value = 0;
                for (int j = 0; j < digits.Length; j++)
                {
                    value += (long)Math.Pow(digits[j], 5);
                }

                if (value == i)
                {
                    result += value;
                }
            }

            return result.ToString();
        }
    }
}
