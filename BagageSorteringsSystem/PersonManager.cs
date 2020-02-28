using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BagageSorteringsSystem.Model;

namespace BagageSorteringsSystem
{
    public class PersonManager : BaseThread
    {

        /// <summary>
        /// The person factory used to generate random persons for random destinations
        /// </summary>
        public PersonFactory PersonFactory
        {
            get
            {
                return personFactory;
            }

            private set
            {
                personFactory = value;
            }
        }

        /// <summary>
        /// References to the available counters
        /// </summary>
        public CounterDesk[] Counters
        {
            get
            {
                return counters;
            }

            private set
            {
                counters = value;
            }
        }

        private PersonFactory personFactory;
        private CounterDesk[] counters;
        private Random rnd = new Random(Guid.NewGuid().GetHashCode());


        public PersonManager(CounterDesk[] counters)
        {
            Counters = counters;
            PersonFactory = new PersonFactory();
        }

        /// <summary>
        /// Thread for generating persons
        /// and delegating them to the different gates
        /// </summary>
        protected override void ThreadWork()
        {
            while (true)
            {

                for (int i = 0; i < Counters.Length; i++)
                {
                    CounterDesk curDesk = Counters[i];
                    Monitor.Enter(curDesk.Line.Lock);

                    try
                    {
                        if (!curDesk.IsOpen)
                            continue;

                        if (curDesk.Line.IsBufferFull)
                            continue;

                        // Create a chance to generate person :)
                        int pRnd = rnd.Next(0, 10000);

                        if (pRnd <= 10)
                            curDesk.Line.AddToFrontBuffer(PersonFactory.GeneratePerson(curDesk.GateId));

                        if (curDesk.Line.BufferCounter == 1)
                            Monitor.PulseAll(curDesk.Line.Lock);
                    }
                    finally
                    {
                        Monitor.Exit(Counters[i].Line.Lock);
                    }
                }
            }
        }
    }
}
