using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BagageSorteringsSystem.Model
{
    public class FileLogger : ILog
    {
        /// <summary>
        /// The path to the file that is being written to
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
        private string path;

        public FileLogger(string path)
        {
            Path = path;
        }

        /// <summary>
        /// write data to file
        /// creates file if not exists already
        /// </summary>
        /// <param name="data"></param>
        public void Write(string data)
        {
            Monitor.Enter(Lock);
            try
            {
                File.WriteAllText(Path, data);
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                Monitor.Exit(Lock);
            }
            
        }

        /// <summary>
        /// Append data to file
        /// Creates file if not already exists
        /// </summary>
        /// <param name="data"></param>
        public void Append(string data)
        {
            Monitor.Enter(Lock);
            try
            {
                File.AppendAllText(Path, data);
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                Monitor.Exit(Lock);
            }

        }
    }
}
