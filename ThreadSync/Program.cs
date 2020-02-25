using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSync
{
    class Program
    {

        private static int currentCount;
        private static object _lock = new object();

        static void Main(string[] args)
        {
            currentCount = 0;

            Thread[] threads = new Thread[2];

            threads[0] = new Thread(PrintLine);
            threads[0].Start('#');

            threads[1] = new Thread(PrintLine);
            threads[1].Start('*');

            threads[0].Join();
            threads[1].Join();

            threads[0] = new Thread(PrintLine);
            threads[0].Start('#');

            threads[1] = new Thread(PrintLine);
            threads[1].Start('*');

            threads[0].Join();
            threads[1].Join();

            Console.ReadKey();

        }

        static void PrintLine(object character)
        {
            Monitor.Enter(_lock);
            try
            {
                char c = (char)character; ;

                for (int i = 0; i < 60; i++)
                {
                    Console.Write(character);
                    currentCount++;
                }
                Console.Write(currentCount + "\n");
            }
            finally
            {
                Monitor.Exit(_lock);
            }
  
        }
    }
}
