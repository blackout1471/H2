using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flaskebaand
{
    public class Producer : BaseThread
    {
        /// <summary>
        /// The current bottle buffer object
        /// </summary>
        public BottleBuffer BottleBuffer
        {
            get { return bottleBuffer; }
            private set { bottleBuffer = value; }
        }

        private BottleBuffer bottleBuffer;
        private Random rnd = new Random(Guid.NewGuid().GetHashCode());

        /// <summary>
        /// The names of the bottles which can be produced
        /// </summary>
        private string[] bottleNames =
        {
            "Beer",
            "Faxe Kondi"
        };

        public Producer(BottleBuffer buffer)
        {
            BottleBuffer = buffer;
        }

        /// <summary>
        /// The current threads process
        /// </summary>
        protected override void ThreadWork()
        {
            while (true)
            {
                Monitor.Enter(BottleBuffer.Lock);

                try
                {
                    if (BottleBuffer.IsBufferFull())
                    {
                        Monitor.Wait(BottleBuffer.Lock);
                    }

                    BottleBuffer.AddBottleInFront(GenerateRandomBottle());

                    if (BottleBuffer.GetItemsInBuffer() == 1)
                        Monitor.PulseAll(BottleBuffer.Lock);
                }
                finally
                {
                    Monitor.Exit(BottleBuffer.Lock);
                }
            }
        }

        /// <summary>
        /// Generates a random bottle
        /// </summary>
        /// <returns></returns>
        private Bottle GenerateRandomBottle()
        {
            string bName = bottleNames[rnd.Next(0, bottleNames.Length)];

            return new Bottle(bName);
        }
    }
}
