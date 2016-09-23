using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page1._001___010
{
    // Sum square difference
    public class Problem006
    {

        public static string Algorithm()
        {
            long squareSum = 0;
            long sumSquare = 0;
            for (int i = 1; i <= 100; i++)
            {
                squareSum += i;
                sumSquare += (long)Math.Pow(i, 2);
            }
            squareSum = (long)Math.Pow(squareSum, 2);

            return ((long)Math.Abs(squareSum - sumSquare)).ToString();
        }
    }
}
