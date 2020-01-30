using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsFlyingAround
{
    /// <summary>
    /// The position of an object in the simulator/world
    /// </summary>
    public class WorldPosition
    {
        public Vector3 Position
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
        private Vector3 position;

        public WorldPosition(Vector3 pos) 
        {
            Position = pos;
        }

        public void Translate(Vector3 pos)
        {
            Position += pos;
        }
    }
}
