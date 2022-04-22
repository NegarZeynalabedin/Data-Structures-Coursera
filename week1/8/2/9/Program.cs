using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _9
{
    class Program
    {
        static void Main(string[] args)
        {
            string nodeCountStr = Console.ReadLine();
            long nodeCount = long.Parse(nodeCountStr);

            string input = Console.ReadLine();
            string [] inputSpl = input.Split();
            long[] tree = new long[nodeCount];
            for (int i = 0; i < nodeCount; i++)
                tree[i] = long.Parse(inputSpl[i]);

            List<long>[] treeChildren = new List<long>[nodeCount];
            Stack treeHeightStack = new Stack();
            long[] branchesHeight = new long[nodeCount];

            long root = tree.ToList().IndexOf(-1);
            treeHeightStack.Push(root);

            for (int j = 0; j < nodeCount; j++)
                treeChildren[j] = new List<long>();

            for (int j = 0; j < nodeCount; j++)
            {
                if (tree[j] == -1)
                    continue;

                if (j == 0)
                    treeChildren[tree[j]].Add(-5);
                else
                    treeChildren[tree[j]].Add(j);
            }

            treeHeightStack.Pop();
            branchesHeight[root] = 1;

            while (true)
            {
                if (treeChildren[root].Count != 0)
                {
                    for (int i = 0; i < treeChildren[root].Count; i++)
                    {
                        treeHeightStack.Push(treeChildren[root][i]);
                        if (treeChildren[root][i] == -5)
                            branchesHeight[0] = branchesHeight[root] + 1;
                        else branchesHeight[treeChildren[root][i]] = branchesHeight[root] + 1;
                    }

                    root = (long)treeHeightStack.Pop();
                    if (root == -5)
                        root = 0;
                }
                else
                {
                    if (treeHeightStack.Count == 0)
                        break;

                    root = (long)treeHeightStack.Pop();
                    if (root == -5)
                        root = 0;
                }
            }
            Console.WriteLine($"{branchesHeight.Max()}");
        }
    }
}
