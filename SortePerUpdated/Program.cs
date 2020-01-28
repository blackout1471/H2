using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortePerUpdated
{
    class Program
    {
        static void Main(string[] args)
        {
            SortePerGame game = new SortePerGame(
                (x) => Console.WriteLine(x),
                new BotPlayer("Bot"),
                new BotPlayer("Bot2"),
                new BotPlayer("Bot3"),
                new BotPlayer("Bot4")
                );
            game.StartGame();
            Console.ReadKey();
        }

        /// <summary>
        /// Gets a valid input from a string
        /// and convert it to a int
        /// will loop until successfull convertion
        /// </summary>
        /// <returns></returns>
        static int GetNumberFromInput()
        {
            bool validated = false;
            int val = 0;

            while (!validated)
                if (int.TryParse(Console.ReadLine(), out val))
                    validated = true;
                    

            return val;
        }
    }
}
