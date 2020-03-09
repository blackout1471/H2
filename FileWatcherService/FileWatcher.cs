using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWatcherService
{
    public class FileWatcher
    {
        /// <summary>
        /// File system watcher object
        /// </summary>
        public FileSystemWatcher Fsw
        {
            get
            {
                return fsw;
            }

            private set
            {
                fsw = value;
            }
        }

        /// <summary>
        /// The path to the file folder to watch
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

        private FileSystemWatcher fsw;
        private string path;

        public FileWatcher(string path)
        {
            Path = path;
            fsw = new FileSystemWatcher(Path);
        }

        /// <summary>
        /// This will begin watching changes in the folder
        /// this will block the main thread
        /// </summary>
        public void Run()
        {
            // Watch for changes in LastAccess and LastWrite times, and
            // the renaming of files or directories.
            fsw.NotifyFilter = NotifyFilters.LastAccess
                                    | NotifyFilters.LastWrite
                                    | NotifyFilters.FileName
                                    | NotifyFilters.DirectoryName;

            // Only watch text files.
            fsw.Filter = "*";

            // Begin watching.
            fsw.EnableRaisingEvents = true;
        }
    }
}
