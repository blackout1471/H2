using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsFlyingAround
{
    public abstract class Simulator
    {
        /// <summary>
        /// The time between each tick
        /// measured in seconds
        /// </summary>
        public float DeltaTime
        {
            get
            {
                return deltaTime;
            }

            private set
            {
                deltaTime = value;
            }
        }

        /// <summary>
        /// Whether the simulator should run
        /// </summary>
        public bool Simulating
        {
            get
            {
                return simulating;
            }

            private set
            {
                simulating = value;
            }
        }

        private Action<string> OutPutMethod
        {
            get
            {
                return outPutMethod;
            }

            set
            {
                outPutMethod = value;
            }
        }

        private float deltaTime;
        private bool simulating;
        private Action<string> outPutMethod;

        public Simulator(Action<string> outputMethod)
        {
            OutPutMethod = outputMethod;
            Simulating = true;
        }

        protected void ShowMessage(string message)
        {
            OutPutMethod(message);
        }

        /// <summary>
        /// The update method will get called each tick
        /// </summary>
        public abstract void Update();

        /// <summary>
        /// The run method, will start the simulator and run the functionality
        /// </summary>
        public void Run()
        {
            DateTime d1, d2;
            d1 = d2 = DateTime.Now;

            while (Simulating)
            {
                // Calculate delta time between each update
                d2 = DateTime.Now;
                TimeSpan delta = d2.Subtract(d1);
                DeltaTime = (float)delta.TotalSeconds;
                d1 = d2;

                Update();
            }
        }
    }
}
