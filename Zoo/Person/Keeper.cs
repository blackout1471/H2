using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Zoo.turd;

namespace Zoo.Person
{
    public class Keeper : BaseThread
    {
        /// <summary>
        /// The delegate for when a turd has been cleaned
        /// </summary>
        /// <param name="keeper"></param>
        /// <param name="turd"></param>
        public delegate void TurdCleanedEvent(Keeper keeper, Turd turd);

        /// <summary>
        /// The name of the current keeper
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }

            private set
            {
                name = value;
            }
        }

        /// <summary>
        /// The fences hes keeping clean
        /// </summary>
        public Fence[] Fences
        {
            get
            {
                return fences;
            }

            private set
            {
                fences = value;
            }
        }

        /// <summary>
        /// Turd cleaned event handler
        /// </summary>
        public TurdCleanedEvent TurdCleanedHandler
        {
            get
            {
                return turdCleanedHandler;
            }

            set
            {
                turdCleanedHandler = value;
            }
        }

        private string name;
        private Fence[] fences;
        private TurdCleanedEvent turdCleanedHandler;

        public Keeper(string name, Fence[] fences)
        {
            Name = name;
            Fences = fences;
        }

        /// <summary>
        /// The thread of the keeper
        /// </summary>
        protected override void ThreadWork()
        {
            while(true)
            {
                for (int i = 0; i < Fences.Length; i++)
                {
                    Turd turdToClean = null;
                    Fence curFence = Fences[i];

                    Monitor.Enter(curFence.TurdBuffer.Lock);

                    try
                    {
                        if (curFence.TurdBuffer.IsBufferFull)
                            Monitor.Wait(curFence.TurdBuffer.Lock);

                        turdToClean = curFence.TurdBuffer.RemoveItem();
                    }
                    finally
                    {
                        Monitor.Exit(curFence.TurdBuffer.Lock);
                    }

                    if (turdToClean != null)
                    {
                        Thread.Sleep(turdToClean.TimeToClean);
                        TurdCleanedHandler?.Invoke(this, turdToClean);
                    }
                }       
            }
        }
    }
}
