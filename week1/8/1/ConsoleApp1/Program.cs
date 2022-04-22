using System;
using System.Collections;

namespace A8
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();

            Stack stack = new Stack();
            Tuple<string, int> temp;

            if (str[0] == ')' || str[0] == ']' || str[0] == '}')
            {
                Console.WriteLine("1");
                return;
            }

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '(' || str[i] == '[' || str[i] == '{')
                    stack.Push(Tuple.Create<char, int>(str[i], i));

                if (str[i] == ')' || str[i] == ']' || str[i] == '}')
                {
                    if (stack.Count == 0)
                    {
                        Console.WriteLine($"{i + 1}");
                        return;
                    }

                    Tuple<char, int> b = (Tuple<char, int>)stack.Pop();
                    if (str[i] == ')')
                        if (b.Item1 != '(')
                        {
                            Console.WriteLine($"{i + 1}");
                            return;
                        }

                    if (str[i] == ']')
                        if (b.Item1 != '[')
                        {
                            Console.WriteLine($"{i + 1}");
                            return;
                        }

                    if (str[i] == '}')
                        if (b.Item1 != '{')
                        {
                            Console.WriteLine($"{i + 1}");
                            return;
                        }
                }
            }

            if (stack.Count != 0)
            {
                Tuple<char, int> check = new Tuple<char, int>('a', 0);

                while (stack.Count != 0)
                    check = (Tuple<char, int>)stack.Pop();

                Console.WriteLine($"{check.Item2 + 1}");
                return;

            }

            Console.WriteLine("Success");
        }
    }
}
