using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace SelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new [] { 5,6,1,2,3,4};
            Stopwatch sw = Stopwatch.StartNew();
            var sorted = SelectionSort(list);
            sw.Stop();
            DumpList(sorted);
            Console.WriteLine($"Sorted {list.Count()} items in {sw.ElapsedMilliseconds} milliseconds");

            Random r = new Random();
            list = Enumerable.Range(0,100000).Select(x => r.Next()).ToArray();
            sw.Restart();
            SelectionSort(list);
            sw.Stop();
            Console.WriteLine($"Sorted {list.Count()} items in {sw.ElapsedMilliseconds} milliseconds");
        }

        static IEnumerable<T> SelectionSort<T>(IEnumerable<T> source) where T: IComparable {
            int i = 0;
            var result = new List<T>(source.Count());
            var sourceList = new List<T>(source);
            while (i < source.Count())
            {
                var min = sourceList.Skip(i).Min();
                var position = sourceList.IndexOf(min);

                if (position != i) {
                    sourceList[position] = sourceList[i];
                    sourceList[i] = min;
                }
                
                i++;   
            }
            return sourceList;
        }

        static void DumpList<T>(IEnumerable<T> source) {
            Console.WriteLine($"[{string.Join(",",source)}]");
        }
    }
}
