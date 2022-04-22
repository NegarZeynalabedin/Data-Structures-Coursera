using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsBST
{
    class Node
    {
        public long data;
        public Node left, right;

        public Node() { }

        public Node(long Data)
        {
            Data = this.data;
            left = right = null;
        }

        public override string ToString()
        {
            return $"{this.data}({this.left?.data},{this.right?.data})";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int countOfInput = int.Parse(Console.ReadLine());

            if (countOfInput == 0)
            {
                Console.WriteLine("CORRECT");
                return;
            }
            
            long[][] nodes = new long[countOfInput][];
            for (int i = 0; i < countOfInput; i++)
            {
                string input = Console.ReadLine();
                string[] inputStr = input.Split();
                nodes[i] = new long[3];
                nodes[i][0] = long.Parse(inputStr[0]);
                nodes[i][1] = long.Parse(inputStr[1]);
                nodes[i][2] = long.Parse(inputStr[2]);
            }

            long NodesLen = nodes.Length;
            bool result=InOrder(nodes, NodesLen);
            if(result)
                Console.WriteLine("CORRECT");
            else Console.WriteLine("INCORRECT");
        }

        private static bool InOrder(long[][] nodes, long NodesLen)
        {
            int i = -1;
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
                    i++;
                    try
                    {
                        if (Order[i - 1] > Order[i])
                            return false;
                    }
                    catch (Exception)
                    { }

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

            return true;
        }

    }
}
