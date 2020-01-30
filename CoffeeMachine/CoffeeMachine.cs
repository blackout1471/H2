using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    public abstract class CoffeeMachine : Machine
    {
        public Filter Filter
        {
            get
            {
                return filter;
            }

            private set
            {
                filter = value;
            }
        }
        public Container ProductContainer
        {
            get
            {
                return productContainer;
            }

            private set
            {
                productContainer = value;
            }
        }

        private Filter filter;
        private Container productContainer;
        
        public CoffeeMachine() { }

        public void ChangeFilter(Filter filter)
        {
            Filter = filter;
        }

        public void ChangeProductContainer(Container productContainer)
        {
            ProductContainer = productContainer;
        }

        public Container TakeProduct()
        {
            Container product = ProductContainer;
            ProductContainer = null;
            return product;
        }

        public abstract void AddCoffeeIngredient(float gram);
        public abstract void AddWater(float liter);
        public abstract void BrewCoffee();
    }
}
