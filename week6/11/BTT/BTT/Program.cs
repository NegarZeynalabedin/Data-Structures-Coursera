using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BTT
{
    class Program
    {
        static long[][] Answer;
        public static void Main(string[] args)
        {
            int countOfInput = int.Parse(Console.ReadLine());
            long[][] nodes = new long[countOfInput][];
            for(int i = 0; i < countOfInput; i++)
            {
                string input = Console.ReadLine();
                string[] inputStr = input.Split();
                nodes[i] = new long[3];
                nodes[i][0] = long.Parse(inputStr[0]);
                nodes[i][1] = long.Parse(inputStr[1]);
                nodes[i][2] = long.Parse(inputStr[2]);
            }

            long NodesLen = nodes.Length;

            Answer = new long[3][];

            for (int i = 0; i < 3; i++)
                Answer[i] = new long[NodesLen];

            Answer[0] = InOrder(nodes, NodesLen);
            Answer[1] = PreOrder(nodes, NodesLen);
            Answer[2] = PostOrder(nodes, NodesLen);

            Console.WriteLine(string.Join(" ", Answer[0].Select(x => x.ToString()).ToArray()));
            Console.WriteLine(string.Join(" ", Answer[1].Select(x => x.ToString()).ToArray()));
            Console.WriteLine(string.Join(" ", Answer[2].Select(x => x.ToString()).ToArray()));
        }

        private static long[] PostOrder(long[][] nodes, long NodesLen)
        {
            Stack<long> MyStack = new Stack<long>();
            List<long> Order = new List<long>();
            bool[] Visited = new bool[NodesLen];

            MyStack.Push(0);

            long peek;
            long left, right;
            while (MyStack.Count != 0)
            {
                peek = MyStack.Peek();

                left = nodes[peek][1];
                while (left != -1)
                {
                    if (!Visited[left])
                    {
                        MyStack.Push(left);
                        peek = left;
                        left = nodes[peek][1];
                    }
                    else
                        break;
                }

                right = nodes[peek][2];
                if (right != -1)
                {
                    if (!Visited[right])
                    {
                        MyStack.Push(right);
                        peek = right;
                        continue;
                    }
                }
                Order.Add(nodes[peek][0]);
                MyStack.Pop();
                Visited[peek] = true;
            }
            return Order.ToArray();
        }

        private static long[] PreOrder(long[][] nodes, long NodesLen)
        {
            Stack<long> MyStack = new Stack<long>();
            List<long> Order = new List<long>();
            bool[] Visited = new bool[NodesLen];

            MyStack.Push(0);
            Order.Add(nodes[0][0]);
            long peek;
            long left, right;
            while (MyStack.Count != 0)
            {
                peek = MyStack.Peek();

                left = nodes[peek][1];
                while (left != -1)
                {
                    if (!Visited[left])
                    {
                        MyStack.Push(left);
                        peek = left;
                        Order.Add(nodes[peek][0]);
                        left = nodes[peek][1];
                    }
                    else
                        break;
                }
                right = nodes[peek][2];
                if (right != -1)
                {
                    if (!Visited[right])
                    {
                        MyStack.Push(right);
                        peek = right;
                        Order.Add(nodes[right][0]);
                        continue;
                    }
                }
                MyStack.Pop();
                Visited[peek] = true;
            }
            return Order.ToArray();
        }

        private static long[] InOrder(long[][] nodes, long NodesLen)
        {
            Stack<long> MyStack = new Stack<long>();
            List<long> Order = new List<long>();
            bool[] Visited = new bool[NodesLen];

            MyStack.Push(0);
            long peek;
            long left, right;
            while (MyStack.Count != 0)
            {
                peek = MyStack.Peek();

                left = nodes[peek][1];
                while (left != -1)
                {
                    if (!Visited[left])
                    {
                        MyStack.Push(left);
                        peek = left;
                        left = nodes[peek][1];
                    }
                    else
                        break;
                }

                if (!Visited[peek])
                {
                    Order.Add(nodes[peek][0]);
                    Visited[peek] = true;
                }

                right = nodes[peek][2];
                if (right != -1)
                {
                    if (!Visited[right])
                    {
                        MyStack.Push(right);
                        peek = right;
                        continue;
                    }
                }
                MyStack.Pop();
            }

            return Order.ToArray();
        }
    }
}
