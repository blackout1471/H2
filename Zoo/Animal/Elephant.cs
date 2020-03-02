using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.turd;

namespace Zoo.Animal
{
    public class Elephant : Animal
    {
        public Elephant(string name) : base(name, 10)
        {
        }

        protected override Turd Shit()
        {
            return new ElephantTurd();
        }
    }
}
