using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new [] { 5,6,1,2,3,4};
            Stopwatch sw = Stopwatch.StartNew();
            var sorted = QuickSort(list);
            sw.Stop();
            DumpList(sorted);
            Console.WriteLine($"Sorted {list.Count()} items in {sw.ElapsedMilliseconds} milliseconds");

            Random r = new Random();
            list = Enumerable.Range(0,1000000).Select(x => r.Next()).ToArray();
            sw.Restart();
            QuickSort(list);
            sw.Stop();
            Console.WriteLine($"Sorted {list.Count()} items in {sw.ElapsedMilliseconds} milliseconds");

            list = Enumerable.Range(0,1000000).Select(x => r.Next()).ToArray();
            var l = list.ToList();
            sw.Restart();
            l.Sort();
            sw.Stop();
            Console.WriteLine($"Sorted {list.Count()} items in {sw.ElapsedMilliseconds} milliseconds");


        }

        static IEnumerable<T> QuickSort<T>(IEnumerable<T> source) where T: IComparable
        {
            if (source.Count() < 2) return source;
            var pivotValue = source.Last();
            var list = source.Take(source.Count() - 1).ToList();
            List<T> left = new List<T>();
            List<T> right = new List<T>();

            foreach (var i in source.Take(source.Count() -1))
            {
                if (i.CompareTo(pivotValue) < 0)
                    left.Add(i);
                else    
                    right.Add(i); 
            }
            
            return QuickSort(left).Concat(new [] { pivotValue }).Concat(QuickSort(right));
        }


        static void DumpList<T>(IEnumerable<T> source) {
            Console.WriteLine($"[{string.Join(",",source)}]");
        }
    }
}
