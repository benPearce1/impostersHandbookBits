using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SortedListPerfTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int listSize = 99999990;
            List<int> list = new List<int>(listSize);
            HashSet<int> sortedList = new HashSet<int>(listSize);

            Random r = new Random();
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < listSize; i++)
            {
                int num = r.Next();
                list.Add(num);
            }
            sw.Stop();
            Console.WriteLine($"Filled list in {sw.ElapsedMilliseconds}");
            sw.Restart();
            foreach (var i in list)
            {
                sortedList.Add(i);
            }
            sw.Stop();
            Console.WriteLine($"Filled sorted list in {sw.ElapsedMilliseconds}");

            var avg = list.Average();
            sw.Restart();
            var allNumbersOverAvg = list.Where(x=> x > avg);
            sw.Stop();
            Console.WriteLine($"Average number search for list: {sw.ElapsedMilliseconds}");

            sw.Restart();
            allNumbersOverAvg = sortedList.Where(x => x > avg);
            sw.Stop();
            Console.WriteLine($"Average number search for sorted list: {sw.ElapsedMilliseconds}");

            int randomPostion = r.Next(list.Count);
            int targetValue = sortedList.ElementAt(randomPostion);

            sw.Restart();
            sortedList.Where(x => x == targetValue);
            sw.Stop();
            Console.WriteLine($"Search for {targetValue} in sorted list: {sw.ElapsedMilliseconds}");

            sw.Restart();
            list.Where(x => x == targetValue);
            sw.Stop();
            Console.WriteLine($"Search for {targetValue} in unsorted list: {sw.ElapsedMilliseconds}");
            

        }
    }
}
