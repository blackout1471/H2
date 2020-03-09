using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace FileWatcherService
{
    public partial class Service1 : ServiceBase
    {

        private readonly string folderPath = @"C:\Repos";
        private readonly string fileLoggerPath = @"C:\Repos\log.txt";

        private FileWatcher watcher;
        private ILogger logger;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            watcher = new FileWatcher(folderPath);
            logger = new FileLogger(fileLoggerPath);

            watcher.Fsw.Changed += OnFileWatchChanged;
            watcher.Run();

            logger.Write($"{ServiceName} has started");
        }

        protected override void OnStop()
        {
            logger.Write($"{ServiceName} has stopped");
        }

        /// <summary>
        /// Event for when file changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFileWatchChanged(object sender, FileSystemEventArgs e)
        {
            logger.Write($"{e.Name} has been {e.ChangeType.ToString()}");
        }
    }
}
