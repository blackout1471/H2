using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortePer
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new SortePerGame(new Player[] { new Human("Emil", () => GetNumberFromInput()), new BotPlayer() });
            game.StartGame();
            Console.WriteLine(game.StartGameMessage());

            bool hasGameEnded = false;
            while (!hasGameEnded)
            {
                Console.WriteLine(game.PlayerTakeTurnMessage());
                game.PlayerTakeTurn();

                Console.WriteLine(game.ChangePlayerMessage());
                Console.ReadKey();

                Console.Clear();

                if (!(hasGameEnded = game.HasGameEnded()))
                    game.ChangePlayer();
            }

            Console.WriteLine(game.GameHasEndedMessage());
            Console.ReadKey();
        }

        static int GetNumberFromInput()
        {
            bool validated = false;
            int val = 0;

            while (!validated)
            {
                string s = Console.ReadLine();
                if (int.TryParse(s, out val))
                    validated = true;
            }

            return val;
        }
    }
}
