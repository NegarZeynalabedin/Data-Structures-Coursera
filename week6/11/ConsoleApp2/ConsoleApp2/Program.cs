using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BTT
{
    class Program
    {
        public static long Left(long[][] nodes, long n) => nodes[n][1];
        public static long Right(long[][] nodes, long n) => nodes[n][2];
        public static long Key(long[][] nodes, long n) => nodes[n][0];
        public static void Main(string[] args)
        {
            int countOfInput = int.Parse(Console.ReadLine());
            long[][] nodes = new long[countOfInput][];
            for (int i = 0; i < countOfInput; i++)
            {
                string input = Console.ReadLine();
                string[] inputStr = input.Split();
                nodes[i][0] = long.Parse(inputStr[0]);
                nodes[i][1] = long.Parse(inputStr[1]);
                nodes[i][2] = long.Parse(inputStr[2]);
            }

            long[][] result = new long[3][];
            result[0] = InOrder(nodes, 0);
            result[1] = PreOrder(nodes, 0);
            result[2] = PostOrder(nodes, 0);

            Console.WriteLine(string.Join(" ", result[0].Select(x => x.ToString()).ToArray()));
        }

        private static long[] PostOrder(long[][] nodes, int v)
        {
            long[] result = new long[nodes.Length];
            int lastPos = 0;
            PostOrder(0);
            return result;

            void PostOrder(long r)
            {
                if (Left(nodes, r) != -1)
                    PostOrder(Left(nodes, r));

                if (Right(nodes, r) != -1)
                    PostOrder(Right(nodes, r));

                result[lastPos] = Key(nodes, r);
                lastPos++;
            }
        }

        private static long[] PreOrder(long[][] nodes, int v)
        {
            long[] result = new long[nodes.Length];
            int lastPos = 0;
            PreOrder(0);
            return result;

            void PreOrder(long r)
            {
                result[lastPos] = Key(nodes, r);
                lastPos++;

                if (Left(nodes, r) != -1)
                    PreOrder(Left(nodes, r));

                if (Right(nodes, r) != -1)
                    PreOrder(Right(nodes, r));
            }
        }

        long result;

        private static long[] InOrder(long[][] nodes, int n)
        {
            long[] result = new long[nodes.Length];
            int lastPos = 0;
            InOrder(0);
            return result;

            void InOrder(long r)
            {
                if (Left(nodes, r) != -1)
                    InOrder(Left(nodes, r));

                result[lastPos] = Key(nodes, r);
                lastPos++;

                if (Right(nodes, r) != -1)
                    InOrder(Right(nodes, r));
            }
        }
    }
}
