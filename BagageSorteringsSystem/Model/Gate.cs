using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BagageSorteringsSystem.Model
{
    public class Gate : Desk
    {
        /// <summary>
        /// The event for when the airplane has loaded all the bagage
        /// </summary>
        /// <param name="bagage"></param>
        /// <param name="gate"></param>
        public delegate void AiplaneLoadedBagageEvent(Gate gate);

        /// <summary>
        /// The eventhandler for when bagage has been registered
        /// </summary>
        public AiplaneLoadedBagageEvent BagageLoadedHandler { get => bagageLoadedHandler; set => bagageLoadedHandler = value; }
        private AiplaneLoadedBagageEvent bagageLoadedHandler;

        public Gate(uint id, Status status) : base(30, id, status)
        {
        }

        /// <summary>
        /// The threads workload
        /// </summary>
        protected override void ThreadWork()
        {
            while (true)
            {
                Monitor.Enter(Buffer.Lock);

                try
                {
                    if (Buffer.IsBufferEmpty)
                        Monitor.Wait(Buffer.Lock);

                    if (Buffer.IsBufferFull)
                    {
                        LoadAirplaneWithBagage();
                        Monitor.PulseAll(Buffer.Lock);
                        BagageLoadedHandler?.Invoke(this);
                    }
                }
                finally
                {
                    Monitor.Exit(Buffer.Lock);
                }
            }
        }

        /// <summary>
        /// Loads the aiplane with bagage
        /// </summary>
        public void LoadAirplaneWithBagage()
        {
            Monitor.Enter(Buffer.Lock);

            try
            {
                Buffer.FlushBuffer();
            }
            finally
            {
                Monitor.Exit(Buffer.Lock);
            }
        }
    }
}
