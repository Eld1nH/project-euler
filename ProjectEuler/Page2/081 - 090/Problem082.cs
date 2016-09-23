using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace ProjectEuler.Page2._081___090
{
    // Path sum: three ways
    public class Problem082
    {

        private static string filename = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/Assets/matrix.txt";

        public static string Algorithm()
        {
            long result = 0;
            int[][] input = ReadInput(filename);
            int gridSize = input.Length;
            int[] solution = new int[gridSize];

            //initialise solution
            for (int i = 0; i < gridSize; i++)
            {
                solution[i] = input[i][gridSize - 1];
            }

            for (int y = gridSize - 2; y >= 0; y--)
            {
                // Traverse down
                solution[0] += input[0][y];

                for (int x = 1; x < gridSize; x++)
                {
                    solution[x] = Math.Min(solution[x - 1] + input[x][y], solution[x] + input[x][y]);
                }

                //Traverse up
                for (int x = gridSize - 2; x >= 0; x--)
                {
                    solution[x] = Math.Min(solution[x], solution[x + 1] + input[x][y]);
                }

            }
            result = solution.Min();
            return result.ToString();
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
    }
}
