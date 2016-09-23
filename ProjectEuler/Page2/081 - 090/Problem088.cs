using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page2._081___090
{
    // Product-sum numbers
    public class Problem088
    {

        public static string Algorithm()
        {
            long result = 0;

            int maxK = 12000;
            int maxN = 2 * maxK;

            int factorCount = (int)(Math.Log10(maxN) / Math.Log10(2));
            int[] factors = new int[factorCount];

            int[] k = Enumerable.Range(0, maxK + 1).Select(x => x * 2).ToArray();
            k[1] = 0;

            factors[0] = 1;
            int currentMaxFactor = 1;
            int i = 0;

            while (true)
            {
                if (i == 0)
                {
                    if (currentMaxFactor == factorCount)
                        break;

                    if (factors[0] < factors[1])
                    {
                        factors[0]++;
                    }
                    else
                    {
                        currentMaxFactor++;
                        factors[currentMaxFactor - 1] = int.MaxValue;
                        factors[0] = 2;
                    }

                    i++;
                    factors[1] = factors[0] - 1;
                }
                else if (i == currentMaxFactor - 1)
                {
                    factors[i]++;
                    int sum = 0;
                    int prod = 1;
                    for (int j = 0; j < currentMaxFactor; j++)
                    {
                        prod *= factors[j];
                        sum += factors[j];
                    }

                    if (prod > maxN)
                    {
                        i--;
                    }
                    else
                    {
                        int pk = prod - sum + currentMaxFactor;
                        if (pk <= maxK && prod < k[pk])
                        {
                            k[pk] = prod;
                        }
                    }
                }
                else if (factors[i] < factors[i + 1])
                {
                    factors[i]++;
                    factors[i + 1] = factors[i] - 1;
                    i++;
                }
                else if (factors[i] >= factors[i + 1])
                {
                    i--;
                }
            }
            result = k.Distinct().Sum();

            return result.ToString();
        }
    }
}
