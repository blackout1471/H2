using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagageSorteringsSystem.Model
{
    public class ItemBuffer<T>
    {
        /// <summary>
        /// The belt / buffer of the belt
        /// </summary>
        public T[] Buffer
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

        /// <summary>
        /// The current count of bagages
        /// </summary>
        public uint BufferCounter
        {
            get
            {
                return bufferCounter;
            }

            private set
            {
                bufferCounter = value;
            }
        }

        /// <summary>
        /// The current Lock
        /// </summary>
        public object Lock
        {
            get
            {
                return _lock;
            }

            private set
            {
                _lock = value;
            }
        }

        /// <summary>
        /// returns whether the current belt is full
        /// </summary>
        public bool IsBufferFull => (Buffer.Length == BufferCounter);

        /// <summary>
        /// Whether the buffer is empty
        /// </summary>
        public bool IsBufferEmpty => (BufferCounter == 0);

        private T[] buffer;
        private uint bufferCounter;
        private object _lock = new object();

        public ItemBuffer(uint bufferLength)
        {
            Buffer = new T[bufferLength];
            BufferCounter = 0;
        }


        /// <summary>
        /// Adds bagage to the front of the buffer
        /// </summary>
        /// <param name="bagage"></param>
        public void AddToFrontBuffer(T bagage)
        {
            for (int i = 0; i < Buffer.Length; i++)
            {
                if (Buffer[i] == null)
                {
                    Buffer[i] = bagage;
                    BufferCounter++;
                    return;
                }
            }
        }

        /// <summary>
        /// Removes bagage from the back of the buffer
        /// </summary>
        /// <returns></returns>
        public T RemoveFromBackBuffer()
        {
            for (int i = Buffer.Length-1; i >= 0 ; i--)
            {
                if (Buffer[i] != null)
                {
                    T item = Buffer[i];
                    Buffer[i] = default(T);
                    BufferCounter--;
                    return item;
                }
            }

            return default(T);
        }

        /// <summary>
        /// Flushes the buffer
        /// </summary>
        public void FlushBuffer()
        {
            for (int i = 0; i < Buffer.Length; i++)
            {
                Buffer[i] = default(T);
            }
        }
    }
}
