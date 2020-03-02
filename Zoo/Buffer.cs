using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class Buffer<T>
    {

        /// <summary>
        /// The items
        /// </summary>
        public T[] Items
        {
            get
            {
                return items;
            }

            private set
            {
                items = value;
            }
        }

        /// <summary>
        /// The lock for the buffer
        /// </summary>
        public object Lock
        {
            get
            {
                return _lock;
            }

            set
            {
                _lock = value;
            }
        }

        /// <summary>
        /// Whether the buffer is full
        /// </summary>
        public bool IsBufferFull => (CurrentItems == Items.Length);

        /// <summary>
        /// whether the buffer is empty
        /// </summary>
        public bool IsBufferEmpty => (CurrentItems == 0);

        /// <summary>
        /// The current amount of items
        /// </summary>
        public int CurrentItems
        {
            get
            {
                return currentItems;
            }

            private set
            {
                currentItems = value;
            }
        }

        private T[] items;
        private object _lock = new object();
        private int currentItems;

        public Buffer(int bufferSize)
        {
            Items = new T[bufferSize];
            CurrentItems = 0;
        }

        /// <summary>
        /// Removes the first turd
        /// </summary>
        /// <param name="turd"></param>
        public void AddItem(T item)
        {
            for (int i = 0; i < Items.Length; i++)
            {
                if (Items[i] == null)
                {
                    Items[i] = item;
                    CurrentItems++;
                    return;
                }
            }
        }

        /// <summary>
        /// Removes the first turd
        /// </summary>
        /// <param name="turd"></param>
        public T RemoveItem()
        {
            for (int i = 0; i < Items.Length; i++)
            {
                if (Items[i] != null)
                {
                    T cur = Items[i];
                    Items[i] = default(T);
                    CurrentItems--;
                    return cur;
                }
            }

            return default(T);
        }


    }
}
