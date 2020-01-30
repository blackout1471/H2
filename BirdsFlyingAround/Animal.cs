using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsFlyingAround
{
    public abstract class Animal
    {
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
        /// The position of the animal in the world
        /// </summary>
        public WorldPosition Position
        {
            get
            {
                return position;
            }

            private set
            {
                position = value;
            }
        }

        private string name;
        private WorldPosition position;

        public Animal(string name, WorldPosition pos)
        {
            Name = name;
            Position = pos; 
        }
        
    }
}
