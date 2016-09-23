using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page1._011___020
{
    // Counting sundays
    public class Problem019
    {

        public static int[] mKey = { 6, 2, 2, 5, 0, 3, 5, 1, 4, 6, 2, 4 };

        public static string Algorithm()
        {
            long result = 0;
            int dN = 0;

            for (int y = 1901; y <= 2000; y++)
            {
                for (int m = 1; m <= 12; m++)
                {
                    string yS = y.ToString();
                    int fDoY = Convert.ToInt32(yS.Substring(0, 2));
                    int lDoY = Convert.ToInt32(yS.Substring(2, 2));

                    int step1 = lDoY + (int)(lDoY / 4);
                    int step2 = DateTime.IsLeapYear(y) && (m == 1 || m == 2) ? mKey[m - 1] - 1 : mKey[m - 1];
                    int step3 = 1;
                    dN = (step1 + step2 + step3) % 7;

                    if (fDoY == 19)
                        dN++;

                    while (dN < 1)
                    {
                        dN += 7;
                    }

                    if (dN == 7)
                        result++;
                }
            }

            return result.ToString();
        }
    }
}
