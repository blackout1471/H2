using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPool
{
    class Program
    {
        static void Main(string[] args)
        {

            Stopwatch watch = new Stopwatch();
            Console.WriteLine("Starting Threads");
            watch.Start();

            // Threads
            ProcessWithThreads();
            Console.WriteLine($"Time used with threads {watch.ElapsedTicks} ticks");

            watch.Restart();

            ProcessWithPool();

            Console.WriteLine($"Time used with pools {watch.ElapsedTicks} ticks");
            watch.Stop();

            Console.ReadKey();
        }

        private static void ProcessWithThreads()
        {
            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < 10; i++)
            {
                Thread a = new Thread(Process);
                threads.Add(a);
                a.Priority = ThreadPriority.Highest;
                a.Start();
            }

            for (int i = 0; i < 10; i++)
            {
                threads[i].Join();
            }
        }

        private static void ProcessWithPool()
        {
            for (int i = 0; i < 10; i++)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(Process);
            }
        }

        static void Process(object callback)
        {
            for (int i = 0; i < 10000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {

                }
            }
        }
    }
}
