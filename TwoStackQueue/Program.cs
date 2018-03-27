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
                //Console.WriteLine($"Queuing {i}");
                Enqueue(i);    
            }
            Console.WriteLine($"Enqueuing took {sw.ElapsedMilliseconds} milliseconds");
            sw.Restart();
            for (int i = 0; i < 10000; i++) 
            {
                Dequeue();
            }
            Console.WriteLine($"Dequeuing took {sw.ElapsedMilliseconds} milliseconds");
            
        }

        static void Enqueue(int i) {
            In.Push(i);
        }

        static int Dequeue() {
            while (In.Any())
            {
                Out.Push(In.Pop());
            }

            var returnValue = Out.Pop();
            while (Out.Any()) 
            {
                In.Push(Out.Pop());
            }
            
            return returnValue;
        }

        static void PrintQueue() {

        }
    }
}
