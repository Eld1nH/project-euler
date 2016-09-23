using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page2._051___060
{
    // XOR decryption
    public class Problem059
    {

        const int keyLength = 3;

        public static string Algorithm()
        {
            string filename = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/Assets/cipher1.txt";
            int[] message = File.ReadAllText(filename)
                                .Split(',')
                                .Select(int.Parse)
                                .ToArray();
            int[] key = AnalyseKey(message, keyLength);
            int[] decrypted = Encrypt(message, key);
            long result = decrypted.Sum();

            return result.ToString();
        }

        private static int[] Encrypt(int[] message, int[] key)
        {
            int[] encrypted = new int[message.Length];

            for (int i = 0; i < message.Length; i++)
            {
                encrypted[i] = message[i] ^ key[i % key.Length];
            }
            return encrypted;
        }

        private static int[] AnalyseKey(int[] message, int keyLength)
        {
            int maxsize = 0;
            for (int i = 0; i < message.Length; i++)
            {
                if (message[i] > maxsize) maxsize = message[i];
            }

            int[,] aMessage = new int[keyLength, maxsize + 1];
            int[] key = new int[keyLength];

            for (int i = 0; i < message.Length; i++)
            {
                int j = i % keyLength;
                aMessage[j, message[i]]++;
                if (aMessage[j, message[i]] > aMessage[j, key[j]]) key[j] = message[i];
            }

            int spaceAscii = 32;
            for (int i = 0; i < keyLength; i++)
            {
                key[i] = key[i] ^ spaceAscii;
            }

            return key;
        } 
    }
}
