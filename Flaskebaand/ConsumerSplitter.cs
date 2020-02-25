using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flaskebaand
{
    /// <summary>
    /// Consumer splitter class
    /// </summary>
    public class ConsumerSplitter : BaseThread
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
        /// The beer buffer which the beer bottles will be added to
        /// </summary>
        public BottleBuffer BeerBuffer
        {
            get { return beerBuffer; }
            private set { beerBuffer = value; }
        }

        /// <summary>
        /// The faxe buffer which all the faxe bottles will be added to
        /// </summary>
        public BottleBuffer FaxeBuffer
        {
            get { return faxeBuffer; }
            private set { faxeBuffer = value; }
        }

        private BottleBuffer inBuffer;
        private BottleBuffer beerBuffer;
        private BottleBuffer faxeBuffer;


        public ConsumerSplitter(BottleBuffer ingoingBuffer, BottleBuffer beerBuffer, BottleBuffer faxeBuffer)
        {
            InBuffer = ingoingBuffer;
            BeerBuffer = beerBuffer;
            FaxeBuffer = faxeBuffer;
        }

        /// <summary>
        /// The current thread process
        /// </summary>
        protected override void ThreadWork()
        {
            while (true)
            {
                Bottle curBottle = GetBottleFromIngoingBuffer();
                AddBottleToCorrectBuffer(curBottle);
            }
        }

        /// <summary>
        /// Adds the current bottle to the correct outgoing buffer
        /// </summary>
        /// <param name="bottle"></param>
        private void AddBottleToCorrectBuffer(Bottle bottle)
        {
            switch(bottle.Name)
            {
                case "Beer":
                    AddBottleToBuffer(FaxeBuffer, bottle);
                    break;
                case "Faxe Kondi":
                    AddBottleToBuffer(BeerBuffer, bottle);
                    break;
            }
        }

        /// <summary>
        /// Adds a bottle to a buffer
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="bottle"></param>
        private void AddBottleToBuffer(BottleBuffer buffer, Bottle bottle)
        {
            Monitor.Enter(buffer.Lock);

            try
            {
                buffer.AddBottleInFront(bottle);

                if (buffer.GetItemsInBuffer() == 1)
                    Monitor.PulseAll(buffer.Lock);
            }
            finally
            {
                Monitor.Exit(buffer.Lock);
            }
        }

        /// <summary>
        /// Get the last bottle from the ingoing buffer
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
