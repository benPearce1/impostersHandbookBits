using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace TwoStackQueue
{
    class Program
    {
        static Stack<int> In = new Stack<int>();
        
        static Stack<int> Out = new Stack<int>();
        

        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < 10000; i++)
            {
                Enqueue(i);    
            }
            Console.WriteLine($"Enqueuing 10000 took {sw.ElapsedMilliseconds} milliseconds");

            sw.Restart();
            for (int i = 0; i < 5000; i++) 
            {
                Dequeue();
            }
            Console.WriteLine($"Dequeuing 5000 took {sw.ElapsedMilliseconds} milliseconds");
            
            sw.Restart();
            for (int i = 0; i < 5000; i++) 
            {
                Enqueue(i);
            }
            Console.WriteLine($"Enqueuing 5000 took {sw.ElapsedMilliseconds} milliseconds");

            sw.Restart();
            for (int i = 0; i < 10000; i++) 
            {
                Dequeue();
            }
            Console.WriteLine($"Dequeuing 10000 took {sw.ElapsedMilliseconds} milliseconds");
            
        }

        static void Enqueue(int i) {
            In.Push(i);
        }

        static int Dequeue() {
            if (Out.Any())
            {
                return Out.Pop();
            }

            while (In.Any())
            {
                Out.Push(In.Pop());
            }

            return Out.Pop();
        }

        static void PrintQueue() {

        }
    }
}
