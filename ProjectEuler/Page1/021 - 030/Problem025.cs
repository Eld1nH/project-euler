using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ProjectEuler.Page1._021___030
{
    // 1000-digit Fibbonacci number
    public class Problem025
    {

        public static string Algorithm()
        {
            long result = 0;
            BigInteger total = 0;
            BigInteger pValue = 0;
            BigInteger ppValue = 0;

            while (total.ToString().Length != 1000)
            {
                result++;
                if (result == 1)
                {
                    total = 1;
                }
                else if (result > 1)
                {
                    total = pValue + ppValue;
                }

                ppValue = pValue;
                pValue = total;
            }

            return result.ToString();
        }
    }
}
