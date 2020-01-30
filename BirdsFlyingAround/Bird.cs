using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsFlyingAround
{
    public abstract class Bird : Animal
    {
        public Bird(string name, WorldPosition pos): base(name, pos) { }
    }
}
