using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
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

        private float maxCapacity;
        private float currentCapacity;

        public Container(float maxCapacity)
        {
            MaxCapacity = maxCapacity;
        }
    }
}
