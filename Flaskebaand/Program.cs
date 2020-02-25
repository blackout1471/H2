using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flaskebaand
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create bottle buffers
            BottleBuffer producerBuffer = new BottleBuffer(30);
            BottleBuffer faxeBuffer = new BottleBuffer(20);
            BottleBuffer beerBuffer = new BottleBuffer(20);

            // Create the producer and the consumer splitter
            Producer producer = new Producer(producerBuffer);
            ConsumerSplitter conSplit = new ConsumerSplitter(producerBuffer, beerBuffer, faxeBuffer);

            // Creates the consumers
            Consumer faxeConsumer = new Consumer(faxeBuffer, "Faxe Consumer");
            Consumer beerConsumer = new Consumer(beerBuffer, "Beer Consumer");

            // Start all the threads
            producer.Start();
            conSplit.Start();
            faxeConsumer.Start();
            beerConsumer.Start();

            // Wait for all threads to be done
            producer.Join();
            conSplit.Join();
            faxeConsumer.Join();
            beerConsumer.Join();

            Console.ReadKey();

        }
    }
}
