using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page1._021___030
{
    // Names scores
    public class Problem022
    {

        public static string Algorithm()
        {
            long result = 0;

            string namestring = "";
            using (StreamReader sr = new StreamReader(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/Assets/names.txt"))
            {
                namestring = sr.ReadToEnd();
            }
            string[] names = namestring.Replace("\"", "").Split(',');
            Array.Sort(names);

            for (int i = 0; i < names.Length; i++)
            {
                result += GetNameValue(names[i]) * (i + 1);
            }

            return result.ToString();
        }

        private static string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static long GetNameValue(string name)
        {
            long value = 0;

            for (int i = 0; i < name.Length; i++)
            {
                char character = name.ElementAt(i);
                value += alphabet.IndexOf(character) + 1;
            }

            return value;
        }
    }
}
