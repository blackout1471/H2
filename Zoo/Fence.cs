using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Zoo.Animal;
using Zoo.turd;

namespace Zoo
{
    public class Fence
    {
        /// <summary>
        /// The animals in the fence
        /// </summary>
        public Animal.Animal[] Animals
        {
            get
            {
                return animals;
            }

            private set
            {
                animals = value;
            }
        }

        /// <summary>
        /// The turd buffer for shits
        /// </summary>
        public TurdBuffer TurdBuffer
        {
            get
            {
                return turdBuffer;
            }

            private set
            {
                turdBuffer = value;
            }
        }

        private Animal.Animal[] animals;
        private TurdBuffer turdBuffer;

        public Fence(params Animal.Animal[] animals)
        {
            Animals = animals;
            TurdBuffer = new TurdBuffer();
        }

        /// <summary>
        /// Start all the threads and attach events
        /// </summary>
        public void Start()
        {
            AttachMethodForAnimalShit(AnimalShitMethod);

            for (int i = 0; i < Animals.Length; i++)
            {
                Animals[i].Start();   
            }

        }

        /// <summary>
        /// Attach a event when for when a animal shits
        /// </summary>
        /// <param name="ev"></param>
        public void AttachMethodForAnimalShit(Animal.Animal.AnimalShitEvent ev)
        {
            for (int i = 0; i < Animals.Length; i++)
            {
                Animals[i].ShitEventHandler += ev;
            }
        }

        /// <summary>
        /// What happens when a animal shits
        /// </summary>
        /// <param name="animal"></param>
        /// <param name="turd"></param>
        private void AnimalShitMethod(Animal.Animal animal, Turd turd)
        {
            Monitor.Enter(TurdBuffer.Lock);
            try
            {
                if (TurdBuffer.IsBufferFull)
                {
                    Monitor.PulseAll(TurdBuffer.Lock);
                }

                TurdBuffer.AddItem(turd);

                if (TurdBuffer.CurrentItems == 1)
                    Monitor.PulseAll(TurdBuffer.Lock);
            }
            finally
            {
                Monitor.Exit(TurdBuffer.Lock);
            }
        }
    }
}
