using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new [] { 4,3,2,1 };
            Stopwatch sw = Stopwatch.StartNew();
            MergeSort(list);
            sw.Stop();
            Console.WriteLine($"Sorted {list.Count()} items in {sw.ElapsedMilliseconds} milliseconds");

            Random r = new Random();
            list = Enumerable.Range(0,10000000).Select(x=>r.Next()).ToArray();
            sw.Start();
            MergeSort(list);
            sw.Stop();
            Console.WriteLine($"Sorted {list.Count()} items in {sw.ElapsedMilliseconds} milliseconds");

            var l = list.ToList();
            sw.Start();
            l.Sort();
            sw.Stop();
            Console.WriteLine($"Sorted {list.Count()} items in {sw.ElapsedMilliseconds} milliseconds");

        }

        static IEnumerable<T> MergeSort<T>(IEnumerable<T> source) where T: IComparable
        {
            if (source.Count() <= 1) return source;
            var lists = Split(source);
            
            return Merge(MergeSort(lists.First()), MergeSort(lists.Skip(1).First()));
        }

        static IEnumerable<T> Merge<T>(IEnumerable<T> left, IEnumerable<T> right) where T: IComparable 
        {
            var result = new List<T>();
            while (left.Any() || right.Any()) {
                if (left.Any() && right.Any()) {
                    if (left.First().CompareTo(right.First()) < -1) {
                        result.Add(left.First());
                        left = left.Skip(1);
                    }
                    else {
                        result.Add(right.First());
                        right = right.Skip(1);
                    }
                }
                else { 
                    if (left.Any()) {
                        result.Add(left.First());
                        left  = left.Skip(1);
                    }
                    else {
                        result.Add(right.First());
                        right = right.Skip(1);
                    }
                }
            }

            return result;
        }

        static IEnumerable<IEnumerable<T>> Split<T>(IEnumerable<T> source) {
            
            var half = source.Count().Half();
            var left = source.Take(half);
            var right = source.Skip(half);
            return new []{ left, right };
        }

        static void DumpList<T>(IEnumerable<T> source) {
            Console.WriteLine($"[{string.Join(",",source)}]");
        }
    }

    public static class Extensions 
    {
        public static int Half(this int i) {
            return i / 2;
        }
    }
}
