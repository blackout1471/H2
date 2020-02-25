using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flaskebaand
{
    /// <summary>
    /// The consumer class is used to pick up bottles from a buffer
    /// </summary>
    public class Consumer : BaseThread
    {
        /// <summary>
        /// The in going buffer
        /// </summary>
        public BottleBuffer InBuffer
        {
            get { return inBuffer; }
            private set { inBuffer = value; }
        }

        /// <summary>
        /// The name of the consumer
        /// </summary>
        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        private string name;
        private BottleBuffer inBuffer;

        public Consumer(BottleBuffer ingoingBuffer, string name)
        {
            InBuffer = ingoingBuffer;
            Name = name;
        }

        /// <summary>
        /// The thread process
        /// </summary>
        protected override void ThreadWork()
        {
            while (true)
            {
                Bottle curBottle = GetBottleFromIngoingBuffer();
                Console.WriteLine($"{Name} just picked a bottle");
            }
        }

        /// <summary>
        /// Gets the last bottle from the buffer
        /// </summary>
        /// <returns></returns>
        private Bottle GetBottleFromIngoingBuffer()
        {
            Monitor.Enter(InBuffer.Lock);
            try
            {
                if (InBuffer.GetItemsInBuffer() == 0)
                {
                    Monitor.PulseAll(InBuffer.Lock);
                    Monitor.Wait(inBuffer.Lock);
                }

                return InBuffer.RemoveLastBottle();
            }
            finally
            {
                Monitor.Exit(InBuffer.Lock);
            }
        }
    }
}
