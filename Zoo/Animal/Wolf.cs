using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.turd;

namespace Zoo.Animal
{
    public class Wolf : Animal
    {
        public Wolf(string name) : base(name, 13)
        {
        }

        protected override Turd Shit()
        {
            return new WolfTurd();
        }
    }
}
