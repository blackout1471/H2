using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProducerConsumer
{
    class Program
    {

        private static int itemsCount;
        private static readonly uint maxItems = 20;
        private static object _lock = new object();

        static void Main(string[] args)
        {

            itemsCount = 0;

            Thread prod = new Thread(Producer);
            Thread cons = new Thread(Consumer);

            prod.Start();
            cons.Start();

            prod.Join();

            Console.ReadKey();

        }

        private static void Producer()
        {
            while (true)
            {
                Monitor.Enter(_lock);
                try
                {
                    if (itemsCount == maxItems)
                    {
                        Console.WriteLine("Produced max");
                        Monitor.Wait(_lock);
                    }
                    else
                    {
                        itemsCount++;
                        Console.WriteLine($"Produced 1 more: {itemsCount}");
                    }

                    if (itemsCount == 1)
                        Monitor.PulseAll(_lock);
                }
                finally
                {
                    Monitor.Exit(_lock);
                }     
            }
        }

        private static void Consumer()
        {
            while (true)
            {
                Monitor.Enter(_lock);
                try
                {
                    if (itemsCount == 0)
                    {
                        Console.WriteLine("Waiting for producer");
                        Monitor.PulseAll(_lock);
                        Monitor.Wait(_lock);
                    }
                    else
                    {
                        itemsCount--;
                        Console.WriteLine($"Consumer took 1, now there's {itemsCount}");
                    }
                }
                finally
                {
                    Monitor.Exit(_lock);
                }
                
            }
        }



        // OPGAVE 1
        //private static void Producer()
        //{
        //    while (true)
        //    {
        //        if (itemsCount == maxItems)
        //        {
        //            Console.WriteLine("Produced max");
        //            Thread.Sleep(5000);
        //        }
        //        else
        //        {
        //            itemsCount++;
        //            Console.WriteLine($"Produced 1 more: {itemsCount}");
        //        }
        //    }
        //}

        // OPGAVE 1
        //private static void Consumer()
        //{
        //    while (true)
        //    {
        //        if (itemsCount == 0)
        //        {
        //            Console.WriteLine("Waiting for producer");
        //            Thread.Sleep(1000);
        //        }
        //        else
        //        {
        //            itemsCount--;
        //            Console.WriteLine($"Consumer took 1, now there's {itemsCount}");
        //        }
        //    }
        //}
    }
}
