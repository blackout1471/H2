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
    class Program
    {
        static void Main(string[] args)
        {
            CentralManager.Instance.CreateManagers();

            CentralManager.Instance.CounterManager.AddRegisteredEvent(CounterMessage);
            CentralManager.Instance.GateManager.AddLoadedEvent(GateHasLoadedBagage);
            CentralManager.Instance.SortingMachine.InGoingBagageHandler += SortingIngoingMessage;
            CentralManager.Instance.SortingMachine.OutGoingBagageHandler += SortingOutgoingMessage;
            CentralManager.Instance.ScheduleManager.AddActiveEventChangedMethod(ShowChanges);
            ShowChanges(null);

            CentralManager.Instance.StartAll();

            // Take user input on the background thread
            while (true)
            {
                string line = Console.ReadLine();

                int number = 0;
                if (int.TryParse(line, out number))
                    if (!CentralManager.Instance.ScheduleManager.Schedules[number].Active)
                        CentralManager.Instance.ForceScheduleToOpen((uint)number);
                    else
                        CentralManager.Instance.ForceScheduleToClose((uint)number);
            }
        }

        /// <summary>
        /// Called when the schedule is changed
        /// </summary>
        /// <param name="schedule"></param>
        static void ShowChanges(AirplaneSchedule schedule)
        {
            CentralManager.Instance.ConsoleLogger.Write(CentralManager.Instance.ScheduleManager.ToString());
            CentralManager.Instance.ConsoleLogger.Append($"Press [0 - {CentralManager.Instance.ScheduleManager.Schedules.Length - 1}] to forcefully open/close schedules gates");
        }

        /// <summary>
        /// Called when the counter registers a bagage
        /// </summary>
        /// <param name="bagage"></param>
        /// <param name="desk"></param>
        static void CounterMessage(Bagage bagage, CounterDesk desk)
        {
            CentralManager.Instance.FileLogger.Append($"[{bagage.Brand}] [{DateTime.Now}] [{desk.GateId}] Checked In\n");
        }

        /// <summary>
        /// Called when the gate has loaded a pile of bagage
        /// </summary>
        /// <param name="gate"></param>
        static void GateHasLoadedBagage(Gate gate)
        {
            CentralManager.Instance.FileLogger.Append($"[{gate.Id}] [{DateTime.Now}] bagage has been loaded\n");
        }

        /// <summary>
        /// Called when a bagage is about to be sorted
        /// </summary>
        /// <param name="bagage"></param>
        static void SortingIngoingMessage(Bagage bagage)
        {
            CentralManager.Instance.FileLogger.Append($"[{bagage.Brand}] [{DateTime.Now}] about to be sorted\n");
        }

        /// <summary>
        /// Called when the bagage has been sorted
        /// </summary>
        /// <param name="bagage"></param>
        static void SortingOutgoingMessage(Bagage bagage)
        {
            CentralManager.Instance.FileLogger.Append($"[{bagage.Brand}] [{DateTime.Now}] sorted and going to gate: [{bagage.Sticker.GateId}]\n");
        }
    }
}
