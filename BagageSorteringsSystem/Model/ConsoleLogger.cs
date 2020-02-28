using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagageSorteringsSystem.Model
{
    public class ConsoleLogger : ILog
    {
        /// <summary>
        /// The log for when writing can begin
        /// </summary>
        public object Lock
        {
            get
            {
                return _lock;
            }
        }

        private object _lock = new object();

        /// <summary>
        /// Appends data to the console
        /// </summary>
        /// <param name="data"></param>
        public void Append(string data)
        {
            Console.WriteLine(data);
        }

        /// <summary>
        /// Clears the screen then writes
        /// </summary>
        /// <param name="data"></param>
        public void Write(string data)
        {
            Console.Clear();
            Console.WriteLine(data);
        }
    }
}
