using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page1._001___010
{
    // Even fibonacci numbers
    public class Problem002
    {

        public static string Algorithm()
        {
            long result = 2;

            long f = 2;
            long pF = 0;
            while (f * 4 < 4000000)
            {
                long n = f * 4 + pF;
                result += n;
                pF = f;
                f = n;
            }

            return result.ToString();
        }
    }
}
