using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsFlyingAround
{
    public class Seagull : Bird, IFlyAble
    {
        public Seagull(WorldPosition pos) : base("Seagull", pos)
        {
        }

        public void Fly(Vector3 direction)
        {
            Position.Translate(direction);
        }
    }
}
