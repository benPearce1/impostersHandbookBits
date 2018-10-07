using System;
using System.Diagnostics;

namespace Utils
{
    public class Timer : IDisposable
    {
        Stopwatch sw;
        public Timer(Stopwatch sw)
        {
            this.sw = sw;
            sw = Stopwatch.StartNew();
        }

        public void Dispose()
        {
            sw.Stop();
        }
    }
}
