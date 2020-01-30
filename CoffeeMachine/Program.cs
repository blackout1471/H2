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
            a.ChangeFilter(new Filter(100, 3));
            a.ChangeProductContainer(new Container(2));
            a.AddCoffeeIngredient(200);
            a.AddWater(1);
            a.TurnOn();
            a.BrewCoffee();
            a.TurnOff();
            Container cup = a.TakeProduct();

            Console.ReadKey();
        }
    }
}
