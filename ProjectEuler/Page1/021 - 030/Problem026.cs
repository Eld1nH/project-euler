using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page1._021___030
{
    // Reciprocal cycles
    public class Problem026
    {

        public static string Algorithm()
        {
            long result = 0;
            long cycle = 0;

            for (int i = 1000; i > 0; i--)
            {
                if (cycle >= i)
                    break;

                int[] remainders = new int[i];
                int value = 1;
                int position = 0;

                while (remainders[value] == 0 && value != 0)
                {
                    remainders[value] = position;
                    value *= 10;
                    value %= i;
                    position++;
                }

                if (position - remainders[value] > cycle)
                {
                    cycle = position - remainders[value];
                    result = i;
                }
            }

            return result.ToString();
        }
    }
}
