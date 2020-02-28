using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BagageSorteringsSystem.Model
{
    public class Sorting : BaseThread
    {
        /// <summary>
        /// Event for when bagage is either being checked in or out
        /// </summary>
        /// <param name="bagage"></param>
        public delegate void SortingEvent(Bagage bagage);

        /// <summary>
        /// The buffers which the bagage will be loaded from
        /// </summary>
        public CounterDesk[] InGoingBuffers
        {
            get
            {
                return inGoingBuffers;
            }

            private set
            {
                inGoingBuffers = value;
            }
        }

        /// <summary>
        /// The buffers where the sorted bagage will go to
        /// </summary>
        public Gate[] OutGoingBuffers
        {
            get
            {
                return outGoingBuffers;
            }

            private set
            {
                outGoingBuffers = value;
            }
        }

        /// <summary>
        /// event for when the bagage is about to being sorted
        /// </summary>
        public SortingEvent InGoingBagageHandler
        {
            get
            {
                return inGoingBagageHandler;
            }

            set
            {
                inGoingBagageHandler = value;
            }
        }

        /// <summary>
        /// Event for when bagage has been sorted
        /// </summary>
        public SortingEvent OutGoingBagageHandler
        {
            get
            {
                return outGoingBagageHandler;
            }

            set
            {
                outGoingBagageHandler = value;
            }
        }

        private CounterDesk[] inGoingBuffers;
        private Gate[] outGoingBuffers;
        private SortingEvent inGoingBagageHandler;
        private SortingEvent outGoingBagageHandler;

        public Sorting(CounterDesk[] ingoingBuffers, Gate[] outGoingBuffers)
        {
            InGoingBuffers = ingoingBuffers;
            OutGoingBuffers = outGoingBuffers;
        }

        protected override void ThreadWork()
        {
            while (true)
            {
                Bagage bagage = GetNextBagage();

                if (bagage != null)
                    ProcessBagage(bagage);
            }
        }

        /// <summary>
        /// Processes the bagage and sends it to the outgoing buffer
        /// </summary>
        /// <param name="bagage"></param>
        private void ProcessBagage(Bagage bagage)
        {
            for (int i = 0; i < OutGoingBuffers.Length; i++)
            {
                Gate curGate = OutGoingBuffers[i];

                Monitor.Enter(OutGoingBuffers[i].Buffer.Lock);

                try
                {
                    if (bagage.Sticker.GateId != curGate.Id)
                        continue;

                    if (curGate.Buffer.IsBufferFull)
                    {
                        Monitor.PulseAll(curGate.Buffer.Lock);
                        Monitor.Wait(curGate.Buffer.Lock);
                    }

                    curGate.Buffer.AddToFrontBuffer(bagage);
                    OutGoingBagageHandler?.Invoke(bagage);
                }
                finally
                {
                    Monitor.Exit(OutGoingBuffers[i].Buffer.Lock);
                }
            }
        }

        /// <summary>
        /// Gets the next availlable bagage on the ingoing buffers
        /// </summary>
        /// <returns></returns>
        private Bagage GetNextBagage()
        {
            for (int i = 0; i < InGoingBuffers.Length; i++)
            {
                CounterDesk curBuffer = InGoingBuffers[i];

                Monitor.Enter(curBuffer.Buffer.Lock);

                try
                {
                    if (curBuffer.Buffer.IsBufferEmpty)
                    {
                        Monitor.PulseAll(curBuffer.Buffer.Lock);
                        continue;
                    }

                    Bagage curBagage = curBuffer.Buffer.RemoveFromBackBuffer();
                    InGoingBagageHandler?.Invoke(curBagage);

                    return curBagage;
                }
                finally
                {
                    Monitor.Exit(curBuffer.Buffer.Lock);
                }
            }

            return null;
        }
    }
}
