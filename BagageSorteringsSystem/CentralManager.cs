using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BagageSorteringsSystem.Model;

namespace BagageSorteringsSystem
{

    /// <summary>
    /// Class for overseeing all the objects, and make them work together
    /// Created as a singleton object
    /// </summary>
    public class CentralManager
    {
        // Singleton pattern
        public static CentralManager Instance { get { if (instance == null) { instance = new CentralManager(); } return instance; } }
        private static CentralManager instance = null;
        private CentralManager() 
        {
        }

        /// <summary>
        /// The current schedule manager
        /// </summary>
        public ScheduleManager ScheduleManager
        {
            get
            {
                return scheduleManager;
            }

            private set
            {
                scheduleManager = value;
            }
        }

        /// <summary>
        /// The current person manager
        /// </summary>
        public PersonManager PersonsManager
        {
            get
            {
                return personsManager;
            }

            private set
            {
                personsManager = value;
            }
        }

        /// <summary>
        /// The current gate manager
        /// </summary>
        public GateManager GateManager
        {
            get
            {
                return gateManager;
            }

            private set
            {
                gateManager = value;
            }
        }

        /// <summary>
        /// The current counter manager
        /// </summary>
        public CounterManager CounterManager
        {
            get
            {
                return counterManager;
            }

            private set
            {
                counterManager = value;
            }
        }

        /// <summary>
        /// The current sorting machine in between Counter and Gate
        /// </summary>
        public Sorting SortingMachine
        {
            get
            {
                return sortingMachine;
            }

            private set
            {
                sortingMachine = value;
            }
        }

        /// <summary>
        /// The current file logger
        /// </summary>
        public ILog FileLogger
        {
            get
            {
                return fileLogger;
            }

            private set
            {
                fileLogger = value;
            }
        }

        /// <summary>
        /// The current console logger
        /// </summary>
        public ILog ConsoleLogger
        {
            get
            {
                return consoleLogger;
            }

            private set
            {
                consoleLogger = value;
            }
        }

        private ScheduleManager scheduleManager;
        private PersonManager personsManager;
        private GateManager gateManager;
        private CounterManager counterManager;
        private Sorting sortingMachine;
        private ILog fileLogger;
        private ILog consoleLogger;

        public void CreateManagers()
        {
            ScheduleManager = new ScheduleManager(@"Data/AirplaneSchedule.txt");
            
            uint[] gateIds = ScheduleManager.GetAllGateIds();
            GateManager = new GateManager(gateIds);
            CounterManager = new CounterManager(GateManager.GetGateIds(), (uint)gateIds.Length * 2);

            SortingMachine = new Sorting(CounterManager.Counters, GateManager.Gates);

            PersonsManager = new PersonManager(CounterManager.Counters);

            FileLogger = new FileLogger(@"Log-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt");
            ConsoleLogger = new ConsoleLogger();

            ScheduleManager.AddActiveEventChangedMethod(ScheduleHasChanged);
        }

        /// <summary>
        /// Start the central manager
        /// </summary>
        public void StartAll()
        {
            CounterManager.StartThreads();
            GateManager.StartThreads();
            SortingMachine.Start();
            ScheduleManager.Start();
            PersonsManager.Start();
        }

        /// <summary>
        /// Opens gates and the relative counters
        /// </summary>
        /// <param name="id"></param>
        public void OpenGate(uint id)
        {
            Gate gate = GateManager.GetGate(id);
            CounterDesk[] desks = CounterManager.GetDesksFromGateId(id);

            gate.Open();

            for (int i = 0; i < desks.Length; i++)
            {
                desks[i].Open();
            }
        }

        /// <summary>
        /// Closes the gate and the relative counters
        /// </summary>
        /// <param name="id"></param>
        public void CloseGate(uint id)
        {
            Gate gate = GateManager.GetGate(id);
            CounterDesk[] desks = CounterManager.GetDesksFromGateId(id);

            gate.Close();

            for (int i = 0; i < desks.Length; i++)
            {
                desks[i].Close();
            }
        }

        /// <summary>
        /// Forces the schedules gate to forcefully open up
        /// </summary>
        /// <param name="scheduleNmb"></param>
        public void ForceScheduleToOpen(uint scheduleNmb)
        {
            if (scheduleNmb >= 0 && scheduleNmb < ScheduleManager.Schedules.Length)
                ScheduleManager.Schedules[scheduleNmb].SetComingDate(DateTime.Now);
        }

        /// <summary>
        /// Forces the schedules gate to forcefully close up
        /// </summary>
        /// <param name="scheduleNmb"></param>
        public void ForceScheduleToClose(uint scheduleNmb)
        {
            if (scheduleNmb >= 0 && scheduleNmb < ScheduleManager.Schedules.Length)
                ScheduleManager.Schedules[scheduleNmb].SetLeaveDate(DateTime.Now);
        }

        /// <summary>
        /// When a schedule changes open or close gates
        /// </summary>
        /// <param name="schedule"></param>
        private void ScheduleHasChanged(AirplaneSchedule schedule)
        {
            if (schedule.Active)
                OpenGate(schedule.GateId);
            else
                CloseGate(schedule.GateId);
        }

    }
}
