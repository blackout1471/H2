using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsFlyingAround
{
    /// <summary>
    /// This class is the simulator AKA the main
    /// </summary>
    public class BirdSimulator : Simulator
    {
        /// <summary>
        /// The animal which will get spawned
        /// </summary>
        public Animal Animal
        {
            get
            {
                return animal;
            }

            private set
            {
                animal = value;
            }
        }

        private Animal animal;

        /// <summary>
        /// Construct the simulator
        /// and set the animal to get spawned
        /// </summary>
        /// <param name="animal"></param>
        public BirdSimulator(Animal animal, Action<string> outputMessage) : base(outputMessage)
        {
            Animal = animal;
        }

        /// <summary>
        /// The update method will be called each tick
        /// </summary>
        public override void Update()
        {
            if (Animal is IFlyAble)
                ((IFlyAble)(Animal)).Fly(new Vector3(1, 1, 0) * DeltaTime);

            ShowMessage(string.Format("{0}'s speed is: {1}", Animal.Name, Animal.Position.Position));
        }
    }
}
