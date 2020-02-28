using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BagageSorteringsSystem.Model;

namespace BagageSorteringsSystem
{
    public class CounterManager
    {

        /// <summary>
        /// The current counters
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
        private CounterDesk[] counters;

        public CounterManager(uint[] gateIds, uint amountOfDesks)
        {
            Counters = new CounterDesk[amountOfDesks];
            LoadCounters(gateIds);
        }

        /// <summary>
        /// This will load all the counters
        /// </summary>
        private void LoadCounters(uint[] gateIds)
        {
            int desksPerGate = (Counters.Length / gateIds.Length);
            uint curGateId = 0;

            for (int i = 0; i < Counters.Length; i++)
            {
                Counters[i] = new CounterDesk((uint)i, Status.Closed, curGateId);

                if (curGateId < desksPerGate)
                    curGateId++;
                else
                    curGateId = 0;
            }
        }

        /// <summary>
        /// Get a counterdesk from their id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CounterDesk GetDesk(uint id)
        {
            for (int i = 0; i < Counters.Length; i++)
            {
                if (Counters[i].Id == id)
                    return Counters[i];
            }

            return null;
        }

        /// <summary>
        /// Starts all the threads
        /// </summary>
        public void StartThreads()
        {
            for (int i = 0; i < Counters.Length; i++)
            {
                Counters[i].Start();
            }
        }

        /// <summary>
        /// Adds event method for all the counters
        /// </summary>
        /// <param name="eventMethod"></param>
        public void AddRegisteredEvent(CounterDesk.RegisteredEvent eventMethod)
        {
            for (int i = 0; i < Counters.Length; i++)
            {
                Counters[i].RegisteredEventHandler += eventMethod;
            }
        }

        /// <summary>
        /// Removes event method for all the counters
        /// </summary>
        /// <param name="eventMethod"></param>
        public void RemoveRegisteredEvent(CounterDesk.RegisteredEvent eventMethod)
        {
            for (int i = 0; i < Counters.Length; i++)
            {
                Counters[i].RegisteredEventHandler -= eventMethod;
            }
        }

        /// <summary>
        /// Get desks from their gate id
        /// </summary>
        /// <param name="gateId"></param>
        /// <returns></returns>
        public CounterDesk[] GetDesksFromGateId(uint gateId)
        {
            List<CounterDesk> counters = new List<CounterDesk>();

            for (int i = 0; i < Counters.Length; i++)
            {
                if (Counters[i].GateId == gateId)
                    counters.Add(Counters[i]);
            }

            return counters.ToArray();
        }


    }
}
