using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page1._031___040
{
    // Champernowne's constant
    public class Problem040
    {

        public static string Algorithm()
        {
            long result = 1;

            for (int i = 1; i <= 1000000; i *= 10)
            {
                int s = 1;
                int n = i;
                while (n > s.ToString().Length)
                {
                    n -= s.ToString().Length;
                    s++;
                }
                int k = Convert.ToInt32(((s.ToString())[n - 1]).ToString());
                result *= k;
            }

            return result.ToString();
        }
    }
}
