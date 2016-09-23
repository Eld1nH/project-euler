using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ProjectEuler.Page2._091___100
{
    // Largest exponential
    public class Problem099
    {

        private static string filename = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/Assets/base_exp.txt";

        public static string Algorithm()
        {
            int result = 0;
            double max = 0.0;
            int[,] input = ReadInput(filename);

            for (int i = 0; i < input.GetLength(0); i++)
            {
                double b = Math.Log(input[i, 0]);
                double n = b * input[i, 1];
                if (n > max)
                {
                    max = n;
                    result = i + 1;
                }
            }

            return result.ToString();
        }

        private static int[,] ReadInput(string filename)
        {
            string[] lines = File.ReadAllLines(filename).ToArray();
            int[,] result = new int[lines.Length, 2];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] split = lines[i].Split(',');
                result[i, 0] = Convert.ToInt32(split[0]);
                result[i, 1] = Convert.ToInt32(split[1]);
            }
            return result;
        }
    }
}
