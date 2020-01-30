using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    /// <summary>
    /// This class can brew from an ingredient
    /// </summary>
    public abstract class CoffeeMachine : Machine
    {
        /// <summary>
        /// The filter used to in the coffeemaker
        /// </summary>
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

        /// <summary>
        /// The output container ex: cup
        /// </summary>
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

        /// <summary>
        /// Change the output container
        /// </summary>
        /// <param name="productContainer"></param>
        public void ChangeProductContainer(Container productContainer)
        {
            ProductContainer = productContainer;
        }

        /// <summary>
        /// Take the product from the machine
        /// </summary>
        /// <returns></returns>
        public Container TakeProduct()
        {
            Container product = ProductContainer;
            ProductContainer = null;
            return product;
        }

        /// <summary>
        /// Adds an ingredient to the machine, which it will brew on
        /// </summary>
        /// <param name="ingredient"></param>
        /// <param name="gram"></param>
        public abstract void AddIngredient(Ingredient ingredient, float gram);
        public abstract void AddWater(float liter);

        /// <summary>
        /// Make the current beverage
        /// </summary>
        public abstract void Brew();
    }
}
