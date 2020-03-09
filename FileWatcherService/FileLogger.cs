using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWatcherService
{
    public class FileLogger : ILogger
    {
        /// <summary>
        /// The path to the file
        /// </summary>
        public string FilePath
        {
            get
            {
                return filePath;
            }

            private set
            {
                filePath = value;
            }
        }
        private string filePath;

        public FileLogger(string path)
        {
            FilePath = path;
        }

        /// <summary>
        /// Write to file, it already register time
        /// it will also create a new line
        /// </summary>
        /// <param name="data"></param>
        public void Write(string data)
        {
            DateTime time = DateTime.Now;

            try
            {
                File.AppendAllText(FilePath, $"{time} {data}\n");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
