﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flaskebaand
{
    /// <summary>
    /// This class is used for base thread to inherit from
    /// </summary>
    public abstract class BaseThread
    {
        /// <summary>
        /// The thread which will be created
        /// </summary>
        private Thread Thread { get => thread; set => thread = value; }
        private Thread thread;

        protected BaseThread()
        {
            this.Thread = new Thread(new ThreadStart(ThreadWork));
        }

        // Method to start the thread
        public void Start() { this.Thread.Start(); }

        // Method to join the thread
        public void Join() { this.Thread.Join(); }
        
        /// <summary>
        /// Check if the thread is alive
        /// </summary>
        /// <returns></returns>
        public bool IsAlive() { return this.Thread.IsAlive; }

        /// <summary>
        /// The inherited classes thread process
        /// </summary>
        protected abstract void ThreadWork();
    }
}
