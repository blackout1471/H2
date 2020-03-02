using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.turd;

namespace Zoo.Animal
{
    public class Giraff : Animal
    {
        public Giraff(string name) : base(name, 18)
        {
        }

        protected override Turd Shit()
        {
            return new GiraffTurd();
        }
    }
}
