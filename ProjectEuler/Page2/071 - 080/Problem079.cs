using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page2._071___080
{
    // Passcode derivation
    public class Problem079
    {

        private static string filename = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/Assets/keylog.txt";

        public static string Algorithm()
        {
            string[] codes = File.ReadAllLines(filename).Distinct().ToArray();
            char nextChar = codes[0][0];
            List<char> triedChars = new List<char> { nextChar };
            List<char> code = new List<char>();

            while (true)
            {
                if (codes.All(c => !c.Skip(1).Contains(nextChar))) 
                { 
                    code.Add(nextChar); 
                    codes = codes.Select(l => l.TrimStart(nextChar)).ToArray(); 
                    triedChars.Clear(); 
                }
                codes = codes.Where(c => c != "").Distinct().ToArray();
                if (codes.Length > 0)
                {
                    nextChar = codes.Select(i => i.First())
                                    .Where(i => !triedChars.Contains(i)).First();
                    triedChars.Add(nextChar);
                }
                else break;
            }

            return new String(code.ToArray());
        }
    }
}
