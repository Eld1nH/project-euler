using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page2._061___070
{
    // Maximum path sum II
    public class Problem067
    {

        public static string Algorithm()
        {
            int[][] input = GenerateInputArray();

            for (int x = 98; x >= 0; x--)
            {
                for (int y = 0; y <= x; y++)
                {
                    input[x][y] += Math.Max(input[x + 1][y], input[x + 1][y + 1]);
                }
            }

            return input[0][0].ToString();
        }

        private static int[][] GenerateInputArray()
        {
            string line = "";
            int[][] output = new int[100][];
            using (StreamReader sr = new StreamReader(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/Assets/triangle.txt"))
            {
                int n = 0;
                while (null != (line = sr.ReadLine()))
                {
                    output[n] = new int[100];
                    string[] split = line.Split(' ');
                    for (int i = 0; i < 100; i++)
                    {
                        output[n][i] = i > split.Length - 1 ? -1 : Convert.ToInt32(split[i]);
                    }
                    n++;
                }
            }

            return output;
        }
    }
}
