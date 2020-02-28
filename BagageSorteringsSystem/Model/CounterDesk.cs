using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BagageSorteringsSystem.Model
{
    public class CounterDesk : Desk
    {
        /// <summary>
        /// Event for when an bagage has been registered
        /// </summary>
        /// <param name="bagage"></param>
        /// <param name="desk"></param>
        public delegate void RegisteredEvent(Bagage bagage, CounterDesk desk);

        /// <summary>
        /// The person Line
        /// </summary>
        public ItemBuffer<Person> Line
        {
            get
            {
                return line;
            }

            private set
            {
                line = value;
            }
        }

        /// <summary>
        /// The gate id that the counter is connected to
        /// </summary>
        public uint GateId
        {
            get
            {
                return gateId;
            }

            private set
            {
                gateId = value;
            }
        }

        /// <summary>
        /// The event handler for when a bagage is being registered
        /// </summary>
        public RegisteredEvent RegisteredEventHandler
        {
            get
            {
                return registeredEventHandler;
            }

            set
            {
                registeredEventHandler = value;
            }
        }

        private ItemBuffer<Person> line;
        private uint gateId;
        private RegisteredEvent registeredEventHandler;

        public CounterDesk(uint id, Status status, uint gateId) : base (10, id, status)
        {
            Line = new ItemBuffer<Person>(50);
            GateId = gateId;
        }

        /// <summary>
        /// The thread work
        /// </summary>
        protected override void ThreadWork()
        {
            while (true)
            {
                Bagage curBagage = ProcessPerson();
                PutBagageOnBelt(curBagage);
            }
        }

        /// <summary>
        /// Puts the bagage on the belt if the buffer is not full
        /// </summary>
        /// <param name="bagage"></param>
        private void PutBagageOnBelt(Bagage bagage)
        {
            Monitor.Enter(Buffer.Lock);

            try
            {
                if (Buffer.IsBufferFull)
                    Monitor.Wait(Buffer.Lock);

                Buffer.AddToFrontBuffer(bagage);

                if (Buffer.BufferCounter == 1)
                    Monitor.PulseAll(Buffer.Lock);
            }
            finally
            {
                Monitor.Exit(Buffer.Lock);
            }
        }


        /// <summary>
        /// Takes the first person in line and returns the bagage
        /// </summary>
        /// <returns></returns>
        private Bagage ProcessPerson()
        {
            Monitor.Enter(Line.Lock);

            try
            {
                if (Line.IsBufferEmpty)
                {
                    Monitor.PulseAll(Line.Lock);
                    Monitor.Wait(Line.Lock);
                }

                Person curPers = Line.RemoveFromBackBuffer();

                curPers.Bagage.SetSticker(curPers.GateId);
                RegisteredEventHandler?.Invoke(curPers.Bagage, this);

                return curPers.Bagage;
            }
            finally
            {
                Monitor.Exit(Line.Lock);
            }
        }

    }
}
