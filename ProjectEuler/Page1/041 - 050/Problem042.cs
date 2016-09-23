using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page1._041___050
{
    // Coded triangle numbers
    public class Problem042
    {

        public static string Algorithm()
        {
            long result = 0;

            string wordstring = "";
            using (StreamReader sr = new StreamReader(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/Assets/words.txt"))
            {
                wordstring = sr.ReadToEnd();
            }
            string[] words = wordstring.Replace("\"", "").Split(',');

            for (int i = 0; i < words.Length; i++)
            {
                int value = GetNameValue(words[i]);
                int triangle = 0;
                bool found = false;
                int n = 1;

                while (!found)
                {
                    triangle = (int)((0.5 * n) * (n + 1));
                    if (value == triangle)
                    {
                        found = true;
                        result++;
                        break;
                    }
                    if (triangle > value)
                    {
                        found = true;
                        break;
                    }
                    n++;
                }
            }

            return result.ToString();
        }

        private static int GetNameValue(string name)
        {
            int value = 0;

            for (int i = 0; i < name.Length; i++)
            {
                char character = name.ElementAt(i);
                if (character == 'A') value += 1;
                if (character == 'B') value += 2;
                if (character == 'C') value += 3;
                if (character == 'D') value += 4;
                if (character == 'E') value += 5;
                if (character == 'F') value += 6;
                if (character == 'G') value += 7;
                if (character == 'H') value += 8;
                if (character == 'I') value += 9;
                if (character == 'J') value += 10;
                if (character == 'K') value += 11;
                if (character == 'L') value += 12;
                if (character == 'M') value += 13;
                if (character == 'N') value += 14;
                if (character == 'O') value += 15;
                if (character == 'P') value += 16;
                if (character == 'Q') value += 17;
                if (character == 'R') value += 18;
                if (character == 'S') value += 19;
                if (character == 'T') value += 20;
                if (character == 'U') value += 21;
                if (character == 'V') value += 22;
                if (character == 'W') value += 23;
                if (character == 'X') value += 24;
                if (character == 'Y') value += 25;
                if (character == 'Z') value += 26;
            }

            return value;
        }
    }
}
