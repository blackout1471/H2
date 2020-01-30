using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            CoffeeMachine a = new DripCoffeMachine();

            // Coffee
            a.ChangeFilter(new Filter(100, 3));
            a.ChangeProductContainer(new Container(2));
            a.AddIngredient(new Coffee(), 200);
            a.AddWater(1);
            a.TurnOn();
            a.Brew();
            a.TurnOff();
            Container coffeCup = a.TakeProduct();

            // The
            a.ChangeFilter(new Filter(100, 3));
            a.ChangeProductContainer(new Container(2));
            a.AddIngredient(new The(), 200);
            a.AddWater(1);
            a.TurnOn();
            a.Brew();
            a.TurnOff();
            Container theCup = a.TakeProduct();

            // Espresso
            a.ChangeFilter(new Filter(100, 3));
            a.ChangeProductContainer(new Container(2));
            a.AddIngredient(new Espresso(), 200);
            a.AddWater(1);
            a.TurnOn();
            a.Brew();
            a.TurnOff();
            Container espressoCup = a.TakeProduct();

            Console.ReadKey();
        }
    }
}
