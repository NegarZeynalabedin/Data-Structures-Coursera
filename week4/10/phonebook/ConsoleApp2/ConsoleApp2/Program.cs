using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApp2
{
    public class Contact
    {
        public string Name;
        public int Number;

        public Contact(string name, int number)
        {
            Name = name;
            Number = number;
        }
    }

    class Program
    {
        public static Dictionary<int, string> PhoneBookList;
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            string[] commands = new string[count];
            for (int i = 0; i < count; i++)
                commands[i] = Console.ReadLine();

            PhoneBookList = new Dictionary<int, string>();
            List<string> result = new List<string>();
            foreach (var cmd in commands)
            {
                var toks = cmd.Split();
                var cmdType = toks[0];
                var arg = toks.Skip(1).ToArray();
                int number = int.Parse(arg[0]);
                switch (cmdType)
                {
                    case "add":
                        Add(arg[1], number);
                        break;
                    case "del":
                        Delete(number);
                        break;
                    case "find":
                        result.Add(Find(number));
                        break;
                }
            }

            foreach (var r in result)
                Console.WriteLine(r);

        }

        public static void Add(string name, int number)
        {

            PhoneBookList[number] = name;
        }

        public static string Find(int number)
        {
            string name;
            if (!PhoneBookList.TryGetValue(number, out name))
                return "not found";

            return name;

        }

        public static void Delete(int number)
        {
            if (PhoneBookList.ContainsKey(number))
                PhoneBookList.Remove(number);
        }
    }
}
