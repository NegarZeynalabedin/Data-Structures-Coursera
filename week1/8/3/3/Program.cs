using System;
using System.Collections.Generic;
using System.Linq;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            string lineOne = Console.ReadLine();
            string[] lineOneSpl = lineOne.Split();
            long bufferSize = long.Parse(lineOneSpl[0]);
            long tmp = long.Parse(lineOneSpl[1]);

            if (tmp == 0)
            {
                Console.WriteLine("");
                return;
            }

            long[] arrivalTimes = new long[tmp];
            long[] processingTimes = new long[tmp];
            for (int i = 0; i < tmp; i++)
            {
                string input = Console.ReadLine();
                string[] inputSpl = input.Split();

                arrivalTimes[i] = long.Parse(inputSpl[0]);
                processingTimes[i] = long.Parse(inputSpl[1]);
            }

            List<long> answer = new List<long>();

            long check = arrivalTimes.First();

            if (bufferSize == 1)
            {
                for (int i = 0; i <= arrivalTimes.Length; i++)
                {
                    if (arrivalTimes.Length == 1)
                    {
                        answer.Add(arrivalTimes.First());
                        break;
                    }

                    if (arrivalTimes[i + 1] == check + processingTimes[i])
                    {
                        check += arrivalTimes[i];
                        answer.Add(arrivalTimes[i]);
                    }
                    else
                        answer.Add(-1);
                }
            }

            foreach(var a in answer)
            {
                Console.WriteLine($"{a}");
            }
        }
    }
}
