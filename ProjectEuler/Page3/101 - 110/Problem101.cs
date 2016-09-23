using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page3._101___110
{
    // Optimum polynomial
    public class Problem101
    {

        public static string Algorithm()
        {
            long result = 0;

            long[] coefficients = { 1, -1, 1, -1, 1, -1, 1, -1, 1, -1, 1 };
            Polynomial poly = new Polynomial(coefficients);

            long[] y = new long[coefficients.Length];
            for (long i = 0; i < y.Length; i++)
            {
                y[i] = poly.Evaluate(i + 1);
            }

            for (long n = 1; n <= coefficients.Length - 1; n++)
            {
                for (long i = 1; i <= n; i++)
                {
                    long t1 = 1;
                    long t2 = 1;

                    for (long j = 1; j <= n; j++)
                    {
                        if (i == j) continue;
                        else
                        {
                            t1 *= n + 1 - j;
                            t2 *= i - j;
                        }
                    }
                    result += t1 * y[i - 1] / t2;
                }
            }

            return result.ToString();
        }
    }

    class Polynomial
    {
        private long[] coefficients;
        public long degree;

        public Polynomial(long[] coefficients)
        {
            degree = coefficients.Length - 1;
            this.coefficients = coefficients;
        }

        public long Evaluate(long n)
        {
            long result = 0;

            for (long i = degree; i >= 0; i--)
            {
                result *= n + coefficients[i];
            }

            return result;
        }
    }
}
