using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page1._001___010
{
    // Multiples of 3 and 5
    public class Problem001
    {

        public static string Algorithm()
        {
            long result = 0;

            for (int i = 3; i < 1000; i += 3)
                result += i;

            for (int i = 5; i < 1000; i += 5)
                if (i % 3 != 0)
                    result += i;

            return result.ToString();
        }
    }
}
