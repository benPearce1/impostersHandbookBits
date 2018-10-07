using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            var fib = new Fibonacci();
            long fibNumber;
            Stopwatch sw = new Stopwatch();
            using (var timer = new Utils.Timer(sw)){
                fibNumber = fib.Calculate(10000000);
            }
            Console.WriteLine(fibNumber);
            Console.WriteLine($"Calc took {sw.ElapsedMilliseconds}");
        }
    }

    public interface IFibonacci {
        long Calculate(long position);
    }
    public class Fibonacci : IFibonacci
    {
        public long Calculate(long position)
        {
            var values = new long[position + 1];
            values[0] = 0;
            values[1] = 1;
            for (long i = 2; i < position + 1; i++) {
                values[i] = values[i - 1] + values[i - 2];
            }

            return values[position];
        }
    }


}
