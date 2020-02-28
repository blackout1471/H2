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
    public class ScheduleManager : BaseThread
    {
        /// <summary>
        /// The path to the file schedule manager
        /// </summary>
        public string Path
        {
            get
            {
                return path;
            }

            private set
            {
                path = value;
            }
        }

        /// <summary>
        /// Airplane schedules
        /// </summary>
        public AirplaneSchedule[] Schedules
        {
            get
            {
                return schedules;
            }

            private set
            {
                schedules = value;
            }
        }

        private string path;
        private AirplaneSchedule[] schedules;

        public ScheduleManager(string path)
        {
            Path = path;
            LoadAirPlaneSchedule();
        }

        /// <summary>
        /// Loads the air plane schedule
        /// </summary>
        /// <param name="path"></param>
        public void LoadAirPlaneSchedule()
        {
            string[] data;

            try
            {
                data = File.ReadAllLines(Path);
            }
            catch (Exception e)
            {
                throw e;
            }

            schedules = new AirplaneSchedule[data.Length];

            for (int i = 0; i < schedules.Length; i++)
            {
                schedules[i] = new AirplaneSchedule();
                schedules[i].ReadData(data[i]);
            }
        }

        /// <summary>
        /// Get the current opens gates
        /// </summary>
        /// <returns></returns>
        public uint[] GetCurrentOpenGates()
        {
            List<uint> ids = new List<uint>();

            for (int i = 0; i < Schedules.Length; i++)
            {
                AirplaneSchedule cur = Schedules[i];

                if (cur.OpenGate <= DateTime.Now && cur.Leaving > DateTime.Now)
                    ids.Add(cur.GateId);
            }

            return ids.ToArray();
        }

        /// <summary>
        /// Get all the unique gate ids
        /// </summary>
        /// <returns></returns>
        public uint[] GetAllGateIds()
        {
            return Schedules.Select(x => x.GateId).Distinct().ToArray();
        }

        /// <summary>
        /// Get the schedule in string format
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string s = "";

            for (int i = 0; i < Schedules.Length; i++)
            {
                AirplaneSchedule cur = Schedules[i];

                s += $"Destination: {cur.Destination} Gate: {cur.GateId} Opens: {cur.OpenGate.ToString("HH.mm")} Leaving: {cur.Leaving.ToString("HH.mm")} Is Open {cur.Active}\n";
            }

            return s;
        }

        /// <summary>
        /// Adds eventhandler to all the schedules
        /// </summary>
        /// <param name="eventHandler"></param>
        public void AddActiveEventChangedMethod(AirplaneSchedule.ActiveChangedEvent eventHandler)
        {
            for (int i = 0; i < Schedules.Length; i++)
            {
                Schedules[i].ActiveChangedHandler += eventHandler;
            }
        }

        /// <summary>
        /// Removes event method from all the schedules
        /// </summary>
        /// <param name="eventHandler"></param>
        public void RemoveActiveEventChangedMethod(AirplaneSchedule.ActiveChangedEvent eventHandler)
        {
            for (int i = 0; i < Schedules.Length; i++)
            {
                Schedules[i].ActiveChangedHandler += eventHandler;
            }
        }

        /// <summary>
        /// Check whether the schedule is active or not
        /// </summary>
        protected override void ThreadWork()
        {
            while (true)
            {
                for (int i = 0; i < Schedules.Length; i++)
                {
                    AirplaneSchedule cur = Schedules[i];

                    if (cur.OpenGate <= DateTime.Now && cur.Leaving > DateTime.Now)
                        cur.Active = true;
                    else
                        cur.Active = false;
                }

                // Don't let the cpu spin
                Thread.Sleep(1000);
            }
        }
    }
}
