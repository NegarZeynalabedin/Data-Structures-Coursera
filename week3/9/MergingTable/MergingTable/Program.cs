using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MergingTable
{
    class Program
    {
        public static long[] Parent;
        public static long[] Rank;
        public static long[] Answer;
        public static long MaxSize;
        static void Main(string[] args)
        {
            string numOfCount = Console.ReadLine();
            string[] numOfCountSpl = numOfCount.Split();
            int numOfTables = int.Parse(numOfCountSpl[0]);
            int numOfQueries = int.Parse(numOfCountSpl[1]);

            string tableSizesInput = Console.ReadLine();
            string[] tableSizesInputSpl = tableSizesInput.Split();
            long[] tableSizes = new long[numOfTables];
            for (int i = 0; i < numOfTables; i++)
                tableSizes[i] = long.Parse(tableSizesInputSpl[i]);

            long[] targetTables = new long[numOfQueries];
            long[] sourceTables = new long[numOfQueries];
            for (int i = 0; i < numOfQueries; i++)
            {
                string query = Console.ReadLine();
                string[] querySpl = query.Split();
                targetTables[i] = long.Parse(querySpl[0]);
                sourceTables[i] = long.Parse(querySpl[1]);
            }

            long TableCount = numOfTables;
            long QueryCount = numOfQueries;

            Parent = new long[TableCount];
            Rank = new long[TableCount];
            Answer = new long[QueryCount];

            MaxSize = tableSizes.Max();

            for (int i = 0; i < TableCount; i++)
            {
                Parent[i] = i;
                Rank[i] = 0;
            }

            long Source, Target, SP, TP;
            for (long i = 0; i < QueryCount; i++)
            {
                Source = sourceTables[i] - 1;
                Target = targetTables[i] - 1;

                if (Source == Target)
                {
                    Answer[i] = MaxSize;
                    continue;
                }

                SP = Find(Source);
                TP = Find(Target);

                Answer[i] = Union(tableSizes, TP, SP, i);
            }

            foreach (var a in Answer)
                Console.WriteLine(a);
        }

        private static long Find(long f)
        {
            if (Parent[f] != f)
            {
                Parent[f] = Find(Parent[f]);
                Rank[f] = 0;
            }

            return Parent[f];
        }

        private static long Union(long[] tableSizes, long t, long s, long i)
        {
            if (t == s)
            {
                return MaxSize;
            }

            if (Rank[s] > Rank[t])
            {
                SetTableSize(tableSizes, s, t);
                Parent[t] = Parent[s];
            }
            else
            {
                SetTableSize(tableSizes, t, s);
                Parent[s] = Parent[t];
                if (Rank[s] == Rank[t])
                    Rank[t]++;
            }
            return MaxSize;
        }

        private static void SetTableSize(long[] tableSizes, long target, long source)
        {
            tableSizes[target] += tableSizes[source];
            tableSizes[source] = 0;
            if (tableSizes[target] > MaxSize)
                MaxSize = tableSizes[target];
        }
    }
}
