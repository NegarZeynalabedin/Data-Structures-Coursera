using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        private static LinkedList<string>[] Buckets;
        public static long count;
        static void Main(string[] args)
        {
            long bucketCount = long.Parse(Console.ReadLine());
            long numOfQueries = long.Parse(Console.ReadLine());

            string[] commands = new string[numOfQueries];
            for (int i = 0; i < numOfQueries; i++)
                commands[i] = Console.ReadLine();

            Buckets = new LinkedList<string>[bucketCount];
            count = bucketCount;
            List<string> result = new List<string>();
            foreach (var cmd in commands)
            {
                var toks = cmd.Split();
                var cmdType = toks[0];
                var arg = toks[1];

                switch (cmdType)
                {
                    case "add":
                        Add(arg);
                        break;
                    case "del":
                        Delete(arg);
                        break;
                    case "find":
                        result.Add(Find(arg));
                        break;
                    case "check":
                        result.Add(Check(int.Parse(arg)));
                        break;
                }
            }

            foreach (var r in result)
                Console.WriteLine(r);
        }

        public const long BigPrimeNumber = 1000000007;
        public const long ChosenX = 263;

        public static long PolyHash(string str, int start, int count, long p = BigPrimeNumber, long x = ChosenX)
        {
            checked
            {
                long hash = 0;
                for (int i = start + count - 1; i >= 0; i--)
                    hash = (hash * x + (int)str[i]) % p;
                return hash;
            }
        }

        public static void Add(string str)
        {
            long hashStr = PolyHash(str, 0, str.Length);

            int index = (int)(hashStr % count);

            if (Buckets[index] == null)
            {
                Buckets[index] = new LinkedList<string>();
                Buckets[index].AddLast(str);
            }
            else if (!Buckets[index].Contains(str))
                Buckets[index].AddLast(str);

        }

        public static string Find(string str)
        {
            long hashStr = PolyHash(str, 0, str.Length);
            int index = (int)(hashStr % count);

            if (Buckets[index] == null)
                return "no";

            if (Buckets[index].Contains(str))
                return "yes";
            else
                return "no";
        }

        public static void Delete(string str)
        {
            long hashStr = PolyHash(str, 0, str.Length);
            int index = (int)(hashStr % count);


            if (Buckets[index] == null)
                return;

            if (Buckets[index].Contains(str))
                Buckets[index].Remove(str);
        }

        public static string Check(int i)
        {
            if (Buckets[i] == null || Buckets[i].Count == 0)
                return "-";

            return String.Join(" ", Buckets[i].Reverse());
        }
    }
}
