using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BagageSorteringsSystem.Model;

namespace BagageSorteringsSystem
{
    public class GateManager
    {
        /// <summary>
        /// The current gates
        /// </summary>
        public Gate[] Gates
        {
            get
            {
                return gates;
            }

            private set
            {
                gates = value;
            }
        }

        private Gate[] gates;

        public GateManager(uint[] ids)
        {
            Gates = new Gate[ids.Length];
            LoadGates(ids);
        }

        /// <summary>
        /// This will load all the different gates relative to the schedule
        /// </summary>
        private void LoadGates(uint[] ids)
        {
            for (int i = 0; i < ids.Length; i++)
            {
                Gates[i] = new Gate(ids[i], Status.Closed);
            }
        }

        /// <summary>
        /// Returns the gate with specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Gate GetGate(uint id)
        {
            for (int i = 0; i < Gates.Length; i++)
            {
                if (Gates[i].Id == id)
                    return Gates[i];
            }

            return null;
        }

        /// <summary>
        /// Get all the gates ids
        /// </summary>
        /// <returns></returns>
        public uint[] GetGateIds()
        {
            return Gates.Select(x => x.Id).ToArray();
        }

        /// <summary>
        /// Starts all the gates threads
        /// </summary>
        public void StartThreads()
        {
            for (int i = 0; i < Gates.Length; i++)
            {
                Gates[i].Start();
            }
        }

        /// <summary>
        /// Adds event method for all the gates
        /// </summary>
        /// <param name="eventMethod"></param>
        public void AddLoadedEvent(Gate.AiplaneLoadedBagageEvent eventMethod)
        {
            for (int i = 0; i < Gates.Length; i++)
            {
                Gates[i].BagageLoadedHandler += eventMethod;
            }
        }

        /// <summary>
        /// Removes event method for all the gates
        /// </summary>
        /// <param name="eventMethod"></param>
        public void RemoveLoadedEventEvent(Gate.AiplaneLoadedBagageEvent eventMethod)
        {
            for (int i = 0; i < Gates.Length; i++)
            {
                Gates[i].BagageLoadedHandler -= eventMethod;
            }
        }


    }
}
