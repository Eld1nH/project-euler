using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page2._081___090
{
    // Path sum: two ways
    public class Problem081
    {

        private static string filename = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/Assets/matrix.txt";

        public static string Algorithm()
        {
            long result = 0;
            int[][] input = ReadInput(filename);

            for (int i = 78; i >= 0; i--)
            {
                int x = i;
                int y = 79;

                while (x < 80 && y >= 0)
                {
                    if (y == 79)
                    {
                        input[x][y] += input[x + 1][y];
                    }
                    else
                    {
                        if (x == 79)
                        {
                            input[x][y] += input[x][y + 1];
                        }
                        else
                        {
                            input[x][y] += input[x + 1][y] < input[x][y + 1] ? input[x + 1][y] : input[x][y + 1];
                        }
                    }

                    x++;
                    y--;
                }
            }

            for (int i = 78; i >= 0; i--)
            {
                int x = 0;
                int y = i;

                while (x < 80 && y >= 0)
                {
                    if (x == 79)
                    {
                        input[x][y] += input[x][y + 1];
                    }
                    else
                    {
                        input[x][y] += input[x + 1][y] < input[x][y + 1] ? input[x + 1][y] : input[x][y + 1];
                    }

                    x++;
                    y--;
                }
            }
            result = input[0][0];
            return result.ToString();
        }

        private static void PrintArray(int[][] input)
        {
            for (int y = 0; y < 80; y++)
            {
                Debug.WriteLine("");
                for (int x = 0; x < 80; x++)
                {
                    string spaces = " ";

                    for (int i = 0; i < 6 - input[x][y].ToString().Length; i++)
                    {
                        spaces += " ";
                    }

                    Debug.Write(spaces + input[x][y]);
                }
            }
        }

        private static int[][] ReadInput(string filename)
        {
            int[][] output = new int[80][];
            string[] lines = File.ReadAllLines(filename).Distinct().ToArray();

            for (int i = 0; i < lines.Length; i++)
            {
                output[i] = new int[80];
                string[] split = lines[i].Split(',');
                for (int j = 0; j < split.Length; j++)
                {
                    output[i][j] = Convert.ToInt32(split[j]);
                }
            }

            return output;
        }
    }
}
