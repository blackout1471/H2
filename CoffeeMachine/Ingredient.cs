using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    public abstract class Ingredient
    {
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

        private string name;

        public Ingredient(string name)
        {
            Name = name;
        }
    }
}
