using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.turd;

namespace Zoo.Animal
{
    public class Rabbit : Animal
    {
        public Rabbit(string name) : base(name, 8)
        {
        }

        protected override Turd Shit()
        {
            return new RabbitTurd();
        }
    }
}
