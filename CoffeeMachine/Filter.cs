using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    public struct Filter
    {
        public int Holes
        {
            get
            {
                return holes;
            }

            private set
            {
                holes = value;
            }
        }

        public int Layers
        {
            get
            {
                return layers;
            }

            private set
            {
                layers = value;
            }
        }

        private int holes;
        private int layers;

        public Filter(int holes, int layers) : this()
        {
            Holes = holes;
            Layers = layers;
        }
        
    }
}
