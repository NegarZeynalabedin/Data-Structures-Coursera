using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        public const long BigPrimeNumber = 1000000007;
        public const long ChosenX = 263;
        static void Main(string[] args)
        {

            string pattern = Console.ReadLine();
            string text = Console.ReadLine();

            int patternLenght = pattern.Length;
            int textLenght = text.Length;

            List<string> occurrences = new List<string>();

            long[] H = PreComputeHashes(text, patternLenght, BigPrimeNumber, ChosenX);

            long paternhash = PolyHash(pattern, 0, patternLenght);

            for (int i = 0; i < textLenght - patternLenght + 1; i++)
            {
                if (H[i] == paternhash)
                    if ( Equals(pattern, text, i))
                        occurrences.Add(i.ToString());

            }  
            Console.WriteLine(string.Join(" ", occurrences.ToArray()));
        }

        private static bool Equals(string pattern, string text, int pos)
        {
            for (int i = 0; i < pattern.Length; i++)
                if (pattern[i] != text[i + pos])
                    return false;
            return true;
        }

        public static long[] PreComputeHashes(
           string T,
           int P,
           long p,
           long x)
        {
            int TLenght = T.Length;
            long[] result = new long[TLenght - P + 1];
            result[TLenght - P] = PolyHash(T, TLenght - P, P, p, x);
            long y = 1;
            for (int i = 0; i < P; i++)
                y = (y * x) % p;

            for (int i = TLenght - P - 1; i >= 0; i--)
            {
                long hash = (1000 * p + (result[i + 1] * x % p) - (T[i + P] * y % p) + T[i]) % p;
                result[i] = hash;
            }

            return result;

        }

        public static long PolyHash(
            string str, int start, int count,
            long p = BigPrimeNumber, long x = ChosenX)
        {
            int end = count + start;
            long hash = 0;
            for (int i = end - 1; i >= start; i--)
            {
                hash = (hash * x + str[i]) % p;
            }

            return hash;
        }
    }
}
