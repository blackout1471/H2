using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    /// <summary>
    /// A container which will hold a beverage/ingredient
    /// </summary>
    public class Container
    {
        public float MaxCapacity
        {
            get
            {
                return maxCapacity;
            }

            private set
            {
                maxCapacity = value;
            }
        }

        public float CurrentCapacity
        {
            get
            {
                return currentCapacity;
            }

            set
            {
                currentCapacity = value;
            }
        }

        public Ingredient Ingredient
        {
            get
            {
                return ingredient;
            }

            set
            {
                ingredient = value;
            }
        }

        private float maxCapacity;
        private float currentCapacity;
        private Ingredient ingredient;

        public Container(float maxCapacity)
        {
            MaxCapacity = maxCapacity;
        }
    }
}
