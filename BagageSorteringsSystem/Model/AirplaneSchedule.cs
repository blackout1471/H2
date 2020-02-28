using BagageSorteringsSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagageSorteringsSystem.Model
{
    public class AirplaneSchedule : ISerializable<AirplaneSchedule>
    {
		/// <summary>
		/// The event for when active is changed
		/// </summary>
		/// <param name="schedule"></param>
		public delegate void ActiveChangedEvent(AirplaneSchedule schedule);

		/// <summary>
		/// The unique id of the airplane schedule
		/// </summary>
		public uint Id
		{
			get { return id; }
			private set { id = value; }
		}

		/// <summary>
		/// The destination
		/// </summary>
		public string Destination
		{
			get
			{
				return destination;
			}

			private set
			{
				destination = value;
			}
		}

		/// <summary>
		/// What time the airplane is leaving
		/// </summary>
		public DateTime Leaving
		{
			get
			{
				return leaving;
			}

			private set
			{
				leaving = value;
			}
		}

		/// <summary>
		/// The gate which the airplane will leave from
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
		/// When the gate will open
		/// </summary>
		public DateTime OpenGate
		{
			get
			{
				return openGate;
			}

			private set
			{
				openGate = value;
			}
		}

		/// <summary>
		/// Whether the schedule is active right now
		/// </summary>
		public bool Active
		{
			get
			{
				return active;
			}

			set
			{
				if (value == active)
					return;

				active = value;
				ActiveChangedHandler?.Invoke(this);
			}
		}

		/// <summary>
		/// Event for when active changed
		/// </summary>
		public ActiveChangedEvent ActiveChangedHandler
		{
			get
			{
				return activeChangedHandler;
			}

			set
			{
				activeChangedHandler = value;
			}
		}

		private uint id;
		private string destination;
		private DateTime openGate;
		private DateTime leaving;
		private uint gateId;
		private bool active;
		private ActiveChangedEvent activeChangedHandler;

		public AirplaneSchedule()
		{
			Id = 0;
			Destination = "";
			OpenGate = DateTime.Now;
			Leaving = DateTime.Now;
			GateId = 0;
			Active = false;
		}

		public AirplaneSchedule(uint id, string destination, DateTime openGate, DateTime leaving, uint gateId)
		{
			Id = id;
			Destination = destination;
			Leaving = leaving;
			GateId = gateId;
			OpenGate = openGate;
			Active = false;
		}

		/// <summary>
		/// Reads data and converts it into this class
		/// </summary>
		/// <param name="rawData"></param>
		public void ReadData(string rawData)
		{
			string[] arr = rawData.Split('|');

			if (arr.Length != 5)
				throw new Exception("Not correct data");

			uint tId = uint.Parse(arr[0]);
			string tDest = arr[1];
			uint tGateId = uint.Parse(arr[2]);
			DateTime tOpen = DateTime.Now.AddMinutes(double.Parse(arr[3]));
			DateTime tLeave = DateTime.Now.AddMinutes(double.Parse(arr[4]));

			Id = tId;
			Destination = tDest;
			Leaving = tLeave;
			GateId = tGateId;
			OpenGate = tOpen;
		}

		/// <summary>
		/// returns the serialized object
		/// </summary>
		/// <returns></returns>
		public string WriteData()
		{
			TimeSpan time = Leaving.TimeOfDay - DateTime.Now.TimeOfDay;

			return $"{Id}|{Destination}|{GateId}|{time.Minutes}|{time.Minutes}";
		}


		/// <summary>
		/// Sets when the counters opens up
		/// </summary>
		/// <param name="date"></param>
		public void SetComingDate(DateTime date)
		{
			OpenGate = date;
		}

		/// <summary>
		/// Sets when the gates are closing
		/// </summary>
		/// <param name="date"></param>
		public void SetLeaveDate(DateTime date)
		{
			Leaving = date;
		}
	}
}
