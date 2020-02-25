using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flaskebaand
{
	/// <summary>
	/// The bottle buffer object
	/// used to hold a amount of bottles temporary
	/// </summary>
    public class BottleBuffer
    {
		/// <summary>
		/// Lock used to thread safe the class
		/// </summary>
		public object Lock
		{
			get { return _lock; }
			private set { _lock = value; }
		}

		/// <summary>
		/// The bottles that is currently in the buffer
		/// </summary>
		public Bottle[] Buffer
		{
			get { return buffer; }
			private set { buffer = value; }
		}

		private object _lock;
		private Bottle[] buffer;

		public BottleBuffer(uint bufferLength)
		{
			Buffer = new Bottle[bufferLength];
			Lock = new object();
		}

		/// <summary>
		/// Adds a bottle to the place which is first available
		/// </summary>
		/// <param name="bottle"></param>
		public void AddBottleInFront(Bottle bottle)
		{
			for (int i = 0; i < Buffer.Length; i++)
			{
				if (Buffer[i] == null)
				{
					Buffer[i] = bottle;
					return;
				}
			}
		}

		/// <summary>
		/// Removes the last object in the buffer
		/// </summary>
		/// <returns></returns>
		public Bottle RemoveLastBottle()
		{
			for (int i = Buffer.Length-1; i >= 0; i--)
			{
				if (Buffer[i] != null)
				{
					Bottle cur = Buffer[i];
					buffer[i] = null;
					return cur;
				}
			}

			return null;
		}

		/// <summary>
		/// Returns whether the buffer is full
		/// </summary>
		/// <returns></returns>
		public bool IsBufferFull()
		{
			for (int i = 0; i < Buffer.Length; i++)
			{
				if (Buffer[i] == null)
					return false;
			}

			return true;
		}

		/// <summary>
		/// Get the current amount of items in the buffer
		/// </summary>
		/// <returns></returns>
		public int GetItemsInBuffer()
		{
			int amount = 0;

			for (int i = 0; i < Buffer.Length; i++)
			{
				if (Buffer[i] != null)
					amount++;
			}

			return amount;
		}
	}
}
