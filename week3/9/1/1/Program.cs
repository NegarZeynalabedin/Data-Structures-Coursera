using System;
using System.Collections.Generic;
using System.Text;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            long count = long.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            string[] inputSpl = input.Split();
            long[] array = new long[count];
            for (int i = 0; i < count; i++)
                array[i] = long.Parse(inputSpl[i]);

            List<long> answerIdx1 = new List<long>();
            List<long> answerIdx2 = new List<long>();
            int arrayLenght = (int)count;

            BuildHeap(array, arrayLenght, answerIdx1, answerIdx2);

            Console.WriteLine(answerIdx1.Count);
            for(int i = 0; i< answerIdx1.Count; i++)
            {
                Console.WriteLine(answerIdx1[i]+" "+ answerIdx2[i]);
            }
        }

        private static void BuildHeap(long[] array, int arrayLenght, List<long> answerIdx1,List<long>answerIdx2)
        {
            int index = (arrayLenght / 2) - 1;
            for (int i = index; i >= 0; i--)
                heapify(array, arrayLenght, i, answerIdx1,answerIdx2);
        }

        private static void heapify(long[] array, int arrayLenght, int i, List<long> answerIdx1, List<long> answerIdx2)
        {
            int largestIdx = i;
            int leftIdx = 2 * i + 1;
            int rightIdx = 2 * i + 2;

            if (leftIdx < arrayLenght && array[leftIdx] < array[largestIdx])
                largestIdx = leftIdx;

            if (rightIdx < arrayLenght && array[rightIdx] < array[largestIdx])
                largestIdx = rightIdx;

            if (largestIdx != i)
            {
                answerIdx1.Add(i);
                answerIdx2.Add(largestIdx);

                long swap = array[i];
                array[i] = array[largestIdx];
                array[largestIdx] = swap;

                heapify(array, arrayLenght, largestIdx, answerIdx1,answerIdx2);
            }
        }
    }
}
