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
        public Container IngredientContainer
        {
            get
            {
                return ingredientContainer;
            }

            private set
            {
                ingredientContainer = value;
            }
        }

        private Container waterContainer;
        private Container ingredientContainer;

        public DripCoffeMachine()
        {
            WaterContainer = new Container(2);
            IngredientContainer = new Container(1f);
        }
        
        private float GetAmountFromBrew()
        {
            return WaterContainer.CurrentCapacity;
        }

        public override void AddIngredient(Ingredient ingredient, float gram)
        {
            if (IngredientContainer.CurrentCapacity < IngredientContainer.MaxCapacity)
            {
                IngredientContainer.CurrentCapacity += gram;
                IngredientContainer.Ingredient = ingredient;
            }
        }

        public override void AddWater(float liter)
        {
            if (WaterContainer.CurrentCapacity < WaterContainer.MaxCapacity)
                WaterContainer.CurrentCapacity += liter;
        }

        public override void Brew()
        {
            ProductContainer.CurrentCapacity += GetAmountFromBrew();
            ProductContainer.Ingredient = IngredientContainer.Ingredient;
            WaterContainer.CurrentCapacity = 0;
            IngredientContainer.CurrentCapacity = 0;
            IngredientContainer.Ingredient = null;
        }

    }
}
