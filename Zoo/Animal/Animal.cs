using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Zoo.turd;

namespace Zoo.Animal
{
    public abstract class Animal : BaseThread
    {
        /// <summary>
        /// Called when it's time for the animal to shit
        /// </summary>
        /// <returns></returns>
        public delegate void AnimalShitEvent(Animal animal, Turd turd);

        /// <summary>
        /// The name of the animal
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }

            private set
            {
                name = value;
            }
        }

        /// <summary>
        /// the interval between each shit
        /// </summary>
        public int ShitInterval
        {
            get
            {
                return shitInterval;
            }
            set
            {
                shitInterval = value;
            }
        }

        /// <summary>
        /// How much time has passed since the last shit
        /// </summary>
        public int CurrentShitCounter
        {
            get
            {
                return currentShitCounter;
            }

            private set
            {
                currentShitCounter = value;
            }
        }

        /// <summary>
        /// The event handler for when the animal is shitting
        /// </summary>
        public AnimalShitEvent ShitEventHandler
        {
            get
            {
                return shitEventHandler;
            }

            set
            {
                shitEventHandler = value;
            }
        }

        private string name;
        private int shitInterval;
        private int currentShitCounter;
        private AnimalShitEvent shitEventHandler;

        public Animal(string name, int interval)
        {
            Name = name;
            ShitInterval = interval;
        }

        /// <summary>
        /// Call when the animal is shitting
        /// </summary>
        protected abstract Turd Shit();

        /// <summary>
        /// The thread which will handle the animal shitting routine
        /// </summary>
        protected override void ThreadWork()
        {
            while (true)
            {
                Thread.Sleep(ShitInterval);

                // invoke delegate
                ShitEventHandler?.Invoke(this, Shit());
            }
        }



    }
}
