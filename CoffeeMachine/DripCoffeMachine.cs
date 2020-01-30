using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    public class DripCoffeMachine : CoffeeMachine
    {
        public Container WaterContainer
        {
            get
            {
                return waterContainer;
            }

            private set
            {
                waterContainer = value;
            }
        }
        public Container CoffeeContainer
        {
            get
            {
                return coffeeContainer;
            }

            private set
            {
                coffeeContainer = value;
            }
        }

        private Container waterContainer;
        private Container coffeeContainer;

        public DripCoffeMachine()
        {
            WaterContainer = new Container(2);
            CoffeeContainer = new Container(0.5f);
        }
        
        private float GetAmountFromBrew()
        {
            return WaterContainer.CurrentCapacity;
        }

        public override void AddCoffeeIngredient(float gram)
        {
            if (CoffeeContainer.CurrentCapacity < CoffeeContainer.CurrentCapacity)
                CoffeeContainer.CurrentCapacity += gram;
        }

        public override void AddWater(float liter)
        {
            if (WaterContainer.CurrentCapacity < WaterContainer.MaxCapacity)
                WaterContainer.CurrentCapacity += liter;
        }

        public override void BrewCoffee()
        {
            ProductContainer.CurrentCapacity += GetAmountFromBrew();
            WaterContainer.CurrentCapacity = 0;
            CoffeeContainer.CurrentCapacity = 0;
        }

    }
}
