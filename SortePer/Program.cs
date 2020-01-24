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
            Game game = new SortePerGame(new Player[] { new Human("Emil"), new Human("Bot") });
            game.StartGame();

            while (!game.HasGameEnded())
            {
                Console.WriteLine("It is {0}'s turn", game.CurrentPlayer.Name);
                Console.WriteLine("Choose between {0}-{1} of your enemies cards", 0, game.PeekNextPlayer.Cards.Count-1);

                game.PlayerTakeTurn(5);
                game.ChangePlayer();
            }

            Console.WriteLine("");
            Console.ReadKey();
        }
    }
}
