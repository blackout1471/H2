using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagageSorteringsSystem.Model
{
    public abstract class Desk : BaseThread
    {
        /// <summary>
        /// The id of the counter
        /// </summary>
        public uint Id
        {
            get { return id; }
            private set { id = value; }
        }

        /// <summary>
        /// The status of the counter
        /// </summary>
        public Status Status
        {
            get
            {
                return status;
            }

            private set
            {
                status = value;
            }
        }

        /// <summary>
        /// If the counter is open
        /// </summary>
        public bool IsOpen => (Status == Status.Open) ? true : false;

        /// <summary>
        /// How many bagages has been checked in
        /// </summary>
        public uint BagageCounter
        {
            get
            {
                return bagageCounter;
            }

            private set
            {
                bagageCounter = value;
            }
        }

        /// <summary>
        /// The current buffer of the counter
        /// </summary>
        public ItemBuffer<Bagage> Buffer
        {
            get
            {
                return buffer;
            }

            private set
            {
                buffer = value;
            }
        }

        private uint id;
        private Status status;
        private uint bagageCounter;
        private ItemBuffer<Bagage> buffer;

        public Desk(uint bufferSize, uint id, Status status)
        {
            Id = id;
            Status = status;
            ResetBuffer(bufferSize);
        }

        /// <summary>
        /// Resets the buffer size
        /// </summary>
        /// <param name="size"></param>
        public void ResetBuffer(uint size)
        {
            BagageCounter = 0;
            Buffer = new ItemBuffer<Bagage>(size);
        }

        /// <summary>
        /// Closes the desk
        /// </summary>
        public void Close()
        {
            Status = Status.Closed;
        }

        /// <summary>
        /// Opens the desk
        /// </summary>
        public void Open()
        {
            Status = Status.Open;
        }
    }
}
