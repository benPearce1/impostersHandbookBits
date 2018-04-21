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
            var sorted = MergeSort(list);
            sw.Stop();
            Console.WriteLine($"Sorted {list.Count()} items in {sw.ElapsedMilliseconds} milliseconds");
            DumpList(sorted);

            Random r = new Random();
            
            list = Enumerable.Range(0,100000).Select(x=>r.Next()).ToArray();
            var l = list.ToList();
            GC.Collect();
            sw.Start();
            l.Sort();
            sw.Stop();
            Console.WriteLine($"Sorted {list.Count()} items in {sw.ElapsedMilliseconds} milliseconds");


            list = Enumerable.Range(0,100000).Select(x=>r.Next()).ToArray();
            GC.Collect();
            sw.Start();
            MergeSort(list);
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
            int leftPostion = 0, rightPostion = 0;
            while (leftPostion < left.Count() || rightPostion < right.Count()) {
                if (leftPostion < left.Count() && rightPostion < right.Count()) {
                    if (left.ElementAt(leftPostion).CompareTo(right.ElementAt(rightPostion)) < -1) {
                        result.Add(left.ElementAt(leftPostion++));
                        leftPostion++;
                    }
                    else {
                        result.Add(right.ElementAt(rightPostion++));
                    }
                }
                else { 
                    if (leftPostion < left.Count()) {
                        result.Add(left.ElementAt(leftPostion++));
                    }
                    else {
                        result.Add(right.ElementAt(rightPostion++));
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
